using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;
using System.Web.Services;
using System.Net;

namespace DeclaraINAI.Formas
{
    public partial class Login : Pagina
    {
        //internal protected static string ReCaptcha_Key => "6LfyBjYUAAAAADCz5C7cnc-pomCZQvEsXflv240W";
        //internal protected static string ReCaptcha_Secret => "6LfyBjYUAAAAAC7okLUec0kAoGuFsStVMXIbx6YS";

        internal protected static string ReCaptcha_Key => "6Lcbo80UAAAAAD1EGOixaZ1gO9gsXMhRl5ouViLL";
        internal protected static string ReCaptcha_Secret => "6Lcbo80UAAAAAH3elLf2LE3FTjn9pYYxSuPt098z";

        internal static string APIGoogle => "<script type=\"text/javascript\" src=\"https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit\" async=\"async\" defer=\"defer\"></script>";
        internal static string ScriptGoogle => "<script type=\"text/javascript\"> " +
            "var onloadCallback = function () { " +
                "grecaptcha.render('dvCaptcha', { " +
                    "'sitekey': '6Lcbo80UAAAAAD1EGOixaZ1gO9gsXMhRl5ouViLL', " +
                    "'callback': function (response) { " +
                        "$.ajax({ " +
                            "type: \"POST\", " +
                            "url: \"VerifyCaptcha.asmx/Verify\", " +
                            "data: \"{response: '\" + response + \"'}\", " +
                            "contentType: \"application/json; charset=utf-8\", " +
                            "dataType: \"json\", " +
                            "success: function (r) { " +
                                "var captchaResponse = jQuery.parseJSON(r.d); " +
                                "if (captchaResponse.success) { " +
                                    "$(\"[id*=txtCaptcha]\").val(captchaResponse.success); " +
                                    "$(\"[id*=rfvCaptcha]\").hide(); " +
                                "} else { " +
                                    "$(\"[id*=txtCaptcha]\").val(\"\"); " +
                                    "$(\"[id*=rfvCaptcha]\").show(); " +
                                    "var error = captchaResponse[\"error-codes\"][0]; " +
                                    "$(\"[id*=rfvCaptcha]\").html(\"RECaptcha error. \" + error); " +
                                "} " +
                            "} " +
                        "}); " +
                    "} " +
               "}); " +
            "}; " +
 "</script> ";

        [WebMethod]
        public static string VerifyCaptcha(string response)
        {
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
            return (new WebClient()).DownloadString(url);
        }
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        blld_USUARIO_SESION _oUsuario_Sesion
        {
            get => (blld_USUARIO_SESION)Session["oUsuario_Sesion"];
            set => SessionAdd("oUsuario_Sesion", value);
        }
        clsSistema _oSistema
        {
            get => (clsSistema)Session["oSistema"];
            set => SessionAdd("oSistema", value);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (clsSistema.lActivaCaptcha)
            {
                ltrAPIGoogle.Text = APIGoogle;
                ltrScriptGoogle.Text = ScriptGoogle;
            }
            if (!IsPostBack)
            {
                Session.RemoveAll();
                _oSistema = new clsSistema();
                Page.Title = "Login";
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
                if (!String.IsNullOrEmpty(clsSistema.MensajeInicial))
                    MsgBox.ShowDanger(clsSistema.MensajeInicial);
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            String strIP;
            String strHost;

            try
            {
                strIP = String.Join(",", (System.Collections.Generic.IEnumerable<System.Net.IPAddress>)System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).AddressList).Trim('.').Trim(',').Trim();
                if (String.IsNullOrEmpty(strIP)) throw new Exception();
            }
            catch
            {
                try
                {
                    strIP = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim('.').Trim(',').Trim();
                    if (String.IsNullOrEmpty(strIP)) throw new Exception();
                }
                catch
                {
                    strIP = "Host name not reached";
                }
            }
            try
            {
                strHost = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName.Trim('.').Trim(',').Trim();
                if (String.IsNullOrEmpty(strHost.Trim())) throw new Exception();
            }
            catch
            {
                try
                {
                    strHost = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim('.').Trim(',').Trim();
                    if (String.IsNullOrEmpty(strHost.Trim())) throw new Exception();
                }
                catch
                {
                    strHost = "Host name not reached";
                }
            }


            try
            {
                string captchaResponse = HttpContext.Current.Request.Form["g-Recaptcha-Response"];
                blld_USUARIO oUsuario = new blld_USUARIO(
                                                          txtUsuario.Text,
                                                          txtContraseña.Text,
                                                          strIP,
                                                          strHost,
                                                          1
                                                        );
                _oSistema = new clsSistema();
                Response.Redirect("Index.aspx", false);
                _oUsuario = oUsuario;

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    if (ex is CustomException && ex.InnerException != null)
                    {
                        if (ex.InnerException is CustomException && ((CustomException)ex.InnerException).Data.Contains("CambiarPass"))
                        {

                        }
                        else
                        {
                            MsgBox.ShowDanger(ex.Message);
                        }
                    }
                    else
                    {
                        MsgBox.ShowDanger(ex.Message);
                    }
                }
                else
                    MsgBox.ShowDanger(ex.Message);
            }

        }

        //protected void btnOlvido_Click(object sender, EventArgs e)
        //{
        //    _oSistema = new clsSistema();
        //    Response.Redirect("Pass.aspx");

        //}

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            _oSistema = new clsSistema();
            Response.Redirect("AvisoPrivacidadRegistro.aspx");
        }



        protected void btnRecuperaClave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtRFC.Text.Trim()))
                {
                    MsgBox.ShowDanger("El R.F.C. no puede ser vacio");
                }
                else if (txtRFC.Text.Trim().Length != 13)
                {
                    MsgBox.ShowDanger("El R.F.C. debe ser exactamente de 13 posiciones");
                }
                else
                {
                    //  blld_USUARIO_REC_PASS.SolicitaRecuperacion(txtRFC.Text);
                    string vCorreo = blld_USUARIO_REC_PASS.SolicitaRecuperacionV2(txtRFC.Text);
                    MsgBox.ShowSuccess("Se ha enviado un correo a " + vCorreo + ", con un enlace para restablecer su contraseña");
                    Session.Remove("oSistema");
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowDanger(ex.Message);
            }

        }

    }
}