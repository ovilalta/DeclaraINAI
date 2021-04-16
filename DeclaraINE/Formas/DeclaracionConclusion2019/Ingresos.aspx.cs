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



namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class Ingresos : Pagina, IDeclaracionInicial
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
        private blld_MODIFICACION_INGRESOS _oModificacion_Ingresos
        {
            get => (blld_MODIFICACION_INGRESOS)Session["oModificacion_Ingresos"];
            set => SessionAdd("oModificacion_Ingresos", value);
        }
        protected void Page_Init(Object sender, EventArgs e)
        {

           

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)Master.FindControl("liIngresos")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu8")).Attributes.Add("class", "tab-pane fade level1 active in");
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!IsPostBack)
            {
                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Siguiente";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "next";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Siguiente apartado";
                grdPreguntas.DataSource = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.VID_NOMBRE == oDeclaracion.VID_NOMBRE && p.VID_FECHA == oDeclaracion.VID_FECHA && p.VID_HOMOCLAVE == oDeclaracion.VID_HOMOCLAVE && p.NID_DECLARACION == oDeclaracion.NID_DECLARACION && p.NID_INGRESO < 16).ToList();
                grdPreguntas.DataBind();
                grdPreguntas.Rows[14].Visible = false;
                Daformato();
                SumaDatos();
                GeneraTooltip();
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkIngresos")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkIngresos")).CssClass = "active";

            ltrSubTitulo.Text = "Ingresos Netos del declarante, pareja y/o dependientes económicos(situación actual) <br/> <h6> Capturar cantidades libres de impuestos, sin comas, sin puntos, sin centavos y sin ceros a la izquierda </h6>";

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
                if (ultima == 6)
                {
                    this.lblAuxiliar.Text = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                }
                if (ultima == 1 || ultima == 11 || ultima == 13)
                {
                    if (Contenido.Split('|')[0] == "M" || Contenido.Split('|')[0] == "F")
                    {
                        ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = String.Empty;

                        ((TextBox)e.Row.FindControl("txtMonto")).Enabled = false;
                    }
                }
                else if (ultima == 14)
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = String.Empty;
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                    ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                    this.txtObservaciones.Text = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                    //((TextBox)e.Row.FindControl("txtRespuesta")).MaxLength=2000;
                    //((TextBox)e.Row.FindControl("txtRespuesta")).ToolTip = "Longitud máxima 2000 caracteres";
                }

                else
                {


                    if (Contenido.Split('|')[0] == "T")
                    {
                        ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = String.Empty;
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                        if (e.Row.RowIndex == -1) ((TextBox)e.Row.FindControl("txtRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);

                        //if (e.Row.RowIndex == -1) ((TextBox)e.Row.FindControl("txtRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);
                    }
                    if (Contenido.Split('|')[0] == "C")
                    {
                        ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = String.Empty;
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                        blld__l_CAT_INSTRUMENTO_RENDIMIENTO oCAT_INSTRUMENTO_RENDIMIENTO = new blld__l_CAT_INSTRUMENTO_RENDIMIENTO();
                        oCAT_INSTRUMENTO_RENDIMIENTO.select();
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).DataBind(oCAT_INSTRUMENTO_RENDIMIENTO.lista_CAT_INSTRUMENTO_RENDIMIENTO, CAT_INSTRUMENTO_RENDIMIENTO.Properties.NID_INSTRUMENTO_RENDIMIENTO, CAT_INSTRUMENTO_RENDIMIENTO.Properties.V_INSTRUMENTO_RENDIMIENTO, false);
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).SelectedValue = Desgloce.Split('|')[0].ToString();
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).Items.Insert(0, new ListItem(string.Empty));
                        // if (e.Row.RowIndex == -1) ((DropDownList)e.Row.FindControl("cmbRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);

                    }
                    if (Contenido.Split('|')[0] == "M" || Contenido.Split('|')[0] == "F")
                    {
                        ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = String.Empty;
                        ((TextBox)e.Row.FindControl("txtMonto")).ReadOnly = false;
                        //((TextBox)e.Row.FindControl("txtMonto")).Attributes.Add("OnKeyPress", "return AcceptaPuntoNum(event)");

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
                              where p.NID_RUBRO == NID_INGRESO && p.NID_SECCION == 1

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
                Int32 x = 1;
                foreach (GridViewRow row in grdPreguntas.Rows)
                {
                    V_COMPLEMENTO = ((TextBox)row.FindControl("txtRespuesta")).Text;
                    V_MONTO = ((TextBox)row.FindControl("txtMonto")).Text;
                    if (x != 7 && x != 15)
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().M_INGRESO = ((TextBox)row.FindControl("txtMonto")).Text.Money();
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().E_ESPECIFICAR_COMPLEMENTO = ((TextBox)row.FindControl("txtRespuesta")).Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().update();
                    }
                    else if (x == 15)
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().E_ESPECIFICAR_COMPLEMENTO = txtObservaciones.Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().update();

                    }
                    else
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().E_ESPECIFICAR_COMPLEMENTO = lblAuxiliar.Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().update();
                    }
                    x++;
                }
                marcaApartado(18);
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
            foreach (GridViewRow row in grdPreguntas.Rows)
            {
                Analisis = TomaDesicion(x);
                if (Analisis.Split('|')[0] != "F" && Analisis.Split('|')[1] == "2")
                {
                    V_COMPLEMENTO = ((TextBox)row.FindControl("txtMonto")).Text.Replace("$", "").Replace(",", "");
                    if (V_COMPLEMENTO.Length == 0)
                        V_COMPLEMENTO = "0";

                    Suma2 = Suma2 + Convert.ToDouble(V_COMPLEMENTO);
                }
                else if (Analisis.Split('|')[0] != "F" && Analisis.Split('|')[1] == "12")
                {
                    V_COMPLEMENTO = ((TextBox)row.FindControl("txtMonto")).Text.Replace("$", "").Replace(",", "");
                    if (V_COMPLEMENTO.Length == 0)
                        V_COMPLEMENTO = "0";
                    Suma12 = Suma12 + Convert.ToDouble(V_COMPLEMENTO);
                }
                else if (Analisis.Split('|')[0] != "F" && Analisis.Split('|')[1] == "14")
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
                if (((Label)row.FindControl("NID_INGRESO")).Text == "2")
                {
                    ((TextBox)row.FindControl("txtMonto")).Text = Suma2.ToString();
                    ((TextBox)row.FindControl("txtMonto")).ToolTip = DescribeCifras(((TextBox)row.FindControl("txtMonto")).Text);
                }

                if (((Label)row.FindControl("NID_INGRESO")).Text == "12")
                {
                    ((TextBox)row.FindControl("txtMonto")).Text = Convert.ToString(Suma2 + Suma12);
                    ((TextBox)row.FindControl("txtMonto")).ToolTip = DescribeCifras(((TextBox)row.FindControl("txtMonto")).Text);
                }
                if (((Label)row.FindControl("NID_INGRESO")).Text == "14")
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
            string checadato = ((TextBox)sender).Text;
            if (int.TryParse(checadato.Replace("$", "").Replace(",", ""), out valorNumerico))
            {
                //Verifica que sea númerico;
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
       

        public void Anterior()
        {
            Response.Redirect("AdeudosModifica.aspx");
        }

        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            SalvaDatos();
            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
            {
                // AQUI VA EL CODIGO DEL APARTADO
                //---------------------------------------------------

                marcaApartado(18);
                //---------------------------------------------------
            }
            //Response.Redirect("TarjetasDeCredito.aspx");
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

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 26, 27 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
            {
                if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                {
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO = true;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().update();
                }
            }
            oDeclaracion = _oDeclaracion;
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            marcaApartado(12);
            Response.Redirect("AdeudosModifica.aspx");
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }
    }
}