using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;
using Declara_V2.BLL;
namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class Bienes : Pagina, IDeclaracionInicial
    {
        internal SubSecciones SubSeccionActiva
        {
            get => (SubSecciones)ViewState["SubSeccionActiva"];
            set => ViewState["SubSeccionActiva"] = value;
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


        internal Boolean lBanderaActualizaAnterior
        {
            get
            {
                if (ViewState["lBanderaActualizaAnterior"] == null)
                    return false;
                return (Boolean)ViewState["lBanderaActualizaAnterior"];
            }
            set
            {
                if (ViewState["lBanderaActualizaAnterior"] == null)
                    ViewState.Add("lBanderaActualizaAnterior", value);
                else
                    ViewState["lBanderaActualizaAnterior"] = value;
            }
        }


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

        internal enum SubSecciones
        {
            BienesInmuebles,
            OtrosBienes,
            Vehiculos
        }


        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;

            conInmuebles();
            conMuebles();
            conVehiculos();


            if (!IsPostBack)
            {
                txtFechaAfquisicion_C.StartDate = new DateTime(1900, 1, 1);
                txtFechaAfquisicion_C.EndDate = DateTime.Today.AddDays(-1);
                txtFechaAdquisicionVehiculo_C.StartDate = new DateTime(1900, 1, 1);
                txtFechaAdquisicionVehiculo_C.EndDate = DateTime.Today.AddDays(-1);
                txtF_ADQUISICION_C.StartDate = new DateTime(1900, 1, 1);
                txtF_ADQUISICION_C.EndDate = DateTime.Today.AddDays(-1);
                ctrlDesincorpora1.V_BUTTONID = btnGuardarBaja.ClientID;
            }

            if (ControlDeNavegacion != null || ViewState["SubSeccionActiva"] != null)
            {
                ViewState["SubSeccionActiva"] = ((SubSecciones)ControlDeNavegacion);
                this.SubSeccionActiva = ((SubSecciones)ControlDeNavegacion);
                lBanderaActualizaAnterior = false;
                ControlDeNavegacion = null;
            }
            if (ViewState["SubSeccionActiva"] == null)
            {
                ((Button)Master.FindControl("btnAnterior")).Visible = false;
                ViewState["SubSeccionActiva"] = SubSecciones.BienesInmuebles;
            }
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

            if (NID_APARTADO == 10)
            {
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 8, 9, 10, 18, 19, 20, 21 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
                {
                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO.Value)
                    {
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO = true;
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().update();
                    }
                }
            }
        }

        void active()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            ((_Conclusion)Master).links_Bienes(ref oDeclaracion);
            switch (SubSeccionActiva)
            {
                case SubSecciones.BienesInmuebles:
                    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                        ((LinkButton)Master.FindControl("lkBienesInmuebles")).CssClass = "completeve";
                    else
                        ((LinkButton)Master.FindControl("lkBienesInmuebles")).CssClass = "active";
                    break;
                case SubSecciones.OtrosBienes:
                    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                        ((LinkButton)Master.FindControl("lkBienesMuebles")).CssClass = "completeve";
                    else
                        ((LinkButton)Master.FindControl("lkBienesMuebles")).CssClass = "active";
                    break;
                case SubSecciones.Vehiculos:
                    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                        ((LinkButton)Master.FindControl("lkVehiculos")).CssClass = "completeve";
                    else
                        ((LinkButton)Master.FindControl("lkVehiculos")).CssClass = "active";
                    break;
            }

        }

        private void conVehiculos()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            if (!IsPostBack)
            {
                blld__l_CAT_MARCA_VEHICULO oMarca = new blld__l_CAT_MARCA_VEHICULO();
                oMarca.OrderByCriterios.Add(new Declara_V2.Order(CAT_MARCA_VEHICULO.Properties.V_MARCA));
                oMarca.select();
                cmbMarca.DataBind(oMarca.lista_CAT_MARCA_VEHICULO, CAT_MARCA_VEHICULO.Properties.NID_MARCA, CAT_MARCA_VEHICULO.Properties.V_MARCA);
                dpModelo.DataSource = oUsuario.CAT_AGNO;
                dpModelo.DataBind();



                cmbTipoVehiculo.DataBinder<blld__l_CAT_TIPO_VEHICULO>(new blld__l_CAT_TIPO_VEHICULO(), CAT_TIPO_VEHICULO.Properties.NID_TIPO_VEHICULO, CAT_TIPO_VEHICULO.Properties.V_TIPO_VEHICULO);

                blld__l_CAT_USO_VEHICULO oUV = new blld__l_CAT_USO_VEHICULO();
                oUV.select();
                dpTipoUso.DataBind(oUV.lista_CAT_USO_VEHICULO, CAT_USO_VEHICULO.Properties.NID_USO, CAT_USO_VEHICULO.Properties.V_USO);
                chbDependietesVehiculo.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietesVehiculo.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietesVehiculo.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietesVehiculo.DataBind();
                chbDependietesVehiculo.Items.Insert(0, new ListItem("DECLARANTE", "0"));
            }
            //Dependientes
            blld_ALTA_VEHICULO v;
            for (int x = 0; x < oDeclaracion.ALTA.ALTA_VEHICULOs.Count(); x++)
            {
                v = oDeclaracion.ALTA.ALTA_VEHICULOs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("Vehiculo_", x);
                ((Item)item).TextoPrincipal = v.V_MARCA.ToString();
                ((Item)item).TextoSecundario = v.V_DESCRIPCION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_VEHICULO/", x, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                ((Item)item).Bajar += OnBaja;
                grdVehiculos.Controls.AddAt(0 + x, item);
            }

        }

        private void conMuebles()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            if (!IsPostBack)
            {
                //---------------Muebles
                //cmbTipoBien
                blld__l_CAT_TIPO_MUEBLE oTipoMueble = new blld__l_CAT_TIPO_MUEBLE();
                oTipoMueble.select();
                dpTipoBienMueble.DataBind(oTipoMueble.lista_CAT_TIPO_MUEBLE, CAT_TIPO_MUEBLE.Properties.NID_TIPO, CAT_TIPO_MUEBLE.Properties.V_TIPO);
                //Dependientes
                chbDependietesMuebles.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietesMuebles.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietesMuebles.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietesMuebles.DataBind();
                chbDependietesMuebles.Items.Insert(0, new ListItem("DECLARANTE", "0"));

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
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                ((Item)item).Bajar += OnBaja;
                grdMueble.Controls.AddAt(0 + x, item);
            }


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
                chbDependietes.Items.Insert(0, new ListItem("DECLARANTE", "0"));
            }
            //PANEL
            blld_ALTA_INMUEBLE i;
            for (int x = 0; x < oDeclaracion.ALTA.ALTA_INMUEBLEs.Count; x++)
            {
                i = oDeclaracion.ALTA.ALTA_INMUEBLEs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("Inmueble_", x);

                ((Item)item).TextoPrincipal = i.V_TIPO;
                ((Item)item).TextoSecundario = i.E_UBICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", i.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                ((Item)item).Bajar += OnBaja;
                grdInmueble.Controls.AddAt(0 + x, item);
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                blld_USUARIO oUsuario = _oUsuario;


                switch (SubSeccionActiva)
                {
                    case SubSecciones.BienesInmuebles:

                        ((Button)Master.FindControl("btnAnterior")).Visible = true;
                        ViewState["SubSeccionActiva"] = SubSecciones.BienesInmuebles;
                        ltrSubTitulo.Text = "Bienes - Inmuebles";
                        pnlBienesInmuebles.Visible = true;
                        pnlOtrosBienes.Visible = false;
                        pnlVehiculos.Visible = false;
                        if (oDeclaracion.ALTA.ALTA_INMUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                            QstBoxInm.Ask("¿Tiene Bienes Inmuebles que registrar?");
                        break;

                    case SubSecciones.OtrosBienes:
                        ((Button)Master.FindControl("btnAnterior")).Visible = true;
                        ViewState["SubSeccionActiva"] = SubSecciones.OtrosBienes;
                        ltrSubTitulo.Text = "Bienes - Otros Bienes Muebles";
                        pnlBienesInmuebles.Visible = false;
                        pnlOtrosBienes.Visible = true;
                        pnlVehiculos.Visible = false;
                        if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                            QstBoxMue.Ask("¿Tiene Otros Bienes Muebles que registrar?");
                        break;
                    case SubSecciones.Vehiculos:
                        ((Button)Master.FindControl("btnAnterior")).Visible = true;
                        ViewState["SubSeccionActiva"] = SubSecciones.Vehiculos;
                        ltrSubTitulo.Text = "Bienes - Vehículos";
                        pnlBienesInmuebles.Visible = false;
                        pnlOtrosBienes.Visible = false;
                        pnlVehiculos.Visible = true;
                        if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                            QstBoxVehic.Ask("¿Tiene Vehículos que registrar?");
                        break;
                }

                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = QstBoxInm.FindControl("btnCancelar").UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);

                //AsyncPostBackTrigger trigger2 = new AsyncPostBackTrigger();
                trigger = new AsyncPostBackTrigger();
                trigger.ControlID = QstBoxMue.FindControl("btnCancelar").UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);

                //AsyncPostBackTrigger trigger3 = new AsyncPostBackTrigger();
                trigger = new AsyncPostBackTrigger();
                trigger.ControlID = QstBoxVehic.FindControl("btnCancelar").UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);

                trigger = new AsyncPostBackTrigger();
                trigger.ControlID = QstBoxInm.FindControl("btnAceptar").UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);

                trigger = new AsyncPostBackTrigger();
                trigger.ControlID = QstBoxMue.FindControl("btnAceptar").UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);

                trigger = new AsyncPostBackTrigger();
                trigger.ControlID = QstBoxVehic.FindControl("btnAceptar").UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);

                active();
            }
            ((HtmlControl)Master.FindControl("liBienes")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu2")).Attributes.Add("class", "tab-pane fade level1 active in");


        }

        public void Anterior()
        {
            switch (SubSeccionActiva)
            {
                case SubSecciones.BienesInmuebles:
                    Response.Redirect("ModificaVehiculos.aspx");
                    break;

                case SubSecciones.OtrosBienes:
                    blld_DECLARACION oDeclaracion = _oDeclaracion;
                    if (oDeclaracion.ALTA.ALTA_INMUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                        QstBoxInm.Ask("¿Tiene Bienes Inmuebles que registrar?");
                    ltrSubTitulo.Text = "Bienes - Inmuebles";
                    ((Button)Master.FindControl("btnAnterior")).Visible = true;
                    pnlBienesInmuebles.Visible = true;
                    pnlOtrosBienes.Visible = false;
                    pnlVehiculos.Visible = false;
                    SubSeccionActiva = SubSecciones.BienesInmuebles;
                    break;

                case SubSecciones.Vehiculos:
                    ltrSubTitulo.Text = "Bienes - Otros Bienes";
                    ((Button)Master.FindControl("btnAnterior")).Visible = true;
                    pnlBienesInmuebles.Visible = false;
                    pnlOtrosBienes.Visible = true;
                    pnlVehiculos.Visible = false;
                    SubSeccionActiva = SubSecciones.OtrosBienes;
                    break;

            }
            active();
        }


        public void Guardar()
        {
            switch (SubSeccionActiva)
            {
                case SubSecciones.BienesInmuebles:
                    blld_DECLARACION oDeclaracion = _oDeclaracion;
                    //oDeclaracion.
                    break;
                case SubSecciones.Vehiculos:
                    break;
                case SubSecciones.OtrosBienes:
                    break;
            }
            String msg = "Se guardaron correctamente los datos del apartado";
            AlertaSuperior.ShowSuccess(msg);
        }

        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            switch (SubSeccionActiva)
            {
                case SubSecciones.BienesInmuebles:
                    if (oDeclaracion.ALTA.ALTA_INMUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                    { }
                    else
                    {
                        marcaApartado(ref oDeclaracion, 8);
                    }
                    ltrSubTitulo.Text = "Bienes - Otros Bienes";
                    ((Button)Master.FindControl("btnAnterior")).Visible = true;
                    pnlBienesInmuebles.Visible = false;
                    pnlOtrosBienes.Visible = true;
                    pnlVehiculos.Visible = false;
                    SubSeccionActiva = SubSecciones.OtrosBienes;

                    if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                        QstBoxMue.Ask("¿Tiene Otros Bienes Muebles que registrar?");
                    break;

                case SubSecciones.OtrosBienes:
                    if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                    { }
                    else
                    {
                        marcaApartado(ref oDeclaracion, 9);
                    }
                        ltrSubTitulo.Text = "Bienes - Vehículos ";
                        ((Button)Master.FindControl("btnAnterior")).Visible = true;
                        pnlBienesInmuebles.Visible = false;
                        pnlOtrosBienes.Visible = false;
                        pnlVehiculos.Visible = true;
                        SubSeccionActiva = SubSecciones.Vehiculos;
                        if (oDeclaracion.ALTA.ALTA_VEHICULOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                            QstBoxVehic.Ask("¿Tiene Vehículos que registrar?");
                    
                    break;

                case SubSecciones.Vehiculos:
                    if (oDeclaracion.ALTA.ALTA_VEHICULOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                    { }
                    else
                    {
                        marcaApartado(ref oDeclaracion, 10);
                    }
                        Response.Redirect("Desincorpora.aspx");
                    break;

            }
            active();
            _oDeclaracion = oDeclaracion;
        }

        protected void OnBaja(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            Int32 nid;
            switch (SubSeccionActiva)
            {
                case SubSecciones.BienesInmuebles:
                    nid = oDeclaracion.ALTA.ALTA_INMUEBLEs[e.Id].NID_PATRIMONIO;
                    break;
                case SubSecciones.OtrosBienes:
                    nid = oDeclaracion.ALTA.ALTA_MUEBLEs[e.Id].NID_PATRIMONIO;
                    break;
                case SubSecciones.Vehiculos:
                    nid = oDeclaracion.ALTA.ALTA_VEHICULOs[e.Id].NID_PATRIMONIO;
                    break;
                default:
                    nid = -1;
                    break;
            }
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
        protected void OnEditar(object sender, ItemEventArgs e)
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            switch (SubSeccionActiva)
            {
                case SubSecciones.BienesInmuebles:

                    blld_ALTA_INMUEBLE i;
                    lEditar = true;
                    mppInmuebles.HeaderText = "Editar inmueble";
                    mppInmuebles.Show(true);
                    i = oDeclaracion.ALTA.ALTA_INMUEBLEs[e.Id];
                    IndiceItemSeleccionado = e.Id;
                    chbDependietes.ClearSelection();
                    cmbTipoBien.SelectedValue = i.NID_TIPO.ToString();
                    txtUbicacionInmueble.Text = i.E_UBICACION.ToString();
                    numbertxtSuperficieTerreno.Text = i.N_TERRENO.ToString();
                    numbertxtSuperficieConstruccion.Text = i.N_CONSTRUCCION.ToString();
                    txtFechaAfquisicion.Text = i.F_ADQUISICION.ToString(strFormatoFecha);
                    moneytxtValorAdqusicion.Text = i.M_VALOR_INMUEBLE.ToString();
                    InmuebleSeccionTipoBien(i.N_CONSTRUCCION.ToString());
                    cmbTipoUso.SelectedValue = i.NID_USO.ToString();
                    checaAdeudoImueble();
                    chbDependietes.ClearSelection();


                    foreach (blld_ALTA_INMUEBLE_TITULAR item in i.ALTA_INMUEBLE_TITULARs)
                    {
                        chbDependietes.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
                    break;

                case SubSecciones.OtrosBienes:

                    blld_ALTA_MUEBLE m;
                    lEditar = true;
                    mppMuebles.HeaderText = "Editar mueble";
                    mppMuebles.Show(true);
                    m = oDeclaracion.ALTA.ALTA_MUEBLEs[e.Id];
                    IndiceItemSeleccionado = e.Id;

                    dpTipoBienMueble.SelectedValue = m.NID_TIPO.ToString();
                    txtEspecifica.Text = m.E_ESPECIFICACION.ToString();
                    moneytxtValorAdqusicionMueble.Text = m.M_VALOR.ToString();
                    txtF_ADQUISICION.Text = m.F_ADQUISICION.ToString(strFormatoFecha);
                    chbDependietesMuebles.ClearSelection();
                    foreach (blld_ALTA_MUEBLE_TITULAR item in m.ALTA_MUEBLE_TITULARs)
                    {
                        chbDependietesMuebles.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
                    break;
                case SubSecciones.Vehiculos:

                    blld_ALTA_VEHICULO v;
                    lEditar = true;
                    mppVehículos.HeaderText = "Editar vehiculo";
                    mppVehículos.Show(true);
                    v = oDeclaracion.ALTA.ALTA_VEHICULOs[e.Id];
                    IndiceItemSeleccionado = e.Id;

                    cmbMarca.SelectedValue = v.NID_MARCA.ToString();
                    cmbTipoVehiculo.SelectedValue = v.NID_TIPO_VEHICULO.ToString();
                    txtTipo.Text = v.V_DESCRIPCION.ToString();
                    txtFechaAdquisicionVehiculo.Text = v.F_ADQUISICION.ToString(strFormatoFecha);
                    dpModelo.SelectedItem.Text = v.C_MODELO.ToString();
                    moneytxtValorAdquisicion.Text = v.M_VALOR_VEHICULO.ToString();
                    dpTipoUso.SelectedItem.Value = v.NID_USO.ToString();
                    checaAdeudoVehiculo();
                    chbDependietesVehiculo.ClearSelection();

                    foreach (blld_ALTA_VEHICULO_TITULAR item in v.ALTA_VEHICULO_TITULARs)
                    {
                        chbDependietesVehiculo.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
                    break;
            }



        }

        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            switch (SubSeccionActiva)
            {
                case SubSecciones.BienesInmuebles:
                    try
                    {
                        oDeclaracion.ALTA.ALTA_INMUEBLEs.RemoveAt(e.Id);
                        _oDeclaracion = oDeclaracion;
                        grdInmueble.Controls.Remove(grdInmueble.FindControl(String.Concat("Inmueble_", e.Id)));
                        AlertaSuperior.ShowSuccess("Se eliminó correctamente el inmueble");
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
                    break;

                case SubSecciones.OtrosBienes:
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
                    break;
                case SubSecciones.Vehiculos:
                    try
                    {
                        oDeclaracion.ALTA.ALTA_VEHICULOs.RemoveAt(e.Id);
                        _oDeclaracion = oDeclaracion;
                        grdVehiculos.Controls.Remove(grdVehiculos.FindControl(String.Concat("Vehiculo_", e.Id)));
                        AlertaSuperior.ShowSuccess("Se eliminó correctamente el vehículo");
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
                    break;
            }


        }

        protected void btnAgregarInmuebles_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            lEditar = false;

            mppInmuebles.HeaderText = "Agregar Inmueble";
            mppInmuebles.Show(true);

            txtUbicacionInmueble.Text = String.Empty;
            numbertxtSuperficieTerreno.Text = String.Empty;
            numbertxtSuperficieConstruccion.Text = String.Empty;
            txtFechaAfquisicion.Text = String.Empty;
            moneytxtValorAdqusicion.Text = String.Empty;
            checaAdeudoImueble();
            chbDependietes.ClearSelection();


        }

        protected void btnCerrarInmuebles_Click(object sender, EventArgs e)
        {
            mppInmuebles.Hide();
            InfoAdeudo = null;
        }
        protected void cmbTipoBienSelect_Change(object sender, EventArgs e)
        {
            String Index = e.ToString();
            string message = cmbTipoBien.SelectedItem.Text + " - " + cmbTipoBien.SelectedItem.Value;
            InmuebleSeccionTipoBien(cmbTipoBien.SelectedItem.Value);
        }

        private void InmuebleSeccionTipoBien(string value)
        {
            if (cmbTipoBien.SelectedItem.Value == "2" || cmbTipoBien.SelectedItem.Value == "4")
            {
                numbertxtSuperficieConstruccion.Enabled = true;
                numbertxtSuperficieTerreno.Enabled = true;
            }

            switch (cmbTipoBien.SelectedItem.Value)
            {
                case "2":
                    numbertxtSuperficieTerreno.Text = "0";
                    numbertxtSuperficieTerreno.Enabled = false;
                    break;
                case "4":
                    numbertxtSuperficieConstruccion.Text = "0";
                    numbertxtSuperficieConstruccion.Enabled = false;
                    break;
                default:
                    numbertxtSuperficieConstruccion.Enabled = true;
                    numbertxtSuperficieTerreno.Enabled = true;
                    break;
            }
        }

        protected void btnGuardarInmueble_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarInmueble();
                String msg = "Se actualizarón correctamente los datos del inmueble";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarInmueble();
                String msg = "Se agregó correctamente el inmueble";
                AlertaSuperior.ShowSuccess(msg);
            }
        }

        private void GuardarInmueble()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_INMUEBLE o;
            try
            {
                Decimal SupCostruccion;
                if (String.IsNullOrEmpty(numbertxtSuperficieConstruccion.Text)) SupCostruccion = 0;
                else SupCostruccion = numbertxtSuperficieConstruccion.Decimal();

                //oDeclaracion.ALTA.Add_ALTA_INMUEBLEs(cmbTipoBien.SelectedValue()
                //                                   , txtFechaAfquisicion.Date(esMX)
                //                                   , 1
                //                                   , Convert.ToInt32(cmbTipoUso.SelectedValue)
                //                                   , txtUbicacionInmueble.Text
                //                                   , numbertxtSuperficieTerreno.Decimal()
                //                                   , SupCostruccion
                //                                   , moneytxtValorAdqusicion.Money()
                //                                   , chbDependietes.SelectedValuesInteger());
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
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oDeclaracion.ALTA.ALTA_INMUEBLEs.Count - 1;
                ((Item)item).TextoPrincipal = o.V_TIPO;
                ((Item)item).TextoSecundario = o.E_UBICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", o.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                ((Item)item).Bajar += OnBaja;
                grdInmueble.Controls.AddAt(x, item);

                mppInmuebles.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
            _oDeclaracion = oDeclaracion;
        }

        private void EditarInmueble()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceItemSeleccionado;
            try
            {
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_TIPO = cmbTipoBien.SelectedValue();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].E_UBICACION = txtUbicacionInmueble.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].N_TERRENO = numbertxtSuperficieTerreno.Decimal();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].N_CONSTRUCCION = numbertxtSuperficieConstruccion.Decimal();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].F_ADQUISICION = txtFechaAfquisicion.Date(Pagina.esMX);
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].M_VALOR_INMUEBLE = moneytxtValorAdqusicion.Money();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_USO = cmbTipoUso.SelectedValue();
                //oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].update(chbDependietes.SelectedValuesInteger());
                mppInmuebles.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            _oDeclaracion = oDeclaracion;
        }

        protected void btnCerrarMueble_Click(object sender, EventArgs e)
        {
            mppMuebles.Hide();
        }

        protected void btnAgregarMueble_Click(object sender, EventArgs e)
        {
            mppMuebles.HeaderText = "Agregar mueble";
            mppMuebles.Show(true);

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            lEditar = false;
            txtEspecifica.Text = String.Empty;
            txtF_ADQUISICION.Text = String.Empty;
            moneytxtValorAdqusicionMueble.Text = String.Empty;
            chbDependietesMuebles.ClearSelection();
        }

        protected void btnGuardarMueble_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarMueble();
                String msg = "Se actualizarón correctamente los datos del bien";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarMueble();
                String msg = "Se agregó correctamente el bien";
                AlertaSuperior.ShowSuccess(msg);
            }
        }

        private void GuardarMueble()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_MUEBLE o;
            try
            {
                //oDeclaracion.ALTA.Add_ALTA_MUEBLEs(
                //                                  dpTipoBienMueble.SelectedValue()
                //                                , txtEspecifica.Text
                //                                , moneytxtValorAdqusicionMueble.Money()
                //                                , false
                //                                , txtF_ADQUISICION.Date(esMX)
                //                                , chbDependietesMuebles.SelectedValuesInteger());
                o = oDeclaracion.ALTA.ALTA_MUEBLEs.Last();

                int x = grdMueble.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("Mueble_", x);
                ((Item)item).TextoPrincipal = o.V_TIPO;
                ((Item)item).TextoSecundario = o.E_ESPECIFICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_MUEBLE/", o.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                ((Item)item).Bajar += OnBaja;
                grdMueble.Controls.AddAt(x, item);

                mppMuebles.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }

            _oDeclaracion = oDeclaracion;
        }

        private void EditarMueble()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceItemSeleccionado;
            try
            {
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].NID_TIPO = dpTipoBienMueble.SelectedValue();
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].E_ESPECIFICACION = txtEspecifica.Text;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].M_VALOR = moneytxtValorAdqusicionMueble.Money();
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].F_ADQUISICION = txtF_ADQUISICION.Date(esMX);
                //oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].update(chbDependietesMuebles.SelectedValuesInteger());
                mppMuebles.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            _oDeclaracion = oDeclaracion;
        }


        protected void btnEditaMueble_Click(object sender, EventArgs e)
        {
            mppMuebles.HeaderText = "Editar mueble";
            mppMuebles.Show(true);

        }
        protected void btnEliminarMueble_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            lEditar = false;
            InfoAdeudo = null;

            mppVehículos.HeaderText = "Agregar vehiculo";
            mppVehículos.Show(true);
            dpModelo.ClearSelection();
            cmbMarca.ClearSelection();
            cmbTipoVehiculo.ClearSelection();
            txtTipo.Text = String.Empty;
            txtFechaAdquisicionVehiculo.Text = String.Empty;
            moneytxtValorAdquisicion.Text = String.Empty;
            checaAdeudoVehiculo();
            dpTipoUso.ClearSelection();

            chbDependietesVehiculo.ClearSelection();
        }



        protected void btnGuardarVehiculo_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarVehiculo();
                String msg = "Se actualizarón correctamente los datos del vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarVehiculo();
                String msg = "Se agregó correctamente el vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
        }

        private void GuardarVehiculo()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_VEHICULO v;

            try
            {
                //oDeclaracion.ALTA.Add_ALTA_VEHICULOs(
                //                                    cmbTipoVehiculo.SelectedValue()
                //                                    , cmbMarca.SelectedValue()
                //                                   , dpModelo.SelectedValue
                //                                   , txtTipo.Text
                //                                   , txtFechaAdquisicionVehiculo.Date(esMX)
                //                                   , dpTipoUso.SelectedValue()
                //                                   , moneytxtValorAdquisicion.Money()
                //                                   , chbDependietesVehiculo.SelectedValuesInteger());
                if (InfoAdeudo != null)
                {
                    oDeclaracion.ALTA.ALTA_VEHICULOs.Last().Add_ALTA_VEHICULO_ADEUDO
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
                v = oDeclaracion.ALTA.ALTA_VEHICULOs.Last();

                int x = grdVehiculos.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).TextoPrincipal = v.V_MARCA;
                ((Item)item).TextoSecundario = v.V_DESCRIPCION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_VEHICULO/", x, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                ((Item)item).Bajar += OnBaja;
                grdVehiculos.Controls.AddAt(x, item);

                mppVehículos.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
            _oDeclaracion = oDeclaracion;


        }

        private void EditarVehiculo()
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceItemSeleccionado;
            try
            {

                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_TIPO_VEHICULO = cmbTipoVehiculo.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_MARCA = cmbMarca.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].V_DESCRIPCION = txtTipo.Text;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].C_MODELO = dpModelo.SelectedItem.ToString();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_USO = dpTipoUso.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].F_ADQUISICION = txtFechaAdquisicionVehiculo.Date(esMX);
                //oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].update(chbDependietesVehiculo.SelectedValuesInteger());
                mppVehículos.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            _oDeclaracion = oDeclaracion;
        }

        protected void btnEditaVehículos_Click(object sender, EventArgs e)
        {
            mppVehículos.HeaderText = "Editar vehiculo";
            mppVehículos.Show(true);
        }

        protected void btnCerrarMppVehículos_Click(object sender, EventArgs e)
        {
            mppVehículos.Hide();
        }

        #region Fuera de lugar 
        enum OrigenesAdeudo
        {
            Inmuebles,
            Vehiculos
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
            if (lEditar)
            {
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                Int32 Indice = IndiceItemSeleccionado;
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
                        if (lEditar)
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

        protected void cbxTieneAdeudo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTieneAdeudo.Checked)
            {
                mppInmuebles.Hide();
                mppAdeudos.Show(true);
                Adeudo.Requerido = btnGuardarAdeudo.ClientID;
                mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
                btnCerrarModal.Visible = true;
                btnGuardarAdeudo.Visible = true;
                btnCerrarModalVehiculo.Visible = false;
                btnGuardarAdeudoVehiculo.Visible = false;
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 3;
                lEditaAdeudo = false;
                InfoAdeudo = null;
                MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
            }
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mppAdeudos.Hide();
            mppInmuebles.Show();
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
                Int32 Indice = IndiceItemSeleccionado;
                Int32 IndiceAdeudo = this.IndiceAdeudoSeleccionado;
                try
                {
                    if (Adeudo.M_ORIGINAL.HasValue)
                        if (Adeudo.M_ORIGINAL > moneytxtValorAdqusicion.Money())
                            throw new CustomException("El monto original del adeudo no puede ser mayor que el valor del inmueble asociado");
                    if (Adeudo.F_ADEUDO > txtFechaAfquisicion.Date())
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
                        if (lEditar)
                        {
                            oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].Add_ALTA_INMUEBLE_ADEUDOs
                                (
                                  Adeudo.NID_PAIS
                                 , Adeudo.CID_ENTIDAD_FEDERATIVA
                                 , Adeudo.V_LUGAR
                                 , Adeudo.NID_INSTITUCION
                                 , Adeudo.V_OTRA
                                 , 3
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
                                NID_TIPO_ADEUDO = 3,
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
                    mppInmuebles.Show();
                    checaAdeudoImueble();
                }
                catch (Exception ex)
                {
                    if (ex is CustomException || ex is ConvertionException)
                        MsgBox.ShowDanger(ex.Message);
                    else throw ex;
                }
            }
        }

        protected void btnEditarAdeudo1_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            this.IndiceAdeudoSeleccionado = 0;
            mppInmuebles.Hide();
            mppAdeudos.Show(true);
            Adeudo.Requerido = btnGuardarAdeudo.ClientID;
            mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
            btnCerrarModal.Visible = true;
            btnGuardarAdeudo.Visible = true;
            btnCerrarModalVehiculo.Visible = false;
            btnGuardarAdeudoVehiculo.Visible = false;
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
                Int32 Indice = IndiceItemSeleccionado;
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
            if (lEditar)
            {
                mppInmuebles.Hide();
                mppAdeudos.Show(true);
                Adeudo.Requerido = btnGuardarAdeudo.ClientID;
                mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
                btnCerrarModal.Visible = true;
                btnGuardarAdeudo.Visible = true;
                btnCerrarModalVehiculo.Visible = false;
                btnGuardarAdeudoVehiculo.Visible = false;
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 3;
                lEditaAdeudo = false;
            }
        }

        protected void btnBorrarAdeudo2_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
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
            Int32 Indice = IndiceItemSeleccionado;
            this.IndiceAdeudoSeleccionado = 1;
            mppInmuebles.Hide();
            mppAdeudos.Show(true);
            mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
            Adeudo.Requerido = btnGuardarAdeudo.ClientID;
            btnCerrarModal.Visible = true;
            btnGuardarAdeudo.Visible = true;
            btnCerrarModalVehiculo.Visible = false;
            btnGuardarAdeudoVehiculo.Visible = false;
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

        void checaAdeudoVehiculo()
        {
            Boolean lPreadeudo = InfoAdeudo != null;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            btnEditarAdeudoVehiculo.Visible = true;
            Int32 Indice = IndiceItemSeleccionado;
            Boolean lAdeudo;
            try
            { lAdeudo = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs.Any(); }
            catch { lAdeudo = false; }

            if (lEditar)
            {
                cbxAdeudoVehiculo.Checked = (lAdeudo || lPreadeudo);
                tblAdeudoVehiculo.Visible = cbxAdeudoVehiculo.Checked;
                cbxAdeudoVehiculo.Enabled = !cbxAdeudoVehiculo.Checked;

            }
            else
            {
                if (lPreadeudo)
                {
                    btnEditarAdeudoVehiculo.Visible = false;
                    cbxAdeudoVehiculo.Checked = (lAdeudo || lPreadeudo);
                    tblAdeudoVehiculo.Visible = cbxAdeudoVehiculo.Checked;
                    cbxAdeudoVehiculo.Enabled = !cbxAdeudoVehiculo.Checked;

                }
                else
                {
                    cbxAdeudoVehiculo.Checked = false;
                    tblAdeudoVehiculo.Visible = cbxAdeudoVehiculo.Checked;
                    cbxAdeudoVehiculo.Enabled = !cbxAdeudoVehiculo.Checked;
                }
            }

            try
            {
                ltrAdeudoVehiculo.Text = String.Concat("Saldo:"
                              , oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[0].M_SALDO.ToString("C")
                            , "  -  "
                            , "Cuenta: "
                            , oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[0].E_CUENTA
                                        );
            }
            catch
            {
            }


        }

        protected void cbxAdeudoVehiculo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAdeudoVehiculo.Checked)
            {
                mppVehículos.Hide();
                mppAdeudos.Show(true);
                Adeudo.Requerido = btnGuardarAdeudoVehiculo.ClientID;
                mppAdeudos.HeaderText = "Adeudo por concepto de crédito automotriz";
                btnCerrarModal.Visible = false;
                btnGuardarAdeudo.Visible = false;
                btnCerrarModalVehiculo.Visible = true;
                btnGuardarAdeudoVehiculo.Visible = true;
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 2;
                lEditaAdeudo = false;
                InfoAdeudo = null;
                MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
            }
        }

        protected void btnModificarAdeudoVehiculo_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            IndiceAdeudoSeleccionado = 0;
            Int32 IndiceAdeudo = this.IndiceAdeudoSeleccionado;
            mppAdeudos.Show(true);
            Adeudo.Requerido = btnGuardarAdeudoVehiculo.ClientID;
            mppAdeudos.HeaderText = "Adeudo por concepto de crédito automotriz";
            btnCerrarModal.Visible = false;
            btnGuardarAdeudo.Visible = false;
            btnCerrarModalVehiculo.Visible = true;
            btnGuardarAdeudoVehiculo.Visible = true;
            lEditaAdeudo = true;


            Adeudo.NID_PAIS = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_PAIS;
            Adeudo.CID_ENTIDAD_FEDERATIVA = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].CID_ENTIDAD_FEDERATIVA;
            Adeudo.V_LUGAR = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_LUGAR;
            Adeudo.NID_INSTITUCION = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_INSTITUCION;
            Adeudo.V_OTRA = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_OTRA;
            Adeudo.F_ADEUDO = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].F_ADEUDO;
            Adeudo.M_ORIGINAL = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_ORIGINAL;
            Adeudo.M_SALDO = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_SALDO;
            Adeudo.E_CUENTA = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_CUENTA;
            Adeudo.NID_TITULARs = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].ALTA_ADEUDO_TITULARs.Select(p => p.NID_DEPENDIENTE).ToList();
            checaAdeudoVehiculo();
            mppVehículos.Hide();
        }

        protected void btnEliminarAdeudo_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            if (InfoAdeudo == null)
            {
                try
                {
                    oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                    oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[0].deleteConVehiculo(oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_VEHICULO);
                    //oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs.RemoveAt(0);
                    oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                    oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].Reload_ALTA_VEHICULO_ADEUDOs();
                    _oDeclaracion = oDeclaracion;
                }
                catch (Exception ex)
                {
                    if (ex is CustomException || ex is ConvertionException)
                        MsgBox.ShowDanger(ex.Message);
                }
            }
            else
            {
                InfoAdeudo = null;
            }
            checaAdeudoVehiculo();
        }

        protected void btnCerrarModalVehiculo_Click(object sender, EventArgs e)
        {
            mppVehículos.Show(true);
            InfoAdeudo = null;
            mppAdeudos.Hide();
            checaAdeudoVehiculo();
        }

        protected void btnGuardarAdeudoVehiculo_Click(object sender, EventArgs e)
        {
            mppVehículos.Show(true);
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            try
            {

                if (Adeudo.M_ORIGINAL.HasValue)
                    if (Adeudo.M_ORIGINAL > moneytxtValorAdquisicion.Money())
                        throw new CustomException("El monto original del adeudo no puede ser mayor que el valor del vehículo asociado");
                if (Adeudo.F_ADEUDO > txtFechaAdquisicionVehiculo.Date())
                    throw new CustomException("La fecha del adeudo no puede ser mayor que la fecha de adquisición del vehículo asociado");
                if (lEditar)
                {

                    Int32 Indice = IndiceItemSeleccionado;
                    if (lEditaAdeudo)
                    {
                        Int32 IndiceAdeudo = this.IndiceAdeudoSeleccionado;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_PAIS = Adeudo.NID_PAIS;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].CID_ENTIDAD_FEDERATIVA = Adeudo.CID_ENTIDAD_FEDERATIVA;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_LUGAR = Adeudo.V_LUGAR;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_INSTITUCION = Adeudo.NID_INSTITUCION;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_OTRA = Adeudo.V_OTRA;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].F_ADEUDO = Adeudo.F_ADEUDO;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_ORIGINAL = Adeudo.M_ORIGINAL.Value;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_SALDO = Adeudo.M_SALDO.Value;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_CUENTA = Adeudo.E_CUENTA;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].update(Adeudo.NID_TITULARs);

                        ltrAdeudoVehiculo.Text = String.Concat("Saldo:"
                                     , oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_SALDO.ToString("C")
                                   , "  -  "
                                   , "Cuenta: "
                                   , oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_CUENTA
                                               );
                    }
                    else
                    {
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].Add_ALTA_VEHICULO_ADEUDO
                              (
                                Adeudo.NID_PAIS
                               , Adeudo.CID_ENTIDAD_FEDERATIVA
                               , Adeudo.V_LUGAR
                               , Adeudo.NID_INSTITUCION
                               , Adeudo.V_OTRA
                               , 2
                               , Adeudo.F_ADEUDO
                               , Adeudo.M_ORIGINAL.Value
                               , Adeudo.M_SALDO.Value
                               , Adeudo.E_CUENTA
                               , Adeudo.NID_TITULARs
                              );
                        ltrAdeudoVehiculo.Text = String.Concat("Saldo:"
                 , oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[0].M_SALDO.ToString("C")
               , "  -  "
               , "Cuenta: "
               , oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[0].E_CUENTA
                           );
                    }
                }
                else
                {
                    InfoAdeudo = new PreAduedo
                    {
                        NID_TIPO_ADEUDO = 2,
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

                    ltrAdeudoVehiculo.Text = String.Concat("Saldo:"
                              , InfoAdeudo.M_SALDO.ToString("C")
                            , "  -  "
                            , "Cuenta: "
                            , InfoAdeudo.E_CUENTA
                                        );
                }
                mppAdeudos.Hide();
                checaAdeudoVehiculo();
                oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                _oDeclaracion = oDeclaracion;
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    MsgBox.ShowDanger(ex.Message);
                else
                    throw ex;
            }
        }

        protected void btnGuardarVehiculo2_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarVehiculo();
                String msg = "Se actualizarón correctamente los datos del vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarVehiculo();
                String msg = "Se agregó correctamente el vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
        }

        protected void QstBoxInm_No(object Sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 8);
            _oDeclaracion = oDeclaracion;
            Siguiente();
            active();
        }

        protected void QstBoxMue_No(object Sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 9);
            _oDeclaracion = oDeclaracion;
            Siguiente();
            active();
        }

        protected void QstBoxVehic_No(object Sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 10);
            _oDeclaracion = oDeclaracion;
            Siguiente();
            active();
        }

        protected void QstBoxInm_Yes(object Sender, EventArgs e)
        {
            active();
        }

        protected void QstBoxMue_Yes(object Sender, EventArgs e)
        {
            active();
        }

        protected void QstBoxVehic_Yes(object Sender, EventArgs e)
        {
            active();
        }

     
    }

}