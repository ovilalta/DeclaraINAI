using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using System.Text.RegularExpressions;

namespace DeclaraINEAdmin.Formas
{
    public partial class CambioContraseña : Pagina
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("CambioContraseña");
            }

        }

        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["Object2"];
            set => SessionAdd("Object2", value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBusqueda.Text.Length < 3)
                    throw new CustomException("Escriba más caracteres para realizar la busqueda");

                blld__l_USUARIO ListaUsuario = new blld__l_USUARIO();
                List<USUARIO> resultado = new List<USUARIO>();

                ListaUsuario.VID_RFC = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                ListaUsuario.select();
                foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                    resultado.Add(u);

                //ListaUsuario = new blld__l_USUARIO();
                //ListaUsuario.VID_FECHA = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                //ListaUsuario.select();
                //foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                //    if (!resultado.Contains(u))
                //    resultado.Add(u);

                //ListaUsuario = new blld__l_USUARIO();
                //ListaUsuario.VID_HOMOCLAVE = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                //ListaUsuario.select();
                //foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                //    if (!resultado.Contains(u))
                //        resultado.Add(u);

                ListaUsuario = new blld__l_USUARIO();
                ListaUsuario.V_NOMBRE_COMPLETO_ESTILO1 = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                ListaUsuario.select();
                foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                    if (!resultado.Where(p => p.VID_NOMBRE == u.VID_NOMBRE && p.VID_FECHA == u.VID_FECHA && p.VID_HOMOCLAVE == u.VID_HOMOCLAVE).Any())
                        resultado.Add(u);

                ListaUsuario = new blld__l_USUARIO();
                ListaUsuario.V_NOMBRE_COMPLETO_ESTILO2 = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                ListaUsuario.select();
                foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                    if (!resultado.Where(p => p.VID_NOMBRE == u.VID_NOMBRE && p.VID_FECHA == u.VID_FECHA && p.VID_HOMOCLAVE == u.VID_HOMOCLAVE).Any())
                        resultado.Add(u);

                //ListaUsuario = new blld__l_USUARIO();
                //ListaUsuario.V_SEGUNDO_A = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                //ListaUsuario.select();
                //foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                //    if (!resultado.Contains(u))
                //        resultado.Add(u);



                SessionAdd("Object1", resultado);
                grdUsuario.DataSource = resultado;
                grdUsuario.DataBind();
                if (!resultado.Any())
                    throw new CustomException("La busqueda no generó ningun resultado");
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaSuperior.ShowDanger(ex.Message);
                else
                    throw ex;
            }
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            mppCambioContraseña.Show(true);
            String RFC = ((Button)sender).CommandArgument;
            blld_USUARIO oUsuario = new blld_USUARIO(RFC.Substring(0, 4).ToUpper(), RFC.Substring(4, 6).ToUpper(), RFC.Substring(10, 3).ToUpper());
            ltrNombreCompreto.Text = oUsuario.V_NOMBRE_COMPLETO.ToString();
            ltrRfc.Text = RFC;
            txtNueva.Text = String.Empty;
            _oUsuario = oUsuario;
        }

        protected void btnEditarEnviarContraseña_Click(object sender, EventArgs e)
        {
            String RFC = ((Button)sender).CommandArgument;
            try
            {
                blld_USUARIO_REC_PASS.SolicitaRecuperacion(RFC);
                MsgBox.ShowSuccess("Solicitud de Recuperación de Contraseña Enviada");
            }
            catch (Exception ex)
            {
                MsgBox.ShowDanger(ex.Message);
            }
        }

        protected void btnActivarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                String RFC = ((Button)sender).CommandArgument;
                _oUsuario = new blld_USUARIO(RFC.Substring(0, 4).ToUpper(), RFC.Substring(4, 6).ToUpper(), RFC.Substring(10, 3).ToUpper());

                blld_USUARIO oUsuario = _oUsuario;
                cbxlActivo.Checked = oUsuario.L_ACTIVO;
                ltrIngresoInstituto.Text = oUsuario.F_INGRESO_INSTITUTO.ToString("dd/MM/yyyy");
                ltrRegistro.Text = oUsuario.F_REGISTRO.ToString("dd/MM/yyyy");
                mppCorreos.HeaderText = String.Concat("Detalles del Acceso ", oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, " ", oUsuario.V_NOMBRE_COMPLETO);
                btnDesactivar.Enabled = oUsuario.L_ACTIVO;
                btnReenviarComprobacion.Enabled = !oUsuario.L_ACTIVO;
                
                grdCorreos.DataSource = oUsuario.USUARIO_CORREOs;
                grdCorreos.DataBind();
                mppCorreos.Show(true);

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    MsgBox.ShowDanger(ex.Message);
                else
                    throw ex;
            }
        }

        protected void btnRestablecerContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                String RFC = ((Button)sender).CommandArgument;
                blld_USUARIO oUsuario = new blld_USUARIO(RFC.Substring(0, 4).ToUpper(), RFC.Substring(4, 6).ToUpper(), RFC.Substring(10, 3).ToUpper());
                oUsuario.RestableceContraseña();

                MsgBox.ShowSuccess("Contraseña Restablecida ");
            }
            catch (Exception ex)
            {
                MsgBox.ShowDanger(ex.Message);
            }
        }

        protected void btnGuardarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNueva.Text == String.Empty) throw new CustomException("Escribe una contraseña");
                blld_USUARIO oUsuario = _oUsuario;
                blld_USUARIO PasswordUpdate = new blld_USUARIO(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE);
                PasswordUpdate.V_PASSWORD = encriptaPass(txtNueva.Text.Trim());
                PasswordUpdate.update();
                AlertaSuperiorSolicitud.ShowSuccess("Contraseña actualizada");
            }
            catch (Exception ex)
            {

                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void btnCerrarContraseña_Click(object sender, EventArgs e)
        {
            mppCambioContraseña.Hide();
        }

        protected void btnCerrarConsulta_Click(object sender, EventArgs e)
        {
            mppCorreos.Hide();
        }


        protected void btnReenviarComprobacion_Click(object sender, EventArgs e)
        {

            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                foreach (GridViewRow row in grdCorreos.Rows)
                {
                    oUsuario.USUARIO_CORREOs.Where(p => p.V_CORREO == ((Literal)row.FindControl("lrtCorreo")).Text).First().EnviarCorreoConfirmacionCuenta();
                }
                MsgBox.ShowSuccess("Se envió correctamente el correo electrónico de activacion a todos los correos registrados");
                _oUsuario = oUsuario;
            }
            catch (Exception ex)
            {

                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void btnAgregarCorreo_Click(object sender, EventArgs e)
        {
            mppCorreos.Hide();
            txtNuevoCorreo.Text = String.Empty;
            mppNuevoCorreo.HeaderText = mppCorreos.HeaderText;
            mppNuevoCorreo.Show(true);
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            QstBox.ArgumentString = "DesactivarUsuario";
            QstBox.AskWarning("¿Desea desactivar el usuario?");
        }

        protected void btnGuardarNuevoCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                oUsuario.Add_USUARIO_CORREOs(txtNuevoCorreo.Text,false);
                grdCorreos.DataSource = oUsuario.USUARIO_CORREOs;
                grdCorreos.DataBind();
                mppNuevoCorreo.Hide();
                mppCorreos.Show(true);
                _oUsuario = oUsuario;
            }
            catch (Exception ex)
            {

                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void btnCerrarNuevoCorreo_Click(object sender, EventArgs e)
        {
            mppNuevoCorreo.Hide();
            mppCorreos.Show(true);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                String V_CORREO = ((Button)sender).CommandArgument;
                if (!oUsuario.L_ACTIVO)
                {
                    oUsuario.USUARIO_CORREOs.Where(p => p.V_CORREO == V_CORREO).First().delete();
                    oUsuario.Reload_USUARIO_CORREOs();
                    grdCorreos.DataSource = oUsuario.USUARIO_CORREOs;
                    grdCorreos.DataBind();
                    _oUsuario = oUsuario;
                }
                else
                {
                    if (!oUsuario.USUARIO_CORREOs.Where(p => p.V_CORREO == V_CORREO).First().L_CONFIRMADO)
                    {
                        oUsuario.USUARIO_CORREOs.Where(p => p.V_CORREO == V_CORREO).First().delete();
                        oUsuario.Reload_USUARIO_CORREOs();
                        grdCorreos.DataSource = oUsuario.USUARIO_CORREOs;
                        grdCorreos.DataBind();
                    }
                    else
                    {
                        QstBox.ArgumentString = V_CORREO.Replace("@",String.Empty);
                        QstBox.AskSuccess("Eliminar un correo electrónico activo desactivara al usuario ¿Desea continuar?");
                    }
                }
                _oUsuario = oUsuario;
            }
            catch (Exception ex)
            {

                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void btnAceptarConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                String V_CORREO = ((Button)sender).CommandArgument;
                oUsuario.USUARIO_CORREOs.Where(p => p.V_CORREO == V_CORREO).First().EnviarConfirmarCorreo();
                _oUsuario = oUsuario;
                MsgBox.ShowSuccess("Se envió correctamente el correo de confirmación de correo electrónico");
            }
            catch (Exception ex)
            {

                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {
            switch (QstBox.ArgumentString)
            {
                case "DesactivarUsuario":
                    try
                    {
                        blld_USUARIO oUsuario = _oUsuario;
                        oUsuario.Desactivar();
                        oUsuario.Reload_USUARIO_CORREOs();
                        grdCorreos.DataSource = oUsuario.USUARIO_CORREOs;
                        grdCorreos.DataBind();
                        _oUsuario = oUsuario;
                        cbxlActivo.Checked = oUsuario.L_ACTIVO;
                        btnDesactivar.Enabled = oUsuario.L_ACTIVO;
                        btnReenviarComprobacion.Enabled = !oUsuario.L_ACTIVO;
                        mppCorreos.Update();
                        MsgBox.ShowSuccess("Se desactivó correctamente el usuario");

                    }
                    catch (Exception ex)
                    {

                        if (ex is CustomException || ex is ConvertionException)
                        {
                            MsgBox.ShowDanger(ex.Message);
                        }
                        else throw ex;
                    }
                    break;
                default:
                    if (QstBox.ArgumentString.Contains("@"))
                    {
                        try
                        {
                            blld_USUARIO oUsuario = _oUsuario;
                            oUsuario.USUARIO_CORREOs.Where(p => p.V_CORREO == QstBox.ArgumentString).First().delete();
                            oUsuario.Reload_USUARIO_CORREOs();
                            grdCorreos.DataSource = oUsuario.USUARIO_CORREOs;
                            grdCorreos.DataBind();
                            oUsuario.Desactivar();
                            _oUsuario = oUsuario;
                            cbxlActivo.Checked = oUsuario.L_ACTIVO;
                            btnDesactivar.Enabled = oUsuario.L_ACTIVO;
                            btnReenviarComprobacion.Enabled = !oUsuario.L_ACTIVO;
                            MsgBox.ShowSuccess("Se desactivó correctamente el usuario");
                        }
                        catch (Exception ex)
                        {

                            if (ex is CustomException || ex is ConvertionException)
                            {
                                MsgBox.ShowDanger(ex.Message);
                            }
                            else throw ex;
                        }
                    }
                    break;
            }
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

    }
}