using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;
using System.Data;
using Declara_V2.BLL;



namespace DeclaraINE.Formas.DeclaracionInicial
{
    public partial class Adeudos : Pagina, IDeclaracionInicial
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
        internal Boolean lEditar
        {
            get => (Boolean)ViewState["lEditar"];
            set => ViewState["lEditar"] = value;
        }
        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_ADEUDO o;
            for (int x = 0; x < oDeclaracion.ALTA.ALTA_ADEUDOs.Count; x++)
            {
                o = oDeclaracion.ALTA.ALTA_ADEUDOs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("grd", ((Item)item).Id);
                ((Item)item).TextoPrincipal = o.V_TIPO_ADEUDO;
                ((Item)item).TextoSecundario = "No. Cuenta:" + o.E_CUENTA + "<br> Monto original: " + o.M_ORIGINAL.ToString("C") + "<br>  Saldo : " + o.M_SALDO.ToString("C");
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", o.NID_TIPO_ADEUDO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grd.Controls.AddAt(0 + x, item);
            }

        }


        protected void OnEditar(object sender, ItemEventArgs e)
        {
            mppAdeudo.Show(true);
            mppAdeudo.HeaderText = "Adeudos/Pasivos";
            lEditar = true;
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            IndiceItemSeleccionado = e.Id;
            if (!oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].L_AUTOGENERADO)
                ((DropDownList)Adeudo.FindControl("cmbNID_TIPO_ADEUDO")).Enabled = false;
            else
                ((DropDownList)Adeudo.FindControl("cmbNID_TIPO_ADEUDO")).Enabled = true;
            Adeudo.NID_TIPO_ADEUDO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].NID_TIPO_ADEUDO;
            Adeudo.NID_PAIS = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].NID_PAIS;
            Adeudo.CID_ENTIDAD_FEDERATIVA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].CID_ENTIDAD_FEDERATIVA;
            Adeudo.V_LUGAR = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_LUGAR;
            Adeudo.NID_INSTITUCION = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].NID_INSTITUCION;
            Adeudo.E_RFC = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_RFC;
            Adeudo.V_OTRA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_OTRA;
            Adeudo.M_ORIGINAL = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].M_ORIGINAL;
            Adeudo.V_TIPO_MONEDA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_TIPO_MONEDA;
            Adeudo.CID_TIPO_PERSONA_OTORGANTE = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].CID_TIPO_PERSONA_OTORGANTE;
            Adeudo.F_ADEUDO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].F_ADEUDO;
            Adeudo.M_SALDO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].M_SALDO;
            Adeudo.E_CUENTA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_CUENTA.ToString();
            Adeudo.E_OBSERVACIONES = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_OBSERVACIONES.ToString();
            Adeudo.NID_TITULARs = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].ALTA_ADEUDO_TITULARs.Select(p => p.NID_DEPENDIENTE).ToList();
            Adeudo.NID_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].NID_TERCERO;
            Adeudo.E_NOMBRE_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_NOMBRE_TERCERO.ToString();
            Adeudo.E_RFC_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_RFC_TERCERO.ToString();
            //if (String.IsNullOrEmpty(oDeclaracion.ALTA.ALTA_ADEUDOs.   [e.Id].CID_TIPO_PERSONA))
            {
                //    Adeudo.CID_TIPO_PERSONA_TERCERO = String.Empty;
                //    Adeudo.E_NOMBRE_TERCERO = String.Empty;
                //    Adeudo.E_RFC_TERCERO = String.Empty;

                //}
                //else
                //{
                //    Adeudo.CID_TIPO_PERSONA_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].CID_TIPO_PERSONA;
                //    Adeudo.E_NOMBRE_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_NOMBRE;
                //    Adeudo.E_RFC_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_RFC;
                //}

            }
        } 
        protected void OnEliminar(object sender, ItemEventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                blld_ALTA_ADEUDO o;
                o = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id];
                oDeclaracion.ALTA.ALTA_ADEUDOs.RemoveAt(e.Id);
                grd.Controls.Remove(grd.FindControl(String.Concat("grd", e.Id)));
                _oDeclaracion = oDeclaracion;
                AlertaSuperior.ShowSuccess("Se eliminó correctamente el adeudo");
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
        protected void Page_Load(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            ((HtmlControl)Master.FindControl("liAdeudos")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu4")).Attributes.Add("class", "tab-pane fade level1 active in");
            if (!IsPostBack)
            {
               //OEVM
                if (oDeclaracion.ALTA.ALTA_ADEUDOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                  //  QstBox.Ask("¿Cuenta con adeudos vigentes al dia de hoy?");
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkAdeudos")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkAdeudos")).CssClass = "active";
        }
      
        protected void btnAgregarAdeudo_Click(object sender, EventArgs e)
        {
            lEditar = false;            
            mppAdeudo.Show(true);
            lEditar = false;
            Adeudo.Clear();
            Adeudo.NID_TIPO_ADEUDO = 4;
            ((DropDownList)Adeudo.FindControl("cmbNID_TIPO_ADEUDO")).Enabled = true;
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mppAdeudo.Hide();
        }

        public void Anterior()
        {
            Response.Redirect("Inversiones.aspx");
        }

        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            //if (oDeclaracion.ALTA.ALTA_ADEUDOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
            //{
            //    marcaApartado(12);
            //}
            //else
            //{
                marcaApartado(12);
            //}
                Response.Redirect("Comodato.aspx");
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

        //protected void cmbNID_PAIS_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
        //    oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbNID_PAIS.SelectedValue());
        //    oEntidadFederativa.select();
        //    cmbCID_ENTIDAD_FEDERATIVA.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
        //}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           

        }
       

        protected void btnGuarda_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                ActualizaAdeudo();
            }
            else
            {
                NuevoAdeudo();
            }

        }
        public void ActualizaAdeudo()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            if (oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE != Adeudo.E_RFC.ToUpper())
            {
                try
                {

                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].NID_PAIS = Adeudo.NID_PAIS;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].CID_ENTIDAD_FEDERATIVA = Adeudo.CID_ENTIDAD_FEDERATIVA;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_LUGAR = Adeudo.V_LUGAR;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].NID_INSTITUCION = Adeudo.NID_INSTITUCION;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].E_RFC = Adeudo.E_RFC;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_OTRA = Adeudo.V_OTRA;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].E_CUENTA = Adeudo.E_CUENTA;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].F_ADEUDO = Adeudo.F_ADEUDO;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].M_ORIGINAL = Adeudo.M_ORIGINAL.Value;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_TIPO_MONEDA = Adeudo.V_TIPO_MONEDA;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].CID_TIPO_PERSONA_OTORGANTE = Adeudo.CID_TIPO_PERSONA_OTORGANTE;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].M_SALDO = Adeudo.M_SALDO.Value;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_OTRA = Adeudo.V_OTRA;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_LUGAR = String.Empty;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].E_OBSERVACIONES = Adeudo.E_OBSERVACIONES;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].NID_TERCERO = Adeudo.NID_TERCERO;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].E_NOMBRE_TERCERO = Adeudo.E_NOMBRE_TERCERO;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].E_RFC_TERCERO = Adeudo.E_RFC_TERCERO;
                    oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].update(Adeudo.NID_TITULARs);

                    ((Item)grd.FindControl(String.Concat("grd", Indice))).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", Adeudo.NID_TIPO_ADEUDO, ".png");
                    ((Item)grd.FindControl(String.Concat("grd", Indice))).TextoPrincipal = Adeudo.V_TIPO_ADEUDO;
                    ((Item)grd.FindControl(String.Concat("grd", Indice))).TextoSecundario = "<br> No. Cuenta: " + Adeudo.E_CUENTA + "<br>Monto original del Adeudo: " + Adeudo.M_ORIGINAL.Value.ToString("C") + "<br>  Saldo : " + Adeudo.M_SALDO.Value.ToString("C");

                    AlertaSuperior.ShowSuccess("Se actualizaron correctamente los datos del adeudo");
                    _oDeclaracion = oDeclaracion;
                    mppAdeudo.Hide();
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
            else
            {
                MsgBox.ShowDanger("Advertencia", "El RFC del otorgante NO puede ser el mismo del declarante");
            }

        }
        public void NuevoAdeudo()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            if (oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE != Adeudo.E_RFC.ToUpper())
            {
                try
                {
                    oDeclaracion.ALTA.Add_ALTA_ADEUDOs(
                                                      Adeudo.NID_PAIS,
                                                      Adeudo.CID_ENTIDAD_FEDERATIVA,
                                                      Adeudo.V_LUGAR,
                                                      Adeudo.NID_INSTITUCION,
                                                      Adeudo.V_OTRA,
                                                      Adeudo.NID_TIPO_ADEUDO,
                                                      Adeudo.F_ADEUDO,
                                                      Adeudo.M_ORIGINAL.Value,
                                                      Adeudo.M_SALDO.Value,
                                                      Adeudo.E_CUENTA,
                                                      Adeudo.V_TIPO_MONEDA,
                                                      Adeudo.E_RFC,
                                                      Adeudo.E_OBSERVACIONES,
                                                      Adeudo.CID_TIPO_PERSONA_OTORGANTE,
                                                      Adeudo.NID_TITULARs);
                    AlertaSuperior.ShowSuccess("Se agregó correctamente el adeudo");
                    string PasaNombre = Adeudo.V_TIPO_ADEUDO;
                    UserControl item = (UserControl)Page.LoadControl("item.ascx");
                    ((Item)item).Id = oDeclaracion.ALTA.ALTA_ADEUDOs.Count + 1;
                    ((Item)item).ID = String.Concat("grd", ((Item)item).Id);
                    ((Item)item).TextoPrincipal = PasaNombre;
                    ((Item)item).TextoSecundario = "No. Cuenta " + Adeudo.E_CUENTA + "<br>Monto del Adeudo: " + Adeudo.M_ORIGINAL.Value.ToString("C") + "<br>  Saldo : " + Adeudo.M_SALDO.Value.ToString("C");
                    ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", Adeudo.NID_TIPO_ADEUDO, ".png");
                    ((Item)item).Editar += OnEditar;
                    ((Item)item).Eliminar += OnEliminar;
                    grd.Controls.AddAt(grd.Controls.Count - 3, item);
                    mppAdeudo.Hide();
                    marcaApartado(12);
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
            else
            {
                MsgBox.ShowDanger("Advertencia", "El RFC del otorgante NO puede ser el mismo del declarante");
            }

        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            marcaApartado(12);
            Response.Redirect("Observaciones.aspx");
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }
    }
}