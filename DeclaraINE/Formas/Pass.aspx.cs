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
    public partial class Pass : Pagina
    {
        clsSistema _oSistema => (clsSistema)Session["oSistema"];

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

        private Int32 N_INTENTOS
        {
            get => (Int32)Session["N_INTENTOS"];
            set => SessionAdd("N_INTENTOS", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Contraseña Olvidada";
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
        }


        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("login");
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
                    blld_USUARIO_REC_PASS.SolicitaRecuperacion(txtRFC.Text);
                    pnlRecuperacion.Visible = false;
                    pnlConfimacion.Visible = true;
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