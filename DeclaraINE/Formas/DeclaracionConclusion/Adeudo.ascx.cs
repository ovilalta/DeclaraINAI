using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;

namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class Adeudo : System.Web.UI.UserControl
    {
        public String Requerido
        {
            get
            {
                if (ViewState["req"] == null)
                    return String.Empty;
               return ViewState["req"].ToString();
            }
            set
            {
                ViewState["req"] = value;
                req();
            }
        }
        private void SessionAdd(String ObjectName, Object Objeto)
        {
            if (Session[ObjectName] == null) Session.Add(ObjectName, Objeto);
            else Session[ObjectName] = Objeto;
        }

        private blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        private blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }
        public Int32 NID_TIPO_ADEUDO
        {
            get => cmbNID_TIPO_ADEUDO.SelectedValue();
            set => cmbNID_TIPO_ADEUDO.SelectedValue = value.ToString();
        }

        public String V_TIPO_ADEUDO
        {
            get => cmbNID_TIPO_ADEUDO.SelectedItem.Text;
        }

        public Int32 NID_PAIS
        {
            get => cmbNID_PAIS.SelectedValue();
            set
            {
                cmbNID_PAIS.SelectedValue = value.ToString();
                cmbNID_PAIS_SelectedIndexChanged(cmbNID_PAIS, null);
            }
        }

        public String CID_ENTIDAD_FEDERATIVA
        {
            get => cmbCID_ENTIDAD_FEDERATIVA.SelectedValue;
            set => cmbCID_ENTIDAD_FEDERATIVA.SelectedValue = value;
        }

        public Int32 NID_INSTITUCION
        {
            get => cmbNID_INSTITUCION.SelectedValue();
            set
            {
                cmbNID_INSTITUCION.SelectedValue = value.ToString();
                cmbNID_INSTITUCION_SelectedIndexChanged(cmbNID_INSTITUCION, null);
            }
        }
        public String CID_TIPO_PERSONA_OTORGANTE
        {
            get => cmbOtorgante_credito.SelectedValue;
            set
            {
                cmbOtorgante_credito.SelectedValue = value;
                //cmbOtorgante_credito_SelectedIndexChanged(cmbOtorgante_credito, null);
            }

        }

        public String NID_TERCERO
        {
            get => cmbTercero.SelectedValue;
            set
            {
                cmbTercero.SelectedValue = value;
            }

        }

        public String E_RFC_TERCERO
        {
            get => txtRfc_Terceros.Text;
            set => txtRfc_Terceros.Text = value;
        }

        public String E_NOMBRE_TERCERO
        {
            get => txtNombre_terceros.Text;
            set => txtNombre_terceros.Text = value;
        }
        public String V_LUGAR
        {
            get
            {
                if (NID_PAIS != 1)
                    return txtV_LUGAR.Text;
                else
                    return String.Empty;
            }
            set
            {
                if (NID_INSTITUCION != 1)
                    txtV_LUGAR.Text = value;
                else
                    txtV_LUGAR.Text = String.Empty;
            }
        }

        public String V_OTRA
        {
            get
            {
                if (NID_INSTITUCION == 999)
                    return txtV_OTRO.Text;
                else
                    return String.Empty;
            }
            set
            {
                if (NID_INSTITUCION == 999)
                    txtV_OTRO.Text = value;
                else
                    txtV_OTRO.Text = String.Empty;
            }
        }

        public DateTime F_ADEUDO
        {
            get => txtF_ADEUDO.Date(Pagina.esMX);
            set => txtF_ADEUDO.Text = value.ToString(Pagina.strFormatoFecha);
        }

        public System.Nullable<Decimal> M_ORIGINAL
        {
            get => moneytxtM_ORIGINAL.MoneyNullable();
            set
            {
                if (value.HasValue)
                    moneytxtM_ORIGINAL.Text = value.Value.ToString("C");
                else
                    moneytxtM_ORIGINAL.Text = String.Empty;
            }
        }

        public System.Nullable<Decimal> M_SALDO
        {
            get => moneytxtM_SALDO.MoneyNullable();
            set
            {
                if (value.HasValue)
                    moneytxtM_SALDO.Text = value.Value.ToString("C");
                else
                    moneytxtM_SALDO.Text = String.Empty;
            }
        }

        public String E_CUENTA
        {
            get => txtE_CUENTA.Text;
            set => txtE_CUENTA.Text = value;
        }

        public String NOM_MONEDA
        {
            get => ddlTipoMonedaInm.SelectedValue;
            set
            {
                ddlTipoMonedaInm.SelectedValue = value;
            }
        }

        public String V_TIPO_MONEDA
        {
            get => txtTipo_Moneda.Text;
            set => txtTipo_Moneda.Text = value;
        }       

        public String E_RFC
        {
            get => txtRfc.Text;
            set => txtRfc.Text = value;
        }

        public String E_OBSERVACIONES
        {
            get => txtObservaciones.Text;
            set => txtObservaciones.Text = value;
        }

        public List<Int32> NID_TITULARs
        {
            get
            {
                if (cblTitulares.SelectedValuesInteger() == null && chbDependietesInm.Items.Count.Equals(0))
                    return new List<Int32>();
                else
                    //return cblTitulares.SelectedValuesInteger();
                    return new List<Int32>() { Int32.Parse(chbDependietesInm.SelectedValue) };
            }
            set
            {
                cblTitulares.ClearSelection();
                if (value != null)
                    foreach (Int32 ID in value)
                        cblTitulares.Items.FindByValue(ID.ToString()).Selected = true;
            }
        }
        //public List<Int32> NID_TITULARs
        //{
        //    get
        //    {
        //        if (cblTitulares.SelectedValuesInteger() == null)
        //            return new List<Int32>();
        //        else
        //            return cblTitulares.SelectedValuesInteger();
        //    }
        //    set
        //    {
        //        cblTitulares.ClearSelection();
        //        if (value != null)
        //            foreach (Int32 ID in value)
        //                cblTitulares.Items.FindByValue(ID.ToString()).Selected = true;
        //    }
        //}

        public Int32 IndiceItemSeleccionado
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                req();
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                //cblTitulares.DataBind(oDeclaracion.DECLARACION_DEPENDIENTESs, DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE, DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO);
                //cblTitulares.Items.Insert(0, new ListItem("Declarante", "0"));
                //cblTitulares.Items.Insert(cblTitulares.Items.Count, new ListItem("Copropietario", "-1"));
                cblTitulares.Items.Insert(0, new ListItem("Declarante", "0"));
                cblTitulares.Items.Insert(1, new ListItem("Declarante y Cónyuge", "1"));
                cblTitulares.Items.Insert(2, new ListItem("Declarante y Cónyuge en Copropiedad con Terceros", "2"));
                cblTitulares.Items.Insert(3, new ListItem("Declarante en Copropiedad con Terceros", "3"));
                cblTitulares.Items.Insert(4, new ListItem("Declarante y Concubina o Concubinario", "4"));
                cblTitulares.Items.Insert(5, new ListItem("Declarante y Concubina o Concubinario en Copropiedad con Terceros", "5"));
                cblTitulares.Items.Insert(6, new ListItem("Cónyuge", "6"));
                cblTitulares.Items.Insert(7, new ListItem("Cónyuge en Copropiedad con Terceros", "7"));
                cblTitulares.Items.Insert(8, new ListItem("Concubina o Concubinario", "8"));
                cblTitulares.Items.Insert(9, new ListItem("Concubina o Concubinario en Copropiedad con Terceros", "9"));
                cblTitulares.Items.Insert(10, new ListItem("Conviviente", "10"));
                cblTitulares.Items.Insert(11, new ListItem("Declarante y Conviviente", "11"));
                cblTitulares.Items.Insert(12, new ListItem("Declarante y Conviviente en Copropiedad con Terceros", "12"));
                cblTitulares.Items.Insert(13, new ListItem("Conviviente y Dependiente Económico", "13"));
                cblTitulares.Items.Insert(14, new ListItem("Conviviente y Dependiente Económico en Copropiedad con Terceros", "14"));
                cblTitulares.Items.Insert(15, new ListItem("Dependiente Económico", "15"));
                cblTitulares.Items.Insert(16, new ListItem("Declarante y Dependiente Económico", "16"));
                cblTitulares.Items.Insert(17, new ListItem("Dependiente Económico en Copropiedad con Terceros", "17"));
                cblTitulares.Items.Insert(18, new ListItem("Declarante, Cónyuge y Dependiente Económico", "18"));
                cblTitulares.Items.Insert(19, new ListItem("Declarante, Concubina o Concubinario y Dependiente Económico", "19"));
                cblTitulares.Items.Insert(20, new ListItem("Cónyuge y Dependiente Económico", "20"));
                cblTitulares.Items.Insert(21, new ListItem("Concubina o Concubinario y Dependiente Económico", "21"));
                cblTitulares.Items.Insert(22, new ListItem("Cónyuge y Dependiente Económico en Copropiedad con Terceros", "22"));
                cblTitulares.Items.Insert(23, new ListItem("Concubina o Concubinario y Dependiente Económico en Copropiedad con Terceros", "23"));
                cblTitulares.Items.Insert(24, new ListItem(" Declarante y dependiente económico en copropiedad con terceros", "24"));
                cblTitulares.Items.Insert(cblTitulares.Items.Count, new ListItem("Copropietario", "-1"));


                cmbNID_PAIS.DataBinder<blld__l_CAT_PAIS>(new blld__l_CAT_PAIS(), CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbNID_PAIS.Items.Insert(0, new ListItem(String.Empty));
                blld__l_CAT_INST_FINANCIERA oInstitucion = new blld__l_CAT_INST_FINANCIERA();
                oInstitucion.OrderByCriterios.Add(new Declara_V2.Order(CAT_INST_FINANCIERA.Properties.V_INSTITUCION));
                oInstitucion.select();
                cmbNID_INSTITUCION.DataBind(oInstitucion.lista_CAT_INST_FINANCIERA, CAT_INST_FINANCIERA.Properties.NID_INSTITUCION, CAT_INST_FINANCIERA.Properties.V_INSTITUCION, false);

                cmbNID_INSTITUCION.Items.Insert(0, new ListItem(String.Empty));
                //cmbNID_INSTITUCION.Items.Insert(0, new ListItem("Seleccione", ""));
                blld__l_CAT_TIPO_ADEUDO oTipoAdeudo = new blld__l_CAT_TIPO_ADEUDO();
                oTipoAdeudo.L_ACTIVO = true;
                oTipoAdeudo.select();
                cmbNID_TIPO_ADEUDO.DataBind(oTipoAdeudo.lista_CAT_TIPO_ADEUDO, CAT_TIPO_ADEUDO.Properties.NID_TIPO_ADEUDO, CAT_TIPO_ADEUDO.Properties.V_TIPO_ADEUDO, false);
                cmbNID_TIPO_ADEUDO.Items.Insert(0, new ListItem(String.Empty));
                txtF_ADEUDO_C.StartDate = new DateTime(1900, 1, 1);
                txtF_ADEUDO_C.EndDate = DateTime.Today.AddDays(-1);

                //tipo de moneda
                var cnx = new MODELDeclara_V2.cnxDeclara();
                var lista = cnx.CAT_MONEDA;
                ddlTipoMonedaInm.DataTextField = "V_CODIGO_MONEDA";
                ddlTipoMonedaInm.DataValueField = "NID_MONEDA";
                ddlTipoMonedaInm.DataSource = lista.ToList();
                ddlTipoMonedaInm.DataBind();
                ddlTipoMonedaInm.SelectedValue = "101";
                ddlTipoMonedaInm_SelectedIndexChanged(sender, e);

            }
        }
        protected void ddlTipoMonedaInm_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtTipo_Moneda
            // txtTipo_Moneda.Text = ddlTipoMonedaInm.SelectedValue.ToString() + '|' + ddlTipoMonedaInm.SelectedItem.Text;
            txtTipo_Moneda.Text = ddlTipoMonedaInm.SelectedValue.ToString();
        }
        private void req()
        {
            if (!String.IsNullOrEmpty(Requerido))
            {
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is TextBox)
                    {
                        ((TextBox)ctr).Attributes.Add("requerido", Requerido);
                    }
                    else if (ctr is DropDownList)
                    {
                        ((DropDownList)ctr).Attributes.Add("requerido", Requerido);
                    }
                }
            }
        }

        protected void cmbNID_PAIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(NID_PAIS);
            oEntidadFederativa.select();
            cmbCID_ENTIDAD_FEDERATIVA.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA.ToString(), CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            //if (NID_PAIS != 1) txtV_LUGAR.Visible = true;
            //else txtV_LUGAR.Visible = false;
        }

        protected void cmbNID_INSTITUCION_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NID_INSTITUCION == 999) txtV_OTRO.Visible = true;
            else txtV_OTRO.Visible = false;
        }

        public void Clear()
        {
            try { cmbNID_TIPO_ADEUDO.SelectedIndex = 0; } catch { }
            try { cmbNID_PAIS.SelectedIndex = 0; cmbNID_PAIS_SelectedIndexChanged(cmbNID_PAIS, null); } catch { }
            txtV_LUGAR.Text = String.Empty;
            try { cmbNID_INSTITUCION.SelectedIndex = 0; } catch { }
            txtRfc.Text = String.Empty;
            txtV_OTRO.Text = String.Empty;
            txtV_OTRO.Visible = false;
            txtF_ADEUDO.Text = String.Empty;
            moneytxtM_ORIGINAL.Text = String.Empty;
            txtTipo_Moneda.Text = String.Empty;
            moneytxtM_SALDO.Text = String.Empty;
            cmbTercero.SelectedIndex = 0;
            txtNombre_terceros.Text = String.Empty;
            txtRfc_Terceros.Text = String.Empty;
            cmbOtorgante_credito.SelectedIndex = 0;
            txtE_CUENTA.Text = String.Empty;
            txtObservaciones.Text = String.Empty;
            try { cblTitulares.ClearSelection(); } catch { }
            txtV_LUGAR.Visible = false;
        }

        protected void chbDependietesInm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Paso = chbDependietesInm.SelectedItem.Text;
            Int32 Contenido = Paso.IndexOf("Terceros");
            if (Contenido > 0)
            {
                cmbTercero.Enabled = true;
                txtNombre_terceros.Enabled = true;
                txtRfc_Terceros.Enabled = true;
                //ComboTercero.Visible = true;
                //NombreTercero.Visible = true;
                //RFCTercero.Visible = true;
                //ComentaObservación.Visible = true;
            }
            else
            {
                cmbTercero.Enabled = false;
                txtNombre_terceros.Enabled = false;
                txtRfc_Terceros.Enabled = false;
                //ComboTercero.Visible = true;
                //NombreTercero.Visible = true;
                //RFCTercero.Visible = true;
                txtRfc_Terceros.Text = string.Empty;
                txtNombre_terceros.Text = string.Empty;
                cmbTercero.ClearSelection();
                //ComentaObservación.Visible = true;
            }
        }
    }
}