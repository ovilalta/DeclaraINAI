using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;

namespace DeclaraINE.Formas
{
    public partial class Confirma : Pagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                try
                {
                    String VID_NOMBRE = Base64_Decode(Request.QueryString["ein"]);
                    String VID_FECHA = Base64_Decode(Request.QueryString["zwei"]);
                    String VID_HOMOCLAVE = Base64_Decode(Request.QueryString["drei"]);
                    String V_CORREO = Request.QueryString["mailto"];
                    String V_CODIGO = Request.QueryString["vier"];
                    Boolean V_ACCION = Base64_Decode(Request.QueryString["funf"]).Equals("ZEN");
                    if (V_ACCION)
                    {
                        btnConfirmar(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, V_CODIGO);
                        this.Page.Title = "Confirmación de Cuenta de Usuario";
                    }
                    else
                    {

                        btnConfirmarCorreo(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, V_CODIGO);
                        this.Page.Title = "Confirmación de Correo Electrónico";
                    }
                    
                    ltr.DataBind();
                }
                catch
                {
                    QstBox.AskSuccess("No válido");
                }
            }
        }

        private void btnConfirmar(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, String V_CODIGO)
        {
            try
            {
                blld_USUARIO oUsuario = new blld_USUARIO(VID_NOMBRE
                   , VID_FECHA
                   , VID_HOMOCLAVE);
                oUsuario.Activar(V_CORREO, V_CODIGO);
                QstBox.AskSuccess("Se ha activado correctamente la cuenta, utilice el R.F.C o el correo electrónico como nombre de usuario y la contraseña que escribio para entrar al sistema");
            }
            catch (Exception ex)
            {
                QstBox.AskSuccess(ex.Message);
            }
        }

        private void btnConfirmarCorreo(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, String V_CODIGO)
        {
            try
            {
                blld_USUARIO_CORREO oCorreo = new blld_USUARIO_CORREO(VID_NOMBRE
                   , VID_FECHA
                   , VID_HOMOCLAVE,V_CORREO);
                //oCorreo.Activar();
            }
            catch (Exception ex)
            {
                QstBox.AskSuccess(ex.Message);
            }
        }


        protected void QstBox_Yes(object Sender, EventArgs e)
        {
            Response.Redirect(clsSistema.URL_SISTEMA.ToString());
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            Response.Redirect(clsSistema.URL_SISTEMA.ToString());
        }
    }
}