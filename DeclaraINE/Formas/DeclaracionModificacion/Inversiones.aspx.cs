﻿using AlanWebControls;
using Declara_V2;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using MODELDeclara_V2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas.DeclaracionModificacion
{
    public partial class Inversiones : Pagina, IDeclaracionInicial
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
            blld_ALTA_INVERSION o;

            for (int x = 0; x < oDeclaracion.ALTA.ALTA_INVERSIONs.Count; x++)
            {
                o = oDeclaracion.ALTA.ALTA_INVERSIONs[x];
                
                UserControl item = (UserControl)Page.LoadControl("ItemBaja.ascx");
                ((ItemBaja)item).Id = x;
                ((ItemBaja)item).TextoPrincipal = o.V_TIPO_INVERSION + "<br>" + o.V_SUBTIPO_INVERSION + "<br>" + o.V_INSTITUCION ;
                ((ItemBaja)item).TextoSecundario = "<br>No. Cuenta :" + o.E_CUENTA + "<br> Saldo : " + o.M_SALDO.ToString("C"); ;
                ((ItemBaja)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INVERSION/", o.NID_TIPO_INVERSION, ".png");
                ((ItemBaja)item).Editar += OnEditar;
                ((ItemBaja)item).Eliminar += OnEliminar;
                ((ItemBaja)item).Bajar += OnBaja;
                if (o.F_APERTURA < String.Concat("01/01/", Convert.ToString(System.DateTime.Today.Year - 1)).Date())
                {
                    //((Button)((ItemBaja)item).FindControl("btnEliminar")).Visible = false;
                    ((Button)((ItemBaja)item).FindControl("btnBaja")).Visible = false;
                }

                if (o.F_APERTURA > String.Concat("01/01/", Convert.ToString(System.DateTime.Today.Year - 1)).Date())
                {
                    ((Button)((ItemBaja)item).FindControl("btnEliminar")).Visible = true;
                    ((Button)((ItemBaja)item).FindControl("btnBaja")).Visible = false;
                }
                grd.Controls.AddAt(0 + x, item);
            }

            if (!IsPostBack)
            {
                txtF_APERTURA_C.StartDate = new DateTime(1900, 1, 1);
                txtF_APERTURA_C.EndDate = DateTime.Today.AddDays(-1);
                txtF_APERTURA.Text= DateTime.Today.ToShortDateString();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liInversiones")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu3")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                //OEVM
                if (oDeclaracion.ALTA.ALTA_INVERSIONs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                  //  QstBox.Ask("¿Cuenta con inversiones en alguna institución financiera, en especie o en efectivo?");
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";

                //OEVM quitó renglones comentados - 20200617
                cmbNID_TIPO_INVERSION.DataBinder<blld__l_CAT_TIPO_INVERSION>(new blld__l_CAT_TIPO_INVERSION(), Declara_V2.MODELextended.CAT_TIPO_INVERSION.Properties.NID_TIPO_INVERSION, Declara_V2.MODELextended.CAT_TIPO_INVERSION.Properties.V_TIPO_INVERSION, false);
                cmbNID_TIPO_INVERSION_SelectedIndexChanged(sender, e);
                cmbNID_TIPO_INVERSION.Items.Insert(0, new ListItem(String.Empty));

                cmbNID_PAIS.DataBinder<blld__l_CAT_PAIS>(new blld__l_CAT_PAIS(), Declara_V2.MODELextended.CAT_PAIS.Properties.NID_PAIS, Declara_V2.MODELextended.CAT_PAIS.Properties.V_PAIS, false);
                //cmbNID_PAIS_SelectedIndexChanged(sender, e);
                cmbNID_PAIS.Items.Insert(0, new ListItem(String.Empty));
                blld__l_CAT_INST_FINANCIERA oInstitucion = new blld__l_CAT_INST_FINANCIERA();
                oInstitucion.OrderByCriterios.Add(new Order(Declara_V2.MODELextended.CAT_INST_FINANCIERA.Properties.V_INSTITUCION));
                oInstitucion.select();
                cmbNID_INSTITUCION.DataBind(oInstitucion.lista_CAT_INST_FINANCIERA, Declara_V2.MODELextended.CAT_INST_FINANCIERA.Properties.NID_INSTITUCION, Declara_V2.MODELextended.CAT_INST_FINANCIERA.Properties.V_INSTITUCION, false);
                cmbNID_INSTITUCION_SelectedIndexChanged(sender, e);
                cmbNID_INSTITUCION.Items.Insert(0, new ListItem(String.Empty));
                // cmbNID_INSTITUCION.Items.Insert(0, new ListItem("Seleccione", ""));

                //cblTitulares.DataBind(oDeclaracion.DECLARACION_DEPENDIENTESs, DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE, DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO);
                //cblTitulares.Items.Insert(0, new ListItem("Declarante", "0"));
                //cblTitulares.Items.Insert(cblTitulares.Items.Count, new ListItem("Copropietario", "-1"));
                cblTitulares.Items.Insert(0, new ListItem("Declarante", "0"));
                cblTitulares.Items.Insert(1, new ListItem("Declarante y Cónyuge", "1"));
                cblTitulares.Items.Insert(2, new ListItem("Declarante y Cónyuge en Copropiedad con Terceros", "2"));
                cblTitulares.Items.Insert(3, new ListItem("Declarante en Copropiedad con Terceros", "3"));
                cblTitulares.Items.Insert(4, new ListItem("Declarante y Concubina o Concubinario", "4"));
                cblTitulares.Items.Insert(5, new ListItem("Declarante y Concubina o Concubinario en Copropiedad con Terceros", "5"));
                cblTitulares.Items.Insert(6, new ListItem("Cónyuge", "6"));
                cblTitulares.Items.Insert(7, new ListItem("Cónyuge en Copropiedad con Terceros", "7"));
                cblTitulares.Items.Insert(8, new ListItem("Concubina o Concubinario", "8"));
                cblTitulares.Items.Insert(9, new ListItem("Concubina o Concubinario en Copropiedad con Terceros", "9"));
                cblTitulares.Items.Insert(10, new ListItem("Conviviente", "10"));
                cblTitulares.Items.Insert(11, new ListItem("Declarante y Conviviente", "11"));
                cblTitulares.Items.Insert(12, new ListItem("Declarante y Conviviente en Copropiedad con Terceros", "12"));
                cblTitulares.Items.Insert(13, new ListItem("Conviviente y Dependiente Económico", "13"));
                cblTitulares.Items.Insert(14, new ListItem("Conviviente y Dependiente Económico en Copropiedad con Terceros", "14"));
                cblTitulares.Items.Insert(15, new ListItem("Dependiente Económico", "15"));
                cblTitulares.Items.Insert(16, new ListItem("Declarante y Dependiente Económico", "16"));
                cblTitulares.Items.Insert(17, new ListItem("Dependiente Económico en Copropiedad con Terceros", "17"));
                cblTitulares.Items.Insert(18, new ListItem("Declarante, Cónyuge y Dependiente Económico", "18"));
                cblTitulares.Items.Insert(19, new ListItem("Declarante, Concubina o Concubinario y Dependiente Económico", "19"));
                cblTitulares.Items.Insert(20, new ListItem("Cónyuge y Dependiente Económico", "20"));
                cblTitulares.Items.Insert(21, new ListItem("Concubina o Concubinario y Dependiente Económico", "21"));
                cblTitulares.Items.Insert(22, new ListItem("Cónyuge y Dependiente Económico en Copropiedad con Terceros", "22"));
                cblTitulares.Items.Insert(23, new ListItem("Concubina o Concubinario y Dependiente Económico en Copropiedad con Terceros", "23"));
                cblTitulares.Items.Insert(24, new ListItem("Declarante y Dependiente económico en copropiedad con terceros", "24"));
                cblTitulares.Items.Insert(cblTitulares.Items.Count, new ListItem("Copropietario", "-1"));

            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkInversiones")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkInversiones")).CssClass = "active";
        }
        protected void OnEditar(object sender, ItemEventArgs e)
        {
            mppInversion.Show(true);
            mppInversion.HeaderText = "Modificar";

            lEditar = true;
            txtF_BAJA.Text = string.Empty;
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            IndiceItemSeleccionado = e.Id;
            //blld_ALTA_INVERSION i;

            cmbNID_TIPO_INVERSION.SelectedValue = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].NID_TIPO_INVERSION.ToString();
            cmbNID_TIPO_INVERSION_SelectedIndexChanged(sender, e);
            cmbNID_SUBTIPO_INVERSION.SelectedValue = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].NID_SUBTIPO_INVERSION.ToString();

            cmbNID_PAIS.SelectedValue = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].NID_PAIS.ToString();
            cmbNID_PAIS_SelectedIndexChanged(sender, null);
            cmbCID_ENTIDAD_FEDERATIVA.SelectedValue = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].CID_ENTIDAD_FEDERATIVA;
            txtV_LUGAR.Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].V_LUGAR;

            cmbNID_INSTITUCION.SelectedValue = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].NID_INSTITUCION.ToString();
            cmbNID_INSTITUCION_SelectedIndexChanged(sender, null);
            txtV_OTRO.Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].V_OTRO != null ? oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].V_OTRO : String.Empty;

            moneytxtM_SALDO.Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].M_SALDO.ToString();
            txtE_CUENTA.Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].E_CUENTA.ToString();
            txtF_APERTURA.Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].F_APERTURA.ToString(strFormatoFecha);


            txtV_RFC.Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].V_RFC_INVERSION.ToString();
            if (txtV_RFC.Text == "0000000000000")
                txtV_RFC.Text = "";
           txtTipoMoneda.Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].V_TIPO_MONEDA.ToString();
            try { ddlTipoMonedaInm.SelectedValue = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].V_TIPO_MONEDA.ToString().Split('|')[0]; } catch { }

            try {txtF_BAJA.Text= oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].NID_PATRIMONIO).First().F_BAJA.ToString(Pagina.strFormatoFecha); } catch { }
            txtObservaciones.Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].E_OBSERVACIONES.ToString();

            cblTitulares.ClearSelection();

            //chbDependietesInm.SelectedValue = i.ALTA_INMUEBLE_TITULARs.First().NID_DEPENDIENTE.ToString();
            chbDependietesInm.SelectedValue = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].ALTA_INVERSION_TITULARs.First().NID_DEPENDIENTE.ToString();
            chbDependietesInm_SelectedIndexChanged(sender, e);

            try
            {
                blld_ALTA_INVERSION_COPROPIETARIO oCompro = new blld_ALTA_INVERSION_COPROPIETARIO(oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].VID_NOMBRE
                    , oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].VID_FECHA
                    , oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].VID_HOMOCLAVE
                    , oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].NID_DECLARACION
                    , oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].NID_INVERSION
                    , 1
                    );
                cmbTerceroInversion.SelectedValue = oCompro.CID_TIPO_PERSONA;
                txtTerceroNombre.Text = oCompro.V_NOMBRE.ToString();
                txtTerceroRFC.Text = oCompro.V_RFC.ToString();

                txtTerceroNombre.Enabled = true;
                txtTerceroRFC.Enabled = true;
            }
            catch (Exception)
            {
                cmbTerceroInversion.SelectedIndex = 0;
                txtTerceroNombre.Text = String.Empty;
                txtTerceroRFC.Text = String.Empty;
                txtTerceroNombre.Enabled = false;
                txtTerceroRFC.Enabled = false;
            }
            try
            {
                foreach (blld_ALTA_INVERSION_TITULAR item in oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].ALTA_INVERSION_TITULARs)
                {
                    cblTitulares.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            try
            {

                blld_USUARIO oUsuario = _oUsuario;
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                blld_ALTA_INVERSION o;
                o = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id];
                oDeclaracion.ALTA.ALTA_INVERSIONs.RemoveAt(e.Id);
                grd.Controls.RemoveAt(e.Id);
                //((UpdatePanel)Master.FindControl("pnlMain")).Update();
                _oDeclaracion = oDeclaracion;
                MsgBox.ShowSuccess("Se eliminó correctamente la inversión");
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

        public void Anterior()
        {
            HttpContext.Current.Items.Add("subSeccion", Bienes.SubSecciones.Vehiculos);
            Response.Redirect("Bienes.aspx");
        }
        public void Guardar()
        {

        }
        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            //if (oDeclaracion.ALTA.ALTA_INVERSIONs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
            //{ }
            //else
            //{
                marcaApartado(11);
            //}
            Response.Redirect("Adeudos.aspx");
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

        protected void btnAgregarInversion_Click(object sender, EventArgs e)
        {
            mppInversion.Show(true);
            mppInversion.HeaderText = "Inversión, cuenta bancaria y otro tipo de valores/activos";
            lEditar = false;
            txtF_BAJA.Text = string.Empty;
            cmbNID_TIPO_INVERSION.SelectedIndex = 0;
            cmbNID_TIPO_INVERSION_SelectedIndexChanged(sender, e);

            cmbNID_PAIS.SelectedIndex = 0;
            cmbNID_PAIS_SelectedIndexChanged(sender, e);
            //cmbCID_ENTIDAD_FEDERATIVA.SelectedIndex = 0;
            txtV_LUGAR.Text = String.Empty;
          //  txtF_APERTURA.Text = String.Empty;

            cmbNID_INSTITUCION.SelectedIndex = 0;
            cmbNID_INSTITUCION_SelectedIndexChanged(sender, null);
            txtV_OTRO.Text = String.Empty;
            txtV_OTRO.Visible = false;
            txtV_LUGAR.Visible = false;

            moneytxtM_SALDO.Text = String.Empty;
            txtE_CUENTA.Text = String.Empty;

            cblTitulares.ClearSelection();


            txtV_RFC.Text = String.Empty;
            txtTipoMoneda.Text = String.Empty;
            cmbTerceroInversion.SelectedIndex = 0;
            txtTerceroNombre.Text = String.Empty;
            txtTerceroRFC.Text = String.Empty;
            txtObservaciones.Text = String.Empty;

            txtTerceroNombre.Enabled = false;
            txtTerceroRFC.Enabled = false;
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mppInversion.Hide();
        }


        protected void cmbNID_TIPO_INVERSION_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((new Int32[] { 5, 8, 7 }).Contains(cmbNID_TIPO_INVERSION.SelectedValue()))
            {
                txtE_CUENTA.Text = "N/A";
                txtE_CUENTA.Enabled = false;
                cmbNID_INSTITUCION.SelectedValue = "999";
                trInstitucion.Visible = false;
            }
            else
            {
                txtE_CUENTA.Text = String.Empty;
                txtE_CUENTA.Enabled = true;
                cmbNID_INSTITUCION.SelectedIndex = 0;
                trInstitucion.Visible = true;
            }

            //blld__l_CAT_TIPO_INMUEBLE oTipoBien = new blld__l_CAT_TIPO_INMUEBLE();
            //oTipoBien.L_ACTIVO = true;
            //oTipoBien.select();


            blld__l_CAT_SUBTIPO_INVERSION oSubtipoInversion = new blld__l_CAT_SUBTIPO_INVERSION();
            oSubtipoInversion.L_ACTIVO = true;
            oSubtipoInversion.NID_TIPO_INVERSION = new Declara_V2.IntegerFilter(cmbNID_TIPO_INVERSION.SelectedValue());
            oSubtipoInversion.select();
            cmbNID_SUBTIPO_INVERSION.DataBind(oSubtipoInversion.lista_CAT_SUBTIPO_INVERSION, Declara_V2.MODELextended.CAT_SUBTIPO_INVERSION.Properties.NID_SUBTIPO_INVERSION, Declara_V2.MODELextended.CAT_SUBTIPO_INVERSION.Properties.V_SUBTIPO_INVERSION);
        }




        protected void cmbNID_PAIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbNID_PAIS.SelectedValue());
            oEntidadFederativa.select();
            cmbCID_ENTIDAD_FEDERATIVA.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, Declara_V2.MODELextended.CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            try { cmbCID_ENTIDAD_FEDERATIVA.SelectedIndex = 0; } catch { }
            //txtV_LUGAR.Visible = (cmbNID_PAIS.SelectedValue() != 1);
            //if (!txtV_LUGAR.Visible)
            //    txtV_LUGAR.Text = String.Empty;
            if(cmbNID_PAIS.SelectedValue=="1")
            { idRFC.Visible = true; txtV_RFC.Text = ""; }
            else
            { idRFC.Visible = false; txtV_RFC.Text = "0000000000000"; }
        }



        protected void btnGuarda_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                ActualizaInversion();

                //Response.Redirect("Inversiones.aspx"); //OEVM - 20220511 - Se incuye para forzar la actualizacion de la pagina y asi se visualicen los cambios realizados
            }
            else
            {
                NuevaInversion();
            }


        }
        private void NuevaInversion()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            blld_ALTA_INVERSION o;
            cblTitulares.SelectedValue = chbDependietesInm.SelectedValue;
            try
            {
                List<Int32> ListaTitulares = new List<int>();
                try
                {
                    foreach (Int32 x in cblTitulares.SelectedValuesInteger())
                    {
                        ListaTitulares.Add(x);
                    }
                }
                catch { }

                if (oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE != txtV_RFC.Text.ToUpper())
                {
                    oDeclaracion.ALTA.Add_ALTA_INVERSIONs(cmbNID_TIPO_INVERSION.SelectedValue()
                                                      , cmbNID_SUBTIPO_INVERSION.SelectedValue()
                                                      , cmbNID_INSTITUCION.SelectedValue()
                                                      , txtE_CUENTA.Text
                                                      , String.Empty
                                                      , moneytxtM_SALDO.Money()
                                                      , cmbNID_PAIS.SelectedValue()
                                                      , cmbCID_ENTIDAD_FEDERATIVA.SelectedValue
                                                      , txtV_LUGAR.Text
                                                      , txtF_APERTURA.Date(esMX)
                                                      , txtV_RFC.Text
                                                      , txtTipoMoneda.Text
                                                      , cmbTerceroInversion.SelectedValue
                                                      , txtTerceroNombre.Text
                                                      , txtTerceroRFC.Text
                                                      , txtObservaciones.Text
                                                      , ListaTitulares
                                                      );
                    _oDeclaracion = oDeclaracion;
                    marcaApartado(11);
                    o = oDeclaracion.ALTA.ALTA_INVERSIONs.Last();

                    if (txtF_BAJA.Text.Length > 8)
                        oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(o.NID_PATRIMONIO, 1, txtF_BAJA.Date(Pagina.esMX));

                    int x1 = grd.Controls.Count - 3;
                    UserControl item = (UserControl)Page.LoadControl("ItemBaja.ascx");
                    ((ItemBaja)item).Id = oDeclaracion.ALTA.ALTA_INVERSIONs.Count + 1;
                    ((ItemBaja)item).TextoPrincipal = cmbNID_TIPO_INVERSION.SelectedItem.Text + "<br>" + cmbNID_SUBTIPO_INVERSION.SelectedItem.Text;
                    ((ItemBaja)item).TextoSecundario = "<br>No. Cuenta :" + txtE_CUENTA.Text + "<br> Saldo : " + moneytxtM_SALDO.Money().ToString("C");
                    ((ItemBaja)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INVERSION/", cmbNID_TIPO_INVERSION.SelectedValue, ".png");
                    ((ItemBaja)item).Editar += OnEditar;
                    ((ItemBaja)item).Eliminar += OnEliminar;
                    ((ItemBaja)item).Bajar += OnBaja;
                    if (o.F_APERTURA < String.Concat("01/01/", Convert.ToString(System.DateTime.Today.Year - 1)).Date())
                    {
                        ((Button)((ItemBaja)item).FindControl("btnEliminar")).Visible = false;
                        ((Button)((ItemBaja)item).FindControl("btnBaja")).Visible = true;
                    }

                    if (o.F_APERTURA > String.Concat("01/01/", Convert.ToString(System.DateTime.Today.Year - 1)).Date())
                    {
                        ((Button)((ItemBaja)item).FindControl("btnEliminar")).Visible = true;
                        ((Button)((ItemBaja)item).FindControl("btnBaja")).Visible = false;
                    }
                    grd.Controls.AddAt(x1, item);
                    mppInversion.Hide();
                    marcaApartado(11);
                    MsgBox.ShowSuccess("Se agregó correctamente la inversión");
                }
                else
                {
                    MsgBox.ShowDanger("Advertencia", "El RFC del otorgante NO puede ser el mismo del declarante");
                }
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
        private void ActualizaInversion()
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            cblTitulares.SelectedValue = chbDependietesInm.SelectedValue;
            if (oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE != txtV_RFC.Text.ToUpper())
            {
                try
                {

                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].NID_TIPO_INVERSION = cmbNID_TIPO_INVERSION.SelectedValue();
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].NID_SUBTIPO_INVERSION = cmbNID_SUBTIPO_INVERSION.SelectedValue();
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].NID_INSTITUCION = cmbNID_INSTITUCION.SelectedValue();
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].E_CUENTA = txtE_CUENTA.Text;
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].V_OTRO = txtV_OTRO.Text;
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].M_SALDO = moneytxtM_SALDO.Money();
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].NID_PAIS = cmbNID_PAIS.SelectedValue();
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].CID_ENTIDAD_FEDERATIVA = cmbCID_ENTIDAD_FEDERATIVA.SelectedValue;
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].V_LUGAR = txtV_LUGAR.Text;
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].F_APERTURA = txtF_APERTURA.Date(esMX);
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].V_RFC_INVERSION = txtV_RFC.Text;  //OEVM20200723
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].V_TIPO_MONEDA = txtTipoMoneda.Text;
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].E_OBSERVACIONES = txtObservaciones.Text;
                    oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].update(cblTitulares.SelectedValuesInteger(), cmbTerceroInversion.SelectedValue, txtTerceroNombre.Text, txtTerceroRFC.Text);

                    EliminaF_baja(oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].NID_PATRIMONIO.ToString());
                    if (txtF_BAJA.Text.Length > 8)
                        oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].NID_PATRIMONIO, 1, txtF_BAJA.Date(Pagina.esMX));

                    mppInversion.Hide();
                    MsgBox.ShowSuccess("Se actualizaron correctamente los datos de la inversión");
                    _oDeclaracion = oDeclaracion;

                    //OEVM para actualizar pantalla despues de la actualizacion

                    Response.Redirect("Inversiones.aspx");

                    
                    //OEVM todo lo de arriba hasta el otro comentario se agrego para ver si actualiza los datos despues de la edicion OEVM 20220530
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
            else
            {
                MsgBox.ShowDanger("Advertencia", "El RFC del otorgante NO puede ser el mismo del declarante");
                
            }


        }

        protected void cmbNID_INSTITUCION_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNID_INSTITUCION.SelectedValue == "999")
            {
                txtV_OTRO.Visible = true;

            }
            else
            {
                txtV_OTRO.Visible = false;
                txtV_OTRO.Text = String.Empty;
            }

        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            marcaApartado(11);
            Response.Redirect("Adeudos.aspx");
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }

        protected void cmbTerceroInversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTerceroRFC.Text = string.Empty; ;

            if (cmbTerceroInversion.SelectedValue != "")
            {
                txtTerceroNombre.Enabled = true;
                txtTerceroRFC.Enabled = true;

                if (cmbTerceroInversion.SelectedValue == "F")
                    txtTerceroRFC.MaxLength = 13;

                if (cmbTerceroInversion.SelectedValue == "M")
                    txtTerceroRFC.MaxLength = 12;
            }
            else
            {
                txtTerceroNombre.Enabled = false;
                txtTerceroRFC.Enabled = false;

                txtTerceroNombre.Text = string.Empty;
            }
        }

        //  ************************** Dar de baja datos *********************
        protected void OnBaja(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            Int32 nid;
            nid = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].NID_PATRIMONIO;
           
            if (oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == nid).Any())
                ctrlDesincorpora1.llena(nid);
            else
            {
                ctrlDesincorpora1.NID_PATRIMONIO = nid;
                ctrlDesincorpora1.limpia();
            }

        }

        protected void btnCerrarBaja_Click(object sender, EventArgs e)
        {
            mppBaja.Hide();
        }

        protected void btnGuardarBaja_Click(object sender, EventArgs e)
        {
            ctrlDesincorpora1.Guarda();
            mppBaja.Hide();
            MsgBox.ShowSuccess("Se guardó exitosamenta la baja del bien patrimonial");
        }
        protected void btnEliminarBaja_Click(object sender, EventArgs e)
        {
            ctrlDesincorpora1.Elimina();
            mppBaja.Hide();
            MsgBox.ShowSuccess("Se eliminó exitosamenta la baja del bien patrimonial");
        }

        public void EliminaF_baja(string Patrimonio)
        {
            try
            {
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Remove(oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == Convert.ToInt32(Patrimonio)).First());
                _oDeclaracion = oDeclaracion;
            }
            catch { }
        }

        protected void chbDependietesInm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Paso = chbDependietesInm.SelectedItem.Text;
            Int32 Contenido = Paso.IndexOf("Terceros");
            if (Contenido > 0)
            {
                cmbTerceroInversion.Enabled = true;
                txtTerceroNombre.Enabled = true;
                txtTerceroRFC.Enabled = true;
            }
            else
            {
                cmbTerceroInversion.Enabled = false;
                txtTerceroNombre.Enabled = false;
                txtTerceroRFC.Enabled = false;
            }
        }
        protected void ddlTipoMonedaInm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoMoneda.Text = ddlTipoMonedaInm.SelectedValue.ToString() + '|' + ddlTipoMonedaInm.SelectedItem.Text;
        }
    }
}