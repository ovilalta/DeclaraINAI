﻿using Declara_V2.BLLD;
using System;
using System.IO;
using System.Web;
using System.Linq;
using DeclaraINAI.file;
using System.Collections.Generic;
using Declara_V2.MODELextended;
using Declara_V2;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace DeclaraINAI.Formas
{
    public partial class EliminarConclusionErronea : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;

            string VID_RFC = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE;
            if (!IsPostBack)
            {
                rbRFC.Checked = true;
                Page.Title = "Eliminar declaración de conclusión";
                string line;
                bool excep = false;
                var buildDir = HttpRuntime.AppDomainAppPath;
                var filePath = buildDir + @"\Formas\Administrador\Administradores.txt";
                StreamReader file = new StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    if (VID_RFC.Equals(line))
                    {
                        excep = true;
                    }
                }
                file.Close();
                if (excep == false)
                {
                    Response.Redirect("..\\Index.aspx");
                }
            }
        }

        List<Declara_V2.BLLD.DeclaracionesInformeDetalle> Declaraciones = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();

        private void BuscarDeclaraciones(string txtRfc)
        {
            try
            {
                string VID_RFC = txtRfc;

                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();

                o.VID_NOMBRE = new Declara_V2.StringFilter(VID_RFC.Substring(0, 4));
                o.VID_FECHA = new Declara_V2.StringFilter(VID_RFC.Substring(4, 6));
                o.VID_HOMOCLAVE = new Declara_V2.StringFilter(txtRfc.Substring(10, 3));
                o.NID_ESTADOs.FilterCondition = ListFilter.FilterConditions.Negated;
                //o.NID_ESTADOs.Add(1);
                o.NID_ESTADOs.Add(6);
                o.NID_ESTADOs.Add(7);
                o.select();

                List<Declara_V2.BLLD.DeclaracionesInformeDetalle> DeclaracionesAntiguas = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();

                blld_DECLARACION oDeclaracion;

                if (o.lista_DECLARACION_DIARIA.Any())
                {
                    oDeclaracion = new blld_DECLARACION
                                                              (
                                                                VID_RFC.Substring(0, 4)
                                                              , VID_RFC.Substring(4, 6)
                                                              , VID_RFC.Substring(10, 3)
                                                              , o.lista_DECLARACION_DIARIA.Last().NID_DECLARACION
                                                               );
                }
                else
                {
                    oDeclaracion = new blld_DECLARACION
                                                          (
                                                            VID_RFC.Substring(0, 4)
                                                          , VID_RFC.Substring(4, 6)
                                                          , VID_RFC.Substring(10, 3)
                                                          , 1
                                                           );
                }
                blld_USUARIO oUsuarioDeclaracion = new blld_USUARIO
                                                         (
                                                               VID_RFC.Substring(0, 4)
                                                             , VID_RFC.Substring(4, 6)
                                                             , VID_RFC.Substring(10, 3)
                                                          );

                foreach (DECLARACION_DIARIA dec in o.lista_DECLARACION_DIARIA.Where(p => p.NID_TIPO_DECLARACION == 3))
                {
                    Declaraciones.Add(
                                      new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                            2
                                          , dec.C_EJERCICIO
                                          , dec.NID_DECLARACION
                                          , dec.NID_TIPO_DECLARACION
                                          , dec.F_ENVIO.ToString()
                                          , dec.NID_ESTADO
                                          , dec.V_NOMBRE_COMPLETO
                                          , dec.VID_NOMBRE
                                          , dec.VID_FECHA
                                          , dec.VID_HOMOCLAVE
                                         )
                                                                      );
                }
            }

            catch
            {
                //msgBox.ShowDanger("No está registrado el usuario con RFC: " + txtRfc.Text + " en DeclaraINAI.");
                msgBox.ShowDanger("No está registrado el usuario con RFC: " + txtRfc + " en DeclaraINAI o no cuenta con declaraciones patrimoniales.");
                grdDP.DataSource = null;
                grdDP.DataBind();
            }
        }

        //Ver si puedo quitar este método
        protected void btnDescargar_Click(object sender, EventArgs e)
        {

            if (txtRfc.Text == "" || txtRfc.Text == null)
            {
                msgBox.ShowDanger("Debe especificar un RFC.");
            }
            else
            {
                //Busqueda de declaraciones por RFC
                if (rbRFC.Checked == true)
                {
                    BuscarDeclaraciones(txtRfc.Text);
                }                
            }

            grdDP.DataSource = Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.V_NOMBRE_COMPLETO).ToArray();
            grdDP.DataBind();
        }

        protected void btnEliminarConclusion_Click(object sender, EventArgs e)
        {
            
            if (txtRfc.Text.Length == 13)
            {
                #region Logica agregar a tabla el RFC  que se autorizara para actualizar acuse fiscal
                
                Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);

                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                string connString = db.Database.Connection.ConnectionString;
                string sql = "SP_LimpiaDeclaracion";
                int rpta = 0;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@usuario", txtRfc.Text.Substring(0,4));
                            cmd.Parameters.AddWithValue("@declaracion", NID_DECLARACION);
                            cmd.Parameters.AddWithValue("@usuarioFecha", txtRfc.Text.Substring(4, 6));

                            rpta = cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        rpta = 0;
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                #endregion

                if (rpta == -1)
                {
                    msgBox.ShowSuccess("Se eliminó de manera correcta la declaración de conclusión del RFC: " + txtRfc.Text.ToUpper() );
                    txtRfc.Text = "";
                }
                else
                {
                    msgBox.ShowWarning("No fue posible eliminar la declaración de conclusión del RFC: " + txtRfc.Text.ToUpper() + " , favor de validar la información");
                    txtRfc.Text = "";
                }
            }
            else
            {
                msgBox.ShowDanger("El RFC no tiene 13 caracteres, por favor revise la información");
            }
        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGridDeclaracion_Click(object sender, EventArgs e)
        {

            int tamanioTotal = ((Button)sender).CommandArgument.Length;
            int tamanioArg1 = tamanioTotal - 14;
            int inicioArg2 = tamanioArg1 + 1;
            Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument.Substring(0, tamanioArg1));
            string rfc = Convert.ToString(((Button)sender).CommandArgument.Substring(inicioArg2, 13));


            //blld_USUARIO oUsuarioReporte = new blld_USUARIO(rfc);
            MODELDeclara_V2.cnxDeclara bd = new MODELDeclara_V2.cnxDeclara();
            string connString = bd.Database.Connection.ConnectionString;
            int existeUsuario = bd.USUARIO.Where(p => p.VID_NOMBRE.Equals(rfc.Substring(0, 4))
            && p.VID_FECHA.Equals(rfc.Substring(4, 6)) && p.VID_HOMOCLAVE.Equals(rfc.Substring(10, 3))).Count();

            if (existeUsuario != 0)
            {
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(rfc.Substring(0, 4), rfc.Substring(4, 6), rfc.Substring(10, 3), NID_DECLARACION);
                try
                {
                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();

                    //----- CONSULTAMOS SI ESTA BINARIZADO
                    String File = "";
                    byte[] b1 = null;

                    registro = db.DECLARACION.Find(rfc.Substring(0, 4), rfc.Substring(4, 6), rfc.Substring(10, 3), oDeclaracion.NID_DECLARACION);


                    string TipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == oDeclaracion.NID_TIPO_DECLARACION).First().V_TIPO_DECLARACION;


                    String VersionDeclaracion = string.Empty;

                    int nTipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == oDeclaracion.NID_TIPO_DECLARACION).First().NID_TIPO_DECLARACION;

                    blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                    oPuesto.select();
                    var obligado = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single().L_OBLIGADO;

                    switch (nTipoDeclaracion)
                    {
                        case 1:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_INICIAL";
                            else
                                VersionDeclaracion = "DECLARACION_INICIAL_SIMPLI";
                            break;
                        case 2:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_MODIFICACION";
                            else
                                VersionDeclaracion = "DECLARACION_MODIFICACION_SIMPLI";
                            break;
                        case 3:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_CONCLUSION";
                            else
                                VersionDeclaracion = "DECLARACION_CONCLUSION_SIMPLI";
                            break;
                    }

                    file.fileSoapClient o = new file.fileSoapClient();
                    SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { rfc.Substring(0, 4)
                                                                               ,rfc.Substring(4, 6)
                                                                               ,rfc.Substring(10, 3)
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
                    registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
                    registro.B_FILE_DECLARACION = sf.FileBytes;
                    db.SaveChanges();


                    registro = db.DECLARACION.Find(rfc.Substring(0, 4), rfc.Substring(4, 6), rfc.Substring(10, 3), oDeclaracion.NID_DECLARACION);
                    b1 = registro.B_FILE_DECLARACION;


                    FileStream fs1;
                    File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
                    fs1 = new FileStream(File, FileMode.Create);
                    fs1.Write(b1, 0, b1.Length);
                    fs1.Close();
                    fs1 = null;
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "application/pdf"; // sf.MimeType;
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Declaracion_" + TipoDeclaracion + "_" + rfc + ".pdf");
                    HttpContext.Current.Response.WriteFile(File);
                    HttpContext.Current.Response.Flush();
                    System.IO.File.Delete(File);

                    HttpContext.Current.Response.End();


                }
                catch (Exception ex)
                {
                }
            }

        }

        protected void grdDP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string vTipo = ((Literal)e.Row.FindControl("ltrDescripcionDP")).Text;
                string ejercicio = ((Literal)e.Row.FindControl("ltrEjercicioDP")).Text;
                int ejercicioInt;
                var ejercicioValido = true;

                if (int.TryParse(ejercicio, out ejercicioInt))
                {
                    ejercicioValido = ejercicioInt >= 2020;
                }

            }
        }

        public static string GetSHA1(String texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }

        protected void btnGridDeclaracionAcuse_Click(object sender, EventArgs e)
        {
            int tamanioTotal = ((Button)sender).CommandArgument.Length;
            int tamanioArg1 = tamanioTotal - 14;
            int inicioArg2 = tamanioArg1 + 1;
            Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument.Substring(0, tamanioArg1));
            string rfc = Convert.ToString(((Button)sender).CommandArgument.Substring(inicioArg2, 13));

            //blld_USUARIO oUsuarioReporte = new blld_USUARIO(rfc);
            MODELDeclara_V2.cnxDeclara bd = new MODELDeclara_V2.cnxDeclara();
            string connString = bd.Database.Connection.ConnectionString;
            int existeUsuario = bd.USUARIO.Where(p => p.VID_NOMBRE.Equals(rfc.Substring(0, 4))
            && p.VID_FECHA.Equals(rfc.Substring(4, 6)) && p.VID_HOMOCLAVE.Equals(rfc.Substring(10, 3))).Count();

            if (existeUsuario != 0)
            {

                //Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(rfc.Substring(0, 4), rfc.Substring(4, 6), rfc.Substring(10, 3), NID_DECLARACION);

                try
                {
                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();

                    //----- CONSULTAMOS SI ESTA BINARIZADO
                    String File = "";
                    byte[] b1 = null;

                    registro = db.DECLARACION.Find(rfc.Substring(0, 4), rfc.Substring(4, 6), rfc.Substring(10, 3), oDeclaracion.NID_DECLARACION);
                    //b1 = registro.B_FILE_DECLARACION;

                    string TipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == oDeclaracion.NID_TIPO_DECLARACION).First().V_TIPO_DECLARACION;

                    //if (b1 == null)
                    //{
                    String VersionDeclaracion = string.Empty;

                    int nTipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == oDeclaracion.NID_TIPO_DECLARACION).First().NID_TIPO_DECLARACION;

                    blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                    oPuesto.select();
                    var obligado = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single().L_OBLIGADO;

                    switch (nTipoDeclaracion)
                    {
                        case 1:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_INICIAL_PUB";
                            else
                                VersionDeclaracion = "DECLARACION_INICIAL_SIMPLI_PUB";
                            break;
                        case 2:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_MODIFICACION_PUB";
                            else
                                VersionDeclaracion = "DECLARACION_MODIFICACION_SIMPLI_PUB";
                            break;
                        case 3:
                            if (obligado.Equals(true))
                                VersionDeclaracion = "DECLARACION_CONCLUSION_PUB";
                            else
                                VersionDeclaracion = "DECLARACION_CONCLUSION_SIMPLI_PUB";
                            break;
                    }



                    file.fileSoapClient o = new file.fileSoapClient();
                    SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { rfc.Substring(0, 4)
                                                                               ,rfc.Substring(4, 6)
                                                                               ,rfc.Substring(10, 3)
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
                    registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
                    registro.B_FILE_DECLARACION = sf.FileBytes;
                    db.SaveChanges();


                    registro = db.DECLARACION.Find(rfc.Substring(0, 4), rfc.Substring(4, 6), rfc.Substring(10, 3), oDeclaracion.NID_DECLARACION);


                    b1 = registro.B_FILE_DECLARACION;
                    //}

                    FileStream fs1;
                    File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
                    fs1 = new FileStream(File, FileMode.Create);
                    fs1.Write(b1, 0, b1.Length);
                    fs1.Close();
                    fs1 = null;
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "application/pdf"; // sf.MimeType;
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Declaracion_" + TipoDeclaracion + "_" + rfc + ".pdf");
                    HttpContext.Current.Response.WriteFile(File);
                    HttpContext.Current.Response.Flush();
                    System.IO.File.Delete(File);

                    //Codigo para no dejar bloqueado al usuario por la sesion abierta

                    HttpContext.Current.Response.End();


                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void grdDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rfc = grdDP.Rows[0].Cells[0].Text;
        }
    }
}