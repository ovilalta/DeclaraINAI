using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AlanWebControls;

namespace DeclaraINE.Formas.DeclaracionInicial
{
    public partial class Envio : Pagina, IDeclaracionInicial
    {
        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            ((HtmlControl)Master.FindControl("liEnvio")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu7")).Attributes.Add("class", "tab-pane fade level1 active in");
            if (!IsPostBack)
            {

                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Enviar";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "send";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Enviar declaración";
                cambiarBoton();
                PostBackTrigger trigger = new PostBackTrigger();
                trigger.ControlID = btnPrevisualizar.UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkEnvio")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkEnvio")).CssClass = "active";


        }

        private void cambiarBoton()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
            {
                btnPrevisualizar.CssClass = "big pdf";
                lrtAccion.Text = "Vista previa de la declaración";
            }
            else
            {
                btnPrevisualizar.CssClass = "big enviar";
                lrtAccion.Text = "Enviar la declaración";
            }
        }

        private void enviar()
        {
            try
            {
                if (_oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO != 0 && p.L_ESTADO == false).Any())
                {
                    MsgBox.ShowDanger("Debe finalizar todos los apartados para poder enviar la declaración");
                }
                else
                {
                    _oDeclaracion.enviar(SiNo.Checked);
                    QstBox.AskSuccess("Se envió correctamente la declaración ¿Desea consultar el acuse?");
                }
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    if (ex.InnerException != null)
                    {
                        MsgBox.ShowDanger(ex.InnerException.Message);
                    }
                    else
                    {
                        MsgBox.ShowDanger(ex.Message);
                    }
                }
                else
                {
                    if (ex.InnerException == null)
                    {
                        throw ex;
                    }
                    else if (ex.InnerException is CustomException)
                    {
                        MsgBox.ShowDanger(ex.InnerException.Message);
                    }
                    else
                    {
                        throw ex;
                    }
                }


            }

        }

        public void Anterior()
        {
            Response.Redirect("Conflicto.aspx");
        }

        public void Guardar()
        {
        }

        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
            {
                QstBoxEnviar.AskWarning("¿Desea enviar la declaración? <br />Debe tomar en cuenta que una vez enviada la declaración no podrá hacer modificaciones");
            }
            else
            {
                MsgBox.ShowDanger("Debe generar una vista previa de la declaración terminada antes de enviar la declaración");
            }
        }

        protected void btnPrevisualizar_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
            {
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO = true;
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().update();
                cambiarBoton();
                _oDeclaracion = oDeclaracion;
                _Inicial.Imprimir(oDeclaracion, true);
            }
            else
            {
                if (_oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO != 0 && p.L_ESTADO == false).Any())
                {
                    MsgBox.ShowDanger("Debe finalizar todos los apartados para poder enviar la declaración");
                }
                else
                {
                    cambiarBoton();
                    QstBoxEnviar.AskWarning("¿Desea enviar la declaración? <br />Debe tomar en cuenta que una vez enviada la declaración no podrá hacer modificaciones");
                }
            }
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {
            Response.Redirect("../ConsultaDeclaraciones.aspx");
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void QstBoxEnviar_Yes(object Sender, EventArgs e)
        {
            enviar();
        }

        protected void QstBoxEnviar_No(object Sender, EventArgs e)
        {

        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //blld_DECLARACION oDeclaracion = _oDeclaracion;
                //try { _Inicial.Imprimir(oDeclaracion); }
                //catch (Exception ex) { }
            }
        }

        protected void SiNo_CheckedChanged(object sender, EventArgs e)
        {
            _oDeclaracion.L_AUTORIZA_PUBLICAR = SiNo.Checked;
            _oDeclaracion.update();
        }
    }
}