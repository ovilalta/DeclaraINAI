using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DeclaraINE.Formas.DeclaracionModificacion
{
    public partial class DatosGenerales : Pagina, IDeclaracionInicial
    {
        internal SubSecciones SubSeccionActiva
        {
            get => (SubSecciones)ViewState["SubSeccionActiva"];
            set => ViewState["SubSeccionActiva"] = value;
        }
        internal Boolean lEditar
        {
            get
            {
                if (ViewState["lEditar"] == null)
                    return true;
                return (Boolean)ViewState["lEditar"];
            }
            set
            {
                if (ViewState["lEditar"] == null)
                    ViewState.Add("lEditar", value);
                else
                    ViewState["lEditar"] = value;
            }
            //get => (Boolean)ViewState["lEditar"];
            //set => ViewState["lEditar"] = value;
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
        public Boolean lDeside
        {
            get
            {
                if (ViewState["lDeside"] == null)
                    return false;
                return (Boolean)ViewState["lDeside"];
            }
            set
            {
                if (ViewState["lDeside"] == null)
                    ViewState.Add("lDeside", value);
                else
                    ViewState["lDeside"] = value;
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



        blld_DECLARACION_DEPENDIENTES _oDependiente
        {
            get => (blld_DECLARACION_DEPENDIENTES)Session["oDependiente"];
            set => SessionAdd("oDependiente", value);
        }



        internal enum SubSecciones
        {
            DatosPersonales,
            DomicilioParticular,
            DomicilioLaboral,
            Cargo,
            DependienteEconomicos,
            DatosCurriculares,
            ExperienciaLaboral,

        }

        internal enum Paneles
        {
            pnlDatosPersonales,
            pnlDomicilioParticular,
            pnlDomicilioLaboral,
            pnlCargo,
            pnlDependientes,
            pnlPareja
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

        internal Int32 IndiceItemSeleccionadoDep
        {
            get
            {
                if (ViewState["IndiceItemSeleccionadoDep"] == null) return -1;
                return (Int32)ViewState["IndiceItemSeleccionadoDep"];
            }

            set
            {
                if (ViewState["IndiceItemSeleccionadoDep"] == null) ViewState.Add("IndiceItemSeleccionadoDep", value);
                ViewState["IndiceItemSeleccionadoDep"] = value;
            }

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            _oDeclaracion = oDeclaracion;

            blld_DECLARACION_DEPENDIENTES o;
            int nDepPareja = _oDeclaracion.DECLARACION_DEPENDIENTESs.Where(c => c.L_PAREJA == true).ToList().Count();

            for (int x = 0; x < nDepPareja; x++)
            {
                o = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.L_PAREJA == true).ToList()[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = o.NID_DEPENDIENTE;
                ((Item)item).State = true;
                ((Item)item).ID = String.Concat("grd", o.NID_DEPENDIENTE);
                ((Item)item).TextoPrincipal = o.V_TIPO_DEPENDIENTE;
                ((Item)item).TextoSecundario = o.V_NOMBRE_COMPLETO;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", o.NID_TIPO_DEPENDIENTE, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grd.Controls.AddAt(0 + x, item);
            }

            int nDependiente = _oDeclaracion.DECLARACION_DEPENDIENTESs.Where(c => c.L_PAREJA == false).ToList().Count();

            for (int x = 0; x < nDependiente; x++)
            {
                o = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.L_PAREJA == false).ToList()[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = o.NID_DEPENDIENTE;
                ((Item)item).State = false;
                ((Item)item).ID = String.Concat("grdx7", o.NID_DEPENDIENTE);
                ((Item)item).TextoPrincipal = o.V_TIPO_DEPENDIENTE;
                ((Item)item).TextoSecundario = o.V_NOMBRE_COMPLETO;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", o.NID_TIPO_DEPENDIENTE, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grdx7.Controls.AddAt(0 + x, item);
            }

            if (!IsPostBack)
            {
                txtF_POSESION_C.StartDate = new DateTime(1900, 1, 1);
                txtF_INGRESO_C.StartDate = new DateTime(1900, 1, 1);
                txtF_POSESION_C.EndDate = DateTime.Today.AddDays(-1);
                txtF_INGRESO_C.EndDate = DateTime.Today.AddDays(-1);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            ((HtmlControl)Master.FindControl("liDatosGenerales")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu1")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            if (!IsPostBack)
            {
                _oDeclaracion = oDeclaracion;
                ctrlDependiente1.Requerido = btnGuardarDependiente.ClientID;
                //blld_DECLARACION oDeclaracion = _oDeclaracion;

                ((Button)Master.FindControl("btnSiguiente")).Text = "Guardar";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "saveNext";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Guardar e ir al siguiente apartado";

                blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
                oCAT_PAIS.select();
                // SME-NF-I
                cmbnIdPaisNacimiento.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbPaisDomParticular.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbCARGO_NID_PAIS_OTRO.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);

                //cmbPaisDomimicioParticular.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                //cmbPaisDomimicioParticular.SelectedValue = "1";
                //cmbPaisDomimicioParticular_SelectedIndexChanged(sender, e);

                cmbNacionalidad.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_NACIONALIDAD_M, false);
                //cmbnIdPaisNacimiento.SelectedValue = "1";

                cmbEstadoCivil.DataBinder<blld__l_CAT_ESTADO_CIVIL>(new blld__l_CAT_ESTADO_CIVIL(), CAT_ESTADO_CIVIL.Properties.NID_ESTADO_CIVIL, CAT_ESTADO_CIVIL.Properties.V_ESTADO_CIVIL, false);
                cmbRegimenMatrimonial.DataBinder<blld__l_CAT_REGIMEN_MATRIMONIAL>(new blld__l_CAT_REGIMEN_MATRIMONIAL(), CAT_REGIMEN_MATRIMONIAL.Properties.NID_REGIMEN_MATRIMONIAL, CAT_REGIMEN_MATRIMONIAL.Properties.V_REGIMEN_MATRIMONIAL, false);

                cmbPaisDomParticular.Items.Insert(0, new ListItem(String.Empty));
                cmbnIdPaisNacimiento.Items.Insert(0, new ListItem(String.Empty));
                cmbNacionalidad.Items.Insert(0, new ListItem(String.Empty));
                //cmbCARGO_NID_PAIS_OTRO.Items.Insert(0, new ListItem(String.Empty));
                cmbEstadoCivil.Items.Insert(0, new ListItem(String.Empty));
                cmbRegimenMatrimonial.Items.Insert(0, new ListItem(String.Empty));

                cmbPaisDomParticular.SelectedIndex = 0;
                cmbnIdPaisNacimiento.SelectedIndex = 0;
                //cmbCARGO_NID_PAIS_OTRO.SelectedIndex = 0;
                cmbNacionalidad.SelectedIndex = 0;
                cmbEstadoCivil.SelectedIndex = 0;
                cmbRegimenMatrimonial.SelectedIndex = 0;
                cmbPaisDomParticular_SelectedIndexChanged(sender, e);
                cmbCARGO_NID_PAIS_OTRO_SelectedIndexChanged(sender, e);
                // Cargo Nivel Órden de Gobierno
                rbtOtroOrdenGobierno.Items.Insert(0, new ListItem("Federal", "1"));
                rbtOtroOrdenGobierno.Items.Insert(1, new ListItem("Estatal", "2"));
                rbtOtroOrdenGobierno.Items.Insert(2, new ListItem("Municipal / Alcaldía", "3"));
                // Cargo Ambito Público
                rbtAmbitoPublico.Items.Insert(0, new ListItem("Ejecutivo", "1"));
                rbtAmbitoPublico.Items.Insert(1, new ListItem("Legislativo ", "3"));
                rbtAmbitoPublico.Items.Insert(2, new ListItem("Judicial ", "2"));
                rbtAmbitoPublico.Items.Insert(3, new ListItem("Órgano Autónomo", "4"));
                if (ControlDeNavegacion != null)
                {
                    ViewState["SubSeccionActiva"] = ((SubSecciones)ControlDeNavegacion);
                    this.SubSeccionActiva = ((SubSecciones)ControlDeNavegacion);
                    if (this.SubSeccionActiva.ToString() == "DatosPersonales")
                        this.lDeside = true;
                    else if (this.SubSeccionActiva.ToString() == "DomicilioParticular")
                        this.lDeside = true;
                    else
                        this.lDeside = false;
                    lBanderaActualizaAnterior = false;
                    Siguiente();
                    ControlDeNavegacion = null;
                }
                else
                {
                    ((Button)Master.FindControl("btnAnterior")).Visible = false;
                    ViewState["SubSeccionActiva"] = SubSecciones.DatosPersonales;
                    lBanderaActualizaAnterior = true;
                    ltrSubTitulo.Text = "<h6> Nota: Sírvase revisar las Normas e Instructivo para el llenado y presentación del formato de Declaraciones de Situación Patrimonial y de Intereses </br>  <p align='left'>  C. TITULAR DEL ORGANO INTERNO DE CONTROL : BAJO PROTESTA DE DECIR VERDAD, PRESENTO A USTED MI DECLARACIÓN DE SITUACIÓN PATRIMONIAL Y DE INTERESES, CONFORME A LO DISPUESTO EN LA LEY GENERAL DE RESPONSABILIDADES ADMINISTRATIVAS, LA LEY GENERAL DEL SISTEMA NACIONAL ANTICORRUPCIÓN Y LA NORMATIVIDAD APLICABLE</p></H6> 1. Datos Generales";
                    pnlDatosPersonales.Visible = true;
                    pnlDomicilioParticular.Visible = false;
                    pnlCargo.Visible = false;
                    pnlDomicilioLaboral.Visible = false;
                    pnlDependientes.Visible = false;
                }

                try
                {
                    // SME-NF-I
                    cmbcGenero.SelectedValue = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
                    txtvCURP.Text = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
                    txtObservacionesDatosGenerales.Text = oDeclaracion.DECLARACION_PERSONALES.E_OBSERVACIONES;
                    cmbnIdPaisNacimiento.SelectedValue = oDeclaracion.DECLARACION_PERSONALES.NID_PAIS.ToString();
                    cmbnIdPaisNacimiento_SelectedIndexChanged(sender, e);
                    cmbcIdEntidadFederativaNacimiento.SelectedValue = oDeclaracion.DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA;
                    cmbNacionalidad.SelectedValue = oDeclaracion.DECLARACION_PERSONALES.NID_NACIONALIDAD.ToString();
                    cmbEstadoCivil.SelectedValue = oDeclaracion.DECLARACION_PERSONALES.NID_ESTADO_CIVIL.ToString();

                    txtV_CORREO_PERSONAL.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO;
                    //OEVM 20230612 Se agrega validación para considerar el correo institucional como el dato a reccuperar para los casos donde tienen correos personales como principales
                    txtV_CORREO_INE.Text = _oUsuario.USUARIO_CORREOs.Where(p => p.L_CONFIRMADO == true && p.L_PRINCIPAL == true && p.V_CORREO.Contains("@inai.org.mx")).First().V_CORREO;

                    txtV_TEL_PARTICULAR.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR;
                    txtV_TEL_CELULAR.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR;
                    if (oDeclaracion.DECLARACION_REGIMEN_MATRIMONIALs.Count > 0)
                        cmbRegimenMatrimonial.SelectedValue = oDeclaracion.DECLARACION_REGIMEN_MATRIMONIALs.First().NID_REGIMEN_MATRIMONIAL.ToString();
                }
                catch (Exception ex)
                {
                    if (ex is Declara_V2.Exceptions.RowNotFoundException)
                    {
                        cmbcGenero.SelectedValue = "1";
                        txtvCURP.Text = String.Empty;
                        cmbnIdPaisNacimiento.SelectedValue = "1";
                        cmbnIdPaisNacimiento_SelectedIndexChanged(sender, e);
                        cmbcIdEntidadFederativaNacimiento.SelectedValue = "1";
                        cmbNacionalidad.SelectedValue = "1";
                        //cmbEstadoCivil.SelectedValue = "1";
                        cmbEstadoCivil.SelectedIndex = 0;
                    }
                    else
                    {
                        throw ex;
                    }
                    // SME-NF-F
                }

                txtvPrimerA.Text = oUsuario.V_PRIMER_A;
                txtvSegundoA.Text = oUsuario.V_SEGUNDO_A;
                txtvNombre.Text = oUsuario.V_NOMBRE;
                txtfNacimiento.Text = oUsuario.F_NACIMIENTO.ToString(strFormatoFecha);
                txtvIdNombre.Text = oUsuario.VID_NOMBRE;
                txtvIdFecha.Text = oUsuario.VID_FECHA;
                txtVIdHomoClave.Text = oUsuario.VID_HOMOCLAVE;
                int idPuesto = oDeclaracion.DECLARACION_CARGO.NID_PUESTO;

                blld__l_CAT_PRIMER_NIVEL oPrimerNivel = new blld__l_CAT_PRIMER_NIVEL();
                oPrimerNivel.OrderByCriterios.Add(new Declara_V2.Order(CAT_PRIMER_NIVEL.Properties.V_PRIMER_NIVEL));
                oPrimerNivel.select();
                cmbVID_PRIMER_NIVEL.DataSource = oPrimerNivel.lista_CAT_PRIMER_NIVEL.OrderBy(x => x.V_PRIMER_NIVEL);
                cmbVID_PRIMER_NIVEL.DataTextField = CAT_PRIMER_NIVEL.Properties.V_PRIMER_NIVEL.ToString();
                cmbVID_PRIMER_NIVEL.DataValueField = CAT_PRIMER_NIVEL.Properties.VID_PRIMER_NIVEL.ToString();
                cmbVID_PRIMER_NIVEL.DataBind();
                txtVID_PRIMER_NIVEL_TextChanged(cmbVID_PRIMER_NIVEL, null);

                blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                string valorSeleccionado = "";
                if (cmbVID_PRIMER_NIVEL.SelectedValue != "")
                {
                    valorSeleccionado = cmbVID_PRIMER_NIVEL.SelectedValue.Substring(0, 3);
                    oPuesto.select();
                    if (valorSeleccionado != "210")
                    {
                        cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO
                                                .Where(p => p.VID_PUESTO.StartsWith(valorSeleccionado) || p.VID_PUESTO.Contains("CH-"))
                                                .OrderBy(x => x.VID_PUESTO)
                                                .ThenBy(x => x.VID_NIVEL)
                                                .ThenBy(x => x.V_PUESTO);
                    }
                    else
                    {
                        cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO
                        .Where(p => p.VID_PUESTO.StartsWith("210") || p.VID_PUESTO.StartsWith("211") || p.VID_PUESTO.StartsWith("212") || p.VID_PUESTO.StartsWith("214") || p.VID_PUESTO.Contains("CH-"))
                        .OrderBy(x => x.VID_PUESTO)
                        .ThenBy(x => x.VID_NIVEL)
                        .ThenBy(x => x.V_PUESTO);
                    }

                }

                cmbVID_CLAVEPUESTO.DataTextField = CAT_PUESTO.Properties.CLAVE_NOMBRE_PUESTO.ToString();
                cmbVID_CLAVEPUESTO.DataValueField = CAT_PUESTO.Properties.NID_PUESTO.ToString(); //Trae la descripcion completa para el combo
                cmbVID_CLAVEPUESTO.DataBind();
                cmbVID_CLAVEPUESTO.SelectedValue = idPuesto.ToString();

                grdPreguntas.DataBind(oDeclaracion.DECLARACION_RESTRICCIONESs);
                blld__l_CAT_ENTIDAD_FEDERATIVA oFed = new blld__l_CAT_ENTIDAD_FEDERATIVA();
                oFed.select();
                

                cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged(sender, e);
                active();

            }
            ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "mostrarAviso", "$('#mdAvisoModificacion').hide()", true);
            oUsuario = _oUsuario;
            oDeclaracion = _oDeclaracion;


        }

        protected void cmbnIdPaisNacimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbnIdPaisNacimiento.SelectedValue());
            oEntidadFederativa.select();
            cmbcIdEntidadFederativaNacimiento.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            //cmbcIdEntidadFederativaNacimiento_SelectedIndexChanged(sender, e);
        }


        #region *** Botones Navegacion ***
        public void Anterior()
        {
            switch (SubSeccionActiva)
            {
                case SubSecciones.DatosPersonales:
                    break;
                case SubSecciones.DomicilioParticular:
                    ltrSubTitulo.Text = "1. Datos Generales";
                    ((Button)Master.FindControl("btnAnterior")).Visible = false;
                    pnlDatosPersonales.Visible = true;
                    pnlDomicilioParticular.Visible = false;
                    pnlCargo.Visible = false;
                    pnlDomicilioLaboral.Visible = false;
                    pnlDependientes.Visible = false;
                    SubSeccionActiva = SubSecciones.DatosPersonales;
                    break;
                case SubSecciones.Cargo:
                    //ltrSubTitulo.Text = "2. Domicilio del Declarante";
                    //pnlDatosPersonales.Visible = false;
                    //pnlDomicilioParticular.Visible = true;
                    //pnlCargo.Visible = false;
                    //pnlDomicilioLaboral.Visible = false;
                    //pnlDependientes.Visible = false;
                    //SubSeccionActiva = SubSecciones.DomicilioParticular;
                    Response.Redirect("DatosCurriculares.aspx");
                    break;
                case SubSecciones.DependienteEconomicos:
                    //ltrSubTitulo.Text = "2. Domicilio del Declarante - Domicilio Laboral";
                    //pnlDatosPersonales.Visible = false;
                    //pnlDomicilioParticular.Visible = false;
                    //pnlCargo.Visible = false;
                    //pnlDomicilioLaboral.Visible = true;
                    //pnlDependientes.Visible = false;
                    //SubSeccionActiva = SubSecciones.DomicilioLaboral;
                    Response.Redirect("ExperienciaLaboral.aspx");
                    break;
                case SubSecciones.DomicilioLaboral:
                    //ltrSubTitulo.Text = "2. Domicilio del Declarante - Domicilio Laboral";
                    //pnlDatosPersonales.Visible = false;
                    //pnlDomicilioParticular.Visible = false;
                    //pnlCargo.Visible = false;
                    //pnlDomicilioLaboral.Visible = true;
                    pnlDependientes.Visible = false;
                    //SubSeccionActiva = SubSecciones.DomicilioLaboral;
                    Response.Redirect("ExperienciaLaboral.aspx");
                    break;

            }
            active();
            if (SubSeccionActiva == SubSecciones.DependienteEconomicos)
            {
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
            }
            else
            {
                ((Button)Master.FindControl("btnSiguiente")).Text = "Guardar";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "saveNext";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Guardar e ir al siguiente apartado";
            }
        }
        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            Boolean lBanderaPasa = true;
            try
            {
                switch (SubSeccionActiva)
                {
                    case SubSecciones.DatosPersonales:
                        if (lBanderaActualizaAnterior)
                        {
                            try
                            {
                                // SME-NF-I
                                oDeclaracion.DECLARACION_PERSONALES.C_GENERO = cmbcGenero.SelectedValue;
                                oDeclaracion.DECLARACION_PERSONALES.C_CURP = txtvCURP.Text;
                                oDeclaracion.DECLARACION_PERSONALES.NID_PAIS = cmbnIdPaisNacimiento.SelectedValue();
                                oDeclaracion.DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA = cmbcIdEntidadFederativaNacimiento.SelectedValue;
                                oDeclaracion.DECLARACION_PERSONALES.NID_NACIONALIDAD = cmbNacionalidad.SelectedValue();
                                oDeclaracion.DECLARACION_PERSONALES.NID_ESTADO_CIVIL = cmbEstadoCivil.SelectedValue();
                                oDeclaracion.DECLARACION_PERSONALES.E_OBSERVACIONES = txtObservacionesDatosGenerales.Text;
                                oDeclaracion.DECLARACION_PERSONALES.update();

                                //TODO: COTA - REGIMEN_MATRIMONIAL MODIF
                                if (oDeclaracion.DECLARACION_REGIMEN_MATRIMONIALs.Count > 0)
                                {
                                    oDeclaracion.DECLARACION_REGIMEN_MATRIMONIALs.First().NID_REGIMEN_MATRIMONIAL = cmbRegimenMatrimonial.SelectedValue();
                                    oDeclaracion.DECLARACION_REGIMEN_MATRIMONIALs.First().update();
                                }
                                else
                                {
                                    oDeclaracion.Add_DECLARACION_REGIMEN_MATRIMONIALs(
                                        oUsuario.VID_NOMBRE,
                                        oUsuario.VID_FECHA,
                                        oUsuario.VID_HOMOCLAVE,
                                        oDeclaracion.NID_DECLARACION,
                                        cmbRegimenMatrimonial.SelectedValue()
                                    );
                                }

                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO = txtV_CORREO_PERSONAL.Text;

                                //Meter logica para guardar datos de correo personal en Usuario_Correo - OEVM 4nov2021 - Peticion de Alex Rdz

                                if (txtV_CORREO_PERSONAL.Text != null)
                                {

                                    string rfc = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE;
                                    string correoPersonal = txtV_CORREO_PERSONAL.Text;

                                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                                    string connString = db.Database.Connection.ConnectionString;

                                    int existeCorreo = db.USUARIO_CORREO.Where(p => p.VID_NOMBRE.Equals(oUsuario.VID_NOMBRE) && p.VID_FECHA.Equals(oUsuario.VID_FECHA) && p.VID_HOMOCLAVE.Equals(oUsuario.VID_HOMOCLAVE) && p.V_CORREO.Equals(txtV_CORREO_PERSONAL.Text)).Count();

                                    if (existeCorreo == 0)
                                    {
                                        string sql = "SP_InsertaCorreoPersonal";
                                        using (SqlConnection conn = new SqlConnection(connString))
                                        {
                                            conn.Open();
                                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                                            {

                                                cmd.CommandType = CommandType.StoredProcedure;
                                                cmd.Parameters.AddWithValue("@RFC", rfc);
                                                cmd.Parameters.AddWithValue("@CorreoPersonal", correoPersonal);
                                                cmd.ExecuteNonQuery();
                                            }
                                            conn.Close();
                                        }
                                    }
                                }

                                //Termina logica para insertar datos en Usuario_Correo
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR = txtV_TEL_PARTICULAR.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR = txtV_TEL_CELULAR.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.update();

                                oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL = txtV_CORREO_INE.Text;
                                oDeclaracion.DECLARACION_DOM_LABORAL.update();
                            }

                            catch (Exception ex)
                            {
                                if (ex is RowNotFoundException)
                                {
                                    oDeclaracion.DECLARACION_PERSONALES = new blld_DECLARACION_PERSONALES(
                                                                               oDeclaracion.VID_NOMBRE,
                                                                               oDeclaracion.VID_FECHA,
                                                                               oDeclaracion.VID_HOMOCLAVE,
                                                                               oDeclaracion.NID_DECLARACION,
                                                                               cmbcGenero.SelectedValue,
                                                                               txtvCURP.Text,
                                                                               cmbnIdPaisNacimiento.SelectedValue(),
                                                                               cmbcIdEntidadFederativaNacimiento.SelectedValue,
                                                                               cmbNacionalidad.SelectedValue(),
                                                                               cmbEstadoCivil.SelectedValue(),
                                                                               null,
                                                                               null,
                                                                               null,
                                                                               txtObservacionesDatosGenerales.Text,
                                                                               cmbRegimenMatrimonial.SelectedValue()
                                                                               );
                                    
                                    oDeclaracion.DECLARACION_DOM_PARTICULAR = new blld_DECLARACION_DOM_PARTICULAR(oDeclaracion.VID_NOMBRE
                                                                                                                         , oDeclaracion.VID_FECHA
                                                                                                                         , oDeclaracion.VID_HOMOCLAVE
                                                                                                                         , oDeclaracion.NID_DECLARACION
                                                                                                                         , ""
                                                                                                                         , 1
                                                                                                                         , "01"
                                                                                                                         , "001"
                                                                                                                         , ""
                                                                                                                         , ""
                                                                                                                         , ""
                                                                                                                         , ""
                                                                                                                         , txtV_CORREO_PERSONAL.Text
                                                                                                                         , String.Concat(txtV_TEL_PARTICULAR.Text)
                                                                                                                         , txtV_TEL_CELULAR.Text
                                                                                                                         , null
                                                                                                                         , "01"
                                                                                                                         , "001");


                                    // SME-NF-F
                                }
                                else if (ex is CustomException || ex is ConvertionException)
                                {
                                    lBanderaPasa = false;
                                    MsgBox.ShowDanger(ex.Message);

                                }
                                else
                                {
                                    lBanderaPasa = false;
                                    throw ex;
                                }
                            }
                            lBanderaActualizaAnterior = true;
                            marcaApartado(ref oDeclaracion, 2);
                        }
                        if (lBanderaPasa)
                        {
                            ltrSubTitulo.Text = "2. Domicilio del declarante";
                            ((Button)Master.FindControl("btnAnterior")).Visible = true;
                            pnlDatosPersonales.Visible = false;
                            pnlDomicilioParticular.Visible = true;
                            pnlCargo.Visible = false;
                            pnlDomicilioLaboral.Visible = false;
                            pnlDependientes.Visible = false;
                            SubSeccionActiva = SubSecciones.DomicilioParticular;
                            try
                            {
                                txtcCodigoPostal.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL;
                                cmbPaisDomParticular.SelectedValue = oDeclaracion.DECLARACION_DOM_PARTICULAR.NID_PAIS.ToString();
                                cmbPaisDomParticular_SelectedIndexChanged(cmbPaisDomParticular, null);
                                
                                cmbEntidadFederativaDomParticular.SelectedValue = oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA;
                                cmbEntidadFederativaDomParticular_SelectedIndexChanged(cmbEntidadFederativaDomParticular, null);
                                cmbMunicipioDomParticular.SelectedValue = oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO;                                

                                txtColoniaParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_COLONIA;
                                txtCalleDomParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CALLE;
                                txtNumeroExteriorDomParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_NUMERO_EXTERNO;
                                txtNumeroInteriorDomParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_NUMERO_INTERNO;
                                //txtV_TEL_PARTICULAR.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR;
                                //txtV_TEL_CELULAR.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR;
                                //txtV_CORREO_PERSONAL.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO;
                                txtE_OBSERVACIONES.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES;
                            }
                            catch (Exception ex)
                            {
                                if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                {
                                    txtcCodigoPostal.Text = String.Empty;
                                    cmbPaisDomParticular.SelectedIndex = 0;
                                    cmbEntidadFederativaDomParticular.SelectedIndex = 0;
                                    cmbMunicipioDomParticular.SelectedIndex = 0;
                                    txtColoniaParticular.Text = String.Empty;
                                    txtCalleDomParticular.Text = String.Empty;
                                    txtNumeroExteriorDomParticular.Text = String.Empty;
                                    txtNumeroInteriorDomParticular.Text = String.Empty;
                                    txtV_TEL_PARTICULAR.Text = String.Empty;
                                    txtV_TEL_CELULAR.Text = String.Empty;
                                    try
                                    {
                                        txtV_CORREO_PERSONAL.Text = oUsuario.USUARIO_CORREOs.Where(p => !p.L_PRINCIPAL && p.L_ACTIVO && p.L_CONFIRMADO).First().V_CORREO;
                                    }
                                    catch
                                    {
                                    }
                                }
                                else throw ex;
                            }
                        }
                        break;
                    case SubSecciones.DomicilioParticular:

                        if (lBanderaActualizaAnterior)
                        {
                            try
                            {
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL = txtcCodigoPostal.Text;


                                oDeclaracion.DECLARACION_DOM_PARTICULAR.NID_PAIS = cmbPaisDomParticular.SelectedValue();

                                //if (cmbPaisDomParticular.SelectedValue == "1")
                                //{
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA = cmbEntidadFederativaDomParticular.SelectedValue;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO = cmbMunicipioDomParticular.SelectedValue;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_ENTIDAD_FEDERATIVA = String.Empty;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_MUNICIPIO = String.Empty;
                                ////}
                                ////else
                                ////{
                                //    oDeclaracion.DECLARACION_DOM_PARTICULAR.V_ENTIDAD_FEDERATIVA = txtbEntidadFederativaDomicilioParticular.Text;
                                //    oDeclaracion.DECLARACION_DOM_PARTICULAR.V_MUNICIPIO = txtMunicipioDomicilioParticular.Text;
                                //}

                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_COLONIA = txtColoniaParticular.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CALLE = txtCalleDomParticular.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_NUMERO_EXTERNO = txtNumeroExteriorDomParticular.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_NUMERO_INTERNO = txtNumeroInteriorDomParticular.Text;
                                //oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO = txtV_CORREO_PERSONAL.Text;
                                //oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR = String.Concat(txtV_TEL_PARTICULAR.Text);
                                //oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR = txtV_TEL_CELULAR.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES = txtE_OBSERVACIONES.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.update();

                            }
                            catch (Exception ex)
                            {
                                if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                {
                                    oDeclaracion.DECLARACION_DOM_PARTICULAR = new blld_DECLARACION_DOM_PARTICULAR(oDeclaracion.VID_NOMBRE
                                                                                                                          , oDeclaracion.VID_FECHA
                                                                                                                          , oDeclaracion.VID_HOMOCLAVE
                                                                                                                          , oDeclaracion.NID_DECLARACION
                                                                                                                          , txtcCodigoPostal.Text
                                                                                                                          , cmbPaisDomParticular.SelectedValue()
                                                                                                                          , cmbEntidadFederativaDomParticular.SelectedValue
                                                                                                                          , cmbMunicipioDomParticular.SelectedValue
                                                                                                                          , txtColoniaParticular.Text
                                                                                                                          , txtCalleDomParticular.Text
                                                                                                                          , txtNumeroExteriorDomParticular.Text
                                                                                                                          , txtNumeroInteriorDomParticular.Text
                                                                                                                          , txtV_CORREO_PERSONAL.Text
                                                                                                                          , String.Concat(txtV_TEL_PARTICULAR.Text)
                                                                                                                          , txtV_TEL_CELULAR.Text
                                                                                                                          , txtE_OBSERVACIONES.Text
                                                                                                                          , txtbEntidadFederativaDomicilioParticular.Text
                                                                                                                          , txtMunicipioDomicilioParticular.Text);
                                }
                                else
                                {
                                    MsgBox.ShowDanger(ex.Message);
                                    lBanderaPasa = false;
                                }
                            }
                            lBanderaActualizaAnterior = true;
                            marcaApartado(ref oDeclaracion, 3);
                            lDeside = false;
                        }
                        if (lBanderaPasa)
                        {
                            if (lDeside == false)
                                Response.Redirect("DatosCurriculares.aspx");
                            else
                            {
                                lDeside = false;
                                ltrSubTitulo.Text = "4. Datos del empleo, cargo o comisión actual";
                                pnlDatosPersonales.Visible = false;
                                pnlDomicilioParticular.Visible = false;
                                pnlCargo.Visible = true;
                                pnlDomicilioLaboral.Visible = false;
                                pnlDependientes.Visible = false;
                                SubSeccionActiva = SubSecciones.Cargo;

                                try
                                {


                                    cmbVID_PRIMER_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.VID_PRIMER_NIVEL;
                                    txtVID_PRIMER_NIVEL_TextChanged(cmbVID_PRIMER_NIVEL, null);
                                    cmbVID_SEGUNDO_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.VID_SEGUNDO_NIVEL;


                                    blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                                    oPuesto.select();
                                    //cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO;
                                    cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO;

                                    cmbVID_CLAVEPUESTO.DataTextField = CAT_PUESTO.Properties.VID_PUESTO.ToString();
                                    cmbVID_CLAVEPUESTO.DataValueField = CAT_PUESTO.Properties.NID_PUESTO.ToString();
                                    cmbVID_CLAVEPUESTO.DataBind();

                                    cmbVID_CLAVEPUESTO.SelectedValue = oDeclaracion.DECLARACION_CARGO.NID_PUESTO.ToString();
                                    cmbVID_CLAVEPUESTO_SelectedIndexChanged(cmbVID_CLAVEPUESTO, null);

                                    cmbVID_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.NID_PUESTO.ToString();
                                    cmbVID_NIVEL_SelectedIndexChanged(cmbVID_NIVEL, null);

                                    txt_DENOMINACION_CARGO.Text = oDeclaracion.DECLARACION_CARGO.V_FUNCION_PRINCIPAL;


                                    txtF_POSESION.Text = oDeclaracion.DECLARACION_CARGO.F_POSESION.ToString(strFormatoFecha);
                                    txtF_INGRESO.Text = oDeclaracion.DECLARACION_CARGO.F_INICIO.ToString(strFormatoFecha);

                                    // DATOS DEL DOMICILIO LABORAL

                                    C_CODIGO_POSTAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL;
                                    // cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue = oDeclaracion.DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA;
                                    //cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged(cmbCID_ENTIDAD_FEDERATIVA_LABORAL, null);
                                    // cmbCID_MUNICIPIO_LABORAL.SelectedValue = oDeclaracion.DECLARACION_DOM_LABORAL.CID_MUNICIPIO;
                                    txtV_COLONIA_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_COLONIA;

                                    try { txtV_DOMICILIO_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO.Split('|')[0]; } catch { }
                                    try { txtNumExteriorDOMICILIO_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO.Split('|')[1]; } catch { }
                                    try { txtNumInteriorDOMICILIO_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO.Split('|')[2]; } catch { }

                                    txtV_CORREO_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL;

                                    try { txtV_TELEFONO_LABORAL1.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[0]; } catch { }
                                    try { txtV_TELEFONO_LABORAL2.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[1]; } catch { }
                                    txtObservaciones.Text = oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES;
                                    // *************    DATOS OTRO EMPLEO
                                    rbtOtroOrdenGobierno.SelectedValue = oDeclaracion.DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO.ToString();
                                    rbtAmbitoPublico.SelectedValue = oDeclaracion.DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO.ToString();
                                    txtCargoEntePublico.Text = oDeclaracion.DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTE.ToString();
                                    if (txtCargoEntePublico.Text.Length > 0)
                                    {
                                        cbxOtroEmpleo.Checked = true;
                                        DivOtroEmpleo.Visible = true;
                                    }
                                    else
                                    {
                                        cbxOtroEmpleo.Checked = false;
                                        DivOtroEmpleo.Visible = false;
                                    }


                                    txtCargoAreaAdscripcion.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCION.ToString();
                                    txtCargoEmpleo.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_CARGO.ToString();
                                    string Manejo = oDeclaracion.DECLARACION_CARGO_OTRO.L_HONORARIOS.ToString();
                                    if (Manejo == "True")
                                    {
                                        cbxCargoHonorarios.Checked = true;

                                    }
                                    else if (Manejo == "False")
                                    {
                                        cbxCargoHonorarios.Checked = false;

                                    }

                                    txtCargoNivel.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_NIVEL_EMPLEO.ToString();
                                    txtCargoFuncion.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPAL.ToString();
                                    txtCargoFechaPosesion.Text = oDeclaracion.DECLARACION_CARGO_OTRO.F_POSESION.ToString(strFormatoFecha);
                                    try { txtCARGOV_TELEFONO.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_TEL_LABORAL.Split('|')[0]; } catch { }
                                    try { txtCARGOV_TELEFONO_EXT.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_TEL_LABORAL.Split('|')[1]; } catch { }
                                    txtCARGO_CODIGO_POSTAL_O.Text = oDeclaracion.DECLARACION_CARGO_OTRO.C_CODIGO_POSTAL.ToString();

                                    cmbCARGO_NID_PAIS_OTRO.SelectedValue = oDeclaracion.DECLARACION_CARGO_OTRO.NID_PAIS.ToString();
                                    cmbCARGO_NID_PAIS_OTRO_SelectedIndexChanged(cmbCARGO_NID_PAIS_OTRO, null);
                                    cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO.SelectedValue = oDeclaracion.DECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVA.ToString();
                                    cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO_SelectedIndexChanged(cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO, null);


                                    cmbCARGO_CID_MUNICIPIO_OTRO.SelectedValue = oDeclaracion.DECLARACION_CARGO_OTRO.CID_MUNICIPIO.ToString();
                                    txtCargoColonia.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_COLONIA.ToString();
                                    try { txtCargoV_DOMICILIO_O.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_DOMICILIO.Split('|')[0]; } catch { }
                                    try { txtCargoNumExteriorDOMICILIO_O.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_DOMICILIO.Split('|')[1]; } catch { }
                                    try { txtCargoNumInteriorDOMICILIO_O.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_DOMICILIO.Split('|')[2]; } catch { }
                                    try { txtCargoEstado.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_DOMICILIO.Split('|')[3]; } catch { }
                                    txtCargoObserva.Text = oDeclaracion.DECLARACION_CARGO_OTRO.V_OBSERVACIONES.ToString();
                                }
                                catch (Exception ex)
                                {
                                    if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                    {
                                        txtcCodigoPostal.Text = String.Empty;
                                        cmbPaisDomParticular.SelectedIndex = 0;
                                        cmbEntidadFederativaDomParticular.SelectedIndex = 0;
                                        cmbMunicipioDomParticular.SelectedIndex = 0;
                                        txtColoniaParticular.Text = String.Empty;
                                        txtCalleDomParticular.Text = String.Empty;
                                        txtNumeroExteriorDomParticular.Text = String.Empty;
                                        txtNumeroInteriorDomParticular.Text = String.Empty;
                                        txtV_TEL_PARTICULAR.Text = String.Empty;
                                        txtV_TEL_CELULAR.Text = String.Empty;
                                        try
                                        {
                                            txtV_CORREO_PERSONAL.Text = oUsuario.USUARIO_CORREOs.Where(p => !p.L_PRINCIPAL && p.L_ACTIVO && p.L_CONFIRMADO).First().V_CORREO;
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else throw ex;
                                }
                            }
                        }
                        break;

                    case SubSecciones.Cargo:
                        try
                        {
                            if (lBanderaActualizaAnterior)
                            {
                                try
                                {
                                    Int32 NID_RESTRICCION;
                                    Boolean L_RESPUESTA;
                                    foreach (GridViewRow row in grdPreguntas.Rows)
                                    {
                                        NID_RESTRICCION = Convert.ToInt32(((HiddenField)row.FindControl("NID_RESTRICCION")).Value);
                                        L_RESPUESTA = ((SioNo)row.FindControl("cbx")).Checked;
                                        oDeclaracion.DECLARACION_RESTRICCIONESs.Where(p => p.NID_RESTRICCION == NID_RESTRICCION).First().L_RESPUESTA = L_RESPUESTA;
                                        oDeclaracion.DECLARACION_RESTRICCIONESs.Where(p => p.NID_RESTRICCION == NID_RESTRICCION).First().update();
                                    }
                                    oDeclaracion.DECLARACION_CARGO.NID_PUESTO = cmbVID_NIVEL.SelectedValue();
                                    oDeclaracion.DECLARACION_CARGO.V_DENOMINACION = txtV_DENOMINACION_PUESTO.Text;
                                    oDeclaracion.DECLARACION_CARGO.V_FUNCION_PRINCIPAL = txt_DENOMINACION_CARGO.Text;
                                    oDeclaracion.DECLARACION_CARGO.VID_PRIMER_NIVEL = cmbVID_PRIMER_NIVEL.Text;
                                    oDeclaracion.DECLARACION_CARGO.VID_SEGUNDO_NIVEL = cmbVID_SEGUNDO_NIVEL.SelectedValue;

                                    DateTime Dia = txtF_POSESION.Text.Date();

                                    //oDeclaracion.DECLARACION_CARGO.F_POSESION = txtF_POSESION.Date(Pagina.esMX);
                                    oDeclaracion.DECLARACION_CARGO.F_POSESION = txtF_POSESION.Text.Date();
                                    //oDeclaracion.DECLARACION_CARGO.F_INICIO = txtF_POSESION.Date(Pagina.esMX); // SE ASUME QUE LA FECHA DE INGRESO ES IGUAL A LA DE POSESION txtF_INGRESO

                                    oDeclaracion.DECLARACION_CARGO.update();

                                    oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL = C_CODIGO_POSTAL.Text;
                                    oDeclaracion.DECLARACION_DOM_LABORAL.NID_PAIS = cmbNID_PAIS_LABORAL.SelectedValue();
                                    //oDeclaracion.DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA = cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue;
                                    //oDeclaracion.DECLARACION_DOM_LABORAL.CID_MUNICIPIO = cmbCID_MUNICIPIO_LABORAL.SelectedValue;
                                    oDeclaracion.DECLARACION_DOM_LABORAL.V_COLONIA = txtV_COLONIA_LABORAL.Text;
                                    oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO = String.Concat(txtV_DOMICILIO_LABORAL.Text, '|', txtNumExteriorDOMICILIO_LABORAL.Text.Trim(), '|', txtNumInteriorDOMICILIO_LABORAL.Text.Trim());
                                    oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL = _oUsuario.USUARIO_CORREOs.Where(p => p.L_CONFIRMADO == true).First().V_CORREO;
                                    oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL = String.Concat(txtV_TELEFONO_LABORAL1.Text.Trim(), '|', txtV_TELEFONO_LABORAL2.Text.Trim());
                                    oDeclaracion.DECLARACION_DOM_LABORAL.update();
                                    oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES = txtObservaciones.Text;
                                    oDeclaracion.DECLARACION_CARGO.update();
                                    try
                                    {
                                        oDeclaracion.DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO = Convert.ToInt32(rbtOtroOrdenGobierno.SelectedValue);
                                        oDeclaracion.DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO = Convert.ToInt32(rbtAmbitoPublico.SelectedValue);
                                        oDeclaracion.DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTE = txtCargoEntePublico.Text;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCION = txtCargoAreaAdscripcion.Text;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.V_CARGO = txtCargoEmpleo.Text;
                                        if (cbxCargoHonorarios.Checked == true)
                                        {
                                            oDeclaracion.DECLARACION_CARGO_OTRO.L_HONORARIOS = true;
                                        }
                                        else
                                        { oDeclaracion.DECLARACION_CARGO_OTRO.L_HONORARIOS = false; }
                                        oDeclaracion.DECLARACION_CARGO_OTRO.V_NIVEL_EMPLEO = txtCargoNivel.Text;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPAL = txtCargoFuncion.Text;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.F_POSESION = txtCargoFechaPosesion.Text.Date();
                                        oDeclaracion.DECLARACION_CARGO_OTRO.V_TEL_LABORAL = txtCARGOV_TELEFONO.Text + "|" + txtCARGOV_TELEFONO_EXT.Text;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.C_CODIGO_POSTAL = txtCARGO_CODIGO_POSTAL_O.Text;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.NID_PAIS = cmbCARGO_NID_PAIS_OTRO.SelectedValue();
                                        oDeclaracion.DECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVA = cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO.SelectedValue().ToString();
                                        oDeclaracion.DECLARACION_CARGO_OTRO.CID_MUNICIPIO = cmbCARGO_CID_MUNICIPIO_OTRO.SelectedValue;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.V_COLONIA = txtCargoColonia.Text;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.V_DOMICILIO = String.Concat(txtCargoV_DOMICILIO_O.Text, '|', txtCargoNumExteriorDOMICILIO_O.Text, '|', txtCargoNumInteriorDOMICILIO_O.Text, '|', txtCargoEstado.Text);

                                        oDeclaracion.DECLARACION_CARGO_OTRO.V_OBSERVACIONES = txtCargoObserva.Text;
                                        oDeclaracion.DECLARACION_CARGO_OTRO.update();
                                    }
                                    catch
                                    {
                                        if (cbxOtroEmpleo.Checked)
                                        {
                                            oDeclaracion.DECLARACION_CARGO_OTRO = new blld_DECLARACION_CARGO_OTRO(
                                                                                                                       oDeclaracion.VID_NOMBRE
                                                                                                                       , oDeclaracion.VID_FECHA
                                                                                                                       , oDeclaracion.VID_HOMOCLAVE
                                                                                                                       , oDeclaracion.NID_DECLARACION
                                                                                                                       , Convert.ToInt32(rbtOtroOrdenGobierno.SelectedValue)
                                                                                                                       , Convert.ToInt32(rbtAmbitoPublico.SelectedValue)
                                                                                                                       , txtCargoEntePublico.Text
                                                                                                                       , txtCargoAreaAdscripcion.Text
                                                                                                                       , txtCargoEmpleo.Text
                                                                                                                       , cbxCargoHonorarios.Checked
                                                                                                                       , txtCargoNivel.Text
                                                                                                                       , txtCargoFuncion.Text
                                                                                                                       , Convert.ToDateTime(txtCargoFechaPosesion.Text)
                                                                                                                       , txtCARGOV_TELEFONO.Text + "|" + txtCARGOV_TELEFONO_EXT.Text
                                                                                                                       , txtCARGO_CODIGO_POSTAL_O.Text
                                                                                                                       , Convert.ToInt32(cmbCARGO_NID_PAIS_OTRO.SelectedValue)
                                                                                                                       , cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO.SelectedValue
                                                                                                                       , cmbCARGO_CID_MUNICIPIO_OTRO.SelectedValue
                                                                                                                       , txtCargoColonia.Text
                                                                                                                       , String.Concat(txtCargoV_DOMICILIO_O.Text, '|', txtCargoNumExteriorDOMICILIO_O.Text, '|', txtCargoNumInteriorDOMICILIO_O.Text, '|', txtCargoEstado.Text)
                                                                                                                       , txtCargoObserva.Text
                                                                                                                   );
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                    {

                                        Int32 NID_RESTRICCION;
                                        Boolean L_RESPUESTA;
                                        oDeclaracion.DECLARACION_CARGO = new blld_DECLARACION_CARGO(oDeclaracion.VID_NOMBRE
                                                                                                   , oDeclaracion.VID_FECHA
                                                                                                   , oDeclaracion.VID_HOMOCLAVE
                                                                                                   , oDeclaracion.NID_DECLARACION
                                                                                                   , Convert.ToInt32(cmbVID_NIVEL.SelectedValue)
                                                                                                   , txtV_DENOMINACION_PUESTO.Text
                                                                                                   , txt_DENOMINACION_CARGO.Text
                                                                                                   //, txtF_POSESION.Date(Pagina.esMX)
                                                                                                   //, txtF_INGRESO.Date(Pagina.esMX).Date
                                                                                                   , Convert.ToDateTime(txtF_POSESION.Text)
                                                                                                   , Convert.ToDateTime(txtF_POSESION.Text)
                                                                                                   , cmbVID_PRIMER_NIVEL.SelectedValue
                                                                                                   , cmbVID_SEGUNDO_NIVEL.SelectedValue);
                                        foreach (GridViewRow row in grdPreguntas.Rows)
                                        {
                                            NID_RESTRICCION = Convert.ToInt32(((HiddenField)row.FindControl("NID_RESTRICCION")).Value);
                                            L_RESPUESTA = ((SioNo)row.FindControl("cbx")).Checked;
                                            oDeclaracion.DECLARACION_RESTRICCIONESs.Where(p => p.NID_RESTRICCION == NID_RESTRICCION).First().L_RESPUESTA = L_RESPUESTA;
                                            oDeclaracion.DECLARACION_RESTRICCIONESs.Where(p => p.NID_RESTRICCION == NID_RESTRICCION).First().update();
                                        }

                                        oDeclaracion.DECLARACION_DOM_LABORAL = new blld_DECLARACION_DOM_LABORAL(oDeclaracion.VID_NOMBRE
                                                                                                                 , oDeclaracion.VID_FECHA
                                                                                                                 , oDeclaracion.VID_HOMOCLAVE
                                                                                                                 , oDeclaracion.NID_DECLARACION
                                                                                                                 , C_CODIGO_POSTAL.Text
                                                                                                                 , cmbNID_PAIS_LABORAL.SelectedValue()
                                                                                                                 , "09"
                                                                                                                 , "003"
                                                                                                                 , txtV_COLONIA_LABORAL.Text
                                                                                                                 , String.Concat(txtV_DOMICILIO_LABORAL.Text, '|', txtNumExteriorDOMICILIO_LABORAL.Text, '|', txtNumInteriorDOMICILIO_LABORAL.Text)
                                                                                                                 , txtV_CORREO_LABORAL.Text
                                                                                                                 , String.Concat(txtV_TELEFONO_LABORAL1.Text, '|', txtV_TELEFONO_LABORAL2.Text));

                                        oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES = txtObservaciones.Text;
                                        oDeclaracion.DECLARACION_CARGO.update();

                                        if (cbxOtroEmpleo.Checked)
                                        {
                                            oDeclaracion.DECLARACION_CARGO_OTRO = new blld_DECLARACION_CARGO_OTRO(
                                                                                                                  oDeclaracion.VID_NOMBRE
                                                                                                                  , oDeclaracion.VID_FECHA
                                                                                                                  , oDeclaracion.VID_HOMOCLAVE
                                                                                                                  , oDeclaracion.NID_DECLARACION
                                                                                                                  , Convert.ToInt32(rbtOtroOrdenGobierno.SelectedValue)
                                                                                                                  , Convert.ToInt32(rbtAmbitoPublico.SelectedValue)
                                                                                                                  , txtCargoEntePublico.Text
                                                                                                                  , txtCargoAreaAdscripcion.Text
                                                                                                                  , txtCargoEmpleo.Text
                                                                                                                  , cbxCargoHonorarios.Checked
                                                                                                                  , txtCargoNivel.Text
                                                                                                                  , txtCargoFuncion.Text
                                                                                                                  , Convert.ToDateTime(txtCargoFechaPosesion.Text)
                                                                                                                  , txtCARGOV_TELEFONO.Text + "|" + txtCARGOV_TELEFONO_EXT.Text
                                                                                                                  , txtCARGO_CODIGO_POSTAL_O.Text
                                                                                                                  , Convert.ToInt32(cmbCARGO_NID_PAIS_OTRO.SelectedValue)
                                                                                                                  , cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO.SelectedValue
                                                                                                                  , cmbCARGO_CID_MUNICIPIO_OTRO.SelectedValue
                                                                                                                  , txtCargoColonia.Text
                                                                                                                  , String.Concat(txtCargoV_DOMICILIO_O.Text, '|', txtCargoNumExteriorDOMICILIO_O.Text, '|', txtCargoNumInteriorDOMICILIO_O.Text, '|', txtCargoEstado.Text)
                                                                                                                  , txtCargoObserva.Text
                                                                                                              );
                                        }
                                    }
                                    else if (ex is CustomException || ex is ConvertionException)
                                    {
                                        MsgBox.ShowDanger(ex.Message);
                                        lBanderaPasa = false;
                                    }
                                    else throw ex;
                                }
                                //lBanderaActualizaAnterior = true;
                                //marcaApartado(ref oDeclaracion, 4);
                            }
                            if (lBanderaPasa)
                            {
                                lBanderaActualizaAnterior = true;
                                marcaApartado(ref oDeclaracion, 4);
                                Response.Redirect("ExperienciaLaboral.aspx", false);

                                //    blld_DECLARACION_CARGO oTempCargo = new blld_DECLARACION_CARGO(oDeclaracion.VID_NOMBRE
                                //                                                                                      , oDeclaracion.VID_FECHA
                                //                                                                                      , oDeclaracion.VID_HOMOCLAVE
                                //                                                                                      , oDeclaracion.NID_DECLARACION);

                                //    ltrSubTitulo.Text = "4. Datos del empleo, cargo o comisión que concluye - Domicilio Laboral";
                                //    pnlDatosPersonales.Visible = false;
                                //    pnlDomicilioParticular.Visible = false;
                                //    pnlCargo.Visible = false;
                                //    pnlDomicilioLaboral.Visible = true;
                                //    pnlDependientes.Visible = false;
                                //    SubSeccionActiva = SubSecciones.DomicilioLaboral;
                                //    try
                                //    {
                                //        C_CODIGO_POSTAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL;
                                //        cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue = oDeclaracion.DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA;
                                //        cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged(cmbCID_ENTIDAD_FEDERATIVA_LABORAL, null);
                                //        cmbCID_MUNICIPIO_LABORAL.SelectedValue = oDeclaracion.DECLARACION_DOM_LABORAL.CID_MUNICIPIO;
                                //        txtV_COLONIA_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_COLONIA;

                                //        try { txtV_DOMICILIO_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO.Split('|')[0]; } catch { }
                                //        try { txtNumExteriorDOMICILIO_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO.Split('|')[1]; } catch { }
                                //        try { txtNumInteriorDOMICILIO_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO.Split('|')[2]; } catch { }

                                //        txtV_CORREO_LABORAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL;

                                //        try { txtV_TELEFONO_LABORAL1.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[0]; } catch { }
                                //        try { txtV_TELEFONO_LABORAL2.Text = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[1]; } catch { }


                                //        txtObservaciones.Text = oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES;

                                //    }
                                //    catch (Exception ex)
                                //    {
                                //        if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                //        {
                                //            C_CODIGO_POSTAL.Text = String.Empty;
                                //            cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedIndex = 0;
                                //            cmbCID_MUNICIPIO_LABORAL.SelectedIndex = 0;
                                //            txtV_COLONIA_LABORAL.Text = String.Empty;
                                //            txtV_DOMICILIO_LABORAL.Text = String.Empty;

                                //            txtV_TELEFONO_LABORAL1.Text = String.Empty;
                                //            txtV_TELEFONO_LABORAL2.Text = String.Empty;
                                //            try
                                //            {
                                //                txtV_CORREO_LABORAL.Text = oUsuario.USUARIO_CORREOs.Where(p => p.L_PRINCIPAL && p.L_ACTIVO && p.L_CONFIRMADO).First().V_CORREO;
                                //            }
                                //            catch
                                //            {
                                //                txtV_CORREO_LABORAL.Text = String.Empty;
                                //            }
                                //        }
                                //        else throw ex;
                                //    }
                            }

                            // aqui es el punto
                        }
                        catch (Exception ex)
                        {

                            if (ex is CustomException || ex is ConvertionException)
                                MsgBox.ShowDanger(ex.Message);
                            else
                                throw ex;
                            //MsgBox.ShowWarning("Debe finalizar este apartado para continuar con el siguiente apartado 'Domicilio Laboral'");
                            //SubSeccionActiva = SubSecciones.DomicilioParticular;
                            //lBanderaActualizaAnterior = false;
                            //lBanderaPasa = true;
                            //Siguiente();
                        }
                        break;
                    case SubSecciones.DomicilioLaboral:
                        if (lBanderaActualizaAnterior)
                        {
                            try
                            {
                                ////////////////ltrSubTitulo.Text = "Datos del dependiente económico";
                                ////////////////pnlDatosPersonales.Visible = false;
                                ////////////////pnlDomicilioParticular.Visible = false;
                                ////////////////pnlCargo.Visible = false;
                                ////////////////pnlDomicilioLaboral.Visible = false;
                                ////////////////// Aqui se tiene que modificar *****

                                ////////////////pnlPareja.Visible = false;
                                ////////////////pnlDependientes.Visible = true;
                                //////////////// SubSeccionActiva = SubSecciones.DependienteEconomicos;
                                ////////////////if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                                ////////////////    QstBoxDep.Ask("¿Cuenta con dependientes económicos que desee registrar?");
                                //oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL = C_CODIGO_POSTAL.Text;
                                //oDeclaracion.DECLARACION_DOM_LABORAL.NID_PAIS = cmbNID_PAIS_LABORAL.SelectedValue();
                                //oDeclaracion.DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA = cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue;
                                //oDeclaracion.DECLARACION_DOM_LABORAL.CID_MUNICIPIO = cmbCID_MUNICIPIO_LABORAL.SelectedValue;
                                //oDeclaracion.DECLARACION_DOM_LABORAL.V_COLONIA = txtV_COLONIA_LABORAL.Text;
                                //oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO = String.Concat(txtV_DOMICILIO_LABORAL.Text, '|', txtNumExteriorDOMICILIO_LABORAL.Text, '|', txtNumInteriorDOMICILIO_LABORAL.Text);
                                //oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL = txtV_CORREO_LABORAL.Text;
                                //oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL = txtV_TELEFONO_LABORAL1.Text;
                                //oDeclaracion.DECLARACION_DOM_LABORAL.update();
                                //oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES = txtObservaciones.Text;
                                //oDeclaracion.DECLARACION_CARGO.update();
                            }
                            catch (Exception ex)
                            {
                                //MsgBox.ShowWarning("Debe finalizar el apartado 'Cargo' para continuar con el guardado de Domicilio Laboral");

                                //    if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                //    {
                                //        oDeclaracion.DECLARACION_DOM_LABORAL = new blld_DECLARACION_DOM_LABORAL(oDeclaracion.VID_NOMBRE
                                //                                                                                      , oDeclaracion.VID_FECHA
                                //                                                                                      , oDeclaracion.VID_HOMOCLAVE
                                //                                                                                      , oDeclaracion.NID_DECLARACION
                                //                                                                                      , C_CODIGO_POSTAL.Text
                                //                                                                                      , cmbNID_PAIS_LABORAL.SelectedValue()
                                //                                                                                      , cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue
                                //                                                                                      , cmbCID_MUNICIPIO_LABORAL.SelectedValue
                                //                                                                                      , txtV_COLONIA_LABORAL.Text
                                //                                                                                      , String.Concat(txtV_DOMICILIO_LABORAL.Text, '|', txtNumExteriorDOMICILIO_LABORAL.Text, '|', txtNumInteriorDOMICILIO_LABORAL.Text)
                                //                                                                                      , txtV_CORREO_LABORAL.Text
                                //                                                                                      , String.Concat(txtV_TELEFONO_LABORAL1.Text, '|', txtV_TELEFONO_LABORAL2.Text));
                                //        oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES = txtObservaciones.Text;
                                //        oDeclaracion.DECLARACION_CARGO.update();
                                //    }
                                //    else
                                //    {
                                //        MsgBox.ShowDanger(ex.Message);
                                //        lBanderaPasa = false;
                                //    }
                            }
                            lBanderaActualizaAnterior = true;
                            lBanderaPasa = false;
                            marcaApartado(ref oDeclaracion, 5);
                        }
                        if (lBanderaPasa)
                        {
                            ltrSubTitulo.Text = "Apartado 6. Dar de alta datos de la pareja";
                            pnlDatosPersonales.Visible = false;
                            pnlDomicilioParticular.Visible = false;
                            pnlCargo.Visible = false;
                            pnlDomicilioLaboral.Visible = false;
                            // Aqui se tiene que modificar *****
                            pnlDependientes.Visible = true;
                            SubSeccionActiva = SubSecciones.DependienteEconomicos;
                            ////OEVM abril 2023
                            //if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value) ;
                            //QstBoxDep.Ask("¿Cuenta con dependientes económicos y/o cónyuge que deba registrar?");
                        }
                        break;
                    case SubSecciones.DependienteEconomicos:
                        if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                        {
                            marcaApartado(ref oDeclaracion, 5);
                            marcaApartado(ref oDeclaracion, 6);
                        }
                        else
                        {
                            marcaApartado(ref oDeclaracion, 5);
                            marcaApartado(ref oDeclaracion, 6);

                        }
                        if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
                        {
                            MsgBox.ShowWarning("Debe finalizar el apartado 'Datos Generales' para continuar con la declaración");
                        }
                        else
                        {
                            Response.Redirect("Ingresos.aspx");
                        }
                        break;
                }
                if (SubSeccionActiva == SubSecciones.DependienteEconomicos)
                {
                    ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                    ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                    ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
                }
                else
                {
                    ((Button)Master.FindControl("btnSiguiente")).Text = "Guardar";
                    ((Button)Master.FindControl("btnSiguiente")).CssClass = "saveNext";
                    ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Guardar e ir al siguiente apartado";
                }
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    MsgBox.ShowDanger(ex.Message);
                else
                    throw ex;
            }
            _oDeclaracion = oDeclaracion;
            lBanderaActualizaAnterior = true;
            active();
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

            if (NID_APARTADO == 6)
            {
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 2, 3, 4, 5, 6 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
                {
                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
                    {
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO = true;
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().update();
                    }
                }
            }
        }

        void active()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            ((_Modificacion)Master).links_DatosGenerales(ref oDeclaracion);
            switch (SubSeccionActiva)
            {
                case SubSecciones.DatosPersonales:
                    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                        ((LinkButton)Master.FindControl("lkDatosPersonales")).CssClass = "completeve";
                    else
                        ((LinkButton)Master.FindControl("lkDatosPersonales")).CssClass = "active";
                    break;
                case SubSecciones.DomicilioParticular:
                    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                        ((LinkButton)Master.FindControl("lkDomicilioParticular")).CssClass = "completeve";
                    else
                        ((LinkButton)Master.FindControl("lkDomicilioParticular")).CssClass = "active";
                    break;
                case SubSecciones.Cargo:
                    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                        ((LinkButton)Master.FindControl("lkCargo")).CssClass = "completeve";
                    else
                        ((LinkButton)Master.FindControl("lkCargo")).CssClass = "active";
                    break;
                case SubSecciones.DomicilioLaboral:
                    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                        ((LinkButton)Master.FindControl("lkDomicilioLaboral")).CssClass = "completeve";
                    else
                        ((LinkButton)Master.FindControl("lkDomicilioLaboral")).CssClass = "active";
                    break;
                case SubSecciones.DependienteEconomicos:
                    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                        ((LinkButton)Master.FindControl("lkDependientesEconomicos")).CssClass = "completeve";
                    else
                        ((LinkButton)Master.FindControl("lkDependientesEconomicos")).CssClass = "active";
                    break;
            }

        }

        #endregion

        protected void aDatosPersonales_Click(object sender, EventArgs e)
        {

            pnlDatosPersonales.Visible = true;

        }

        protected void aDomicilioParticular_Click(object sender, EventArgs e)
        {
            pnlDomicilioParticular.Visible = true;
        }

        protected void aCargo_Click(object sender, EventArgs e)
        {
            pnlCargo.Visible = true;
        }

        protected void aDomicilioLaboral_Click(object sender, EventArgs e)
        {
            pnlDomicilioLaboral.Visible = true;
        }

        protected void aDependientes_Click(object sender, EventArgs e)
        {
            pnlDependientes.Visible = true;
        }

        protected void cmbcGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcGenero.SelectedValue == "F")
            {
                cmbNacionalidad.DataBinder<blld__l_CAT_PAIS>(new blld__l_CAT_PAIS(), CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_NACIONALIDAD_F, false);
                cmbnIdPaisNacimiento.SelectedValue = "1";
            }
            else
            {
                cmbNacionalidad.DataBinder<blld__l_CAT_PAIS>(new blld__l_CAT_PAIS(), CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_NACIONALIDAD_M, false);
                cmbnIdPaisNacimiento.SelectedValue = "1";
            }
        }

        //protected void cmbPaisDomimicioParticular_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
        //    oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisDomimicioParticular.SelectedValue());
        //    oEntidadFederativa.select();
        //    cmbEntidadFederativaDomicilioParticular.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
        //    cmbEntidadFederativaDomicilioParticular_SelectedIndexChanged(sender, e);
        //}

        //protected void cmbEntidadFederativaDomicilioParticular_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
        //    omun.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisDomimicioParticular.SelectedValue());
        //    omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbEntidadFederativaDomicilioParticular.SelectedValue);
        //    omun.select();
        //    cmbMunicipioDomicilioParticular.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
        //}

        protected void txtcCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            if (txtcCodigoPostal.Text.Length == 5)
            {
                try
                {
                    blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(txtcCodigoPostal.Text);
                    cmbPaisDomParticular.SelectedValue = oCodigo.NID_PAIS.ToString();
                    cmbPaisDomParticular_SelectedIndexChanged(sender, e);
                    cmbEntidadFederativaDomParticular.SelectedValue = oCodigo.CID_ENTIDAD_FEDERATIVA;
                    cmbEntidadFederativaDomParticular_SelectedIndexChanged(sender, e);
                    cmbMunicipioDomParticular.SelectedValue = oCodigo.CID_MUNICIPIO;
                    txtColoniaParticular.Text = oCodigo.V_COLONIA;

                }
                catch
                {
                }
            }
        }

        protected void C_CODIGO_POSTAL_TextChanged(object sender, EventArgs e)
        {
            if (C_CODIGO_POSTAL.Text.Length == 5)
            {
                try
                {
                    blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(C_CODIGO_POSTAL.Text);
                    cmbNID_PAIS_LABORAL.SelectedValue = oCodigo.NID_PAIS.ToString();
                    //cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue = oCodigo.CID_ENTIDAD_FEDERATIVA;
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged(sender, e);
                    //cmbCID_MUNICIPIO_LABORAL.SelectedValue = oCodigo.CID_MUNICIPIO;
                    txtV_COLONIA_LABORAL.Text = oCodigo.V_COLONIA;

                }
                catch
                {
                }
            }
        }

        protected void cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
            omun.NID_PAIS = new Declara_V2.IntegerFilter(1);
            // omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue);
            omun.select();
            //cmbCID_MUNICIPIO_LABORAL.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
        }

        protected void txtVID_CLAVEPUESTO_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtVID_PRIMER_NIVEL_TextChanged(object sender, EventArgs e)
        {
            blld__l_CAT_SEGUNDO_NIVEL oSegundo = new blld__l_CAT_SEGUNDO_NIVEL();
            oSegundo.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(cmbVID_PRIMER_NIVEL.SelectedValue);
            oSegundo.select();
            cmbVID_SEGUNDO_NIVEL.DataBind(oSegundo.lista_CAT_SEGUNDO_NIVEL, CAT_SEGUNDO_NIVEL.Properties.VID_SEGUNDO_NIVEL, CAT_SEGUNDO_NIVEL.Properties.V_SEGUNDO_NIVEL);

            //OEVM 20230613 - Mejoras para que el catalogo de puestos se arme a partir de la unidad administrativa seleccionada
            string primerNivel =  oSegundo.VID_PRIMER_NIVEL.Value;
            if (primerNivel != "")
            {
                blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                //Ver como agregar al listado los honorarios
                string valorSeleccionado = cmbVID_PRIMER_NIVEL.SelectedValue.Substring(0, 3);

                if (valorSeleccionado != "210")
                {
                    oPuesto.select();
                    cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO
                        .Where(p => p.VID_PUESTO.StartsWith(valorSeleccionado) || p.VID_PUESTO.Contains("CH-"))
                        .OrderBy(x => x.VID_PUESTO)
                        .ThenBy(x => x.VID_NIVEL)
                        .ThenBy(x => x.V_PUESTO);
                }
                else
                {
                    oPuesto.select();
                    cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO
                        .Where(p => p.VID_PUESTO.StartsWith(valorSeleccionado) || p.VID_PUESTO.StartsWith("211") || p.VID_PUESTO.StartsWith("212") || p.VID_PUESTO.StartsWith("214") || p.VID_PUESTO.Contains("CH-"))
                        .OrderBy(x => x.VID_PUESTO)
                        .ThenBy(x => x.VID_NIVEL)
                        .ThenBy(x => x.V_PUESTO);
                }

                cmbVID_CLAVEPUESTO.DataTextField = CAT_PUESTO.Properties.CLAVE_NOMBRE_PUESTO.ToString();
                cmbVID_CLAVEPUESTO.DataValueField = CAT_PUESTO.Properties.NID_PUESTO.ToString(); //Trae la descripcion completa para el combo
                cmbVID_CLAVEPUESTO.DataBind();
            }
            
        }

        protected void cmbVID_CLAVEPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();

            int indice = cmbVID_CLAVEPUESTO.SelectedItem.Text.IndexOf("|");

            if (indice > 0)
            {
                oPuesto.VID_PUESTO = new Declara_V2.StringFilter(cmbVID_CLAVEPUESTO.SelectedItem.Text.Substring(0, indice));

            }
            else
            {
                oPuesto.VID_PUESTO = new Declara_V2.StringFilter(cmbVID_CLAVEPUESTO.SelectedItem.Text);
            }

            oPuesto.L_ACTIVO = true;
            oPuesto.select();

            cmbVID_NIVEL.DataBind(oPuesto.lista_CAT_PUESTO.OrderBy(x => x.V_PUESTO)

                            , CAT_PUESTO.Properties.NID_PUESTO, CAT_PUESTO.Properties.V_PUESTO_NIVEL);


            txtV_DENOMINACION_PUESTO.Text = String.Empty;

            txtV_DENOMINACION_PUESTO.Text = cmbVID_CLAVEPUESTO.SelectedItem.Text;

            cmbVID_NIVEL.Items.Insert(0, new ListItem(String.Empty));
            cmbVID_NIVEL.SelectedValue = String.Empty;

        }

        protected void cmbVID_NIVEL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int indice = cmbVID_CLAVEPUESTO.SelectedItem.Text.IndexOf("|");

                if (indice > 0)
                {
                    blld_CAT_PUESTO oPuesto = new blld_CAT_PUESTO(cmbVID_CLAVEPUESTO.SelectedItem.Text.Substring(0, indice), cmbVID_NIVEL.SelectedValue());
                    txtV_DENOMINACION_PUESTO.Text = oPuesto.V_PUESTO;
                }
                else
                {

                    blld_CAT_PUESTO oPuesto = new blld_CAT_PUESTO(cmbVID_CLAVEPUESTO.SelectedItem.Text, cmbVID_NIVEL.SelectedValue());
                    txtV_DENOMINACION_PUESTO.Text = oPuesto.V_PUESTO;
                }


            }
            catch (Exception ex)
            {
                txtV_DENOMINACION_PUESTO.Text = String.Empty;
            }
        }

        protected void btnAgregarDependientePareja_Click(object sender, EventArgs e)
        {
            mdlDependiente.Show(true);
            mdlDependiente.HeaderText = "Dar de alta datos de la pareja";
            ctrlDependiente1.limpia();
            ctrlDependiente1.SelectPareja();
        }

        protected void btnAgregarDependiente_Click(object sender, EventArgs e)
        {
            mdlDependiente.Show(true);
            mdlDependiente.HeaderText = "Dar de alta datos del dependiente económico";
            ctrlDependiente1.limpia();
            ctrlDependiente1.SelectDependiente();
        }

        protected void btnGuardaDependiente_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            try
            {
                if (ctrlDependiente1.Accion == ctrlDependiente.Acciones.Actualiza)
                {
                    int nDependiente = ctrlDependiente1.Selected_id;

                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().NID_TIPO_DEPENDIENTE = Convert.ToInt32(ctrlDependiente1.NID_TIPO_DEPENDIENTE);
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().E_NOMBRE = ctrlDependiente1.E_NOMBRE;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().E_PRIMER_A = ctrlDependiente1.E_PRIMER_A;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().E_SEGUNDO_A = ctrlDependiente1.E_SEGUNDO_A;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().F_NACIMIENTO = ctrlDependiente1.F_NACIMIENTO;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().E_RFC = ctrlDependiente1.E_RFC;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().L_DEPENDE_ECO = ctrlDependiente1.L_DEPENDE_ECO;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().L_PAREJA = ctrlDependiente1.L_PAREJA;
                    //,  ctrlDependiente1.L_ACTIVO
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().L_CIUDADANO_EXTRANJERO = ctrlDependiente1.L_CIUDADANO_EXTRANJERO;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().E_CURP = ctrlDependiente1.E_CURP;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().NID_ACTIVIDAD_LABORAL = ctrlDependiente1.NID_ACTIVIDAD_LABORAL;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().E_OBSERVACIONES = ctrlDependiente1.E_OBSERVACIONES;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().E_OBSERVACIONES_MARCADO = ctrlDependiente1.E_OBSERVACIONES_MARCADO;
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().V_OBSERVACIONES_TESTADO = ctrlDependiente1.V_OBSERVACIONES_TESTADO;
                    //,  ctrlDependiente1.NID_ESTADO_TESTADO
                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().L_MISMO_DOMICILIO_DECLARANTE = ctrlDependiente1.L_MISMO_DOMICILIO_DECLARANTE;

                    if (!ctrlDependiente1.L_MISMO_DOMICILIO_DECLARANTE)
                    {

                        MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                        var iDomicilio = (from p in db.DECLARACION_DEPENDIENTES_DOMICILIO
                                          where
                                                 p.VID_NOMBRE == oDeclaracion.VID_NOMBRE &&
                                                 p.VID_FECHA == oDeclaracion.VID_FECHA &&
                                                 p.VID_HOMOCLAVE == oDeclaracion.VID_HOMOCLAVE &&
                                                 p.NID_DECLARACION == oDeclaracion.NID_DECLARACION &&
                                                 p.NID_DEPENDIENTE == nDependiente
                                          select p).ToList();

                        if (iDomicilio.Count() > 0)
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DomicilioUpdate(ctrlDependiente1.C_CODIGO_POSTAL, ctrlDependiente1.NID_PAIS, ctrlDependiente1.CID_ENTIDAD_FEDERATIVA, ctrlDependiente1.CID_MUNICIPIO, ctrlDependiente1.V_COLONIA, ctrlDependiente1.V_DOMICILIO);
                        else
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DomicilioNuevo(ctrlDependiente1.C_CODIGO_POSTAL, ctrlDependiente1.NID_PAIS, ctrlDependiente1.CID_ENTIDAD_FEDERATIVA, ctrlDependiente1.CID_MUNICIPIO, ctrlDependiente1.V_COLONIA, ctrlDependiente1.V_DOMICILIO);

                    }
                    else
                        oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DomicilioBorra(ctrlDependiente1.C_CODIGO_POSTAL, ctrlDependiente1.NID_PAIS, ctrlDependiente1.CID_ENTIDAD_FEDERATIVA, ctrlDependiente1.CID_MUNICIPIO, ctrlDependiente1.V_COLONIA, ctrlDependiente1.V_DOMICILIO);


                    //PRIVADO
                    if (ctrlDependiente1.NID_ACTIVIDAD_LABORAL == 1)
                    {
                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, nDependiente);

                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = ctrlDependiente1.V_NOMBRE;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = ctrlDependiente1.V_CARGO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = ctrlDependiente1.V_RFC;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = ctrlDependiente1.M_SALARIO_MENSUAL.Value;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR = ctrlDependiente1.NID_SECTOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO = ctrlDependiente1.F_INGRESO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = ctrlDependiente1.L_PROVEEDOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.update();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, nDependiente,
                                ctrlDependiente1.V_NOMBRE,
                                ctrlDependiente1.V_CARGO,
                                ctrlDependiente1.V_RFC,
                                ctrlDependiente1.F_INGRESO,
                                ctrlDependiente1.NID_SECTOR,
                                 ctrlDependiente1.M_SALARIO_MENSUAL.Value,
                                ctrlDependiente1.L_PROVEEDOR
                                );

                                blld__l_DECLARACION_DEPENDIENTES_PUBLICO lDP = new blld__l_DECLARACION_DEPENDIENTES_PUBLICO();
                                lDP.select();
                                if (lDP.lista_DECLARACION_DEPENDIENTES_PUBLICO.Where(p => p.NID_DEPENDIENTE == nDependiente
                                && p.VID_NOMBRE == oDeclaracion.VID_NOMBRE
                                && p.VID_FECHA == oDeclaracion.VID_FECHA
                                && p.VID_HOMOCLAVE == oDeclaracion.VID_HOMOCLAVE
                                ).Count() > 0)
                                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.delete();
                            }
                            catch (Exception)
                            {


                            }

                        }
                    }


                    //Publico
                    if (ctrlDependiente1.NID_ACTIVIDAD_LABORAL == 2)
                    {

                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PUBLICO oDep = new blld_DECLARACION_DEPENDIENTES_PUBLICO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, nDependiente);

                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR = ctrlDependiente1.NID_AMBITO_SECTOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO = ctrlDependiente1.NID_NIVEL_GOBIERNO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO = ctrlDependiente1.NID_AMBITO_PUBLICO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE = ctrlDependiente1.V_NOMBRE_ENTE;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION = ctrlDependiente1.V_AREA_ADSCRIPCION;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO = ctrlDependiente1.V_CARGO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL = ctrlDependiente1.V_FUNCION_PRINCIPAL;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL = ctrlDependiente1.M_SALARIO_MENSUAL.Value;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO = ctrlDependiente1.F_INGRESO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.update();

                        }
                        catch (Exception)
                        {
                            try
                            {
                                blld_DECLARACION_DEPENDIENTES_PUBLICO oDep = new blld_DECLARACION_DEPENDIENTES_PUBLICO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, nDependiente,
                                    ctrlDependiente1.NID_AMBITO_SECTOR,
                                    ctrlDependiente1.NID_NIVEL_GOBIERNO,
                                    ctrlDependiente1.NID_AMBITO_PUBLICO,
                                    ctrlDependiente1.V_NOMBRE_ENTE,
                                    ctrlDependiente1.V_AREA_ADSCRIPCION,
                                    ctrlDependiente1.V_CARGO,
                                    ctrlDependiente1.V_FUNCION_PRINCIPAL,
                                    ctrlDependiente1.M_SALARIO_MENSUAL.Value,
                                    ctrlDependiente1.F_INGRESO
                                    );

                                blld__l_DECLARACION_DEPENDIENTES_PRIVADO lDP = new blld__l_DECLARACION_DEPENDIENTES_PRIVADO();
                                lDP.select();
                                if (lDP.lista_DECLARACION_DEPENDIENTES_PRIVADO.Where(p => p.NID_DEPENDIENTE == nDependiente
                                && p.VID_NOMBRE == oDeclaracion.VID_NOMBRE
                                && p.VID_FECHA == oDeclaracion.VID_FECHA
                                && p.VID_HOMOCLAVE == oDeclaracion.VID_HOMOCLAVE
                                ).Count() > 0)
                                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.delete();

                            }
                            catch (Exception)
                            {

                            }
                        }
                    }

                    //PRIVADO
                    if (ctrlDependiente1.NID_ACTIVIDAD_LABORAL == 3)
                    {
                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, nDependiente);

                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = ctrlDependiente1.V_NOMBRE;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = ctrlDependiente1.V_CARGO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = ctrlDependiente1.V_RFC;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = ctrlDependiente1.M_SALARIO_MENSUAL.Value;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR = ctrlDependiente1.NID_SECTOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = ctrlDependiente1.L_PROVEEDOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.update();

                        }
                        catch (Exception ex)
                        {

                            try
                            {
                                blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, nDependiente,
                                ctrlDependiente1.V_NOMBRE,
                                ctrlDependiente1.V_CARGO,
                                ctrlDependiente1.V_RFC,
                                ctrlDependiente1.F_INGRESO,
                                ctrlDependiente1.NID_SECTOR,
                                ctrlDependiente1.M_SALARIO_MENSUAL.Value,
                                ctrlDependiente1.L_PROVEEDOR
                                );

                                blld__l_DECLARACION_DEPENDIENTES_PUBLICO lDP = new blld__l_DECLARACION_DEPENDIENTES_PUBLICO();
                                lDP.select();
                                if (lDP.lista_DECLARACION_DEPENDIENTES_PUBLICO.Where(p => p.NID_DEPENDIENTE == nDependiente
                                && p.VID_NOMBRE == oDeclaracion.VID_NOMBRE
                                && p.VID_FECHA == oDeclaracion.VID_FECHA
                                && p.VID_HOMOCLAVE == oDeclaracion.VID_HOMOCLAVE
                                ).Count() > 0)
                                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.delete();

                            }
                            catch { }
                        }
                    }

                    //Ninguna
                    if (ctrlDependiente1.NID_ACTIVIDAD_LABORAL == 4)
                    {
                        blld__l_DECLARACION_DEPENDIENTES_PUBLICO lDP = new blld__l_DECLARACION_DEPENDIENTES_PUBLICO();
                        lDP.select();
                        if (lDP.lista_DECLARACION_DEPENDIENTES_PUBLICO.Where(p => p.NID_DEPENDIENTE == nDependiente
                        && p.VID_NOMBRE == oDeclaracion.VID_NOMBRE
                        && p.VID_FECHA == oDeclaracion.VID_FECHA
                        && p.VID_HOMOCLAVE == oDeclaracion.VID_HOMOCLAVE
                        ).Count() > 0)
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PUBLICO.delete();


                        blld__l_DECLARACION_DEPENDIENTES_PRIVADO lDPi = new blld__l_DECLARACION_DEPENDIENTES_PRIVADO();
                        lDPi.select();
                        if (lDPi.lista_DECLARACION_DEPENDIENTES_PRIVADO.Where(p => p.NID_DEPENDIENTE == nDependiente
                        && p.VID_NOMBRE == oDeclaracion.VID_NOMBRE
                        && p.VID_FECHA == oDeclaracion.VID_FECHA
                        && p.VID_HOMOCLAVE == oDeclaracion.VID_HOMOCLAVE
                        ).Count() > 0)
                            oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().DECLARACION_DEPENDIENTES_PRIVADO.delete();

                    }




                    oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().update();

                    if (ctrlDependiente1.L_PAREJA)
                    {
                        UserControl item = (UserControl)Page.LoadControl("item.ascx");
                        ((Item)grd.FindControl(String.Concat("grd", nDependiente))).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", ctrlDependiente1.NID_TIPO_DEPENDIENTE, ".png");
                        ((Item)grd.FindControl(String.Concat("grd", nDependiente))).TextoPrincipal = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().V_TIPO_DEPENDIENTE;
                        ((Item)grd.FindControl(String.Concat("grd", nDependiente))).TextoSecundario = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().V_NOMBRE_COMPLETO;
                    }
                    else
                    {
                        UserControl item = (UserControl)Page.LoadControl("item.ascx");
                        ((Item)grdx7.FindControl(String.Concat("grdx7", nDependiente))).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", ctrlDependiente1.NID_TIPO_DEPENDIENTE, ".png");
                        ((Item)grdx7.FindControl(String.Concat("grdx7", nDependiente))).TextoPrincipal = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().V_TIPO_DEPENDIENTE;
                        ((Item)grdx7.FindControl(String.Concat("grdx7", nDependiente))).TextoSecundario = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == nDependiente).First().V_NOMBRE_COMPLETO;
                    }
                    //AlertaInferior.ShowSuccess("Se actualizaron correctamente los datos del dependiente");
                    AlertaSuperior.ShowSuccess("Se actualizaron correctamente los datos del dependiente");
                }
                else if (ctrlDependiente1.Accion == ctrlDependiente.Acciones.Inserta)
                {
                    oDeclaracion.Add_DECLARACION_DEPENDIENTESs(Convert.ToInt32(ctrlDependiente1.NID_TIPO_DEPENDIENTE)
                                                               , ctrlDependiente1.E_NOMBRE
                                                               , ctrlDependiente1.E_PRIMER_A
                                                               , ctrlDependiente1.E_SEGUNDO_A
                                                               , ctrlDependiente1.F_NACIMIENTO
                                                               , ctrlDependiente1.E_RFC
                                                               , ctrlDependiente1.L_DEPENDE_ECO

                                                               //,  ctrlDependiente1.L_ACTIVO
                                                               , ctrlDependiente1.L_CIUDADANO_EXTRANJERO
                                                               , ctrlDependiente1.E_CURP
                                                               , ctrlDependiente1.NID_ACTIVIDAD_LABORAL
                                                               , ctrlDependiente1.E_OBSERVACIONES
                                                               , ctrlDependiente1.E_OBSERVACIONES_MARCADO
                                                               , ctrlDependiente1.V_OBSERVACIONES_TESTADO
                                                               //,  ctrlDependiente1.NID_ESTADO_TESTADO
                                                               , ctrlDependiente1.L_MISMO_DOMICILIO_DECLARANTE

                                                               //Domicilio
                                                               , ctrlDependiente1.C_CODIGO_POSTAL
                                                               , ctrlDependiente1.NID_PAIS
                                                               , ctrlDependiente1.CID_ENTIDAD_FEDERATIVA
                                                               , ctrlDependiente1.CID_MUNICIPIO
                                                               , ctrlDependiente1.V_COLONIA
                                                               , ctrlDependiente1.V_DOMICILIO

                                                               //Publico
                                                               , ctrlDependiente1.NID_AMBITO_SECTOR
                                                               , ctrlDependiente1.NID_NIVEL_GOBIERNO
                                                               , ctrlDependiente1.NID_AMBITO_PUBLICO
                                                               , ctrlDependiente1.V_NOMBRE_ENTE
                                                               , ctrlDependiente1.V_AREA_ADSCRIPCION
                                                               , ctrlDependiente1.V_CARGO
                                                               , ctrlDependiente1.V_FUNCION_PRINCIPAL
                                                               , ctrlDependiente1.M_SALARIO_MENSUAL.Value
                                                               , ctrlDependiente1.F_INGRESO

                                                               //Privado 
                                                               , ctrlDependiente1.V_NOMBRE
                                                               , ctrlDependiente1.V_RFC
                                                               , ctrlDependiente1.NID_SECTOR
                                                               , ctrlDependiente1.L_PROVEEDOR
                                                               , ctrlDependiente1.L_PAREJA
                                                               );






                    if (ctrlDependiente1.L_PAREJA == true)
                    {
                        var X = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.L_PAREJA == true).ToList();
                        blld_DECLARACION_DEPENDIENTES o = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.L_PAREJA == true).ToList().Last();
                        UserControl item = (UserControl)Page.LoadControl("item.ascx");
                        ((Item)item).Id = o.NID_DEPENDIENTE;
                        ((Item)item).State = true;
                        ((Item)item).ID = String.Concat("grd", o.NID_DEPENDIENTE);
                        ((Item)item).TextoPrincipal = o.V_TIPO_DEPENDIENTE;
                        ((Item)item).TextoSecundario = o.V_NOMBRE_COMPLETO;
                        ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", o.NID_TIPO_DEPENDIENTE, ".png");
                        ((Item)item).Editar += OnEditar;
                        ((Item)item).Eliminar += OnEliminar;
                        grd.Controls.AddAt(grd.Controls.Count - 3, item);
                    }
                    else
                    {
                        blld_DECLARACION_DEPENDIENTES o = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.L_PAREJA == false).ToList().Last();
                        UserControl item = (UserControl)Page.LoadControl("item.ascx");
                        ((Item)item).Id = o.NID_DEPENDIENTE;
                        ((Item)item).State = false;
                        ((Item)item).ID = String.Concat("grdx7", o.NID_DEPENDIENTE);
                        ((Item)item).TextoPrincipal = o.V_TIPO_DEPENDIENTE;
                        ((Item)item).TextoSecundario = o.V_NOMBRE_COMPLETO;
                        ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", o.NID_TIPO_DEPENDIENTE, ".png");
                        ((Item)item).Editar += OnEditar;
                        ((Item)item).Eliminar += OnEliminar;
                        grdx7.Controls.AddAt(grdx7.Controls.Count - 3, item);
                    }

                    AlertaSuperior.ShowSuccess("Se agregó correctamente el dependiente");
                }
                mdlDependiente.Hide();
                marcaApartado(ref oDeclaracion, 6);
                _oDeclaracion = oDeclaracion;

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            mdlDependiente.Hide();
        }
        protected void OnEditar(object sender, ItemEventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            var personaSeleccionada = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == e.Id).First();
            var esPareja = personaSeleccionada.L_PAREJA;

            mdlDependiente.Show(true);
            mdlDependiente.HeaderText = "Modificar datos " + (esPareja ? "de la pareja" : "del dependiente");

            _oDependiente = personaSeleccionada;
            ctrlDependiente1.llena(personaSeleccionada);
        }

        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            try
            {
                blld_DECLARACION oDeclaracion = _oDeclaracion;

                bool esPareja = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(p => p.NID_DEPENDIENTE == e.Id).First().L_PAREJA;
                var o = oDeclaracion.DECLARACION_DEPENDIENTESs.Where(n => n.NID_DEPENDIENTE == e.Id).First();
                oDeclaracion.DECLARACION_DEPENDIENTESs.Remove(o);

                esPareja = false;
                if (e.State)
                    grd.Controls.Remove(((Item)grd.FindControl(String.Concat("grd", e.Id))));
                else
                    grdx7.Controls.Remove(((Item)grdx7.FindControl(String.Concat("grdx7", e.Id))));

                _oDeclaracion = oDeclaracion;
                AlertaSuperior.ShowSuccess("Se eliminó correctamente " + (esPareja ? "la pareja" : "el dependiente"));
            }
            catch (Exception ex)
            {
                if (ex.InnerException is CustomException || ex.InnerException is ConvertionException)
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

        protected void QstBoxDep_Yes(object Sender, EventArgs e)
        {
            //No hagas nada 
        }

        protected void QstBoxDep_No(object Sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            marcaApartado(ref oDeclaracion, 6);
            _oDeclaracion = oDeclaracion;
            Siguiente();
        }

        private void ControlaEjercicio(string Anio)
        {
            QstEjercicio.AskDanger("Su declaración corresponde al ejercicio: <b>" + Convert.ToDateTime(Anio).Year.ToString() + "</b>. Si es correcto continué en caso contrario corrija la fecha de posesión de encargo.</b><br><br><br> <h3><p style='color:#FF0000';> ¿Esta de Acuerdo? </p></h3>");

        }
        protected void QstEjercicio_Yes(object Sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            try
            {
                oDeclaracion.C_EJERCICIO = Convert.ToDateTime(this.txtF_POSESION.Text).Year.ToString();
                oDeclaracion.update();
            }
            catch
            { }
        }

        protected void QstEjercicio_No(object Sender, EventArgs e)
        {
            this.txtF_POSESION.Focus();
        }

        protected void cmbNID_PAIS_LABORAL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbPaisDomParticular_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbPaisDomParticular.SelectedValue == "1")
                this.idDomDeclarante.Text = "Localidad o Colonia";
            else
                this.idDomDeclarante.Text = "Ciudad/Localidad";


            blld__l_CAT_ENTIDAD_FEDERATIVA oEFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();

            oEFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisDomParticular.SelectedValue());
            oEFederativa.select();
            cmbEntidadFederativaDomParticular.DataBind(oEFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            cmbEntidadFederativaDomParticular_SelectedIndexChanged(sender, e);
        }

        protected void cmbEntidadFederativaDomParticular_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO oMunicipio = new blld__l_CAT_MUNICIPIO();

            oMunicipio.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisDomParticular.SelectedValue());
            oMunicipio.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbEntidadFederativaDomParticular.SelectedValue);
            oMunicipio.select();
            cmbMunicipioDomParticular.DataBind(oMunicipio.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);

        }

        protected void cbxOtroEmpleo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxOtroEmpleo.Checked == true)
            { this.DivOtroEmpleo.Visible = true; txtCargoObserva.Focus(); }
            else
            { this.DivOtroEmpleo.Visible = false; }
        }

        protected void cmbCARGO_NID_PAIS_OTRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEFederativa_Otra = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            if (cmbCARGO_NID_PAIS_OTRO.SelectedValue != "1" && cmbCARGO_NID_PAIS_OTRO.SelectedValue != "")
            {
                lblCargoDescribe.Text = "Ciudad/Localidad";
                this.txtCargoExtrangero.Visible = true;
            }
            else
            {
                lblCargoDescribe.Text = "Localidad/Colonia";
                this.txtCargoExtrangero.Visible = false;
            }

            oEFederativa_Otra.NID_PAIS = new Declara_V2.IntegerFilter(cmbCARGO_NID_PAIS_OTRO.SelectedValue());
            oEFederativa_Otra.select();
            cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO.DataBind(oEFederativa_Otra.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO_SelectedIndexChanged(sender, e);
        }

        protected void cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO oMunicipio_Otro = new blld__l_CAT_MUNICIPIO();

            oMunicipio_Otro.NID_PAIS = new Declara_V2.IntegerFilter(cmbCARGO_NID_PAIS_OTRO.SelectedValue());
            oMunicipio_Otro.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO.SelectedValue);
            oMunicipio_Otro.select();
            cmbCARGO_CID_MUNICIPIO_OTRO.DataBind(oMunicipio_Otro.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
        }

    }
}