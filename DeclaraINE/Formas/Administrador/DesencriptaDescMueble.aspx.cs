using Declara_V2.BLLD;
using Declara_V2.BLL;
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
using DeclaraINAI.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using AlanWebControls;



namespace DeclaraINAI.Formas.Administrador
{
    public partial class DesencriptaDescMueble : Pagina
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
            string path = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(path + "Formas\\DeclaracionFiscal\\pdfFiscales\\");
           

            

            if (!IsPostBack)
            {
                Page.Title = "Desencriptar Bien Mueble";
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
        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }





        protected void BtnDesencriptar(object sender, EventArgs e)
        {

            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            string connString = db.Database.Connection.ConnectionString;
            string sql = "SP_ListaBienesMuebles";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(sql, conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        //int totalRegistros = Convert.ToInt32( dt.Rows);
                        foreach (DataRow row in dt.Rows)
                        {
                            string vid_nombre = Convert.ToString(row["VID_NOMBRE"]);
                            string vid_fecha = Convert.ToString(row["VID_FECHA"]);
                            string vid_homoclave = Convert.ToString(row["VID_HOMOCLAVE"]);
                            int nid_declaracion = Convert.ToInt32(row["NID_DECLARACION"]);
                            int nid_mueble = Convert.ToInt32(row["NID_MUEBLE"]);
                            string e_especificacion = "";
                            try { e_especificacion = _bllSistema.DesEncriptaStatic(Convert.ToString(row["E_ESPECIFICACION"])); } catch { e_especificacion = ""; }
                            string d_especificacion = Convert.ToString(row["D_ESPECIFICACION"]);

                            if (d_especificacion != null)
                            {
                                //MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                                //string connString2 = db.Database.Connection.ConnectionString;
                                string sql2 = "SP_ActualizaDescripcionBienMueble";
                                try
                                {
                                    conn.Open();
                                    using (SqlCommand cmd = new SqlCommand(sql2, conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@VID_NOMBRE", vid_nombre);
                                        cmd.Parameters.AddWithValue("@VID_FECHA", vid_fecha);
                                        cmd.Parameters.AddWithValue("@VID_HOMOCLAVE", vid_homoclave);
                                        cmd.Parameters.AddWithValue("@NID_DECLARACION", nid_declaracion);
                                        cmd.Parameters.AddWithValue("@NID_MUEBLE", nid_mueble);
                                        cmd.Parameters.AddWithValue("@E_ESPECIFICACION", e_especificacion);

                                        cmd.ExecuteNonQuery();

                                    }
                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error: " + ex.Message);
                                }
                            }

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

