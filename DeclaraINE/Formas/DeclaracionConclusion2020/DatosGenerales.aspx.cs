using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace DeclaraINE.Formas.DeclaracionInicial
{
    public partial class DatosGenerales : Pagina, IDeclaracionInicial
    {
        internal SubSecciones SubSeccionActiva
        {
            get => (SubSecciones)ViewState["SubSeccionActiva"];
            set => ViewState["SubSeccionActiva"] = value;
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
            DatosPersonales,
            DomicilioParticular,
            DomicilioLaboral,
            Cargo,
            DependienteEconomicos,
            DatosCurriculares,
        }

        internal enum Paneles
        {
            pnlDatosPersonales,
            pnlDomicilioParticular,
            pnlDomicilioLaboral,
            pnlCargo,
            pnlDependientes
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            _oDeclaracion = oDeclaracion;

            blld_DECLARACION_DEPENDIENTES o;

            for (int x = 0; x < oDeclaracion.DECLARACION_DEPENDIENTESs.Count; x++)
            {
                o = oDeclaracion.DECLARACION_DEPENDIENTESs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("grd", x);
                ((Item)item).TextoPrincipal = o.V_TIPO_DEPENDIENTE;
                ((Item)item).TextoSecundario = o.V_NOMBRE_COMPLETO;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_DEPENDIENTE/", o.NID_TIPO_DEPENDIENTE, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grd.Controls.AddAt(0 + x, item);
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
                cmbPaisDomimicioParticular.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                //cmbPaisDomimicioParticular.SelectedValue = "1";
                cmbPaisDomimicioParticular_SelectedIndexChanged(sender, e);

                cmbNacionalidad.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_NACIONALIDAD_M, false);
                //cmbnIdPaisNacimiento.SelectedValue = "1";

                cmbEstadoCivil.DataBinder<blld__l_CAT_ESTADO_CIVIL>(new blld__l_CAT_ESTADO_CIVIL(), CAT_ESTADO_CIVIL.Properties.NID_ESTADO_CIVIL, CAT_ESTADO_CIVIL.Properties.V_ESTADO_CIVIL, false);
                cmbRegimenMatrimonial.DataBinder<blld__l_CAT_REGIMEN_MATRIMONIAL>(new blld__l_CAT_REGIMEN_MATRIMONIAL(), CAT_REGIMEN_MATRIMONIAL.Properties.NID_REGIMEN_MATRIMONIAL, CAT_REGIMEN_MATRIMONIAL.Properties.V_REGIMEN_MATRIMONIAL, false);

                cmbPaisDomimicioParticular.Items.Insert(0, new ListItem(String.Empty));
                cmbnIdPaisNacimiento.Items.Insert(0, new ListItem(String.Empty));
                cmbNacionalidad.Items.Insert(0, new ListItem(String.Empty));
                cmbEstadoCivil.Items.Insert(0, new ListItem(String.Empty));
                cmbRegimenMatrimonial.Items.Insert(0, new ListItem(String.Empty));

                cmbPaisDomimicioParticular.SelectedIndex = 0;
                cmbnIdPaisNacimiento.SelectedIndex = 0;
                cmbNacionalidad.SelectedIndex = 0;
                cmbEstadoCivil.SelectedIndex = 0;
                cmbRegimenMatrimonial.SelectedIndex = 0;
                // SME-NF_F

                if (ControlDeNavegacion != null)
                {
                    ViewState["SubSeccionActiva"] = ((SubSecciones)ControlDeNavegacion);
                    this.SubSeccionActiva = ((SubSecciones)ControlDeNavegacion);
                    lBanderaActualizaAnterior = false;
                    Siguiente();
                    ControlDeNavegacion = null;
                }
                else
                {
                    ((Button)Master.FindControl("btnAnterior")).Visible = false;
                    ViewState["SubSeccionActiva"] = SubSecciones.DatosPersonales;
                    lBanderaActualizaAnterior = true;
                    ltrSubTitulo.Text = "Datos Generales - Datos Personales";
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
                        throw ex;
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
                    ltrSubTitulo.Text = "Datos Generales - Datos Personales";
                    ((Button)Master.FindControl("btnAnterior")).Visible = false;
                    pnlDatosPersonales.Visible = true;
                    pnlDomicilioParticular.Visible = false;
                    pnlCargo.Visible = false;
                    pnlDomicilioLaboral.Visible = false;
                    pnlDependientes.Visible = false;
                    SubSeccionActiva = SubSecciones.DatosPersonales;
                    break;
                case SubSecciones.Cargo:
                    ltrSubTitulo.Text = "Datos Generales - Domicilio Particular";
                    pnlDatosPersonales.Visible = false;
                    pnlDomicilioParticular.Visible = true;
                    pnlCargo.Visible = false;
                    pnlDomicilioLaboral.Visible = false;
                    pnlDependientes.Visible = false;
                    SubSeccionActiva = SubSecciones.DomicilioParticular;
                    break;
                case SubSecciones.DomicilioLaboral:
                    ltrSubTitulo.Text = "Datos Generales – Cargo Actual";
                    pnlDatosPersonales.Visible = false;
                    pnlDomicilioParticular.Visible = false;
                    pnlCargo.Visible = true;
                    pnlDomicilioLaboral.Visible = false;
                    pnlDependientes.Visible = false;
                    SubSeccionActiva = SubSecciones.Cargo;
                    break;
                case SubSecciones.DependienteEconomicos:
                    ltrSubTitulo.Text = "Datos Generales - Domicilio Laboral";
                    pnlDatosPersonales.Visible = false;
                    pnlDomicilioParticular.Visible = false;
                    pnlCargo.Visible = false;
                    pnlDomicilioLaboral.Visible = true;
                    pnlDependientes.Visible = false;
                    SubSeccionActiva = SubSecciones.DomicilioLaboral;
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
                            ltrSubTitulo.Text = "Datos Generales - Domicilio Particular";
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
                                cmbPaisDomimicioParticular.SelectedValue = oDeclaracion.DECLARACION_DOM_PARTICULAR.NID_PAIS.ToString();
                                cmbPaisDomimicioParticular_SelectedIndexChanged(cmbPaisDomimicioParticular, null);
                                cmbEntidadFederativaDomicilioParticular.SelectedValue = oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA;
                                cmbEntidadFederativaDomicilioParticular_SelectedIndexChanged(cmbEntidadFederativaDomicilioParticular, null);
                                cmbMunicipioDomicilioParticular.SelectedValue = oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO;
                                txtColoniaParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_COLONIA;
                                txtCalleDomParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CALLE;
                                txtNumeroExteriorDomParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_NUMERO_EXTERNO;
                                txtNumeroInteriorDomParticular.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_NUMERO_INTERNO;
                                txtV_TEL_PARTICULAR.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR;
                                txtV_TEL_CELULAR.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR;
                                txtV_CORREO_PERSONAL.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO;
                                txtE_OBSERVACIONES.Text = oDeclaracion.DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES;
                            }
                            catch (Exception ex)
                            {
                                if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                {
                                    txtcCodigoPostal.Text = String.Empty;
                                    cmbPaisDomimicioParticular.SelectedIndex = 0;
                                    cmbEntidadFederativaDomicilioParticular.SelectedIndex = 0;
                                    cmbMunicipioDomicilioParticular.SelectedIndex = 0;
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
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.NID_PAIS = cmbPaisDomimicioParticular.SelectedValue();
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA = cmbEntidadFederativaDomicilioParticular.SelectedValue;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO = cmbMunicipioDomicilioParticular.SelectedValue;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_COLONIA = txtColoniaParticular.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CALLE = txtCalleDomParticular.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_NUMERO_EXTERNO = txtNumeroExteriorDomParticular.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_NUMERO_INTERNO = txtNumeroInteriorDomParticular.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO = txtV_CORREO_PERSONAL.Text;
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR = String.Concat(txtV_TEL_PARTICULAR.Text);
                                oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR = txtV_TEL_CELULAR.Text;
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
                                                                                                                          , cmbPaisDomimicioParticular.SelectedValue()
                                                                                                                          , cmbEntidadFederativaDomicilioParticular.SelectedValue
                                                                                                                          , cmbMunicipioDomicilioParticular.SelectedValue
                                                                                                                          , txtColoniaParticular.Text
                                                                                                                          , txtCalleDomParticular.Text
                                                                                                                          , txtNumeroExteriorDomParticular.Text
                                                                                                                          , txtNumeroInteriorDomParticular.Text
                                                                                                                          , txtV_CORREO_PERSONAL.Text
                                                                                                                          , String.Concat(txtV_TEL_PARTICULAR.Text)
                                                                                                                          , txtV_TEL_CELULAR.Text
                                                                                                                          , txtE_OBSERVACIONES.Text);
                                }
                                else
                                {
                                    MsgBox.ShowDanger(ex.Message);
                                    lBanderaPasa = false;
                                }
                            }
                            lBanderaActualizaAnterior = true;
                            marcaApartado(ref oDeclaracion, 3);
                        }
                        if (lBanderaPasa)
                        {
                            ltrSubTitulo.Text = "Datos Generales – Cargo Actual";
                            pnlDatosPersonales.Visible = false;
                            pnlDomicilioParticular.Visible = false;
                            pnlCargo.Visible = true;
                            pnlDomicilioLaboral.Visible = false;
                            pnlDependientes.Visible = false;
                            SubSeccionActiva = SubSecciones.Cargo;

                            try
                            {
                                cmbVID_CLAVEPUESTO.SelectedValue = oDeclaracion.DECLARACION_CARGO.NID_PUESTO.ToString();
                                cmbVID_CLAVEPUESTO_SelectedIndexChanged(cmbVID_CLAVEPUESTO, null);
                                cmbVID_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.NID_PUESTO.ToString();
                                cmbVID_NIVEL_SelectedIndexChanged(cmbVID_NIVEL, null);
                                txt_DENOMINACION_CARGO.Text = oDeclaracion.DECLARACION_CARGO.V_DENOMINACION;
                                cmbVID_PRIMER_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.VID_PRIMER_NIVEL;
                                txtVID_PRIMER_NIVEL_TextChanged(cmbVID_PRIMER_NIVEL, null);
                                cmbVID_SEGUNDO_NIVEL.SelectedValue = oDeclaracion.DECLARACION_CARGO.VID_SEGUNDO_NIVEL;
                                txtF_POSESION.Text = oDeclaracion.DECLARACION_CARGO.F_POSESION.ToString(strFormatoFecha);
                                txtF_INGRESO.Text = oDeclaracion.DECLARACION_CARGO.F_INICIO.ToString(strFormatoFecha);
                            }
                            catch (Exception ex)
                            {
                                if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                {
                                    txtcCodigoPostal.Text = String.Empty;
                                    cmbPaisDomimicioParticular.SelectedIndex = 0;
                                    cmbEntidadFederativaDomicilioParticular.SelectedIndex = 0;
                                    cmbMunicipioDomicilioParticular.SelectedIndex = 0;
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
                                    oDeclaracion.DECLARACION_CARGO.F_POSESION = txtF_POSESION.Date(Pagina.esMX);
                                    oDeclaracion.DECLARACION_CARGO.F_INICIO = txtF_INGRESO.Date(Pagina.esMX);
                                    oDeclaracion.DECLARACION_CARGO.update();

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
                                                                                                   , Convert.ToDateTime(txtF_INGRESO.Text)
                                                                                                   , cmbVID_PRIMER_NIVEL.SelectedValue
                                                                                                   , cmbVID_SEGUNDO_NIVEL.SelectedValue);
                                        foreach (GridViewRow row in grdPreguntas.Rows)
                                        {
                                            NID_RESTRICCION = Convert.ToInt32(((HiddenField)row.FindControl("NID_RESTRICCION")).Value);
                                            L_RESPUESTA = ((SioNo)row.FindControl("cbx")).Checked;
                                            oDeclaracion.DECLARACION_RESTRICCIONESs.Where(p => p.NID_RESTRICCION == NID_RESTRICCION).First().L_RESPUESTA = L_RESPUESTA;
                                            oDeclaracion.DECLARACION_RESTRICCIONESs.Where(p => p.NID_RESTRICCION == NID_RESTRICCION).First().update();
                                        }
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

                                blld_DECLARACION_CARGO oTempCargo = new blld_DECLARACION_CARGO(oDeclaracion.VID_NOMBRE
                                                                                                                  , oDeclaracion.VID_FECHA
                                                                                                                  , oDeclaracion.VID_HOMOCLAVE
                                                                                                                  , oDeclaracion.NID_DECLARACION);

                                ltrSubTitulo.Text = "Datos Generales - Domicilio Laboral";
                                pnlDatosPersonales.Visible = false;
                                pnlDomicilioParticular.Visible = false;
                                pnlCargo.Visible = false;
                                pnlDomicilioLaboral.Visible = true;
                                pnlDependientes.Visible = false;
                                SubSeccionActiva = SubSecciones.DomicilioLaboral;
                                try
                                {
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

                                }
                                catch (Exception ex)
                                {
                                    if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                    {
                                        C_CODIGO_POSTAL.Text = String.Empty;
                                        cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedIndex = 0;
                                        cmbCID_MUNICIPIO_LABORAL.SelectedIndex = 0;
                                        txtV_COLONIA_LABORAL.Text = String.Empty;
                                        txtV_DOMICILIO_LABORAL.Text = String.Empty;

                                        txtV_TELEFONO_LABORAL1.Text = String.Empty;
                                        txtV_TELEFONO_LABORAL2.Text = String.Empty;
                                        try
                                        {
                                            txtV_CORREO_LABORAL.Text = oUsuario.USUARIO_CORREOs.Where(p => p.L_PRINCIPAL && p.L_ACTIVO && p.L_CONFIRMADO).First().V_CORREO;
                                        }
                                        catch
                                        {
                                            txtV_CORREO_LABORAL.Text = String.Empty;
                                        }
                                    }
                                    else throw ex;
                                }
                            }


                        }
                        catch (Exception)
                        {
                            MsgBox.ShowWarning("Debe finalizar este apartado para continuar con el siguiente apartado 'Domicilio Laboral'");
                            SubSeccionActiva = SubSecciones.DomicilioParticular;
                            lBanderaActualizaAnterior = false;
                            lBanderaPasa = true;
                            Siguiente();
                        }
                        break;
                    case SubSecciones.DomicilioLaboral:
                        if (lBanderaActualizaAnterior)
                        {
                            try
                            {

                                oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL = C_CODIGO_POSTAL.Text;
                                oDeclaracion.DECLARACION_DOM_LABORAL.NID_PAIS = cmbNID_PAIS_LABORAL.SelectedValue();
                                oDeclaracion.DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA = cmbCID_ENTIDAD_FEDERATIVA_LABORAL.SelectedValue;
                                oDeclaracion.DECLARACION_DOM_LABORAL.CID_MUNICIPIO = cmbCID_MUNICIPIO_LABORAL.SelectedValue;
                                oDeclaracion.DECLARACION_DOM_LABORAL.V_COLONIA = txtV_COLONIA_LABORAL.Text;
                                oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO = String.Concat(txtV_DOMICILIO_LABORAL.Text, '|', txtNumExteriorDOMICILIO_LABORAL.Text, '|', txtNumInteriorDOMICILIO_LABORAL.Text);
                                oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL = txtV_CORREO_LABORAL.Text;
                                oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL = txtV_TELEFONO_LABORAL1.Text;
                                oDeclaracion.DECLARACION_DOM_LABORAL.update();
                                oDeclaracion.DECLARACION_CARGO.E_OBSERVACIONES = txtObservaciones.Text;
                                oDeclaracion.DECLARACION_CARGO.update();
                            }
                            catch (Exception ex)
                            {
                                //MsgBox.ShowWarning("Debe finalizar el apartado 'Cargo' para continuar con el guardado de Domicilio Laboral");

                                if (ex is Declara_V2.Exceptions.RowNotFoundException)
                                {
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
                                }
                                else
                                {
                                    MsgBox.ShowDanger(ex.Message);
                                    lBanderaPasa = false;
                                }
                            }
                            lBanderaActualizaAnterior = true;
                            marcaApartado(ref oDeclaracion, 5);
                        }
                        if (lBanderaPasa)
                        {
                            ltrSubTitulo.Text = "Datos Generales - Cónyuge, concubina o concubinario y/ o dependientes económicos";
                            pnlDatosPersonales.Visible = false;
                            pnlDomicilioParticular.Visible = false;
                            pnlCargo.Visible = false;
                            pnlDomicilioLaboral.Visible = false;
                            pnlDependientes.Visible = true;
                            SubSeccionActiva = SubSecciones.DependienteEconomicos;
                            if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                                QstBoxDep.Ask("¿Cuenta con dependientes económicos y/o cónyuge que desee registrar?");
                        }
                        break;
                    case SubSecciones.DependienteEconomicos:
                        if (oDeclaracion.DECLARACION_DEPENDIENTESs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                        { }
                        else
                        {
                            marcaApartado(ref oDeclaracion, 6);
                        }
                        if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
                        {
                            MsgBox.ShowWarning("Debe finalizar el apartado 'Datos Generales' para continuar con la declaración");
                        }
                        else
                        {
                            Response.Redirect("DatosCurriculares.aspx");
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
            ((_Inicial)Master).links_DatosGenerales(ref oDeclaracion);
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

        protected void cmbPaisDomimicioParticular_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisDomimicioParticular.SelectedValue());
            oEntidadFederativa.select();
            cmbEntidadFederativaDomicilioParticular.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            cmbEntidadFederativaDomicilioParticular_SelectedIndexChanged(sender, e);
        }

        protected void cmbEntidadFederativaDomicilioParticular_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
            omun.NID_PAIS = new Declara_V2.IntegerFilter(cmbPaisDomimicioParticular.SelectedValue());
            omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbEntidadFederativaDomicilioParticular.SelectedValue);
            omun.select();
            cmbMunicipioDomicilioParticular.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
        }

        protected void txtcCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            if (txtcCodigoPostal.Text.Length == 5)
            {
                try
                {
                    blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(txtcCodigoPostal.Text);
                    cmbPaisDomimicioParticular.SelectedValue = oCodigo.NID_PAIS.ToString();
                    cmbPaisDomimicioParticular_SelectedIndexChanged(sender, e);
                    cmbEntidadFederativaDomicilioParticular.SelectedValue = oCodigo.CID_ENTIDAD_FEDERATIVA;
                    cmbEntidadFederativaDomicilioParticular_SelectedIndexChanged(sender, e);
                    cmbMunicipioDomicilioParticular.SelectedValue = oCodigo.CID_MUNICIPIO;
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
                txtV_DENOMINACION_PUESTO.Text = oPuesto.V_PUESTO_COMPUESTO;
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
            mdlDependiente.Show(true);
            mdlDependiente.HeaderText = "Dar de alta dependiente";
            ctrlDependiente1.limpia();
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
                            oDeclaracion.DECLARACION_DEPENDIENTESs[ctrlDependiente1.Selected_id].DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = ctrlDependiente1.V_RFC;
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
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mdlDependiente.Show(true);
            mdlDependiente.HeaderText = "Modificar dependiente";
            ctrlDependiente1.llena(oDeclaracion.DECLARACION_DEPENDIENTESs[e.Id], e.Id);
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

        protected void txtF_POSESION_TextChanged(object sender, EventArgs e)
        {
            ControlaEjercicio(txtF_POSESION.Text);
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

    }
}