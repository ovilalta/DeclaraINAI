using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace DeclaraINE.Formas.DeclaracionInicial
{
    public partial class ExperienciaLaboral : Pagina, IDeclaracionInicial
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

        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_DECLARACION_EXPERIENCIA_LABORAL o;

            for (int x = 0; x < oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs.Count; x++)
            {
                o = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("grd", ((Item)item).Id);
                ((Item)item).TextoPrincipal = o.V_AMBITO_SECTOR;
                ((Item)item).TextoSecundario = "Empresa: " + o.V_NOMBRE + "<br>Puesto: " + o.V_PUESTO + "<br>" + o.F_INGRESO.ToShortDateString() + " - " + o.F_EGRESO.ToShortDateString();
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_EXPERIENCIALABORAL/", o.NID_AMBITO_SECTOR, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grd.Controls.AddAt(0 + x, item);
            }
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
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 17).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lnkExperienciaLaboral")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lnkExperienciaLaboral")).CssClass = "active";



            ltrSubTitulo.Text = "5. Experiencia Laboral (últimos cinco empleos) </br> <h6>Empleo, Cargo o Comisión/Puesto. </h6>";
        }

        public void Anterior()
        {
            try
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioParticular;
                Response.Redirect("DatosGenerales.aspx");
            }
            catch
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioParticular;
                Response.Redirect("DatosGenerales.aspx");
            }


           
        }

        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 17).First().L_ESTADO.Value)
            {
                // AQUI VA EL CODIGO DEL APARTADO
                //---------------------------------------------------
                //*
                //---------------------------------------------------
            }

            marcaApartado(ref oDeclaracion, 17);
           
            try
            {

                blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                oPuesto.select();
                var o = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single();

                bool? obligado = o.L_OBLIGADO;
                if (obligado != null)
                    if (obligado.Equals(false))
                    {
                        marcaApartado(ref oDeclaracion, 1);
                        marcaApartado(ref oDeclaracion, 5);
                        marcaApartado(ref oDeclaracion, 6);
                        
                        Response.Redirect("Ingresos.aspx");

                    }
                    else
                    {
                        ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioLaboral;
                        Response.Redirect("DatosGenerales.aspx");
                    }
               
            }
            catch
            {

            }

            //if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
            //{
            //    MsgBox.ShowWarning("Debe finalizar el apartado 'Datos Generales' para continuar con la declaración");
            //}
            //else
            //{
            //    //Response.Redirect("Bienes.aspx");
            //    ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioLaboral;

            //    Response.Redirect("DatosGenerales.aspx");
            //}
        }

        public static void marcaApartado(ref blld_DECLARACION oDeclaracion, int NID_APARTADO)
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

            if (NID_APARTADO == 17)
            {
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 2, 3, 4, 5, 6, 16, 17 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
                {
                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
                    {
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO = true;
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().update();
                    }
                }
            }
        }

        protected void btnAgregarExperienciaLaboral_Click(object sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                blld_DECLARACION_EXPERIENCIA_LABORAL o;

                if (oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs.Count() < 5)
                {
                    mppExperienciaLaboral.Show(true);
                    lEditar = false;
                    ctrlExperienciaLaboral.limpiarFormulario();
                }
                else
                    MsgBox.ShowDanger("Solo se necesita 5 empleos laborales");
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

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            ctrlExperienciaLaboral.CheckedNullable = true;
            mppExperienciaLaboral.Hide();
        }

        protected void btnGuardarExperienciaLaboral_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                ActualizaExperienciaLaboral();
            }
            else
            {
                NuevaExperienciaLaboral();
            }
        }

        //---------------------------------------------
        //Guardar datos
        public void NuevaExperienciaLaboral()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            try
            {
                ctrlExperienciaLaboral.ValidaPregunta();

                oDeclaracion.Add_DECLARACION_EXPERIENCIA_LABORALs(
                    _oUsuario.VID_NOMBRE,
                    _oUsuario.VID_FECHA,
                    _oUsuario.VID_HOMOCLAVE,
                    _oDeclaracion.NID_DECLARACION,
                    ctrlExperienciaLaboral.NID_AMBITO_SECTOR,
                    ctrlExperienciaLaboral.NID_NIVEL_GOBIERNO,
                    ctrlExperienciaLaboral.NID_AMBITO_PUBLICO,
                    ctrlExperienciaLaboral.V_NOMBRE,
                    ctrlExperienciaLaboral.V_RFC,
                    ctrlExperienciaLaboral.V_AREA_ADSCRIPCION,
                    ctrlExperienciaLaboral.V_PUESTO,
                    ctrlExperienciaLaboral.V_FUNCION_PRINCIPAL,
                    ctrlExperienciaLaboral.NID_SECTOR,
                    ctrlExperienciaLaboral.F_INGRESO,
                    ctrlExperienciaLaboral.F_EGRESO,
                    ctrlExperienciaLaboral.NID_PAIS,
                    ctrlExperienciaLaboral.E_OBSERVACIONES
                    );

                AlertaSuperior.ShowSuccess("Se agrego correctamente la Experiencia Laboral");

                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs.Count + 1; // .ALTA.ALTA_ADEUDOs.Count + 1;
                ((Item)item).ID = String.Concat("grd", ((Item)item).Id);
                ((Item)item).TextoPrincipal = ctrlExperienciaLaboral.V_AMBITO_SECTOR;
                ((Item)item).TextoSecundario = "Empresa: " + ctrlExperienciaLaboral.V_NOMBRE + "<br>Puesto: " + ctrlExperienciaLaboral.V_PUESTO + "<br>" + ctrlExperienciaLaboral.F_INGRESO.ToShortDateString() + " - " + ctrlExperienciaLaboral.F_EGRESO.ToShortDateString();
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_EXPERIENCIALABORAL/", ctrlExperienciaLaboral.NID_AMBITO_SECTOR, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grd.Controls.AddAt(grd.Controls.Count - 3, item);

                ctrlExperienciaLaboral.CheckedNullable = true;
                mppExperienciaLaboral.Hide();

                marcaApartado(ref oDeclaracion, 17);

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

        //Actualiza datos
        public void ActualizaExperienciaLaboral()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            try
            {
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].NID_NIVEL_GOBIERNO = ctrlExperienciaLaboral.NID_NIVEL_GOBIERNO;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].NID_AMBITO_PUBLICO = ctrlExperienciaLaboral.NID_AMBITO_PUBLICO;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].V_NOMBRE = ctrlExperienciaLaboral.V_NOMBRE;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].V_RFC = ctrlExperienciaLaboral.V_RFC;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].V_AREA_ADSCRIPCION = ctrlExperienciaLaboral.V_AREA_ADSCRIPCION;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].V_PUESTO = ctrlExperienciaLaboral.V_PUESTO;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].V_FUNCION_PRINCIPAL = ctrlExperienciaLaboral.V_FUNCION_PRINCIPAL;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].NID_SECTOR = ctrlExperienciaLaboral.NID_SECTOR;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].F_INGRESO = ctrlExperienciaLaboral.F_INGRESO;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].F_EGRESO = ctrlExperienciaLaboral.F_EGRESO;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].NID_PAIS = ctrlExperienciaLaboral.NID_PAIS;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].E_OBSERVACIONES = ctrlExperienciaLaboral.E_OBSERVACIONES;
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[Indice].update();

                ((Item)grd.FindControl(String.Concat("grd", Indice))).ImageUrl = String.Concat("../../Images/CAT_TIPO_EXPERIENCIALABORAL/", ctrlExperienciaLaboral.NID_AMBITO_SECTOR, ".png");
                ((Item)grd.FindControl(String.Concat("grd", Indice))).TextoPrincipal = ctrlExperienciaLaboral.V_AMBITO_SECTOR;
                ((Item)grd.FindControl(String.Concat("grd", Indice))).TextoSecundario = "Empresa: " + ctrlExperienciaLaboral.V_NOMBRE + "<br>Puesto: " + ctrlExperienciaLaboral.V_PUESTO + "<br>" + ctrlExperienciaLaboral.F_INGRESO.ToShortDateString() + " - " + ctrlExperienciaLaboral.F_EGRESO.ToShortDateString();

                AlertaSuperior.ShowSuccess("Se actualizaron correctamente los datos de la experiencia laboral");
                _oDeclaracion = oDeclaracion;
                mppExperienciaLaboral.Hide();
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

        //-----------------------------------
        //
        //-----------------------------------
        //-----------------------------------

        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                blld_DECLARACION_EXPERIENCIA_LABORAL o;

                o = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id];
                oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs.RemoveAt(e.Id);
                grd.Controls.Remove(grd.FindControl(String.Concat("grd", e.Id)));
                _oDeclaracion = oDeclaracion;
                AlertaSuperior.ShowSuccess("Se eliminó correctamente la experiencia laboral");
            }
            catch (Exception ex)
            {
                if (ex.InnerException is CustomException || ex is ConvertionException)
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

        protected void OnEditar(object sender, ItemEventArgs e)
        {
            mppExperienciaLaboral.Show(true);

            lEditar = true;

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            IndiceItemSeleccionado = e.Id;

            try { ctrlExperienciaLaboral.NID_AMBITO_SECTOR = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].NID_AMBITO_SECTOR; } catch { }
            try { ctrlExperienciaLaboral.NID_AMBITO_PUBLICO = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].NID_AMBITO_PUBLICO; } catch { }
            try { ctrlExperienciaLaboral.NID_NIVEL_GOBIERNO = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].NID_NIVEL_GOBIERNO; } catch { }

            ctrlExperienciaLaboral.V_NOMBRE = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].V_NOMBRE;
            ctrlExperienciaLaboral.V_RFC = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].V_RFC;
            ctrlExperienciaLaboral.V_AREA_ADSCRIPCION = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].V_AREA_ADSCRIPCION;
            ctrlExperienciaLaboral.V_PUESTO = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].V_PUESTO;
            ctrlExperienciaLaboral.V_FUNCION_PRINCIPAL = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].V_FUNCION_PRINCIPAL;
            ctrlExperienciaLaboral.NID_EXPERIENCIA_LABORAL = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].NID_EXPERIENCIA_LABORAL;

            try
            {
                ctrlExperienciaLaboral.NID_SECTOR = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].NID_SECTOR;


                if (oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].NID_SECTOR == 17)
                {
                    ctrlExperienciaLaboral.V_SECTOR_BOOL = true;
                }
                else
                {
                    ctrlExperienciaLaboral.V_SECTOR_BOOL = false;
                }

            }
            catch { }
            ctrlExperienciaLaboral.F_INGRESO = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].F_INGRESO;
            ctrlExperienciaLaboral.F_EGRESO = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].F_EGRESO;
            ctrlExperienciaLaboral.NID_PAIS = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].NID_PAIS;
            ctrlExperienciaLaboral.E_OBSERVACIONES = oDeclaracion.DECLARACION_EXPERIENCIA_LABORALs[e.Id].E_OBSERVACIONES;




        }

    }
}