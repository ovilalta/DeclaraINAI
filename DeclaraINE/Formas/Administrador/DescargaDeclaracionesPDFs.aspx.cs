using Declara_V2.BLLD;
using System;
using System.IO;
using System.IO.Compression;
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
using DeclaraINAI.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using AlanWebControls;



namespace DeclaraINAI.Formas.Administrador
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


        public static void CreateEmptyDirectory(string fullPath)
        {
            if (!System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.CreateDirectory(fullPath);
            }
        }
        public static void DeleteFolder(string fullPath)
        {
            if (System.IO.Directory.Exists(fullPath))
            {
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(fullPath)
                {
                    Attributes = System.IO.FileAttributes.Normal
                };
                foreach (var info in directory.GetFileSystemInfos("*", System.IO.SearchOption.AllDirectories))
                {
                    System.IO.FileInfo fInfo = info as System.IO.FileInfo;
                    if (fInfo != null) info.Attributes = System.IO.FileAttributes.Normal;
                }
                System.Threading.Thread.Sleep(100);
                directory.Delete(true);
            }
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
                            int numeroFilas = dt.Rows.Count;

                            int tipoDeclaracion = 0;
                            string tipoDeclaracionN = "";
                            string vid_nombre = "";
                            string vid_fecha = "";
                            string vid_homo = "";
                            string nombreCompleto = "";

                            String File = "";

                            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "Formas\\PdfDeclaracionesTemp"; //Asigna ruta donde se guardaran los archivos pdf
                            DeleteFolder(rutaDirectorio);  //Limpia el folder para asegurar que no tenga archivos
                            CreateEmptyDirectory(rutaDirectorio); //Crea el folder de nueva cuenta para ser utilizado
                                                                  //Mandar llamar la logica de armado de pdfs
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();

                                byte[] b1 = null;
                                tipoDeclaracion = Convert.ToInt32(dt.Rows[i]["NID_TIPO_DECLARACION"].ToString());
                                switch (tipoDeclaracion)
                                {
                                    case 1:
                                        tipoDeclaracionN = "Inicial";
                                        break;
                                    case 2:
                                        tipoDeclaracionN = "Modificacion";
                                        break;
                                    case 3:
                                        tipoDeclaracionN = "Conclusion";
                                        break;
                                    default:
                                        break;
                                }
                                bool obligado = Convert.ToBoolean(dt.Rows[i]["L_OBLIGADO"].ToString());
                                string VersionDeclaracion = "";
                                vid_nombre = dt.Rows[i]["VID_NOMBRE"].ToString();
                                vid_fecha = dt.Rows[i]["VID_FECHA"].ToString();
                                vid_homo = dt.Rows[i]["VID_HOMOCLAVE"].ToString();
                                nombreCompleto = dt.Rows[i]["NOMBRE"].ToString();
                                //string nombreFile = vid_nombre + vid_fecha + vid_homo + ".pdf";

                                int idDeclaracion = Convert.ToInt32(dt.Rows[i]["NID_DECLARACION"].ToString());
                                string nombreFile = nombreCompleto + "_" + tipoDeclaracionN + "_" + idDeclaracion + ".pdf";

                                ActualizaNombreArchivoDeclaracion(vid_nombre, vid_fecha, vid_homo, idDeclaracion, nombreFile);

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

                                b1 = sf.FileBytes;

                                FileStream fs1;

                                File = AppDomain.CurrentDomain.BaseDirectory + "Formas\\PdfDeclaracionesTemp\\" + nombreFile;

                                fs1 = new FileStream(File, FileMode.Create);
                                fs1.Write(b1, 0, b1.Length);

                                fs1.Close();
                                fs1 = null;

                            }

                            string startPath = rutaDirectorio; //folder to add
                            string zipPath = AppDomain.CurrentDomain.BaseDirectory + "Formas\\zip" + "\\DeclaracionesPatrimoniales.zip"; //URL for your Zip file

                            ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Optimal, true);

                            DeleteFolder(rutaDirectorio);  //Limpia el folder para asegurar que no tenga archivos
                            CreateEmptyDirectory(rutaDirectorio); //Crea el folder de nueva cuenta para ser utilizado

                            HttpContext.Current.Response.ClearContent();
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.ContentType = "application/zip"; // sf.MimeType;
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=DeclaracionesPatrimoniales_" + DateTime.Now + ".zip");
                            HttpContext.Current.Response.WriteFile(zipPath);
                            HttpContext.Current.Response.Flush();
                            System.IO.File.Delete(zipPath);
                            HttpContext.Current.Response.End();


                        }

                    }
                    catch (Exception ex)
                    {
                        msgBox.ShowDanger("Error: " + ex.Message);
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }


        protected void ActualizaNombreArchivoDeclaracion(string VID_NOMBRE, string VID_FECHA, string VID_HOMO, int NID_DECLARACION, string NOMBRE_ARCHIVO)
        {

            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();

            string connString = db.Database.Connection.ConnectionString;
            string sql = "SP_AgregaNombreArchivoDeclaracion";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.CommandTimeout = 20;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VID_NOMBRE", VID_NOMBRE);
            cmd.Parameters.AddWithValue("@VID_FECHA", VID_FECHA);
            cmd.Parameters.AddWithValue("@VID_HOMO", VID_HOMO);
            cmd.Parameters.AddWithValue("@NID_DECLARACION", NID_DECLARACION);
            cmd.Parameters.AddWithValue("@nombreArchivo", NOMBRE_ARCHIVO);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();//Libera recursos utilizados
        }

    }
}

