using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using DeclaraINEAdmin;
using AlanWebControls;

namespace DeclaraINEAdmin.Formas
{
    public partial class Login : Pagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsSistema oSistema = new clsSistema();
                SessionAdd("oSistema", oSistema);
                NombreSistema.Text = oSistema.TiluloPanelDeclaraINE.ToString();
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            clsUsuario oUsuario;
            clsSistema oSistema;
            try
            {
                oSistema = (clsSistema)Session["oSistema"];
            }
            catch
            {
                oSistema = new clsSistema();
                SessionAdd("oSistema", oSistema);
            }

            String strIP;
            String strHost;
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
                oUsuario = new clsUsuario(strHost, strIP, txtUsuario.Text, txtContraseña.Text);
                SessionAdd("oUsuario", oUsuario);

                if (txtUsuario.Text == txtContraseña.Text)
                {
                    mppCambioClave.Show(true);
                    txtContrasenAnterior.Text = String.Empty;
                    txtNueva.Text = String.Empty;
                    txtConfirmar.Text = String.Empty;
                }
                else
                {
                    SessionAdd("oSistema", oSistema);
                    Response.Redirect("index.aspx", true);
                }

            }
            catch (Exception ex)
            {
                if (ex is System.Web.Services.Protocols.SoapException)
                {
                    System.Web.Services.Protocols.SoapException soapEx = ex as System.Web.Services.Protocols.SoapException;
                    MsgBox.ShowWarning(soapEx.Message);
                }
                if (ex.Data.Contains(5666))
                {
                    MsgBox.ShowWarning(ex.Message);
                }
                else
                {
                    if (ex.Data.Contains(4666))
                    {
                        MsgBox.ShowWarning(ex.Message);
                    }
                    else
                    {
                        MsgBox.ShowWarning(ex.Message);
                    }
                }

            }
        }


        protected void btnGuardarClave_Click(object sender, EventArgs e)
        {
            try
            {
                clsUsuario oUsuario = (clsUsuario)Session["oUsuario"];
                oUsuario.CambiaPassword(txtContrasenAnterior.Text, txtNueva.Text, txtConfirmar.Text);
                oUsuario = null;
                mppCambioClave.Hide();
                MsgBox.ShowSuccess("Se cambió exitosamente la contraseña, ingrese nuevamente con la nueva contraseña.");
            }
            catch (Exception ex)
            {
                AlertaSuperior.ShowDanger(ex.Message);
            }
        }

        protected void btnCerrarClave_Click(object sender, EventArgs e)
        {
            mppCambioClave.Hide();
        }
    }
}