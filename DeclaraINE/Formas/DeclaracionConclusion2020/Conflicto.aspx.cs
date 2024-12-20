﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;

namespace DeclaraINE.Formas.DeclaracionInicial
{
    public partial class Conflicto : Pagina, IDeclaracionInicial
    {

        private blld_CONFLICTO _oConflicto
        {
            get => (blld_CONFLICTO)Session["oConflicto"];
            set => SessionAdd("oConflicto", value);
        }

        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }

        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        Int32 NID_RUBRO
        {
            get => (Int32)ViewState["NID_RUBRO"];
            set => ViewState["NID_RUBRO"] = value;
        }

        Int32 NID_ENCABEZADO
        {
            get => (Int32)ViewState["NID_ENCABEZADO"];
            set => ViewState["NID_ENCABEZADO"] = value;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            ((HtmlControl)Master.FindControl("liConflictoInteres")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu6")).Attributes.Add("class", "tab-pane fade level1 active in");
            if (!IsPostBack)
            {
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";


                create();
                grdRubros.DataSource = _oConflicto.CONFLICTO_RUBROs;
                grdRubros.DataBind();
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lknConflicto")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lknConflicto")).CssClass = "active";
        }

        private void create()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld__l_CONFLICTO obc = new blld__l_CONFLICTO();
            obc.VID_NOMBRE = new Declara_V2.StringFilter(oDeclaracion.VID_NOMBRE);
            obc.VID_FECHA = new Declara_V2.StringFilter(oDeclaracion.VID_FECHA);
            obc.VID_HOMOCLAVE = new Declara_V2.StringFilter(oDeclaracion.VID_HOMOCLAVE);
            obc.NID_DEC_ASOS = new Declara_V2.IntegerFilter(oDeclaracion.NID_DECLARACION);
            obc.select();
            _oConflicto = new blld_CONFLICTO(obc.lista_CONFLICTO.First());

        }

        public void Anterior()
        {
            Response.Redirect("Observaciones.aspx");
        }

        public void Siguiente()
        {
            blld_CONFLICTO oConflicto = _oConflicto;
            if (oConflicto != null)
            {
                create();
                oConflicto = _oConflicto;
            }
            try
            {
                if (oConflicto.L_VALIDA)
                {
                    marcaApartado(14);
                    Response.Redirect("Envio.aspx");
                }
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    MsgBox.ShowWarning(ex.Message);
                    desMarcaApartado(14);
                }
                else
                    throw ex;
            }
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

        private void desMarcaApartado(int NID_APARTADO)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO.HasValue)
            {
                if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO.Value)
                {
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO = false;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().update();
                }
            }
            else
            {
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO = false;
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().update();
            }
        }

        protected void btnSI_Click(object sender, EventArgs e)
        {
            blld_CONFLICTO oConflicto = _oConflicto;
            Int32 NID_RUBRO = Convert.ToInt32(((Button)sender).CommandArgument);
            this.NID_RUBRO = NID_RUBRO;
            this.NID_ENCABEZADO = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).Last().SI(oConflicto.NID_DEC_ASOS);
            cbx.CheckedNullable = null;
            grdRubros.DataSource = oConflicto.CONFLICTO_RUBROs;
            grdRubros.DataBind();
            mppPreguntas.Show(true);
            grdPreguntas.DataSource = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().CONFLICTO_RESPUESTAs;
            grdPreguntas.DataBind();
           
            _oConflicto = oConflicto;
        }

        protected void btnNO_Click(object sender, EventArgs e)
        {
            blld_CONFLICTO oConflicto = _oConflicto;
            Int32 NID_RUBRO = Convert.ToInt32(((Button)sender).CommandArgument);
            oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().NO(oConflicto.NID_DEC_ASOS);
            ((Button)((GridViewRow)((Button)sender).Parent.Parent).FindControl("btnSi")).CssClass = "btnFalse2";
            ((Button)((GridViewRow)((Button)sender).Parent.Parent).FindControl("btnSi")).Enabled = true;
            ((Button)sender).CssClass = "btnTrue2";
            ((Button)sender).Enabled = false;
            grdRubros.DataSource = _oConflicto.CONFLICTO_RUBROs;
            grdRubros.DataBind();

            _oConflicto = oConflicto;
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mppPreguntas.Hide();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                blld_CONFLICTO oConflicto = _oConflicto;
                Int32 x = 1;
                String V_RESPUESTA;
                foreach (GridViewRow row in grdPreguntas.Rows)
                {
                    V_RESPUESTA = ((TextBox)row.FindControl("txtRespuesta")).Text;
                    oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().CONFLICTO_RESPUESTAs.Where(p => p.NID_PREGUNTA == x).First().V_RESPUESTA = V_RESPUESTA;
                    oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().CONFLICTO_RESPUESTAs.Where(p => p.NID_PREGUNTA == x).First().update();
                    x++;
                }
                oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().L_CONFLICTO = cbx.Checked;
                oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().update();
                mppPreguntas.Hide();
                _oConflicto = oConflicto;
                grdRubros.DataSource = oConflicto.CONFLICTO_RUBROs;

                grdRubros.DataBind();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    MsgBox.ShowDanger(ex.Message);
                else
                    throw ex;
            }
        }

        protected void grdRubros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            blld_CONFLICTO oConflicto = _oConflicto;
            if (oConflicto != null)
            {
                create();
                oConflicto = _oConflicto;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Int32 NID_RUBRO = Convert.ToInt32(((Label)e.Row.FindControl("NID_RUBRO")).Text);
                ((GridView)e.Row.FindControl("grdEncabezados")).DataSource = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs;
                ((GridView)e.Row.FindControl("grdEncabezados")).DataBind();
                ((Button)e.Row.FindControl("btnAgregarEncabezado")).Visible = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().L_RESPUESTA.HasValue ? oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().L_RESPUESTA.Value : false;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            blld_CONFLICTO oConflicto = _oConflicto;
            String[] Params = ((Button)sender).CommandArgument.Split('|');
            Int32 NID_RUBRO = Convert.ToInt32(Params[0]);
            Int32 NID_ENCABEZADO = Convert.ToInt32(Params[1]);
            this.NID_RUBRO = NID_RUBRO;
            this.NID_ENCABEZADO = NID_ENCABEZADO;
            mppPreguntas.Show(true);
            grdPreguntas.DataSource = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().CONFLICTO_RESPUESTAs;
            cbx.CheckedNullable = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().L_CONFLICTO;
            grdPreguntas.DataBind();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            blld_CONFLICTO oConflicto = _oConflicto;
            String[] Params = ((Button)sender).CommandArgument.Split('|');
            Int32 NID_RUBRO = Convert.ToInt32(Params[0]);
            Int32 NID_ENCABEZADO = Convert.ToInt32(Params[1]);
            this.NID_RUBRO = NID_RUBRO;
            this.NID_ENCABEZADO = NID_ENCABEZADO;
            blld_CONFLICTO_ENCABEZADO o = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First();
            oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Remove(o);
            grdRubros.DataSource = oConflicto.CONFLICTO_RUBROs;
            grdRubros.DataBind();
            _oConflicto = oConflicto;
        }

        protected void grdPreguntas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            blld_CONFLICTO oConflicto = _oConflicto;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Int32 NID_RUBRO = Convert.ToInt32(((Label)e.Row.FindControl("NID_RUBRO")).Text);
                Int32 NID_ENCABEZADO = Convert.ToInt32(((Label)e.Row.FindControl("NID_ENCABEZADO")).Text);
                Int32 NID_PREGUNTA = Convert.ToInt32(((Label)e.Row.FindControl("NID_PREGUNTA")).Text);
                blld_CAT_CONFLICTO_PREGUNTA oPregunta = new blld_CAT_CONFLICTO_PREGUNTA(NID_RUBRO, NID_PREGUNTA);
                if (String.IsNullOrEmpty(oPregunta.V_OPCIONES))
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = String.Empty;
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                   if (e.Row.RowIndex ==-1) ((TextBox)e.Row.FindControl("txtRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);
                }
                else
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = String.Empty;
                    if (e.Row.RowIndex == -1) ((DropDownList)e.Row.FindControl("cmbRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);
                    Int32 x = 0;
                    foreach (String str in oPregunta.V_OPCIONES.Split('|'))
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).Items.Add(new ListItem(str, String.Concat(e.Row.RowIndex, '|',x++)));
                    try { ((DropDownList)e.Row.FindControl("cmbRespuesta")).SelectedIndex = ((DropDownList)e.Row.FindControl("cmbRespuesta")).Items.IndexOf(((DropDownList)e.Row.FindControl("cmbRespuesta")).Items.FindByText(((TextBox)e.Row.FindControl("txtRespuesta")).Text)); }
                    catch { }

                }
            }
        }

        protected void cmbRespuesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdPreguntas.Rows[Convert.ToInt32(((DropDownList)sender).SelectedValue.Split('|')[0])];
            ((TextBox)row.FindControl("txtRespuesta")).Text = ((DropDownList)sender).SelectedItem.Text;
        }
    }
}