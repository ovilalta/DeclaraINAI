using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Declara_V2.BLLD;
using Declara_V2;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;

namespace DeclaraINE.Formas.DeclaracionModificacion
{
    public partial class ImpuestosYRetenciones : Pagina, IDeclaracionInicial
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ((Button)Master.FindControl("dummy")).Enabled = false;
           

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liGastos")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu9")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
                ctrlGastos1.NID_TIPO_GASTO.Add(1);
                //ctrlGastos1.NID_PATRIMONIO = 2;
                ctrlGastos1.V_GASTO_DEFAULT = "¡Nuevo Impuesto!";
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 30).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkImpuestos")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkImpuestos")).CssClass = "active";
        }


        public void Anterior()
        {
            Response.Redirect("TarjetasDeCredito.aspx");
        }
        public void Siguiente()
        {
            Response.Redirect("OtrosGastos.aspx");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 30);
            _oDeclaracion = oDeclaracion;
        }

        private void marcaApartado(ref blld_DECLARACION oDeclaracion, int NID_APARTADO)
        {
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO.HasValue)
            {
                if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO.Value)
                {
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO = true;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().update();
                }
            }
            else
            {
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO = true;
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().update();
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 29, 30, 31 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
            {
                if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 28).First().L_ESTADO.Value)
                {
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 28).First().L_ESTADO = true;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 28).First().update();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ctrlGastos1.btnGuardar(sender, e);
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 30);
            _oDeclaracion = oDeclaracion;
            AlertaSuperior.ShowSuccess("Se guardó correctamente la información");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ctrlGastos1.btnAgregar(sender,e);
        }

      
    }
}