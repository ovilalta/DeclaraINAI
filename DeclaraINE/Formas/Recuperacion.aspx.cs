using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using AlanWebControls;
using Declara_V2.Exceptions;


namespace DeclaraINAI.Formas
{
    public partial class Recuperacion : Pagina
    {
        private blld_USUARIO_REC_PASS _oRecuperacion
        {
            get => (blld_USUARIO_REC_PASS)Session["oRecuperacion"];
            set => SessionAdd("oRecuperacion", value);
        }

        private String VID_NOMBRE
        {
            get => (String)ViewState["VID_NOMBRE"];
            set => ViewState.Add("VID_NOMBRE", value);
        }
        private String VID_FECHA
        {
            get => (String)ViewState["VID_FECHA"];
            set => ViewState.Add("VID_FECHA", value);
        }
        private String VID_HOMOCLAVE
        {
            get => (String)ViewState["VID_HOMOCLAVE"];
            set => ViewState.Add("VID_HOMOCLAVE", value);
        }
        private String V_CORREO
        {
            get => (String)ViewState["V_CORREO"];
            set => ViewState.Add("V_CORREO", value);
        }

        private String V_CODIGO
        {
            get => (String)Session["V_CODIGO"];
            set => SessionAdd("V_CODIGO", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSistema.lActivaCaptcha)
            {
                ltrAPIGoogle.Text = Login.APIGoogle;
                ltrScriptGoogle.Text = Login.ScriptGoogle;
            }

            if (!IsPostBack)
            {
                try
                {
                    if (clsSistema.lActivaCaptcha)
                    {
                        txtCaptcha.Visible = true;
                        rfvCaptcha.Visible = true;
                        trCaptcha.Visible = true;
                    }
                    else
                    {
                        txtCaptcha.Visible = false;
                        rfvCaptcha.Visible = false;
                        trCaptcha.Visible = false;
                    }


                    VID_NOMBRE = Base64_Decode(Request.QueryString["ein"]);
                    VID_FECHA = Base64_Decode(Request.QueryString["zwei"]);
                    VID_HOMOCLAVE = Base64_Decode(Request.QueryString["drei"]);
                    V_CORREO = Request.QueryString["mailto"];
                    V_CODIGO = Request.QueryString["vier"];

                    blld__l_USUARIO_REC_PASS oRCorreo = new blld__l_USUARIO_REC_PASS();
                    oRCorreo.VID_NOMBRE = new Declara_V2.StringFilter(VID_NOMBRE);
                    oRCorreo.VID_FECHA = new Declara_V2.StringFilter(VID_FECHA);
                    oRCorreo.VID_HOMOCLAVE = new Declara_V2.StringFilter(VID_HOMOCLAVE);
                    oRCorreo.select();
                    if (oRCorreo.lista_USUARIO_REC_PASS.Any())
                    {
                        blld_USUARIO_REC_PASS oRecuperacion = new blld_USUARIO_REC_PASS(oRCorreo.lista_USUARIO_REC_PASS[0],V_CODIGO);
                        _oRecuperacion = oRecuperacion;
                        mppCambioClave.Show();
                    }
                    else
                        throw new CustomException("No se ha solicitado ninguna recuperación de contraseña");

                }
                catch (Exception ex)
                {
                    mppCambioClave.Hide();
                    MsgBox.ShowDanger(ex.Message);
                }
            }
        }
        protected void btnGuardarClave_Click(object sender, EventArgs e)
        {
            blld_USUARIO_REC_PASS oRecuperacion = _oRecuperacion;
            try
            {
                _oRecuperacion = blld_USUARIO.ActualizarPassCodigoRecuperacion(oRecuperacion, V_CODIGO, txtNueva.Text, txtConfirmar.Text);
                mppCambioClave.Hide();
                pnlMensaje.Visible = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowDanger(ex.Message);
                _oRecuperacion.N_USOS++;
                _oRecuperacion.update();
            }


        }

        protected void btnSistema_Click(object sender, EventArgs e)
        {
            Response.Redirect(clsSistema.URL_SISTEMA.ToString());
        }
    }
}