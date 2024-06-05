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
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace DeclaraINAI.Formas
{
    public partial class BuscaRegistroUsuario : Pagina
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
                rbRFC.Checked = true;
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

        List<Declara_V2.BLLD.DeclaracionesInformeDetalle> Declaraciones = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();

        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtRfc.Text == "" || txtRfc.Text == null)
            {
                msgBox.ShowDanger("Debe especificar un RFC.");
            }
            else
            {
                //Busqueda de declaraciones por RFC
                if (rbRFC.Checked == true)
                {
                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    string connString = db.Database.Connection.ConnectionString;

                    string sql = "Sp_Busca_RFC_PorNombre";

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        try
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = new SqlCommand(sql, conn);
                                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                                da.SelectCommand.Parameters.Add(new SqlParameter("@nombre", ""));
                                da.SelectCommand.Parameters.Add(new SqlParameter("@rfc", txtRfc.Text));
                                da.SelectCommand.Parameters.Add(new SqlParameter("@tipo", 2));


                                DataTable dt = new DataTable();
                                dt.Clear();
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        grdDP.DataSource = dt;
                                        grdDP.DataBind();
                                       
                                    }
                                }
                                else
                                {
                                    msgBox.ShowDanger("No se encontró registrado el nombre: " + "'" + txtRfc.Text.ToUpper() + "'" + " en DeclaraINAI ");
                                }

                            }

                            //Registra la búsqueda en bitácora
                            BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                                , "Busca registro de usuario por RFC", "Se realiza la búsqueda del usuario con RFC: " + txtRfc.Text);
                        }
                        catch (Exception ex)
                        {
                          
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
                //Busqueda de declaraciones por nombre
                if (rbNombre.Checked == true)
                {
                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    string connString = db.Database.Connection.ConnectionString;

                    string sql = "Sp_Busca_RFC_PorNombre";

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        try
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = new SqlCommand(sql, conn);
                                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                                da.SelectCommand.Parameters.Add(new SqlParameter("@nombre", txtRfc.Text));
                                da.SelectCommand.Parameters.Add(new SqlParameter("@rfc", ""));
                                da.SelectCommand.Parameters.Add(new SqlParameter("@tipo", 1));


                                DataTable dt = new DataTable();
                                dt.Clear();
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                       
                                        grdDP.DataSource = dt;
                                        grdDP.DataBind();
                                   
                                    }
                                }
                                else
                                {
                                    msgBox.ShowDanger("No se encontró registrado el nombre: " + "'" + txtRfc.Text.ToUpper() + "'" + " en DeclaraINAI ");
                                }

                            }

                            //Registra la búsqueda en bitácora
                            BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                                , "Busca registro de usuario por nombre", "Se realiza la búsqueda del usuario con nombre: " + txtRfc.Text);
                        }
                        catch (Exception ex)
                        {
                            //msgBox.ShowDanger("Error: " + ex.Message);
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }

          
        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("..\\Index.aspx");
        }

        

        
        
        

        
    }
}