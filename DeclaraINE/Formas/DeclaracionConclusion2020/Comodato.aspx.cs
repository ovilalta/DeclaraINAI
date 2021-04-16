using Declara_V2.BLLD;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using Declara_V2.MODELextended;
using AlanWebControls;
using Declara_V2.Exceptions;
using Declara_V2.BLL;
using Declara_V2.DALD;


namespace DeclaraINE.Formas.DeclaracionInicial
{
    public partial class Comodato : Pagina, IDeclaracionInicial
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

        public void Anterior()
        {
            Response.Redirect("Desemp.aspx");
        }

       

        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
            {
                // AQUI VA EL CODIGO DEL APARTADO
                //---------------------------------------------------
                marcaApartado(19);

                if (oDeclaracion.ALTA.ALTA_COMODATOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                    QstBoxInm.Ask("¿Tiene Otros Préstamos o COMODATO que registrar?");


                //---------------------------------------------------
            }


            Response.Redirect("Observaciones.aspx");
        }

        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            //blld_ALTA_INVERSION o;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liComodato")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu9")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            if (!IsPostBack)
            {
                blld__l_CAT_RELACION_TRANSMISOR oRel = new blld__l_CAT_RELACION_TRANSMISOR();
                oRel.OrderByCriterios.Add(new Declara_V2.Order(CAT_RELACION_TRANSMISOR.Properties.V_RELACION_TRANSMISOR));
                oRel.select();
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
                cmbNID_TIPO_RELACION.DataBind(oRel.lista_CAT_RELACION_TRANSMISOR, CAT_RELACION_TRANSMISOR.Properties.NID_RELACION_TRANSMISOR, CAT_RELACION_TRANSMISOR.Properties.V_RELACION_TRANSMISOR);
                cmbNID_TIPO_RELACION.Items.Insert(0, new ListItem(string.Empty));
                //cmbNID_TIPO_RELACION.DataBind();

                blld__l_CAT_TIPO_INMUEBLE oTipoInmueble = new blld__l_CAT_TIPO_INMUEBLE();
                //oTipoInmueble.L_ACTIVO = true;
                oTipoInmueble.select();
                cmbNID_TIPO_INMUEBLE.DataBind(oTipoInmueble.lista_CAT_TIPO_INMUEBLE, CAT_TIPO_INMUEBLE.Properties.NID_TIPO, CAT_TIPO_INMUEBLE.Properties.V_TIPO);
                cmbNID_TIPO_INMUEBLE.Items.Insert(0, new ListItem(String.Empty));

                blld__l_CAT_TIPO_VEHICULO oTipoVehiculo = new blld__l_CAT_TIPO_VEHICULO();
                oTipoVehiculo.select();
                cmdNID_TIPO_VEHICULO.DataBind(oTipoVehiculo.lista_CAT_TIPO_VEHICULO, CAT_TIPO_VEHICULO.Properties.NID_TIPO_VEHICULO, CAT_TIPO_VEHICULO.Properties.V_TIPO_VEHICULO);
                cmdNID_TIPO_VEHICULO.Items.Insert(0, new ListItem(string.Empty));

                blld__l_CAT_MARCA_VEHICULO oMarca = new blld__l_CAT_MARCA_VEHICULO();
                oMarca.OrderByCriterios.Add(new Declara_V2.Order(CAT_MARCA_VEHICULO.Properties.V_MARCA));
                oMarca.select();
                cmbMarca.DataBind(oMarca.lista_CAT_MARCA_VEHICULO, CAT_MARCA_VEHICULO.Properties.NID_MARCA, CAT_MARCA_VEHICULO.Properties.V_MARCA);
                cmbMarca.Items.Insert(0, new ListItem(String.Empty));

                dpModelo.DataSource = oUsuario.CAT_AGNO;
                dpModelo.DataBind();
                dpModelo.Items.Insert(0, new ListItem(string.Empty));

                blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
                oCAT_PAIS.select();

                cmbnIdPaisOrigen.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbnIdPaisOrigen.Items.Insert(0, new ListItem(String.Empty));
                blld__l_CAT_PAIS oCAT_PAIS_DIR = new blld__l_CAT_PAIS();
                oCAT_PAIS_DIR.select();
                cmbnIdPais.DataBind(oCAT_PAIS_DIR.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbnIdPais.SelectedValue = "1";
                cmbnIdPais_SelectedIndexChanged(sender, e);

               
                }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkComodato")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkComodato")).CssClass = "active";

            ltrSubTitulo.Text = "Préstamo o Comodato por terceros(Situación Actual)";
            string Contenedor;
            string Identifica;
            string Principal;
            string Secundario;
            blld_ALTA_COMODATO b;
            for (int x = 0; x < oDeclaracion.ALTA.ALTA_COMODATOs.Count(); x++)
            {
                b = oDeclaracion.ALTA.ALTA_COMODATOs[x];

                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                string ValoresRegreso = TraeComplementoT(b.NID_COMODATO);
                Identifica = ValoresRegreso.Split('|')[1];
                if (ValoresRegreso.Split('|')[0] == "1")
                {
                    ((Item)item).ID = String.Concat("Inmueble_", x);
                    Contenedor = "../../Images/CAT_TIPO_INMUEBLE/";
                    Principal = ValoresRegreso.Split('|')[4] + " Número" + ValoresRegreso.Split('|')[5];
                    Secundario = "Colonia " + ValoresRegreso.Split('|')[8] + " C.P. " + ValoresRegreso.Split('|')[9];
                }
                else
                {
                    ((Item)item).ID = String.Concat("Vehículo_", x);
                    Contenedor = "../../Images/CAT_TIPO_VEHICULO/";
                    Principal = ValoresRegreso.Split('|')[2];
                    Secundario = "Serie " + ValoresRegreso.Split('|')[3];
                }
                ((Item)item).TextoPrincipal = Principal;
                ((Item)item).TextoSecundario = Secundario;
                ((Item)item).ImageUrl = String.Concat(Contenedor, Identifica, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grdComoDato.Controls.AddAt(0 + x, item);
            }

        }


       
    private void Pinta()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            blld_ALTA_COMODATO b;
            string Contenedor;
            string Identifica;
            string Principal;
            string Secundario;
            b = oDeclaracion.ALTA.ALTA_COMODATOs.Last();
            int x = grdComoDato.Controls.Count - 3;
            UserControl item = (UserControl)Page.LoadControl("item.ascx");
            ((Item)item).Id = oDeclaracion.ALTA.ALTA_COMODATOs.Count - 1;
            string ValoresRegreso = TraeComplementoT(b.NID_COMODATO);
            Identifica = ValoresRegreso.Split('|')[1];
            if (ValoresRegreso.Split('|')[0] == "1")
            {
                ((Item)item).ID = String.Concat("Inmueble_", oDeclaracion.ALTA.ALTA_COMODATOs.Count - 1);
                Contenedor = "../../Images/CAT_TIPO_INMUEBLE/";
                Principal = ValoresRegreso.Split('|')[4] + " Número" + ValoresRegreso.Split('|')[5];
                Secundario = "Colonia " + ValoresRegreso.Split('|')[8] + " C.P. " + ValoresRegreso.Split('|')[9];
            }
            else
            {
                ((Item)item).ID = String.Concat("Vehículo_", oDeclaracion.ALTA.ALTA_COMODATOs.Count - 1);
                Contenedor = "../../Images/CAT_TIPO_VEHICULO/";
                Principal = ValoresRegreso.Split('|')[2];
                Secundario = "Serie " + ValoresRegreso.Split('|')[3];
            }

                ((Item)item).TextoPrincipal = Principal;
            ((Item)item).TextoSecundario = Secundario;
            ((Item)item).ImageUrl = String.Concat(Contenedor, Identifica, ".png");
            ((Item)item).Editar += OnEditar;
            ((Item)item).Eliminar += OnEliminar;
            grdComoDato.Controls.AddAt(x, item);
            mppDatos.Hide();
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
            if (NID_APARTADO == 19)
            {
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 19 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
                {
                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                    {
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO = true;
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().update();
                    }
                }
            }
        }

        protected void btnAgregarComoDato_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            lEditar = false;
            mppDatos.HeaderText = "Agregar Préstamo o Comodato";
            mppDatos.Show(true);
            LimpiaDatos();
            cmbTipoBien.Enabled = true;
        }
        private void LimpiaDatos()
        {
            this.idVeviculos.Visible = false;
            this.idInmueble.Visible = false;
            cmbTipoBien.ClearSelection();
            cmbTipoPersona.ClearSelection();
            txtvNombre.Text = string.Empty;
            txtvRFC.Text = string.Empty;
            cmbNID_TIPO_RELACION.ClearSelection();
            txtObservaciones.Text = string.Empty;
            cmdNID_TIPO_VEHICULO.ClearSelection();
            cmbMarca.ClearSelection();
            txtTipo.Text = string.Empty;
            dpModelo.ClearSelection();
            cmbnIdPaisOrigen.ClearSelection();
            cmbcIdEntidadFederativaOrigen.ClearSelection();
            txtvSerie.Text = string.Empty;
            cmbNID_TIPO_INMUEBLE.ClearSelection();
            cmbnIdPais.ClearSelection();
            cmbcIdEntidadFederativa.ClearSelection();
            cmbMunicipio.ClearSelection();
            txtcCodigoPostal.Text = string.Empty;
            txtColoniaParticular.Text = string.Empty;
            txtEdo_Provincia.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtNumInterior.Text = string.Empty;
            txtNumExterior.Text = string.Empty;
        }
        protected void OnEditar(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_COMODATO i;
           
            String Selecciona;
            lEditar = true;
            i = oDeclaracion.ALTA.ALTA_COMODATOs[e.Id];
            IndiceItemSeleccionado = e.Id;
            Selecciona=TraeComplementoT(i.NID_COMODATO).Split('|')[0];

            if(Selecciona=="1")
            {
                mppDatos.HeaderText = "Editar Inmuebles";
                mppDatos.Show(true);
                this.idVeviculos.Visible = false;
                this.idInmueble.Visible = true;
                cmbTipoBien.Enabled = false;
                cmbTipoBien.SelectedValue = Selecciona.ToString();
                cmbTipoPersona.SelectedValue = i.CID_TIPO_PERSONA;
                this.txtvNombre.Text = i.E_TITULAR.ToString();
                txtvRFC.Text = i.E_RFC.ToString();
                cmbNID_TIPO_RELACION.SelectedValue = i.NID_TIPO_RELACION.ToString();
                txtObservaciones.Text = i.E_OBSERVACIONES.ToString();

                blld__l_ALTA_COMODATO_INMUEBLE oInmueble = new blld__l_ALTA_COMODATO_INMUEBLE();
                oInmueble.VID_NOMBRE = new Declara_V2.StringFilter(i.VID_NOMBRE);
                oInmueble.VID_FECHA = new Declara_V2.StringFilter(i.VID_FECHA);
                oInmueble.VID_HOMOCLAVE = new Declara_V2.StringFilter(i.VID_HOMOCLAVE);
                oInmueble.NID_DECLARACION = new Declara_V2.IntegerFilter(i.NID_DECLARACION);
                oInmueble.NID_COMODATO = new Declara_V2.IntegerFilter(i.NID_COMODATO);
                oInmueble.select();
               
                cmbNID_TIPO_INMUEBLE.SelectedValue = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].NID_TIPO.ToString();
                cmbnIdPais.SelectedValue = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].NID_PAIS.ToString();
                cmbnIdPais_SelectedIndexChanged(sender, e);
                cmbcIdEntidadFederativa.SelectedValue = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].CID_ENTIDAD_FEDERATIVA.ToString();
                cmbcIdEntidadFederativa_SelectedIndexChanged(sender, e);
                cmbMunicipio.SelectedValue = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].CID_MUNICIPIO.ToString();
                txtcCodigoPostal.Text = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].C_CODIGO_POSTAL.ToString();
                txtColoniaParticular.Text = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].V_COLONIA.ToString();
                txtEdo_Provincia.Text = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].V_DOMICILIO.ToString().Split('|')[1];
                txtCalle.Text = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].V_DOMICILIO.ToString().Split('|')[2];
                txtNumExterior.Text = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].V_DOMICILIO.ToString().Split('|')[3];
                txtNumInterior.Text = oInmueble.lista_ALTA_COMODATO_INMUEBLE[0].V_DOMICILIO.ToString().Split('|')[4];


               
            }
            else
            {
                mppDatos.HeaderText = "Editar Vehículos";
                mppDatos.Show(true);
                this.idInmueble.Visible = false;
                this.idVeviculos.Visible = true;
                cmbTipoBien.Enabled = false;
                cmbTipoBien.SelectedValue = Selecciona.ToString();
                cmbTipoPersona.SelectedValue = i.CID_TIPO_PERSONA;
                this.txtvNombre.Text = i.E_TITULAR.ToString();
                txtvRFC.Text = i.E_RFC.ToString();
                cmbNID_TIPO_RELACION.SelectedValue = i.NID_TIPO_RELACION.ToString();
                txtObservaciones.Text = i.E_OBSERVACIONES.ToString();

                blld__l_ALTA_COMODATO_VEHICULO oVehiculo = new blld__l_ALTA_COMODATO_VEHICULO();
                oVehiculo.VID_NOMBRE = new Declara_V2.StringFilter(i.VID_NOMBRE);
                oVehiculo.VID_FECHA = new Declara_V2.StringFilter(i.VID_FECHA);
                oVehiculo.VID_HOMOCLAVE = new Declara_V2.StringFilter(i.VID_HOMOCLAVE);
                oVehiculo.NID_DECLARACION = new Declara_V2.IntegerFilter(i.NID_DECLARACION);
                oVehiculo.NID_COMODATO = new Declara_V2.IntegerFilter(i.NID_COMODATO);
                oVehiculo.select();
                cmdNID_TIPO_VEHICULO.SelectedValue = oVehiculo.lista_ALTA_COMODATO_VEHICULO[0].NID_TIPO_VEHICULO.ToString();
                cmbMarca.SelectedValue = oVehiculo.lista_ALTA_COMODATO_VEHICULO[0].NID_MARCA.ToString();
                txtTipo.Text = oVehiculo.lista_ALTA_COMODATO_VEHICULO[0].V_DESCRIPCION.ToString();
                dpModelo.SelectedValue = oVehiculo.lista_ALTA_COMODATO_VEHICULO[0].C_MODELO.ToString();
                cmbnIdPaisOrigen.SelectedValue = oVehiculo.lista_ALTA_COMODATO_VEHICULO[0].NID_PAIS.ToString();
                cmbnIdPaisOrigen_SelectedIndexChanged(sender, e);
                cmbcIdEntidadFederativaOrigen.SelectedValue = oVehiculo.lista_ALTA_COMODATO_VEHICULO[0].CID_ENTIDAD_FEDERATIVA.ToString();
                txtvSerie.Text = oVehiculo.lista_ALTA_COMODATO_VEHICULO[0].E_NUMERO_SERIE.ToString();
            }

        }
        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_COMODATO i;
            String Selecciona;
           
            lEditar = true;
            i = oDeclaracion.ALTA.ALTA_COMODATOs[e.Id];
            IndiceItemSeleccionado = e.Id;
            Int32 Indice = IndiceItemSeleccionado;
            
            Selecciona = TraeComplementoT(oDeclaracion.ALTA.ALTA_COMODATOs[Indice].NID_COMODATO).Split('|')[0];
            
            try
            {
                
                if(Selecciona=="1")
                {
                    Nborra_Inmueble(i.VID_NOMBRE, i.VID_FECHA, i.VID_HOMOCLAVE, i.NID_DECLARACION, i.NID_COMODATO);
                    grdComoDato.Controls.Remove(grdComoDato.FindControl(String.Concat("Inmueble_", e.Id)));
                    AlertaSuperior.ShowSuccess("Se eliminó correctamente el inmueble");
                }
                if(Selecciona=="2")
                {
                    nBorra_Vehiculo(i.VID_NOMBRE, i.VID_FECHA, i.VID_HOMOCLAVE, i.NID_DECLARACION, i.NID_COMODATO);
                    grdComoDato.Controls.Remove(grdComoDato.FindControl(String.Concat("Vehículo_", e.Id)));
                    AlertaSuperior.ShowSuccess("Se eliminó correctamente el vehículo");
                }
                oDeclaracion.ALTA.ALTA_COMODATOs.RemoveAt(e.Id);
                _oDeclaracion = oDeclaracion;
            }
            catch
            {

            }
        }
        protected void QstBoxInm_No(object Sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(19);
            _oDeclaracion = oDeclaracion;
            Siguiente();

        }
        protected void QstBoxInm_Yes(object Sender, EventArgs e)
        {
            //active();
        }

        protected void cmbTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardarComodo_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            String msg;
            if (lEditar)
            {
                EditaDatos();
               
            }
            else
            {
                GuardaDatos();
                blld_ALTA_COMODATO b;
                b = oDeclaracion.ALTA.ALTA_COMODATOs.Last();
                string ValoresRegreso = TraeComplementoT(b.NID_COMODATO);
                String Identifica = ValoresRegreso.Split('|')[1];
                if(Identifica=="1")
                      msg = "Se agregó correctamente el inmueble";
                   else
                    msg = "Se agregó correctamente el vehículo";
                AlertaSuperior.ShowSuccess(msg);
               
            }

        }
        private void EditaDatos()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

           
            int Selector;

            if (idInmueble.Visible == true)
                Selector = 0;

            else
                Selector = 1;
            Int32 Indice = IndiceItemSeleccionado;

            try
            {
                oDeclaracion.ALTA.ALTA_COMODATOs[Indice].CID_TIPO_PERSONA = cmbTipoPersona.SelectedValue;
                oDeclaracion.ALTA.ALTA_COMODATOs[Indice].E_TITULAR = txtvNombre.Text;
                oDeclaracion.ALTA.ALTA_COMODATOs[Indice].E_RFC = txtvRFC.Text;
                oDeclaracion.ALTA.ALTA_COMODATOs[Indice].NID_TIPO_RELACION = cmbNID_TIPO_RELACION.SelectedValue();
                oDeclaracion.ALTA.ALTA_COMODATOs[Indice].E_OBSERVACIONES = txtObservaciones.Text;
                oDeclaracion.ALTA.ALTA_COMODATOs[Indice].update();
                if (Selector==0)
                {
                    blld_ALTA_COMODATO_INMUEBLE ActualizaInmueble = new blld_ALTA_COMODATO_INMUEBLE(
                                                                                        oDeclaracion.VID_NOMBRE
                                                                                        , oDeclaracion.VID_FECHA
                                                                                        , oDeclaracion.VID_HOMOCLAVE
                                                                                        , oDeclaracion.NID_DECLARACION
                                                                                        , oDeclaracion.ALTA.ALTA_COMODATOs[Indice].NID_COMODATO
                                                                                        ,Convert.ToInt32(cmbNID_TIPO_INMUEBLE.SelectedValue())
                                                                                        , txtcCodigoPostal.Text
                                                                                        , Convert.ToInt32(cmbnIdPais.SelectedValue())
                                                                                        , cmbcIdEntidadFederativa.SelectedValue
                                                                                        , cmbMunicipio.SelectedValue
                                                                                        , txtColoniaParticular.Text
                                                                                        , ("|" + txtEdo_Provincia.Text + "|" + txtCalle.Text + "|" + txtNumExterior.Text + "|" + txtNumInterior.Text + "|").ToString()
                                                                                        );
              
                }
                else
                {
                    blld_ALTA_COMODATO_VEHICULO ActualizaVehiculo = new blld_ALTA_COMODATO_VEHICULO(
                                                                                          oDeclaracion.VID_NOMBRE
                                                                                        , oDeclaracion.VID_FECHA
                                                                                        , oDeclaracion.VID_HOMOCLAVE
                                                                                        , oDeclaracion.NID_DECLARACION
                                                                                        , oDeclaracion.ALTA.ALTA_COMODATOs[Indice].NID_COMODATO
                                                                                        , Convert.ToInt32(cmdNID_TIPO_VEHICULO.SelectedValue())
                                                                                        , Convert.ToInt32(cmbMarca.SelectedValue())
                                                                                        , dpModelo.SelectedValue
                                                                                        , txtTipo.Text
                                                                                        , txtvSerie.Text
                                                                                        , Convert.ToInt32(cmbnIdPaisOrigen.SelectedValue())
                                                                                        , cmbcIdEntidadFederativaOrigen.SelectedValue
                                                                                                     );
                }
            }
            catch (Exception ex)
            {
                
            }
            mppDatos.Hide();
            _oDeclaracion = oDeclaracion;
        }
        private void GuardaDatos()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_COMODATO b;
            
            int Selector;

            if (idInmueble.Visible == true)
                Selector = 0;

            else
                Selector = 1;


            try
            {
                oDeclaracion.ALTA.Add_ALTA_COMODATOs(
                                                      cmbTipoPersona.SelectedValue
                                                      , txtvNombre.Text
                                                      , txtvRFC.Text
                                                      , Convert.ToInt32(cmbNID_TIPO_RELACION.SelectedValue())
                                                      , txtObservaciones.Text
                                                      );

                if (Selector == 0)
                {
                    oDeclaracion.ALTA.Add_ALTA_COMODATO_INMUEBLEs(
                                                                 Convert.ToInt32(cmbNID_TIPO_INMUEBLE.SelectedValue())
                                                                 , txtcCodigoPostal.Text
                                                                 , Convert.ToInt32(cmbnIdPais.SelectedValue())
                                                                 , cmbcIdEntidadFederativa.SelectedValue
                                                                 , cmbMunicipio.SelectedValue
                                                                 , txtColoniaParticular.Text
                                                                 , ("|" + txtEdo_Provincia.Text + "|" + txtCalle.Text + "|" + txtNumExterior.Text + "|" + txtNumInterior.Text + "|").ToString()
                                                                );
                    
                }
                else
                {
                    oDeclaracion.ALTA.Add_ALTA_COMODATO_VEHICULOs(
                                                                Convert.ToInt32(cmdNID_TIPO_VEHICULO.SelectedValue())
                                                                , Convert.ToInt32(cmbMarca.SelectedValue())
                                                                , dpModelo.SelectedValue
                                                                , txtTipo.Text
                                                                , txtvSerie.Text
                                                                , Convert.ToInt32(cmbnIdPaisOrigen.SelectedValue())
                                                                , cmbcIdEntidadFederativaOrigen.SelectedValue
                                                                );
                }
                
                string Contenedor;
                string Identifica;
                string Principal;
                string Secundario;
                b = oDeclaracion.ALTA.ALTA_COMODATOs.Last();


                int x = grdComoDato.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oDeclaracion.ALTA.ALTA_COMODATOs.Count - 1;
                string ValoresRegreso = TraeComplementoT(b.NID_COMODATO);
                Identifica = ValoresRegreso.Split('|')[1];
                if (ValoresRegreso.Split('|')[0] == "1")
                {
                    ((Item)item).ID = String.Concat("Inmueble_", oDeclaracion.ALTA.ALTA_COMODATOs.Count - 1);
                    Contenedor = "../../Images/CAT_TIPO_INMUEBLE/";
                    Principal = ValoresRegreso.Split('|')[4] + " Número" + ValoresRegreso.Split('|')[5];
                    Secundario = "Colonia " + ValoresRegreso.Split('|')[8] + " C.P. " + ValoresRegreso.Split('|')[9];
                }
                else
                {
                    ((Item)item).ID = String.Concat("Vehículo_", oDeclaracion.ALTA.ALTA_COMODATOs.Count - 1);
                    Contenedor = "../../Images/CAT_TIPO_VEHICULO/";
                    Principal = ValoresRegreso.Split('|')[2];
                    Secundario = "Serie " + ValoresRegreso.Split('|')[3];
                }

                ((Item)item).TextoPrincipal = Principal;
                ((Item)item).TextoSecundario = Secundario;
                ((Item)item).ImageUrl = String.Concat(Contenedor, Identifica, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grdComoDato.Controls.AddAt( x, item);
                mppDatos.Hide();
            }
            catch (Exception ex)
            {
               
                Pinta();
            }
            
            _oDeclaracion = oDeclaracion;
           
        }
        protected void btnCerrarComodo_Click(object sender, EventArgs e)
        {
            mppDatos.Hide();
        }

        protected void cmbTipoPersona_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void cmbTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoBien.SelectedValue == "1")
            {
                this.idVeviculos.Visible = false;
                this.idInmueble.Visible = true;
            }
            if (cmbTipoBien.SelectedValue == "2")
            {
                this.idVeviculos.Visible = true;
                this.idInmueble.Visible = false;
            }

        }

        protected void cmbNID_TIPO_RELACION_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbNID_TIPO_INMUEBLE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmdNID_TIPO_VEHICULO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        protected void cmbnIdPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederaDir = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederaDir.NID_PAIS = new Declara_V2.IntegerFilter(cmbnIdPais.SelectedValue());
            oEntidadFederaDir.select();
            cmbcIdEntidadFederativa.DataBind(oEntidadFederaDir.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            cmbcIdEntidadFederativa_SelectedIndexChanged(sender, e);
            if (cmbnIdPais.SelectedValue == "1")
            {
                lblLocalidad.Text = "Colonia/localidad";
                idMunicipio.Visible = true;
                cmbcIdEntidadFederativa.Visible = true;
                idEdoProv.Visible = false;
            }
            else
            {
                lblLocalidad.Text = "Ciudad/localidad";
                idMunicipio.Visible = true;
                cmbcIdEntidadFederativa.Visible = true;
                idEdoProv.Visible = true;
            }
        }

        protected void cmbcIdEntidadFederativa_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
            omun.NID_PAIS = new Declara_V2.IntegerFilter(cmbnIdPais.SelectedValue());
            omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbcIdEntidadFederativa.SelectedValue);
            omun.select();
            cmbMunicipio.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
        }

        protected void txtcCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            if (txtcCodigoPostal.Text.Length == 5)
            {
                try
                {
                    blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(txtcCodigoPostal.Text);
                    cmbnIdPais.SelectedValue = oCodigo.NID_PAIS.ToString();
                    cmbnIdPais_SelectedIndexChanged(sender, e);
                    cmbcIdEntidadFederativa.SelectedValue = oCodigo.CID_ENTIDAD_FEDERATIVA;
                    cmbcIdEntidadFederativa_SelectedIndexChanged(sender, e);
                    cmbMunicipio.SelectedValue = oCodigo.CID_MUNICIPIO;
                    txtColoniaParticular.Text = oCodigo.V_COLONIA;

                }
                catch
                {
                }
            }
        }

        protected void cmbnIdPaisOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbnIdPaisOrigen.SelectedValue());
            oEntidadFederativa.select();
            cmbcIdEntidadFederativaOrigen.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            
        }
        private string TraeComplementoT(Int32 NID_COMODATO)
        {
            string Tipo_Comodo;
            blld_DECLARACION y = _oDeclaracion;
            string _Tipo = nBusca_Inmueble(y.VID_NOMBRE, y.VID_FECHA, y.VID_HOMOCLAVE, y.NID_DECLARACION, NID_COMODATO);
            if (_Tipo.ToString().Length > 0)
            {
                Tipo_Comodo = _Tipo;
            }
            else
            {
                Tipo_Comodo = nNBusca_Vehiculo(y.VID_NOMBRE, y.VID_FECHA, y.VID_HOMOCLAVE, y.NID_DECLARACION, NID_COMODATO);
            }

            return Tipo_Comodo;
        }

        internal static string nBusca_Inmueble(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO)
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in dbInt.ALTA_COMODATO_INMUEBLE
                              where p.VID_NOMBRE == VID_NOMBRE &&
                                    p.VID_FECHA == VID_FECHA &&
                                    p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                    p.NID_DECLARACION == NID_DECLARACION &&
                                    p.NID_COMODATO == NID_COMODATO
                              select "1|" + p.NID_TIPO.ToString() + "|" + p.V_DOMICILIO + "|" + p.V_COLONIA + "|" + p.C_CODIGO_POSTAL).First());
                return query;
            }
            catch
            {
                return "";
            }
        }
        internal static string nNBusca_Vehiculo(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO)
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in dbInt.ALTA_COMODATO_VEHICULO
                              where p.VID_NOMBRE == VID_NOMBRE &&
                                    p.VID_FECHA == VID_FECHA &&
                                    p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                    p.NID_DECLARACION == NID_DECLARACION &&
                                    p.NID_COMODATO == NID_COMODATO
                              select "2|" + p.NID_TIPO_VEHICULO.ToString() + "|" + p.V_DESCRIPCION + "|" + p.E_NUMERO_SERIE).First());
                return query;
            }
            catch
            {
                return null;
            }
        }
        internal static void nBorra_Vehiculo(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO)
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();

            var x = (from p in dbInt.ALTA_COMODATO_VEHICULO
                     where p.VID_NOMBRE == VID_NOMBRE &&
                           p.VID_FECHA == VID_FECHA &&
                           p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                           p.NID_DECLARACION == NID_DECLARACION &&
                           p.NID_COMODATO == NID_COMODATO
                     select p).FirstOrDefault();

            dbInt.ALTA_COMODATO_VEHICULO.Remove(x);
            dbInt.SaveChanges();
        }

        internal static void Nborra_Inmueble(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO)
        {
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();

            var x = (from p in dbInt.ALTA_COMODATO_INMUEBLE
                     where p.VID_NOMBRE == VID_NOMBRE &&
                           p.VID_FECHA == VID_FECHA &&
                           p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                           p.NID_DECLARACION == NID_DECLARACION &&
                           p.NID_COMODATO == NID_COMODATO
                     select p).FirstOrDefault();

            dbInt.ALTA_COMODATO_INMUEBLE.Remove(x);
            dbInt.SaveChanges();
        }
    }
}