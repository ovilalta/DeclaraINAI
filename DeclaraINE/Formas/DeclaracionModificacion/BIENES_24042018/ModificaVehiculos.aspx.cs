using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Declara.BLLD;
using Declara;
using Declara.MODELextended;
using Declara.Exceptions;
using AlanWebControls;

namespace DeclaraINE.Formas.DeclaracionModificacion
{
    public partial class ModificaVehiculos : Pagina, IDeclaracionInicial
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
        internal Boolean lEditarN
        {
            get => (Boolean)ViewState["lEditarN"];
            set => ViewState["lEditarN"] = value;

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

        internal Int32 IndiceSeleccionadoN
        {
            get
            {
                if (ViewState["IndiceSeleccionadoN"] == null) return -1;
                return (Int32)ViewState["IndiceSeleccionadoN"];
            }

            set
            {
                if (ViewState["IndiceSeleccionadoN"] == null) ViewState.Add("IndiceSeleccionadoN", value);
                ViewState["IndiceSeleccionadoN"] = value;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liBienes")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu2")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
           
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkVehiculosAct")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkVehiculosAct")).CssClass = "active";


           
           
        }


        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            PagVehiculo();
            PagGasto();
            PagVehiculoN();
        }
        private void PagGasto()
        {
            ((Button)Master.FindControl("dummy")).Enabled = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
         
                ctrlGastos1.NID_TIPO_GASTO.Add(5);
                ctrlGastos1.OPCIONES = new List<String>();
                ctrlGastos1.OPCIONES.Add("Reparacion Mayor");
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 30).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkImpuestos")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkImpuestos")).CssClass = "active";
        }
        protected void OnGastos(object sender, ItemEventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            mppGasto.Show();
            ctrlGastos1.NID_PATRIMONIO = oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[e.Id].NID_PATRIMONIO;
 


        }
        private void PagVehiculo()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            blld_MODIFICACION_VEHICULO o;
            if (!IsPostBack)
            {
                //((Button)Master.FindControl("btnAnterior")).Visible = true;
                //((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                //((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                //((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";


                blld__l_CAT_MARCA_VEHICULO oMarca = new blld__l_CAT_MARCA_VEHICULO();
                oMarca.OrderByCriterios.Add(new Declara.Order(CAT_MARCA_VEHICULO.Properties.V_MARCA));
                oMarca.select();
                cmbMarca.DataBind(oMarca.lista_CAT_MARCA_VEHICULO, CAT_MARCA_VEHICULO.Properties.NID_MARCA, CAT_MARCA_VEHICULO.Properties.V_MARCA);
                dpModelo.DataSource = oUsuario.CAT_AGNO;
                dpModelo.DataBind();
                blld__l_CAT_USO_VEHICULO oUV = new blld__l_CAT_USO_VEHICULO();
                oUV.select();
                dpTipoUso.DataBind(oUV.lista_CAT_USO_VEHICULO, CAT_USO_VEHICULO.Properties.NID_USO, CAT_USO_VEHICULO.Properties.V_USO);
                chbDependietesVehiculo.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietesVehiculo.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietesVehiculo.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietesVehiculo.DataBind();
                chbDependietesVehiculo.Items.Insert(0, new ListItem("DECLARANTE", "0"));
            }
            for (int x = 0; x < oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs.Count; x++)
            {
                o = oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[x];
                UserControl item = (UserControl)Page.LoadControl("ItemVeh.ascx");
                ((ItemVeh)item).Id = x;
                ((ItemVeh)item).ID = String.Concat("Vehiculo_P", x);
                ((ItemVeh)item).TextoPrincipal = o.V_MARCA.ToString();
                ((ItemVeh)item).TextoSecundario = o.V_DESCRIPCION;
                ((ItemVeh)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_VEHICULO/", x, ".png");
                ((ItemVeh)item).Editar += OnEditar;
                //((Button)((ItemVeh)item).FindControl("btnEliminar")).Text = "Gastos";
                ((Button)((ItemVeh)item).FindControl("btnRepara")).Visible = false;
                //((ItemVeh)item).Eliminar += OnGastos;
                ((Button)((ItemVeh)item).FindControl("btnRepara")).Visible = false;
                ((ItemVeh)item).Bajar += OnBaja;
                // ((Item)item).Eliminar += OnEliminar;

                grd.Controls.AddAt(0 + x, item);
            }
        }

            public void Anterior()
        {
            Response.Redirect("ModificaMuebles.aspx");
        }
        public void Siguiente()
        {
            Response.Redirect("Desincorpora.aspx");
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

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 8, 9, 10, 18, 19, 20, 21 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
            {
                if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO.Value)
                {
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO = true;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().update();
                }
            }
        }
        protected void btnCerrarMppVehículos_Click(object sender, EventArgs e)
        {
            mppVehículos.Hide();
        }
        protected void btnGuardarVehiculo_Click(object sender, EventArgs e)
        {
            if (lEditar)
            {
                EditarVehiculo();
                String msg = "Se actualizarón correctamente los datos del vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
           
        }
        private void EditarVehiculo()
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceItemSeleccionado;
            try
            {
                oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[Indice].NID_MARCA= cmbMarca.SelectedValue();
                oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[Indice].V_DESCRIPCION = txtTipo.Text;
                oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[Indice].C_MODELO= dpModelo.SelectedItem.ToString();
                oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[Indice].NID_USO= dpTipoUso.SelectedValue();
                oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[Indice].F_ADQUISICION= txtFechaAdquisicionVehiculo.Date(esMX);
                oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[Indice].update(chbDependietesVehiculo.SelectedValuesInteger());
                marcaApartado(ref oDeclaracion,20);
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

        protected void OnEditar(object sender, ItemEventArgs e)
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_MODIFICACION_VEHICULO v;
            lEditar = true;
            mppVehículos.HeaderText = "Editar vehiculo";
            mppVehículos.Show(true);
            cmbFAdquisicionM.SelectedValue = "";
            v = oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[e.Id];
            IndiceItemSeleccionado = e.Id;

            cmbMarca.SelectedValue = v.NID_MARCA.ToString();
            //cmbTipoVehiculo.SelectedValue = v.NID_TIPO_VEHICULO.ToString();
            txtTipo.Text = v.V_DESCRIPCION.ToString();
            txtFechaAdquisicionVehiculo.Text = v.F_ADQUISICION.ToString(strFormatoFecha);
            dpModelo.SelectedItem.Text = v.C_MODELO.ToString();
            moneytxtValorAdquisicion.Text = v.M_VALOR_VEHICULO.ToString();
            dpTipoUso.SelectedItem.Value = v.NID_USO.ToString();
            //checaAdeudoVehiculo();
            chbDependietesVehiculo.ClearSelection();

            foreach (blld_MODIFICACION_VEHICULO_TITU item in v.MODIFICACION_VEHICULO_TITUs)
            {
                chbDependietesVehiculo.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ctrlGastos1.btnGuardar(sender, e);
            AlertaSuperior1.ShowSuccess("Se guardó correctamente la información");
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ctrlGastos1.btnAgregar(sender, e);
        }
        protected void btnXGasto_Click(object sender, EventArgs e)
        {
            mppGasto.Hide();
        }

        protected void OnBaja(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            Int32 nid = oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[e.Id].NID_PATRIMONIO;

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
            AlertaSuperior.ShowSuccess("Se guardó exitosamenta la baja del bien patrimonial");
        }

        protected void btnEliminarBaja_Click(object sender, EventArgs e)
        {
            ctrlDesincorpora1.Elimina();
            mppBaja.Hide();
            AlertaSuperior.ShowSuccess("Se eliminó exitosamenta la baja del bien patrimonial");
        }
        //   A partir de aquí todo lo integrado
        protected void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            lEditarN = false;
            InfoAdeudo = null;
            mppVehículosN.HeaderText = "Agregar vehiculo";
            mppVehículosN.Show(true);
            dpModeloN.ClearSelection();
            cmbMarcaN.ClearSelection();
            cmbTipoVehiculoN.ClearSelection();
            txtTipoN.Text = string.Empty;
            txtFechaAdquisicionVehiculoN.Text = string.Empty;
            moneytxtValorAdquisicionN.Text = String.Empty;
            checaAdeudoVehiculo();
            dpTipoUsoN.ClearSelection();
            chbDependietesVehiculoN.ClearSelection();
        }




        private void PagVehiculoN()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            if (!IsPostBack)
            {
                blld__l_CAT_MARCA_VEHICULO oMarca = new blld__l_CAT_MARCA_VEHICULO();
                oMarca.OrderByCriterios.Add(new Declara.Order(CAT_MARCA_VEHICULO.Properties.V_MARCA));
                oMarca.select();
                cmbMarcaN.DataBind(oMarca.lista_CAT_MARCA_VEHICULO, CAT_MARCA_VEHICULO.Properties.NID_MARCA, CAT_MARCA_VEHICULO.Properties.V_MARCA);
                cmbMarcaN.Items.Insert(0, new ListItem(String.Empty));
                dpModeloN.DataSource = oUsuario.CAT_AGNO;
                dpModeloN.DataBind();
                dpModeloN.Items.Insert(0, new ListItem(String.Empty));
                cmbTipoVehiculoN.DataBinder<blld__l_CAT_TIPO_VEHICULO>(new blld__l_CAT_TIPO_VEHICULO(), CAT_TIPO_VEHICULO.Properties.NID_TIPO_VEHICULO, CAT_TIPO_VEHICULO.Properties.V_TIPO_VEHICULO);
                blld__l_CAT_USO_VEHICULO oUV = new blld__l_CAT_USO_VEHICULO();
                cmbTipoVehiculoN.Items.Insert(0, new ListItem(String.Empty));
                oUV.select();
                dpTipoUsoN.DataBind(oUV.lista_CAT_USO_VEHICULO, CAT_USO_VEHICULO.Properties.NID_USO, CAT_USO_VEHICULO.Properties.V_USO);
                dpTipoUsoN.Items.Insert(0, new ListItem(String.Empty));
                chbDependietesVehiculoN.DataSource = oDeclaracion.DECLARACION_DEPENDIENTESs;
                chbDependietesVehiculoN.DataTextField = DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO.ToString();
                chbDependietesVehiculoN.DataValueField = DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE.ToString();
                chbDependietesVehiculoN.DataBind();
                chbDependietesVehiculoN.Items.Insert(0, new ListItem("DECLARANTE", "0"));
            }
            ////Dependientes
            blld_ALTA_VEHICULO v;
            for (int x = 0; x < oDeclaracion.ALTA.ALTA_VEHICULOs.Count(); x++)
            {
                v = oDeclaracion.ALTA.ALTA_VEHICULOs[x];
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).ID = String.Concat("Vehiculo_", x);
                ((Item)item).TextoPrincipal = v.V_MARCA.ToString();
                ((Item)item).TextoSecundario = v.V_DESCRIPCION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_VEHICULO/", x, ".png");
                ((Item)item).Editar += OnEditarN;
                ((Item)item).Eliminar += OnEliminarN;
                ((Item)item).Bajar += OnBajaN;
                grdVehiculos.Controls.AddAt(0 + x, item);
            }
        }

        protected void OnEditarN(object sender, ItemEventArgs e)
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_VEHICULO v;
            lEditarN = true;
            mppVehículosN.HeaderText = "Editar vehiculo";
            mppVehículosN.Show(true);
            v = oDeclaracion.ALTA.ALTA_VEHICULOs[e.Id];
            IndiceSeleccionadoN = e.Id;
            cmbMarcaN.SelectedValue = v.NID_MARCA.ToString();
            cmbTipoVehiculoN.SelectedValue = v.NID_TIPO_VEHICULO.ToString();
            txtTipoN.Text = v.V_DESCRIPCION.ToString();
            txtFechaAdquisicionVehiculoN.Text = v.F_ADQUISICION.ToString(strFormatoFecha);
            dpModeloN.SelectedItem.Text = v.C_MODELO.ToString();
            moneytxtValorAdquisicionN.Text = v.M_VALOR_VEHICULO.ToString();
            dpTipoUsoN.SelectedItem.Value = v.NID_USO.ToString();
            checaAdeudoVehiculo();
            chbDependietesVehiculoN.ClearSelection();
            foreach (blld_ALTA_VEHICULO_TITULAR item in v.ALTA_VEHICULO_TITULARs)
                    {
                        chbDependietesVehiculoN.Items.FindByValue(item.NID_DEPENDIENTE.ToString()).Selected = true;
                    }
        }
        protected void OnBajaN(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            mppBaja.Show(true);
            Int32 nid;
            nid = oDeclaracion.ALTA.ALTA_VEHICULOs[e.Id].NID_PATRIMONIO;
            if (oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == nid).Any())
                ctrlDesincorpora1.llena(nid);
            else
            {
                ctrlDesincorpora1.NID_PATRIMONIO = nid;
                ctrlDesincorpora1.limpia();
            }

        }
        protected void OnEliminarN(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            
                    try
                    {
                        oDeclaracion.ALTA.ALTA_VEHICULOs.RemoveAt(e.Id);
                        _oDeclaracion = oDeclaracion;
                        grdVehiculos.Controls.Remove(grdVehiculos.FindControl(String.Concat("Vehiculo_", e.Id)));
                        AlertaSuperior.ShowSuccess("Se eliminó correctamente el vehículo");
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

        #region Fuera de lugar 
        enum OrigenesAdeudo
        {
           // Inmuebles,
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
        private Boolean lEditaAdeudoM
        {
            get => (Boolean)ViewState["lEditaAdeudoM"];
            set => ViewState.Add("lEditaAdeudoM", value);
        }
        private PreAduedo InfoAdeudo
        {
            get => (PreAduedo)ViewState["InfoAdeudo"];
            set => ViewState.Add("InfoAdeudo", value);
        }

        private PreAduedo InfoAdeudoM
        {
            get => (PreAduedo)ViewState["InfoAdeudo"];
            set => ViewState.Add("InfoAdeudo", value);
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
            internal List<Int32> NID_TITULARs { get; set; }
        }

        #endregion

       

        //protected void cbxAdeudoVehiculo_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (cbxAdeudoVehiculo.Checked)
        //    {
        //        mppVehículosN.Hide();
        //        mppAdeudos.Show(true);
        //        Adeudo.Requerido = btnGuardarAdeudoVehiculo.ClientID;
        //        mppAdeudos.HeaderText = "Adeudo por concepto de crédito automotriz";
                
        //        btnCerrarModalVehiculo.Visible = true;
        //        btnGuardarAdeudoVehiculo.Visible = true;
        //        Adeudo.Clear();
        //        Adeudo.NID_TIPO_ADEUDO = 2;
        //        lEditaAdeudo = false;
        //        InfoAdeudo = null;
        //        MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
        //    }
        //}
        protected void cmbFAdquisicionN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFAdquisicionN.SelectedValue=="2")
            {
                mppVehículosN.Hide();
                mppAdeudos.Show(true);
                Adeudo.Requerido = btnGuardarAdeudoVehiculo.ClientID;
                mppAdeudos.HeaderText = "Adeudo por concepto de crédito automotriz";

                btnCerrarModalVehiculo.Visible = true;
                btnGuardarAdeudoVehiculo.Visible = true;
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 2;
                lEditaAdeudo = false;
                InfoAdeudo = null;
                MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
            }
            else
            {
                mppVehículosN.Show();
                // mppAdeudos.Show(true);
                mppAdeudos.Hide();
                Adeudo.Requerido = btnGuardarAdeudoVehiculo.ClientID;
                //mppAdeudos.HeaderText = "Adeudo por concepto de crédito automotriz";

                btnCerrarModalVehiculo.Visible = false;
                btnGuardarAdeudoVehiculo.Visible = false;
                Adeudo.Clear();
                Adeudo.NID_TIPO_ADEUDO = 2;
                lEditaAdeudo = true;
                //InfoAdeudo = null;
               // MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
            }
        }
        protected void btnModificarAdeudoVehiculo_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceSeleccionadoN;
            IndiceAdeudoSeleccionado = 0;
            Int32 IndiceAdeudo = this.IndiceAdeudoSeleccionado;
            mppAdeudos.Show(true);
            Adeudo.Requerido = btnGuardarAdeudoVehiculo.ClientID;
            mppAdeudos.HeaderText = "Adeudo por concepto de crédito automotriz";
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
            mppVehículosN.Hide();
        }
        protected void btnCerrarModalVehiculo_Click(object sender, EventArgs e)
        {
            mppVehículosN.Show(true);
            InfoAdeudo = null;
            mppAdeudos.Hide();
            checaAdeudoVehiculo();
        }
        void checaAdeudoVehiculo()
        {
            Boolean lPreadeudo = InfoAdeudo != null;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            btnEditarAdeudoVehiculo.Visible = true;
            Int32 Indice = IndiceSeleccionadoN;
            Boolean lAdeudo;
            try
            { lAdeudo = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs.Any(); }
            catch { lAdeudo = false; }
            if (lAdeudo)
                cmbFAdquisicionN.SelectedValue = "2";
              else
                cmbFAdquisicionN.SelectedValue =string.Empty;
            if (lEditarN)
            {
                //cbxAdeudoVehiculo.Checked = (lAdeudo || lPreadeudo);
                if (cmbFAdquisicionN.SelectedValue == "2")
                    tblAdeudoVehiculo.Visible = true;
                else
                    tblAdeudoVehiculo.Visible = false;
                //cbxAdeudoVehiculo.Enabled = !cbxAdeudoVehiculo.Checked;

            }
            else
            {
                if (lPreadeudo)
                {
                    btnEditarAdeudoVehiculo.Visible = false;
                    //cbxAdeudoVehiculo.Checked = (lAdeudo || lPreadeudo);
                    if (cmbFAdquisicionN.SelectedValue == "2")
                        tblAdeudoVehiculo.Visible = true;
                    else
                        tblAdeudoVehiculo.Visible = false;
                    //cbxAdeudoVehiculo.Enabled = !cbxAdeudoVehiculo.Checked;

                }
                else
                {
                    //cbxAdeudoVehiculo.Checked = false;
                    if (cmbFAdquisicionN.SelectedValue == "2")
                        tblAdeudoVehiculo.Visible = true;
                    else
                        tblAdeudoVehiculo.Visible = false;
                    // cbxAdeudoVehiculo.Enabled = !cbxAdeudoVehiculo.Checked;
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
        protected void btnEliminarAdeudo_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceSeleccionadoN;
            if (InfoAdeudo == null)
            {
                try
                {
                    oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                    oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[0].deleteConVehiculo(oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_VEHICULO);
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
        protected void btnCerrarMppVehículosN_Click(object sender, EventArgs e)
        {
            mppVehículosN.Hide();
        }
        protected void btnGuardarVehiculo2N_Click(object sender, EventArgs e)
        {
            if (lEditarN)
            {
                EditarVehiculoN();
                String msg = "Se actualizarón correctamente los datos del vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarVehiculoN();
                String msg = "Se agregó correctamente el vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
        }
        private void EditarVehiculoN()
        {

            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Int32 Indice = IndiceSeleccionadoN;
            try
            {

                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_TIPO_VEHICULO = cmbTipoVehiculoN.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_MARCA = cmbMarcaN.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].V_DESCRIPCION = txtTipoN.Text;
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].C_MODELO = dpModeloN.SelectedItem.ToString();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_USO = dpTipoUsoN.SelectedValue();
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].F_ADQUISICION = txtFechaAdquisicionVehiculoN.Date(esMX);
                oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].update(chbDependietesVehiculoN.SelectedValuesInteger());
                mppVehículosN.Hide();
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


        private void GuardarVehiculoN()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_VEHICULO v;

            try
            {
                oDeclaracion.ALTA.Add_ALTA_VEHICULOs(
                                                    cmbTipoVehiculoN.SelectedValue()
                                                    , cmbMarcaN.SelectedValue()
                                                   , dpModeloN.SelectedValue
                                                   , txtTipoN.Text
                                                   , txtFechaAdquisicionVehiculoN.Date(esMX)
                                                   , dpTipoUsoN.SelectedValue()
                                                   , moneytxtValorAdquisicionN.Money()
                                                   , chbDependietesVehiculoN.SelectedValuesInteger());
                marcaApartado(ref oDeclaracion, 20);
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

                int x = grdVehiculos.Controls.Count - 3;
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = x;
                ((Item)item).TextoPrincipal = v.V_MARCA;
                ((Item)item).TextoSecundario = v.V_DESCRIPCION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_VEHICULO/", x, ".png");
                ((Item)item).Editar += OnEditarN;
                ((Item)item).Eliminar += OnEliminarN;
                ((Item)item).Bajar += OnBajaN;
                grdVehiculos.Controls.AddAt(x, item);

                mppVehículosN.Hide();
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
        }

        protected void btnGuardarVehiculoN_Click(object sender, EventArgs e)
        {
            if (lEditarN)
            {
                EditarVehiculoN();
                String msg = "Se actualizarón correctamente los datos del vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
            else
            {
                GuardarVehiculoN();
                String msg = "Se agregó correctamente el vehículo";
                AlertaSuperior.ShowSuccess(msg);
            }
        }
        protected void btnGuardarAdeudoVehiculo_Click(object sender, EventArgs e)
        {
            mppVehículosN.Show(true);
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            try
            {

                if (Adeudo.M_ORIGINAL.HasValue)
                    if (Adeudo.M_ORIGINAL > moneytxtValorAdquisicionN.Money())
                        throw new CustomException("El monto original del adeudo no puede ser mayor que el valor del vehículo asociado");
                if (Adeudo.F_ADEUDO > txtFechaAdquisicionVehiculoN.Date())
                    throw new CustomException("La fecha del adeudo no puede ser mayor que la fecha de adquisición del vehículo asociado");
                if (lEditarN)
                {

                    Int32 Indice = IndiceSeleccionadoN;
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
                               , Adeudo.V_LUGAR
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
                        V_LUGAR = Adeudo.V_LUGAR,
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
        // Codigo Nuevo 23/04/2018

        protected void cmbFAdquisicionM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFAdquisicionM.SelectedValue == "2")
            {
                mppVehículos.Hide();
                mppAdeudosM.Show(true);
                AdeudoM.Requerido = btnGuardarAdeudoVehiculoM.ClientID;
                mppAdeudosM.HeaderText = "Adeudo por concepto de crédito automotriz";

                btnCerrarModalVehiculoM.Visible = true;
                btnGuardarAdeudoVehiculoM.Visible = true;
                AdeudoM.Clear();
                AdeudoM.NID_TIPO_ADEUDO = 2;
                //lEditaAdeudo = false;
                //InfoAdeudo = null;
                MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
            }
            else
            {
                mppVehículos.Show();
                mppAdeudosM.Hide();
                AdeudoM.Requerido = btnGuardarAdeudoVehiculoM.ClientID;
                //mppAdeudos.HeaderText = "Adeudo por concepto de crédito automotriz";

                btnCerrarModalVehiculoM.Visible = false;
                btnGuardarAdeudoVehiculoM.Visible = false;
                AdeudoM.Clear();
                AdeudoM.NID_TIPO_ADEUDO = 2;
                // lEditaAdeudo = true;
                //InfoAdeudo = null;
                // MsgBox.ShowInfo("Por favor capture los datos correspondientes al adeudo");
            }
        }
        protected void btnModificarAdeudoVehiculoM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            IndiceAdeudoSeleccionado = 0;
            Int32 IndiceAdeudo = this.IndiceAdeudoSeleccionado;
            mppAdeudosM.Show(true);
            AdeudoM.Requerido = btnGuardarAdeudoVehiculoM.ClientID;
            mppAdeudosM.HeaderText = "Adeudo por concepto de crédito automotriz";
            btnCerrarModalVehiculoM.Visible = true;
            btnGuardarAdeudoVehiculoM.Visible = true;
            lEditaAdeudoM = true;
            AdeudoM.NID_PAIS = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_PAIS;
            AdeudoM.CID_ENTIDAD_FEDERATIVA = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].CID_ENTIDAD_FEDERATIVA;
            AdeudoM.V_LUGAR = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_LUGAR;
            AdeudoM.NID_INSTITUCION = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].NID_INSTITUCION;
            AdeudoM.V_OTRA = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].V_OTRA;
            AdeudoM.F_ADEUDO = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].F_ADEUDO;
            AdeudoM.M_ORIGINAL = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_ORIGINAL;
            AdeudoM.M_SALDO = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].M_SALDO;
            AdeudoM.E_CUENTA = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].E_CUENTA;
            AdeudoM.NID_TITULARs = oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[IndiceAdeudo].ALTA_ADEUDO_TITULARs.Select(p => p.NID_DEPENDIENTE).ToList();
            //checaAdeudoVehiculo();
            mppVehículos.Hide();
        }
        protected void btnEliminarAdeudoM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 Indice = IndiceItemSeleccionado;
            if (InfoAdeudoM == null)
            {
                try
                {
                    oDeclaracion.ALTA.Reload_ALTA_ADEUDOs();
                    oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].ALTA_ADEUDOs[0].deleteConVehiculo(oDeclaracion.ALTA.ALTA_VEHICULOs[Indice].NID_VEHICULO);
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
                InfoAdeudoM = null;
            }
            //checaAdeudoVehiculo();
        }
        protected void btnCerrarModalVehiculoM_Click(object sender, EventArgs e)
        {
            mppVehículos.Show(true);
            InfoAdeudoM = null;
            mppAdeudosM.Hide();
            //checaAdeudoVehiculo();
        }
        protected void btnGuardarAdeudoVehiculoM_Click(object sender, EventArgs e)
        {
        }
        private void Verificar_Titulares(string D_Nom, string D_Fec, string D_Hom, int IDecla)
        {
            //int SinTitular = 0;

            //MODELDeclara.cnxDeclara con = new MODELDeclara.cnxDeclara();
            //var query = from resultado in con.paTITULAR_MODIF_VEHICULO(D_Nom, D_Fec, D_Hom, IDecla);

            //Sc.Me.GrDBDataContext con = new actualizaAlt.Sc.Me.GrDBDataContext();
            //var query = from resultado in con.actualizaAlt(id_alt)
            //            select new LlenaAlerta
            //            {
            //                alerta = resultado.id_alt
            //                   mensaje = resultado.Descr
            //            };
            //return query.ToList();

                           //MODELDeclara.cnxDeclara BDTitulares = new MODELDeclara.cnxDeclara();
                           //var p = BDTitulares.paTITULAR_MODIF_VEHICULO(D_Nom, D_Fec, D_Hom, IDecla);
                           //    select p;


                           //foreach (var d in p)

                           //{
                           //    SinTitular = p.CHECA_TITULAR;
                           // }
        }


        public class Titulares

        {

            public int CHECA_TITULAR { get; set; }
           

        }
    }
}