using Declara_V2.BLLD;
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

namespace DeclaraINAI.Formas.Administrador
{
    public partial class GeneraDeclaracion : Pagina
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
                Page.Title = "Generación de Declaraciones";
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

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuarioDesc = new blld_USUARIO(txtRfc.Text);                
                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                int nid_Estado = Convert.ToInt32(o.NID_ESTADO); // OEVM
                string VID_RFC = oUsuarioDesc.VID_NOMBRE + oUsuarioDesc.VID_FECHA + oUsuarioDesc.VID_HOMOCLAVE;
                o.VID_NOMBRE = new Declara_V2.StringFilter(oUsuarioDesc.VID_NOMBRE);
                o.VID_FECHA = new Declara_V2.StringFilter(oUsuarioDesc.VID_FECHA);
                o.VID_HOMOCLAVE = new Declara_V2.StringFilter(oUsuarioDesc.VID_HOMOCLAVE);
                //o.NID_ESTADOs.Add(2);  //OEVM filtro que busca permitir que solo se descarguen declaraciones concluidas
                o.NID_TIPO_DECLARACION = new Declara_V2.IntegerFilter(Convert.ToInt32(txtIdDeclaracion.Text)); //OEVM agregar filtro del id de la declaración 1, 2, 3 Inicial, Modificación, Conclusión
                o.NID_ESTADOs.FilterCondition = ListFilter.FilterConditions.Negated;
                o.NID_ESTADOs.Add(1);
                o.NID_ESTADOs.Add(6);
                o.NID_ESTADOs.Add(7);
                
                
                o.select();
                List<Declara_V2.BLLD.DeclaracionesInformeDetalle> Declaraciones = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();
                List<Declara_V2.BLLD.DeclaracionesInformeDetalle> DeclaracionesAntiguas = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();

                blld_DECLARACION oDeclaracion;

                

                //if (nid_Estado == 2)
                //{
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

                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();
                    var xxx = Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToArray();

                    String File = "";
                    byte[] b1 = null;

                    if (xxx.Length != 0)
                        registro = db.DECLARACION.Find(oUsuarioDesc.VID_NOMBRE, oUsuarioDesc.VID_FECHA, oUsuarioDesc.VID_HOMOCLAVE, xxx[0].NID_DECLARACION);

                    else
                        registro = db.DECLARACION.Find(oUsuarioDesc.VID_NOMBRE, oUsuarioDesc.VID_FECHA, oUsuarioDesc.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION);

                    //b1 = registro.B_FILE_DECLARACION;
                    b1 = null;

