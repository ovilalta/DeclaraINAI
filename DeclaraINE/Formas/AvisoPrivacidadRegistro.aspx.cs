using Declara_V2.BLLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas
{
    public partial class AvisoPrivacidadRegistro : System.Web.UI.Page
    {

        clsSistema _oSistema => (clsSistema)Session["oSistema"];

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                clsSistema oSistema = _oSistema;
                if (oSistema == null)
                    Response.Redirect("Login");
            }
            catch
            {
                Response.Redirect("Login");
            }

            if (!IsPostBack)
            {
                Page.Title = "Aviso de Privacidad Registro";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}