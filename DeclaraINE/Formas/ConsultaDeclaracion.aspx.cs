using Declara_V2.BLLD;
using DeclaraINAI.Formas.DeclaracionInicial;
using DeclaraINAI.Formas.DeclaracionModificacion;
using DeclaraINAI.Formas.DeclaracionConclusion;
using DeclaraINAI.Formas.DeclaracionConflicto;
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

namespace DeclaraINAI.Formas
{
    public partial class ConsultaDeclaracion : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }

        blld_DECLARACION _oDeclaracionTemp
        {
            get => (blld_DECLARACION)Session["oDeclaracionTemp"];
            set => SessionAdd("oDeclaracionTemp", value);
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            blld_USUARIO oUsuario = _oUsuario;
            string VID_RFC = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE;


            if (!IsPostBack)
            {
                Page.Title = "Consulta de Declaraciones";

                ltrSubTitulo.Text = "Declaración Patrimonial";
                oUsuario.Reload_DECLARACIONs();
                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                o.VID_NOMBRE = new Declara_V2.StringFilter(oUsuario.VID_NOMBRE);
                o.VID_FECHA = new Declara_V2.StringFilter(oUsuario.VID_FECHA);
                o.VID_HOMOCLAVE = new Declara_V2.StringFilter(oUsuario.VID_HOMOCLAVE);
                o.NID_ESTADOs.FilterCondition = ListFilter.FilterConditions.Negated;
                o.NID_ESTADOs.Add(1);
                o.NID_ESTADOs.Add(6);
                o.NID_ESTADOs.Add(7);
                o.select();
                List<Declara_V2.BLLD.DeclaracionesInformeDetalle> Declaraciones = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();
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
                    try
                    {
                        oDeclaracion = new blld_DECLARACION
                                                              (
                                                                VID_RFC.Substring(0, 4)
                                                              , VID_RFC.Substring(4, 6)
                                                              , VID_RFC.Substring(10, 3)
                                                              , 1
                                                               );
                    }
                    catch
                    { }
                }
                blld_USUARIO oUsuarioDeclaracion = new blld_USUARIO
                                                         (
                                                               VID_RFC.Substring(0, 4)
                                                             , VID_RFC.Substring(4, 6)
                                                             , VID_RFC.Substring(10, 3)
                                                          );

                foreach (DECLARACION_DIARIA dec in o.lista_DECLARACION_DIARIA)
                {
                    Declaraciones.Add(
                                      new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                            2
                                          , dec.C_EJERCICIO
                                          , dec.NID_DECLARACION
                                          , dec.NID_TIPO_DECLARACION
                                          , dec.F_ENVIO.ToString()
                                          , dec.NID_ESTADO)
                                                                      );
                }



                grdDP.DataSource = Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToArray();
                grdDP.DataBind();

            }
        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGridDeclaracion_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);

            try
            {
                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();

                //----- CONSULTAMOS SI ESTA BINARIZADO
                String File = "";
                byte[] b1 = null;

                registro = db.DECLARACION.Find(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION);
                b1 = registro.B_FILE_DECLARACION;

                string TipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == oDeclaracion.NID_TIPO_DECLARACION).First().V_TIPO_DECLARACION;

                if (b1 == null)
                {
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
                    SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { oUsuario.VID_NOMBRE
                                                                               ,oUsuario.VID_FECHA
                                                                               ,oUsuario.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
                    registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
                    registro.B_FILE_DECLARACION = sf.FileBytes;
                    db.SaveChanges();


                    registro = db.DECLARACION.Find(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION);
                    b1 = registro.B_FILE_DECLARACION;
                }

                FileStream fs1;
                File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
                fs1 = new FileStream(File, FileMode.Create);
                fs1.Write(b1, 0, b1.Length);
                fs1.Close();
                fs1 = null;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/pdf"; // sf.MimeType;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Declaracion_" + TipoDeclaracion + "_" + oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE + ".pdf");
                HttpContext.Current.Response.WriteFile(File);
                HttpContext.Current.Response.Flush();
                System.IO.File.Delete(File);
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
            }
        }


        protected void btnGridDeclaracionAcuse_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);

            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);

            switch (oDeclaracion.NID_TIPO_DECLARACION)
            {
                case 1:
                    _Inicial.ImprimirAcuseInicial(oDeclaracion, _oUsuario);
                    break;
                case 2:
                    _Modificacion.ImprimirAcuseModificacion(oDeclaracion, _oUsuario);
                    break;
                case 3:
                    _Conclusion.ImprimirAcuseConclusion(oDeclaracion, _oUsuario);
                    break;
                default:
                    break;
            }

        }

        protected void btnAclaraciones_Click(object sender, EventArgs e)
        {
            Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
            Response.Redirect("AgregarObservacion.aspx?idDec=" + NID_DECLARACION);
        }

        protected void btnGridDeclaracionConstanciaEticaConducta_Click(object sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);
                string vTipoAcuse = string.Empty;
                switch (oDeclaracion.NID_TIPO_DECLARACION)
                {
                    case 1:
                        vTipoAcuse = "ACUSE_CONSTANCIA_ETICA_DI";
                        break;
                    case 2:
                        vTipoAcuse = "ACUSE_CONSTANCIA_ETICA_DM";
                        break;
                    default:
                        break;
                }

                file.fileSoapClient o = new file.fileSoapClient();
                FileStream fs1;
                SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, vTipoAcuse, new List<object> { oUsuario.VID_NOMBRE
                                                                               ,oUsuario.VID_FECHA
                                                                               ,oUsuario.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
                byte[] b1 = sf.FileBytes;
                String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
                fs1 = new FileStream(File, FileMode.Create);
                fs1.Write(b1, 0, b1.Length);
                fs1.Close();
                fs1 = null;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/pdf"; // sf.MimeType;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
                HttpContext.Current.Response.WriteFile(File);
                HttpContext.Current.Response.Flush();
                System.IO.File.Delete(File);
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnGridDeclaracionConstanciaCodigoConducta_Click(object sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);
                string vTipoAcuse = string.Empty;

                int ejercicio = Convert.ToInt32( oDeclaracion.C_EJERCICIO);
               
                vTipoAcuse = "ACUSE_CONSTANCIA_CONDUCTA";

                file.fileSoapClient o = new file.fileSoapClient();
                FileStream fs1;
                SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, vTipoAcuse, new List<object> { oUsuario.VID_NOMBRE
                                                                               ,oUsuario.VID_FECHA
                                                                               ,oUsuario.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
                byte[] b1 = sf.FileBytes;
                String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
                fs1 = new FileStream(File, FileMode.Create);
                fs1.Write(b1, 0, b1.Length);
                fs1.Close();
                fs1 = null;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/pdf"; // sf.MimeType;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
                HttpContext.Current.Response.WriteFile(File);
                HttpContext.Current.Response.Flush();
                System.IO.File.Delete(File);
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
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


                if (vTipo == "Inicial") { 
                    ((Button)e.Row.FindControl("btnGridDeclaracionConstanciaEticaConducta")).Text = "Declaración de Aceptación de cumplimiento al código de ética";
                    ((Button)e.Row.FindControl("btnGridDeclaracionConstanciaCodigoConducta")).Text = "Acuse de cumplimiento al código de conducta";
                    if (Convert.ToInt32(ejercicio) < 2022)
                    {
                        ((Button)e.Row.FindControl("btnGridDeclaracionConstanciaCodigoConducta")).Visible = false;
                    }
                    
                }
                if (vTipo == "Modificación") { 
                    ((Button)e.Row.FindControl("btnGridDeclaracionConstanciaEticaConducta")).Text = "Declaración Anual de cumplimiento al código de ética";
                    ((Button)e.Row.FindControl("btnGridDeclaracionConstanciaCodigoConducta")).Text = "Acuse de cumplimiento al código de conducta";
                    if (Convert.ToInt32(ejercicio) < 2021)
                    {
                        ((Button)e.Row.FindControl("btnGridDeclaracionConstanciaCodigoConducta")).Visible = false;
                    }
                }
                //if (vTipo == "Conclusión" || !ejercicioValido) oevm 20200724
                if (vTipo == "Conclusión") { 
                    ((Button)e.Row.FindControl("btnGridDeclaracionConstanciaEticaConducta")).Visible = false;
                    ((Button)e.Row.FindControl("btnGridDeclaracionConstanciaCodigoConducta")).Visible = false;
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

    }
}