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

        public List<Int32> NID_TITULARs
        {
            get
            {
                if (cblTitulares.SelectedValuesInteger() == null)
                    return new List<Int32>();
                else
                    return cblTitulares.SelectedValuesInteger();
            }
            set
            {
                cblTitulares.ClearSelection();
                if (value != null)
                    foreach (Int32 ID in value)
                        cblTitulares.Items.FindByValue(ID.ToString()).Selected = true;
            }
        }

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
                cblTitulares.DataBind(oDeclaracion.DECLARACION_DEPENDIENTESs, DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE, DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO);
                cblTitulares.Items.Insert(0, new ListItem("Declarante", "0"));
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
            }
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
            if (NID_PAIS > 1) txtV_LUGAR.Visible = true;
            else txtV_LUGAR.Visible = false;
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
            txtV_OTRO.Text = String.Empty;
            txtV_OTRO.Visible = false;
            txtF_ADEUDO.Text = String.Empty;
            moneytxtM_ORIGINAL.Text = String.Empty;
            moneytxtM_SALDO.Text = String.Empty;
            txtE_CUENTA.Text = String.Empty;
            try { cblTitulares.ClearSelection(); } catch { }
        }
    }
}