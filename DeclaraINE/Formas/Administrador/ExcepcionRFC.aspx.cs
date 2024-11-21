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
using DeclaraINAI.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using AlanWebControls;



namespace DeclaraINAI.Formas.Administrador
{
    public partial class ExcepcionRFC : Pagina
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

                try
                {
                    MODELDeclara_V2.cnxDeclara bd = new MODELDeclara_V2.cnxDeclara();
                    string context = bd.Database.Connection.ConnectionString;

                    string sql = "SP_ExcepcionRegistroRFC";

                    using (SqlConnection conn = new SqlConnection(context))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@RFC", txtRfc.Text.ToUpper());

                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();

                        //Registra la búsqueda en bitácora
                        BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                    , "Excepción para registrar usuario con RFC fuera de regla de validación", "Se dan los permisos para permitir el registro de usuario con RFC: " + txtRfc.Text);
                        msgBox.ShowSuccess("Se agregó el RFC: " + txtRfc.Text.ToUpper() + " de manera correcta");
                        txtRfc.Text = "";
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