                    string TipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == registro.NID_TIPO_DECLARACION).First().V_TIPO_DECLARACION;

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
                                //VersionDeclaracion = "DECLARACION_INICIAL_PUB";
                                else
                                    VersionDeclaracion = "DECLARACION_INICIAL_SIMPLI";
                                //VersionDeclaracion = "DECLARACION_INICIAL_SIMPLI_PUB";
                                break;
                            case 2:
                                if (obligado.Equals(true))
                                    VersionDeclaracion = "DECLARACION_MODIFICACION";
                                //VersionDeclaracion = "DECLARACION_MODIFICACION_PUB";
                                else
                                    VersionDeclaracion = "DECLARACION_MODIFICACION_SIMPLI";
                                //VersionDeclaracion = "DECLARACION_MODIFICACION_SIMPLI_PUB";
                                break;
                            case 3:
                                if (obligado.Equals(true))
                                    VersionDeclaracion = "DECLARACION_CONCLUSION";
                                //VersionDeclaracion = "DECLARACION_CONCLUSION_PUB";
                                else
                                    VersionDeclaracion = "DECLARACION_CONCLUSION_SIMPLI";
                                //VersionDeclaracion = "DECLARACION_CONCLUSION_SIMPLI_PUB";
                                break;
                        }

                        file.fileSoapClient oo = new file.fileSoapClient();
                        SerializedFile sf = oo.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { oUsuarioDesc.VID_NOMBRE
                                                                               ,oUsuarioDesc.VID_FECHA
                                                                               ,oUsuarioDesc.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
                        registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
                        registro.B_FILE_DECLARACION = sf.FileBytes;
                        db.SaveChanges(); //OEVM 20200902

                        b1 = registro.B_FILE_DECLARACION; //OEVM20200902
                        registro = db.DECLARACION.Find(oUsuarioDesc.VID_NOMBRE, oUsuarioDesc.VID_FECHA, oUsuarioDesc.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION);
                        //b1 = registro.B_FILE_DECLARACION;
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
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Declaracion_" + TipoDeclaracion + "_" + oUsuarioDesc.VID_NOMBRE + oUsuarioDesc.VID_FECHA + oUsuarioDesc.VID_HOMOCLAVE + ".pdf");
                    HttpContext.Current.Response.WriteFile(File);
                    HttpContext.Current.Response.Flush();
                    System.IO.File.Delete(File);
                    HttpContext.Current.Response.End();
                //}
                
            }

            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                popupErr.Show();
            }
        }

        //protected void btnMostrar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("..\\ConsultaDeclaracionAdmin.aspx?rfc=" + txtRfc.Text);
        //}

        protected void btnDescargarPub_Click(object sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuarioDesc = new blld_USUARIO(TextRfcPub.Text);
                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                string VID_RFC = oUsuarioDesc.VID_NOMBRE + oUsuarioDesc.VID_FECHA + oUsuarioDesc.VID_HOMOCLAVE;
                o.VID_NOMBRE = new Declara_V2.StringFilter(oUsuarioDesc.VID_NOMBRE);
                o.VID_FECHA = new Declara_V2.StringFilter(oUsuarioDesc.VID_FECHA);
                o.VID_HOMOCLAVE = new Declara_V2.StringFilter(oUsuarioDesc.VID_HOMOCLAVE);
                o.NID_ESTADO = new Declara_V2.IntegerFilter(Convert.ToInt32(2)); //OEVM filtro que busca permitir que solo se descarguen declaraciones concluidas
                o.NID_TIPO_DECLARACION = new Declara_V2.IntegerFilter(Convert.ToInt32(txtIdDeclaracionPub.Text)); //OEVM agregar filtro del id de la declaración 1, 2, 3 Inicial, Modificación, Conclusión
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

                    oDeclaracion = new blld_DECLARACION
                                                          (
                                                            VID_RFC.Substring(0, 4)
                                                          , VID_RFC.Substring(4, 6)
                                                          , VID_RFC.Substring(10, 3)
                                                          , 1
                                                           );

                }

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

                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();
                var xxx = Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToArray();

                String File = "";
                byte[] b1 = null;

                if (xxx.Length != 0)
                    registro = db.DECLARACION.Find(oUsuarioDesc.VID_NOMBRE, oUsuarioDesc.VID_FECHA, oUsuarioDesc.VID_HOMOCLAVE, xxx[0].NID_DECLARACION);

                else
                    registro = db.DECLARACION.Find(oUsuarioDesc.VID_NOMBRE, oUsuarioDesc.VID_FECHA, oUsuarioDesc.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION);

                //b1 = registro.B_FILE_DECLARACION;
                b1 = null;

                string TipoDeclaracion = db.CAT_TIPO_DECLARACION.Where(q => q.NID_TIPO_DECLARACION == registro.NID_TIPO_DECLARACION).First().V_TIPO_DECLARACION;

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

                    file.fileSoapClient oo = new file.fileSoapClient();
                    SerializedFile sf = oo.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { oUsuarioDesc.VID_NOMBRE
                                                                               ,oUsuarioDesc.VID_FECHA
                                                                               ,oUsuarioDesc.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
                    registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
                    registro.B_FILE_DECLARACION = sf.FileBytes;
                    db.SaveChanges(); //OEVM 20200902

                    b1 = registro.B_FILE_DECLARACION; //OEVM20200902
                    registro = db.DECLARACION.Find(oUsuarioDesc.VID_NOMBRE, oUsuarioDesc.VID_FECHA, oUsuarioDesc.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION);
                    //b1 = registro.B_FILE_DECLARACION;
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
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Declaracion_" + TipoDeclaracion + "_" + oUsuarioDesc.VID_NOMBRE + oUsuarioDesc.VID_FECHA + oUsuarioDesc.VID_HOMOCLAVE + ".pdf");
                HttpContext.Current.Response.WriteFile(File);
                HttpContext.Current.Response.Flush();
                System.IO.File.Delete(File);
                HttpContext.Current.Response.End();

            }

            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                popupErr.Show();
            }
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            popupErr.Hide();

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