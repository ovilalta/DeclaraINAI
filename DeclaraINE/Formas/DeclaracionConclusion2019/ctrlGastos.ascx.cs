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
    public partial class ctrlGastos : System.Web.UI.UserControl
    {

        public List<Int32> NID_TIPO_GASTO
        {
            get
            {
                if (ViewState["NID_TIPO_GASTO"] == null)
                    ViewState.Add("NID_TIPO_GASTO", new List<Int32>());
                return (List<Int32>)ViewState["NID_TIPO_GASTO"];
            }
            set
            {
                if (ViewState["NID_TIPO_GASTO"] == null)
                    ViewState.Add("NID_TIPO_GASTO", value);
                else
                    ViewState["NID_TIPO_GASTO"] = value;
            }
        }

        public List<String> OPCIONES
        {
            get
            {
                if (ViewState["OPCIONES"] == null)
                    ViewState.Add("OPCIONES", new List<String>());
                return (List<String>)ViewState["OPCIONES"];
            }
            set
            {
                if (ViewState["OPCIONES"] == null)
                    ViewState.Add("OPCIONES", value);
                else
                    ViewState["OPCIONES"] = value;
                if (OPCIONES.Count > 0)
                    V_GASTO_DEFAULT = OPCIONES[0];
            }
        }

        public System.Nullable<Int32> NID_PATRIMONIO
        {
            get
            {
                if (ViewState["NID_PATRIMONIO"] == null)
                    return null;
                return (System.Nullable<Int32>)ViewState["NID_PATRIMONIO"];
            }
            set
            {
                if (ViewState["NID_PATRIMONIO"] == null)
                {
                    ViewState.Add("NID_PATRIMONIO", value);
                }
                else
                {

                    ViewState["NID_PATRIMONIO"] = value;
                    blld_DECLARACION oDeclaracion = _oDeclaracion;
                    if (NID_PATRIMONIO.HasValue)
                        grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_PATRIMONIO_ASC == this.NID_PATRIMONIO.Value));
                }
            }
        }

        public String V_GASTO_DEFAULT
        {
            get
            {
                if (ViewState["V_GASTO_DEFAULT"] == null)
                    return "Nuevo Gasto";
                return (String)ViewState["V_GASTO_DEFAULT"];
            }
            set
            {
                if (ViewState["V_GASTO_DEFAULT"] == null)
                    ViewState.Add("V_GASTO_DEFAULT", value);
                else
                    ViewState["V_GASTO_DEFAULT"] = value;
            }
        }


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

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                if (NID_PATRIMONIO.HasValue)
                    grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_PATRIMONIO_ASC == this.NID_PATRIMONIO.Value));
                else
                    grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => NID_TIPO_GASTO.Contains(p.NID_TIPO_GASTO)));
            }

            foreach (GridViewRow row in grd.Rows)
            {
                try
                {
                    String NID_GASTO = ((Button)row.FindControl("btnEliminar")).CommandArgument;
                    ((HtmlGenericControl)row.FindControl("div")).ID = "div" + ((TextBox)row.FindControl(String.Concat("moneytxtM_GASTO"))).ClientID;
                }
                catch
                { }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 NID_GASTO = Convert.ToInt32(((Button)sender).CommandArgument);
            oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Remove(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First());
            if (NID_PATRIMONIO.HasValue)
                grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_PATRIMONIO_ASC == this.NID_PATRIMONIO.Value));
            else
                grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => NID_TIPO_GASTO.Contains(p.NID_TIPO_GASTO)));
            _oDeclaracion = oDeclaracion;
        }

        internal void btnGuardar(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            Int32 NID_GASTO;
            foreach (GridViewRow row in grd.Rows)
            {
                NID_GASTO = Convert.ToInt32(((Button)row.FindControl("btnEliminar")).CommandArgument);
                oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First().M_GASTO = ((TextBox)row.FindControl(String.Concat("moneytxtM_GASTO"))).Money();
                if (OPCIONES.Count == 0)
                    oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First().V_GASTO = ((TextBox)row.FindControl("txtV_GASTO")).Text;
                else
                    oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First().V_GASTO = ((DropDownList)row.FindControl("cmbV_GASTO")).SelectedItem.Text;
                oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First().update();
            }

            _oDeclaracion = oDeclaracion;
        }

        internal void btnAgregar(object sender, EventArgs e) => btnAgregar(sender, e, this.NID_PATRIMONIO);

        internal void btnAgregar(object sender, EventArgs e, System.Nullable<Int32> NID_PATRIMONIO)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            oDeclaracion.MODIFICACION.Add_MODIFICACION_GASTOs(NID_TIPO_GASTO.First(), V_GASTO_DEFAULT, 0, false, NID_PATRIMONIO);
            _oDeclaracion = oDeclaracion;
            if (NID_PATRIMONIO.HasValue)
                grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_PATRIMONIO_ASC == this.NID_PATRIMONIO.Value));
            else
                grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => this.NID_TIPO_GASTO.Contains(p.NID_TIPO_GASTO)));
        }

        internal void btnAgregar(object sender, EventArgs e, Int32 NID_TIPO_GASTO, System.Nullable<Int32> NID_PATRIMONIO)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
                oDeclaracion.MODIFICACION.Add_MODIFICACION_GASTOs(NID_TIPO_GASTO, V_GASTO_DEFAULT, 0, false, NID_PATRIMONIO);
            _oDeclaracion = oDeclaracion;
            if (NID_PATRIMONIO.HasValue)
                grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_PATRIMONIO_ASC == this.NID_PATRIMONIO.Value));
            else
                grd.DataBind(oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => this.NID_TIPO_GASTO.Contains(p.NID_TIPO_GASTO)));
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Int32 NID_GASTO = Convert.ToInt32(((Label)e.Row.FindControl("NID_GASTO")).Text);
                if (OPCIONES.Count == 0)
                {
                    ((TextBox)e.Row.FindControl("txtV_GASTO")).Visible = true;
                    ((DropDownList)e.Row.FindControl("cmbV_GASTO")).Visible = false;
                    ((TextBox)e.Row.FindControl("txtV_GASTO")).Enabled = !oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First().L_AUTOGENERADO;
                    ((TextBox)e.Row.FindControl("txtV_GASTO")).Text = oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First().V_GASTO;
                }
                else
                {
                    ((TextBox)e.Row.FindControl("txtV_GASTO")).Visible = false;
                    ((DropDownList)e.Row.FindControl("cmbV_GASTO")).Visible = true;
                    ((DropDownList)e.Row.FindControl("cmbV_GASTO")).DataSource = OPCIONES;
                    ((DropDownList)e.Row.FindControl("cmbV_GASTO")).DataBind();
                    ((DropDownList)e.Row.FindControl("cmbV_GASTO")).Enabled = !oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First().L_AUTOGENERADO;
                    ((DropDownList)e.Row.FindControl("cmbV_GASTO")).SelectedValue = oDeclaracion.MODIFICACION.MODIFICACION_GASTOs.Where(p => p.NID_GASTO == NID_GASTO).First().V_GASTO;
                }
                    try
                    {

                        ((HtmlGenericControl)e.Row.FindControl("div")).ID = "div" + ((TextBox)e.Row.FindControl(String.Concat("moneytxtM_GASTO"))).ClientID;
                    }
                    catch { }
            }
        }


    }
}