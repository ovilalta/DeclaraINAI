using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Declara_V2.BLL;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;


namespace DeclaraINE.Formas.DeclaracionConflicto
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
            blld_DECLARACION_DEPENDIENTES p;

            for (int x = 0; x < oDeclaracion.DECLARACION_DEPENDIENTESs.Count; x++)
            {
                o = oDeclaracion.DECLARACION_DEPENDIENTESs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("grd", x);
                ((Item)item).TextoPrincipal = o.V_TIPO_DEPENDIENTE;
                ((Item)item).TextoSecundario = o.V_NOMBRE_COMPLETO;

                //((Button)((Item)item).FindControl("btnBaja")).Visible = false;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", o.NID_TIPO_DEPENDIENTE, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                if (o.L_PAREJA == false)
                    grd.Controls.AddAt(0 + x, item);
            }

            for (int p1 = 0; p1 < oDeclaracion.DECLARACION_DEPENDIENTESs.Count; p1++)
            {
                //  p = oDeclaracion.DECLARACION_DEPENDIENTESs[p1];
                p = oDeclaracion.DECLARACION_DEPENDIENTESs[p1];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = p1;
                ((Item)item).ID = String.Concat("grdPareja", p1);
                ((Item)item).TextoPrincipal =   p.V_TIPO_DEPENDIENTE;
                ((Item)item).TextoSecundario = p.V_NOMBRE_COMPLETO;

                //((Button)((Item)item).FindControl("btnBaja")).Visible = false;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", p.NID_TIPO_DEPENDIENTE, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                if(p.L_PAREJA==true)
                  grdPareja.Controls.AddAt(0 + p1, item);
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


            //((HtmlControl)Master.FindControl("liDatosGenerales")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("liConflictoInteres")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu6")).Attributes.Add("class", "tab-pane fade level1 active in");
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
               // cmbCARGO_NID_PAIS_OTRO.SelectedIndex = 0;
                cmbNacionalidad.SelectedIndex = 0;
                cmbEstadoCivil.SelectedIndex = 0;
                cmbRegimenMatrimonial.SelectedIndex = 0;
                cmbPaisDomParticular_SelectedIndexChanged(sender, e);
               // cmbCARGO_NID_PAIS_OTRO_SelectedIndexChanged(sender, e);
                // Cargo Nivel Órden de Gobierno
                rbtOtroOrdenGobierno.Items.Insert(0, new ListItem("Federal", "1"));
                rbtOtroOrdenGobierno.Items.Insert(1, new ListItem("Estatal", "2"));
                rbtOtroOrdenGobierno.Items.Insert(2, new ListItem("Municipal / Alcaldía", "3"));
                // Cargo Ambito Público
                rbtAmbitoPublico.Items.Insert(0, new ListItem("Federal", "1"));
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
                    ltrSubTitulo.Text = " <h6> <p align='left'>  C. TITULAR DEL ORGANO INTERNO DE CONTROL BAJO PROTESTA DE DECIR VERDAD, PRESENTO A USTED MI DECLARACIÓN DE SITUACIÓN PATRIMONIAL Y DE INTERESES, CONFORME A LO DISPUESTO EN LA LEY GENERAL DE RESPONSABILIDADES ADMINISTRATIVAS, LA LEY GENERAL DEL SISTEMA NACIONAL ANTICORRUPCIÓN Y LA NORMATIVIDAD APLICABLE</p></H6> 1. Datos Generales - Datos Personales";
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


                blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                oPuesto.select();
                cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO;
                cmbVID_CLAVEPUESTO.DataTextField = CAT_PUESTO.Properties.VID_PUESTO.ToString();
                cmbVID_CLAVEPUESTO.DataValueField = CAT_PUESTO.Properties.NID_PUESTO.ToString();
                cmbVID_CLAVEPUESTO.DataBind();

                blld__l_CAT_PRIMER_NIVEL oPrimerNivel = new blld__l_CAT_PRIMER_NIVEL();
                oPrimerNivel.OrderByCriterios.Add(new Declara_V2.Order(CAT_PRIMER_NIVEL.Properties.V_PRIMER_NIVEL));
                oPrimerNivel.select();
                cmbVID_PRIMER_NIVEL.DataSource = oPrimerNivel.lista_CAT_PRIMER_NIVEL;
                cmbVID_PRIMER_NIVEL.DataTextField = CAT_PRIMER_NIVEL.Properties.V_PRIMER_NIVEL.ToString();
                cmbVID_PRIMER_NIVEL.DataValueField = CAT_PRIMER_NIVEL.Properties.VID_PRIMER_NIVEL.ToString();
                cmbVID_PRIMER_NIVEL.DataBind();
                txtVID_PRIMER_NIVEL_TextChanged(cmbVID_PRIMER_NIVEL, null);

                grdPreguntas.DataBind(oDeclaracion.DECLARACION_RESTRICCIONESs);
                blld__l_CAT_ENTIDAD_FEDERATIVA oFed = new blld__l_CAT_ENTIDAD_FEDERATIVA();
                oFed.select();
                cmbCID_ENTIDAD_FEDERATIVA_LABORAL.DataBind(oFed.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);

                cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged(sender, e);
                active();

            }

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

        //protected void cmbcIdEntidadFederativaNacimiento_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
        //    omun.NID_PAIS = new Declara_V2.IntegerFilter(cmbnIdPaisNacimiento.SelectedValue());
        //    omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbcIdEntidadFederativaNacimiento.SelectedValue);
        //    omun.select();
        //    cmbcIdMunicipioNacimiento.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
        //}


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
                    ltrSubTitulo.Text = "6.- Datos de la pareja";
                    pnlDatosPersonales.Visible = false;
                    pnlDomicilioParticular.Visible = false;
                    pnlCargo.Visible = false;
                    pnlDomicilioLaboral.Visible = false;
                    pnlPareja.Visible = true;
                    pnlDependientes.Visible = false;
                    SubSeccionActiva = SubSecciones.DomicilioLaboral;
                    break;
                case SubSecciones.DomicilioLaboral:
                    //ltrSubTitulo.Text = "2. Domicilio del Declarante - Domicilio Laboral";
                    //pnlDatosPersonales.Visible = false;
                    //pnlDomicilioParticular.Visible = false;
                    //pnlCargo.Visible = false;
                    //pnlDomicilioLaboral.Visible = true;
                    //pnlDependientes.Visible = false;
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
                                oDeclaracion.DECLARACION_REGIMEN_MATRIMONIALs.First().NID_REGIMEN_MATRIMONIAL = cmbRegimenMatrimonial.SelectedValue();
                                oDeclaracion.DECLARACION_REGIMEN_MATRIMONIALs.First().update();
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO = txtV_CORREO_PERSONAL.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR = txtV_TEL_PARTICULAR.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR = txtV_TEL_CELULAR.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.update();
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
                                    //public blld_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL,
                                    //Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_CALLE 10, String V_NUMERO_EXTERNO, String V_NUMERO_INTERNO, String V_CORREO, String V_TEL_PARTICULAR, String V_TEL_CELULAR, String E_OBSERVACIONES, String V_ENTIDAD_FEDERATIVA, String V_MUNICIPIO)
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



                                //if (cmbPaisDomParticular.SelectedValue == "1")
                                //{
                                    cmbEntidadFederativaDomParticular.SelectedValue = oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA;
                                    cmbEntidadFederativaDomParticular_SelectedIndexChanged(cmbEntidadFederativaDomParticular, null);
                                    cmbMunicipioDomParticular.SelectedValue= oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO;
                                    // cmbEntidadFederativaDomParticular.SelectedValue = oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO;
                                //}
                                //else
                                //{
                                //    txtbEntidadFederativaDomicilioParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_ENTIDAD_FEDERATIVA;
                                //    txtMunicipioDomicilioParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_MUNICIPIO;
                                //}

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
                                //}
                                //else
                                //{
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
                                ltrSubTitulo.Text = "4. Datos del empleo, cargo o comisión que concluye";
                                pnlDatosPersonales.Visible = false;
                                pnlDomicilioParticular.Visible = false;
                                pnlCargo.Visible = true;
                                pnlDomicilioLaboral.Visible = false;
                                pnlDependientes.Visible = false;
                                SubSeccionActiva = SubSecciones.Cargo;

                                try
                                {
                                    blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                                    oPuesto.select();
                                    cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO;
                                    cmbVID_CLAVEPUESTO.DataTextField = CAT_PUESTO.Properties.VID_PUESTO.ToString();
                                    cmbVID_CLAVEPUESTO.DataValueField = CAT_PUESTO.Properties.NID_PUESTO.ToString();
                                    cmbVID_CLAVEPUESTO.DataBind();

                                    cmbVID_CLAVEPUESTO.SelectedValue = oDeclaracion.DECLARACION_CARGO.NID_PUESTO.ToString();
                                    cmbVID_CLAVEPUESTO_SelectedIndexChanged(cmbVID_CLAVEPUESTO, null);
                                    cmbVID_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.NID_PUESTO.ToString();
                                    cmbVID_NIVEL_SelectedIndexChanged(cmbVID_NIVEL, null);
                                    txt_DENOMINACION_CARGO.Text = oDeclaracion.DECLARACION_CARGO.V_FUNCION_PRINCIPAL;
                                    cmbVID_PRIMER_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.VID_PRIMER_NIVEL;
                                    txtVID_PRIMER_NIVEL_TextChanged(cmbVID_PRIMER_NIVEL, null);
                                    cmbVID_SEGUNDO_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.VID_SEGUNDO_NIVEL;
                                    txtF_POSESION.Text = oDeclaracion.DECLARACION_CARGO.F_POSESION.ToString(strFormatoFecha);
                                    txtF_INGRESO.Text = oDeclaracion.DECLARACION_CARGO.F_INICIO.ToString(strFormatoFecha);
                                    // DATOS DEL DOMICILIO LABORAL

                                    C_CODIGO_POSTAL.Text = oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL;
                                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue = oDeclaracion.DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA;
                                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged(cmbCID_ENTIDAD_FEDERATIVA_LABORAL, null);
                                    cmbCID_MUNICIPIO_LABORAL.SelectedValue = oDeclaracion.DECLARACION_DOM_LABORAL.CID_MUNICIPIO;
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
                                    if(txtCargoEntePublico.Text.Length>0)
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
                                    if(Manejo== "True")
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
                                    cmbCARGO_NID_PAIS_OTRO_SelectedIndexChanged(cmbCARGO_NID_PAIS_OTRO,null);
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
                                    oDeclaracion.DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA = cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue;
                                    oDeclaracion.DECLARACION_DOM_LABORAL.CID_MUNICIPIO = cmbCID_MUNICIPIO_LABORAL.SelectedValue;
                                    oDeclaracion.DECLARACION_DOM_LABORAL.V_COLONIA = txtV_COLONIA_LABORAL.Text;
                                    oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO = String.Concat(txtV_DOMICILIO_LABORAL.Text, '|', txtNumExteriorDOMICILIO_LABORAL.Text, '|', txtNumInteriorDOMICILIO_LABORAL.Text);
                                    oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL = txtV_CORREO_LABORAL.Text;
                                    oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL = String.Concat(txtV_TELEFONO_LABORAL1.Text, '|', txtV_TELEFONO_LABORAL2.Text);
                                    oDeclaracion.DECLARACION_DOM_LABORAL.update();
                                    oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES = txtObservaciones.Text;
                                    oDeclaracion.DECLARACION_CARGO.update();
                                    try
                                    {
                                        oDeclaracion.DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO =Convert.ToInt32( rbtOtroOrdenGobierno.SelectedValue);
                                            oDeclaracion.DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO = Convert.ToInt32(rbtAmbitoPublico.SelectedValue);
                                            oDeclaracion.DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTE = txtCargoEntePublico.Text;
                                            oDeclaracion.DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCION = txtCargoAreaAdscripcion.Text;
                                            oDeclaracion.DECLARACION_CARGO_OTRO.V_CARGO = txtCargoEmpleo.Text;
                                            if(cbxCargoHonorarios.Checked==true)
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
                                            oDeclaracion.DECLARACION_CARGO_OTRO.V_DOMICILIO= String.Concat(txtCargoV_DOMICILIO_O.Text, '|', txtCargoNumExteriorDOMICILIO_O.Text, '|', txtCargoNumInteriorDOMICILIO_O.Text, '|', txtCargoEstado.Text);
                                         
                                            oDeclaracion.DECLARACION_CARGO_OTRO.V_OBSERVACIONES = txtCargoObserva.Text;
                                            oDeclaracion.DECLARACION_CARGO_OTRO.update();
                                    }
                                    catch
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
                                                                                                                 , cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue
                                                                                                                 , cmbCID_MUNICIPIO_LABORAL.SelectedValue
                                                                                                                 , txtV_COLONIA_LABORAL.Text
                                                                                                                 , String.Concat(txtV_DOMICILIO_LABORAL.Text, '|', txtNumExteriorDOMICILIO_LABORAL.Text, '|', txtNumInteriorDOMICILIO_LABORAL.Text)
                                                                                                                 , txtV_CORREO_LABORAL.Text
                                                                                                                 , String.Concat(txtV_TELEFONO_LABORAL1.Text, '|', txtV_TELEFONO_LABORAL2.Text));

                                        oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES = txtObservaciones.Text;
                                        oDeclaracion.DECLARACION_CARGO.update();

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
                                    else if (ex is CustomException || ex is ConvertionException)
                                    {
                                        MsgBox.ShowDanger(ex.Message);
                                        lBanderaPasa = false;
                                    }
                                    else throw ex;
                                }
                                lBanderaActualizaAnterior = true;
                                marcaApartado(ref oDeclaracion, 4);
                            }
                            if (lBanderaPasa)
                            {
                                lBanderaActualizaAnterior = true;
                                Response.Redirect("ExperienciaLaboral.aspx");

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
                                ltrSubTitulo.Text = "Datos del dependiente económico";
                                pnlDatosPersonales.Visible = false;
                                pnlDomicilioParticular.Visible = false;
                                pnlCargo.Visible = false;
                                pnlDomicilioLaboral.Visible = false;
                                // Aqui se tiene que modificar *****
                               
                                pnlPareja.Visible = false;
                                pnlDependientes.Visible = true;
                                 SubSeccionActiva = SubSecciones.DependienteEconomicos;
                                //OEVM
                                if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value) ;
                                    QstBoxDep.Ask("¿Cuenta con dependientes económicos que desee registrar?");
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
                            // ltrSubTitulo.Text = "Datos Generales - Cónyuge, concubina o concubinario y/ o dependientes económicos";
                            // pnlDatosPersonales.Visible = false;
                            // pnlDomicilioParticular.Visible = false;
                            // pnlCargo.Visible = false;
                            // pnlDomicilioLaboral.Visible = false;
                            //// Aqui se tiene que modificar *****
                            // pnlDependientes.Visible = true;
                            // SubSeccionActiva = SubSecciones.DependienteEconomicos;
                            //OEVM Revisar si es correcto que esté el if
                            //if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                            //     QstBoxDep.Ask("¿Cuenta con dependientes económicos y/o cónyuge que desee registrar?");

                            ltrSubTitulo.Text = "Datos de la pareja";
                            pnlDatosPersonales.Visible = false;
                            pnlDomicilioParticular.Visible = false;
                            pnlCargo.Visible = false;
                            pnlDomicilioLaboral.Visible = false;
                            // Aqui se tiene que modificar *****
                            pnlDependientes.Visible = false;
                            pnlPareja.Visible = true;
                            //SubSeccionActiva = SubSecciones.DependienteEconomicos;
                            //OEVM
                            if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value) ;
                                QstBoxDep.Ask("¿Cuenta con cónyuge que desee registrar?");


                        }
                        break;
                    case SubSecciones.DependienteEconomicos:
                        if(!lBanderaActualizaAnterior)
                        { 
                               
                                    ltrSubTitulo.Text = "Datos del dependiente económico";
                                    pnlDatosPersonales.Visible = false;
                                    pnlDomicilioParticular.Visible = false;
                                    pnlCargo.Visible = false;
                                    pnlDomicilioLaboral.Visible = false;
                                    pnlPareja.Visible = false;
                                    // Aqui se tiene que modificar *****
                                    pnlDependientes.Visible = true;
                                    SubSeccionActiva = SubSecciones.DependienteEconomicos;
                                   //OEVM
                                     if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                                        QstBoxDep.Ask("¿Cuenta con dependientes económicos  que desee registrar?");

                            lBanderaActualizaAnterior = true;
                            lBanderaPasa = false;
                        }
                        else
                        { 
                                if(lBanderaPasa && lBanderaActualizaAnterior)
                                {
                                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
                                    {
                                        MsgBox.ShowWarning("Debe finalizar el apartado 'Datos Generales' para continuar con la declaración");
                                    }
                                    else
                                    {
                                        Response.Redirect("Ingresos.aspx");
                                    }
                                }
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
            ((_Conflicto)Master).links_DatosGenerales(ref oDeclaracion);
            switch (SubSeccionActiva)
            {
                case SubSecciones.DatosPersonales:
                    Response.Redirect("Conflicto.aspx");
                    //if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                    //    ((LinkButton)Master.FindControl("lkDatosPersonales")).CssClass = "completeve";
                    //else
                    //    ((LinkButton)Master.FindControl("lkDatosPersonales")).CssClass = "active";
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
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue = oCodigo.CID_ENTIDAD_FEDERATIVA;
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged(sender, e);
                    cmbCID_MUNICIPIO_LABORAL.SelectedValue = oCodigo.CID_MUNICIPIO;
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
            omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue);
            omun.select();
            cmbCID_MUNICIPIO_LABORAL.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
        }

        protected void txtVID_CLAVEPUESTO_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cmbVID_NIVEL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                blld_CAT_PUESTO oPuesto = new blld_CAT_PUESTO(cmbVID_CLAVEPUESTO.SelectedItem.Text, cmbVID_NIVEL.SelectedValue());
                //txtV_DENOMINACION_PUESTO.Text = oPuesto.V_PUESTO_COMPUESTO;
                txtV_DENOMINACION_PUESTO.Text = oPuesto.V_PUESTO;
            }
            catch
            {
                txtV_DENOMINACION_PUESTO.Text = String.Empty;
            }
        }

        protected void cmbVID_CLAVEPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
            oPuesto.VID_PUESTO = new Declara_V2.StringFilter(cmbVID_CLAVEPUESTO.SelectedItem.Text);
            oPuesto.L_ACTIVO = true;
            oPuesto.select();
            cmbVID_NIVEL.DataBind(oPuesto.lista_CAT_PUESTO, CAT_PUESTO.Properties.NID_PUESTO, CAT_PUESTO.Properties.V_PUESTO_NIVEL);
            txtV_DENOMINACION_PUESTO.Text = String.Empty;
            cmbVID_NIVEL.Items.Insert(0, new ListItem(String.Empty));
            cmbVID_NIVEL.SelectedValue = String.Empty;
        }

        protected void btnAgregarDependiente_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
            oCAT_PAIS.select();
            cmbNID_PAIS_LABORAL_DEP.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
            cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(cmbNID_PAIS_LABORAL_DEP, null);
            EligeDependiente();
            labTipoRelacion.Text = "Parentesco o relación con el declarante";
            lEditar = false;

            mppPareja.Show(true);
            mppPareja.HeaderText = "Dar de alta datos de dependiente economico";
            //mdlDependiente.Show(true);
            //mdlDependiente.HeaderText = "Dar de alta dependiente";
            //ctrlDependiente1.limpia();
        }

        protected void btnGuardaDependiente_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            try
            {
                if (ctrlDependiente1.Accion == ctrlDependiente.Acciones.Actualiza)
                {
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].NID_TIPO_DEPENDIENTE = Convert.ToInt32(ctrlDependiente1.NID_TIPO_DEPENDIENTE);
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].E_NOMBRE = ctrlDependiente1.E_NOMBRE;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].E_PRIMER_A = ctrlDependiente1.E_PRIMER_A;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].E_SEGUNDO_A = ctrlDependiente1.E_SEGUNDO_A;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].F_NACIMIENTO = ctrlDependiente1.F_NACIMIENTO;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].E_RFC = ctrlDependiente1.E_RFC;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].L_DEPENDE_ECO = ctrlDependiente1.L_DEPENDE_ECO;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].L_PAREJA = ctrlDependiente1.L_PAREJA;
                    //,  ctrlDependiente1.L_ACTIVO
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].L_CIUDADANO_EXTRANJERO = ctrlDependiente1.L_CIUDADANO_EXTRANJERO;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].E_CURP = ctrlDependiente1.E_CURP;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].NID_ACTIVIDAD_LABORAL = ctrlDependiente1.NID_ACTIVIDAD_LABORAL;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].E_OBSERVACIONES = ctrlDependiente1.E_OBSERVACIONES;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].E_OBSERVACIONES_MARCADO = ctrlDependiente1.E_OBSERVACIONES_MARCADO;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].V_OBSERVACIONES_TESTADO = ctrlDependiente1.V_OBSERVACIONES_TESTADO;
                    //,  ctrlDependiente1.NID_ESTADO_TESTADO
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].L_MISMO_DOMICILIO_DECLARANTE = ctrlDependiente1.L_MISMO_DOMICILIO_DECLARANTE;


                    //Domicilio
                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DomicilioUpdate(ctrlDependiente1.C_CODIGO_POSTAL
                    , ctrlDependiente1.NID_PAIS
                    , ctrlDependiente1.CID_ENTIDAD_FEDERATIVA
                    , ctrlDependiente1.CID_MUNICIPIO
                    , ctrlDependiente1.V_COLONIA
                    , ctrlDependiente1.V_DOMICILIO);

                    //PRIVADO
                    if (ctrlDependiente1.NID_ACTIVIDAD_LABORAL == 1)
                    {
                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].NID_DEPENDIENTE);

                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = ctrlDependiente1.V_NOMBRE;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = ctrlDependiente1.V_CARGO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = ctrlDependiente1.V_RFC;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = ctrlDependiente1.M_SALARIO_MENSUAL.Value;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR = ctrlDependiente1.NID_SECTOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = ctrlDependiente1.L_PROVEEDOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.update();
                        }
                        catch (Exception ex)
                        {
                           // String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, String V_NOMBRE, String V_CARGO, String V_RFC, DateTime F_INGRESO, Int32 NID_SECTOR, Decimal M_SALARIO_MENSUAL, Boolean L_PROVEEDOR)

                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION
                                ,
                         ctrlDependiente1.V_NOMBRE,
                         "", ctrlDependiente1.V_RFC,
                         DateTime.Now.Date,
                             ctrlDependiente1.NID_SECTOR, 0m,
                              ctrlDependiente1.L_PROVEEDOR
                               );

                        }
                    }


                    //Publico
                    if (ctrlDependiente1.NID_ACTIVIDAD_LABORAL == 2)
                    {

                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PUBLICO oDep = new blld_DECLARACION_DEPENDIENTES_PUBLICO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].NID_DEPENDIENTE);



                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR = ctrlDependiente1.NID_AMBITO_SECTOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO = ctrlDependiente1.NID_NIVEL_GOBIERNO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO = ctrlDependiente1.NID_AMBITO_PUBLICO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE = ctrlDependiente1.V_NOMBRE_ENTE;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION = ctrlDependiente1.V_AREA_ADSCRIPCION;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO = ctrlDependiente1.V_CARGO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL = ctrlDependiente1.V_FUNCION_PRINCIPAL;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL = ctrlDependiente1.M_SALARIO_MENSUAL.Value;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO = ctrlDependiente1.F_INGRESO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PUBLICO.update();


                        }
                        catch (Exception)
                        {

                            //DECLARACION_DEPENDIENTES_PUBLICO oDep = new DECLARACION_DEPENDIENTES_PUBLICO();
                            blld_DECLARACION_DEPENDIENTES_PUBLICO oDep = new blld_DECLARACION_DEPENDIENTES_PUBLICO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION
                                ,
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


                            //MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();

                            //oDep.VID_NOMBRE = oDeclaracion.VID_NOMBRE;
                            //oDep.VID_FECHA = oDeclaracion.VID_FECHA;
                            //oDep.VID_HOMOCLAVE = oDeclaracion.VID_HOMOCLAVE;
                            //oDep.NID_DECLARACION = oDeclaracion.NID_DECLARACION;
                            //oDep.NID_DEPENDIENTE = oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].NID_DEPENDIENTE;

                            //oDep.NID_AMBITO_SECTOR = ctrlDependiente1.NID_AMBITO_SECTOR;
                            //oDep.NID_NIVEL_GOBIERNO = ctrlDependiente1.NID_NIVEL_GOBIERNO;
                            //oDep.NID_AMBITO_PUBLICO = ctrlDependiente1.NID_AMBITO_PUBLICO;
                            //oDep.V_NOMBRE_ENTE = ctrlDependiente1.V_NOMBRE_ENTE;
                            //oDep.V_AREA_ADSCRIPCION = ctrlDependiente1.V_AREA_ADSCRIPCION;
                            //oDep.V_CARGO = ctrlDependiente1.V_CARGO;
                            //oDep.V_FUNCION_PRINCIPAL = ctrlDependiente1.V_FUNCION_PRINCIPAL;
                            //oDep.M_SALARIO_MENSUAL = ctrlDependiente1.M_SALARIO_MENSUAL.Value;
                            //oDep.F_INGRESO = ctrlDependiente1.F_INGRESO;

                            //db.DECLARACION_DEPENDIENTES_PUBLICO.Add(oDep);
                            ////db.Entry(oDep).State = System.Data.Entity.EntityState.Modified;
                            //db.SaveChanges();

                        }
                    }


                    //PRIVADO
                    if (ctrlDependiente1.NID_ACTIVIDAD_LABORAL == 3)
                    {
                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].NID_DEPENDIENTE);

                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = ctrlDependiente1.V_NOMBRE;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = ctrlDependiente1.V_CARGO;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = ctrlDependiente1.V_RFC;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = ctrlDependiente1.M_SALARIO_MENSUAL.Value;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR = ctrlDependiente1.NID_SECTOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = ctrlDependiente1.L_PROVEEDOR;
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.update();
                        }
                        catch (Exception ex)
                        {


                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION
                                ,
                         ctrlDependiente1.V_NOMBRE,
                         "", ctrlDependiente1.V_RFC,
                         DateTime.Now.Date,
                             ctrlDependiente1.NID_SECTOR, 0m,
                              ctrlDependiente1.L_PROVEEDOR
                               );
                        }
                    }


                    oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].update();

                    ((Item)grd.FindControl(String.Concat("grd", ctrlDependiente1.Selected_id))).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", ctrlDependiente1.NID_TIPO_DEPENDIENTE, ".png");
                    ((Item)grd.FindControl(String.Concat("grd", ctrlDependiente1.Selected_id))).TextoPrincipal = oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].V_TIPO_DEPENDIENTE;
                    ((Item)grd.FindControl(String.Concat("grd", ctrlDependiente1.Selected_id))).TextoSecundario = oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].V_NOMBRE_COMPLETO;
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

                    blld_DECLARACION_DEPENDIENTES o = oDeclaracion.DECLARACION_DEPENDIENTESs.Last();
                    UserControl item = (UserControl)Page.LoadControl("item.ascx");
                    ((Item)item).Id = oDeclaracion.DECLARACION_DEPENDIENTESs.Count() + 1;
                    ((Item)item).ID = String.Concat("grd", oDeclaracion.DECLARACION_DEPENDIENTESs.Count() + 1);
                    ((Item)item).TextoPrincipal = o.V_TIPO_DEPENDIENTE;
                    ((Item)item).TextoSecundario = o.V_NOMBRE_COMPLETO;
                    ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", o.NID_TIPO_DEPENDIENTE, ".png");
                    ((Item)item).Editar += OnEditar;
                    ((Item)item).Eliminar += OnEliminar;
                    grd.Controls.AddAt(grd.Controls.Count - 3, item);
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

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            switch (SubSeccionActiva)
            {
                case SubSecciones.DependienteEconomicos:

                    blld_DECLARACION_DEPENDIENTES j;
                    mppPareja.Show(true);
                    mppPareja.HeaderText = "Modificar dependiente";
                    j = oDeclaracion.DECLARACION_DEPENDIENTESs[e.Id];
                    IndiceItemSeleccionadoDep = e.Id;
                    try { txtE_NOMBRE.Text = _bllSistema.DesEncriptaStatic(j.E_NOMBRE.ToString()); } catch { txtE_NOMBRE.Text = j.E_NOMBRE.ToString(); }
                    try { txtE_PRIMER_A.Text = _bllSistema.DesEncriptaStatic(j.E_PRIMER_A.ToString()); } catch { txtE_PRIMER_A.Text = j.E_PRIMER_A.ToString(); }
                    try { txtE_SEGUNDO_A.Text = _bllSistema.DesEncriptaStatic(j.E_SEGUNDO_A.ToString()); } catch { txtE_SEGUNDO_A.Text = j.E_SEGUNDO_A.ToString(); }
                    txtF_NACIMIENTO.Text = j.F_NACIMIENTO.ToString();
                    txtE_RFC.Text = j.E_RFC.ToString();
                    EligeDependiente();
                    cmbNID_TIPO_DEPENDIENTE_DEP.SelectedValue = j.NID_TIPO_DEPENDIENTE.ToString();
                    txtCurp.Text = j.E_CURP.ToString();
                    chk_L_MISMO_DOMICIO_DEP.Checked = j.L_MISMO_DOMICILIO_DECLARANTE;
                    cbxEstrangero.Checked = j.L_CIUDADANO_EXTRANJERO;
                    cbxL_DEPENDE_ECO.Checked = j.L_DEPENDE_ECO;
                    txtObservaPareja.Text = j.E_OBSERVACIONES;
                    blld__l_CAT_PAIS oPCAT_PAIS = new blld__l_CAT_PAIS();
                    oPCAT_PAIS.select();
                    cmbNID_PAIS_LABORAL_DEP.DataBind(oPCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                    cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(cmbNID_PAIS_LABORAL_DEP, null);
                    if (!j.L_MISMO_DOMICILIO_DECLARANTE)
                    {
                        try
                        {
                            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();

                            var oDomicilio = ((from p in db.DECLARACION_DEPENDIENTES_DOMICILIO
                                               where
                                                      p.VID_NOMBRE == j.VID_NOMBRE &&
                                                      p.VID_FECHA == j.VID_FECHA &&
                                                      p.VID_HOMOCLAVE == j.VID_HOMOCLAVE &&
                                                      p.NID_DECLARACION == j.NID_DECLARACION &&
                                                      p.NID_DEPENDIENTE == j.NID_DEPENDIENTE
                                               select p).First());


                            C_CODIGO_POSTAL_DEP.Text = oDomicilio.C_CODIGO_POSTAL;



                            cmbNID_PAIS_LABORAL_DEP.SelectedValue = oDomicilio.NID_PAIS.ToString();
                            cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(cmbNID_PAIS_LABORAL_DEP, null);
                            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue = oDomicilio.CID_ENTIDAD_FEDERATIVA;
                            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP, null);
                            cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue = oDomicilio.CID_MUNICIPIO;



                            try { txtColoniaDep.Text = _bllSistema.DesEncriptaStatic(oDomicilio.V_COLONIA); } catch { txtV_COLONIA_LABORAL.Text = oDomicilio.V_COLONIA; }
                            try { txtCalleDep.Text = _bllSistema.DesEncriptaStatic(oDomicilio.V_DOMICILIO); } catch { txtCalleDep.Text = oDomicilio.V_DOMICILIO; }
                            try { txtNumExtDep.Text = txtCalleDep.Text.Split('|')[1]; } catch { }
                            try { txtNumInteriorDep.Text = txtCalleDep.Text.Split('|')[2]; } catch { }
                            try { txtCalleDep.Text = txtCalleDep.Text.Split('|')[0]; } catch { }

                        }
                        catch (Exception)
                        {

                        }

                    }
                    else
                    {
                        pnlPareja.Visible = false;
                    }

                    if (j.NID_ACTIVIDAD_LABORAL == 3)
                    {
                        mostrarOtros();
                        rbtPr.Enabled = false;
                        rbtnPu.Enabled = false;
                        rbtnOtros.Enabled = false;
                        rbtnNinguno.Enabled = false;
                    }

                    if (j.NID_ACTIVIDAD_LABORAL == 4)
                    {
                        mostrarNinguno();
                        rbtPr.Enabled = false;
                        rbtnPu.Enabled = false;
                        rbtnOtros.Enabled = false;
                        rbtnNinguno.Enabled = false;

                    }

                    if (j.NID_ACTIVIDAD_LABORAL == 1)
                    {
                        mostrarPrivado();

                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDepPrivado = new blld_DECLARACION_DEPENDIENTES_PRIVADO(j.VID_NOMBRE, j.VID_FECHA, j.VID_HOMOCLAVE, j.NID_DECLARACION, j.NID_DEPENDIENTE);

                            txtNombre.Text = oDepPrivado.V_NOMBRE;
                            txtPuesto.Text = oDepPrivado.V_CARGO;
                            txtRFC.Text = oDepPrivado.V_RFC;

                            txtF_FechaIngresoPriv.Text = oDepPrivado.F_INGRESO.ToString();
                            cmbPR_Sector.SelectedIndex = oDepPrivado.NID_SECTOR;
                            moneytxtM_Salario.Text = oDepPrivado.M_SALARIO_MENSUAL.ToString("C");
                            cbxProveedor.Checked = oDepPrivado.L_PROVEEDOR;
                            rbtPr.Enabled = false;
                            rbtnPu.Enabled = false;
                            rbtnOtros.Enabled = false;
                            rbtnNinguno.Enabled = false;
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    if (j.NID_ACTIVIDAD_LABORAL == 3)
                    {
                        mostrarPrivado();

                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDepPrivado = new blld_DECLARACION_DEPENDIENTES_PRIVADO(j.VID_NOMBRE, j.VID_FECHA, j.VID_HOMOCLAVE, j.NID_DECLARACION, j.NID_DEPENDIENTE);

                            txtNombre.Text = oDepPrivado.V_NOMBRE;
                            txtPuesto.Text = oDepPrivado.V_CARGO;
                            txtRFC.Text = oDepPrivado.V_RFC;

                            txtF_FechaIngresoPriv.Text = oDepPrivado.F_INGRESO.ToString();
                            cmbPR_Sector.SelectedIndex = oDepPrivado.NID_SECTOR;
                            moneytxtM_Salario.Text = oDepPrivado.M_SALARIO_MENSUAL.ToString("C");
                            cbxProveedor.Checked = oDepPrivado.L_PROVEEDOR;
                            rbtPr.Enabled = false;
                            rbtnPu.Enabled = false;
                            rbtnOtros.Enabled = false;
                            rbtnNinguno.Enabled = false;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (j.NID_ACTIVIDAD_LABORAL == 2)
                    {
                        mostrarPublico();

                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PUBLICO oDepPublico = new blld_DECLARACION_DEPENDIENTES_PUBLICO(j.VID_NOMBRE, j.VID_FECHA, j.VID_HOMOCLAVE, j.NID_DECLARACION, j.NID_DEPENDIENTE);

                            cmbPU_nivel.SelectedIndex = oDepPublico.NID_NIVEL_GOBIERNO;
                            cmbPU_Ambito.SelectedIndex = oDepPublico.NID_AMBITO_PUBLICO;

                            txtNombre.Text = oDepPublico.V_NOMBRE_ENTE;
                            txtFuncion.Text = oDepPublico.V_FUNCION_PRINCIPAL;
                            moneytxtM_Salario.Text = oDepPublico.M_SALARIO_MENSUAL.ToString("C");
                            txtF_FechaIngreso.Text = oDepPublico.F_INGRESO.ToString();

                            txtPuesto.Text = oDepPublico.V_CARGO;
                            txtArea.Text = oDepPublico.V_AREA_ADSCRIPCION;

                            rbtPr.Enabled = false;
                            rbtnPu.Enabled = false;
                            rbtnOtros.Enabled = false;
                            rbtnNinguno.Enabled = false;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    // mdlDependiente.Show(true);
                    //mdlDependiente.HeaderText = "Modificar dependiente";
                    //ctrlDependiente1.llena(oDeclaracion.DECLARACION_DEPENDIENTESs[e.Id], e.Id);
                    break;
                case SubSecciones.DomicilioLaboral:
                    blld_DECLARACION_DEPENDIENTES i;
                    mppPareja.Show(true);
                    mppPareja.HeaderText = "Modificación Datos de la pareja";
                    i = oDeclaracion.DECLARACION_DEPENDIENTESs[e.Id];
                    IndiceItemSeleccionado = e.Id;

                    try { txtE_NOMBRE.Text = _bllSistema.DesEncriptaStatic(i.E_NOMBRE.ToString()); } catch { txtE_NOMBRE.Text = i.E_NOMBRE.ToString(); }
                    try { txtE_PRIMER_A.Text = _bllSistema.DesEncriptaStatic(i.E_PRIMER_A.ToString()); } catch { txtE_PRIMER_A.Text = i.E_PRIMER_A.ToString(); }
                    try { txtE_SEGUNDO_A.Text = _bllSistema.DesEncriptaStatic(i.E_SEGUNDO_A.ToString()); } catch { txtE_SEGUNDO_A.Text = i.E_SEGUNDO_A.ToString(); }
                   
                  
                    txtF_NACIMIENTO.Text = i.F_NACIMIENTO.ToString();
                    txtE_RFC.Text = i.E_RFC.ToString();
                    SelectDependiente();
                    cmbNID_TIPO_DEPENDIENTE_DEP.SelectedValue = i.NID_TIPO_DEPENDIENTE.ToString();
                    txtCurp.Text = i.E_CURP.ToString();
                    chk_L_MISMO_DOMICIO_DEP.Checked = i.L_MISMO_DOMICILIO_DECLARANTE;
                    cbxEstrangero.Checked = i.L_CIUDADANO_EXTRANJERO;
                    cbxL_DEPENDE_ECO.Checked = i.L_DEPENDE_ECO;
                    txtObservaPareja.Text = i.E_OBSERVACIONES;
                    blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
                    oCAT_PAIS.select();
                    cmbNID_PAIS_LABORAL_DEP.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                    cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(cmbNID_PAIS_LABORAL_DEP, null);
                    if (!i.L_MISMO_DOMICILIO_DECLARANTE)
                    {
                        try
                        {
                            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                           
                            var oDomicilio = ((from p in db.DECLARACION_DEPENDIENTES_DOMICILIO
                                               where
                                                      p.VID_NOMBRE == i.VID_NOMBRE &&
                                                      p.VID_FECHA == i.VID_FECHA &&
                                                      p.VID_HOMOCLAVE == i.VID_HOMOCLAVE &&
                                                      p.NID_DECLARACION == i.NID_DECLARACION &&
                                                      p.NID_DEPENDIENTE == i.NID_DEPENDIENTE
                                               select p).First());
                           

                            C_CODIGO_POSTAL_DEP.Text = oDomicilio.C_CODIGO_POSTAL;

                           

                            cmbNID_PAIS_LABORAL_DEP.SelectedValue = oDomicilio.NID_PAIS.ToString();
                            cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(cmbNID_PAIS_LABORAL_DEP, null);
                            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue = oDomicilio.CID_ENTIDAD_FEDERATIVA;
                            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP, null);
                            cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue = oDomicilio.CID_MUNICIPIO;



                            try { txtColoniaDep.Text = _bllSistema.DesEncriptaStatic(oDomicilio.V_COLONIA); } catch { txtV_COLONIA_LABORAL.Text = oDomicilio.V_COLONIA; }
                            try { txtCalleDep.Text = _bllSistema.DesEncriptaStatic(oDomicilio.V_DOMICILIO); } catch { txtCalleDep.Text = oDomicilio.V_DOMICILIO; }
                            try { txtNumExtDep.Text = txtCalleDep.Text.Split('|')[1]; } catch { }
                            try { txtNumInteriorDep.Text = txtCalleDep.Text.Split('|')[2]; } catch { }
                            try { txtCalleDep.Text = txtCalleDep.Text.Split('|')[0]; } catch { }
                           
                        }
                        catch (Exception)
                        {

                        }

                    }
                    else
                    {
                        pnlDependiente.Visible = false;
                    }

                    if (i.NID_ACTIVIDAD_LABORAL == 3)
                    {
                        mostrarOtros();
                        rbtPr.Enabled = false;
                        rbtnPu.Enabled = false;
                        rbtnOtros.Enabled = false;
                        rbtnNinguno.Enabled = false;
                    }

                    if (i.NID_ACTIVIDAD_LABORAL == 4)
                    {
                        mostrarNinguno();
                        rbtPr.Enabled = false;
                        rbtnPu.Enabled = false;
                        rbtnOtros.Enabled = false;
                        rbtnNinguno.Enabled = false;

                    }

                    if (i.NID_ACTIVIDAD_LABORAL == 1 )
                    {
                        mostrarPrivado();

                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDepPrivado = new blld_DECLARACION_DEPENDIENTES_PRIVADO(i.VID_NOMBRE, i.VID_FECHA, i.VID_HOMOCLAVE, i.NID_DECLARACION, i.NID_DEPENDIENTE);

                            txtNombre.Text = oDepPrivado.V_NOMBRE;
                            txtPuesto.Text = oDepPrivado.V_CARGO;
                            txtRFC.Text = oDepPrivado.V_RFC;

                            txtF_FechaIngresoPriv.Text = oDepPrivado.F_INGRESO.ToString();
                            cmbPR_Sector.SelectedIndex = oDepPrivado.NID_SECTOR;
                            moneytxtM_Salario.Text = oDepPrivado.M_SALARIO_MENSUAL.ToString("C");
                            cbxProveedor.Checked = oDepPrivado.L_PROVEEDOR;
                            rbtPr.Enabled = false;
                            rbtnPu.Enabled = false;
                            rbtnOtros.Enabled = false;
                            rbtnNinguno.Enabled = false;
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    if (i.NID_ACTIVIDAD_LABORAL == 3)
                    {
                        mostrarPrivado();

                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PRIVADO oDepPrivado = new blld_DECLARACION_DEPENDIENTES_PRIVADO(i.VID_NOMBRE, i.VID_FECHA, i.VID_HOMOCLAVE, i.NID_DECLARACION, i.NID_DEPENDIENTE);

                            txtNombre.Text = oDepPrivado.V_NOMBRE;
                            txtPuesto.Text = oDepPrivado.V_CARGO;
                            txtRFC.Text = oDepPrivado.V_RFC;

                            txtF_FechaIngresoPriv.Text = oDepPrivado.F_INGRESO.ToString();
                            cmbPR_Sector.SelectedIndex = oDepPrivado.NID_SECTOR;
                            moneytxtM_Salario.Text = oDepPrivado.M_SALARIO_MENSUAL.ToString("C");
                            cbxProveedor.Checked = oDepPrivado.L_PROVEEDOR;
                            rbtPr.Enabled = false;
                            rbtnPu.Enabled = false;
                            rbtnOtros.Enabled = false;
                            rbtnNinguno.Enabled = false;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (i.NID_ACTIVIDAD_LABORAL == 2)
                    {
                        mostrarPublico();

                        try
                        {
                            blld_DECLARACION_DEPENDIENTES_PUBLICO oDepPublico = new blld_DECLARACION_DEPENDIENTES_PUBLICO(i.VID_NOMBRE, i.VID_FECHA, i.VID_HOMOCLAVE, i.NID_DECLARACION, i.NID_DEPENDIENTE);

                            cmbPU_nivel.SelectedIndex = oDepPublico.NID_NIVEL_GOBIERNO;
                            cmbPU_Ambito.SelectedIndex = oDepPublico.NID_AMBITO_PUBLICO;

                            txtNombre.Text = oDepPublico.V_NOMBRE_ENTE;
                            txtFuncion.Text = oDepPublico.V_FUNCION_PRINCIPAL;
                            moneytxtM_Salario.Text = oDepPublico.M_SALARIO_MENSUAL.ToString("C");
                            txtF_FechaIngreso.Text = oDepPublico.F_INGRESO.ToString();

                            txtPuesto.Text = oDepPublico.V_CARGO;
                            txtArea.Text = oDepPublico.V_AREA_ADSCRIPCION;

                            rbtPr.Enabled = false;
                            rbtnPu.Enabled = false;
                            rbtnOtros.Enabled = false;
                            rbtnNinguno.Enabled = false;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    break;


            }
           
        }


        public void limpia()
        {

            txtE_NOMBRE.Text = String.Empty;
            txtE_PRIMER_A.Text = String.Empty;
            txtE_SEGUNDO_A.Text = String.Empty;
            txtF_NACIMIENTO.Text = String.Empty;
            txtE_RFC.Text = String.Empty;
            txtCurp.Text = String.Empty;
            cbxL_DEPENDE_ECO.Checked = false;
            chk_L_MISMO_DOMICIO_DEP.Checked = false;
            cbxEstrangero.Checked = false;
          
            cmbPU_nivel.ClearSelection();
            cmbPU_Ambito.ClearSelection();
            cmbPR_Sector.ClearSelection();

            txtNombre.Text = String.Empty;
            txtPuesto.Text = String.Empty;
            txtRFC.Text = String.Empty;
            txtF_FechaIngreso.Text = String.Empty;
          
            txtArea.Text = String.Empty;
            txtFuncion.Text = String.Empty;
            moneytxtM_Salario.Text = String.Empty;
            txtObservaciones.Text = String.Empty;
            cbxProveedor.Checked = false;

            cmbNID_PAIS_LABORAL_DEP.ClearSelection();
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.ClearSelection();
            cmbCID_MUNICIPIO_LABORAL_DEP.ClearSelection();

            //Direccion
            C_CODIGO_POSTAL_DEP.Text = String.Empty;
            txtV_COLONIA_LABORAL.Text = String.Empty;
            txtV_DOMICILIO_LABORAL.Text = String.Empty;
            txtNumExteriorDOMICILIO_LABORAL.Text = String.Empty;
            txtNumInteriorDOMICILIO_LABORAL.Text = String.Empty;
            txtCalleDep.Text = String.Empty;
            txtNumExtDep.Text = String.Empty;
            txtNumInteriorDep.Text = String.Empty;
            txtColoniaDep.Text = String.Empty;
            txtF_FechaIngresoPriv.Text = String.Empty;
            txtObservaPareja.Text = String.Empty;
            cmbNID_PAIS_LABORAL_DEP.ClearSelection();
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.ClearSelection();
            cmbCID_MUNICIPIO_LABORAL_DEP.ClearSelection();

            //cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Clear();
            //cmbCID_MUNICIPIO_LABORAL_DEP.Items.Clear();

            tr_Mixto1.Visible = false;
            tr_Mixto2.Visible = false;
            tr_Mixto3.Visible = false;
            tr_Mixto4.Visible = false;


            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = false;
            trPr_Area.Visible = false;

           


            trPr_Proveedor.Visible = false;
            trPR_RFC.Visible = false;
            trPR_Sector.Visible = false;

            rbtnPu.Checked = false;
            rbtPr.Checked = false;
            rbtnOtros.Checked = false;
            rbtnNinguno.Checked = false;

            rbtnPu.Enabled = true;
            rbtPr.Enabled = true;
            rbtnOtros.Enabled = true;
            rbtnNinguno.Enabled = true;

            pnlDependiente.Visible = true;




            blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
            oCAT_PAIS.select();
            cmbNID_PAIS_LABORAL_DEP.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);

            cmbNID_PAIS_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
            cmbNID_PAIS_LABORAL_DEP.SelectedIndex = 0;

            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedIndex = 0;


            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedIndex = 0;

            cmbCID_MUNICIPIO_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
            cmbCID_MUNICIPIO_LABORAL_DEP.SelectedIndex = 0;
        }



        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            try
            {
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                oDeclaracion.DECLARACION_DEPENDIENTESs.RemoveAt(e.Id);
                grd.Controls.Remove(((Item)grd.FindControl(String.Concat("grd", e.Id))));
                _oDeclaracion = oDeclaracion;
                AlertaSuperior.ShowSuccess("Se eliminó correctamente el dependiente");
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

        protected void txtVID_PRIMER_NIVEL_TextChanged(object sender, EventArgs e)
        {
            blld__l_CAT_SEGUNDO_NIVEL oSegundo = new blld__l_CAT_SEGUNDO_NIVEL();
            oSegundo.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(cmbVID_PRIMER_NIVEL.SelectedValue);
            oSegundo.select();
            cmbVID_SEGUNDO_NIVEL.DataBind(oSegundo.lista_CAT_SEGUNDO_NIVEL, CAT_SEGUNDO_NIVEL.Properties.VID_SEGUNDO_NIVEL, CAT_SEGUNDO_NIVEL.Properties.V_SEGUNDO_NIVEL);
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
            if(cbxOtroEmpleo.Checked==true)
            { this.DivOtroEmpleo.Visible = true; }
            else
            { this.DivOtroEmpleo.Visible = false; }
        }

        protected void cmbCARGO_NID_PAIS_OTRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEFederativa_Otra = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            if( cmbCARGO_NID_PAIS_OTRO.SelectedValue !="1" && cmbCARGO_NID_PAIS_OTRO.SelectedValue != "")
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

        protected void txtF_NACIMIENTO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtE_NOMBRE.Text) &&
                    !String.IsNullOrEmpty(txtE_PRIMER_A.Text) &&
                    !String.IsNullOrEmpty(txtF_NACIMIENTO.Text))
                    txtE_RFC.Text = RFC.CalcularRFC(txtE_NOMBRE.Text
                                                   , txtE_PRIMER_A.Text
                                                   , txtE_SEGUNDO_A.Text
                                                   , txtF_NACIMIENTO.Date(Pagina.esMX));
            }
            catch { }
        }

        protected void chk_L_MISMO_DOMICIO_DEP_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_MISMO_DOMICIO_DEP.Checked)
            {
                pnlDependiente.Visible = false;
            }
            else
            {
                pnlDependiente.Visible = true;
            }
        }

        protected void C_CODIGO_POSTAL_DEP_TextChanged(object sender, EventArgs e)
        {
            if (C_CODIGO_POSTAL_DEP.Text.Length == 5)
            {
                try
                {
                    blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(C_CODIGO_POSTAL_DEP.Text);
                    cmbNID_PAIS_LABORAL_DEP.SelectedValue = oCodigo.NID_PAIS.ToString();
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue = oCodigo.CID_ENTIDAD_FEDERATIVA;
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(sender, e);
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
                    cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue = oCodigo.CID_MUNICIPIO;
                    txtV_COLONIA_LABORAL.Text = oCodigo.V_COLONIA;

                }
                catch
                {
                }
            }
        }
        protected void cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbNID_PAIS_LABORAL_DEP.SelectedValue());
            oEntidadFederativa.select();
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(sender, e);
            //cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
        }
        protected void cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
            omun.NID_PAIS = new Declara_V2.IntegerFilter(cmbNID_PAIS_LABORAL_DEP.SelectedValue());
            omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue);
            omun.select();
            cmbCID_MUNICIPIO_LABORAL_DEP.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
            //cmbCID_MUNICIPIO_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
        }
        protected void rbtnPu_CheckedChanged(object sender, EventArgs e)
        {
            mostrarPublico();
        }

        protected void rbtPr_CheckedChanged(object sender, EventArgs e)
        {
            mostrarPrivado();
        }

        protected void rbtnOtros_CheckedChanged(object sender, EventArgs e)
        {
            mostrarOtros();
        }

        protected void rbtnNinguno_CheckedChanged(object sender, EventArgs e)
        {
            mostrarNinguno();
        }
        private void mostrarPublico()
        {
            tr_Mixto1.Visible = true;
            tr_Mixto2.Visible = true;
            tr_Mixto3.Visible = true;
            tr_Mixto3Priv.Visible = false;
            tr_Mixto4.Visible = true;

            trPR_RFC.Visible = false;
            trPR_Sector.Visible = false;
            trPr_Proveedor.Visible = false;

            trPU_nivel.Visible = true;
            trPU_Ambito.Visible = true;
            trPr_Funcion.Visible = true;
            trPr_Area.Visible = true;

            ltrPU_nivel.Text = "Nivel / Orden de Gobierno ";
            ltrPuPr_Puesto.Text = "Empleo, Cargo o Comisión";
            ltrPuPr_Area.Text = "Área de adscripción";
            ltrPuPr_Nombre.Text = "Nombre del ente público ";

            rbtnPu.Checked = true;
            rbtPr.Checked = false;

            rbtnOtros.Checked = false;
            rbtnNinguno.Checked = false;

            blld__l_CAT_AMBITO_PUBLICO catAmbitoPublico = new blld__l_CAT_AMBITO_PUBLICO();
            catAmbitoPublico.select();
            cmbPU_Ambito.DataBind(catAmbitoPublico.lista_CAT_AMBITO_PUBLICO, CAT_AMBITO_PUBLICO.Properties.NID_AMBITO_PUBLICO, CAT_AMBITO_PUBLICO.Properties.V_AMBITO_PUBLICO, false);
            cmbPU_Ambito.Items.Insert(0, new ListItem(string.Empty));
            cmbPU_Ambito.Items.Remove(cmbPU_Ambito.Items.FindByValue("1000"));

            blld__l_CAT_NIVEL_GOBIERNO catNivelGob = new blld__l_CAT_NIVEL_GOBIERNO();
            catNivelGob.select();
            cmbPU_nivel.DataBind(catNivelGob.lista_CAT_NIVEL_GOBIERNO, CAT_NIVEL_GOBIERNO.Properties.NID_NIVEL_GOBIERNO, CAT_NIVEL_GOBIERNO.Properties.V_NIVEL_GOBIERNO);
            cmbPU_nivel.Items.Insert(0, new ListItem(string.Empty));
            cmbPU_nivel.Items.Remove(cmbPU_nivel.Items.FindByValue("1000"));
        }
        private void mostrarPrivado()
        {
            tr_Mixto1.Visible = true;
            tr_Mixto2.Visible = true;
            tr_Mixto3.Visible = false;
            tr_Mixto3Priv.Visible = true;
            tr_Mixto4.Visible = true;

            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = false;
            trPr_Area.Visible = false;

            trPr_Proveedor.Visible = true;
            trPR_RFC.Visible = true;
            trPR_Sector.Visible = true;

            ltrPuPr_Puesto.Text = "Empleo o cargo";
            //ltrPuPr_Area.Text = "Área";
            ltrPuPr_Nombre.Text = "Nombre de la empresa, <br/> sociedad o asociacion";

            rbtnPu.Checked = false;
            rbtPr.Checked = true;

            rbtnOtros.Checked = false;
            rbtnNinguno.Checked = false;

            blld__l_CAT_SECTOR catSector = new blld__l_CAT_SECTOR();
            catSector.select();
            cmbPR_Sector.DataBind(catSector.lista_CAT_SECTOR, CAT_SECTOR.Properties.NID_SECTOR, CAT_SECTOR.Properties.V_SECTOR);
            cmbPR_Sector.Items.Insert(0, new ListItem(String.Empty));
            cmbPR_Sector.Items.Remove(cmbPR_Sector.Items.FindByValue("1000"));
            //cmbPR_Sector.Items.Remove(cmbPR_Sector.Items.FindByValue("17"));


        }

        private void mostrarOtros()
        {
            rbtnPu.Checked = false;
            rbtPr.Checked = false;
            rbtnOtros.Checked = true;
            rbtnNinguno.Checked = false;



            tr_Mixto1.Visible = true;
            tr_Mixto2.Visible = true;
            tr_Mixto3.Visible = false;
            tr_Mixto3Priv.Visible = true;
            tr_Mixto4.Visible = true;

            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = false;
            trPr_Area.Visible = false;

            trPr_Proveedor.Visible = true;
            trPR_RFC.Visible = true;
            trPR_Sector.Visible = true;

            ltrPuPr_Puesto.Text = "Empleo o cargo";
            //ltrPuPr_Area.Text = "Área";
            ltrPuPr_Nombre.Text = "Nombre de la empresa, <br/> sociedad o asociacion";


            blld__l_CAT_SECTOR catSector = new blld__l_CAT_SECTOR();
            catSector.select();
            cmbPR_Sector.DataBind(catSector.lista_CAT_SECTOR, CAT_SECTOR.Properties.NID_SECTOR, CAT_SECTOR.Properties.V_SECTOR);
            cmbPR_Sector.Items.Insert(0, new ListItem(String.Empty));
            cmbPR_Sector.Items.Remove(cmbPR_Sector.Items.FindByValue("1000"));
            cmbPR_Sector.SelectedIndex = 17;
        }


        private void mostrarNinguno()
        {
            rbtnPu.Checked = false;
            rbtPr.Checked = false;
            rbtnOtros.Checked = false;
            rbtnNinguno.Checked = true;

            tr_Mixto1.Visible = false;
            tr_Mixto2.Visible = false;
            tr_Mixto3.Visible = false;
            tr_Mixto4.Visible = false;

            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = false;
            trPr_Area.Visible = false;
            trPR_RFC.Visible = false;
            trPR_Sector.Visible = false;
        }
        protected void btnAgregarDatosPareja_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
            oCAT_PAIS.select();
            cmbNID_PAIS_LABORAL_DEP.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
            cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(cmbNID_PAIS_LABORAL_DEP, null);
            SelectDependiente();
            labTipoRelacion.Text = "Relación con el declarante";
            lEditar = false;

            mppPareja.Show(true);
            mppPareja.HeaderText = "Dar de alta datos del dependiente económico";
            limpia();
            //mdlDependiente.Show(true);
            //mdlDependiente.HeaderText = "Dar de alta dependiente";
            //ctrlDependiente1.limpia();
        }

        protected void btnCerrarDatosPareja_Click(object sender, EventArgs e)
        {
            mppPareja.Hide();
            limpia();
        }

        protected void btnGuarDatosPareja_Click(object sender, EventArgs e)
        {

            if (lEditar)
            {
                EditaPareja();
                mppPareja.Hide();
                 String msg = "Se actualizaron correctamente los datos de la pareja";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                InsertaPareja();
                mppPareja.Hide();
                String msg = "Se agregaron correctamente los datos de la pareja";
                AlertaSuperior.ShowSuccess(msg);
            }

            limpia();

           
        }
        internal void SelectDependiente()
        {
            try
            {
               // trPareja.Visible = false;
                labTipoRelacion.Text = "Relación con el declarante";
                //lblDomicilio.Text = "¿El domicilio del dependiente <br/> es el mismo que el del declarante?";

                blld__l_CAT_TIPO_DEPENDIENTES oDep = new blld__l_CAT_TIPO_DEPENDIENTES();
                oDep.OrderByCriterios.Add(new Declara_V2.Order(CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE));
                oDep.select();
                var list = oDep.lista_CAT_TIPO_DEPENDIENTES.Where(p => p.L_PAREJA == true).ToList();

                cmbNID_TIPO_DEPENDIENTE_DEP.DataBind(list, CAT_TIPO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE, CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE);
                cmbNID_TIPO_DEPENDIENTE_DEP.Items.Insert(0, new ListItem(String.Empty, "0"));
            }
            catch (Exception ex)
            {


            }
        }

        internal void EligeDependiente()
        {
            try
            {
               // trPareja.Visible = false;
                labTipoRelacion.Text = "Parentesco o relación con el declarante";
                //lblDomicilio.Text = "¿El domicilio del dependiente <br/> es el mismo que el del declarante?";

                blld__l_CAT_TIPO_DEPENDIENTES oDep = new blld__l_CAT_TIPO_DEPENDIENTES();
                oDep.OrderByCriterios.Add(new Declara_V2.Order(CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE));
                oDep.select();
                var list = oDep.lista_CAT_TIPO_DEPENDIENTES.Where(p => p.L_PAREJA == false).ToList();

                cmbNID_TIPO_DEPENDIENTE_DEP.DataBind(list, CAT_TIPO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE, CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE);
                cmbNID_TIPO_DEPENDIENTE_DEP.Items.Insert(0, new ListItem(String.Empty, "0"));
            }
            catch (Exception ex)
            {


            }
        }

        private void InsertaPareja()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            try
            {
               
                    oDeclaracion.Add_DECLARACION_DEPENDIENTESs(Convert.ToInt32(cmbNID_TIPO_DEPENDIENTE_DEP.SelectedValue)
                                                               , txtE_NOMBRE.Text
                                                               , txtE_PRIMER_A.Text
                                                               , txtE_SEGUNDO_A.Text
                                                               , txtF_NACIMIENTO.Date(Pagina.esMX)
                                                               , txtE_RFC.Text
                                                               , L_DEPENDE_ECO_P

                                                               //,  ctrlDependiente1.L_ACTIVO
                                                               , L_CIUDADANO_EXTRANJERO_P
                                                               , txtCurp.Text
                                                               , NID_ACTIVIDAD_LABORAL_P
                                                               , txtObservaPareja.Text
                                                               , txtObservaPareja.Text
                                                               , txtObservaPareja.Text
                                                               //,  ctrlDependiente1.NID_ESTADO_TESTADO
                                                               , L_MISMO_DOMICILIO_DECLARANTE_P

                                                               //Domicilio
                                                               , C_CODIGO_POSTAL_DEP.Text
                                                               , Convert.ToInt32(cmbNID_PAIS_LABORAL_DEP.SelectedValue)
                                                               , cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue
                                                               , cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue
                                                               , txtColoniaDep.Text
                                                               , String.Concat(txtCalleDep.Text, '|', txtNumExtDep.Text, '|', txtNumInteriorDep.Text)

                                                               //Publico
                                                               , NID_AMBITO_SECTOR_P
                                                               ,NID_NIVEL_GOBIERNO_P
                                                               ,NID_AMBITO_PUBLICO_P
                                                               , txtNombre.Text
                                                               , txtArea.Text
                                                               , txtPuesto.Text
                                                               , txtFuncion.Text
                                                               , Convert.ToDecimal(moneytxtM_Salario.Text.Replace("$", "").Replace(",", ""))
                                                               , txtF_FechaIngreso.Date(Pagina.esMX)

                                                               //Privado 
                                                               , txtNombre.Text
                                                               , txtRFC.Text
                                                               , NID_SECTOR_P
                                                               , L_PROVEEDOR_P
                                                               , true
                                                               );

                    blld_DECLARACION_DEPENDIENTES o = oDeclaracion.DECLARACION_DEPENDIENTESs.Last();
                    UserControl item = (UserControl)Page.LoadControl("item.ascx");
                    ((Item)item).Id = oDeclaracion.DECLARACION_DEPENDIENTESs.Count() + 1;
                    ((Item)item).ID = String.Concat("grdPareja", oDeclaracion.DECLARACION_DEPENDIENTESs.Count() + 1);
                    ((Item)item).TextoPrincipal = o.V_TIPO_DEPENDIENTE;
                    ((Item)item).TextoSecundario = o.V_NOMBRE_COMPLETO;
                    ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", o.NID_TIPO_DEPENDIENTE, ".png");
                    ((Item)item).Editar += OnEditar;
                    ((Item)item).Eliminar += OnEliminar;
                if (o.L_PAREJA == true)
                    grdPareja.Controls.AddAt(grdPareja.Controls.Count - 3, item);
                    AlertaSuperior.ShowSuccess("Se agregaron correctamente los datos de la pareja");
                mppPareja.Hide();
               
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
        private void EditaPareja()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice=0;
            switch (SubSeccionActiva)
            {
                case SubSecciones.DependienteEconomicos:
                     Indice = IndiceItemSeleccionadoDep;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].L_PAREJA = false;
                    break;
                case SubSecciones.DomicilioLaboral:
                     Indice = IndiceItemSeleccionado;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].L_PAREJA = true;
                    break;
            }

           
          
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].NID_TIPO_DEPENDIENTE = Convert.ToInt32(cmbNID_TIPO_DEPENDIENTE_DEP.SelectedValue());
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].E_NOMBRE = txtE_NOMBRE.Text;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].E_PRIMER_A = txtE_PRIMER_A.Text;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].E_SEGUNDO_A = txtE_SEGUNDO_A.Text;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].F_NACIMIENTO = txtF_NACIMIENTO.Date(Pagina.esMX);
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].E_RFC = txtE_RFC.Text;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].L_DEPENDE_ECO = cbxL_DEPENDE_ECO.Checked;
            //oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].L_PAREJA =true;
            //,  ctrlDependiente1.L_ACTIVO
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].L_CIUDADANO_EXTRANJERO = cbxEstrangero.Checked;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].E_CURP = txtCurp.Text;

            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].NID_ACTIVIDAD_LABORAL = NID_ACTIVIDAD_LABORAL_P;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].E_OBSERVACIONES = txtObservaPareja.Text;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].E_OBSERVACIONES_MARCADO = txtObservaPareja.Text;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].V_OBSERVACIONES_TESTADO = txtObservaPareja.Text;
            //,  ctrlDependiente1.NID_ESTADO_TESTADO
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].L_MISMO_DOMICILIO_DECLARANTE = L_MISMO_DOMICILIO_DECLARANTE_P;
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].update();

            //Domicilio
            oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DomicilioUpdate(C_CODIGO_POSTAL_DEP.Text
            ,Convert.ToInt32( cmbNID_PAIS_LABORAL_DEP.SelectedValue())
            , cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue
            , cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue
            , txtColoniaDep.Text
            , String.Concat(txtCalleDep.Text, '|', txtNumExtDep.Text, '|', txtNumInteriorDep.Text));
           

            //oDeclaracion.Add_DECLARACION_DEPENDIENTESs


            //PRIVADO
            if (NID_ACTIVIDAD_LABORAL_P == 1)
            {
                try
                {
                    blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].NID_DEPENDIENTE);

                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = txtNombre.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = txtPuesto.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = txtRFC.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = Convert.ToDecimal( moneytxtM_Salario.Text.Replace("$", "").Replace(",", ""));
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR =NID_SECTOR_P;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = L_PROVEEDOR_P;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO = txtF_FechaIngresoPriv.Date(Pagina.esMX);
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.update();
                }
                catch (Exception ex)
                {
                    blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new
                        blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE,
                        oDeclaracion.NID_DECLARACION, oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].NID_DEPENDIENTE,  txtNombre.Text, txtPuesto.Text, txtRFC.Text,
                        DateTime.Now.Date, NID_SECTOR_P, Convert.ToDecimal(moneytxtM_Salario.Text.Replace("$", "").Replace(",", "")), L_PROVEEDOR_P);

                 //   blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION
                 //       ,
                 // txtNombre.Text,
                 // txtPuesto.Text, txtRFC.Text,
                 //DateTime.Now.Date,
                 //   NID_SECTOR_P, Convert.ToDecimal(moneytxtM_Salario.Text.Replace("$", "").Replace(",", "")),
                 //    L_PROVEEDOR_P
                 //      );
                }
            }


            //Publico
            if (NID_ACTIVIDAD_LABORAL_P == 2)
            {

                try
                {
                    blld_DECLARACION_DEPENDIENTES_PUBLICO oDep = new blld_DECLARACION_DEPENDIENTES_PUBLICO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].NID_DEPENDIENTE);



                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR = NID_AMBITO_SECTOR_P;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO =NID_NIVEL_GOBIERNO_P;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO =NID_AMBITO_PUBLICO_P;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE = txtNombre.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION = txtArea.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO = txtPuesto.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL = txtFuncion.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL = Convert.ToDecimal(moneytxtM_Salario.Text);
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO = txtF_FechaIngreso.Date(Pagina.esMX);
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PUBLICO.update();


                }
                catch (Exception)
                {
                    // public blld_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE,
                    //Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO,
                    //String V_FUNCION_PRINCIPAL, Decimal M_SALARIO_MENSUAL, DateTime F_INGRESO)
                    blld_DECLARACION_DEPENDIENTES_PUBLICO oDep = new
                        blld_DECLARACION_DEPENDIENTES_PUBLICO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION
                                                               , oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].NID_DEPENDIENTE
                                                               , NID_AMBITO_SECTOR_P, NID_NIVEL_GOBIERNO_P, NID_AMBITO_SECTOR_P, txtNombre.Text, txtArea.Text, txtPuesto.Text, txtFuncion.Text
                                                               , Convert.ToDecimal(moneytxtM_Salario.Text.Replace("$", "").Replace(",", "")), txtF_FechaIngreso.Date(Pagina.esMX));
                    //DECLARACION_DEPENDIENTES_PUBLICO oDep = new DECLARACION_DEPENDIENTES_PUBLICO();
                    //  blld_DECLARACION_DEPENDIENTES_PUBLICO oDep = new blld_DECLARACION_DEPENDIENTES_PUBLICO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION
                    //      ,
                    //       NID_AMBITO_SECTOR_P,
                    //    NID_NIVEL_GOBIERNO_P,
                    //    NID_AMBITO_PUBLICO_P,
                    //   txtNombre.Text,
                    //   txtArea.Text,
                    //  txtPuesto.Text,
                    //    txtFuncion.Text,
                    //   Convert.ToDecimal(moneytxtM_Salario.Text),
                    //txtF_FechaIngreso.Date(Pagina.esMX)

                    //     );




                }
            }


            //PRIVADO
            if (NID_ACTIVIDAD_LABORAL_P == 3)
            {
                try
                {
                    blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION, oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].NID_DEPENDIENTE);

                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = txtNombre.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = txtPuesto.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = txtRFC.Text;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = Convert.ToDecimal(moneytxtM_Salario.Text);
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR = NID_SECTOR_P;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = L_PROVEEDOR_P;
                    oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].DECLARACION_DEPENDIENTES_PRIVADO.update();

                }
                catch (Exception ex)
                {

                    blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new
                                           blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE,
                                           oDeclaracion.NID_DECLARACION, oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].NID_DEPENDIENTE, txtNombre.Text, txtPuesto.Text, txtRFC.Text,
                                           DateTime.Now.Date, NID_SECTOR_P, Convert.ToDecimal(moneytxtM_Salario.Text.Replace("$", "").Replace(",", "")), L_PROVEEDOR_P);
                    //    blld_DECLARACION_DEPENDIENTES_PRIVADO oDep = new blld_DECLARACION_DEPENDIENTES_PRIVADO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_DECLARACION
                    //        ,
                    //txtNombre.Text,
                    // "", txtRFC.Text,
                    // DateTime.Now.Date,
                    //     NID_SECTOR_P, 0m,
                    //      L_PROVEEDOR_P
                    //       );
                }
            }


            //oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].update();

            switch (SubSeccionActiva)
            {
                case SubSecciones.DependienteEconomicos:
                    ((Item)grd.FindControl(String.Concat("grd", Indice))).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", cmbNID_TIPO_DEPENDIENTE_DEP.SelectedValue(), ".png");
                    ((Item)grd.FindControl(String.Concat("grd", Indice))).TextoPrincipal = oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].V_TIPO_DEPENDIENTE;
                    ((Item)grd.FindControl(String.Concat("grd", Indice))).TextoSecundario = oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].V_NOMBRE_COMPLETO;
                    //AlertaInferior.ShowSuccess("Se actualizaron correctamente los datos del dependiente");
                    AlertaSuperior.ShowSuccess("Se actualizaron correctamente los datos del dependiente");
                    break;
                case SubSecciones.DomicilioLaboral:
                

                    ((Item)grd.FindControl(String.Concat("grdPareja", Indice))).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", cmbNID_TIPO_DEPENDIENTE_DEP.SelectedValue(), ".png");
                    ((Item)grd.FindControl(String.Concat("grdPareja", Indice))).TextoPrincipal = oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].V_TIPO_DEPENDIENTE;
                    ((Item)grd.FindControl(String.Concat("grdPareja", Indice))).TextoSecundario = oDeclaracion.DECLARACION_DEPENDIENTESs[Indice].V_NOMBRE_COMPLETO;
                    //AlertaInferior.ShowSuccess("Se actualizaron correctamente los datos del dependiente");
                    AlertaSuperior.ShowSuccess("Se actualizaron correctamente los datos de la pareja");
                    break;
            }
           

        }

        public int NID_ACTIVIDAD_LABORAL_P//NID_ACTIVIDAD_LABORAL
        {
            get
            {
                int op = 0;

                if (rbtPr.Checked)
                    op = 1; //privado 

                if (rbtnPu.Checked)
                    op = 2; //publico 

                if (rbtnOtros.Checked)
                    op = 3; //Otros 

                if (rbtnNinguno.Checked)
                    op = 4; //Ningunos 

                return op;
            }
            set
            {
                int val = value;
                if (val == 1)
                {
                    rbtPr.Checked = true;
                    rbtnPu.Checked = false;
                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                    mostrarPrivado();
                }
                if (val == 2)
                {
                    rbtPr.Checked = false;
                    rbtnPu.Checked = true;
                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                    mostrarPublico();
                }


                if (val == 3)
                {
                    rbtPr.Checked = false;
                    rbtnPu.Checked = false;
                    rbtnOtros.Checked = true;
                    rbtnNinguno.Checked = false;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                    mostrarOtros();
                }

                if (val == 4)
                {
                    rbtPr.Checked = false;
                    rbtnPu.Checked = false;
                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = true;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                    mostrarNinguno();
                }
            }
        }

        public int NID_AMBITO_SECTOR_P//NID_ACTIVIDAD_LABORAL
        {
            get
            {
                int op = 0;

                if (rbtPr.Checked)
                    op = 1; //publico

                if (rbtnPu.Checked)
                    op = 2; //publico

                if (rbtnOtros.Checked)
                    op = 3; //Otro

                if (rbtnNinguno.Checked)
                    op = 4; //Ninguno

                return op;
            }
            set
            {
                int val = value;

                if (val == 1)
                {
                    rbtnPu.Checked = true;
                    rbtPr.Checked = false;
                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;


                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;

                    mostrarPublico();

                }
                if (val == 2)
                {
                    rbtnPu.Checked = false;
                    rbtPr.Checked = true;

                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;

                    mostrarPrivado();
                }
                if (val == 3)
                {
                    rbtnPu.Checked = false;
                    rbtPr.Checked = false;

                    rbtnOtros.Checked = true;
                    rbtnNinguno.Checked = false;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;

                    mostrarOtros();
                }
                if (val == 4)
                {
                    rbtnPu.Checked = false;
                    rbtPr.Checked = false;

                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;

                    mostrarNinguno();
                }
            }
        }

        public Boolean L_DEPENDE_ECO_P
        {
            get
            {
                return cbxL_DEPENDE_ECO.Checked;
               
            }
            set
            {
                cbxL_DEPENDE_ECO.Checked = value;
            }
        }




        public Boolean L_PROVEEDOR_P
        {
            get
            {
                return cbxProveedor.Checked;
            }
            set
            {
                cbxProveedor.Checked = value;
            }
        }



        public Boolean L_MISMO_DOMICILIO_DECLARANTE_P
        {
            get
            {
                return chk_L_MISMO_DOMICIO_DEP.Checked;
            }
            set
            {
                chk_L_MISMO_DOMICIO_DEP.Checked = value;
            }
        }

        public int NID_SECTOR_P
        {
            //get => cmbPR_Sector.SelectedIndex;
            //set => cmbPR_Sector.SelectedIndex = value;
            get
            {
                if (cmbPR_Sector.SelectedValue == "")
                    return NID_SECTOR_P = 0;
                else
                    return cmbPR_Sector.SelectedIndex;
            }

            set
            {
                if (value.ToString() == "")
                    NID_SECTOR_P = value;
                else
                    try { cmbPR_Sector.SelectedIndex = value; } catch { }
            }
        }

        public Boolean L_CIUDADANO_EXTRANJERO_P
        {
            get
            {
                return cbxEstrangero.Checked;
            }
            set
            {
                cbxEstrangero.Checked = true;
            }
        }
        public Int32 NID_NIVEL_GOBIERNO_P
        {
            get
            {
                if (cmbPU_nivel.SelectedValue() == 0)
                    return NID_NIVEL_GOBIERNO_P = 1000;
                else
                    return cmbPU_nivel.SelectedValue();
            }

            set
            {
                if (value.ToString() == "")
                    NID_NIVEL_GOBIERNO_P = 1000;
                else
                    try { cmbPU_nivel.SelectedValue = value.ToString(); } catch { }
            }
        }

        public int NID_AMBITO_PUBLICO_P
        {
            //get => cmbPU_Ambito.SelectedIndex;
            //set => cmbPU_Ambito.SelectedIndex = value;

            get
            {
                if (cmbPU_Ambito.SelectedValue == "")
                    return NID_AMBITO_PUBLICO_P = 0;
                else
                    return cmbPU_nivel.SelectedIndex;
            }

            set
            {
                if (value.ToString() == "")
                    NID_AMBITO_PUBLICO_P = 0;
                else
                    try { cmbPU_Ambito.SelectedIndex = value; } catch { }
            }
        }
    }
}