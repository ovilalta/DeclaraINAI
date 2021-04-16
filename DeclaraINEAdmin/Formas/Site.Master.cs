using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using System.Globalization;

namespace DeclaraINEAdmin.Formas
{
    public partial class SiteMaster : MasterPage
    {

        DeclaraINEAdmin.clsUsuario _oUsuario
        {
            get => (DeclaraINEAdmin.clsUsuario)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        DeclaraINEAdmin.clsSistema _oSistema
        {
            get => (DeclaraINEAdmin.clsSistema)Session["oSistema"];
            set => SessionAdd("oSistema", value);
        }

        protected void Page_Init(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                clsSistema oSistema = _oSistema;
                clsUsuario oUsuario = _oUsuario;

                MenuPrincipal.ParentIdField = "NID_MENU_SUPERIOR";
                MenuPrincipal.IdField = "NID_MENU";
                MenuPrincipal.TextField = "V_TEXTO_MENU";
                MenuPrincipal.ImageUrlField = "V_URL";
                MenuPrincipal.HrefField = "V_NOMBRE_FORMA";
                MenuPrincipal.OrderField = "N_ORDEN";
                MenuPrincipal.DataBind(oUsuario.Menu);
            }
            else
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lkCierreSesion_Click(object sender, EventArgs e)
        {

            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Formas/login");
        }


        protected void SessionAdd(String ObjectName, Object Objeto)
        {
            if (Session[ObjectName] == null) Session.Add(ObjectName, Objeto);
            else Session[ObjectName] = Objeto;
        }

    }
}