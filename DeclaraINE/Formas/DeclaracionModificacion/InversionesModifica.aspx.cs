using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;
using System.Data;
using Declara_V2.BLL;


namespace DeclaraINAI.Formas.DeclaracionModificacion
{
    public partial class InversionesModifica : Pagina, IDeclaracionInicial
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
 
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liInversiones")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu3")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                //OEVM
                if (oDeclaracion.ALTA.ALTA_INVERSIONs.Count == 0 && oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                  //  QstBox.Ask("¿Cuenta con inversiones en alguna institución financiera, en especie o en efectivo?");
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";

                cmbNID_TIPO_INVERSION.DataBinder<blld__l_CAT_TIPO_INVERSION>(new blld__l_CAT_TIPO_INVERSION(), CAT_TIPO_INVERSION.Properties.NID_TIPO_INVERSION, CAT_TIPO_INVERSION.Properties.V_TIPO_INVERSION, false);
                cmbNID_TIPO_INVERSION.Items.Insert(0, new ListItem(String.Empty));
                cmbNID_TIPO_INVERSION_SelectedIndexChanged(sender, e);

                cmbNID_PAIS.DataBinder<blld__l_CAT_PAIS>(new blld__l_CAT_PAIS(), CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbNID_PAIS.Items.Insert(0, new ListItem(String.Empty));
                cmbNID_PAIS_SelectedIndexChanged(sender, e);

                blld__l_CAT_INST_FINANCIERA oInstitucion = new blld__l_CAT_INST_FINANCIERA();
                oInstitucion.OrderByCriterios.Add(new Order(CAT_INST_FINANCIERA.Properties.V_INSTITUCION));
                oInstitucion.select();
                cmbNID_INSTITUCION.DataBind(oInstitucion.lista_CAT_INST_FINANCIERA, CAT_INST_FINANCIERA.Properties.NID_INSTITUCION, CAT_INST_FINANCIERA.Properties.V_INSTITUCION, false);
                cmbNID_INSTITUCION.Items.Insert(0, new ListItem(String.Empty));
                cmbNID_INSTITUCION_SelectedIndexChanged(sender, e);

                cblTitulares.DataBind(oDeclaracion.DECLARACION_DEPENDIENTESs, DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE, DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO);
                cblTitulares.Items.Insert(0, new ListItem("Declarante", "0"));
                cblTitulares.Items.Insert(cblTitulares.Items.Count, new ListItem("Copropietario", "-1"));

                cblTitularesMod.DataBind(oDeclaracion.DECLARACION_DEPENDIENTESs, DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE, DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO);
                cblTitularesMod.Items.Insert(0, new ListItem("Declarante", "0"));
                cblTitularesMod.Items.Insert(cblTitularesMod.Items.Count, new ListItem("Copropietario", "-1"));

                txtF_APERTURA_C.StartDate = new DateTime(1900, 1, 1);
                txtF_APERTURA_C.EndDate = DateTime.Today.AddDays(-1);
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 24).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkInversionesAct")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkInversionesAct")).CssClass = "active";

            blld_USUARIO oUsuario = _oUsuario;

            if (!oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs.Any())
            {
                SinInversionesBR.Visible = true;
                SinInversiones.ShowDanger("No existe ninguna inversión vigente que haya sido dada de alta en declaraciones anteriores");
            }

            for (Int32 x = 0; x < oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs.Count; x++)
            {
                UserControl item = (UserControl)Page.LoadControl("ItemInv.ascx");
                ((ItemInv)item).Id = x;
                ((ItemInv)item).ID = "itemx_" + x.ToString();
                ((ItemInv)item).Keys = "Mod";
                ((ItemInv)item).TextoPrincipal = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[x].PATRIMONIO.PATRIMONIO_INVERSION.V_SUBTIPO_INVERSION;
                ((ItemInv)item).TextoSecundario = "Número de Cuenta " + oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[x].PATRIMONIO.PATRIMONIO_INVERSION.E_CUENTA
                                           + "<br> Saldo Anterior  " + oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[x].M_SALDO_ANTERIOR.ToString("C")
                                           + "<br> Saldo Actual  " + oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[x].M_SALDO_ACTUAL.ToString("C");
                                           //+ "<br> Diferencia " + oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[x].M_DIFERENCIA.ToString("C");
                ((ItemInv)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INVERSION/", oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[x].PATRIMONIO.PATRIMONIO_INVERSION.NID_TIPO_INVERSION, ".png");
                if (oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[x].L_MODIFICADA) ((Button)((ItemInv)item).FindControl("btnEditar")).CssClass = "ok";
                ((ItemInv)item).Editar += OnEditar;
                grdMod.Controls.AddAt(0 + x, item);
            }

            blld_ALTA_INVERSION o;
            for (int x = 0; x < oDeclaracion.ALTA.ALTA_INVERSIONs.Count; x++)
            {
                o = oDeclaracion.ALTA.ALTA_INVERSIONs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).FindControl("btnBaja").Visible = false;
                ((Item)item).ID = "item_" + x.ToString();
                ((Item)item).Id = x;
                ((Item)item).Keys = "Inv";
                ((Item)item).TextoPrincipal = o.V_TIPO_INVERSION + "<br>" + o.V_SUBTIPO_INVERSION;
                ((Item)item).TextoSecundario = "<br>No. Cuenta :" + o.E_CUENTA + "<br> Saldo : " + o.M_SALDO.ToString("C"); ;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INVERSION/", o.NID_TIPO_INVERSION, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grd.Controls.AddAt(0 + x, item);


            }


        }
        protected void OnEditar(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            switch (e.Keys)
            {
                case "Inv":

                    mppInversion.Show(true);

                    lEditar = true;

                    IndiceItemSeleccionado = e.Id;

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

                    cblTitulares.ClearSelection();

                    foreach (blld_ALTA_INVERSION_TITULAR item in oDeclaracion.ALTA.ALTA_INVERSIONs[e.Id].ALTA_INVERSION_TITULARs)
                    {
                        cblTitulares.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
                    break;

                case "Mod":
                    mppInversionMod.Show(true);

                    lEditar = true;

                    IndiceItemSeleccionado = e.Id;

                    cbx.CheckedNullable = !oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].L_CANCELADA;
                    moneytxtM_SALDO_ANTERIOR.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].M_SALDO_ANTERIOR.ToString("C");
                    moneytxtM_SALDO_ANTERIOR.Enabled = false;
                    moneytxtM_SALDO_ACTUAL_MOD.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].M_SALDO_ACTUAL.ToString("C");
                    txtTipoInversion.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].PATRIMONIO.PATRIMONIO_INVERSION.V_TIPO_INVERSION;
                    txtSubtipoInversion.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].PATRIMONIO.PATRIMONIO_INVERSION.V_SUBTIPO_INVERSION;
                    txtPais.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].PATRIMONIO.PATRIMONIO_INVERSION.V_PAIS;
                    txtEntidadFederativa.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].PATRIMONIO.PATRIMONIO_INVERSION.V_ENTIDAD_FEDERATIVA;
                    txtInstitucion.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].PATRIMONIO.PATRIMONIO_INVERSION.V_INSTITUCION;
                    txtCuenta.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].PATRIMONIO.PATRIMONIO_INVERSION.E_CUENTA;
                    //txtFecha.Text = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].PATRIMONIO.PATRIMONIO_INVERSION.F_APERTURA;
                    cblTitularesMod.ClearSelection();

                    foreach (blld_MODIFICACION_INVERSION_TITU item in oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Id].MODIFICACION_INVERSION_TITUs)
                    {
                        cblTitularesMod.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
                    break;
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
                AlertaSuperior.ShowSuccess("Se eliminó correctamente la inversión");
            }
            catch (Exception ex)
            {
                if (ex.InnerException is CustomException)
                {
                    MsgBox.ShowDanger(ex.InnerException.Message);
                }
                else
                {
                    if (ex is CustomException)
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
            Response.Redirect("ModificaVehiculos.aspx");
        }
        public void Guardar()
        {

        }
        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.ALTA.ALTA_INVERSIONs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
            { }
            else
            {
                marcaApartado(24);
            }
            Response.Redirect("AdeudosModifica.aspx");
        }

        private void marcaApartado(int NID_APARTADO)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs.Where(p => p.L_MODIFICADA == false).Any())
            { }
            else
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

                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 24 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
                {
                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                    {
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO = true;
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().update();
                    }
                }
                _oDeclaracion = oDeclaracion;
            }
        }

        protected void btnAgregarInversion_Click(object sender, EventArgs e)
        {
            mppInversion.Show(true);
            lEditar = false;

            cmbNID_TIPO_INVERSION.SelectedIndex = 0;
            cmbNID_TIPO_INVERSION_SelectedIndexChanged(sender, e);
            cmbNID_SUBTIPO_INVERSION.Items.Insert(0, new ListItem(String.Empty));
            cmbNID_SUBTIPO_INVERSION.SelectedIndex = 0;

            cmbNID_PAIS.SelectedIndex = 0;
            cmbNID_PAIS_SelectedIndexChanged(sender, null);
            cmbCID_ENTIDAD_FEDERATIVA.Items.Insert(0, new ListItem(String.Empty));
            cmbCID_ENTIDAD_FEDERATIVA.SelectedIndex = 0;
            txtV_LUGAR.Text = String.Empty;
            txtF_APERTURA.Text = String.Empty;
            cbx.CheckedNullable = null;

            cmbNID_INSTITUCION.SelectedIndex = 0;
            cmbNID_INSTITUCION_SelectedIndexChanged(sender, null);
            txtV_OTRO.Text = String.Empty;

            moneytxtM_SALDO.Text = String.Empty;
            txtE_CUENTA.Text = String.Empty;

            cblTitulares.ClearSelection();

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
            blld__l_CAT_SUBTIPO_INVERSION oSubtipoInversion = new blld__l_CAT_SUBTIPO_INVERSION();
            oSubtipoInversion.NID_TIPO_INVERSION = new Declara_V2.IntegerFilter(cmbNID_TIPO_INVERSION.SelectedValue());
            oSubtipoInversion.select();
            cmbNID_SUBTIPO_INVERSION.DataBind(oSubtipoInversion.lista_CAT_SUBTIPO_INVERSION, CAT_SUBTIPO_INVERSION.Properties.NID_SUBTIPO_INVERSION, CAT_SUBTIPO_INVERSION.Properties.V_SUBTIPO_INVERSION);
        }




        protected void cmbNID_PAIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbNID_PAIS.SelectedValue());
            oEntidadFederativa.select();
            cmbCID_ENTIDAD_FEDERATIVA.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            txtV_LUGAR.Visible = (cmbNID_PAIS.SelectedValue() > 1);
            if (!txtV_LUGAR.Visible)
                txtV_LUGAR.Text = String.Empty;
        }



        protected void btnGuardaInv_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                ActualizaInversion();
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

                //oDeclaracion.ALTA.Add_ALTA_INVERSIONs(cmbNID_TIPO_INVERSION.SelectedValue()
                //                                      , cmbNID_SUBTIPO_INVERSION.SelectedValue()
                //                                      , cmbNID_INSTITUCION.SelectedValue()
                //                                      , txtE_CUENTA.Text
                //                                      , String.Empty
                //                                      , moneytxtM_SALDO.Money()
                //                                      , cmbNID_PAIS.SelectedValue()
                //                                      , cmbCID_ENTIDAD_FEDERATIVA.SelectedValue
                //                                      , txtV_LUGAR.Text
                //                                      , txtF_APERTURA.Date(esMX)
                //                                      , ListaTitulares
                //                                      );
                //_oDeclaracion = oDeclaracion;
                marcaApartado(24);
                int x1 = grd.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).FindControl("btnBaja").Visible = false;
                ((Item)item).Id = _oDeclaracion.ALTA.ALTA_INVERSIONs.Count + 1;
                ((Item)item).Keys = "Inv";
                ((Item)item).TextoPrincipal = cmbNID_TIPO_INVERSION.SelectedItem.Text + "<br>" + cmbNID_SUBTIPO_INVERSION.SelectedItem.Text;
                ((Item)item).TextoSecundario = "<br>Número Cuenta " + txtE_CUENTA.Text 
                                             + "<br> Saldo " + moneytxtM_SALDO.Money().ToString("C");
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INVERSION/", cmbNID_TIPO_INVERSION.SelectedValue, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grd.Controls.AddAt(x1, item);
                mppInversion.Hide();

                AlertaSuperior.ShowSuccess("Se agregó correctamente la inversión");
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
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
                oDeclaracion.ALTA.ALTA_INVERSIONs[Indice].update(cblTitulares.SelectedValuesInteger());
        

                ((Item)grd.FindControl( "item_" + Indice.ToString())).TextoSecundario = "<br>Número de Cuenta " + txtE_CUENTA.Text + "<br> Saldo " + moneytxtM_SALDO.Money().ToString("C");


                _oDeclaracion = oDeclaracion;
                mppInversion.Hide();
                AlertaSuperior.ShowSuccess("Se actualizaron correctamente los datos de la inversión");
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {



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
            marcaApartado(24);
            Response.Redirect("AdeudosModifica.aspx");
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }








        protected void btnCerrarMod_Click(object sender, EventArgs e)
        {
            mppInversionMod.Hide();
        }


        protected void btnGuardaMod_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;

            try
            {
                oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[Indice].L_CANCELADA = !cbx.Checked;
                //oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[Indice].M_SALDO_ANTERIOR = moneytxtM_SALDO_ANTERIOR.Money();
                oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[Indice].M_SALDO_ACTUAL = moneytxtM_SALDO_ACTUAL_MOD.Money();

                oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[Indice].update(cblTitularesMod.SelectedValuesInteger());

                AlertaSuperiorMod.ShowSuccess("Se actualizaron correctamente los datos de la inversión");
                mppInversionMod.Hide();
                ((ItemInv)grdMod.FindControl("itemx_" + Indice.ToString())).TextoSecundario = "Número de Cuenta " + oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[Indice].PATRIMONIO.PATRIMONIO_INVERSION.E_CUENTA
                                            + "<br> Saldo Anterior " + oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[Indice].M_SALDO_ANTERIOR.ToString("C")
                                            + "<br> Saldo Actual " + oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[Indice].M_SALDO_ACTUAL.ToString("C");
                                            //+ "<br> Diferencia " + oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[Indice].M_DIFERENCIA.ToString("C");
                ((Button)((ItemInv)grdMod.FindControl("itemx_" + Indice.ToString())).FindControl("btnEditar")).CssClass = "ok";
                _oDeclaracion = oDeclaracion;
                marcaApartado(24);
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








    }
}