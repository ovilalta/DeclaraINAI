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


                            Workbook book = new Workbook();
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

                            sheet.DefaultColumnWidth = 25;
                            

                            sheet2.DefaultColumnWidth = 25;

                            //Lista UAs
                            //DataTable listaUAs = new DataTable();

                            //da.SelectCommand = new SqlCommand(sql3, conn);
                            //da.SelectCommand.CommandType = CommandType.StoredProcedure;

                            //da.Fill(listaUAs);



                            //foreach (DataRow ua in listaUAs.Rows)
                            //{
                            //    DataRow[] drUA = dt.Select("SIGLAS = " + ua.ToString().Trim());

                            //}

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
    }
}
