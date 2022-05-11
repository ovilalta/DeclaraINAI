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



namespace DeclaraINE.Formas.DeclaracionModificacion
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
                UserControl item = (UserControl)Page.LoadControl("ItemBaja.ascx");
                ((ItemBaja)item).Id = x;
                ((ItemBaja)item).ID = String.Concat("grd", ((ItemBaja)item).Id);
                ((ItemBaja)item).TextoPrincipal = o.V_TIPO_ADEUDO;
                ((ItemBaja)item).TextoSecundario = "No. Cuenta:" + o.E_CUENTA + "<br> Monto original: " + o.M_ORIGINAL.ToString("C") + "<br>  Saldo : " + o.M_SALDO.ToString("C");
                ((ItemBaja)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", o.NID_TIPO_ADEUDO, ".png");
                ((ItemBaja)item).Editar += OnEditar;
                ((ItemBaja)item).Eliminar += OnEliminar;
                ((ItemBaja)item).Bajar += OnBaja;
                //if (o.F_ADEUDO < String.Concat("01/01/", Convert.ToString(System.DateTime.Today.Year - 1)).Date())
                //{
                //    ((Button)((ItemBaja)item).FindControl("btnEliminar")).Visible = false;
                //    ((Button)((ItemBaja)item).FindControl("btnBaja")).Visible = false;
                //}

                //if (o.F_ADEUDO > String.Concat("01/01/", Convert.ToString(System.DateTime.Today.Year - 1)).Date())
                //{
                ((Button)((ItemBaja)item).FindControl("btnEliminar")).Visible = true;
                ((Button)((ItemBaja)item).FindControl("btnBaja")).Visible = false;
                //}
                grd.Controls.AddAt(0 + x, item);
            }

        }


        protected void OnEditar(object sender, ItemEventArgs e)
        {
            mppAdeudo.Show(true);
            mppAdeudo.HeaderText = "Adeudo/Pasivo";
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
            try { Adeudo.E_RFC = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_RFC; } catch { }

            Adeudo.V_OTRA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_OTRA;
            Adeudo.M_ORIGINAL = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].M_ORIGINAL;
            Adeudo.V_TIPO_MONEDA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_TIPO_MONEDA;
            Adeudo.CID_TIPO_PERSONA_OTORGANTE = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].CID_TIPO_PERSONA_OTORGANTE;
            Adeudo.F_ADEUDO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].F_ADEUDO;
            Adeudo.M_SALDO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].M_SALDO;
            try { Adeudo.E_CUENTA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_CUENTA.ToString(); } catch { }
            try { Adeudo.E_OBSERVACIONES = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_OBSERVACIONES.ToString(); } catch { }

            //chbDependietesInm.SelectedValue = i.ALTA_INMUEBLE_TITULARs.First().NID_DEPENDIENTE.ToString();
            //chbDependietesInm_SelectedIndexChanged(sender, e);
            Adeudo.NOM_DEPENDIENTE = Convert.ToInt32(oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].ALTA_ADEUDO_TITULARs.First().NID_DEPENDIENTE.ToString());
            try { Adeudo.NOM_MONEDA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_TIPO_MONEDA.Split('|')[0]; } catch { }
            Adeudo.NID_TITULARs = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].ALTA_ADEUDO_TITULARs.Select(p => p.NID_DEPENDIENTE).ToList();
            Adeudo.NID_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].NID_TERCERO;
            try { Adeudo.E_NOMBRE_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_NOMBRE_TERCERO.ToString(); } catch { }
            try { Adeudo.E_RFC_TERCERO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_RFC_TERCERO.ToString(); } catch { }

            //try {Adeudo.F_BAJA = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].NID_PATRIMONIO).First().F_BAJA.ToString(Pagina.strFormatoFecha); } catch { }
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
                EliminaF_baja(o.NID_PATRIMONIO.ToString());
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
                    //   QstBox.Ask("¿Cuenta con adeudos vigentes al dia de hoy?");
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
            mppAdeudo.HeaderText = "Adeudos/Pasivos";
            lEditar = false;
            Adeudo.Clear();
            Adeudo.NID_TIPO_ADEUDO = 0;
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
                Response.Redirect("Adeudos.aspx"); //OEVM - 20220511 - Se incuye para forzar la actualizacion de la pagina y asi se visualicen los cambios realizados
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
            //Adeudo.NID_TITULARs = Adeudo.NOM_DEPENDIENTE;
            if (oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE != Adeudo.E_RFC.ToUpper())
            {
                if (Adeudo.F_ADEUDO > Convert.ToDateTime("1900-01-01"))
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
                        String Paso = Adeudo.F_BAJA;
                        EliminaF_baja(oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].NID_PATRIMONIO.ToString());
                        //if (Adeudo.F_BAJA.ToString().Length > 8)
                        //    oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].NID_PATRIMONIO, 1,Convert.ToDateTime( Adeudo.F_BAJA));

                        //((Item)grd.FindControl(String.Concat("grd", Indice))).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", Adeudo.NID_TIPO_ADEUDO, ".png");
                        //((Item)grd.FindControl(String.Concat("grd", Indice))).TextoPrincipal = Adeudo.V_TIPO_ADEUDO;
                        //((Item)grd.FindControl(String.Concat("grd", Indice))).TextoSecundario = "<br> No. Cuenta: " + Adeudo.E_CUENTA + "<br>Monto original del Adeudo: " + Adeudo.M_ORIGINAL.Value.ToString("C") + "<br>  Saldo : " + Adeudo.M_SALDO.Value.ToString("C");

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
                    MsgBox.ShowDanger("Advertencia", "La fecha del adeudo NO puede ser menor al año 1901");
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
            blld_ALTA_ADEUDO o;
            // blld_ALTA_INMUEBLE o;
            if (oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE != Adeudo.E_RFC.ToUpper())
            {
                if (Adeudo.F_ADEUDO > Convert.ToDateTime( "1900-01-01"))
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
                        AlertaSuperior.ShowSuccess("Se agrego correctamente el adeudo");



                        o = oDeclaracion.ALTA.ALTA_ADEUDOs.Last();

                        //if (Adeudo.F_BAJA.ToString().Length > 8)
                        //    oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(o.NID_PATRIMONIO, 1,Convert.ToDateTime( Adeudo.F_BAJA));

                        string PasaNombre = Adeudo.V_TIPO_ADEUDO;
                        UserControl item = (UserControl)Page.LoadControl("ItemBaja.ascx");
                        ((ItemBaja)item).Id = oDeclaracion.ALTA.ALTA_ADEUDOs.Count + 1;
                        ((ItemBaja)item).ID = String.Concat("grd", ((ItemBaja)item).Id);
                        ((ItemBaja)item).TextoPrincipal = PasaNombre;
                        ((ItemBaja)item).TextoSecundario = "No. Cuenta " + Adeudo.E_CUENTA + "<br>Monto del Adeudo: " + Adeudo.M_ORIGINAL.Value.ToString("C") + "<br>  Saldo : " + Adeudo.M_SALDO.Value.ToString("C");
                        ((ItemBaja)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", Adeudo.NID_TIPO_ADEUDO, ".png");
                        ((ItemBaja)item).Editar += OnEditar;
                        ((ItemBaja)item).Eliminar += OnEliminar;
                        ((ItemBaja)item).Bajar += OnBaja;
                        if (o.F_ADEUDO < String.Concat("01/01/", Convert.ToString(System.DateTime.Today.Year - 1)).Date())
                        {
                            ((Button)((ItemBaja)item).FindControl("btnEliminar")).Visible = false;
                            ((Button)((ItemBaja)item).FindControl("btnBaja")).Visible = true;
                        }

                        if (o.F_ADEUDO > String.Concat("01/01/", Convert.ToString(System.DateTime.Today.Year - 1)).Date())
                        {
                            ((Button)((ItemBaja)item).FindControl("btnEliminar")).Visible = true;
                            ((Button)((ItemBaja)item).FindControl("btnBaja")).Visible = false;
                        }

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
                    MsgBox.ShowDanger("Advertencia", "La fecha del adeudo NO puede ser menor al año 1901");
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

        //  ************************** Dar de baja datos *********************
        protected void OnBaja(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            Int32 nid;
            nid = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].NID_PATRIMONIO;

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
            AlertaSuperior.ShowSuccess("Se guardó exitosamenta la baja del Adeudo");
        }
        protected void btnEliminarBaja_Click(object sender, EventArgs e)
        {
            ctrlDesincorpora1.Elimina();
            mppBaja.Hide();
            AlertaSuperior.ShowSuccess("Se eliminó exitosamenta la baja del Adedo");
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
    }
}