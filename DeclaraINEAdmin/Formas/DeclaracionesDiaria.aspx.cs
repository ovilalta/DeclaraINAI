using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using HectorOfficeExtensions;
using System.IO;
using HectorOfficeExtensions.Templates.Excel;

namespace DeclaraINEAdmin.Formas
{
    public partial class DeclaracionesDiaria : Pagina
    {
        private Boolean Alterna
        {
            get => (Boolean)ViewState["Alterna"];
            set => ViewState["Alterna"] = value;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("DeclaracionesDiaria.aspx");

            if (!IsPostBack)
            {
                Alterna = true;
                txtFInicialCalendar.StartDate = new DateTime(2018, 4, 30);
                txtFFinalCalendar.StartDate = new DateTime(2018, 5, 1);
                txtFInicialCalendar.EndDate = DateTime.Today;
                txtFFinalCalendar.EndDate = DateTime.Today;
                txtFInicialCalendar.SelectedDate = DateTime.Today;
                txtFFinalCalendar.SelectedDate = DateTime.Today;

                txtFInicial.Text = DateTime.Today.ToString(strFormatoFecha);
                txtFFinal.Text = DateTime.Today.ToString(strFormatoFecha);
           

                cblTipoDeclaracion.DataBinder<blld__l_CAT_TIPO_DECLARACION>(new blld__l_CAT_TIPO_DECLARACION(),
                CAT_TIPO_DECLARACION.Properties.NID_TIPO_DECLARACION,
                CAT_TIPO_DECLARACION.Properties.V_TIPO_DECLARACION
                );

                foreach (ListItem item in cblTipoDeclaracion.Items)
                {
                    if ((new String[] { "1", "2", "3" }).Contains(item.Value))
                        item.Selected = true;
                }

                btnBuscar_Click(sender, e);
            }
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                Alterna = !Alterna;

                o.F_ENVIO = new DateTimeFilter(txtFInicial.Date(esMX), txtFFinal.Date(esMX));

                txtFInicialCalendar.SelectedDate = txtFInicial.Date(esMX);
                txtFFinalCalendar.SelectedDate = txtFFinal.Date(esMX);

                if (cbxFiltroTipoDeclaracion.Checked)
                {
                    o.NID_TIPO_DECLARACIONs.FilterCondition = Declara_V2.ListFilter.FilterConditions.Normal;
                    foreach (ListItem item in cblTipoDeclaracion.Items)
                    {
                        if (item.Selected)
                            o.NID_TIPO_DECLARACIONs.Add(Convert.ToInt32(item.Value));
                    }
                }
                else { }

                o.NID_ESTADOs.Add(2);
                o.NID_ESTADOs.Add(3);
                o.select();
                grdDeclaracionesDiarias.DataSource = o.lista_DECLARACION_DIARIA;
                grdDeclaracionesDiarias.DataBind();
                SessionAdd("Object1", o.lista_DECLARACION_DIARIA);
                pnlGrid.Update();
                pnlFiltros.Update();
                if (!o.lista_DECLARACION_DIARIA.Any())
                {
                    pnlExcel.Visible = false;
                    if (Alterna)
                        AlertaBusqueda.ShowWarning("La busqueda no produjo resultados");
                    else
                        AlertaBusqueda.ShowDanger("La busqueda no produjo resultados");
                   
                }
                else {
                    pnlExcel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    AlertaBusqueda.ShowDanger(ex.Message);
                }
                else throw ex;
            }
            pnlAlerta.Update();

        }

        protected void btnDiaMas_Click(object sender, EventArgs e)
        {
            if (DateTime.Today > txtFInicial.Date(esMX) && DateTime.Now > txtFFinal.Date(esMX))
            {
                txtFInicial.Text = txtFInicial.Date(esMX).AddDays(1).ToString(strFormatoFecha);
                txtFFinal.Text = txtFFinal.Date(esMX).AddDays(1).ToString(strFormatoFecha);
                txtFInicialCalendar.SelectedDate = txtFInicial.Date(esMX);
                txtFFinalCalendar.SelectedDate = txtFFinal.Date(esMX);
                btnBuscar_Click(sender, e);
            }
        }

        protected void btnDiaMenos_Click(object sender, EventArgs e)
        {
            if (txtFInicial.Date(esMX) > new DateTime(2018, 5, 1) && txtFFinal.Date(esMX) > new DateTime(2018, 4, 1))
            {
                txtFInicial.Text = txtFInicial.Date(esMX).AddDays(-1).ToString(strFormatoFecha);
                txtFFinal.Text = txtFFinal.Date(esMX).AddDays(-1).ToString(strFormatoFecha);
                txtFInicialCalendar.SelectedDate = txtFInicial.Date(esMX);
                txtFFinalCalendar.SelectedDate = txtFFinal.Date(esMX);
                btnBuscar_Click(sender, e);
                pnlFecha.Update();
                pnlFiltros.Update();
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            List<DECLARACION_DIARIA> source = (List<DECLARACION_DIARIA>)Session["Object1"];
            String file = Path.GetRandomFileName() ;
            String folder = Path.GetTempPath();
            ExcelBookBuilder builder = new ExcelBookBuilder(file, folder);
            List<Estructura> Columns = new List<Estructura>();
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.F_POSESION.ToString(),"Fecha de Inicio o Conclusión"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.F_ENVIO.ToString(), "Fecha y Hora de Envio"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.F_REGISTRO.ToString(), "Fecha de Registro"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.V_NOMBRE_COMPLETO.ToString(), "Nombre"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.V_RFC.ToString(), "R.F.C."));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.V_AUTORIZA_PUBLICAR.ToString(), "Pública"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.N_ENVIO_DIA.ToString(), "Dia"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.N_ENVIO_MES.ToString(), "Mes"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.V_PRIMER_NIVEL.ToString(), "Unidad Administrativa"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.V_SEGUNDO_NIVEL.ToString(), "Area de Adscripción"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.V_PUESTO.ToString(), "Cargo"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.VID_PUESTO.ToString(), "Id Cargo"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.VID_NIVEL.ToString(), "Nivel"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.C_EJERCICIO.ToString(), "Ejercicio"));
            Columns.Add(new Estructura(DECLARACION_DIARIA.Properties.V_TIPO_DECLARACION.ToString(), "Tipo de Declaración"));
            builder.DataSource<DECLARACION_DIARIA>(source,"HOLA",Columns);
            String output = builder.Export();

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" );
            HttpContext.Current.Response.WriteFile(output);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(output);
            HttpContext.Current.Response.End();
        }

        protected void cbxFiltroTipoDeclaracion_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroTipo.Visible = cbxFiltroTipoDeclaracion.Checked;
        }

        protected void grdDeclaracionesDiarias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDeclaracionesDiarias.PageIndex = e.NewPageIndex;
            grdDeclaracionesDiarias.DataBind((List<DECLARACION_DIARIA>)Session["Object1"]);
        }
    }
}