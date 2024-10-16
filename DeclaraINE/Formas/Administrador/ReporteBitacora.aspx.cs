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
using System.Globalization;

namespace DeclaraINAI.Formas.Administrador
{
    public partial class ReporteBitacora : Pagina
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
                Page.Title = "Reporte Bitácora";
                string line;
                bool excep = false;
                var buildDir = HttpRuntime.AppDomainAppPath;
                var filePath = buildDir + @"\Formas\Administrador\AdministradoresBitacora.txt";
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

        static string CapitalizeWords(string input)
        {
            TextInfo textInfo = new CultureInfo("es-MX", false).TextInfo;
            return textInfo.ToTitleCase(input);
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
                string sql = "SP_ReporteBitacora";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(sql, conn);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.Add(new SqlParameter("@fechaIni", SqlDbType.VarChar)).Value = txtFInicio.Text;
                            da.SelectCommand.Parameters.Add(new SqlParameter("@fechaFin", SqlDbType.VarChar)).Value = txtFFin.Text;
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            //Registra la búsqueda en bitácora
                            BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                                , "Genera reporte para carga SIPOT", "Se genera el reporte para la carga de SIPOT del periodo del " + txtFInicio.Text + " al " + txtFFin.Text);

                            Workbook book = new Workbook();
                            Worksheet sheet = book.Worksheets[0];
                            sheet.InsertDataTable(dt, true, 1, 1);
                            //string nameFile = "ReporteBitacora-" + DateTime.Now.ToString() + ".xls";
                            book.SaveToHttpResponse("ReporteBitacora-" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls", Response);
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
