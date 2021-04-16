using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Declara_V2.BLLD;
using Declara_V2;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;

namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class AdeudosModifica : Pagina, IDeclaracionInicial
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
                ((Item)item).FindControl("btnBaja").Visible = false;
                ((Item)item).Id = x;
                ((Item)item).Keys = "Adeudo";
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
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            switch (e.Keys)
            {
                case "Adeudo":

                    mppAdeudo.Show(true);

                    lEditar = true;

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
                    Adeudo.V_OTRA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].V_OTRA;
                    Adeudo.M_ORIGINAL = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].M_ORIGINAL;
                    Adeudo.F_ADEUDO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].F_ADEUDO;
                    Adeudo.M_SALDO = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].M_SALDO;
                    Adeudo.E_CUENTA = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].E_CUENTA.ToString();
                    Adeudo.NID_TITULARs = oDeclaracion.ALTA.ALTA_ADEUDOs[e.Id].ALTA_ADEUDO_TITULARs.Select(p => p.NID_DEPENDIENTE).ToList();
                    break;
                case "AdeudoMod":
                    mppModificaAdeudo.Show(true);

                    IndiceItemSeleccionado = e.Id;
                    cbx.Checked = !oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].L_CANCELADO;

                    //AdeudoModificacion.M_PAGOS = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].M_PAGOS;
                    AdeudoModificacion.M_SALDO = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].M_SALDOS;
                    AdeudoModificacion.NID_TITULARs = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].MODIFICACION_ADEUDO_TITULARs.Select(p => p.NID_DEPENDIENTE).ToList();
                    ((TextBox)AdeudoModificacion.FindControl("txtTIPO_ADEUDO")).Text = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].PATRIMONIO.PATRIMONIO_ADEUDO.V_TIPO_ADEUDO;
                    ((TextBox)AdeudoModificacion.FindControl("txtLugarPais")).Text = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].PATRIMONIO.PATRIMONIO_ADEUDO.V_PAIS;
                    ((TextBox)AdeudoModificacion.FindControl("txtLugarEntidad")).Text = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].PATRIMONIO.PATRIMONIO_ADEUDO.V_ENTIDAD_FEDERATIVA;
                    ((TextBox)AdeudoModificacion.FindControl("txtInstitución")).Text = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].PATRIMONIO.PATRIMONIO_ADEUDO.V_INSTITUCION;
                    ((TextBox)AdeudoModificacion.FindControl("txtMontoOriginal")).Text = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].PATRIMONIO.PATRIMONIO_ADEUDO.M_ORIGINAL.ToString("C");
                    ((TextBox)AdeudoModificacion.FindControl("txtCuenta")).Text = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[e.Id].PATRIMONIO.PATRIMONIO_ADEUDO.E_CUENTA;
                    break;
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
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            ((HtmlControl)Master.FindControl("liAdeudos")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu4")).Attributes.Add("class", "tab-pane fade level1 active in");
            if (!IsPostBack)
            {
                if (oDeclaracion.ALTA.ALTA_ADEUDOs.Count == 0 && oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                    QstBox.Ask("¿Cuenta con adeudos vigentes al dia de hoy?");
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 26).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkAdeudosAct")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkAdeudosAct")).CssClass = "active";

            for (int x = 0; x < oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs.Count; x++)
            {

                UserControl item = (UserControl)Page.LoadControl("itemInv.ascx");
                ((ItemInv)item).Id = x;
                ((ItemInv)item).ID = "AdeudoModif" + x.ToString();
                ((ItemInv)item).Keys = "AdeudoMod";
                ((ItemInv)item).TextoPrincipal = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[x].PATRIMONIO.PATRIMONIO_ADEUDO.V_TIPO_ADEUDO;
                ((ItemInv)item).TextoSecundario = "Número de Cuenta " + oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[x].PATRIMONIO.PATRIMONIO_ADEUDO.E_CUENTA
                                      // + "<br> Monto original  " + oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[x].PATRIMONIO.PATRIMONIO_ADEUDO.M_ORIGINAL.ToString("C") 
                                      + "<br> Saldo Actual  " + oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[x].M_SALDOS.ToString("C")
                                      + " <br> Pagos Anualizados  " + oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[x].M_PAGOS.ToString("C");
                ((ItemInv)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[x].PATRIMONIO.PATRIMONIO_ADEUDO.NID_TIPO_ADEUDO + ".png");
                ((ItemInv)item).Editar += OnEditar;
                if(oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[x].L_MODIFICADO) ((Button)((ItemInv)item).FindControl("btnEditar")).CssClass = "ok";
                grdMod.Controls.AddAt(0 + x, item);
            }


        }

        protected void btnAgregarAdeudo_Click(object sender, EventArgs e)
        {
            mppAdeudo.Show(true);
            lEditar = false;
            Adeudo.Clear();
            Adeudo.NID_TIPO_ADEUDO = 4;
            ((DropDownList)Adeudo.FindControl("cmbNID_TIPO_ADEUDO")).Enabled = false;
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mppAdeudo.Hide();
        }

        public void Anterior()
        {
            Response.Redirect("InversionesModifica.aspx");
        }

        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.ALTA.ALTA_ADEUDOs.Count == 0 && !oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
            { }
            else
            {
                marcaApartado(26);
            }
            Response.Redirect("Observaciones.aspx");
        }

        private void marcaApartado(int NID_APARTADO)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs.Where(p => p.L_MODIFICADO == false).Any()) { }
            else
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

                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 26 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
                {
                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                    {
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO = true;
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().update();
                    }
                }
                oDeclaracion = _oDeclaracion;
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
            try
            {
                //oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].NID_TIPO_ADEUDO = Adeudo.NID_TIPO_ADEUDO;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].NID_PAIS = Adeudo.NID_PAIS;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].CID_ENTIDAD_FEDERATIVA = Adeudo.CID_ENTIDAD_FEDERATIVA;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_LUGAR = Adeudo.V_LUGAR;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].NID_INSTITUCION = Adeudo.NID_INSTITUCION;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_OTRA = Adeudo.V_OTRA;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].E_CUENTA = Adeudo.E_CUENTA;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].F_ADEUDO = Adeudo.F_ADEUDO;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].M_ORIGINAL = Adeudo.M_ORIGINAL.Value;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].M_SALDO = Adeudo.M_SALDO.Value;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_OTRA = Adeudo.V_OTRA;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].V_LUGAR = String.Empty;
                oDeclaracion.ALTA.ALTA_ADEUDOs[Indice].update(Adeudo.NID_TITULARs);

                ((Item)grd.FindControl(String.Concat("grd", Indice))).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", Adeudo.NID_TIPO_ADEUDO, ".png");
                ((Item)grd.FindControl(String.Concat("grd", Indice))).TextoPrincipal = Adeudo.V_TIPO_ADEUDO;
                ((Item)grd.FindControl(String.Concat("grd", Indice))).TextoSecundario = "<br> Número de Cuenta " + Adeudo.E_CUENTA + "<br>Monto original del Adeudo " + Adeudo.M_ORIGINAL.Value.ToString("C") + "<br>  Saldo " + Adeudo.M_SALDO.Value.ToString("C");

                AlertaSuperior.ShowSuccess("Se actualizaron correctamente los datos del adeudo");
                _oDeclaracion = oDeclaracion;
                mppAdeudo.Hide();
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }


        }
        public void NuevoAdeudo()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            try
            {
                //oDeclaracion.ALTA.Add_ALTA_ADEUDOs(
                //                                  Adeudo.NID_PAIS,
                //                                  Adeudo.CID_ENTIDAD_FEDERATIVA,
                //                                  Adeudo.V_LUGAR,
                //                                  Adeudo.NID_INSTITUCION,
                //                                  Adeudo.V_OTRA,
                //                                  Adeudo.NID_TIPO_ADEUDO,
                //                                  Adeudo.F_ADEUDO,
                //                                  Adeudo.M_ORIGINAL.Value,
                //                                  Adeudo.M_SALDO.Value,
                //                                  Adeudo.E_CUENTA,
                //                                  Adeudo.NID_TITULARs);
                AlertaSuperior.ShowSuccess("Se agrego correctamente el adeudo");

                string PasaNombre = Adeudo.V_TIPO_ADEUDO;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).FindControl("btnBaja").Visible = false;
                ((Item)item).Id = oDeclaracion.ALTA.ALTA_ADEUDOs.Count + 1;
                ((Item)item).ID = String.Concat("grd", ((Item)item).Id);
                ((Item)item).TextoPrincipal = PasaNombre;
                ((Item)item).TextoSecundario = "No. Cuenta " + Adeudo.E_CUENTA + "<br>Monto del Adeudo: " + Adeudo.M_ORIGINAL.Value.ToString("C") + "<br>  Saldo : " + Adeudo.M_SALDO.Value.ToString("C");
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", Adeudo.NID_TIPO_ADEUDO, ".png");
                ((Item)item).Editar += OnEditar;
                ((Item)item).Eliminar += OnEliminar;
                grd.Controls.AddAt(grd.Controls.Count - 3, item);
                mppAdeudo.Hide();
                _oDeclaracion = oDeclaracion;
                marcaApartado(26);
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }


        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            marcaApartado(26);
            Response.Redirect("Ingresos.aspx");
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }

        //Adeudo Modificacion

        protected void btnCerrarMod_Click(object sender, EventArgs e)
        {
            mppModificaAdeudo.Hide();
        }
        protected void btnGuardaMod_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            try
            {
                oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[Indice].L_CANCELADO = !cbx.Checked;
                //oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[Indice].M_PAGOS = AdeudoModificacion.M_PAGOS.Value;
                oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[Indice].M_SALDOS = AdeudoModificacion.M_SALDO.Value;
                oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[Indice].update(AdeudoModificacion.NID_TITULARs);
                AlertaSuperiorMod.ShowSuccess("Se actualizaron correctamente los datos del adeudo");
                ((Button)((ItemInv)grdMod.FindControl("AdeudoModif" + Indice.ToString())).FindControl("btnEditar")).CssClass = "ok";
                ((ItemInv)grdMod.FindControl("AdeudoModif" + Indice.ToString())).TextoSecundario = "Número de Cuenta " + oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[Indice].PATRIMONIO.PATRIMONIO_ADEUDO.E_CUENTA
                                      // + "<br> Monto original  " + oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[Indice].PATRIMONIO.PATRIMONIO_ADEUDO.M_ORIGINAL.ToString("C") 
                                      + "<br> Saldo Actual  " + oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[Indice].M_SALDOS.ToString("C")
                                      + " <br> Pagos Anualizados  " + oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs[Indice].M_PAGOS.ToString("C");
                _oDeclaracion = oDeclaracion;
                mppModificaAdeudo.Hide();
                marcaApartado(26);
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
    }
}