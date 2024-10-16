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
namespace DeclaraINAI.Formas.DeclaracionInicial
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

            if (NID_APARTADO == 9)
            {
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 8, 9, 10 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
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
            ((_Inicial)Master).links_Bienes(ref oDeclaracion);
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

        private void conInmuebles()
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
                cmbTipoBien.DataBind(oTipoBien.lista_CAT_TIPO_INMUEBLE, CAT_TIPO_INMUEBLE.Properties.NID_TIPO, CAT_TIPO_INMUEBLE.Properties.V_TIPO);
                cmbTipoBien.Items.Insert(0, new ListItem(String.Empty));

                //tipo uso
                blld__l_CAT_USO_INMUEBLE oTipoUso = new blld__l_CAT_USO_INMUEBLE();
                oTipoUso.select();
                cmbTipoUso.DataBind(oTipoUso.lista_CAT_USO_INMUEBLE, CAT_USO_INMUEBLE.Properties.NID_USO, CAT_USO_INMUEBLE.Properties.V_USO);
                cmbTipoUso.Items.Insert(0, new ListItem(String.Empty));
                cmbTipoUso.SelectedIndex = 1;

                //valor adquisicion
                blld__l_CAT_VALOR_ADQUISICION oValorAdquisicion = new blld__l_CAT_VALOR_ADQUISICION();
                oValorAdquisicion.select();
                cmbValorAdquisicion.DataBind(oValorAdquisicion.lista_CAT_VALOR_ADQUISICION, CAT_VALOR_ADQUISICION.Properties.NID_VALOR_ADQUISICION, CAT_VALOR_ADQUISICION.Properties.V_VALOR_ADQUISICION);
                cmbValorAdquisicion.Items.Insert(0, new ListItem(String.Empty));

                //relacion_transmisor
                blld__l_CAT_RELACION_TRANSMISOR oRelacionTransmisor = new blld__l_CAT_RELACION_TRANSMISOR();
                oRelacionTransmisor.select();
                cmbRelacionTransmisor.DataBind(oRelacionTransmisor.lista_CAT_RELACION_TRANSMISOR, CAT_RELACION_TRANSMISOR.Properties.NID_RELACION_TRANSMISOR, CAT_RELACION_TRANSMISOR.Properties.V_RELACION_TRANSMISOR);
                cmbRelacionTransmisor.Items.Insert(0, new ListItem(String.Empty));

                //forma de adquisicion
                blld__l_CAT_FORMA_ADQUISICION oFormaAdquisicion = new blld__l_CAT_FORMA_ADQUISICION();
                oFormaAdquisicion.select();
                cmbFormaAdquisicionInmueble.DataBind(oFormaAdquisicion.lista_CAT_FORMA_ADQUISICION, CAT_FORMA_ADQUISICION.Properties.NID_FORMA_ADQUISICION, CAT_FORMA_ADQUISICION.Properties.V_FORMA_ADQUISICION);
                cmbFormaAdquisicionInmueble.Items.Insert(0, new ListItem(String.Empty));

                //forma de pago
                blld__l_CAT_FORMA_PAGO oFormaPago = new blld__l_CAT_FORMA_PAGO();
                oFormaPago.select();
                cmbFormaPagoInmueble.DataBind(oFormaPago.lista_CAT_FORMA_PAGO, CAT_FORMA_PAGO.Properties.NID_FORMA_PAGO, CAT_FORMA_PAGO.Properties.V_FORMA_PAGO);
                cmbFormaPagoInmueble.Items.Insert(0, new ListItem(String.Empty));

                //
                blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
                oCAT_PAIS.select();

                cmbPaisInmueble.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbPaisInmueble.Items.Insert(0, new ListItem(String.Empty));
                cmbPaisInmueble.SelectedIndex = 0;
                //cmbPaisInmueble_SelectedIndexChanged(sender, e);


                //Dependientes      Ubaldo
                //blld__l_CAT_TIPO_DEPENDIENTES oCAT_TIPO_DEPENDIENTES = new blld__l_CAT_TIPO_DEPENDIENTES();
                //oCAT_TIPO_DEPENDIENTES.Select();
                //chbDependietes.DataBind(oCAT_TIPO_DEPENDIENTES.lista_CAT_TIPO_DEPENDIENTES, CAT_TIPO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE, CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE, false);


                //chbDependietes.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                //chbDependietes.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                //chbDependietes.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                //chbDependietes.DataBind();
                chbDependietes.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietes.Items.Insert(1, new ListItem("Declarante y Cónyuge", "1"));
                chbDependietes.Items.Insert(2, new ListItem("Declarante y Cónyuge en Copropiedad con Terceros", "2"));
                chbDependietes.Items.Insert(3, new ListItem("Declarante en Copropiedad con Terceros", "3"));
                chbDependietes.Items.Insert(4, new ListItem("Declarante y Concubina o Concubinario", "4"));
                chbDependietes.Items.Insert(5, new ListItem("Declarante y Concubina o Concubinario en Copropiedad con Terceros", "5"));
                chbDependietes.Items.Insert(6, new ListItem("Cónyuge", "6"));
                chbDependietes.Items.Insert(7, new ListItem("Cónyuge en Copropiedad con Terceros", "7"));
                chbDependietes.Items.Insert(8, new ListItem("Concubina o Concubinario", "8"));
                chbDependietes.Items.Insert(9, new ListItem("Concubina o Concubinario en Copropiedad con Terceros", "9"));
                chbDependietes.Items.Insert(10, new ListItem("Conviviente", "10"));
                chbDependietes.Items.Insert(11, new ListItem("Declarante y Conviviente", "11"));
                chbDependietes.Items.Insert(12, new ListItem("Declarante y Conviviente en Copropiedad con Terceros", "12"));
                chbDependietes.Items.Insert(13, new ListItem("Conviviente y Dependiente Económico", "13"));
                chbDependietes.Items.Insert(14, new ListItem("Conviviente y Dependiente Económico en Copropiedad con Terceros", "14"));
                chbDependietes.Items.Insert(15, new ListItem("Dependiente Económico", "15"));
                chbDependietes.Items.Insert(16, new ListItem("Declarante y Dependiente Económico", "16"));
                chbDependietes.Items.Insert(17, new ListItem("Dependiente Económico en Copropiedad con Terceros", "17"));
                chbDependietes.Items.Insert(18, new ListItem("Declarante, Cónyuge y Dependiente Económico", "18"));
                chbDependietes.Items.Insert(19, new ListItem("Declarante, Concubina o Concubinario y Dependiente Económico", "19"));
                chbDependietes.Items.Insert(20, new ListItem("Cónyuge y Dependiente Económico", "20"));
                chbDependietes.Items.Insert(21, new ListItem("Concubina o Concubinario y Dependiente Económico", "21"));
                chbDependietes.Items.Insert(22, new ListItem("Cónyuge y Dependiente Económico en Copropiedad con Terceros", "22"));
                chbDependietes.Items.Insert(23, new ListItem("Concubina o Concubinario y Dependiente Económico en Copropiedad con Terceros", "23"));
                chbDependietes.Items.Insert(24, new ListItem("“Declarante y dependiente económico en copropiedad con terceros", "24"));
                chbDependietes.Items.Insert(chbDependietes.Items.Count, new ListItem("Copropietario", "-1"));

                //chbDependietes.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                //chbDependietes.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                //chbDependietes.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                //chbDependietes.DataBind();
                //chbDependietes.Items.Insert(0, new ListItem("Declarante", "0"));
                //chbDependietes.Items.Insert(chbDependietes.Items.Count, new ListItem("Copropietario", "-1"));
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
                ((Item)item).TextoSecundario = i.V_CALLE + " " + i.V_NUMERO_EXTERNO;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", i.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grdInmueble.Controls.AddAt(0 + x, item);
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
                oTipoMueble.L_ACTIVO = true;
                oTipoMueble.select();
                dpTipoBienMueble.DataBind(oTipoMueble.lista_CAT_TIPO_MUEBLE, CAT_TIPO_MUEBLE.Properties.NID_TIPO, CAT_TIPO_MUEBLE.Properties.V_TIPO);
                dpTipoBienMueble.Items.Insert(0, new ListItem(String.Empty));
                dpTipoBienMueble.Items.RemoveAt(6);

                //relacion_transmisor
                blld__l_CAT_RELACION_TRANSMISOR oRelacionTransmisorMueble = new blld__l_CAT_RELACION_TRANSMISOR();
                oRelacionTransmisorMueble.select();
                cmbRelacionTransmisorMueble.DataBind(oRelacionTransmisorMueble.lista_CAT_RELACION_TRANSMISOR, CAT_RELACION_TRANSMISOR.Properties.NID_RELACION_TRANSMISOR, CAT_RELACION_TRANSMISOR.Properties.V_RELACION_TRANSMISOR);
                cmbRelacionTransmisorMueble.Items.Insert(0, new ListItem(String.Empty));

                //forma de adquisicion
                blld__l_CAT_FORMA_ADQUISICION oFormaAdquisicionMueble = new blld__l_CAT_FORMA_ADQUISICION();
                oFormaAdquisicionMueble.select();
                cmbFormaAdquisicionMueble.DataBind(oFormaAdquisicionMueble.lista_CAT_FORMA_ADQUISICION, CAT_FORMA_ADQUISICION.Properties.NID_FORMA_ADQUISICION, CAT_FORMA_ADQUISICION.Properties.V_FORMA_ADQUISICION);
                cmbFormaAdquisicionMueble.Items.Insert(0, new ListItem(String.Empty));

                //forma de pago
                blld__l_CAT_FORMA_PAGO oFormaPagoMueble = new blld__l_CAT_FORMA_PAGO();
                oFormaPagoMueble.select();
                cmbFormaPagoMueble.DataBind(oFormaPagoMueble.lista_CAT_FORMA_PAGO, CAT_FORMA_PAGO.Properties.NID_FORMA_PAGO, CAT_FORMA_PAGO.Properties.V_FORMA_PAGO);
                cmbFormaPagoMueble.Items.Insert(0, new ListItem(String.Empty));


                //Dependientes
                //chbDependietesMuebles.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                //chbDependietesMuebles.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                //chbDependietesMuebles.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                //chbDependietesMuebles.DataBind();
                //chbDependietesMuebles.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietesMuebles.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietesMuebles.Items.Insert(1, new ListItem("Declarante y Cónyuge", "1"));
                chbDependietesMuebles.Items.Insert(2, new ListItem("Declarante en Copropiedad con Terceros", "2"));
                chbDependietesMuebles.Items.Insert(3, new ListItem("Declarante y Concubina o Concubinario", "3"));
                chbDependietesMuebles.Items.Insert(4, new ListItem("Declarante y Concubina o Concubinario en Copropiedad con Terceros", "4"));
                chbDependietesMuebles.Items.Insert(5, new ListItem("Cónyuge", "5"));
                chbDependietesMuebles.Items.Insert(6, new ListItem("Cónyuge en Copropiedad con Terceros", "6"));
                chbDependietesMuebles.Items.Insert(7, new ListItem("Concubina o Concubinario", "7"));
                chbDependietesMuebles.Items.Insert(8, new ListItem("Concubina o Concubinario en Copropiedad con Terceros", "8"));
                chbDependietesMuebles.Items.Insert(9, new ListItem("Conviviente", "9"));
                chbDependietesMuebles.Items.Insert(10, new ListItem("Declarante y Conviviente", "10"));
                chbDependietesMuebles.Items.Insert(11, new ListItem("Declarante y Conviviente en Copropiedad con Terceros", "11"));
                chbDependietesMuebles.Items.Insert(12, new ListItem("Conviviente y Dependiente Económico", "12"));
                chbDependietesMuebles.Items.Insert(13, new ListItem("Conviviente y Dependiente Económico en Copropiedad con Terceros", "13"));
                chbDependietesMuebles.Items.Insert(14, new ListItem("Dependiente Económico", "14"));
                chbDependietesMuebles.Items.Insert(15, new ListItem("Declarante y Dependiente Económico", "15"));
                chbDependietesMuebles.Items.Insert(16, new ListItem("Dependiente Económico en Copropiedad con Terceros", "16"));
                chbDependietesMuebles.Items.Insert(17, new ListItem("Declarante, Cónyuge y Dependiente Económico", "17"));
                chbDependietesMuebles.Items.Insert(18, new ListItem("Declarante, Concubina o Concubinario y Dependiente Económico", "18"));
                chbDependietesMuebles.Items.Insert(19, new ListItem("Cónyuge y Dependiente Económico", "19"));
                chbDependietesMuebles.Items.Insert(20, new ListItem("Concubina o Concubinario y Dependiente Económico", "20"));
                chbDependietesMuebles.Items.Insert(21, new ListItem("Cónyuge y Dependiente Económico en Copropiedad con Terceros", "21"));
                chbDependietesMuebles.Items.Insert(22, new ListItem("Concubina o Concubinario y Dependiente Económico en Copropiedad con Terceros", "22"));
                chbDependietesMuebles.Items.Insert(23, new ListItem("Declarante y Cónyuge en Copropiedad con Terceros", "23"));
                chbDependietesMuebles.Items.Insert(24, new ListItem(" Declarante y dependiente económico en copropiedad con terceros", "24"));
                chbDependietesMuebles.Items.Insert(chbDependietesMuebles.Items.Count, new ListItem("Copropietario", "-1"));

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
                grdMueble.Controls.AddAt(0 + x, item);
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
                cmbMarca.Items.Insert(0, new ListItem(String.Empty));

                dpModelo.DataSource = oUsuario.CAT_AGNO;
                dpModelo.DataBind();
                blld__l_CAT_TIPO_VEHICULO oTipo = new blld__l_CAT_TIPO_VEHICULO();
                oTipo.select();
                cmbTipoVehiculo.DataBind(oTipo.lista_CAT_TIPO_VEHICULO, CAT_TIPO_VEHICULO.Properties.NID_TIPO_VEHICULO, CAT_TIPO_VEHICULO.Properties.V_TIPO_VEHICULO);
                cmbTipoVehiculo.Items.Insert(0, new ListItem(String.Empty));
                cmbTipoVehiculo.Items.RemoveAt(4);

                blld__l_CAT_USO_VEHICULO oUV = new blld__l_CAT_USO_VEHICULO();
                oUV.select();
                dpTipoUso.DataBind(oUV.lista_CAT_USO_VEHICULO, CAT_USO_VEHICULO.Properties.NID_USO, CAT_USO_VEHICULO.Properties.V_USO);
                dpTipoUso.Items.Insert(0, new ListItem(String.Empty));
                dpTipoUso.SelectedIndex = 1;

                blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
                oCAT_PAIS.select();
                cmbPaisVehiculo.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbPaisVehiculo.Items.Insert(0, new ListItem(String.Empty));
                cmbPaisVehiculo.SelectedIndex = 0;

                //relacion_transmisor
                blld__l_CAT_RELACION_TRANSMISOR oRelacionTransmisorVehiculo = new blld__l_CAT_RELACION_TRANSMISOR();
                oRelacionTransmisorVehiculo.select();
                cmbRelacionTransmisorVehiculo.DataBind(oRelacionTransmisorVehiculo.lista_CAT_RELACION_TRANSMISOR, CAT_RELACION_TRANSMISOR.Properties.NID_RELACION_TRANSMISOR, CAT_RELACION_TRANSMISOR.Properties.V_RELACION_TRANSMISOR);
                cmbRelacionTransmisorVehiculo.Items.Insert(0, new ListItem(String.Empty));

                //forma de adquisicion
                blld__l_CAT_FORMA_ADQUISICION oFormaAdquisicionVehiculo = new blld__l_CAT_FORMA_ADQUISICION();
                oFormaAdquisicionVehiculo.select();
                cmbFormaAdquisicionVehiculo.DataBind(oFormaAdquisicionVehiculo.lista_CAT_FORMA_ADQUISICION, CAT_FORMA_ADQUISICION.Properties.NID_FORMA_ADQUISICION, CAT_FORMA_ADQUISICION.Properties.V_FORMA_ADQUISICION);
                cmbFormaAdquisicionVehiculo.Items.Insert(0, new ListItem(String.Empty));

                //forma de pago
                blld__l_CAT_FORMA_PAGO oFormaPagoVehiculo = new blld__l_CAT_FORMA_PAGO();
                oFormaPagoVehiculo.select();
                cmbFormaPagoVehiculo.DataBind(oFormaPagoVehiculo.lista_CAT_FORMA_PAGO, CAT_FORMA_PAGO.Properties.NID_FORMA_PAGO, CAT_FORMA_PAGO.Properties.V_FORMA_PAGO);
                cmbFormaPagoVehiculo.Items.Insert(0, new ListItem(String.Empty));


                //chbDependietesVehiculo.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                //chbDependietesVehiculo.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                //chbDependietesVehiculo.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                //chbDependietesVehiculo.DataBind();
                //chbDependietesVehiculo.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietesVehiculo.Items.Insert(0, new ListItem("Declarante", "0"));
                chbDependietesVehiculo.Items.Insert(1, new ListItem("Declarante y Cónyuge", "1"));
                chbDependietesVehiculo.Items.Insert(2, new ListItem("Declarante en Copropiedad con Terceros", "2"));
                chbDependietesVehiculo.Items.Insert(3, new ListItem("Declarante y Concubina o Concubinario", "3"));
                chbDependietesVehiculo.Items.Insert(4, new ListItem("Declarante y Concubina o Concubinario en Copropiedad con Terceros", "4"));
                chbDependietesVehiculo.Items.Insert(5, new ListItem("Cónyuge", "5"));
                chbDependietesVehiculo.Items.Insert(6, new ListItem("Cónyuge en Copropiedad con Terceros", "6"));
                chbDependietesVehiculo.Items.Insert(7, new ListItem("Concubina o Concubinario", "7"));
                chbDependietesVehiculo.Items.Insert(8, new ListItem("Concubina o Concubinario en Copropiedad con Terceros", "8"));
                chbDependietesVehiculo.Items.Insert(9, new ListItem("Conviviente", "9"));
                chbDependietesVehiculo.Items.Insert(10, new ListItem("Declarante y Conviviente", "10"));
                chbDependietesVehiculo.Items.Insert(11, new ListItem("Declarante y Conviviente en Copropiedad con Terceros", "11"));
                chbDependietesVehiculo.Items.Insert(12, new ListItem("Conviviente y Dependiente Económico", "12"));
                chbDependietesVehiculo.Items.Insert(13, new ListItem("Conviviente y Dependiente Económico en Copropiedad con Terceros", "13"));
                chbDependietesVehiculo.Items.Insert(14, new ListItem("Dependiente Económico", "14"));
                chbDependietesVehiculo.Items.Insert(15, new ListItem("Declarante y Dependiente Económico", "15"));
                chbDependietesVehiculo.Items.Insert(16, new ListItem("Dependiente Económico en Copropiedad con Terceros", "16"));
                chbDependietesVehiculo.Items.Insert(17, new ListItem("Declarante, Cónyuge y Dependiente Económico", "17"));
                chbDependietesVehiculo.Items.Insert(18, new ListItem("Declarante, Concubina o Concubinario y Dependiente Económico", "18"));
                chbDependietesVehiculo.Items.Insert(19, new ListItem("Cónyuge y Dependiente Económico", "19"));
                chbDependietesVehiculo.Items.Insert(20, new ListItem("Concubina o Concubinario y Dependiente Económico", "20"));
                chbDependietesVehiculo.Items.Insert(21, new ListItem("Cónyuge y Dependiente Económico en Copropiedad con Terceros", "21"));
                chbDependietesVehiculo.Items.Insert(22, new ListItem("Concubina o Concubinario y Dependiente Económico en Copropiedad con Terceros", "22"));
                chbDependietesVehiculo.Items.Insert(23, new ListItem("Declarante y Cónyuge en Copropiedad con Terceros", "23"));
                chbDependietesVehiculo.Items.Insert(24, new ListItem(" Declarante y dependiente económico en copropiedad con terceros", "24"));
                chbDependietesVehiculo.Items.Insert(chbDependietesVehiculo.Items.Count, new ListItem("Copropietario", "-1"));
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
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_VEHICULO/", v.NID_TIPO_VEHICULO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grdVehiculos.Controls.AddAt(0 + x, item);
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

                txtFechaAfquisicion_C.StartDate = new DateTime(1900, 1, 1);
                txtFechaAfquisicion_C.EndDate = DateTime.Today.AddDays(-1);

                switch (SubSeccionActiva)
                {
                    case SubSecciones.BienesInmuebles:

                        ((Button)Master.FindControl("btnAnterior")).Visible = true;
                        ViewState["SubSeccionActiva"] = SubSecciones.BienesInmuebles;
                        //ltrSubTitulo.Text = "Bienes - Inmuebles";
                        ltrSubTitulo.Text = "10. Bienes Inmuebles (situación actual) </br><h6> Todos los datos de bienes declarados a nombre de la pareja, dependientes económicos y/o terceros o que sean en copropiedad con el declarante no serán públicos  </br> Bienes del declarante, pareja y/o dependientes económicos";
                        pnlBienesInmuebles.Visible = true;
                        pnlOtrosBienes.Visible = false;
                        pnlVehiculos.Visible = false;
                        //oevm abril 2023
                        //if (oDeclaracion.ALTA.ALTA_INMUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                        //    QstBoxInm.Ask("¿Tiene Bienes Inmuebles que registrar?");
                        break;

                    case SubSecciones.OtrosBienes:
                        ((Button)Master.FindControl("btnAnterior")).Visible = true;
                        ViewState["SubSeccionActiva"] = SubSecciones.OtrosBienes;
                        // ltrSubTitulo.Text = "Bienes - Otros Bienes Muebles";
                        ltrSubTitulo.Text = "12. Bienes muebles (situación actual)</br><h6> Todos los datos de bienes declarados a nombre de la pareja, dependientes económicos y/o terceros o que sean en copropiedad con el declarante no serán públicos </br> Bienes del declarante, pareja y/o dependientes económicos";
                        pnlBienesInmuebles.Visible = false;
                        pnlOtrosBienes.Visible = true;
                        pnlVehiculos.Visible = false;
                        //oevm abril 2023
                        //if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                            //QstBoxMue.Ask("¿Tiene Otros Bienes Muebles que registrar?");
                        break;
                    case SubSecciones.Vehiculos:
                        ((Button)Master.FindControl("btnAnterior")).Visible = true;
                        ViewState["SubSeccionActiva"] = SubSecciones.Vehiculos;
                        //ltrSubTitulo.Text = "Bienes - Vehículos";
                        ltrSubTitulo.Text = "11. Vehículos (situación actual)</br><h6> Todos los datos de vehículos declarados a nombre de la pareja, dependientes económicos y/o terceros o que sean en copropiedad con el declarante no serán públicos </br> Vehículos del declarante, pareja y/o dependientes económicos";
                        pnlBienesInmuebles.Visible = false;
                        pnlOtrosBienes.Visible = false;
                        pnlVehiculos.Visible = true;
                        //oevm abril 2023
                        //if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                        //    QstBoxVehic.Ask("¿Tiene vehículos que registrar?");
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

            }
            ((HtmlControl)Master.FindControl("liBienes")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu2")).Attributes.Add("class", "tab-pane fade level1 active in");

        }

        public void Anterior()
        {
            switch (SubSeccionActiva)
            {
                case SubSecciones.BienesInmuebles:
                    //HttpContext.Current.Items.Add("subSeccion", DatosGenerales.SubSecciones.DependienteEconomicos);
                    //Response.Redirect("DatosGenerales.aspx");
                    Response.Redirect("Desemp.aspx");
                    break;

                case SubSecciones.OtrosBienes:
                    //blld_DECLARACION oDeclaracion = _oDeclaracion;
                    //if (oDeclaracion.ALTA.ALTA_INMUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                    //    QstBoxInm.Ask("¿Tiene Bienes Inmuebles que registrar?");
                    ltrSubTitulo.Text = "11. Vehículos (situación actual)</br><h6> Todos los datos de vehículos declarados a nombre de la pareja, dependientes económicos y/o terceros o que sean en copropiedad con el declarante no serán públicos </br> Vehículos del declarante, pareja y/o dependientes económicos";
                    ((Button)Master.FindControl("btnAnterior")).Visible = true;
                    //pnlBienesInmuebles.Visible = true;
                    //pnlOtrosBienes.Visible = false;
                    //pnlVehiculos.Visible = false;
                    //SubSeccionActiva = SubSecciones.BienesInmuebles;
                    //break;
                    pnlBienesInmuebles.Visible = false;
                    pnlOtrosBienes.Visible = false;
                    pnlVehiculos.Visible = true;
                    SubSeccionActiva = SubSecciones.Vehiculos;
                    break;


                case SubSecciones.Vehiculos:
                    blld_DECLARACION oDeclaracion = _oDeclaracion;
                    if (oDeclaracion.ALTA.ALTA_INMUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                        QstBoxInm.Ask("¿Tiene Bienes Inmuebles que registrar?");
                    ltrSubTitulo.Text = "10. Bienes inmuebles (situación actual)</br><h6> Todos los datos de bienes declarados a nombre de la pareja, dependientes económicos y/o terceros o que sean en copropiedad con el declarante no serán públicos  </br> Bienes del declarante, pareja y/o dependientes económicos";
                    ((Button)Master.FindControl("btnAnterior")).Visible = true;
                    //pnlBienesInmuebles.Visible = false;
                    //pnlOtrosBienes.Visible = true;
                    //pnlVehiculos.Visible = false;
                    //SubSeccionActiva = SubSecciones.OtrosBienes;
                    //break;
                    pnlBienesInmuebles.Visible = true;
                    pnlOtrosBienes.Visible = false;
                    pnlVehiculos.Visible = false;
                    SubSeccionActiva = SubSecciones.BienesInmuebles;
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
                    {
                        //oevm abril 2023
                        marcaApartado(ref oDeclaracion, 8);
                    }
                    else
                    {
                        marcaApartado(ref oDeclaracion, 8);
                    }
                    ltrSubTitulo.Text = "11. Vehículos(situación actual)</br><h6> Todos los datos de vehículos declarados a nombre de la pareja, dependientes económicos y/o terceros o que sean en copropiedad con el declarante no serán públicos </br> Vehículos del declarante, pareja y/o dependientes económicos";
                    ((Button)Master.FindControl("btnAnterior")).Visible = true;
                    pnlBienesInmuebles.Visible = false;
                    // pnlOtrosBienes.Visible = true;

                    pnlOtrosBienes.Visible = false;
                    //pnlVehiculos.Visible = false;
                    pnlVehiculos.Visible = true;
                    // SubSeccionActiva = SubSecciones.OtrosBienes;
                    SubSeccionActiva = SubSecciones.Vehiculos;

                    //if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                    //    QstBoxMue.Ask("¿Tiene Otros Bienes Muebles que registrar?");
                    //oevm abril 2023
                    //if (oDeclaracion.ALTA.ALTA_VEHICULOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                    //    QstBoxVehic.Ask("¿Tiene vehículos que registrar?");
                    break;

                //case SubSecciones.OtrosBienes:
                //    if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                //    { }
                //    else
                //    {
                //        marcaApartado(ref oDeclaracion, 9);
                //    }
                //        ltrSubTitulo.Text = "Bienes - Vehículos ";
                //        ((Button)Master.FindControl("btnAnterior")).Visible = true;
                //        pnlBienesInmuebles.Visible = false;
                //        pnlOtrosBienes.Visible = false;
                //        pnlVehiculos.Visible = true;
                //        SubSeccionActiva = SubSecciones.Vehiculos;
                //        if (oDeclaracion.ALTA.ALTA_VEHICULOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                //            QstBoxVehic.Ask("¿Tiene vehículos que registrar?");

                //    break;
                case SubSecciones.OtrosBienes:
                    if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                    {
                        //oevm abril 2023
                        marcaApartado(ref oDeclaracion, 9);
                    }
                    else
                    {
                        marcaApartado(ref oDeclaracion, 9);
                    }
                    Response.Redirect("Inversiones.aspx");
                    break;

                case SubSecciones.Vehiculos:
                    if (oDeclaracion.ALTA.ALTA_VEHICULOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                    {
                        //oevm abril 2023
                        marcaApartado(ref oDeclaracion, 10);
                    }
                    else
                    {
                        marcaApartado(ref oDeclaracion, 10);
                    }
                    // Response.Redirect("Inversiones.aspx");
                    ltrSubTitulo.Text = "12. Bienes muebles (situación actual)</br><h6> Todos los datos de bienes declarados a nombre de la pareja, dependientes económicos y/o terceros o que sean en copropiedad con el declarante no serán públicos </br> Bienes del declarante, pareja y/o dependientes económicos";
                    ((Button)Master.FindControl("btnAnterior")).Visible = true;
                    pnlBienesInmuebles.Visible = false;
                    pnlOtrosBienes.Visible = true;
                    pnlVehiculos.Visible = false;
                    SubSeccionActiva = SubSecciones.OtrosBienes;
                    //if (oDeclaracion.ALTA.ALTA_MUEBLEs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                    //    QstBoxMue.Ask("¿Tiene Otros Bienes Muebles que registrar?");
                    break;

            }
            active();
            _oDeclaracion = oDeclaracion;
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
                    txtF_BAJA_INM.Text = string.Empty;
                    cmbInmuMotivoBajaInmu.ClearSelection();
                    mppInmuebles.HeaderText = "Editar inmueble";
                    mppInmuebles.Show(true);
                    i = oDeclaracion.ALTA.ALTA_INMUEBLEs[e.Id];
                    IndiceItemSeleccionado = e.Id;
                    chbDependietes.ClearSelection();
                    cmbTipoBien.SelectedValue = i.NID_TIPO.ToString();
                    //txtUbicacionInmueble.Text = i.E_UBICACION.ToString();
                    numbertxtSuperficieTerreno.Text = i.N_TERRENO.ToString();
                    numbertxtSuperficieConstruccion.Text = i.N_CONSTRUCCION.ToString();
                    txtFechaAfquisicion.Text = i.F_ADQUISICION.ToString(strFormatoFecha);
                    moneytxtValorAdqusicion.Text = i.M_VALOR_INMUEBLE.ToString();
                    InmuebleSeccionTipoBien(i.N_CONSTRUCCION.ToString());
                    cmbTipoUso.SelectedValue = i.NID_USO.ToString();
                    numbertxtPorcentajeDeclarante.Text = i.N_PORCENTAJE_DECLARANTE.ToString();
                    txtTipoMoneda.Text = i.V_TIPO_MONEDA.ToString();
                    try { ddlTipoMonedaInm.SelectedValue = i.V_TIPO_MONEDA.ToString().Split('|')[0]; } catch { }
                    cmbFormaAdquisicionInmueble.SelectedValue = i.NID_FORMA_ADQUISICION.ToString();
                    cmbFormaPagoInmueble.SelectedValue = i.NID_FORMA_PAGO.ToString();
                    txtRegistroPublicoPropiedad.Text = i.E_REGISTRO_PUBLICO_PROPIEDAD.ToString();
                    cmbValorAdquisicion.SelectedValue = i.NID_VALOR_ADQUISICION.ToString();
                    cmbTransmisor.SelectedValue = i.CID_TIPO_PERSONA_TRANSMISOR.ToString();

                    try { txtNombreTransmisor.Text = i.E_NOMBRE_TRANSMISOR.ToString().Split('|')[0]; } catch { }
                    try { cmbInmuMotivoBajaInmu.SelectedValue = i.E_NOMBRE_TRANSMISOR.ToString().Split('|')[1]; } catch { }
                    // txtNombreTransmisor.Text = i.E_NOMBRE_TRANSMISOR.ToString();
                    try
                    {
                        txtF_BAJA_INM.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == i.NID_PATRIMONIO).First().F_BAJA.ToString(Pagina.strFormatoFecha);
                    }
                    catch { }

                    txtRFCTransmisor.Text = i.E_RFC_TRANSMISOR.ToString();
                    cmbRelacionTransmisor.SelectedValue = i.NID_RELACION_TRANSMISOR.ToString();
                    txtObservacionesBienesInmuebles.Text = i.E_OBSERVACIONES.ToString();
                    txtcCodigoPostalInmueble.Text = i.V_CODIGO_POSTAL;
                    cmbPaisInmueble.SelectedValue = i.V_PAIS;
                    cmbPaisInmueble_SelectedIndexChanged(cmbPaisInmueble, null);
                    cmbEntidadFederativaInmueble.SelectedValue = i.V_ENTIDAD_FEDERATIVA;
                    cmbEntidadFederativaInmueble_SelectedIndexChanged(cmbEntidadFederativaInmueble, null);
                    cmbMunicipioInmueble.SelectedValue = i.V_MUNICIPIO;
                    txtColoniaInmueble.Text = i.V_COLONIA;
                    txtCalleInmueble.Text = i.V_CALLE;
                    txtNumeroExteriorInmueble.Text = i.V_NUMERO_EXTERNO;
                    txtNumeroInteriorInmueble.Text = i.V_NUMERO_INTERNO;

                    if (String.IsNullOrEmpty(i.ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONA))
                    {
                        cmbTercero.ClearSelection();
                        txtNombreTercero.Text = String.Empty;
                        txtRFCTercero.Text = String.Empty;
                    }
                    else
                    {
                        cmbTercero.SelectedValue = i.ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONA.ToString();
                        txtNombreTercero.Text = i.ALTA_INMUEBLE_COPROPIETARIO.V_NOMBRE;
                        txtRFCTercero.Text = i.ALTA_INMUEBLE_COPROPIETARIO.V_RFC;
                    }

                    checaAdeudoImueble();
                    chbDependietes.ClearSelection();
                    chbDependietesInm.SelectedValue = i.ALTA_INMUEBLE_TITULARs.First().NID_DEPENDIENTE.ToString();

                    chbDependietesInm_SelectedIndexChanged(sender, e);
                    foreach (blld_ALTA_INMUEBLE_TITULAR item in i.ALTA_INMUEBLE_TITULARs)
                    {
                        chbDependietes.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
                    break;

                case SubSecciones.OtrosBienes:

                    blld_ALTA_MUEBLE m;
                    lEditar = true;
                    txtF_BAJA_MUEB.Text = string.Empty;
                    cmbMotivoBaja.ClearSelection();
                    mppMuebles.HeaderText = "Editar bien mueble";
                    mppMuebles.Show(true);
                    m = oDeclaracion.ALTA.ALTA_MUEBLEs[e.Id];
                    IndiceItemSeleccionado = e.Id;

                    dpTipoBienMueble.SelectedValue = m.NID_TIPO.ToString();
                    txtEspecifica.Text = m.E_ESPECIFICACION.ToString();
                    moneytxtValorAdqusicionMueble.Text = m.M_VALOR.ToString();
                    txtF_ADQUISICION.Text = m.F_ADQUISICION.ToString(strFormatoFecha);

                    txtTipoMonedaMueble.Text = m.V_TIPO_MONEDA.ToString();
                    try { ddlTipoMonedaMue.SelectedValue = m.V_TIPO_MONEDA.ToString().Split('|')[0]; } catch { }
                    cmbFormaAdquisicionMueble.SelectedValue = m.NID_FORMA_ADQUISICION.ToString();
                    cmbFormaPagoMueble.SelectedValue = m.NID_FORMA_PAGO.ToString();

                    cmbTransmisorMueble.SelectedValue = m.CID_TIPO_PERSONA_TRANSMISOR.ToString();

                    try { txtNombreTransmisorMueble.Text = m.E_NOMBRE_TRANSMISOR.ToString().Split('|')[0]; } catch { }
                    try { cmbMotivoBaja.SelectedValue = m.E_NOMBRE_TRANSMISOR.ToString().Split('|')[1]; } catch { }
                    //txtNombreTransmisorMueble.Text = m.E_NOMBRE_TRANSMISOR.ToString();
                    try { txtF_BAJA_MUEB.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == m.NID_PATRIMONIO).First().F_BAJA.ToString(Pagina.strFormatoFecha); } catch { }

                    txtRFCTransmisorMueble.Text = m.E_RFC_TRANSMISOR.ToString();
                    cmbRelacionTransmisorMueble.SelectedValue = m.NID_RELACION_TRANSMISOR.ToString();
                    txtObservacionesBienesMuebles.Text = m.E_OBSERVACIONES.ToString();

                    if (String.IsNullOrEmpty(m.ALTA_MUEBLE_COPROPIETARIO.CID_TIPO_PERSONA))
                    {
                        cmbTerceroMueble.ClearSelection();
                        txtNombreTerceroMueble.Text = String.Empty;
                        txtRFCTerceroMueble.Text = String.Empty;
                    }
                    else
                    {
                        cmbTerceroMueble.SelectedValue = m.ALTA_MUEBLE_COPROPIETARIO.CID_TIPO_PERSONA.ToString();
                        txtNombreTerceroMueble.Text = m.ALTA_MUEBLE_COPROPIETARIO.V_NOMBRE;
                        txtRFCTerceroMueble.Text = m.ALTA_MUEBLE_COPROPIETARIO.V_RFC;
                    }
                    chbDependietesMuebles.ClearSelection();
                    chbDependietesMue.SelectedValue = m.ALTA_MUEBLE_TITULARs.First().NID_DEPENDIENTE.ToString();
                    chbDependietesMue_SelectedIndexChanged(sender, e);
                    foreach (blld_ALTA_MUEBLE_TITULAR item in m.ALTA_MUEBLE_TITULARs)
                    {
                        chbDependietesMuebles.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
                    break;
                case SubSecciones.Vehiculos:

                    blld_ALTA_VEHICULO v;
                    lEditar = true;
                    txtF_BAJA_VEHIC.Text = string.Empty;
                    cmbVehiMotivoBaja.ClearSelection();

                    mppVehículos.HeaderText = "Editar vehículo";
                    mppVehículos.Show(true);
                    v = oDeclaracion.ALTA.ALTA_VEHICULOs[e.Id];
                    IndiceItemSeleccionado = e.Id;

                    cmbMarca.SelectedValue = v.NID_MARCA.ToString();
                    cmbTipoVehiculo.SelectedValue = v.NID_TIPO_VEHICULO.ToString();
                    txtTipo.Text = v.V_DESCRIPCION.ToString();
                    txtFechaAdquisicionVehiculo.Text = v.F_ADQUISICION.ToString(strFormatoFecha);
                    dpModelo.SelectedValue = v.C_MODELO.ToString();
                    moneytxtValorAdquisicion.Text = v.M_VALOR_VEHICULO.ToString();
                    dpTipoUso.SelectedValue = v.NID_USO.ToString();


                    cmbPaisVehiculo.SelectedValue = v.NID_PAIS.ToString();
                    cmbPaisVehiculo_SelectedIndexChanged(sender, null);
                    //cmbPaisVehiculo_SelectedIndexChanged(cmbPaisVehiculo, null);
                    cmbEntidadFederativaVehiculo.SelectedValue = v.CID_ENTIDAD_FEDERATIVA;

                    txtTipoMonedaVehiculo.Text = v.V_TIPO_MONEDA.ToString();
                    try { ddlTipoMonedaVeh.SelectedValue = v.V_TIPO_MONEDA.ToString().Split('|')[0]; } catch { }
                    txtNumeroSerie.Text = v.E_NUMERO_SERIE.ToString();
                    cmbFormaAdquisicionVehiculo.SelectedValue = v.NID_FORMA_ADQUISICION.ToString();
                    cmbFormaPagoVehiculo.SelectedValue = v.NID_FORMA_PAGO.ToString();

                    cmbTransmisorVehiculo.SelectedValue = v.CID_TIPO_PERSONA_TRANSMISOR.ToString();


                    //txtNombreTransmisor
                    // Se regreso el día 15/01/2020
                    // txtNombreTransmisorVehiculo.Text = v.E_NOMBRE_TRANSMISOR.ToString();
                    try { txtNombreTransmisorVehiculo.Text = v.E_NOMBRE_TRANSMISOR.ToString().Split('|')[0]; } catch { }
                    try { cmbVehiMotivoBaja.SelectedValue = v.E_NOMBRE_TRANSMISOR.ToString().Split('|')[1]; } catch { }
                    try { txtF_BAJA_VEHIC.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == v.NID_PATRIMONIO).First().F_BAJA.ToString(Pagina.strFormatoFecha); } catch { }

                    txtRFCTransmisorVehiculo.Text = v.E_RFC_TRANSMISOR.ToString();
                    cmbRelacionTransmisorVehiculo.SelectedValue = v.NID_RELACION_TRANSMISOR.ToString();
                    txtObservacionesVehiculos.Text = v.E_OBSERVACIONES.ToString();

                    if (String.IsNullOrEmpty(v.ALTA_VEHICULO_COPROPIETARIO.CID_TIPO_PERSONA))
                    {
                        cmbTerceroVehiculo.ClearSelection();
                        txtNombreTerceroVehiculo.Text = String.Empty;
                        txtRFCTerceroVehiculo.Text = String.Empty;
                    }
                    else
                    {
                        cmbTerceroVehiculo.SelectedValue = v.ALTA_VEHICULO_COPROPIETARIO.CID_TIPO_PERSONA.ToString();
                        txtNombreTerceroVehiculo.Text = v.ALTA_VEHICULO_COPROPIETARIO.V_NOMBRE;
                        txtRFCTerceroVehiculo.Text = v.ALTA_VEHICULO_COPROPIETARIO.V_RFC;
                    }

                    checaAdeudoVehiculo();
                    chbDependietesVehiculo.ClearSelection();
                    chbDependietesVeh.SelectedValue = v.ALTA_VEHICULO_TITULARs.First().NID_DEPENDIENTE.ToString();
                    chbDependietesVeh_SelectedIndexChanged(sender, e);
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
                        oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                        _oDeclaracion = oDeclaracion;
                        grdInmueble.Controls.Remove(grdInmueble.FindControl(String.Concat("Inmueble_", e.Id)));
                        AlertaSuperior.ShowSuccess("Se eliminó correctamente el inmueble");
                        active();
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
                    break;

                case SubSecciones.OtrosBienes:
                    try
                    {
                        oDeclaracion.ALTA.ALTA_MUEBLEs.RemoveAt(e.Id);
                        _oDeclaracion = oDeclaracion;
                        grdMueble.Controls.Remove(grdMueble.FindControl(String.Concat("Mueble_", e.Id)));
                        AlertaSuperior.ShowSuccess("Se eliminó correctamente el bien mueble");
                        active();
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
                    break;
                case SubSecciones.Vehiculos:
                    try
                    {
                        oDeclaracion.ALTA.ALTA_VEHICULOs.RemoveAt(e.Id);
                        oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                        _oDeclaracion = oDeclaracion;
                        grdVehiculos.Controls.Remove(grdVehiculos.FindControl(String.Concat("Vehiculo_", e.Id)));
                        AlertaSuperior.ShowSuccess("Se eliminó correctamente el vehículo");
                        active();
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

            txtF_BAJA_INM.Text = string.Empty;
            cmbInmuMotivoBajaInmu.ClearSelection();

            //txtUbicacionInmueble.Text = String.Empty;
            txtcCodigoPostalInmueble.Text = String.Empty;
            cmbPaisInmueble.ClearSelection();
            cmbPaisInmueble_SelectedIndexChanged(sender, e);
            cmbEntidadFederativaInmueble.ClearSelection();
            cmbMunicipioInmueble.ClearSelection();

            txtColoniaInmueble.Text = String.Empty;
            txtCalleInmueble.Text = String.Empty;
            txtNumeroExteriorInmueble.Text = String.Empty;
            txtNumeroInteriorInmueble.Text = String.Empty;
            numbertxtSuperficieTerreno.Text = String.Empty;
            numbertxtSuperficieConstruccion.Text = String.Empty;
            txtFechaAfquisicion.Text = String.Empty;
            moneytxtValorAdqusicion.Text = String.Empty;
            numbertxtPorcentajeDeclarante.Text = String.Empty;
            txtNombreTransmisor.Text = String.Empty;
            txtRFCTransmisor.Text = String.Empty;
            cmbTransmisor.ClearSelection();
            cmbRelacionTransmisor.ClearSelection();
            cmbFormaAdquisicionInmueble.ClearSelection();
            cmbFormaPagoInmueble.ClearSelection();
            txtTipoMoneda.Text = String.Empty;
            txtRegistroPublicoPropiedad.Text = String.Empty;
            cmbValorAdquisicion.ClearSelection();
            txtObservacionesBienesInmuebles.Text = String.Empty;
            cmbTercero.ClearSelection();
            txtNombreTercero.Text = String.Empty;
            txtRFCTercero.Text = String.Empty;
            checaAdeudoImueble();
            chbDependietes.ClearSelection();
            // cmbTipoUso.ClearSelection();
            cmbTipoBien.ClearSelection();
            cmbTipoBienSelect_Change(sender, e);
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
                String msg = "Se actualizaron correctamente los datos del inmueble";
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
            string Paso;
            String Paso1;
            chbDependietes.SelectedValue = chbDependietesInm.SelectedValue;
            try
            {
                Decimal SupCostruccion;
                Decimal PorcentajeDeclarante;
                String lvUbicacion;
                lvUbicacion = String.Concat(txtcCodigoPostalInmueble.Text, "|",
                                            cmbPaisInmueble.SelectedValue, "|",
                                            cmbEntidadFederativaInmueble.SelectedValue, "|",
                                            cmbMunicipioInmueble.SelectedValue, "|",
                                            txtColoniaInmueble.Text, "|",
                                            txtCalleInmueble.Text, "|",
                                            txtNumeroInteriorInmueble.Text, "|",
                                            txtNumeroExteriorInmueble.Text
                                            );
                if (String.IsNullOrEmpty(numbertxtSuperficieConstruccion.Text)) SupCostruccion = 0;
                else SupCostruccion = numbertxtSuperficieConstruccion.Decimal();

                if (String.IsNullOrEmpty(numbertxtPorcentajeDeclarante.Text)) PorcentajeDeclarante = 0;
                else PorcentajeDeclarante = numbertxtPorcentajeDeclarante.Decimal();

                if (cmbTransmisor.SelectedValue == "")
                {
                    Paso1 = "0";
                }
                else
                {
                    Paso1 = cmbTransmisor.SelectedValue.ToString();
                }
                if (txtRFCTransmisor.Text == "")

                    txtRFCTransmisor.Text = "  ";

                if (cmbRelacionTransmisor.SelectedValue.ToString() == "")
                {
                    Paso = "0";
                }
                else
                {
                    Paso = cmbRelacionTransmisor.SelectedValue.ToString();
                }
                if (txtNombreTransmisor.Text.Length == 0)
                    txtNombreTransmisor.Text = "  ";


                oDeclaracion.ALTA.Add_ALTA_INMUEBLEs(cmbTipoBien.SelectedValue()
                                                   , txtFechaAfquisicion.Date(esMX)
                                                   , 1
                                                   , Convert.ToInt32(cmbTipoUso.SelectedValue)
                                                   , lvUbicacion
                                                   , numbertxtSuperficieTerreno.Decimal()
                                                   , SupCostruccion
                                                   , moneytxtValorAdqusicion.Money()
                                                   , numbertxtPorcentajeDeclarante.Decimal()
                                                   //, cmbTransmisor.SelectedValue
                                                   , Paso1
                                                   , txtNombreTransmisor.Text + "|" + cmbInmuMotivoBajaInmu.SelectedValue.ToString() + "|" + cmbInmuMotivoBajaInmu.SelectedItem.Text
                                                   //, txtNombreTransmisor.Text 
                                                   , txtRFCTransmisor.Text
                                                   //, Convert.ToInt32(cmbRelacionTransmisor.SelectedValue)
                                                   , Convert.ToInt32(Paso)
                                                   , txtTipoMoneda.Text
                                                   , txtRegistroPublicoPropiedad.Text
                                                   , Convert.ToInt32(cmbValorAdquisicion.SelectedValue)
                                                   , Convert.ToInt32(cmbFormaAdquisicionInmueble.SelectedValue)
                                                   , Convert.ToInt32(cmbFormaPagoInmueble.SelectedValue)
                                                   , txtObservacionesBienesInmuebles.Text
                                                   , cmbTercero.SelectedValue
                                                   , txtNombreTercero.Text
                                                   , txtRFCTercero.Text
                                                   , chbDependietes.SelectedValuesInteger());
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

                if (txtF_BAJA_INM.Text.Length > 8)
                    oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(o.NID_PATRIMONIO, 1, txtF_BAJA_INM.Date(Pagina.esMX));

                int x = grdInmueble.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oDeclaracion.ALTA.ALTA_INMUEBLEs.Count - 1;
                ((Item)item).TextoPrincipal = o.V_TIPO;
                ((Item)item).TextoSecundario = o.V_CALLE + " " + o.V_NUMERO_EXTERNO; ;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", o.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grdInmueble.Controls.AddAt(x, item);

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
            oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
            _oDeclaracion = oDeclaracion;
            marcaApartado(ref oDeclaracion, 8);
        }

        private void EditarInmueble()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceItemSeleccionado;
            //String vcUbicacion;
            //vcUbicacion = String.Concat(txtcCodigoPostalInmueble.Text, "|",
            //                            cmbPaisInmueble.SelectedValue, "|",
            //                            cmbEntidadFederativaInmueble.SelectedValue, "|",
            //                            cmbMunicipioInmueble.SelectedValue, "|",
            //                            txtColoniaInmueble.Text, "|",
            //                            txtCalleInmueble.Text, "|",
            //                            txtNumeroExteriorInmueble.Text, "|",
            //                            txtNumeroInteriorInmueble.Text
            //                            );
            try
            {
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_TIPO = cmbTipoBien.SelectedValue();

                //oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].E_UBICACION = vcUbicacion;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_CODIGO_POSTAL = txtcCodigoPostalInmueble.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_PAIS = cmbPaisInmueble.SelectedValue;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_ENTIDAD_FEDERATIVA = cmbEntidadFederativaInmueble.SelectedValue;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_MUNICIPIO = cmbMunicipioInmueble.SelectedValue;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_COLONIA = txtColoniaInmueble.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_CALLE = txtCalleInmueble.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_NUMERO_INTERNO = txtNumeroInteriorInmueble.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_NUMERO_EXTERNO = txtNumeroExteriorInmueble.Text;


                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].N_TERRENO = numbertxtSuperficieTerreno.Decimal();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].N_CONSTRUCCION = numbertxtSuperficieConstruccion.Decimal();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].F_ADQUISICION = txtFechaAfquisicion.Date(Pagina.esMX);
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].M_VALOR_INMUEBLE = moneytxtValorAdqusicion.Money();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_USO = cmbTipoUso.SelectedValue();

                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_VALOR_ADQUISICION = cmbValorAdquisicion.SelectedValue();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].V_TIPO_MONEDA = txtTipoMoneda.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].E_REGISTRO_PUBLICO_PROPIEDAD = txtRegistroPublicoPropiedad.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].N_PORCENTAJE_DECLARANTE = numbertxtPorcentajeDeclarante.Decimal();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].CID_TIPO_PERSONA_TRANSMISOR = cmbTransmisor.SelectedValue;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].E_NOMBRE_TRANSMISOR = txtNombreTransmisor.Text + "|" + cmbInmuMotivoBajaInmu.SelectedValue.ToString() + "|" + cmbInmuMotivoBajaInmu.SelectedItem.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].E_RFC_TRANSMISOR = txtRFCTransmisor.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_RELACION_TRANSMISOR = cmbRelacionTransmisor.SelectedValue();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_FORMA_ADQUISICION = cmbFormaAdquisicionInmueble.SelectedValue();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_FORMA_PAGO = cmbFormaPagoInmueble.SelectedValue();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].E_OBSERVACIONES = txtObservacionesBienesInmuebles.Text;

                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONA = cmbTercero.SelectedValue;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_INMUEBLE_COPROPIETARIO.V_NOMBRE = txtNombreTercero.Text;
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_INMUEBLE_COPROPIETARIO.V_RFC = txtRFCTercero.Text;
                //oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_INMUEBLE_COPROPIETARIO.update();
                oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].update(chbDependietes.SelectedValuesInteger(), cmbTercero.SelectedValue, txtNombreTercero.Text, txtRFCTercero.Text);
                EliminaF_baja(oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_PATRIMONIO.ToString());
                if (txtF_BAJA_INM.Text.Length > 8)
                    oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].NID_PATRIMONIO, 1, txtF_BAJA_INM.Date(Pagina.esMX));
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

        protected void txtcCodigoPostalInmueble_TextChanged(object sender, EventArgs e)
        {
            if (txtcCodigoPostalInmueble.Text.Length == 5)
            {
                try
                {
                    blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(txtcCodigoPostalInmueble.Text);
                    cmbPaisInmueble.SelectedValue = oCodigo.NID_PAIS.ToString();
                    cmbPaisInmueble_SelectedIndexChanged(sender, e);
                    cmbEntidadFederativaInmueble.SelectedValue = oCodigo.CID_ENTIDAD_FEDERATIVA;
                    cmbEntidadFederativaInmueble_SelectedIndexChanged(sender, e);
                    cmbMunicipioInmueble.SelectedValue = oCodigo.CID_MUNICIPIO;
                    txtColoniaInmueble.Text = oCodigo.V_COLONIA;

                }
                catch
                {
                }
            }
        }

        protected void cmbPaisInmueble_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaisInmueble.SelectedValue == "1")
            {
                this.idLocal_colon.Text = "Colonia/Localidad";
                // idEnt_Munic.Text = "Entidad/Municipio o Alcaldía";

            }
            else
            {
                this.idLocal_colon.Text = "Ciudad/Localidad";
                // idEnt_Munic.Text = "Estado/Provincia";
            }
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisInmueble.SelectedValue());
            oEntidadFederativa.select();
            cmbEntidadFederativaInmueble.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            cmbEntidadFederativaInmueble_SelectedIndexChanged(sender, e);
        }

        protected void cmbEntidadFederativaInmueble_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
            omun.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisInmueble.SelectedValue());
            omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbEntidadFederativaInmueble.SelectedValue);
            omun.select();
            cmbMunicipioInmueble.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
        }

        protected void cmbPaisVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisVehiculo.SelectedValue());
            oEntidadFederativa.select();
            cmbEntidadFederativaVehiculo.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            cmbEntidadFederativaVehiculo_SelectedIndexChanged(sender, e);
        }

        protected void cmbEntidadFederativaVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
            omun.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisInmueble.SelectedValue());
            omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbEntidadFederativaVehiculo.SelectedValue);
            omun.select();

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
            dpTipoBienMueble.ClearSelection();
            chbDependietesMuebles.ClearSelection();

            txtTipoMonedaMueble.Text = String.Empty;
            cmbTransmisorMueble.ClearSelection();
            txtNombreTransmisorMueble.Text = String.Empty;
            txtRFCTransmisorMueble.Text = String.Empty;
            cmbRelacionTransmisorMueble.ClearSelection();
            cmbFormaAdquisicionMueble.ClearSelection();
            cmbFormaPagoMueble.ClearSelection();
            txtObservacionesBienesMuebles.Text = String.Empty;
            cmbTerceroMueble.ClearSelection();
            txtNombreTerceroMueble.Text = String.Empty;
            txtRFCTerceroMueble.Text = String.Empty;


        }

        protected void btnGuardarMueble_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarMueble();
                String msg = "Se actualizaron correctamente los datos del bien";
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
            String Paso;
            String Paso1;
            chbDependietesMuebles.SelectedValue = chbDependietesMue.SelectedValue;
            try
            {
                if (cmbTransmisorMueble.SelectedValue == "")
                {
                    Paso1 = "0";
                }
                else
                {
                    Paso1 = cmbTransmisorMueble.SelectedValue.ToString();
                }
                if (txtRFCTransmisorMueble.Text == "")

                    txtRFCTransmisorMueble.Text = "  ";

                if (cmbRelacionTransmisorMueble.SelectedValue.ToString() == "")
                {
                    Paso = "0";
                }
                else
                {
                    Paso = cmbRelacionTransmisorMueble.SelectedValue.ToString();
                }
                if (txtNombreTransmisorMueble.Text.Length == 0)
                    txtNombreTransmisorMueble.Text = "  ";

                oDeclaracion.ALTA.Add_ALTA_MUEBLEs(
                                                  dpTipoBienMueble.SelectedValue()
                                                , txtEspecifica.Text
                                                , moneytxtValorAdqusicionMueble.Money()
                                                , false
                                                , txtF_ADQUISICION.Date(esMX)
                                                //, cmbTransmisorMueble.SelectedValue
                                                , Paso1
                                                , txtNombreTransmisorMueble.Text + "|" + cmbMotivoBaja.SelectedValue.ToString() + "|" + cmbMotivoBaja.SelectedItem.Text
                                                //, txtNombreTransmisorMueble.Text
                                                , txtRFCTransmisorMueble.Text
                                                , Convert.ToInt32(Paso)
                                                , txtTipoMonedaMueble.Text
                                                , Convert.ToInt32(cmbFormaAdquisicionMueble.SelectedValue)
                                                , Convert.ToInt32(cmbFormaPagoMueble.SelectedValue)
                                                , txtObservacionesBienesMuebles.Text
                                                , cmbTerceroMueble.SelectedValue
                                                , txtNombreTerceroMueble.Text
                                                , txtRFCTerceroMueble.Text
                                                , txtEspecifica.Text
                                                , chbDependietesMuebles.SelectedValuesInteger());
                o = oDeclaracion.ALTA.ALTA_MUEBLEs.Last();

                if (txtF_BAJA_MUEB.Text.Length > 8)
                    oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(o.NID_PATRIMONIO, 1, txtF_BAJA_MUEB.Date(Pagina.esMX));
                int x = grdMueble.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("Mueble_", x);
                ((Item)item).TextoPrincipal = o.V_TIPO;
                ((Item)item).TextoSecundario = o.E_ESPECIFICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_MUEBLE/", o.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grdMueble.Controls.AddAt(x, item);
                active();
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
            marcaApartado(ref oDeclaracion, 9);
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
                //Agregar Insert para el campo de E_Especificacion sin encriptar
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].D_ESPECIFICACION = txtEspecifica.Text;
                ////
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].M_VALOR = moneytxtValorAdqusicionMueble.Money();
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].F_ADQUISICION = txtF_ADQUISICION.Date(esMX);

                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].V_TIPO_MONEDA = txtTipoMonedaMueble.Text;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].CID_TIPO_PERSONA_TRANSMISOR = cmbTransmisorMueble.SelectedValue;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].E_NOMBRE_TRANSMISOR = txtNombreTransmisorMueble.Text + "|" + cmbMotivoBaja.SelectedValue.ToString() + "|" + cmbMotivoBaja.SelectedItem.Text;
                //oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].E_NOMBRE_TRANSMISOR = txtNombreTransmisorMueble.Text;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].E_RFC_TRANSMISOR = txtRFCTransmisorMueble.Text;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].NID_RELACION_TRANSMISOR = cmbRelacionTransmisorMueble.SelectedValue();
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].NID_FORMA_ADQUISICION = cmbFormaAdquisicionMueble.SelectedValue();
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].NID_FORMA_PAGO = cmbFormaPagoMueble.SelectedValue();
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].E_OBSERVACIONES = txtObservacionesBienesMuebles.Text;

                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].ALTA_MUEBLE_COPROPIETARIO.CID_TIPO_PERSONA = cmbTerceroMueble.SelectedValue;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].ALTA_MUEBLE_COPROPIETARIO.V_NOMBRE = txtNombreTerceroMueble.Text;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].ALTA_MUEBLE_COPROPIETARIO.V_RFC = txtRFCTerceroMueble.Text;
                oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].update(chbDependietesMuebles.SelectedValuesInteger(), cmbTerceroMueble.SelectedValue, txtNombreTerceroMueble.Text, txtRFCTerceroMueble.Text);
                EliminaF_baja(oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].NID_PATRIMONIO.ToString());
                if (txtF_BAJA_MUEB.Text.Length > 8)
                    oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(oDeclaracion.ALTA.ALTA_MUEBLEs[Indice].NID_PATRIMONIO, 1, txtF_BAJA_MUEB.Date(Pagina.esMX));
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

            mppVehículos.HeaderText = "Agregar vehículo";
            mppVehículos.Show(true);
            dpModelo.ClearSelection();
            dpModelo.DataSource = oUsuario.CAT_AGNO;
            dpModelo.DataBind();

            cmbMarca.ClearSelection();
            cmbTipoVehiculo.ClearSelection();
            txtTipo.Text = String.Empty;
            txtFechaAdquisicionVehiculo.Text = String.Empty;
            moneytxtValorAdquisicion.Text = String.Empty;

            cmbPaisVehiculo.ClearSelection();
            cmbPaisVehiculo_SelectedIndexChanged(sender, e);
            cmbEntidadFederativaVehiculo.ClearSelection();

            cmbTransmisorVehiculo.ClearSelection();
            txtNombreTransmisorVehiculo.Text = String.Empty;
            txtRFCTransmisorVehiculo.Text = String.Empty;
            cmbRelacionTransmisorVehiculo.ClearSelection();
            txtNumeroSerie.Text = String.Empty;
            txtTipoMonedaVehiculo.Text = String.Empty;
            cmbFormaAdquisicionVehiculo.ClearSelection();
            cmbFormaPagoVehiculo.ClearSelection();
            txtObservacionesVehiculos.Text = String.Empty;
            cmbTerceroVehiculo.ClearSelection();
            txtNombreTerceroVehiculo.Text = String.Empty;
            txtRFCTerceroVehiculo.Text = String.Empty;


            checaAdeudoVehiculo();
            // dpTipoUso.ClearSelection();

            chbDependietesVehiculo.ClearSelection();
        }



        protected void btnGuardarVehiculo_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarVehiculo();
                String msg = "Se actualizaron correctamente los datos del vehículo";
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
            string Paso;
            string Paso1;
            chbDependietesVehiculo.SelectedValue = chbDependietesVeh.SelectedValue;
            try
            {
                if (cmbTransmisorVehiculo.SelectedValue == "")
                {
                    Paso1 = "0";
                }
                else
                {
                    Paso1 = cmbTransmisorVehiculo.SelectedValue.ToString();
                }
                if (txtRFCTransmisorVehiculo.Text == "")

                    txtRFCTransmisorVehiculo.Text = "  ";

                if (cmbRelacionTransmisorVehiculo.SelectedValue.ToString() == "")
                {
                    Paso = "0";
                }
                else
                {
                    Paso = cmbRelacionTransmisorVehiculo.SelectedValue.ToString();
                }
                if (txtNombreTransmisorVehiculo.Text.Length == 0)
                    txtNombreTransmisorVehiculo.Text = "  ";

                oDeclaracion.ALTA.Add_ALTA_VEHICULOs(
                                                    cmbTipoVehiculo.SelectedValue()
                                                    , cmbMarca.SelectedValue()
                                                   , dpModelo.SelectedValue
                                                   , txtTipo.Text
                                                   , txtFechaAdquisicionVehiculo.Date(esMX)
                                                   , dpTipoUso.SelectedValue()
                                                   , moneytxtValorAdquisicion.Money()
                                                   , Convert.ToInt32(cmbPaisVehiculo.SelectedValue)
                                                   , cmbEntidadFederativaVehiculo.SelectedValue
                                                    //, cmbTransmisorVehiculo.SelectedValue
                                                    , Paso1
                                                   , txtNombreTransmisorVehiculo.Text + "|" + cmbVehiMotivoBaja.SelectedValue.ToString() + "|" + cmbVehiMotivoBaja.SelectedItem.Text
                                                   // , txtNombreTransmisorVehiculo.Text 
                                                   , txtRFCTransmisorVehiculo.Text
                                                   //, Convert.ToInt32(cmbRelacionTransmisorVehiculo.SelectedValue)
                                                   , Convert.ToInt32(Paso)
                                                   , txtTipoMonedaVehiculo.Text
                                                   , txtNumeroSerie.Text
                                                   , Convert.ToInt32(cmbFormaAdquisicionVehiculo.SelectedValue)
                                                   , Convert.ToInt32(cmbFormaPagoVehiculo.SelectedValue)
                                                   , txtObservacionesVehiculos.Text
                                                   , cmbTerceroVehiculo.SelectedValue
                                                   , txtNombreTerceroVehiculo.Text
                                                   , txtRFCTerceroVehiculo.Text
                                                   , chbDependietesVehiculo.SelectedValuesInteger());

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

                if (txtF_BAJA_VEHIC.Text.Length > 8)
                    oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(v.NID_PATRIMONIO, 1, txtF_BAJA_VEHIC.Date(Pagina.esMX));

                int x = grdVehiculos.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).TextoPrincipal = v.V_MARCA;
                ((Item)item).TextoSecundario = v.V_DESCRIPCION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_VEHICULO/", v.NID_TIPO_VEHICULO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grdVehiculos.Controls.AddAt(x, item);
                active();
                mppVehículos.Hide();
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
            marcaApartado(ref oDeclaracion, 10);

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
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].M_VALOR_VEHICULO = moneytxtValorAdquisicion.Money();

                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_PAIS = Convert.ToInt32(cmbPaisVehiculo.SelectedValue);
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].CID_ENTIDAD_FEDERATIVA = cmbEntidadFederativaVehiculo.SelectedValue;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].V_TIPO_MONEDA = txtTipoMonedaVehiculo.Text;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].E_NUMERO_SERIE = txtNumeroSerie.Text;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].CID_TIPO_PERSONA_TRANSMISOR = cmbTransmisorVehiculo.SelectedValue;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].E_NOMBRE_TRANSMISOR = txtNombreTransmisorVehiculo.Text + "|" + cmbVehiMotivoBaja.SelectedValue.ToString() + "|" + cmbVehiMotivoBaja.SelectedItem.Text;
                //oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].E_NOMBRE_TRANSMISOR = txtNombreTransmisorVehiculo.Text;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].E_RFC_TRANSMISOR = txtRFCTransmisorVehiculo.Text;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_RELACION_TRANSMISOR = cmbRelacionTransmisorVehiculo.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_FORMA_ADQUISICION = cmbFormaAdquisicionVehiculo.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_FORMA_PAGO = cmbFormaPagoVehiculo.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].E_OBSERVACIONES = txtObservacionesVehiculos.Text;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].update(chbDependietesVehiculo.SelectedValuesInteger(), cmbTerceroVehiculo.SelectedValue, txtNombreTerceroVehiculo.Text, txtRFCTerceroVehiculo.Text);
                EliminaF_baja(oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_PATRIMONIO.ToString());
                if (txtF_BAJA_VEHIC.Text.Length > 8)
                    oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_PATRIMONIO, 1, txtF_BAJA_VEHIC.Date(Pagina.esMX));
                mppVehículos.Hide();
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

        protected void btnEditaVehículos_Click(object sender, EventArgs e)
        {
            mppVehículos.HeaderText = "Editar vehículo";
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
            internal String V_TIPO_MONEDA { get; set; }
            internal String CID_TIPO_PERSONA_OTORGANTE { get; set; }
            internal String E_RFC { get; set; }
            internal String E_OBSERVACIONES { get; set; }
            internal String NID_TERCERO { get; set; }
            internal String E_NOMBRE_TERCERO { get; set; }
            internal String E_RFC_TERCERO { get; set; }
            internal List<Int32> NID_TITULARs { get; set; }
        }

        #endregion

        protected void cbxTieneAdeudo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTieneAdeudo.Checked)
            {
                mppInmuebles.Hide();
                mppAdeudos.Show(true);
                //Adeudo.Requerido = btnGuardarAdeudo.ClientID;
                
                mppAdeudos.HeaderText = "Adeudo por concepto de crédito hipotecario";
                btnCerrarModal.Visible = true;
                btnGuardarAdeudo.Visible = true;
                btnCerrarModalVehiculo.Visible = false;
                btnGuardarAdeudoVehiculo.Visible = false;
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 3;
                lEditaAdeudo = false;
                InfoAdeudo = null;
                //MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
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
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_TIPO_MONEDA = Adeudo.V_TIPO_MONEDA;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].CID_TIPO_PERSONA_OTORGANTE = Adeudo.CID_TIPO_PERSONA_OTORGANTE;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_RFC = Adeudo.E_RFC;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_OBSERVACIONES = Adeudo.E_OBSERVACIONES;
                        //Validaciones OEVM para los casos donde llega vacia la informacion de los campos de terceros
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_TERCERO = Adeudo.NID_TERCERO == "" ? "" : Adeudo.NID_TERCERO;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_NOMBRE_TERCERO = Adeudo.E_NOMBRE_TERCERO == "" ? "" : Adeudo.E_NOMBRE_TERCERO;
                        oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_RFC_TERCERO = Adeudo.E_RFC_TERCERO ==""?"": Adeudo.E_RFC_TERCERO;
                        //
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
                                 , Adeudo.V_LUGAR + "|" + Adeudo.V_TIPO_MONEDA + "|" + Adeudo.CID_TIPO_PERSONA_OTORGANTE + "|" + Adeudo.E_RFC + "|" + Adeudo.E_OBSERVACIONES + "|" + Adeudo.NID_TERCERO + "|" + Adeudo.E_NOMBRE_TERCERO + "|" + Adeudo.E_RFC_TERCERO
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
                                V_LUGAR = Adeudo.V_LUGAR + "|" + Adeudo.V_TIPO_MONEDA + "|" + Adeudo.CID_TIPO_PERSONA_OTORGANTE + "|" + Adeudo.E_RFC + "|" + Adeudo.E_OBSERVACIONES + "|" + Adeudo.NID_TERCERO + "|" + Adeudo.E_NOMBRE_TERCERO + "|" + Adeudo.E_RFC_TERCERO,
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
                    oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                    _oDeclaracion = oDeclaracion;
                    mppAdeudos.Hide();
                    mppInmuebles.Show();
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

        protected void btnEditarAdeudo1_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            this.IndiceAdeudoSeleccionado = 0;
            mppInmuebles.Hide();
            mppAdeudos.Show(true);
            //Adeudo.Requerido = btnGuardarAdeudo.ClientID;
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
            // Agregado de nuevos campos
            Adeudo.V_TIPO_MONEDA = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].V_TIPO_MONEDA;
            Adeudo.CID_TIPO_PERSONA_OTORGANTE = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].CID_TIPO_PERSONA_OTORGANTE;
            Adeudo.E_RFC = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].E_RFC;
            Adeudo.E_OBSERVACIONES = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].E_OBSERVACIONES;
            Adeudo.NID_TERCERO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].NID_TERCERO;
            Adeudo.E_NOMBRE_TERCERO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].E_NOMBRE_TERCERO;
            Adeudo.E_RFC_TERCERO = oDeclaracion.ALTA.ALTA_INMUEBLEs[Indice].ALTA_ADEUDOs[0].E_RFC_TERCERO;
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
                //Adeudo.Requerido = btnGuardarAdeudo.ClientID;
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
            //Adeudo.Requerido = btnGuardarAdeudo.ClientID;
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
                //Adeudo.Requerido = btnGuardarAdeudoVehiculo.ClientID;
                mppAdeudos.HeaderText = "Adeudo por concepto de crédito automotriz";
                btnCerrarModal.Visible = false;
                btnGuardarAdeudo.Visible = false;
                btnCerrarModalVehiculo.Visible = true;
                btnGuardarAdeudoVehiculo.Visible = true;
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 2;
                lEditaAdeudo = false;
                InfoAdeudo = null;
                //MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
            }
        }

        protected void btnModificarAdeudoVehiculo_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            IndiceAdeudoSeleccionado = 0;
            Int32 IndiceAdeudo = this.IndiceAdeudoSeleccionado;
            mppAdeudos.Show(true);
            //Adeudo.Requerido = btnGuardarAdeudoVehiculo.ClientID;
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
                    if (ex is CustomException)
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
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_TIPO_MONEDA = Adeudo.V_TIPO_MONEDA;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].CID_TIPO_PERSONA_OTORGANTE = Adeudo.CID_TIPO_PERSONA_OTORGANTE;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_RFC = Adeudo.E_RFC;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_OBSERVACIONES = Adeudo.E_OBSERVACIONES;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_TERCERO = Adeudo.NID_TERCERO;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_NOMBRE_TERCERO = Adeudo.E_NOMBRE_TERCERO;
                        oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_RFC_TERCERO = Adeudo.E_RFC_TERCERO;
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
                               , Adeudo.V_LUGAR + "|" + Adeudo.V_TIPO_MONEDA + "|" + Adeudo.CID_TIPO_PERSONA_OTORGANTE + "|" + Adeudo.E_RFC + "|" + Adeudo.E_OBSERVACIONES + "|" + Adeudo.NID_TERCERO + "|" + Adeudo.E_NOMBRE_TERCERO + "|" + Adeudo.E_RFC_TERCERO
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
                        V_LUGAR = Adeudo.V_LUGAR + "|" + Adeudo.V_TIPO_MONEDA + "|" + Adeudo.CID_TIPO_PERSONA_OTORGANTE + "|" + Adeudo.E_RFC + "|" + Adeudo.E_OBSERVACIONES + "|" + Adeudo.NID_TERCERO + "|" + Adeudo.E_NOMBRE_TERCERO + "|" + Adeudo.E_RFC_TERCERO,
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
                if (ex is CustomException)
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
                String msg = "Se actualizaron correctamente los datos del vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarVehiculo();
                String msg = "Se agregó correctamente el vehículo";
                AlertaSuperior.ShowSuccess(msg);
                active();
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

        internal static Int32 nBuscaAdeudo(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in dbInt.ALTA_ADEUDO
                              where p.VID_NOMBRE == VID_NOMBRE &&
                                    p.VID_FECHA == VID_FECHA &&
                                    p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                    p.NID_DECLARACION == NID_DECLARACION

                              select p.NID_ADEUDO).Max());
                return query;
            }
            catch
            {
                return 0;
            }
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
                cmbTercero.Enabled = true;
                txtNombreTercero.Enabled = true;
                txtRFCTercero.Enabled = true;
            }
            else
            {
                cmbTercero.Enabled = false;
                txtNombreTercero.Enabled = false;
                txtRFCTercero.Enabled = false;
            }
        }

        protected void chbDependietesMue_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Paso = chbDependietesMue.SelectedItem.Text;
            Int32 Contenido = Paso.IndexOf("Terceros");
            if (Contenido > 0)
            {
                cmbTerceroMueble.Enabled = true;
                txtNombreTerceroMueble.Enabled = true;
                txtRFCTerceroMueble.Enabled = true;
            }
            else
            {
                cmbTerceroMueble.Enabled = false;
                txtNombreTerceroMueble.Enabled = false;
                txtRFCTerceroMueble.Enabled = false;
            }
        }

        protected void chbDependietesVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Paso = chbDependietesVeh.SelectedItem.Text;
            Int32 Contenido = Paso.IndexOf("Terceros");
            if (Contenido > 0)
            {
                cmbTerceroVehiculo.Enabled = true;
                txtNombreTerceroVehiculo.Enabled = true;
                txtRFCTerceroVehiculo.Enabled = true;
            }
            else
            {
                cmbTerceroVehiculo.Enabled = false;
                txtNombreTerceroVehiculo.Enabled = false;
                txtRFCTerceroVehiculo.Enabled = false;
            }
        }
        protected void ddlTipoMonedaInm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoMoneda.Text = ddlTipoMonedaInm.SelectedValue.ToString() + '|' + ddlTipoMonedaInm.SelectedItem.Text;
        }
        protected void ddlTipoMonedaMue_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoMonedaMueble.Text = ddlTipoMonedaMue.SelectedValue.ToString() + '|' + ddlTipoMonedaMue.SelectedItem.Text;
        }

        protected void ddlTipoMonedaVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoMonedaVehiculo.Text = ddlTipoMonedaVeh.SelectedValue.ToString() + '|' + ddlTipoMonedaVeh.SelectedItem.Text;
        }
    }

}