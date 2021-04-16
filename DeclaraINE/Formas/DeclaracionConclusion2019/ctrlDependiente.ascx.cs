using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using AlanWebControls;

namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class ctrlDependiente : System.Web.UI.UserControl
    {

        public enum Acciones
        {
            Actualiza,
            Inserta,
        }

        public Acciones Accion
        {
            get => (Acciones)ViewState["ctrlDependienteAccion"];
            set
            {
                if (ViewState["ctrlDependienteAccion"] == null)
                    ViewState.Add("ctrlDependienteAccion", value);
                else
                    ViewState["ctrlDependienteAccion"] = value;
            }
        }

        public Int32 Selected_id
        {
            get
            {
                if (ViewState["ctrlDependienteid"] == null)
                    return -1;
                   return  (Int32)ViewState["ctrlDependienteid"];
            }
            set
            {
                if (ViewState["ctrlDependienteid"] == null)
                    ViewState.Add("ctrlDependienteid", value);
                else
                    ViewState["ctrlDependienteid"] = value;
            }
        }

        public String NID_TIPO_DEPENDIENTE
        {
            get => cmbNID_TIPO_DEPENDIENTE.SelectedValue;
            set
            {
                if( (new String[] { "3","4","5" }).Contains(value))
                {
                    trDepende1.Visible = true;
                    //trDepende2.Visible = true;
                }
                else
                {
                    trDepende1.Visible = false;
                    //trDepende2.Visible = false;
                }
                cmbNID_TIPO_DEPENDIENTE.SelectedValue = value;
            }
        }

        public String E_NOMBRE
        {
            get => txtE_NOMBRE.Text;
            set => txtE_NOMBRE.Text = value;
        }

        public String E_PRIMER_A
        {
            get => txtE_PRIMER_A.Text;
            set => txtE_PRIMER_A.Text = value;
        }

        public String E_SEGUNDO_A
        {
            get => txtE_SEGUNDO_A.Text;
            set => txtE_SEGUNDO_A.Text = value;
        }

        public DateTime F_NACIMIENTO
        {
            get => txtF_NACIMIENTO.Date(Pagina.esMX);
            set => txtF_NACIMIENTO.Text = value.ToString(Pagina.strFormatoFecha);
        }

        public String E_RFC
        {
            get => txtE_RFC.Text;
            set => txtE_RFC.Text = value;
        }

        public Boolean L_DEPENDE_ECO
        {
            get
            {
                if ((new String[] { "3", "4", "5" }).Contains(NID_TIPO_DEPENDIENTE))
                {
                   
                    trDepende1.Visible = true;
                    //trDepende2.Visible = true;
                    return cbxL_DEPENDE_ECO.Checked;
                }
                else
                {
                    trDepende1.Visible = false;
                    //trDepende2.Visible = false;
                    return true;
                }
            }
            set
            {
                if ((new String[] { "3", "4", "5" }).Contains(NID_TIPO_DEPENDIENTE))
                {
                    trDepende1.Visible = true;
                    //trDepende2.Visible = true;
                    cbxL_DEPENDE_ECO.Checked = value;
                }
                else
                {
                    trDepende1.Visible = false;
                    //trDepende2.Visible = false;
                    cbxL_DEPENDE_ECO.Checked = true;
                }
            }
        }

        public string V_DOMICILIO
        {
            get => txt_V_DOMICILIO.Text.Trim();
            set
            {
                if (String.IsNullOrEmpty(value))
                    txt_V_DOMICILIO.Text = String.Empty;
                else
                {
                    txt_V_DOMICILIO.Text = value.Trim();
                }
            }
        }
        public Boolean L_MISMO_DOMICILIO
        {
            get
            {
                if (String.IsNullOrEmpty(V_DOMICILIO))
                    return false;
                return true;
            }
        }

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                req();
                blld__l_CAT_TIPO_DEPENDIENTES oDep = new blld__l_CAT_TIPO_DEPENDIENTES();
                oDep.OrderByCriterios.Add(new Declara_V2.Order(CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE));
                oDep.select();
                cmbNID_TIPO_DEPENDIENTE.DataBind(oDep.lista_CAT_TIPO_DEPENDIENTES, CAT_TIPO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE, CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE);
                cmbNID_TIPO_DEPENDIENTE.Items.Insert(0, new ListItem(String.Empty, "0"));
                txtF_NACIMIENTO_C.StartDate = new DateTime(1900, 1, 1);
                txtF_NACIMIENTO_C.EndDate = DateTime.Today.AddDays(-1);
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
                        if( ((TextBox)ctr).ID != txtE_SEGUNDO_A.ID )
                            ((TextBox)ctr).Attributes.Add("requerido", Requerido);
                    }
                    else if (ctr is DropDownList)
                    {
                        ((DropDownList)ctr).Attributes.Add("requerido", Requerido);
                    }
                }
            }
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

        public void llena(blld_DECLARACION_DEPENDIENTES Dependiente,Int32 Id)
        {
            NID_TIPO_DEPENDIENTE = Dependiente.NID_TIPO_DEPENDIENTE.ToString();
            E_NOMBRE = Dependiente.E_NOMBRE;
            E_PRIMER_A = Dependiente.E_PRIMER_A;
            E_SEGUNDO_A = Dependiente.E_SEGUNDO_A;
            F_NACIMIENTO = Dependiente.F_NACIMIENTO;
            E_RFC = Dependiente.E_RFC;
            L_DEPENDE_ECO = Dependiente.L_DEPENDE_ECO;
            chk_L_MISMO_DOMICIO.Checked = String.IsNullOrEmpty(Dependiente.E_DOMICILIO);
            if (chk_L_MISMO_DOMICIO.Checked)
            {
                try { txt_V_DOMICILIO.Attributes.Remove("requerido"); } catch { }
                
            }
            else
            {
                try { txt_V_DOMICILIO.Attributes.Add("requerido", Requerido); } catch { }
            }
            V_DOMICILIO = Dependiente.E_DOMICILIO;
            txt_V_DOMICILIO.Visible = !chk_L_MISMO_DOMICIO.Checked;
            trDomicilio.Visible = !chk_L_MISMO_DOMICIO.Checked;
            Accion = Acciones.Actualiza;
            this.Selected_id = Id;
        }

        public void limpia()
        {
            NID_TIPO_DEPENDIENTE = "0";
            E_NOMBRE = String.Empty;
            E_PRIMER_A = String.Empty;
            E_SEGUNDO_A = String.Empty;
            txtF_NACIMIENTO.Text = String.Empty;
            E_RFC = String.Empty;
            cbxL_DEPENDE_ECO.CheckedNullable = null;
            chk_L_MISMO_DOMICIO.Checked = true;
            V_DOMICILIO = String.Empty;
            Accion = Acciones.Inserta;
            txt_V_DOMICILIO.Visible = false;
        }

        protected void chk_L_MISMO_DOMICIO_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_MISMO_DOMICIO.Checked)
            {
                V_DOMICILIO = String.Empty;
                txt_V_DOMICILIO.Visible = false;
                trDomicilio.Visible = false;

                try { txt_V_DOMICILIO.Attributes.Remove("requerido"); } catch { }
            }
            else
            {
                txt_V_DOMICILIO.Visible = true;
                trDomicilio.Visible = true;
                try { txt_V_DOMICILIO.Attributes.Add("requerido", Requerido); } catch { }

                
            }
        }

        protected void cmbNID_TIPO_DEPENDIENTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((new String[] { "3", "4", "5" }).Contains(cmbNID_TIPO_DEPENDIENTE.SelectedValue))
            {
                trDepende1.Visible = true;
                //trDepende2.Visible = true;
            }
            else
            {
                trDepende1.Visible = false;
                //trDepende2.Visible = false;
            }
        }
    }
}