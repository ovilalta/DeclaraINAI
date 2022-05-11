using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using System.Text;
using System.Net;
using System.Security.Principal;
using System.IO;

using System.ComponentModel;

namespace DeclaraINE.Formas.DeclaracionModificacion
{
    public partial class Observaciones : Pagina, IDeclaracionInicial
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        public Boolean lEtica
        {
            get
            {
                if (ViewState["lEtica"] == null)
                    return false;
                return (Boolean)ViewState["lEtica"];
            }
            set
            {
                if (ViewState["lEtica"] == null)
                    ViewState.Add("lEtica", value);
                else
                    ViewState["lEtica"] = value;
            }
        }

        public Boolean lConducta
        {
            get
            {
                if (ViewState["lConducta"] == null)
                    return false;
                return (Boolean)ViewState["lConducta"];
            }
            set
            {
                if (ViewState["lConducta"] == null)
                    ViewState.Add("lConducta", value);
                else
                    ViewState["lConducta"] = value;
            }
        }

        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }

        private void HabilitaBotonGuardar()
        {
            ((Button)Master.FindControl("btnSiguiente")).Visible = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liObservaciones")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu5")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                //if (String.IsNullOrEmpty(oDeclaracion.E_OBSERVACIONES) && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                //    QstBox.Ask("¿Desea capturar observaciones adicionales?");
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Guardar";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "saveNext";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Guardar e ir al siguiente apartado";
                //((Button)Master.FindControl("btnSiguiente")).Enabled = false; //Agragdo por OEVM 2022-05-05 con el objetivo de no permitir que avancen los usuarios sin que hayan revisado los codigos


                //txtObservaciones.Text = oDeclaracion.E_OBSERVACIONES;
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkObservaciones")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkObservaciones")).CssClass = "active";

        }

        public void Anterior()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
            oPuesto.select();
            var o = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single();

            bool? obligado = o.L_OBLIGADO;
            if (obligado != null)
                if (obligado.Equals(false))
                {
                    Response.Redirect("Desemp.aspx");

                }
                else
                {
                    Response.Redirect("Conflicto.aspx");
                }

        }

        public void Guardar()
        {
        }

        public void Siguiente()
        {
            if (lConducta && lEtica)
            {
                mppAcepta.Show(true);
                marcaApartado(13);
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                Response.Redirect("../DeclaracionFiscal/declaracionFiscal.aspx");
            }
            else
            {
                MsgBox.ShowDanger("Debe VER el código de Ética y el código de Conducta para cumplir con este apartado");

            }


            //oDeclaracion.E_OBSERVACIONES = txtObservaciones.Text;
            //oDeclaracion.update();
            //Response.Redirect("Envio.aspx");

            
        }

        private void marcaApartado(int NID_APARTADO)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
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
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            //marcaApartado(13);
            Response.Redirect("Envio.aspx");
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }



        protected void idConducta_Click(object sender, EventArgs e)
        {
            lConducta = true;
            try
            {
                this.lblMensaje.Text = "<inpu class='VerDoc' onclick='ValidarDescargaCodigo()'>Código de Conducta</inpu>";
                mppMensaje.Show(true);
                mppMensaje.HeaderText = "Código de Conducta";
            }
            catch { }
            if (lConducta && lEtica)
                mppAcepta.Show(true);
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            mppAcepta.Hide();
            marcaApartado(13);
        }




        protected void btnDocumento_Click(object sender, EventArgs e)
        {
            mppMensaje.Hide();
        }

        protected void idEtica_Click(object sender, EventArgs e)
        {
            lEtica = true;
            try
            {
                this.lblMensaje.Text = "<inpu class='VerDoc' onclick='ValidarDescargaEtica()'> Código de Ética</inpu>";
                mppMensaje.Show(true);
                mppMensaje.HeaderText = "Código de Ética";
            }
            catch (Exception ex) { }
            if (lConducta && lEtica)
            {
                mppAcepta.Show(true);
            }
        }



    }
}