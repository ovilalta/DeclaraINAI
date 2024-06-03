using Declara_V2.BLLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;


namespace DeclaraINAI.Formas.DeclaracionModificacion
{
    public partial class ctrlDesincorpora : System.Web.UI.UserControl
    {

        internal void SessionAdd(String ObjectName, Object Objeto)
        {
            if (Session[ObjectName] == null) Session.Add(ObjectName, Objeto);
            else Session[ObjectName] = Objeto;
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

        public System.Nullable<Int32> NID_PATRIMONIO
        {
            get
            {
                if (ViewState["NID_PATRIMONIO_V"] == null)
                    return null;
                return (System.Nullable<Int32>)ViewState["NID_PATRIMONIO_V"];
            }
            set
            {
                if (ViewState["NID_PATRIMONIO_V"] == null)
                    ViewState.Add("NID_PATRIMONIO_V", value);
                else
                    ViewState["NID_PATRIMONIO_V"] = value;
            }
        }

        public String V_BUTTONID
        {
            get
            {
                if (ViewState["V_BUTTONID"] == null)
                    return null;
                return (String)ViewState["V_BUTTONID"];
            }
            set
            {
                if (ViewState["V_BUTTONID"] == null)
                    ViewState.Add("V_BUTTONID", value);
                else
                    ViewState["V_BUTTONID"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cmbNID_TIPO_DEPENDIENTE.DataBinder(new blld__l_CAT_TIPO_BAJA(), CAT_TIPO_BAJA.Properties.NID_TIPO_BAJA, CAT_TIPO_BAJA.Properties.V_TIPO_BAJA);
              
                cmbNID_TIPO_DEPENDIENTE_SelectedIndexChanged(sender,e);
                
            }
            requerido();
           
        }

        public void requerido()
        {
            if (!String.IsNullOrEmpty(V_BUTTONID))
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).Attributes.Add("requerido", V_BUTTONID);
                    }
                    else if (ctrl is DropDownList)
                    {
                        ((DropDownList)ctrl).Attributes.Add("requerido", V_BUTTONID);
                    }
                    else { }
                }
            }
        }

        public void llena(Int32 NID_PATRIMONIO)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            limpia();
            this.NID_PATRIMONIO = NID_PATRIMONIO;
            cmbNID_TIPO_DEPENDIENTE.SelectedValue = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().NID_TIPO_BAJA.ToString();
            cmbNID_TIPO_DEPENDIENTE_SelectedIndexChanged(cmbNID_TIPO_DEPENDIENTE, null);
            txtF_BAJA.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().F_BAJA.ToString(Pagina.strFormatoFecha);
            switch (cmbNID_TIPO_DEPENDIENTE.SelectedValue())
            {
                case 1:
                    moneytxtM_IMPORTE_VENTA.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTA.ToString();
                    txtE_BENIFICIARIO.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_VENTA.E_BENIFICIARIO.ToString();
                    txtE_ESPECIFICA.Text = String.Empty;
                    txtE_BENIFICIARIO_DONACION.Text = String.Empty;
                    cbxL_POLIZA.Checked = false;
                    cbxL_POLIZA_CheckedChanged(cbxL_POLIZA, null);
                    moneytxtM_RECUPERADO.Text = String.Empty;
                    break;
                case 2:
                    moneytxtM_IMPORTE_VENTA.Text = String.Empty;
                    txtE_BENIFICIARIO.Text = String.Empty;
                    txtE_ESPECIFICA.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_DONACION.E_ESPECIFICA.ToString();
                    txtE_BENIFICIARIO_DONACION.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_DONACION.E_BENIFICIARIO.ToString();
                    cbxL_POLIZA.Checked = false;
                    cbxL_POLIZA_CheckedChanged(cbxL_POLIZA, null);
                    moneytxtM_RECUPERADO.Text = String.Empty;
                    break;
                case 3:
                    moneytxtM_IMPORTE_VENTA.Text = String.Empty;
                    txtE_BENIFICIARIO.Text = String.Empty;
                    txtE_ESPECIFICA.Text = String.Empty;
                    txtE_BENIFICIARIO_DONACION.Text = String.Empty;
                    cbxL_POLIZA.Checked = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_SINIESTRO.L_POLIZA;
                    cbxL_POLIZA_CheckedChanged(cbxL_POLIZA, null);
                    moneytxtM_RECUPERADO.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_SINIESTRO.M_RECUPERADO.ToString();
                    break;
                case 4:
                    moneytxtM_IMPORTE_VENTA.Text = String.Empty;
                    txtE_BENIFICIARIO.Text = String.Empty;
                    txtE_ESPECIFICA.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_DONACION.E_ESPECIFICA.ToString();
                    txtE_BENIFICIARIO_DONACION.Text = oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_DONACION.E_BENIFICIARIO.ToString();
                    cbxL_POLIZA.Checked = false;
                    cbxL_POLIZA_CheckedChanged(cbxL_POLIZA, null);
                    moneytxtM_RECUPERADO.Text = String.Empty;
                    break;
                default:
                    break;
            }
        }

        public void limpia(Int32 NID_PATRIMONIO)
        {
            this.NID_PATRIMONIO = NID_PATRIMONIO;
            limpia();
        }

        public void limpia()
        {
            this.NID_PATRIMONIO = NID_PATRIMONIO;
            cmbNID_TIPO_DEPENDIENTE.SelectedIndex = 3;
            cmbNID_TIPO_DEPENDIENTE_SelectedIndexChanged(cmbNID_TIPO_DEPENDIENTE, null);
            txtF_BAJA.Text = String.Empty;
            moneytxtM_IMPORTE_VENTA.Text = String.Empty;
            txtE_BENIFICIARIO.Text = String.Empty;
            cbxL_POLIZA.Checked = false;
            cbxL_POLIZA_CheckedChanged(cbxL_POLIZA, null);
            txtE_ESPECIFICA.Text = String.Empty;
            txtE_BENIFICIARIO_DONACION.Text = String.Empty;
            
        }

        public void Elimina()
        {
            try
            {
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Remove(oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First());
                _oDeclaracion = oDeclaracion;
            }
            catch { }
        }

        public void Guarda()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            oDeclaracion.MODIFICACION.Add_MODIFICACION_BAJAs(this.NID_PATRIMONIO.Value, cmbNID_TIPO_DEPENDIENTE.SelectedValue(), txtF_BAJA.Date(Pagina.esMX));

            switch (cmbNID_TIPO_DEPENDIENTE.SelectedValue())
            {
                case 1:
                    oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().Add_MODIFICACION_BAJA_VENTA(1, moneytxtM_IMPORTE_VENTA.Money(), txtE_BENIFICIARIO.Text);
                    try
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_SINIESTRO.delete();
                        oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_DONACION.delete();
                    }
                    catch { }
                    break;
                case 2:
                    oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().Add_MODIFICACION_DONACION(txtE_ESPECIFICA.Text, txtE_BENIFICIARIO_DONACION.Text);
                    try
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_SINIESTRO.delete();
                        oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_VENTA.delete();
                    }
                    catch { }
                    break;
                case 3:
                    oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().Add_MODIFICACION_BAJA_SINIESTRO(cbxL_POLIZA.Checked, moneytxtM_RECUPERADO.Money());
                    try
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_VENTA.delete();
                        oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_DONACION.delete();
                    }
                    catch { }
                    break;
                case 4:
                    oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().Add_MODIFICACION_DONACION(txtE_ESPECIFICA.Text, txtE_BENIFICIARIO_DONACION.Text);
                    try
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_SINIESTRO.delete();
                        oDeclaracion.MODIFICACION.MODIFICACION_BAJAs.Where(p => p.NID_PATRIMONIO == this.NID_PATRIMONIO.Value).First().MODIFICACION_BAJA_VENTA.delete();
                    }
                    catch { }
                    break;
                default:
                    break;
            }
            _oDeclaracion = oDeclaracion;
        }

        protected void cmbNID_TIPO_DEPENDIENTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbNID_TIPO_DEPENDIENTE.SelectedValue())
            {
                case 1:
                    pnlVenta.Visible = true;
                    pnlSiniestro.Visible = false;
                    pnlDonacion.Visible = false;
                    break;
                case 2:
                    pnlVenta.Visible = false;
                    pnlSiniestro.Visible = false;
                    pnlDonacion.Visible = true;
                    break;
                case 3:
                    pnlVenta.Visible = false;
                    pnlSiniestro.Visible = true;
                    pnlDonacion.Visible = false;
                    break;
                case 4:
                    pnlVenta.Visible = false;
                    pnlSiniestro.Visible = false;
                    pnlDonacion.Visible = false;
                    break;
                default:
                    break;
            }

        }

        protected void cbxL_POLIZA_CheckedChanged(object sender, EventArgs e)
        {
            trM_RECUPERADO.Visible = cbxL_POLIZA.Checked;
            if (!trM_RECUPERADO.Visible) moneytxtM_RECUPERADO.Text = String.Empty;
        }
    }
}