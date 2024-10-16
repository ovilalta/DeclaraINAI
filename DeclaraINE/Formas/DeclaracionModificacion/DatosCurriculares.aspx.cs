using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Declara_V2.BLLD;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Declara_V2.BLL;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;

namespace DeclaraINAI.Formas.DeclaracionModificacion
{
    public partial class DatosCurriculares : Pagina, IDeclaracionInicial
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

        public int lDeside
        {
            get
            {
                if (ViewState["lDeside"] == null)
                    return 0;
                return (int)ViewState["lDeside"];
            }
            set
            {
                if (ViewState["lDeside"] == null)
                    ViewState.Add("lDeside", value);
                else
                    ViewState["lDeside"] = value;
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
            DatosCurriculares,

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



        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_DECLARACION_ESCOLARIDAD u;

            for (int x = 0; x < oDeclaracion.DECLARACION_ESCOLARIDADs.Count; x++)
            {
                u = oDeclaracion.DECLARACION_ESCOLARIDADs[x];
                UserControl Item = (UserControl)Page.LoadControl("ctrlDatosCurriculares.ascx");
                ((ctrlDatosCurriculares)Item).Id = x;
                ((ctrlDatosCurriculares)Item).ID = Convert.ToString(((ctrlDatosCurriculares)Item).Id);
                ((ctrlDatosCurriculares)Item).TextoPrincipal = u.V_NIVEL_ESCOLARIDAD;
                ((ctrlDatosCurriculares)Item).TextoSecundario = "Institución Educativa:" + u.V_INSTITUCION_EDUCATIVA + "<br> Carrera o Área de Conocimiento: " + u.V_CARRERA.ToString() + "<br>  Estado: " + u.V_ESTADO_ESCOLARIDAD.ToString();
                ((ctrlDatosCurriculares)Item).ImageUrl = String.Concat("../../Images/CAT_NIVEL_ESCOLARIDAD/", u.NID_NIVEL_ESCOLARIDAD, ".png");
                ((ctrlDatosCurriculares)Item).Editar += OnEditar;
                ((ctrlDatosCurriculares)Item).Eliminar += OnEliminar;
                grdCurriculum.Controls.AddAt(0 + x, Item);
            }




        }

        protected void OnEditar(object sender, DatosCurricularesEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppDatosCurriculares.Show(true);
            mppDatosCurriculares.HeaderText = "Modificar datos curriculares del Declarante";

            lEditar = true;

            bll_DECLARACION_ESCOLARIDAD d;
            d = oDeclaracion.DECLARACION_ESCOLARIDADs[e.Id];
            IndiceItemSeleccionado = e.Id;
            cmbNIVEL_ESCOLARIDAD.SelectedValue = d.NID_NIVEL_ESCOLARIDAD.ToString();
            txtInstitucionEducativa.Text = d.V_INSTITUCION_EDUCATIVA.ToString();
            txtAREA_CONOCIMIENTO.Text = d.V_CARRERA.ToString();
            cmbEstado.SelectedValue = d.NID_ESTADO_ESCOLARIDAD.ToString();
            cmbDoctoObtenido.SelectedValue = d.NID_DOCUMENTO_OBTENIDO.ToString();
            txtF_OBT_DOCTO_C.Text = d.F_OBTENCION.ToString().Substring(0, 10);
            cmbPais.SelectedValue = d.NID_PAIS.ToString();
            if (d.E_OBSERVACIONES != null)
                mltObservaciones.Text = d.E_OBSERVACIONES.ToString();
            cmbNIVEL_ESCOLARIDAD.SelectedValue = oDeclaracion.DECLARACION_ESCOLARIDADs[e.Id].NID_NIVEL_ESCOLARIDAD.ToString();
        }

        protected void OnEliminar(object sender, DatosCurricularesEventArgs e)
        {
            QstBox.AskWarning("Desea eliminar el registro");
            lDeside = (e.Id);


        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liDatosGenerales")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu1")).Attributes.Add("class", "tab-pane fade level1 active in");

            blld_DECLARACION oDeclaracion = _oDeclaracion;

