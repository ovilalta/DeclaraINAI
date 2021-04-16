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
    public partial class OtrosGastos : Pagina, IDeclaracionInicial
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

        internal Int32 IndiceItemSeleccionado
        {
            get
            {
                if (ViewState["IndiceItemSeleccionado"] == null) return -1;
                return (Int32)ViewState["IndiceItemSeleccionado"];
            }

            set
            {
                if (ViewState["IndiceItemSeleccionado"] == null) ViewState.Add("IndiceItemSeleccionado", value);
                ViewState["IndiceItemSeleccionado"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liGastos")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu9")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Guardar";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "saveNext";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Guardar e ir al siguiente apartado";


                ctrlGastos.NID_TIPO_GASTO.Add(2);
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 31).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkOtrosGastos")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkOtrosGastos")).CssClass = "active";

            //moneytxtCuentas.Text = oDeclaracion.MODIFICACION.M_MONTO_AHORRO.ToString("C");
            //moneytxtAdeudos.Text = oDeclaracion.MODIFICACION.M_PAGOS_ADEUDOS.ToString("C");
            //moneytxtTarjetas.Text = oDeclaracion.MODIFICACION.M_PAGOS_TARJETAS.ToString("C");
            //moneytxtImpuestos.Text = oDeclaracion.MODIFICACION.M_IMPUESTOS.ToString("C");


            Alertota.ShowInfo("Registre todos los pagos que haya realizado en efectivo, cheque o transferencia electrónica durante " + oDeclaracion.C_EJERCICIO + " el declarante, su cónyuge, concubina o concubinario y/o sus dependientes económicos, para alguno de los siguientes conceptos (no considerar los pagos registrados en adeudos o en tarjetas de crédito):");

        }



        public void Anterior()
        {
            Response.Redirect("ImpuestosYRetenciones.aspx");
        }
        public void Siguiente()
        {
            ctrlGastos.btnGuardar(btnGuardar, null);
            AlertaSuperior.ShowSuccess("Se guardó correctamente la información");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 31);
            _oDeclaracion = oDeclaracion;
            Response.Redirect("Observaciones.aspx");
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
            ctrlGastos.btnGuardar(sender, e);
            AlertaSuperior.ShowSuccess("Se guardó correctamente la información");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 31);
            _oDeclaracion = oDeclaracion;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ctrlGastos.btnAgregar(sender, e);
        }




    }
}