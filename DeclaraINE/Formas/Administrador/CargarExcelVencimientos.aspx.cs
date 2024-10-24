using Declara_V2.BLLD;
using System;
using OfficeOpenXml;
using System.IO;
using System.Data.SqlClient;
using Spire.Xls;
using System.Globalization;
using Microsoft.Ajax.Utilities;
using System.Web.Configuration;



namespace DeclaraINAI.Formas.Administrador
{
    public partial class CargarExcelVencimientos : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            txtSheet1StartRow.Text = "9";
            txtSheet2StartRow.Text = "9";
            txtSheet3StartRow.Text = "10";
        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (ExcelFile.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(ExcelFile.FileName);

                // Verifica si el archivo es un Excel (.xls o .xlsx)
                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    try
                    {
                        // Convertir las filas de inicio ingresadas por el usuario a enteros
                        int sheet1StartRow = int.Parse(txtSheet1StartRow.Text);
                        int sheet2StartRow = int.Parse(txtSheet2StartRow.Text);
                        int sheet3StartRow = int.Parse(txtSheet3StartRow.Text);

                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        // Cargar el archivo en memoria
                        using (var package = new ExcelPackage(ExcelFile.PostedFile.InputStream))
                        {
                            // Procesar la hoja 1 desde la fila especificada
                            ExcelWorksheet sheet1 = package.Workbook.Worksheets[0];
                            ProcesarHoja(sheet1, sheet1StartRow, "Estructura");

                            // Procesar la hoja 2 desde la fila especificada
                            ExcelWorksheet sheet2 = package.Workbook.Worksheets[1];
                            ProcesarHoja(sheet2, sheet2StartRow, "Eventuales");

                            // Procesar la hoja 3 desde la fila especificada
                            ExcelWorksheet sheet3 = package.Workbook.Worksheets[2];
                            ProcesarHoja(sheet3, sheet3StartRow, "Honorarios");

                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "El archivo se procesó exitosamente.";
                            //Registra la búsqueda en bitácora
                            BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                                , "Carga Excel Vencimiento Declaraciones", "Se cargó el excel de movimientos quincenales para calcular las fechas de vencimiento de presentación de declaraciones" );
                            Response.Redirect("VisualizarVencimientosDeclaraciones.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Error al procesar el archivo: " + ex.Message;
                    }
                }
                else
                {
                    // Mostrar mensaje de error si el archivo no es Excel
                    lblMessage.Text = "Por favor, cargue un archivo de Excel válido.";
                }
            }
            else
            {
                lblMessage.Text = "Por favor, seleccione un archivo para cargar.";
            }
        }

        // Función que procesa una hoja de Excel desde la fila indicada
        private void ProcesarHoja(ExcelWorksheet worksheet, int startRow, string sheetName)
        {

            switch (sheetName)
            {
                case "Estructura":
                    Guardar(worksheet, startRow, 3, 4, 5, 6);
                    break;
                case "Eventuales":
                    Guardar(worksheet, startRow, 2, 3, 4, 5);
                    break;
                case "Honorarios":
                    Guardar(worksheet, startRow, 1, 5, 9, 7);
                    break;
                default:
                    break;
            }

        }

        private void Guardar(ExcelWorksheet worksheet, int startRow, int col1, int col2, int col3, int col4)
        {
            // Lee las filas de la hoja desde la fila indicada por el usuario
            for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
            {
                string column1 = worksheet.Cells[row, col1].Text; // Columna A
                string column2 = worksheet.Cells[row, col2].Text; // Columna B
                string column3 = worksheet.Cells[row, col3].Text; // Columna B
                string column4 = "";
                if (col4 == 7)
                {
                    if (column3 == "Alta")
                    {
                        column4 = worksheet.Cells[row, col4].Text; // Columna B
                    }
                    else if (column3 == "Baja")
                    {
                        column4 = worksheet.Cells[row, 8].Text;
                    }
                }
                else
                {
                    column4 = worksheet.Cells[row, col4].Text; // Columna B
                }

                // Aquí puedes procesar y guardar la información que necesitas
                // GuardarEnBaseDeDatos(columnA, columnB, sheetName);
                GuardarEnBaseDeDatos(column1, column2, column3, column4);
            }
        }

        private DateTime ConvertirFecha(string fecha)
        {
            DateTime fechaConvert = DateTime.Today;
            string dia = "";
            string mesLetra = "";
            string mes = "";
            string anio = "";
            if (fecha.Length == 12)
            {
                dia = fecha.Substring(0, 2);
                mesLetra = fecha.Substring(3, 3);
                anio = fecha.Substring(8, 4);
            }
            else if (fecha.Length == 11)
            {
                dia = "0" + fecha.Substring(0, 1);
                mesLetra = fecha.Substring(2, 3);
                anio = fecha.Substring(7, 4);
            }
            else if (fecha.Length == 10)
            {
                dia = fecha.Substring(0, 2);
                mesLetra = fecha.Substring(3, 3);
                anio = "20" + fecha.Substring(8, 2);
            }
            else if (fecha.Length == 9)
            {
                dia = fecha.Substring(0, 1);
                mesLetra = fecha.Substring(2, 3);
                anio = "20" + fecha.Substring(7, 2);
            }

            switch (mesLetra)
            {
                case "ene":
                    mes = "01";
                    break;
                case "feb":
                    mes = "02";
                    break;
                case "mar":
                    mes = "03";
                    break;
                case "abr":
                    mes = "04";
                    break;
                case "may":
                    mes = "05";
                    break;
                case "jun":
                    mes = "06";
                    break;
                case "jul":
                    mes = "07";
                    break;
                case "ago":
                    mes = "08";
                    break;
                case "sep":
                    mes = "09";
                    break;
                case "oct":
                    mes = "10";
                    break;
                case "nov":
                    mes = "11";
                    break;
                case "dic":
                    mes = "12";
                    break;
                default:
                    break;
            }
            string fechaConcatenada = $"{dia}-{mes}-{anio}";
            fechaConvert = DateTime.ParseExact(fechaConcatenada, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            return fechaConvert;
        }

        private void GuardarEnBaseDeDatos(string colA, string colB, string colC, string colD)
        {
            // Definir el formato en el que viene la fecha

            DateTime fecha;
            DateTime FechaVencimiento = DateTime.Today;

            fecha = ConvertirFecha(colD);

            FechaVencimiento = fecha.AddDays(60);

            // Ejemplo de inserción en SQL Server (con ADO.NET)
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            string connString = db.Database.Connection.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO ReporteVencimientoDeclaraciones (Rfc, NombreCompleto,TipoMovimiento,FechaAplicacion, FechaVencimiento) VALUES (@ColA, @ColB, @ColC, @fecha, @FechaVencimiento)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ColA", colA);
                    cmd.Parameters.AddWithValue("@ColB", colB);
                    cmd.Parameters.AddWithValue("@ColC", colC);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

