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
using System.Threading.Tasks;
using System.Web.Mvc;



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


        //public static void CreateEmptyDirectory(string fullPath)
        //{
        //    if (!System.IO.Directory.Exists(fullPath))
        //    {
        //        System.IO.Directory.CreateDirectory(fullPath);
        //    }
        //}
        //public static void DeleteFolder(string fullPath)
        //{
        //    if (System.IO.Directory.Exists(fullPath))
        //    {
        //        System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(fullPath)
        //        {
        //            Attributes = System.IO.FileAttributes.Normal
        //        };
        //        foreach (var info in directory.GetFileSystemInfos("*", System.IO.SearchOption.AllDirectories))
        //        {
        //            System.IO.FileInfo fInfo = info as System.IO.FileInfo;
        //            if (fInfo != null) info.Attributes = System.IO.FileAttributes.Normal;
        //        }
        //        System.Threading.Thread.Sleep(100);
        //        directory.Delete(true);
        //    }
        //}

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

                            //Registra la búsqueda en bitácora
                            BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                                , "Descarga Versiones Públicas", "Se descargan versiones públicas del " + txtFInicio.Text + " al " + txtFFin.Text);

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

        protected void btnDescargar_ActualizarHilos(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFInicio.Text))
            {
                msgBox.ShowDanger("Debe especificar una fecha de inicio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFFin.Text))
            {
                msgBox.ShowDanger("Debe especificar una fecha de fin.");
                return;
            }

            if (Convert.ToDateTime(txtFInicio.Text) > Convert.ToDateTime(txtFFin.Text))
            {
                msgBox.ShowDanger("La fecha de inicio no puede ser mayor a la fecha de fin.");
                return;
            }

            var db = new MODELDeclara_V2.cnxDeclara();
            var connString = db.Database.Connection.ConnectionString;
            var sql = "SP_DescargaPDFs";

            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    using (var da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(sql, conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar)).Value = Convert.ToDateTime(txtFInicio.Text);
                        da.SelectCommand.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar)).Value = Convert.ToDateTime(txtFFin.Text);

                        var dt = new DataTable();
                        da.Fill(dt);
                        var numeroFilas = dt.Rows.Count;
                        System.Diagnostics.Debug.WriteLine($"Número de filas en DataTable: {numeroFilas}");

                        if (numeroFilas == 0)
                        {
                            msgBox.ShowDanger("No se encontraron registros en el rango de fechas especificado.");
                            return;
                        }

                        var rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "Formas\\PdfDeclaracionesTemp";
                        DeleteFolder(rutaDirectorio);
                        CreateEmptyDirectory(rutaDirectorio);

                        var options = new ParallelOptions
                        {
                            MaxDegreeOfParallelism = 4 // Ajusta este valor según la capacidad del servidor y el servicio web
                        };

                        Parallel.ForEach(dt.AsEnumerable(), options, row =>
                        {
                            try
                            {
                                var tipoDeclaracion = Convert.ToInt32(row["NID_TIPO_DECLARACION"]);
                                var tipoDeclaracionN = GetTipoDeclaracionNombre(tipoDeclaracion);

                                var obligado = Convert.ToBoolean(row["L_OBLIGADO"]);
                                var vid_nombre = row["VID_NOMBRE"].ToString();
                                var vid_fecha = row["VID_FECHA"].ToString();
                                var vid_homo = row["VID_HOMOCLAVE"].ToString();
                                var nombreCompleto = row["NOMBRE"].ToString();
                                var idDeclaracion = Convert.ToInt32(row["NID_DECLARACION"]);
                                var nombreFile = $"{nombreCompleto}_{tipoDeclaracionN}_{idDeclaracion}.pdf";

                                System.Diagnostics.Debug.WriteLine($"Generando PDF para: {nombreFile}");

                                ActualizaNombreArchivoDeclaracion(vid_nombre, vid_fecha, vid_homo, idDeclaracion, nombreFile);

                                var VersionDeclaracion = GetVersionDeclaracion(tipoDeclaracion, obligado);

                                var o = new file.fileSoapClient();
                                var sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new object[] { vid_nombre, vid_fecha, vid_homo, idDeclaracion, "Preliminarx" });

                                var b1 = sf.FileBytes;
                                var filePath = Path.Combine(rutaDirectorio, nombreFile);

                                File.WriteAllBytes(filePath, b1);

                                System.Diagnostics.Debug.WriteLine($"PDF generado y guardado: {filePath}");
                            }
                            catch (Exception ex)
                            {
                                // Manejar excepción específica para este registro
                                System.Diagnostics.Debug.WriteLine($"Error generando PDF para el registro {row["NID_DECLARACION"]}: {ex.Message}");
                            }
                        });

                        var filesGenerated = Directory.GetFiles(rutaDirectorio);
                        System.Diagnostics.Debug.WriteLine($"Número de archivos generados: {filesGenerated.Length}");

                        var startPath = rutaDirectorio;
                        var zipPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Formas\\zip", "DeclaracionesPatrimoniales.zip");
                        ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Optimal, true);

                        DeleteFolder(rutaDirectorio);
                        CreateEmptyDirectory(rutaDirectorio);

                        BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE,
                            "Descarga Versiones Públicas", $"Se descargan versiones públicas del {txtFInicio.Text} al {txtFFin.Text}");

                        HttpContext.Current.Response.ClearContent();
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.ContentType = "application/zip";
                        HttpContext.Current.Response.AddHeader("Content-Disposition", $"attachment; filename=DeclaracionesPatrimoniales_{DateTime.Now}.zip");
                        HttpContext.Current.Response.WriteFile(zipPath);
                        HttpContext.Current.Response.Flush();
                        File.Delete(zipPath);
                        HttpContext.Current.Response.End();
                    }
                }
                catch (Exception ex)
                {
                    msgBox.ShowDanger("Error: " + ex.Message);
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private string GetTipoDeclaracionNombre(int tipoDeclaracion)
        {
            switch (tipoDeclaracion)
            {
                case 1: return "Inicial";
                case 2: return "Modificacion";
                case 3: return "Conclusion";
                default: return "";
            }
        }

        private string GetVersionDeclaracion(int tipoDeclaracion, bool obligado)
        {
            switch (tipoDeclaracion)
            {
                case 1:
                    return obligado ? "DECLARACION_INICIAL_PUB" : "DECLARACION_INICIAL_SIMPLI_PUB";
                case 2:
                    return obligado ? "DECLARACION_MODIFICACION_PUB" : "DECLARACION_MODIFICACION_SIMPLI_PUB";
                case 3:
                    return obligado ? "DECLARACION_CONCLUSION_PUB" : "DECLARACION_CONCLUSION_SIMPLI_PUB";
                default:
                    return "";
            }
        }

        private void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        private void CreateEmptyDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }



    }
}














