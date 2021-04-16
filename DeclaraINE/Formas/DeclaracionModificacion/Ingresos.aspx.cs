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

namespace DeclaraINE.Formas.DeclaracionModificacion
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

        //private blld_CONFLICTO _oConflicto
        //{
        //    get => (blld_CONFLICTO)Session["oConflicto"];
        //    set => SessionAdd("oConflicto", value);
        //}

        public void Anterior()
        {
            ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioLaboral;
            Response.Redirect("DatosGenerales.aspx");
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
                grdPreguntas.DataSource = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.VID_NOMBRE==oDeclaracion.VID_NOMBRE && p.VID_FECHA==oDeclaracion.VID_FECHA && p.VID_HOMOCLAVE==oDeclaracion.VID_HOMOCLAVE && p.NID_DECLARACION == oDeclaracion.NID_DECLARACION && p.NID_INGRESO<18).ToList();
                grdPreguntas.DataBind();
               grdPreguntas.Rows[16].Visible = false;
                Daformato();
                SumaDatos();
                GeneraTooltip();

            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkIngresos")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkIngresos")).CssClass = "active";

            ltrSubTitulo.Text = "8. Ingresos netos del declarante, pareja y/o dependientes económicos (entre el 1 de enero y el 31 de diciembre del año inmediato anterior) <br/> <h6> Capturar cantidades libres de impuestos, sin comas, sin puntos, sin centavos y sin ceros a la izquierda </h6>";




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

            if (NID_APARTADO == 18)
            {
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => (new Int32[] { 18 }).Contains(p.NID_APARTADO) && p.L_ESTADO == false).Count() == 0)
                {
                    if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                    {
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO = true;
                        oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().update();
                    }
                }
            }
        }

        protected void cmbRespuesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAuxiliar.Text = ((DropDownList)sender).SelectedValue.ToString()+"|"+((DropDownList)sender).SelectedItem.Text;

        }

        protected void grdPreguntas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int ultima = e.Row.RowIndex;
            int NoCells = e.Row.Cells.Count;
            string Contenido ;
            string Desgloce;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Contenido = TomaDesicion(Convert.ToInt32(((Label)e.Row.FindControl("NID_INGRESO")).Text)).ToString();
                Desgloce = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                if(ultima == 6)
                {
                    this.lblAuxiliar.Text= ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                }
                if (ultima == 10)
                {
                    this.lblAuxiliarBE.Text = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                }
                if (ultima == 1 || ultima == 13 || ultima == 15 )
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
                else if(ultima==14)
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                    ((TextBox)e.Row.FindControl("txtMonto")).CssClass = String.Empty;
                    //this.txtObservaciones.Text = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                    //((TextBox)e.Row.FindControl("txtRespuesta")).MaxLength=2000;
                    //((TextBox)e.Row.FindControl("txtRespuesta")).ToolTip = "Longitud máxima 2000 caracteres";
                }
                else if (ultima == 16)
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                    ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                    this.txtObservaciones.Text = ((TextBox)e.Row.FindControl("txtRespuesta")).Text;
                    //((TextBox)e.Row.FindControl("txtRespuesta")).MaxLength=2000;
                    //((TextBox)e.Row.FindControl("txtRespuesta")).ToolTip = "Longitud máxima 2000 caracteres";
                }
                else
                { 

               
                if (Contenido.Split('|')[0] == "T" )
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = String.Empty;
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                        ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                        ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                    if (e.Row.RowIndex == -1) ((TextBox)e.Row.FindControl("txtRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);

                    //if (e.Row.RowIndex == -1) ((TextBox)e.Row.FindControl("txtRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);
                }
                if (Contenido.Split('|')[0] == "C")
                {
                        if (ultima == 10)
                        {
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible"; 
                            ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                            ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = String.Empty;
                            ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).SelectedValue = Desgloce.Split('|')[0].ToString();
                        }
                        else
                        {
                            ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                            ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = String.Empty;
                            ((TextBox)e.Row.FindControl("txtMonto")).CssClass = "invisible";
                            blld__l_CAT_INSTRUMENTO_RENDIMIENTO oCAT_INSTRUMENTO_RENDIMIENTO = new blld__l_CAT_INSTRUMENTO_RENDIMIENTO();
                            oCAT_INSTRUMENTO_RENDIMIENTO.select();
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).DataBind(oCAT_INSTRUMENTO_RENDIMIENTO.lista_CAT_INSTRUMENTO_RENDIMIENTO, CAT_INSTRUMENTO_RENDIMIENTO.Properties.NID_INSTRUMENTO_RENDIMIENTO, CAT_INSTRUMENTO_RENDIMIENTO.Properties.V_INSTRUMENTO_RENDIMIENTO, false);
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).SelectedValue = Desgloce.Split('|')[0].ToString();
                            ((DropDownList)e.Row.FindControl("cmbRespuesta")).Items.Insert(0, new ListItem(string.Empty));
                            // if (e.Row.RowIndex == -1) ((DropDownList)e.Row.FindControl("cmbRespuesta")).Attributes.Add("requerido", btnGuardarPreguntas.ClientID);

                            
                        }

                }
                if (Contenido.Split('|')[0] == "M" || Contenido.Split('|')[0] == "F")
                {
                    ((TextBox)e.Row.FindControl("txtRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuesta")).CssClass = "invisible";
                    ((DropDownList)e.Row.FindControl("cmbRespuestaBE")).CssClass = "invisible";
                    ((TextBox)e.Row.FindControl("txtMonto")).CssClass = String.Empty;
                    ((TextBox)e.Row.FindControl("txtMonto")).ReadOnly = false;
                    //((TextBox)e.Row.FindControl("txtMonto")).Attributes.Add("OnKeyPress", "return AcceptaPuntoNum(event)");
                    
                }
            }
            Desgloce = "";
              

            }

         }
        protected void cmbRespuestaBE_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAuxiliarBE.Text = ((DropDownList)sender).SelectedValue.ToString() + "|" + ((DropDownList)sender).SelectedItem.Text;
        }
        internal static string TomaDesicion( int NID_INGRESO)
        {
           
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query =( (from p in dbInt.CAT_SECCION_INGRESO
                              where p.NID_RUBRO == NID_INGRESO && p.NID_SECCION==4

                              select  p.CID_TIPO.ToString() + "|" + p.NID_RUBRO_SUMA ).First()) ;
                return query;

            }
            catch
            {
                return "";
            }
        }
        //internal static string TraeConcepto
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
                    if (x != 7 && x != 17 && x != 11)
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().M_INGRESO = ((TextBox)row.FindControl("txtMonto")).Text.Money();
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().E_ESPECIFICAR_COMPLEMENTO = ((TextBox)row.FindControl("txtRespuesta")).Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().update();
                    }
                    else if (x == 17)
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().E_ESPECIFICAR_COMPLEMENTO = txtObservaciones.Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().update();

                    }
                    else if (x == 7)
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().E_ESPECIFICAR_COMPLEMENTO = lblAuxiliar.Text;
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().update();
                    }
                    else
                    {
                        oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.NID_INGRESO == x).First().E_ESPECIFICAR_COMPLEMENTO = lblAuxiliarBE.Text;
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
                if(Analisis.Split('|')[0] != "F" && Analisis.Split('|')[1] == "2")
                {
                    V_COMPLEMENTO = ((TextBox)row.FindControl("txtMonto")).Text.Replace("$","").Replace(",","");
                    if (V_COMPLEMENTO.Length == 0)
                        V_COMPLEMENTO = "0";

                    Suma2 =Suma2 + Convert.ToDouble(V_COMPLEMENTO);
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
                if(((Label)row.FindControl("NID_INGRESO")).Text=="2")
                {
                    ((TextBox)row.FindControl("txtMonto")).Text = Suma2.ToString();
                    ((TextBox)row.FindControl("txtMonto")).ToolTip = DescribeCifras(((TextBox)row.FindControl("txtMonto")).Text);
                }

                if (((Label)row.FindControl("NID_INGRESO")).Text == "14")
                {
                    ((TextBox)row.FindControl("txtMonto")).Text =Convert.ToString( Suma2+Suma12);
                    ((TextBox)row.FindControl("txtMonto")).ToolTip = DescribeCifras(((TextBox)row.FindControl("txtMonto")).Text);
                }
                if (((Label)row.FindControl("NID_INGRESO")).Text == "16")
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
                if(Paso !="")
                    //((TextBox)row.FindControl("txtMonto")).Text = string.Format("{0:###,###,###}", decimal.Parse(((TextBox)row.FindControl("txtMonto")).Text.Replace(",","")));
                    ((TextBox)row.FindControl("txtMonto")).Text = string.Format("{0:C0}", decimal.Parse(((TextBox)row.FindControl("txtMonto")).Text.Replace(",", "").Replace("$","")));
                j++;
            }
        }
        protected void txtMonto_TextChanged(object sender, EventArgs e)
        {
            int valorNumerico = 0;
            Int32 k=0 ;
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
            
            if(k==0)
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
    }
}