            if (!IsPostBack)
            {
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";

                blld__l_CAT_NIVEL_ESCOLARIDAD oNIVEL_ESCOLARIDAD = new blld__l_CAT_NIVEL_ESCOLARIDAD();
                oNIVEL_ESCOLARIDAD.select();
                cmbNIVEL_ESCOLARIDAD.DataBind(oNIVEL_ESCOLARIDAD.lista_CAT_NIVEL_ESCOLARIDAD, CAT_NIVEL_ESCOLARIDAD.Properties.NID_NIVEL_ESCOLARIDAD, CAT_NIVEL_ESCOLARIDAD.Properties.V_NIVEL_ESCOLARIDAD);
                cmbNIVEL_ESCOLARIDAD.Items.Insert(0, new ListItem(String.Empty));

                blld__l_CAT_ESTADO_ESCOLARIDAD oESTADO_ESCOLARIDAD = new blld__l_CAT_ESTADO_ESCOLARIDAD();
                oESTADO_ESCOLARIDAD.select();
                cmbEstado.DataBind(oESTADO_ESCOLARIDAD.lista_CAT_ESTADO_ESCOLARIDAD, CAT_ESTADO_ESCOLARIDAD.Properties.NID_ESTADO_ESCOLARIDAD, CAT_ESTADO_ESCOLARIDAD.Properties.V_ESTADO_ESCOLARIDAD);
                cmbEstado.Items.Insert(0, new ListItem(String.Empty));

                blld__l_CAT_DOCUMENTO_OBTENIDO oDOC_OBTENIDO = new blld__l_CAT_DOCUMENTO_OBTENIDO();
                oDOC_OBTENIDO.select();
                cmbDoctoObtenido.DataBind(oDOC_OBTENIDO.lista_CAT_DOCUMENTO_OBTENIDO, CAT_DOCUMENTO_OBTENIDO.Properties.NID_DOCUMENTO_OBTENIDO, CAT_DOCUMENTO_OBTENIDO.Properties.V_DOCUMENTO_OBTENIDO);
                cmbDoctoObtenido.Items.Insert(0, new ListItem(String.Empty));

                blld__l_CAT_PAIS oPAIS = new blld__l_CAT_PAIS();
                oPAIS.select();
                cmbPais.DataBind(oPAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS);
                cmbPais.Items.Insert(0, new ListItem(String.Empty));
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 16).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lnkDatosCurriculares")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lnkDatosCurriculares")).CssClass = "active";


            ltrSubTitulo.Text = "3. Datos curriculares del declarante <br> <p align='center'>Escolaridad</p> ";
            //pnlDatosCurriculum.Visible = true;

        }


        public void Anterior()
        {
            try
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DatosPersonales;
                Response.Redirect("DatosGenerales.aspx");
            }
            catch
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DatosPersonales;
                Response.Redirect("DatosGenerales.aspx");
            }
        }


        public void Siguiente()
        {
            try
            {
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                int nExp = oDeclaracion.DECLARACION_ESCOLARIDADs.Count();
                //QstSiguiente.Ask("Agregaste " + nExp + " de 5 datos curriculares solicitados, ¿estás seguro de continuar?");
                if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 16).First().L_ESTADO.Value)
                {
                    marcaApartado(16);
                }
                try
                {
                    ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioParticular;
                    Response.Redirect("DatosGenerales.aspx");
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void QstSiguiente_Yes(object Sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 16).First().L_ESTADO.Value)
            {  // AQUI VA EL CODIGO DEL APARTADO
                //---------------------------------------------------



                marcaApartado(16);

                //---------------------------------------------------
            }
            try
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioParticular;

                Response.Redirect("DatosGenerales.aspx");
            }
            catch
            {

            }
            //Response.Redirect("ExperienciaLaboral.aspx");
        }

        protected void QstSiguiente_No(object Sender, EventArgs e)
        {

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

        protected void btnAgregarCurriculum_Click(object sender, EventArgs e)
        {
            lEditar = false;
            cmbNIVEL_ESCOLARIDAD.SelectedIndex = 0;
            txtInstitucionEducativa.Text = String.Empty;
            txtAREA_CONOCIMIENTO.Text = String.Empty;
            cmbEstado.SelectedIndex = 0;
            cmbDoctoObtenido.SelectedIndex = 0;
            txtF_OBT_DOCTO_C.Text = String.Empty;
            cmbPais.Text = String.Empty;
            mltObservaciones.Text = String.Empty;
            mppDatosCurriculares.Show(Visible);
            mppDatosCurriculares.HeaderText = "Agregar datos curriculares del Declarante";
        }



        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mppDatosCurriculares.Hide();
        }

        protected void btnGuardarDatoCurricular_Click(object sender, EventArgs e)
        {

            if (lEditar)
            {
                ActualizaDatosCurriculares();
            }
            else
            {
                NuevoDatoCurricular();


                mppDatosCurriculares.Hide();
            }


        }



        public void ActualizaDatosCurriculares()
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;

            try
            {
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].NID_NIVEL_ESCOLARIDAD = cmbNIVEL_ESCOLARIDAD.SelectedValue();
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].V_INSTITUCION_EDUCATIVA = txtInstitucionEducativa.Text;
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].V_CARRERA = txtAREA_CONOCIMIENTO.Text;
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].NID_ESTADO_ESCOLARIDAD = cmbEstado.SelectedValue();
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].NID_DOCUMENTO_OBTENIDO = cmbDoctoObtenido.SelectedValue();
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].F_OBTENCION = txtF_OBT_DOCTO_C.Date();
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].NID_PAIS = cmbPais.SelectedValue();
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].E_OBSERVACIONES = mltObservaciones.Text;
                oDeclaracion.DECLARACION_ESCOLARIDADs[Indice].update();
                AlertaSuperior.ShowSuccess("Se actualizaron correctamente los datos curriculares");
                mppDatosCurriculares.Hide();
                _oDeclaracion = oDeclaracion;
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

        private static Lista<blld_DECLARACION_ESCOLARIDAD> GetDECLARACION_ESCOLARIDADs(blld_DECLARACION oDeclaracion)
        {
            return oDeclaracion.DECLARACION_ESCOLARIDADs;
        }

        private void NuevoDatoCurricular()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            //blld_USUARIO oUsuario = _oUsuario;


            try
            {
                oDeclaracion.Add_DECLARACION_ESCOLARIDADs(_oUsuario.VID_NOMBRE,
                                                         _oUsuario.VID_FECHA,
                                                         _oUsuario.VID_HOMOCLAVE,
                                                         _oDeclaracion.NID_DECLARACION,
                                                         Convert.ToInt32(cmbNIVEL_ESCOLARIDAD.SelectedValue),
                                                         txtInstitucionEducativa.Text,
                                                         txtAREA_CONOCIMIENTO.Text,
                                                         Convert.ToInt32(cmbEstado.SelectedValue),
                                                         Convert.ToInt32(cmbDoctoObtenido.SelectedValue),
                                                         Convert.ToDateTime(txtF_OBT_DOCTO_C.Text),
                                                         Convert.ToInt32(cmbPais.SelectedValue),
                                                         mltObservaciones.Text);
                AlertaSuperior.ShowSuccess("Se guardaron correctamente los datos curriculares");
                //string PasaNombre = ;
                UserControl Item = (UserControl)Page.LoadControl("ctrlDatosCurriculares.ascx");
                ((ctrlDatosCurriculares)Item).Id = oDeclaracion.DECLARACION_ESCOLARIDADs.Count - 1;
                ((ctrlDatosCurriculares)Item).ID = Convert.ToString(((ctrlDatosCurriculares)Item).Id);
                ((ctrlDatosCurriculares)Item).TextoPrincipal = oDeclaracion.DECLARACION_ESCOLARIDADs.Last().V_NIVEL_ESCOLARIDAD;
                ((ctrlDatosCurriculares)Item).TextoSecundario = "Institución Educativa:" + oDeclaracion.DECLARACION_ESCOLARIDADs.Last().V_INSTITUCION_EDUCATIVA + "<br> Carrera o Área de Conocimiento: " + oDeclaracion.DECLARACION_ESCOLARIDADs.Last().V_CARRERA.ToString() + "<br>  Estado: " + oDeclaracion.DECLARACION_ESCOLARIDADs.Last().V_ESTADO_ESCOLARIDAD.ToString();
                ((ctrlDatosCurriculares)Item).ImageUrl = String.Concat("../../Images/CAT_NIVEL_ESCOLARIDAD/", oDeclaracion.DECLARACION_ESCOLARIDADs.Last().NID_NIVEL_ESCOLARIDAD, ".png");
                ((ctrlDatosCurriculares)Item).Editar += OnEditar;
                ((ctrlDatosCurriculares)Item).Eliminar += OnEliminar;
                grdCurriculum.Controls.AddAt(grdCurriculum.Controls.Count - 4, Item);
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

        protected void QstBoxInm_Yes(object Sender, EventArgs e)
        {
            //active();
        }

        protected void QstBoxInm_No(object Sender, EventArgs e)
        {
            //blld_DECLARACION oDeclaracion = _oDeclaracion;
            //marcaApartado(ref oDeclaracion, 8);
            //_oDeclaracion = oDeclaracion;
            //Siguiente();
            //active();
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            //Response.Redirect("Index.aspx");
        }
        protected void QstBox_Yes(object Sender, EventArgs e)
        {
            try
            {

                blld_USUARIO oUsuario = _oUsuario;
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                blld_DECLARACION_ESCOLARIDAD o;
                o = oDeclaracion.DECLARACION_ESCOLARIDADs[lDeside];
                oDeclaracion.DECLARACION_ESCOLARIDADs.RemoveAt(lDeside);
                grdCurriculum.Controls.RemoveAt(lDeside);
                _oDeclaracion = oDeclaracion;
                AlertaSuperior.ShowSuccess("Se eliminaron correctamente los datos curriculares");
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


    }
}