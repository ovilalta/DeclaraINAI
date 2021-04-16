using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using System.IO;
using DeclaraINE.file;

namespace DeclaraINE.Formas
{
    public partial class AdministracionCuenta : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        internal enum SubSecciones
        {
            Contraseña,
            Correo
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            oUsuario.Reload_USUARIO_CORREOs();
            if (!IsPostBack)
            {
                _oUsuario.ExtenderSesion();
                pnlContraseña.Visible = true;
                pnlCorreo.Visible = false;
                ltrSubTitulo.Text = "Cambiar Contraseña";
                grdCorreos.DataBind(oUsuario.USUARIO_CORREOs);
                btnContraseña.CssClass = "active";
            }

        }

        protected void btnContraseña_Click(object sender, EventArgs e)
        {
            pnlContraseña.Visible = true;
            pnlCorreo.Visible = false;
            ltrSubTitulo.Text = "Cambiar Contraseña";
            btnContraseña.CssClass = "active";
            btnCorreo.CssClass = "";
        }

        protected void btnCorreo_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            grdCorreos.DataBind(oUsuario.USUARIO_CORREOs);
            pnlContraseña.Visible = false;
            pnlCorreo.Visible = true;
            ltrSubTitulo.Text = "Administrar Correos Electrónicos";
            btnCorreo.CssClass = "active";
            btnContraseña.CssClass = "";
        }




        protected void btnGuardarContraseña_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            if (txtContraseñaA.Text.Trim() == txtContraseñaB.Text.Trim() && oUsuario.V_PASSWORD == encriptaPass(txtContraseñaAnterior.Text.Trim()))
            {
                blld_USUARIO PasswordUpdate = new blld_USUARIO(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE);
                PasswordUpdate.V_PASSWORD = encriptaPass(txtContraseñaB.Text.Trim());
                PasswordUpdate.update();
                AlertaSuperiorPass.ShowSuccess("Contraseña actualizada");
            }
            else
            {
                AlertaSuperiorPass.ShowDanger("Revisa los datos ateriores");
            }
        }

        protected void btnCorreoPrincipal_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;

            try
            {
                String V_CORREO = ((Button)sender).CommandArgument;
                oUsuario.principal(V_CORREO);
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    AlertaSuperior.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            grdCorreos.DataBind(oUsuario.USUARIO_CORREOs);
        }


        protected void btnAgregarNCorreo_Click(object sender, EventArgs e)
        {
            mppNCorreo.HeaderText = "Agregar Nuevo Correo";
            mppNCorreo.Show(true);
            txtNuevoCorreo.Text = String.Empty;
            txtConfirmaCorreo.Text = String.Empty;
        }

        protected void btnGuardarNCorreo_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            try
            {
                if (txtNuevoCorreo.Text == txtConfirmaCorreo.Text)
                {
                    oUsuario.Add_USUARIO_CORREOs(txtNuevoCorreo.Text,true);
                    _oUsuario = oUsuario;
                    mppNCorreo.Hide();
                    grdCorreos.DataBind(oUsuario.USUARIO_CORREOs);

                }
                else
                    AlertaCorreo.ShowDanger("La dirección de correo electrónico y la confirmación deben de coincidir");
            }
            catch (Exception ex)
            {
                AlertaCorreo.ShowDanger(ex.Message);
            }
        }


        protected void btnCerrarNCorreo_Click(object sender, EventArgs e)
        {
            mppNCorreo.Hide();
        }


        protected void btnCorreoConfirmado_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            try
            {
                String V_CORREO = ((Button)sender).CommandArgument;
                oUsuario.CorreoConfirmado(V_CORREO);

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    AlertaSuperior.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            _oUsuario = oUsuario;
            oUsuario.Reload_USUARIO_CORREOs();
            grdCorreos.DataBind(oUsuario.USUARIO_CORREOs);
            pnlCorreo.Update();
        }






        protected void btnCorreoActivo_Click(object sender, EventArgs e)
        {

            blld_USUARIO oUsuario = _oUsuario;
            String V_CORREO = ((Button)sender).CommandArgument;
            mppDeshabilitarCorreo.Show(true);

            if (oUsuario.CorreoActivoEstado(V_CORREO))
            {
                mppDeshabilitarCorreo.HeaderText = "Desactivar correo electrónico";
                ltrConfTexto.Text = "Está seguro desactivar el siguiente correo:";
            }
            else
            {
                mppDeshabilitarCorreo.HeaderText = "Activar correo electrónico";
                ltrConfTexto.Text = "Activar el siguiente correo:";
            }

            ltrConfCorreo.Text = V_CORREO;

        }

        protected void btnGuardarConfirmarDeshabilitar_Click(object sender, EventArgs e)
        {

            blld_USUARIO oUsuario = _oUsuario;
            try
            {
                //oUsuario.CorreoActivo(ltrConfCorreo.Text);

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    AlertaSuperior.ShowSuccess(ex.Message);
                }
                else throw ex;
            }
            ltrConfCorreo.Text = String.Empty;
            mppDeshabilitarCorreo.Hide();
            _oUsuario = oUsuario;
            oUsuario.Reload_USUARIO_CORREOs();
            grdCorreos.DataBind(oUsuario.USUARIO_CORREOs);
            pnlCorreo.Update();
        }




        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        private string encriptaPass(string V_PASSWORD)
        {
            String strOverride = "QRTdj+mlvOfANfeIq";
            String strEncodedUser = String.Empty;
            String strEncodedUserAux = String.Empty;
            System.Security.Cryptography.SHA512 sha512 = System.Security.Cryptography.SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] stream = null;
            Byte[] byt = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(V_PASSWORD, strOverride)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            byt = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            strEncodedUser = Convert.ToBase64String(byt);
            foreach (char character in strEncodedUser) strEncodedUserAux += ((Char)(character + (Char)3)).ToString();
            strEncodedUser = strEncodedUserAux;
            strEncodedUserAux = null;
            sb = null;
            stream = null;
            sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(String.Concat(strEncodedUser, strOverride)));
            for (int x = 0; x < stream.Length; x++) sb.AppendFormat("{0:x2}", stream[x]);
            return sb.ToString().ToUpper();
        }

        protected void btnCerrarConfirmacion_Click(object sender, EventArgs e)
        {
            mppDeshabilitarCorreo.Hide();
        }

        protected void btnGuardarConfirmar_Click(object sender, EventArgs e)
        {

        }

        public static void ImprimirAcuseElectronica(blld_USUARIO oUsuario)
        {
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, "ACUSE_IDENTIFICACION_ELECTRONICA", new List<object> { oUsuario.VID_NOMBRE
                                                                               ,oUsuario.VID_FECHA
                                                                               ,oUsuario.VID_HOMOCLAVE }.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        protected void btnDescargarRespon_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            ImprimirAcuseElectronica(oUsuario);
        }
    }
}