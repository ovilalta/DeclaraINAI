using Declara_V2.BLLD;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using Declara_V2.MODELextended;
using AlanWebControls;
using Declara_V2.Exceptions;
using Declara_V2.BLL;
using Declara_V2.DALD;

namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class Desemp : Pagina, IDeclaracionInicial
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
        Int32 NID_INGRESO
        {
            get => (Int32)ViewState["NID_INGRESO"];
            set => ViewState["NID_INGRESO"] = value;
        }

        private blld_MODIFICACION_INGRESOS _oModificacion_Ingresos
        {
            get => (blld_MODIFICACION_INGRESOS)Session["oModificacion_Ingresos"];
            set => SessionAdd("oModificacion_Ingresos", value);
        }
        public void Anterior()
        {
            Response.Redirect("Ingresos.aspx");
        }
       
        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            SalvaDatos();
            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
            {
                // AQUI VA EL CODIGO DEL APARTADO
                //---------------------------------------------------
               
                marcaApartado(20);
               
                //---------------------------------------------------
            }


            //Response.Redirect("Comodato.aspx");
            blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
            oPuesto.select();
            var o = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single();

            bool? obligado = o.L_OBLIGADO;
            if (obligado != null)
                if (obligado.Equals(false))
                {
                    marcaApartado(7);
                    marcaApartado(8);
                    marcaApartado(9);
                    marcaApartado(10);
                    marcaApartado(11);
                    marcaApartado(12);
                    marcaApartado(14);
                    marcaApartado(19);
                    Response.Redirect("Observaciones.aspx");

                }
                else
                {
                    Response.Redirect("Bienes.aspx");
                }
        }

        protected void Page_Init(Object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_ALTA_INVERSION o;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liDesemp")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu10")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
                grdPreguntas.DataSource = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.VID_NOMBRE == oDeclaracion.VID_NOMBRE && p.VID_FECHA == oDeclaracion.VID_FECHA && p.VID_HOMOCLAVE == oDeclaracion.VID_HOMOCLAVE && p.NID_DECLARACION == oDeclaracion.NID_DECLARACION && p.NID_INGRESO > 199).ToList();
                grdPreguntas.DataBind();
                grdPreguntas.Rows[17].Visible = false;
                txtF_INGRESO_C.StartDate = new DateTime(1900, 1, 1);
                txtF_FINAL_C.StartDate = new DateTime(1900, 1, 1);
                txtF_INGRESO_C.EndDate = DateTime.Today.AddDays(-1);
                txtF_FINAL_C.EndDate = DateTime.Today.AddDays(-1);
                if (oDeclaracion.DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_FIN.ToString().Length>0)
                txtF_FINAL.Text = oDeclaracion.DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_FIN.ToString().Substring(0,10);
                if (oDeclaracion.DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_INICIO.ToString().Length > 0)
                    txtF_INGRESO.Text = oDeclaracion.DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_INICIO.ToString().Substring(0, 10);
                string Manejo = oDeclaracion.DECLARACION_PERSONALES.L_SERVIDOR_ANTERIOR.ToString();
                if(Manejo=="True")
                { 
                    cbxFuisteServidor.Checked = true;
                    cuerpo.Visible = true;
                }
                else if (Manejo == "False")
                { 
                    cbxFuisteServidor.Checked = false;
                    cuerpo.Visible = false;
                }
                else
                    cuerpo.Visible = false;

                Daformato();
                SumaDatos();
                GeneraTooltip();
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkDesemp")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkDesemp")).CssClass = "active";

            ltrSubTitulo.Text = "9. ¿Te desempeñaste como servidor público en el año inmediato anterior?";
           
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
        protected void cmbRespuesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAuxiliar.Text = ((DropDownList)sender).SelectedValue.ToString() + "|" + ((DropDownList)sender).SelectedItem.Text;

        }

        protected void grdPreguntas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ultima = e.Row.RowIndex;
            int NoCells = e.Row.Cells.Count;
            string Contenido;
            string Desgloce;
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Contenido = TomaDesicion(Convert.ToInt32(((Label)e.Row.FindControl("NID_INGRESO")).Text)).ToString();
                Desgloce = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
               
                if (ultima == 7)
                {
                    this.lblAuxiliar.Text = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                }
                if(ultima==11)
                {
                    this.lblAuxiliarBE.Text = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                }
                if (ultima == 2 || ultima == 14 || ultima == 16)
                {
                    if (Contenido.Split('|')[0] == "M" || Contenido.Split('|')[0] == "F")
                    {
                        ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = String.Empty;

                        ((TextBox)e.Row.FindControl("txtMonto")).Enabled = false;
                    }
                }
                else if (ultima == 17)
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = String.Empty;
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                    ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                    this.txtObservaciones.Text = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                   
                }
               else if (ultima == 0)
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                    ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                }
                else
                {


                    if (Contenido.Split('|')[0] == "T")
                    {
                        ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = String.Empty;
                        ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                        if (e.Row.RowIndex == -1) ((TextBox)e.Row.FindControl("txtRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);

                        //if (e.Row.RowIndex == -1) ((TextBox)e.Row.FindControl("txtRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);
                    }
                    if (Contenido.Split('|')[0] == "C")
                    {
                        ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                        
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";// 
                        if (ultima == 11)
                        {
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible"; ;
                            ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = String.Empty;
                            ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).SelectedValue = Desgloce.Split('|')[0].ToString();
                        }
                        else
                        {
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = String.Empty;
                            ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible"; 
                            blld__l_CAT_INSTRUMENTO_RENDIMIENTO oCAT_INSTRUMENTO_RENDIMIENTO = new blld__l_CAT_INSTRUMENTO_RENDIMIENTO();
                            oCAT_INSTRUMENTO_RENDIMIENTO.select();
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).DataBind(oCAT_INSTRUMENTO_RENDIMIENTO.lista_CAT_INSTRUMENTO_RENDIMIENTO, CAT_INSTRUMENTO_RENDIMIENTO.Properties.NID_INSTRUMENTO_RENDIMIENTO, CAT_INSTRUMENTO_RENDIMIENTO.Properties.V_INSTRUMENTO_RENDIMIENTO, false);
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).Items.Insert(0, new ListItem(string.Empty));
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).SelectedValue = Desgloce.Split('|')[0].ToString();
                        }

                    }
                    if (Contenido.Split('|')[0] == "M" || Contenido.Split('|')[0] == "F")
                    {
                        ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = String.Empty;
                        ((TextBox)e.Row.FindControl("txtMonto")).ReadOnly = false;
                    }
                }
                Desgloce = "";


            }

        }
        internal static string TomaDesicion(int NID_INGRESO)
        {

            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in dbInt.CAT_SECCION_INGRESO
                              where p.NID_RUBRO == NID_INGRESO && p.NID_SECCION == 3

                              select p.CID_TIPO.ToString() + "|" + p.NID_RUBRO_SUMA).First());
                return query;

            }
            catch
            {
                return "";
            }
        }
        protected void btnGuardarPreguntas_Click(object sender, EventArgs e)
        {
            SalvaDatos();
            AlertaSuperior.ShowSuccess("Se agregó correctamente la información");
        }
        private void SalvaDatos()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            String V_COMPLEMENTO;
            string V_MONTO;

            try
            {
                blld_MODIFICACION_INGRESOS oModificacion_Ingresos = _oModificacion_Ingresos;
                oDeclaracion.DECLARACION_PERSONALES.L_SERVIDOR_ANTERIOR = cbxFuisteServidor.Checked;
                oDeclaracion.DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_INICIO =Convert.ToDateTime( txtF_INGRESO.Text);
                oDeclaracion.DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_FIN = Convert.ToDateTime(txtF_FINAL.Text);
                oDeclaracion.DECLARACION_PERSONALES.update();
                Int32 x = 1;
                Int32 ID_INGRESO = 199;
                foreach (GridViewRow row in grdPreguntas.Rows)
                {
                    V_COMPLEMENTO = ((TextBox)row.FindControl("txtRespuesta")).Text;
                    V_MONTO = ((TextBox)row.FindControl("txtMonto")).Text;
                    ID_INGRESO++;
                    if (x != 8 && x != 18 && x != 12)
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().M_INGRESO = ((TextBox)row.FindControl("txtMonto")).Text.Money();
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().E_ESPECIFICAR_COMPLEMENTO = ((TextBox)row.FindControl("txtRespuesta")).Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().update();
                    }
                    else if (x == 18)
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().E_ESPECIFICAR_COMPLEMENTO = txtObservaciones.Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().update();

                    }
                    else if (x == 8)
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().E_ESPECIFICAR_COMPLEMENTO = lblAuxiliar.Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().update();
                    }
                    else
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().E_ESPECIFICAR_COMPLEMENTO = lblAuxiliarBE.Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == ID_INGRESO).First().update();
                    }
                    x++;
                }
                marcaApartado(20);
            }
            catch (Exception ex)
            {

            }
           
            _oDeclaracion = oDeclaracion;
        }
        private void SumaDatos()
        {
            blld_MODIFICACION_INGRESOS oModificacion_Ingresos = _oModificacion_Ingresos;
            Int32 x = 1;
            String V_COMPLEMENTO;
            String Analisis;
            double Suma2 = 0;
            double Suma12 = 0;
            double Suma14 = 0;
           
            //string checadato = "0";
            foreach (GridViewRow row in grdPreguntas.Rows)
            {
                Analisis = TomaDesicion(Convert.ToInt32(((Label)row.FindControl("NID_INGRESO")).Text)).ToString();
                if (Analisis.Split('|')[0] != "F" && Analisis.Split('|')[1] == "202")
                {
                    V_COMPLEMENTO = ((TextBox)row.FindControl("txtMonto")).Text.Replace("$", "").Replace(",", "");
                    if (V_COMPLEMENTO.Length == 0)
                        V_COMPLEMENTO = "0";

                    Suma2 = Suma2 + Convert.ToDouble(V_COMPLEMENTO);
                }
                else if (Analisis.Split('|')[0] != "F" && Analisis.Split('|')[1] == "214")
                {
                    V_COMPLEMENTO = ((TextBox)row.FindControl("txtMonto")).Text.Replace("$", "").Replace(",", "");
                    if (V_COMPLEMENTO.Length == 0)
                        V_COMPLEMENTO = "0";
                    Suma12 = Suma12 + Convert.ToDouble(V_COMPLEMENTO);
                }
                else if (Analisis.Split('|')[0] != "F" && Analisis.Split('|')[1] == "216")
                {
                    V_COMPLEMENTO = ((TextBox)row.FindControl("txtMonto")).Text.Replace("$", "").Replace(",", "");
                    if (V_COMPLEMENTO.Length == 0)
                        V_COMPLEMENTO = "0";
                    Suma14 = Suma14 + Convert.ToDouble(V_COMPLEMENTO);
                }
                x++;
            }
            foreach (GridViewRow row in grdPreguntas.Rows)
            {
                if (((Label)row.FindControl("NID_INGRESO")).Text == "202")
                {
                    ((TextBox)row.FindControl("txtMonto")).Text = Suma2.ToString();
                    ((TextBox)row.FindControl("txtMonto")).ToolTip = DescribeCifras(((TextBox)row.FindControl("txtMonto")).Text);
                }

                if (((Label)row.FindControl("NID_INGRESO")).Text == "214")
                {
                    ((TextBox)row.FindControl("txtMonto")).Text = Convert.ToString(Suma2 + Suma12);
                    ((TextBox)row.FindControl("txtMonto")).ToolTip = DescribeCifras(((TextBox)row.FindControl("txtMonto")).Text);
                }
                if (((Label)row.FindControl("NID_INGRESO")).Text == "216")
                {
                    ((TextBox)row.FindControl("txtMonto")).Text = Convert.ToString(Suma2 + Suma12 + Suma14);
                    ((TextBox)row.FindControl("txtMonto")).ToolTip = DescribeCifras(((TextBox)row.FindControl("txtMonto")).Text);
                }
                x++;
            }
            Daformato();
        }
        private void Daformato()
        {
            Int32 j = 1;
            String Paso;
            foreach (GridViewRow row in grdPreguntas.Rows)
            {
                Paso = ((TextBox)row.FindControl("txtMonto")).Text;
                if (Paso != "")
                    //((TextBox)row.FindControl("txtMonto")).Text = string.Format("{0:###,###,###}", decimal.Parse(((TextBox)row.FindControl("txtMonto")).Text.Replace(",","")));
                    ((TextBox)row.FindControl("txtMonto")).Text = string.Format("{0:C0}", decimal.Parse(((TextBox)row.FindControl("txtMonto")).Text.Replace(",", "").Replace("$", "")));
                j++;
            }
        }
        protected void txtMonto_TextChanged(object sender, EventArgs e)
        {
            int valorNumerico = 0;
            Int32 k = 0;
            string checadato= ((TextBox)sender).Text;
            if (int.TryParse(checadato.Replace("$", "").Replace(",", ""), out valorNumerico))
                {
                //k = 0;
                ((TextBox)sender).ToolTip = DescribeCifras(((TextBox)sender).Text);
                }
                else
                {
                    k = 1;
                    AlertaSuperior.ShowSuccess("No puede utilizar caracteres en valores númerico favor de corregir");
                }

            if (k == 0)
                SumaDatos();
        }

        protected void cmbRespuestaBE_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAuxiliarBE.Text = ((DropDownList)sender).SelectedValue.ToString() + "|" + ((DropDownList)sender).SelectedItem.Text;
        }

        protected void cbxFuisteServidor_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxFuisteServidor.Checked==true)
            { this.cuerpo.Visible = true; } else { this.cuerpo.Visible = false; Limpia(); }
        }
        private void Limpia()
        {
            this.txtF_FINAL.Text = string.Empty;
            this.txtF_INGRESO.Text = string.Empty;
            this.txtObservaciones.Text = string.Empty;
            foreach (GridViewRow row in grdPreguntas.Rows)
            {
                ((TextBox)row.FindControl("txtMonto")).Text = string.Empty;
                ((TextBox)row.FindControl("txtRespuesta")).Text = string.Empty;
                ((DropDownList)row.FindControl("cmbRespuesta")).SelectedValue = "";
                ((DropDownList)row.FindControl("cmbRespuestaBE")).SelectedValue = "";
            }
        }
        private void GeneraTooltip()
        {
             int valorNumerico = 0;
            string checadato = "0";
            foreach (GridViewRow row in grdPreguntas.Rows)
            {
               
                 checadato = ((TextBox)row.FindControl("txtMonto")).Text;
                if (int.TryParse(checadato.Replace("$", "").Replace(",", ""), out valorNumerico))
                {
                    ((TextBox)row.FindControl("txtMonto")).ToolTip = DescribeCifras(((TextBox)row.FindControl("txtMonto")).Text);
                }
            }
       }
    }
}