using Declara_V2.BLLD;
using System;
using System.IO;
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
using System.Linq;

using System.Collections.Generic;
using System.IO.Compression;

namespace DeclaraINE.Formas.Administrador
{
    public partial class ReporteAvanceDeclaracionesModificacion : Pagina
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
                Page.Title = "Reporte Avance Declaraciones por Unidad Administrativa";
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
        protected void btnDescargar_Actualizar(object sender, EventArgs e)
        {

            if (txtAnio.Text == "" || txtAnio.Text == null)
            {
                msgBox.ShowDanger("Debe especificar un ejercicio.");
            }

            else
            {
                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                string connString = db.Database.Connection.ConnectionString;

                string sql = "SP_ReporteDeclaracionesPlantillaModificacion";
                string sql2 = "SP_ReporteDeclaracionesPlantillaModificacionResumen";
                string sql3 = "SP_ReporteListaUAs";
                string sql4 = "SP_ReporteDeclaracionesPlantillaModificacionArea";



                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {

                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {


                            //Reporte detalle
                            da.SelectCommand = new SqlCommand(sql, conn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.Add(new SqlParameter("@anio", SqlDbType.VarChar)).Value = txtAnio.Text;

                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            //Reporte resumen

                            da.SelectCommand = new SqlCommand(sql2, conn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.Add(new SqlParameter("@anio", SqlDbType.VarChar)).Value = txtAnio.Text;

                            DataTable dt2 = new DataTable();
                            da.Fill(dt2);

                            //Guarda la info en el excel

                            Workbook book = new Workbook();
                            book.CreateEmptySheets(42);
                            Worksheet sheet = book.Worksheets[0];
                            Worksheet sheet2 = book.Worksheets[1];

                            //ExcelFont fontBold = book.CreateFont();
                            //fontBold.IsBold = true;
                            //RichText richText = sheet.Range["A1"].RichText;
                            //richText.SetFont(0, richText.Text.Length - 1, fontBold);



                            //Renombrar hojas
                            sheet.Name = "Detalle";
                            sheet2.Name = "Resumen";
                            //Inserta datos en las hojas
                            sheet.InsertDataTable(dt, true, 1, 1);
                            sheet2.InsertDataTable(dt2, true, 1, 1);

                            sheet.AutoFilters.Range = sheet.Range["A1:J1"];
                            sheet.Range["A1:J1"].Style.Font.IsBold = true;
                            sheet.DefaultColumnWidth = 25;
                            sheet2.AutoFilters.Range = sheet2.Range["A1:C1"];
                            sheet2.Range["A1:C1"].Style.Font.IsBold = true;
                            sheet2.DefaultColumnWidth = 25;

                            //Lista UAs
                            //Reporte que genera xls por area
                            try
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(sql3, conn))
                                {

                                    cmd.CommandType = CommandType.StoredProcedure;

                                    SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.Default);

                                    if (drd != null)
                                    {
                                        int i = 2;


                                        while (drd.Read())
                                        {

                                            string uaTemp = drd.GetString(0).Trim();


                                            using (SqlDataAdapter da2 = new SqlDataAdapter())
                                            {

                                                //Reporte detalle
                                                da2.SelectCommand = new SqlCommand(sql4, conn);
                                                da2.SelectCommand.CommandType = CommandType.StoredProcedure;
                                                da2.SelectCommand.Parameters.Add(new SqlParameter("@anio", SqlDbType.VarChar)).Value = txtAnio.Text;
                                                da2.SelectCommand.Parameters.Add(new SqlParameter("@ua", SqlDbType.VarChar)).Value = uaTemp;

                                                DataTable dt3 = new DataTable();
                                                da2.Fill(dt3);

                                                sheet = book.Worksheets[i];

                                                sheet.Name = uaTemp;
                                                sheet.InsertDataTable(dt3, true, 1, 1);
                                                sheet.DefaultColumnWidth = 25;

                                            }


                                            i++;
                                        }
                                        conn.Close();

                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }

                            book.SaveToHttpResponse("ReporteDeclaracionesPlantillaModificacion.xls", Response);

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }


            }
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
        protected void btnDescargar_ActualizarZIP(object sender, EventArgs e)
        {
            if (txtAnio.Text == "" || txtAnio.Text == null)
            {
                msgBox.ShowDanger("Debe especificar un ejercicio.");
            }
            else
            {
                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                string connString = db.Database.Connection.ConnectionString;

                string sql = "SP_ReporteDeclaracionesPlantillaModificacion";
                string sql2 = "SP_ReporteDeclaracionesPlantillaModificacionResumen";
                string sql3 = "SP_ReporteListaUAs";
                string sql4 = "SP_ReporteDeclaracionesPlantillaModificacionArea";
                string sql5 = "SP_ReporteDeclaracionesPlantillaModificacionAreaResponsable";


                string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "Formas\\zip"; //Asigna ruta donde se guardaran los archivos pdf
                DeleteFolder(rutaDirectorio);  //Limpia el folder para asegurar que no tenga archivos
                CreateEmptyDirectory(rutaDirectorio); //Crea el folder de nueva cuenta para ser utilizado

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {

                            //Reporte detalle
                            da.SelectCommand = new SqlCommand(sql, conn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.Add(new SqlParameter("@anio", SqlDbType.VarChar)).Value = txtAnio.Text;

                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            //Reporte resumen

                            da.SelectCommand = new SqlCommand(sql2, conn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.Add(new SqlParameter("@anio", SqlDbType.VarChar)).Value = txtAnio.Text;

                            DataTable dt2 = new DataTable();
                            da.Fill(dt2);

                            //Guarda la info en el excel

                            Workbook book = new Workbook();
                            //book.CreateEmptySheets(40);
                            Worksheet sheet = book.Worksheets[0];
                            Worksheet sheet2 = book.Worksheets[1];

                            //ExcelFont fontBold = book.CreateFont();
                            //fontBold.IsBold = true;
                            //RichText richText = sheet.Range["A1"].RichText;
                            //richText.SetFont(0, richText.Text.Length - 1, fontBold);
                            //Renombrar hojas
                            sheet.Name = "Detalle";
                            sheet2.Name = "Resumen";
                            //Inserta datos en las hojas
                            sheet.InsertDataTable(dt, true, 1, 1);
                            sheet.Range["A1:J1"].Style.Font.IsBold = true;
                            sheet.AutoFilters.Range = sheet.Range["A1:J1"];
                            sheet2.InsertDataTable(dt2, true, 1, 1);

                            sheet.DefaultColumnWidth = 25;
                            sheet2.DefaultColumnWidth = 25;

                            book.SaveToFile(rutaDirectorio + @"\AvanceDeclaraciones2022.xls", ExcelVersion.Version97to2003);

                            //Lista UAs
                            //Reporte que genera xls por area
                            try
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(sql3, conn))
                                {

                                    cmd.CommandType = CommandType.StoredProcedure;

                                    SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.Default);

                                    if (drd != null)
                                    {


                                        while (drd.Read())
                                        {
                                            Workbook book2 = new Workbook();
                                            string uaTemp = drd.GetString(0).Trim();

                                            bool flag = false;
                                            using (SqlDataAdapter da2 = new SqlDataAdapter())
                                            {

                                                //Reporte detalle
                                                da2.SelectCommand = new SqlCommand(sql4, conn);
                                                da2.SelectCommand.CommandType = CommandType.StoredProcedure;
                                                da2.SelectCommand.Parameters.Add(new SqlParameter("@anio", SqlDbType.VarChar)).Value = txtAnio.Text;
                                                da2.SelectCommand.Parameters.Add(new SqlParameter("@ua", SqlDbType.VarChar)).Value = uaTemp;

                                                DataTable dt3 = new DataTable();

                                                da2.Fill(dt3);


                                                //Revisar si el dt no esta vacio
                                                if (dt3.Rows.Count > 0)
                                                {
                                                    flag = true;
                                                    SqlCommand cmd2 = new SqlCommand(sql5, conn);
                                                    cmd2.CommandType = CommandType.StoredProcedure;
                                                    cmd2.Parameters.AddWithValue("@anio", txtAnio.Text);
                                                    cmd2.Parameters.AddWithValue("@ua", uaTemp);

                                                    string nombreResponsable = "";

                                                    nombreResponsable = Convert.ToString(cmd2.ExecuteScalar());
                                                    DataRow row = dt3.Rows[0];

                                                    string UaNombre = row["UnidadAdministrativa"].ToString().Trim();


                                                    sheet = book2.Worksheets[0];

                                                    sheet.Name = uaTemp;
                                                    sheet.Range[1, 1].Value = "Nombre del área";
                                                    sheet.Range[2, 1].Value = "Nombre del responsable";
                                                    sheet.Range[1, 2].Value = UaNombre;
                                                    sheet.Range[2, 2].Value = nombreResponsable.Trim();

                                                    sheet.Range["A1"].Style.Font.IsBold = true;
                                                    sheet.Range["A2"].Style.Font.IsBold = true;
                                                    sheet.Range["A5:E5"].Style.Font.IsBold = true;

                                                    sheet.InsertDataTable(dt3, true, 5, 1);

                                                    sheet.Range[5, 1].Value = "Nombre del personal";
                                                    sheet.Range[5, 2].Value = "Estatus Declaración";
                                                    sheet.Range[5, 3].Value = "Puesto";
                                                    sheet.Range[5, 4].Value = "Denominación del cargo";
                                                    sheet.Range[5, 5].Value = "Unidad Administrativa";
                                                    sheet.HideColumn(5);
                                                    sheet.AutoFilters.Range = sheet.Range["A5:E5"];
                                                    sheet.DefaultColumnWidth = 25;

                                                    dt3.Clear();
                                                }


                                            }
                                            //i++;

                                            if (flag == true)
                                            {

                                                book2.SaveToFile(rutaDirectorio + "\\" + uaTemp + @".xls", ExcelVersion.Version97to2003);
                                            }

                                        }
                                        conn.Close();

                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }

                            string startPath = rutaDirectorio; //folder to add
                            string zipPath = AppDomain.CurrentDomain.BaseDirectory + "Formas\\zipAvanceDeclaraciones" + "\\AvancePorArea.zip"; //URL for your Zip file

                            ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Optimal, true);

                            DeleteFolder(rutaDirectorio);  //Limpia el folder para asegurar que no tenga archivos
                            CreateEmptyDirectory(rutaDirectorio); //Crea el folder de nueva cuenta para ser utilizado

                            HttpContext.Current.Response.ClearContent();
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.ContentType = "application/zip"; // sf.MimeType;
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=AvancePorArea.zip");
                            HttpContext.Current.Response.WriteFile(zipPath);
                            HttpContext.Current.Response.Flush();
                            System.IO.File.Delete(zipPath);
                            HttpContext.Current.Response.End();




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