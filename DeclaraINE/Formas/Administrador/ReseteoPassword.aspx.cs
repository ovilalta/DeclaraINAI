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
    public partial class ReseteoPassword : Pagina
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


        protected void btnReseteoPass(object sender, EventArgs e)
        {
            if (txtRfc.Text.Length == 13)
            {

                try
                {
                    blld_USUARIO oUsuario = new blld_USUARIO(txtRfc.Text.ToUpper());

                    if (oUsuario != null)
                    {
                        MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                        string connString = db.Database.Connection.ConnectionString;

                        string sql = "SP_ReseteoPassword";

                        using (SqlConnection conn = new SqlConnection(connString))
                        {

                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = new SqlCommand(sql, conn);
                                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                                da.SelectCommand.Parameters.Add(new SqlParameter("@RFC", txtRfc.Text.ToUpper()));

                                msgBox.ShowSuccess("Se reseteo la contraseña del RFC: " + "'" + txtRfc.Text.ToUpper() + "'" + " en DeclaraINAI, quedando: Mexico1234");
                                
                            }

                        }
                    }
                    else
                    {
                        msgBox.ShowDanger("No está registrado el usuario con RFC: " + txtRfc.Text.ToUpper());
                    }
                }
                catch (Exception ex)
                {

                    msgBox.ShowDanger("No está registrado el usuario con RFC: " + txtRfc.Text.ToUpper());
                }

            }
            else
            {
                msgBox.ShowDanger("El RFC no tiene 13 caracteres, por favor revise la información");
            }

        }

    }
}

