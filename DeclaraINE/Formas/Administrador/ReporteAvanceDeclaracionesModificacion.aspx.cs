﻿using Declara_V2.BLLD;
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
                            book.CreateEmptySheets(40);
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

                                                    
                                                    //book.SaveToHttpResponse(uaTemp + ".xls", Response);

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



                            //book.SaveToFile("ReporteUAsPorPestania.xlsx");
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
                            book.CreateEmptySheets(40);
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

                            book.SaveToFile("AvanceDeclaraciones2022.xls");

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
    }
}
