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

namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class TarjetasDeCredito : Pagina, IDeclaracionInicial
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
        internal Boolean lEditar
        {
            get => (Boolean)ViewState["lEditar"];
            set => ViewState["lEditar"] = value;
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
        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_MODIFICACION_TARJETA o;
            for (int x = 0; x < oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs.Count; x++)
            {
                o = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).TextoPrincipal = "Tarjeta de Crédito  " + o.V_NUMERO_CORTO;
                ((Item)item).TextoSecundario = "<br>Monto de los pagos: " + o.M_PAGOS.ToString("C") + "<br> Saldo Actual: " + o.M_SALDO.ToString("C"); ;
                ((Item)item).ImageUrl = String.Concat("../../Images/icons/ColorX100/Bank Card Back Side.png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                ((Button)((Item)item).FindControl("btnBaja")).Visible = false;
                grd.Controls.AddAt(0 + x, item);
            }

            if (!IsPostBack)
            {
                C_EJERCICIO.Text = oDeclaracion.C_EJERCICIO;
                C_EJERCICIO2.Text = oDeclaracion.C_EJERCICIO;

                cblTitulares.DataBind(oDeclaracion.DECLARACION_DEPENDIENTESs, DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE, DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO);
                cblTitulares.Items.Insert(0, new ListItem("Declarante", "0"));
                //cblTitulares.Items.Insert(cblTitulares.Items.Count, new ListItem("Copropietario", "-1"));
            }

        }
        protected void OnEditar(object sender, ItemEventArgs e)
        {
            mppTarjeta.Show(true);
            lEditar = true;
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            IndiceItemSeleccionado = e.Id;
            cmbInstitución.SelectedValue = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[e.Id].NID_INSTITUCION.ToString();
            txtE_CUENTA.Text = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[e.Id].E_NUMERO.ToString();
            moneytxtM_Pagos.Text = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[e.Id].M_PAGOS.ToString();
            moneytxtM_Gasto.Text = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[e.Id].M_SALDO.ToString();
            cblTitulares.ClearSelection();
            foreach (Int32 x in oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[e.Id].MODIFICACION_TARJETA_TITUs.Select(p=> p.NID_DEPENDIENTE))
                cblTitulares.Items.FindByValue(x.ToString()).Selected = true;

        }
        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            IndiceItemSeleccionado = e.Id;
            Qst.AskDanger("Si elimina la tarjeta de crédito no será incluida en la declaración <br /> Esta acción no se puede deshacer, tendra que volver a capturarla <br />¿Desea eliminar la tarjeta de crédito?");
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

                cmbInstitución.DataBinder<blld__l_CAT_INST_FINANCIERA>(new blld__l_CAT_INST_FINANCIERA(), CAT_INST_FINANCIERA.Properties.NID_INSTITUCION, CAT_INST_FINANCIERA.Properties.V_INSTITUCION);
                cmbInstitución.Items.Insert(0, new ListItem(String.Empty, "0"));

            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 29).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkTarjetas")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkTarjetas")).CssClass = "active";
        }


        public void Anterior()
        {
            Response.Redirect("AdeudosModifica.aspx");
        }
        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 29);
            _oDeclaracion = oDeclaracion;
            Response.Redirect("ImpuestosYRetenciones.aspx");
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

        protected void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            mppTarjeta.Show(true);
            lEditar = false;
            txtE_CUENTA.Text = string.Empty;
            moneytxtM_Gasto.Text = string.Empty;
            moneytxtM_Pagos.Text = string.Empty;
            cmbInstitución.SelectedIndex = 0;
            cblTitulares.ClearSelection();
        }
        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mppTarjeta.Hide();
        }

        protected void btnGuarda_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                ActualizaTarjeta();
            }
            else
            {
                NuevaTarjeta();
            }

            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 29);
            _oDeclaracion = oDeclaracion;
        }
        private void NuevaTarjeta()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            Int32 Recorte = 0;
            string Artificio = "";
            Recorte = txtE_CUENTA.Text.Length;
            if (Recorte > 4)
                Artificio = txtE_CUENTA.Text.Substring(Recorte - 4, 4);
            else
                Artificio = txtE_CUENTA.Text;

            try
            {
                oDeclaracion.MODIFICACION.Add_MODIFICACION_TARJETAs(
                                                        txtE_CUENTA.Text,
                                                        cmbInstitución.SelectedValue(),
                                                        Artificio.ToString(),
                                                        moneytxtM_Pagos.Money(),
                                                        moneytxtM_Gasto.Money()
                                                        , true
                                                        , cblTitulares.SelectedValuesInteger()
                                                        );
                _oDeclaracion = oDeclaracion;
                int x1 = grd.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs.Count + 1;
                ((Item)item).TextoPrincipal = "Tarjeta de Crédito  " + Artificio.ToString();
                ((Item)item).TextoSecundario = "<br>Monto de los pagos:" + moneytxtM_Pagos.Money().ToString("C") + "<br> Saldo Actual: " + moneytxtM_Gasto.Money().ToString("C");
                ((Item)item).ImageUrl = String.Concat("../../Images/icons/ColorX100/Bank Card Back Side.png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                ((Button)((Item)item).FindControl("btnBaja")).Visible = false;
                grd.Controls.AddAt(x1, item);
                mppTarjeta.Hide();
                AlertaSuperior.ShowSuccess("Se agregó correctamente la Tarjeta de Crédito");
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }


        }
        private void ActualizaTarjeta()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            try
            {
                oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[Indice].M_PAGOS = moneytxtM_Pagos.Money();
                oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[Indice].M_SALDO = moneytxtM_Gasto.Money();
                oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[Indice].NID_INSTITUCION = cmbInstitución.SelectedValue();
                oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[Indice].update(cblTitulares.SelectedValuesInteger());
                _oDeclaracion = oDeclaracion;
                AlertaSuperior.ShowSuccess("Se actualizó correctamente la Tarjeta de Crédito");
                mppTarjeta.Hide();

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void Qst_Yes(object Sender, EventArgs e)
        {
            try
            {

                blld_USUARIO oUsuario = _oUsuario;
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                blld_MODIFICACION_TARJETA o;
                o = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs[IndiceItemSeleccionado];
                oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs.RemoveAt(IndiceItemSeleccionado);
                grd.Controls.RemoveAt(IndiceItemSeleccionado);
                _oDeclaracion = oDeclaracion;
                AlertaSuperior.ShowSuccess("Se eliminó correctamente la Tarjeta de Crédito");
            }
            catch (Exception ex)
            {
                if (ex.InnerException is CustomException)
                {
                    MsgBox.ShowDanger(ex.InnerException.Message);
                }
                else
                {
                    if (ex is CustomException || ex is ConvertionException)
                    {
                        MsgBox.ShowDanger(ex.Message);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        protected void Qst_No(object Sender, EventArgs e)
        {
          
        }
    }
}