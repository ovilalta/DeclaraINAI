using Declara_V2.BLLD;
using System;
using System.IO;
using System.Threading.Tasks;
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
using DeclaraINE.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using AlanWebControls;



namespace DeclaraINE.Formas.Administrador
{
    public partial class ExcepcionEdicionConflictoI : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
        }


        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }


        protected void btnAgregarRFC(object sender, EventArgs e)
        {
            if (txtRfc.Text.Length == 13)
            {

                #region Logica agregar a tabla el RFC  que se autorizara para actualizar acuse fiscal

                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                string connString = db.Database.Connection.ConnectionString;
                string sql = "SP_BrindaPermisosEdicionConflictoI";
                int rpta = 0;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@rfc", txtRfc.Text.ToUpper());

                            rpta = cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        rpta = 0;
                        Console.WriteLine("Error: " + ex.Message);
                    }

                }

                #endregion

                if (rpta == -1)
                {
                    msgBox.ShowSuccess("Se agregó el RFC: " + txtRfc.Text.ToUpper() + " de manera correcta");
                    txtRfc.Text = "";
                }
                else
                {
                    msgBox.ShowWarning("Ya existe el RFC: " + txtRfc.Text.ToUpper() + " , favor de validar la información");
                    txtRfc.Text = "";
                }

            }
            else
            {
                msgBox.ShowDanger("El RFC no tiene 13 caracteres, por favor revise la información");
            }
        }
    }
}

