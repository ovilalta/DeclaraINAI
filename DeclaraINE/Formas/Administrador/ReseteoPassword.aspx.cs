﻿using Declara_V2.BLLD;
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
                    
                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    string connString = db.Database.Connection.ConnectionString;
                    int existeUsuario = db.USUARIO.Where(p => p.VID_NOMBRE.Equals(txtRfc.Text.Substring(0,4))
                    && p.VID_FECHA.Equals(txtRfc.Text.Substring(4, 6)) && p.VID_HOMOCLAVE.Equals(txtRfc.Text.Substring(10, 3))).Count();

                    if (existeUsuario != 0)
                    {
                        MODELDeclara_V2.cnxDeclara bd = new MODELDeclara_V2.cnxDeclara();
                        string context = bd.Database.Connection.ConnectionString;

                        string sql = "SP_ReseteoPassword";

                        using (SqlConnection conn = new SqlConnection(context))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(sql,conn))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@RFC", txtRfc.Text.ToUpper());

                                cmd.ExecuteNonQuery();
                            }
                            conn.Close();

                            //Registra la búsqueda en bitácora
                            BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                                , "Reseteo de contraseña", "Se reseteo la contraseña del RFC: " + txtRfc.Text);
                            msgBox.ShowSuccess("Se reseteo la contraseña del RFC: " + "'" + txtRfc.Text.ToUpper() + "'" + " en DeclaraINAI, quedando: Mexico1234");
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

