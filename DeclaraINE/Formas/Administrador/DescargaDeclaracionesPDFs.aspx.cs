using Declara_V2.BLLD;
using System;
using System.IO;
using System.IO.Compression ;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Spire.Xls;
using System.Windows.Forms;
using System.Linq;
using DeclaraINE.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using Ionic.Zip;
using ZipFile = Ionic.Zip.ZipFile;
using iText;

namespace DeclaraINE.Formas.Administrador
{
    public partial class DescargaDeclaracionesPDFs : Pagina
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
                Page.Title = "DescargaDeclaracionesPDFs";
                string line;
                bool excep = false;
                var buildDir = HttpRuntime.AppDomainAppPath;
                var filePath = buildDir + @"\Formas\Administrador\Administradores.txt";
                //var filePath = buildDir + @"\Formas\Administrador\AdministradoresReporte.txt";
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
        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
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
        protected void btnDescargar_Actualizar(object sender, EventArgs e)
        {
            if (txtFInicio.Text == "" || txtFInicio.Text == null)
            {
                msgBox.ShowDanger("Debe especificar una fecha de inicio.");
            }
            else if (txtFFin.Text == "" || txtFFin.Text == null)
            {
                msgBox.ShowDanger("Debe especificar una fecha de fin.");
            }
            else if (Convert.ToDateTime(txtFInicio.Text) > Convert.ToDateTime(txtFFin.Text))
            {
                msgBox.ShowDanger("La fecha de inicio no puede ser mayor a la fecha de fin.");
            }
            else
            {
                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                string connString = db.Database.Connection.ConnectionString;
                string sql = "SP_DescargaPDFs";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(sql, conn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;

                            da.SelectCommand.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar)).Value = Convert.ToDateTime(txtFInicio.Text);
                            da.SelectCommand.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar)).Value = Convert.ToDateTime(txtFFin.Text);

                            DataTable dt = new DataTable();
                            dt.Clear();
                            da.Fill(dt);
                            //using(ZipFile zip = new ZipFile() ) 

                            int tipoDeclaracion = 0;
                            string vid_nombre = "";
                            string vid_fecha = "";
                            string vid_homo = "";
                            String File = "";
                            

                            using (ZipFile zip = new ZipFile())
                            {
                                //Mandar llamar la logica de armado de pdfs
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {

                                    MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();


                                    byte[] b1 = null;
                                    tipoDeclaracion = Convert.ToInt32(dt.Rows[i]["NID_TIPO_DECLARACION"].ToString());
                                    bool obligado = Convert.ToBoolean(dt.Rows[i]["L_OBLIGADO"].ToString());
                                    string VersionDeclaracion = "";
                                    vid_nombre = dt.Rows[i]["VID_NOMBRE"].ToString();
                                    vid_fecha = dt.Rows[i]["VID_FECHA"].ToString();
                                    vid_homo = dt.Rows[i]["VID_HOMOCLAVE"].ToString();
                                    int idDeclaracion = Convert.ToInt32(dt.Rows[i]["NID_DECLARACION"].ToString());


                                    switch (tipoDeclaracion)
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
                                    SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { vid_nombre
                                                                                   ,vid_fecha
                                                                                   ,vid_homo
                                                                                   ,idDeclaracion
                                                                                   ,"Preliminarx"}.ToArray());
                                    registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
                                    registro.B_FILE_DECLARACION = sf.FileBytes;
                                    db.SaveChanges();
                                    registro = db.DECLARACION.Find(vid_nombre, vid_fecha, vid_homo, idDeclaracion);
                                    b1 = registro.B_FILE_DECLARACION;

                                    FileStream fs1;
                                    
                                    File = AppDomain.CurrentDomain.BaseDirectory + "Formas\\PdfDeclaracionesTemp\\";
                                   
                                    //File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
                                    fs1 = new FileStream(File, FileMode.Create);
                                    fs1.Write(b1, 0, b1.Length);
                                    //zip.AddEntry("Declaracion" + tipoDeclaracion + vid_nombre + vid_fecha + vid_homo, fs1); //OEVM
                                    fs1.Close();
                                    fs1 = null;

                                    //zip.Save(rutaZip);
                                    
                                    //zip.Save(File);


                                }


                                HttpContext.Current.Response.ClearContent();
                                HttpContext.Current.Response.Clear();
                                HttpContext.Current.Response.ContentType = "application/zip"; // sf.MimeType;
                                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Declaraciones.zip");
                                HttpContext.Current.Response.WriteFile(File);
                                HttpContext.Current.Response.Flush();
                                System.IO.File.Delete(File);
                                HttpContext.Current.Response.End();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }  
            }
        }

       
     }
 }

