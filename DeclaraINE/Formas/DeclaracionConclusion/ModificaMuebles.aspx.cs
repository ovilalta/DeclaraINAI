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
    public partial class ModificaMuebles : Pagina, IDeclaracionInicial
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
        internal Boolean lEditarN
        {
            get => (Boolean)ViewState["lEditarN"];
            set => ViewState["lEditarN"] = value;

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
        internal Int32 IndiceSeleccionadoN
        {
            get
            {
                if (ViewState["IndiceSeleccionadoN"] == null) return -1;
                return (Int32)ViewState["IndiceSeleccionadoN"];
            }

            set
            {
                if (ViewState["IndiceSeleccionadoN"] == null) ViewState.Add("IndiceSeleccionadoN", value);
                ViewState["IndiceSeleccionadoN"] = value;
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liBienes")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu2")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                    QstBox.Ask("¿Cuenta con Bienes Muebles que desee dar de alta?");
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
                blld__l_CAT_TIPO_MUEBLE oTipoMueble = new blld__l_CAT_TIPO_MUEBLE();
                oTipoMueble.select();
                dpTipoBienMueble.DataBind(oTipoMueble.lista_CAT_TIPO_MUEBLE, CAT_TIPO_MUEBLE.Properties.NID_TIPO, CAT_TIPO_MUEBLE.Properties.V_TIPO);
                //Dependientes
                chbDependietesMuebles.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietesMuebles.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietesMuebles.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietesMuebles.DataBind();
                chbDependietesMuebles.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietesMuebles.Items.Insert(chbDependietesMuebles.Items.Count, new ListItem("Copropietario", "-1"));
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkBienesMueblesAct")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkBienesMueblesAct")).CssClass = "active";
        }

        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            PagMuebles();
            PagMueblesN();
        }
    private void PagMueblesN()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            if (!IsPostBack)
            {
                //---------------Muebles
                //cmbTipoBien
                blld__l_CAT_TIPO_MUEBLE oTipoMueble = new blld__l_CAT_TIPO_MUEBLE();
                oTipoMueble.L_ACTIVO = true;
                oTipoMueble.select();
                dpTipoBienMuebleN.DataBind(oTipoMueble.lista_CAT_TIPO_MUEBLE, CAT_TIPO_MUEBLE.Properties.NID_TIPO, CAT_TIPO_MUEBLE.Properties.V_TIPO);
                dpTipoBienMuebleN.Items.Insert(0, new ListItem(String.Empty));
                //Dependientes
                chbDependietesMueblesN.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietesMueblesN.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietesMueblesN.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietesMueblesN.DataBind();
                chbDependietesMueblesN.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietesMueblesN.Items.Insert(chbDependietesMueblesN.Items.Count, new ListItem("Copropietario", "-1"));

            }
            //PANEL
            blld_ALTA_MUEBLE b;
            for (int x = 0; x < oDeclaracion.ALTA.ALTA_MUEBLEs.Count(); x++)
            {
                b = oDeclaracion.ALTA.ALTA_MUEBLEs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("Mueble_", x);
                ((Item)item).TextoPrincipal = b.V_TIPO;
                ((Item)item).TextoSecundario = b.E_ESPECIFICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_MUEBLE/", b.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditarN;
                ((Item)item).Eliminar += OnEliminarN;
                ((Item)item).Bajar += OnBajaN;
                grdMueble.Controls.AddAt(0 + x, item);
            }
        }
    private void PagMuebles()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_MODIFICACION_MUEBLE o;
            for (int x = 0; x < oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs.Count; x++)
            {
                o = oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs[x];
                UserControl item = (UserControl)Page.LoadControl("Item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = "MuebleMod" + x;
                ((Item)item).TextoPrincipal = o.V_TIPO;
                ((Item)item).TextoSecundario = o.E_ESPECIFICACION;
                ((Button)((Item)item).FindControl("btnEliminar")).Visible = false;
                //((Button)((ItemAct)item).FindControl("btnEliminar")).Text = "Gastos";
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_MUEBLE/", o.NID_TIPO, ".png");
                if (o.L_MODIFICADO) ((Button)((Item)item).FindControl("btnEditar")).CssClass = "ok";
                ((Item)item).Editar += OnEditar;
                ((Item)item).Bajar += OnBaja;
                grd.Controls.AddAt(0 + x, item);
            }

            if (!oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs.Any())
            {
                SinMueblesBR.Visible = true;
                SinMuebles.ShowDanger("No existe ningun bien mueble que haya sido dada de alta en declaraciones anteriores");
            }
        }
    public void Anterior()
        {
            Response.Redirect("ModificaInmuebles.aspx");
        }
        public void Siguiente()
        {
            Response.Redirect("ModificaVehiculos.aspx");
        }

        private void marcaApartado(ref blld_DECLARACION oDeclaracion, int NID_APARTADO)
        {
            if (oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs.Where(p => p.L_MODIFICADO == false).Any()) { }
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

                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 18, 19, 20 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
                {
                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO.Value)
                    {
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO = true;
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().update();
                    }
                }
            }
        }
        protected void OnEditar(object sender, ItemEventArgs e)
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_MODIFICACION_MUEBLE m;
            lEditar = true;
            mppMuebles.HeaderText = "Editar mueble";
            mppMuebles.Show(true);
            m = oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs[e.Id];
            IndiceItemSeleccionado = e.Id;

            dpTipoBienMueble.SelectedValue = m.NID_TIPO.ToString();
            txtEspecifica.Text = m.E_ESPECIFICACION.ToString();
            moneytxtValorAdqusicionMueble.Text = m.M_VALOR.ToString();
            chbDependietesMuebles.ClearSelection();
            foreach ( blld_MODIFICACION_MUEBLE_TITULAR item in m.MODIFICACION_MUEBLE_TITULARs)
            {
                
                chbDependietesMuebles.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
            }
        }
        protected void btnCerrarMueble_Click(object sender, EventArgs e)
        {
            mppMuebles.Hide();
        }
       
        protected void btnGuardarMueble_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarMueble();
                String msg = "Se actualizaron correctamente los datos del bien";
                AlertaSuperior.ShowSuccess(msg);
            }
            
        }
        private void EditarMueble()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceItemSeleccionado;
            try
            {
                oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs[Indice].NID_TIPO = dpTipoBienMueble.SelectedValue();
                oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs[Indice].E_ESPECIFICACION = txtEspecifica.Text;
                oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs[Indice].M_VALOR = moneytxtValorAdqusicionMueble.Money();
                oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs[Indice].update(chbDependietesMuebles.SelectedValuesInteger());
                ((Button)((Item)grd.FindControl("MuebleMod" + Indice.ToString())).FindControl("btnEditar")).CssClass = "ok";
                marcaApartado(ref oDeclaracion, 19);
                mppMuebles.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            _oDeclaracion = oDeclaracion;
        }

        protected void OnBaja(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            Int32 nid = oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs[e.Id].NID_PATRIMONIO;

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
            AlertaSuperior.ShowSuccess("Se guardó exitosamenta la baja del bien patrimonial");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 19);
            _oDeclaracion = oDeclaracion;
        }

        protected void btnEliminarBaja_Click(object sender, EventArgs e)
        {
            ctrlDesincorpora1.Elimina();
            mppBaja.Hide();
            AlertaSuperior.ShowSuccess("Se eliminó exitosamenta la baja del bien patrimonial");
        }

        protected void btnAgregarMueble_Click(object sender, EventArgs e)
        {
            mppMueblesN.HeaderText = "Agregar mueble";
            mppMueblesN.Show(true);

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            lEditarN = false;
            txtEspecificaN.Text = String.Empty;
            txtF_ADQUISICIONN.Text = String.Empty;
            moneytxtValorAdqusicionMuebleN.Text = String.Empty;
            chbDependietesMueblesN.ClearSelection();
        }

        protected void btnGuardarMuebleN_Click(object sender, EventArgs e)
        {
            if (lEditarN)
            {
                EditarMuebleN();
                String msg = "Se actualizaron correctamente los datos del bien";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarMuebleN();
                String msg = "Se agregó correctamente el bien";
                AlertaSuperior.ShowSuccess(msg);
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                marcaApartado(ref oDeclaracion, 19);
                _oDeclaracion = oDeclaracion;
            }
        }
        private void EditarMuebleN()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceSeleccionadoN;
            try
            {
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].NID_TIPO = dpTipoBienMuebleN.SelectedValue();
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].E_ESPECIFICACION = txtEspecificaN.Text;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].M_VALOR = moneytxtValorAdqusicionMuebleN.Money();
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].F_ADQUISICION = txtF_ADQUISICIONN.Date(esMX);
                //oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].update(chbDependietesMueblesN.SelectedValuesInteger());
                mppMueblesN.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            _oDeclaracion = oDeclaracion;
        }

        private void GuardarMuebleN()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_MUEBLE o;
            try
            {
                //oDeclaracion.ALTA.Add_ALTA_MUEBLEs(
                //                                  dpTipoBienMuebleN.SelectedValue()
                //                                , txtEspecificaN.Text
                //                                , moneytxtValorAdqusicionMuebleN.Money()
                //                                , false
                //                                , txtF_ADQUISICIONN.Date(esMX)
                //                                , chbDependietesMueblesN.SelectedValuesInteger());

                marcaApartado(ref oDeclaracion,19);
                o = oDeclaracion.ALTA.ALTA_MUEBLEs.Last();

                int x = grdMueble.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("Mueble_", x);
                ((Item)item).TextoPrincipal = o.V_TIPO;
                ((Item)item).TextoSecundario = o.E_ESPECIFICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_MUEBLE/", o.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditarN;
                ((Item)item).Eliminar += OnEliminarN;
                ((Item)item).Bajar += OnBajaN;
                grdMueble.Controls.AddAt(x, item);

                mppMueblesN.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }

            _oDeclaracion = oDeclaracion;
        }


        protected void OnEditarN(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_MUEBLE m;
            lEditarN = true;
            mppMueblesN.HeaderText = "Editar mueble";
            mppMueblesN.Show(true);
            m = oDeclaracion.ALTA.ALTA_MUEBLEs[e.Id];
            IndiceSeleccionadoN = e.Id;
            dpTipoBienMuebleN.SelectedValue = m.NID_TIPO.ToString();
            txtEspecificaN.Text = m.E_ESPECIFICACION.ToString();
            moneytxtValorAdqusicionMuebleN.Text = m.M_VALOR.ToString();
            txtF_ADQUISICIONN.Text = m.F_ADQUISICION.ToString(strFormatoFecha);
            chbDependietesMueblesN.ClearSelection();
            foreach (blld_ALTA_MUEBLE_TITULAR item in m.ALTA_MUEBLE_TITULARs)
                    {
                        chbDependietesMueblesN.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
        }
        protected void OnEliminarN(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

                    try
                    {
                        blld_ALTA_MUEBLE m;
                        oDeclaracion.ALTA.ALTA_MUEBLEs.RemoveAt(e.Id);
                        _oDeclaracion = oDeclaracion;
                        grdMueble.Controls.Remove(grdMueble.FindControl(String.Concat("Mueble_", e.Id)));
                        AlertaSuperior.ShowSuccess("Se eliminó correctamente el bien mueble");
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
        protected void OnBajaN(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            Int32 nid;
            nid = oDeclaracion.ALTA.ALTA_MUEBLEs[e.Id].NID_PATRIMONIO;
            if (oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == nid).Any())
                ctrlDesincorpora1.llena(nid);
            else
            {
                ctrlDesincorpora1.NID_PATRIMONIO = nid;
                ctrlDesincorpora1.limpia();
            }

        }
        protected void btnCerrarMuebleN_Click(object sender, EventArgs e)
        {
            mppMueblesN.Hide();
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 19);
            _oDeclaracion = oDeclaracion;
        }
        //protected void btnGuardarMuebleN_Click(object sender, EventArgs e)
        //{
        //    if (lEditar)
        //    {
        //        EditarMueble();
        //        String msg = "Se actualizaron correctamente los datos del bien";
        //        AlertaSuperior.ShowSuccess(msg);
        //    }
        //    else
        //    {
        //        GuardarMueble();
        //        String msg = "Se agregó correctamente el bien";
        //        AlertaSuperior.ShowSuccess(msg);
        //    }
        //}
    }
}