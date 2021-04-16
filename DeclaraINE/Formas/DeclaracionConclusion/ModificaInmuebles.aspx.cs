﻿using System;
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
using System.Data;
using Declara_V2.BLL;

namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class ModificaInmuebles : Pagina, IDeclaracionInicial
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
        internal Int32 IndiceAdeudoSeleccionado
        {
            get
            {
                if (ViewState["IndiceAdeudoSeleccionado"] == null) return -1;
                return (Int32)ViewState["IndiceAdeudoSeleccionado"];
            }

            set
            {
                if (ViewState["IndiceAdeudoSeleccionado"] == null) ViewState.Add("IndiceAdeudoSeleccionado", value);
                ViewState["IndiceAdeudoSeleccionado"] = value;
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
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";

                if (oDeclaracion.ALTA.ALTA_INMUEBLEs.Count == 0 && oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                    QstBox.Ask("¿Cuenta con Inmuebles que desee dar de alta?");
                // Adicionado para Inmuebles UHM
                //---------------Inmuebles
                blld__l_CAT_TIPO_INMUEBLE oTipoBien = new blld__l_CAT_TIPO_INMUEBLE();
                oTipoBien.select();
                cmbTipoBien.DataBind(oTipoBien.lista_CAT_TIPO_INMUEBLE, CAT_TIPO_INMUEBLE.Properties.NID_TIPO, CAT_TIPO_INMUEBLE.Properties.V_TIPO);
               
                //tipo uso
                blld__l_CAT_USO_INMUEBLE oTipoUso = new blld__l_CAT_USO_INMUEBLE();
                oTipoUso.select();
                cmbTipoUso.DataBind(oTipoUso.lista_CAT_USO_INMUEBLE, CAT_USO_INMUEBLE.Properties.NID_USO, CAT_USO_INMUEBLE.Properties.V_USO);
               
                //Dependientes
                chbDependietes.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietes.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietes.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietes.DataBind();
                chbDependietes.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietes.Items.Insert(chbDependietes.Items.Count, new ListItem("Copropietario", "-1"));
                // Fin de adicionado Inmuebles UHM

            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkBienesInmueblesAct")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkBienesInmueblesAct")).CssClass = "active";
        }
        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            PagInmuebles();
            PagGasto();
            PagInmueblesN();
        }

        private void PagGasto()
        {
            ((Button)Master.FindControl("dummy")).Enabled = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                ctrlGastos1.NID_TIPO_GASTO.Add(3);
                ctrlGastos1.V_GASTO_DEFAULT = "Reparación";
                ctrlGastos1.OPCIONES = new List<string>();
                ctrlGastos1.OPCIONES.Add("Reparación");
                ctrlGastos1.OPCIONES.Add("Remodelación");
            }
        }
        private void PagInmuebles()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_MODIFICACION_INMUEBLE o;
            for (int x = 0; x < oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs.Count; x++)
            {
                o = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[x];
                UserControl item = (UserControl)Page.LoadControl("ItemAct.ascx");
                ((ItemAct)item).Id = x;
                ((ItemAct)item).ID = "ModInmu" + x.ToString() ;
                ((ItemAct)item).TextoPrincipal = o.V_TIPO;
                ((ItemAct)item).TextoSecundario = o.E_UBICACION;
                //((Button)((ItemAct)item).FindControl("btnEliminar")).Text = "Gastos";
                //((Button)((ItemAct)item).FindControl("btnEliminar")).ToolTip = "Gastos";
                ((ItemAct)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", o.NID_TIPO, ".png");
                ((ItemAct)item).Editar += OnEditar;
                ((ItemAct)item).Eliminar += OnGastos;
                if (o.L_MODIFICADO.Value) ((Button)((ItemAct)item).FindControl("btnEditar")).CssClass = "ok";
                ((ItemAct)item).Bajar += OnBaja;
                grd.Controls.AddAt(0 + x, item);
            }
        }

        private void PagInmueblesN()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            if (!IsPostBack)
            {
           

                //---------------Inmuebles
                //cmbTipoBien
                blld__l_CAT_TIPO_INMUEBLE oTipoBien = new blld__l_CAT_TIPO_INMUEBLE();
                oTipoBien.L_ACTIVO = true;
                oTipoBien.select();
                cmbTipoBienN.DataBind(oTipoBien.lista_CAT_TIPO_INMUEBLE, CAT_TIPO_INMUEBLE.Properties.NID_TIPO, CAT_TIPO_INMUEBLE.Properties.V_TIPO);
                cmbTipoBienN.Items.Insert(0, new ListItem(String.Empty));
                //tipo uso
                blld__l_CAT_USO_INMUEBLE oTipoUso = new blld__l_CAT_USO_INMUEBLE();
                oTipoUso.select();
                cmbTipoUsoN.DataBind(oTipoUso.lista_CAT_USO_INMUEBLE, CAT_USO_INMUEBLE.Properties.NID_USO, CAT_USO_INMUEBLE.Properties.V_USO);
                cmbTipoUsoN.Items.Insert(0, new ListItem(String.Empty));
                //Dependientes
                chbDependietesN.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietesN.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietesN.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietesN.DataBind();
                chbDependietesN.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietesN.Items.Insert(chbDependietesN.Items.Count, new ListItem("Copropietario", "-1"));
            }
            blld_ALTA_INMUEBLE j;
            for (int x2 = 0; x2 < oDeclaracion.ALTA.ALTA_INMUEBLEs.Count; x2++)
            {
                j = oDeclaracion.ALTA.ALTA_INMUEBLEs[x2];
                UserControl item = (UserControl)Page.LoadControl("Item.ascx");
                ((Item)item).Id = x2;
                ((Item)item).ID = String.Concat("inm_",x2);
                ((Item)item).TextoPrincipal = j.V_TIPO;
                ((Item)item).TextoSecundario = j.E_UBICACION;

              ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", j.NID_TIPO, ".png");

                ((Item)item).Editar += OnEditarN;
                ((Item)item).Eliminar += OnEliminar;
                //((Button)((ItemAct)item).FindControl("btnGastos")).Visible = false;
                //((Button)((ItemAct)item).FindControl("btnBaja")).Text = "Eliminar";
                //((Button)((ItemAct)item).FindControl("btnBaja")).ToolTip = "Borrar registro"; 

                ((Item)item).Bajar += OnBajaN;
                grdInmueble.Controls.AddAt(0 + x2, item);
            }
        }
        protected void OnGastos(object sender, ItemEventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            mppGasto.Show();
            ctrlGastos1.NID_PATRIMONIO = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[e.Id].NID_PATRIMONIO;
            ctrlGastos1.NID_TIPO_GASTO.Add(3);
        }
        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            oDeclaracion.ALTA.ALTA_INMUEBLEs.RemoveAt(e.Id);
            grdInmueble.Controls.Remove(grdInmueble.FindControl(String.Concat("inm_", e.Id)));
            AlertaSuperior.ShowSuccess("Se eliminó correctamente el inmueble");
            _oDeclaracion = oDeclaracion;

        }
        protected void OnEditar(object sender, ItemEventArgs e)
        {
            // mppInversion.Show(true);

            //blld_ALTA_INMUEBLE i;
            blld_MODIFICACION_INMUEBLE i;
            lEditar = true;
            mppInmuebles.HeaderText = "Editar inmueble";
            mppInmuebles.Show(true);
            i = _oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[e.Id];
            IndiceItemSeleccionado = e.Id;
            chbDependietes.ClearSelection();
            cmbTipoBien.SelectedValue = i.NID_TIPO.ToString();
            txtUbicacionInmueble.Text = i.E_UBICACION.ToString();
            numbertxtSuperficieTerreno.Text = i.N_TERRENO.ToString();
            numbertxtSuperficieConstruccion.Text = i.N_CONSTRUCCION.ToString();
            txtFechaAfquisicion.Text = i.F_ADQUISICION.ToString(strFormatoFecha);
            moneytxtValorAdqusicion.Text = i.M_VALOR_INMUEBLE.ToString();
            cmbTipoUso.SelectedValue = i.NID_USO.ToString();
            //checaAdeudoImueble();
            chbDependietes.ClearSelection();
            foreach (blld_MODIFICACION_INMUEBLE_TITULA item in i.MODIFICACION_INMUEBLE_TITULAs)
            {
                chbDependietes.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
            }

        }
        public void Anterior()
        {
            Response.Redirect("DatosGenerales.aspx");
        }
        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 18);
            _oDeclaracion = oDeclaracion;
            Response.Redirect("ModificaMuebles.aspx");

        }

        private void marcaApartado(ref blld_DECLARACION oDeclaracion, int NID_APARTADO)
        {
            if (oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs.Where(p => p.L_MODIFICADO == false).Any()) { }
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
       
        protected void cmbTipoBienSelect_Change(object sender, EventArgs e)
        {
            String Index = e.ToString();
            string message = cmbTipoBien.SelectedItem.Text + " - " + cmbTipoBien.SelectedItem.Value;
        }

       

      
        protected void btnCerrarInmuebles_Click(object sender, EventArgs e)
        {
            mppInmuebles.Hide();
            InfoAdeudo = null;
        }
        protected void btnGuardarInmueble_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarInmueble();
                String msg = "Se actualizaron correctamente los datos del inmueble";
                AlertaSuperior.ShowSuccess(msg);
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                marcaApartado(ref oDeclaracion, 18);
                _oDeclaracion = oDeclaracion;
            }
            
        }
        private void EditarInmueble()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceItemSeleccionado;
            try
            {
                oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].NID_TIPO = cmbTipoBien.SelectedValue();
                oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].E_UBICACION = txtUbicacionInmueble.Text;
                oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].N_TERRENO = numbertxtSuperficieTerreno.Decimal();
                oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].N_CONSTRUCCION = numbertxtSuperficieConstruccion.Decimal();
                oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].F_ADQUISICION = txtFechaAfquisicion.Date(Pagina.esMX);
                oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].M_VALOR_INMUEBLE = moneytxtValorAdqusicion.Money();
                oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].NID_USO = cmbTipoUso.SelectedValue();
                oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].update(chbDependietes.SelectedValuesInteger());
                ((ItemAct)grd.FindControl("ModInmu" + Indice.ToString())).TextoSecundario = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[Indice].E_UBICACION;
                ((Button)((ItemAct)grd.FindControl("ModInmu" + Indice.ToString())).FindControl("btnEditar")).CssClass = "ok";
                mppInmuebles.Hide();
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
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ctrlGastos1.btnGuardar(sender, e);
            AlertaSuperior1.ShowSuccess("Se guardó correctamente la información");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 18);
            _oDeclaracion = oDeclaracion;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ctrlGastos1.btnAgregar(sender, e);
        }
        protected void btnXGasto_Click(object sender, EventArgs e)
        {
            mppGasto.Hide();
        }

        protected void OnBaja(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            Int32 nid = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[e.Id].NID_PATRIMONIO;

            if (oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == nid).Any())
                ctrlDesincorpora1.llena(nid);
            else
            {
                ctrlDesincorpora1.NID_PATRIMONIO = nid;
                ctrlDesincorpora1.limpia();
            }
        }

        protected void OnBajaN(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            //Int32 nid = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs[e.Id].NID_PATRIMONIO;
            Int32 nid = oDeclaracion.ALTA.ALTA_INMUEBLEs[e.Id].NID_PATRIMONIO;
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
        }

        protected void btnEliminarBaja_Click(object sender, EventArgs e)
        {
            ctrlDesincorpora1.Elimina();
            mppBaja.Hide();
            AlertaSuperior.ShowSuccess("Se eliminó exitosamenta la baja del bien patrimonial");
        }
        private void conInmuebles()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            if (!IsPostBack)
            {

                //---------------Inmuebles
                //cmbTipoBien
                blld__l_CAT_TIPO_INMUEBLE oTipoBien = new blld__l_CAT_TIPO_INMUEBLE();
                oTipoBien.select();
                cmbTipoBien.DataBind(oTipoBien.lista_CAT_TIPO_INMUEBLE, CAT_TIPO_INMUEBLE.Properties.NID_TIPO, CAT_TIPO_INMUEBLE.Properties.V_TIPO);
                //tipo uso
                blld__l_CAT_USO_INMUEBLE oTipoUso = new blld__l_CAT_USO_INMUEBLE();
                oTipoUso.select();
                cmbTipoUso.DataBind(oTipoUso.lista_CAT_USO_INMUEBLE, CAT_USO_INMUEBLE.Properties.NID_USO, CAT_USO_INMUEBLE.Properties.V_USO);
                //Dependientes
                chbDependietes.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietes.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietes.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietes.DataBind();
                chbDependietes.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietes.Items.Insert(chbDependietes.Items.Count, new ListItem("Copropietario", "-1"));
            }
            //PANEL
            blld_ALTA_INMUEBLE i;
           

            for (int x = 0; x < oDeclaracion.ALTA.ALTA_INMUEBLEs.Count; x++)
            {
                i = oDeclaracion.ALTA.ALTA_INMUEBLEs[x];
                UserControl item = (UserControl)Page.LoadControl("Item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("inm_", x);
                ((Item)item).TextoPrincipal = i.V_TIPO;
                ((Item)item).TextoSecundario = i.E_UBICACION;
                //((Button)((ItemAct)item).FindControl("btnEliminar")).Text = "Gastos";
                //((Button)((ItemAct)item).FindControl("btnEliminar")).ToolTip = "Gastos";
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", i.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditarN;
                ((Item)item).Eliminar += OnEliminar;
                //((Button)((ItemAct)item).FindControl("btnEliminar")).Visible = false;
                ((Item)item).Bajar += OnBajaN;
                grdInmueble.Controls.AddAt(0 + x, item);
            }


        }

        protected void btnGuardarInmuebleN_Click(object sender, EventArgs e)
        {
            if (lEditarN)
            {
                EditarInmuebleN();
                String msg = "Se actualizaron correctamente los datos del inmueble";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarInmuebleN();
                String msg = "Se agregó correctamente el inmueble";
                AlertaSuperior.ShowSuccess(msg);
            }
        }

        private void GuardarInmuebleN()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_INMUEBLE o;
            try
            {
                Decimal SupCostruccion;
                if (String.IsNullOrEmpty(numbertxtSuperficieConstruccionN.Text)) SupCostruccion = 0;
                else SupCostruccion = numbertxtSuperficieConstruccionN.Decimal();

                //oDeclaracion.ALTA.Add_ALTA_INMUEBLEs(cmbTipoBienN.SelectedValue()
                //                                   , txtFechaAfquisicionN.Date(esMX)
                //                                   , 1, Convert.ToInt32(cmbTipoUsoN.SelectedValue)
                //                                   , txtUbicacionInmuebleN.Text
                //                                   , numbertxtSuperficieTerrenoN.Decimal()
                //                                   , SupCostruccion
                //                                   , moneytxtValorAdqusicionN.Money()
                //                                   , chbDependietesN.SelectedValuesInteger());
                marcaApartado(ref oDeclaracion, 18);
                if (InfoAdeudo != null)
                {
                    oDeclaracion.ALTA.ALTA_INMUEBLEs.Last().Add_ALTA_INMUEBLE_ADEUDOs
                        (
                           InfoAdeudo.NID_PAIS
                           , InfoAdeudo.CID_ENTIDAD_FEDERATIVA
                           , InfoAdeudo.V_LUGAR
                           , InfoAdeudo.NID_INSTITUCION
                           , InfoAdeudo.V_OTRA
                           , InfoAdeudo.NID_TIPO_ADEUDO
                           , InfoAdeudo.F_ADEUDO
                           , InfoAdeudo.M_ORIGINAL
                           , InfoAdeudo.M_SALDO
                           , InfoAdeudo.E_CUENTA
                           , InfoAdeudo.NID_TITULARs
                        );
                    InfoAdeudo = null;
                }
                o = oDeclaracion.ALTA.ALTA_INMUEBLEs.Last();
                int x = grdInmueble.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("Item.ascx");
                ((Item)item).Id = oDeclaracion.ALTA.ALTA_INMUEBLEs.Count - 1;
                ((Item)item).TextoPrincipal = o.V_TIPO;
                ((Item)item).TextoSecundario = o.E_UBICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", o.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditarN;
                ((Item)item).Eliminar += OnGastos;
                ((Item)item).Bajar += OnBajaN;
                grdInmueble.Controls.AddAt(x, item);

                mppInmuebleNuevo.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
            _oDeclaracion = oDeclaracion;
        }
        private void EditarInmuebleN()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceSeleccionadoN;
            try
            {
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_TIPO = cmbTipoBienN.SelectedValue();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].E_UBICACION = txtUbicacionInmuebleN.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].N_TERRENO = numbertxtSuperficieTerrenoN.Decimal();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].N_CONSTRUCCION = numbertxtSuperficieConstruccionN.Decimal();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].F_ADQUISICION = txtFechaAfquisicionN.Date(Pagina.esMX);
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].M_VALOR_INMUEBLE = moneytxtValorAdqusicionN.Money();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_USO = cmbTipoUsoN.SelectedValue();
                //oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].update(chbDependietesN.SelectedValuesInteger());
                mppInmuebleNuevo.Hide();
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
        protected void btnCerrarInmueblesN_Click(object sender, EventArgs e)
        {
            mppInmuebleNuevo.Hide();
        }
        protected void btnAgregarInmuebles_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            lEditarN = false;

            mppInmuebleNuevo.HeaderText = "Agregar Inmueble";
            mppInmuebleNuevo.Show(true);

            txtUbicacionInmuebleN.Text = String.Empty;
            numbertxtSuperficieTerrenoN.Text = String.Empty;
            numbertxtSuperficieConstruccionN.Text = String.Empty;
            txtFechaAfquisicionN.Text = String.Empty;
            moneytxtValorAdqusicionN.Text = String.Empty;
            checaAdeudoImueble();
            chbDependietesN.ClearSelection();


        }
        protected void cbxTieneAdeudo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTieneAdeudo.Checked)
            {
                mppInmuebleNuevo.Hide();
                mppAdeudos.Show(true);
                Adeudo.Requerido = btnGuardarAdeudo.ClientID;
                mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
                btnCerrarModal.Visible = true;
                btnGuardarAdeudo.Visible = true;
               
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 3;
                lEditaAdeudo = false;
                InfoAdeudo = null;
                MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
            }
        }
        protected void btnEditarAdeudo1_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceSeleccionadoN;
            this.IndiceAdeudoSeleccionado = 0;
            mppInmuebleNuevo.Hide();
            mppAdeudos.Show(true);
            Adeudo.Requerido = btnGuardarAdeudo.ClientID;
            mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
            btnCerrarModal.Visible = true;
            btnGuardarAdeudo.Visible = true;
            //btnCerrarModalVehiculo.Visible = false;
            //btnGuardarAdeudoVehiculo.Visible = false;
            lEditaAdeudo = true;
            Adeudo.NID_TIPO_ADEUDO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].NID_TIPO_ADEUDO;
            Adeudo.NID_PAIS = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].NID_PAIS;
            Adeudo.CID_ENTIDAD_FEDERATIVA = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].CID_ENTIDAD_FEDERATIVA;
            Adeudo.V_LUGAR = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].V_LUGAR;
            Adeudo.NID_INSTITUCION = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].NID_INSTITUCION;
            Adeudo.V_OTRA = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].V_OTRA;
            Adeudo.F_ADEUDO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].F_ADEUDO;
            Adeudo.M_ORIGINAL = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].M_ORIGINAL;
            Adeudo.M_SALDO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].M_SALDO;
            Adeudo.E_CUENTA = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].E_CUENTA;
            Adeudo.NID_TITULARs = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].ALTA_ADEUDO_TITULARs.Select(p => p.NID_DEPENDIENTE).ToList();
        }

        protected void btnBorrarAdeudo1_Click(object sender, EventArgs e)
        {
            if (InfoAdeudo == null)
            {

                blld_USUARIO oUsuario = _oUsuario;
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                Int32 Indice = IndiceSeleccionadoN;
                oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].deleteConInmueble(oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_INMUEBLE);
                //oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs.RemoveAt(0);
                oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].Reload_ALTA_INMUEBLE_ADEUDOs();
                _oDeclaracion = oDeclaracion;
                checaAdeudoImueble();
            }
            else
            {
                InfoAdeudo = null;
                checaAdeudoImueble();
            }
        }
        protected void btnAgregarAdeudo_Click(object sender, EventArgs e)
        {
            if (lEditarN)
            {
                mppInmuebleNuevo.Hide();
                mppAdeudos.Show(true);
                Adeudo.Requerido = btnGuardarAdeudo.ClientID;
                mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
                btnCerrarModal.Visible = true;
                btnGuardarAdeudo.Visible = true;
                //btnCerrarModalVehiculo.Visible = false;
                //btnGuardarAdeudoVehiculo.Visible = false;
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 3;
                lEditaAdeudo = false;
            }
        }

        protected void btnBorrarAdeudo2_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceSeleccionadoN;
            oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
            oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].deleteConInmueble(oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_INMUEBLE);
            //oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs.RemoveAt(1);
            oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
            oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].Reload_ALTA_INMUEBLE_ADEUDOs();
            _oDeclaracion = oDeclaracion;
            checaAdeudoImueble();
        }

        protected void btnEditarAdeudo2_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceSeleccionadoN;
            this.IndiceAdeudoSeleccionado = 1;
            mppInmuebleNuevo.Hide();
            mppAdeudos.Show(true);
            mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
            Adeudo.Requerido = btnGuardarAdeudo.ClientID;
            btnCerrarModal.Visible = true;
            btnGuardarAdeudo.Visible = true;
            //btnCerrarModalVehiculo.Visible = false;
            //btnGuardarAdeudoVehiculo.Visible = false;
            lEditaAdeudo = true;
            Adeudo.NID_TIPO_ADEUDO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].NID_TIPO_ADEUDO;
            Adeudo.NID_PAIS = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].NID_PAIS;
            Adeudo.CID_ENTIDAD_FEDERATIVA = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].CID_ENTIDAD_FEDERATIVA;
            Adeudo.V_LUGAR = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].V_LUGAR;
            Adeudo.NID_INSTITUCION = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].NID_INSTITUCION;
            Adeudo.V_OTRA = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].V_OTRA;
            Adeudo.F_ADEUDO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].F_ADEUDO;
            Adeudo.M_ORIGINAL = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].M_ORIGINAL;
            Adeudo.M_SALDO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].M_SALDO;
            Adeudo.E_CUENTA = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].E_CUENTA;
            Adeudo.NID_TITULARs = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].ALTA_ADEUDO_TITULARs.Select(p => p.NID_DEPENDIENTE).ToList();
        }

        #region Fuera de lugar 
        enum OrigenesAdeudo
        {
            Inmuebles,
           // Vehiculos
        }

        private OrigenesAdeudo OrigenAdeudo
        {
            get => (OrigenesAdeudo)ViewState["OrigenAdeudo"];
            set => ViewState.Add("OrigenAdeudo", value);
        }

        private Boolean lEditaAdeudo
        {
            get => (Boolean)ViewState["lEditaAdeudo"];
            set => ViewState.Add("lEditaAdeudo", value);
        }

        private PreAduedo InfoAdeudo
        {
            get => (PreAduedo)ViewState["InfoAdeudo"];
            set => ViewState.Add("InfoAdeudo", value);
        }

        void checaAdeudoImueble()
        {
            Boolean lPreadeudo = InfoAdeudo != null;
            if (lEditarN)
            {
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                Int32 Indice = IndiceSeleccionadoN;
                Boolean lAdeudo = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs.Any();

                cbxTieneAdeudo.Checked = (lAdeudo || lPreadeudo);
                tablaAdeudo.Visible = cbxTieneAdeudo.Checked;
                cbxTieneAdeudo.Enabled = !cbxTieneAdeudo.Checked;
                if (lAdeudo)
                {
                    trAgregarAdeudo.Visible = true;
                    btnEditarAdeudo1.Visible = true;
                    ltrAdeudo1.Text = String.Concat("Saldo:"
                                       , oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].M_SALDO.ToString("C")
                                     , "  -  "
                                     , "Cuenta: "
                                     , oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].E_CUENTA
                                                 );
                    try
                    {
                        ltrAdeudo2.Text = String.Concat("Saldo:"
                                     , oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].M_SALDO.ToString("C")
                                  , "  -  "
                                  , "Cuenta: "
                                   , oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[1].E_CUENTA
                                               );
                        trAgregarAdeudo.Visible = false;
                        trAdeudo2.Visible = true;
                    }
                    catch
                    {
                        if (lEditarN)
                        {
                            trAgregarAdeudo.Visible = true;
                            trAdeudo2.Visible = false;
                        }
                        else
                        {
                            trAgregarAdeudo.Visible = false;
                            trAdeudo2.Visible = false;
                        }
                    }
                }

            }
            else
            {
                if (lPreadeudo)
                {
                    trAgregarAdeudo.Visible = false;
                    btnEditarAdeudo1.Visible = false;
                    ltrAdeudo1.Text = String.Concat("Saldo:"
                                     , InfoAdeudo.M_SALDO.ToString("C")
                                   , "  -  "
                                   , "Cuenta: "
                                   , InfoAdeudo.E_CUENTA
                                               );
                    cbxTieneAdeudo.Checked = true;
                    tablaAdeudo.Visible = cbxTieneAdeudo.Checked;
                    cbxTieneAdeudo.Enabled = !cbxTieneAdeudo.Checked;
                }
                else
                {
                    cbxTieneAdeudo.Checked = false;
                    tablaAdeudo.Visible = false;
                    cbxTieneAdeudo.Enabled = true;
                }
            }
        }

        [Serializable]
        internal class PreAduedo
        {
            internal Int32 NID_TIPO_ADEUDO { get; set; }
            internal Int32 NID_PAIS { get; set; }
            internal String CID_ENTIDAD_FEDERATIVA { get; set; }
            internal String V_LUGAR { get; set; }
            internal Int32 NID_INSTITUCION { get; set; }
            internal String V_OTRA { get; set; }
            internal DateTime F_ADEUDO { get; set; }
            internal Decimal M_ORIGINAL { get; set; }
            internal Decimal M_SALDO { get; set; }
            internal String E_CUENTA { get; set; }
            internal List<Int32> NID_TITULARs { get; set; }
        }

        #endregion
        protected void OnEditarN(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_INMUEBLE i;
            lEditarN = true;
            mppInmuebleNuevo.HeaderText = "Editar inmueble";
            mppInmuebleNuevo.Show(true);
            i = oDeclaracion.ALTA.ALTA_INMUEBLEs[e.Id];
            IndiceSeleccionadoN = e.Id;
            chbDependietesN.ClearSelection();
            cmbTipoBienN.SelectedValue = i.NID_TIPO.ToString();
            txtUbicacionInmuebleN.Text = i.E_UBICACION.ToString();
            numbertxtSuperficieTerrenoN.Text = i.N_TERRENO.ToString();
            numbertxtSuperficieConstruccionN.Text = i.N_CONSTRUCCION.ToString();
            txtFechaAfquisicionN.Text = i.F_ADQUISICION.ToString(strFormatoFecha);
            moneytxtValorAdqusicionN.Text = i.M_VALOR_INMUEBLE.ToString();
           // InmuebleSeccionTipoBien(i.N_CONSTRUCCION.ToString());
            cmbTipoUsoN.SelectedValue = i.NID_USO.ToString();
            checaAdeudoImueble();
            chbDependietesN.ClearSelection();

            foreach (blld_ALTA_INMUEBLE_TITULAR item in i.ALTA_INMUEBLE_TITULARs)
            {
                chbDependietesN.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
            }
        }
        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mppAdeudos.Hide();
            mppInmuebleNuevo.Show();
            checaAdeudoImueble();
            InfoAdeudo = null;
        }

        protected void btnGuardarAdeudo_Click(object sender, EventArgs e)
        {

            if (!Adeudo.NID_TITULARs.Any())
            {
                MsgBox.ShowDanger("Debe seleccionar por lo menos un titular");
            }
            else
            {
                blld_USUARIO oUsuario = _oUsuario;
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                Int32 Indice = IndiceSeleccionadoN;
                Int32 IndiceAdeudo = this.IndiceAdeudoSeleccionado;
                try
                {
                    if (Adeudo.M_ORIGINAL.HasValue)
                        if (Adeudo.M_ORIGINAL > moneytxtValorAdqusicionN.Money())
                            throw new CustomException("El monto original del adeudo no puede ser mayor que el valor del inmueble asociado");
                    if (Adeudo.F_ADEUDO > txtFechaAfquisicionN.Date())
                        throw new CustomException("La fecha del adeudo no puede ser mayor que la fecha de adquisición del inmueble asociado");

                    if (lEditaAdeudo)
                    {
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_PAIS = Adeudo.NID_PAIS;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].CID_ENTIDAD_FEDERATIVA = Adeudo.CID_ENTIDAD_FEDERATIVA;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_LUGAR = Adeudo.V_LUGAR;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_INSTITUCION = Adeudo.NID_INSTITUCION;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_OTRA = Adeudo.V_OTRA;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].F_ADEUDO = Adeudo.F_ADEUDO;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_ORIGINAL = Adeudo.M_ORIGINAL.Value;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_SALDO = Adeudo.M_SALDO.Value;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_CUENTA = Adeudo.E_CUENTA;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].update(Adeudo.NID_TITULARs);
                    }
                    else
                    {
                        if (lEditarN)
                        {
                            oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].Add_ALTA_INMUEBLE_ADEUDOs
                                (
                                  Adeudo.NID_PAIS
                                 , Adeudo.CID_ENTIDAD_FEDERATIVA
                                 , Adeudo.V_LUGAR
                                 , Adeudo.NID_INSTITUCION
                                 , Adeudo.V_OTRA
                                 , Adeudo.NID_TIPO_ADEUDO
                                 , Adeudo.F_ADEUDO
                                 , Adeudo.M_ORIGINAL.Value
                                 , Adeudo.M_SALDO.Value
                                 , Adeudo.E_CUENTA
                                 , Adeudo.NID_TITULARs
                                );
                        }
                        else
                        {
                            InfoAdeudo = new PreAduedo
                            {
                                NID_TIPO_ADEUDO = Adeudo.NID_TIPO_ADEUDO,
                                NID_PAIS = Adeudo.NID_PAIS,
                                CID_ENTIDAD_FEDERATIVA = Adeudo.CID_ENTIDAD_FEDERATIVA,
                                V_LUGAR = Adeudo.V_LUGAR,
                                NID_INSTITUCION = Adeudo.NID_INSTITUCION,
                                V_OTRA = Adeudo.V_OTRA,
                                F_ADEUDO = Adeudo.F_ADEUDO,
                                M_ORIGINAL = Adeudo.M_ORIGINAL.Value,
                                M_SALDO = Adeudo.M_SALDO.Value,
                                E_CUENTA = Adeudo.E_CUENTA,
                                NID_TITULARs = Adeudo.NID_TITULARs,
                            };


                        }
                    }
                    _oDeclaracion = oDeclaracion;
                    mppAdeudos.Hide();
                    mppInmuebleNuevo.Show();
                    checaAdeudoImueble();
                }
                catch (Exception ex)
                {
                    if (ex is CustomException)
                        MsgBox.ShowDanger(ex.Message);
                    else throw ex;
                }
            }
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            Siguiente();
        }
    }
}