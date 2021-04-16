using AlanWebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using System.IO;
using DeclaraINEAdmin.file;
using Declara_V2;

namespace DeclaraINEAdmin.Formas
{
    public partial class DeclaracionTestadoConsulta : Pagina
    {
        private List<Declara_V2.MODELextended.DECLARACION_DIARIA> Resultados
        {
            get => (List<Declara_V2.MODELextended.DECLARACION_DIARIA>)Session["Object1"];
            set => SessionAdd("Object1", value);
        }

        private blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["Object2"];
            set => SessionAdd("Object2", value);
        }

        private System.Nullable<Int32> Index
        {
            get => (System.Nullable<Int32>)ViewState["Index"];
            set => ViewState["Index"] = value;
        }

        private System.Nullable<Int32> Row
        {
            get => (System.Nullable<Int32>)ViewState["Row"];
            set => ViewState["Row"] = value;
        }

        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("DeclaracionTestadoConsulta.aspx");
                cblEstados.DataBinder<blld__l_CAT_ESTADO_TESTADO>(new blld__l_CAT_ESTADO_TESTADO(),
                          CAT_ESTADO_TESTADO.Properties.NID_ESTADO_TESTADO,
                          CAT_ESTADO_TESTADO.Properties.V_ESTADO_TESTADO,
                          1
                          );

                cblTipoDeclaracion.DataBinder<blld__l_CAT_TIPO_DECLARACION>(new blld__l_CAT_TIPO_DECLARACION(),
                      CAT_TIPO_DECLARACION.Properties.NID_TIPO_DECLARACION,
                      CAT_TIPO_DECLARACION.Properties.V_TIPO_DECLARACION
                      );

                for (int x = 1; x <= 12; x++)
                {
                    cblMes.Items.Add(new ListItem { Value = x.ToString(), Text = new DateTime(2000, x, 1).ToString("MMMM").ToUpper() });
                }


                foreach (ListItem item in cblEstados.Items)
                {
                    if ((new String[] { "1", "2", "3" }).Contains(item.Value))
                        item.Selected = true;
                }
                btnBuscar_Click(btnBuscar, null);
            }

            try
            {
                foreach (GridViewRow row in grid.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
   
                    }
                }
            }
            catch { }
        }
        protected void cbxFiltroRFC_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroRFC.Visible = cbxFiltroRFC.Checked;
        }

        protected void cbxFiltroNombre_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroNombre.Visible = cbxFiltroNombre.Checked;
        }

        protected void cbxFiltroEstadoTestado_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroEstadoTestado.Visible = cbxFiltroEstadoTestado.Checked;
        }

        protected void cbxFiltroAutoriza_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroAutorizaPublicar.Visible = cbxFiltroAutoriza.Checked;
        }

        protected void cbxFiltroTipoDeclaracion_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroTipo.Visible = cbxFiltroTipoDeclaracion.Checked;
        }

        protected void cbxFiltroMes_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroMes.Visible = cbxFiltroMes.Checked;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                o.NID_ESTADOs.Add(2);
                o.NID_ESTADOs.Add(3);


                if (cbxFiltroEstadoTestado.Checked)
                {
                    o.NID_ESTADO_TESTADOs.FilterCondition = Declara_V2.ListFilter.FilterConditions.Normal;
                    foreach (ListItem item in cblEstados.Items)
                    {
                        if (item.Selected)
                            o.NID_ESTADO_TESTADOs.Add(Convert.ToInt32(item.Value));
                    }
                }
                else { }


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

                if (cbxFiltroRFC.Checked)  { o.V_RFC = new Declara_V2.StringFilter(txtRFC.Text,StringFilter.FilterType.like); } else { }
                if (cbxFiltroNombre.Checked) { o.V_NOMBRE_COMPLETO = new Declara_V2.StringFilter(txtNombre.Text, StringFilter.FilterType.like); } else { }

                if (cbxFiltroMes.Checked)
                {
                    o.NID_ENVIO_MESs.FilterCondition = Declara_V2.ListFilter.FilterConditions.Normal;
                    foreach (ListItem item in cblMes.Items)
                    {
                        if (item.Selected)
                            o.NID_ENVIO_MESs.Add(Convert.ToInt32(item.Value));
                    }
                }
                else { }

                if (cbxFiltroAutoriza.Checked)
                    o.L_AUTORIZA_PUBLICAR = cbxAutorizaPublicar.Checked;
                else
                    o.L_AUTORIZA_PUBLICAR = null;

                o.select();
                Resultados = o.lista_DECLARACION_DIARIA;
                grid.DataBind(o.lista_DECLARACION_DIARIA);
                pnlGridResultados.Update();

            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    AlertaBusqueda.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid.PageIndex = e.NewPageIndex;
            grid.DataBind(Resultados);
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Int32 row = Convert.ToInt32(((Button)e.Row.FindControl("btnEditar")).CommandArgument);

                String VID_NOMBRE = Resultados[row].VID_NOMBRE;
                String VID_FECHA = Resultados[row].VID_FECHA;
                String VID_HOMOCLAVE = Resultados[row].VID_HOMOCLAVE;
                Int32 NID_DECLARACION = Resultados[row].NID_DECLARACION;

                blld_DECLARACION o = new blld_DECLARACION(VID_NOMBRE
                                                                    , VID_FECHA
                                                                    , VID_HOMOCLAVE
                                                                    , NID_DECLARACION
                                                                   );

                ((Literal)e.Row.FindControl("ltrPop")).Text = o.E_OBSERVACIONES;
                ((Panel)e.Row.FindControl("popTestado")).Visible = (new Int32[] { 2, 3, 4 }).Contains(o.NID_ESTADO_TESTADO);
                if (((Panel)e.Row.FindControl("popTestado")).Visible)
                    ((Literal)e.Row.FindControl("ltrPopTestado")).Text = o.V_OBSERVACIONES_TESTADO;
                ((Panel)e.Row.FindControl("pnlTestar")).Visible = (new Int32[] { 1, 2, 3, }).Contains(o.NID_ESTADO_TESTADO);

                ((Button)e.Row.FindControl("btnAprobarFinalizar")).Enabled = (new Int32[] { 1, 2 }).Contains(o.NID_ESTADO_TESTADO);
                ((Button)e.Row.FindControl("btnAprobar")).Enabled = (new Int32[] { 3 }).Contains(o.NID_ESTADO_TESTADO);

                ScriptManager.GetCurrent(Page).RegisterPostBackControl(((Button)e.Row.FindControl("btnPDFGrid")));
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(((Button)e.Row.FindControl("btnPDFTestadoGrid")));

                switch (o.NID_TIPO_DECLARACION)
                {
                    case 2:
                        switch (o.DECLARACION_PERSONALES.C_GENERO)
                        {
                            case "M":
                                ((Image)e.Row.FindControl("NID_TIPO_DECLARACION")).ImageUrl = "~/Images/CAT_TIPO_DECLARACION/modificacionM1.png";
                                break;
                            case "F":
                                ((Image)e.Row.FindControl("NID_TIPO_DECLARACION")).ImageUrl = "~/Images/CAT_TIPO_DECLARACION/modificacionF1.png";
                                break;
                            default:
                                ((Image)e.Row.FindControl("NID_TIPO_DECLARACION")).ImageUrl = "~/Images/CAT_TIPO_DECLARACION/modificacion1.png";
                                break;
                        }
                        break;
                    case 1:
                        ((Image)e.Row.FindControl("NID_TIPO_DECLARACION")).ImageUrl = "~/Images/CAT_TIPO_DECLARACION/inicial1.png";
                        break;
                    case 3:
                        ((Image)e.Row.FindControl("NID_TIPO_DECLARACION")).ImageUrl = "~/Images/CAT_TIPO_DECLARACION/conclusion1.png";
                        break;
                    default:
                        ((Image)e.Row.FindControl("NID_TIPO_DECLARACION")).ImageUrl = "~/Images/CAT_TIPO_DECLARACION/nd.png";
                        break;
                }
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            mdlTestar.Hide();
            pnlGridResultados.Update();
            this.Row = null;
            this.Index = null;
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Index = grid.SelectedIndex;
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 row = Convert.ToInt32(e.CommandArgument);//
            this.Row = row;

            String Command = e.CommandName;

            String VID_NOMBRE = Resultados[row].VID_NOMBRE;
            String VID_FECHA = Resultados[row].VID_FECHA;
            String VID_HOMOCLAVE = Resultados[row].VID_HOMOCLAVE;
            Int32 NID_DECLARACION = Resultados[row].NID_DECLARACION;

            blld_DECLARACION o = new blld_DECLARACION(VID_NOMBRE
                                                         , VID_FECHA
                                                         , VID_HOMOCLAVE
                                                         , NID_DECLARACION
                                                        );
            this._oDeclaracion = o;
            blld_USUARIO oUsuario = new blld_USUARIO(VID_NOMBRE
                                              , VID_FECHA
                                              , VID_HOMOCLAVE
                                              );
            switch (Command)
            {
                case "Select":
                    this.Index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent.Parent)).RowIndex;
                    mdlTestar.Show(true);
                    pnlTestar.Enabled = (new Int32[] { 1, 2, 3 }).Contains(o.NID_ESTADO_TESTADO);
                    if ((new Int32[] { 1, 2 }).Contains(o.NID_ESTADO_TESTADO))
                        btnAprobarFinalizar.Enabled = true;
                    else
                        btnAprobarFinalizar.Enabled = false;
                    if ((new Int32[] { 2, 3 }).Contains(o.NID_ESTADO_TESTADO))
                        btnAprobar.Enabled = true;
                    else
                        btnAprobar.Enabled = false;
                    mdlTestar.HeaderText = String.Concat(o.VID_NOMBRE, "-", o.VID_FECHA, '-', o.VID_HOMOCLAVE, "  ", oUsuario.V_PRIMER_A, " ", oUsuario.V_SEGUNDO_A, " ", oUsuario.V_NOMBRE);
                    oUsuario = null;
                    txtE_OBSERVACIONES.Text = o.E_OBSERVACIONES;
                    txtE_OBSERVACIONES_MARCADO.Text = o.E_OBSERVACIONES_MARCADO;
                    txtV_OBSERVACIONES_TESTADO.Text = o.V_OBSERVACIONES_TESTADO;
                    break;
                case "Finaliza":
                    this.Index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent.Parent)).RowIndex;
                    mdlTestar.Show(true);
                    txtE_OBSERVACIONES_MARCADO.Text = o.E_OBSERVACIONES_MARCADO;
                    btnAprobarFinalizar_Click(btnAprobarFinalizar, e);
                    mdlTestar.Hide();
                    break;
                case "Aprobar":
                    this.Index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent.Parent)).RowIndex;
                    mdlTestar.Show(true);
                    txtE_OBSERVACIONES_MARCADO.Text = o.E_OBSERVACIONES_MARCADO;
                    btnAprobar_Click(btnAprobar, e);
                    mdlTestar.Hide();
                    break;
                case "PDF":
                    this.Index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
                    btnPDF_Click(((Button)grid.Rows[this.Index.Value].FindControl("btnPDFGrid")), e);
                    break;
                case "PDFTestado":
                    this.Index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
                    brnPDFTestado_Click(((Button)grid.Rows[this.Index.Value].FindControl("btnPDFTestadoGrid")), e);
                    break;
                default:
                    break;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            try
            {
                oDeclaracion.E_OBSERVACIONES_MARCADO = txtE_OBSERVACIONES_MARCADO.Text;
                oDeclaracion.GuardarTestado();
                txtV_OBSERVACIONES_TESTADO.Text = oDeclaracion.V_OBSERVACIONES_TESTADO;
                lrtDetalle.ShowSuccess("Se guardó correctamente el marcado");
                AlertaBusqueda.ShowSuccess("Se guardó correctamente el marcado");

                ((Image)grid.Rows[Index.Value].FindControl("NID_ESTADO_TESTADO")).ImageUrl = String.Concat("~/Images/CAT_ESTADO_TESTADO/", oDeclaracion.NID_ESTADO_TESTADO, ".png");
                ((Literal)grid.Rows[Index.Value].FindControl("V_ESTADO_TESTADO")).Text = oDeclaracion.V_ESTADO_TESTADO;
                ((Literal)grid.Rows[Index.Value].FindControl("ltrPopTestado")).Text = oDeclaracion.V_OBSERVACIONES_TESTADO;
                Resultados[Row.Value].NID_ESTADO_TESTADO = oDeclaracion.NID_ESTADO_TESTADO;
                Resultados[Row.Value].V_ESTADO_TESTADO = oDeclaracion.V_ESTADO_TESTADO;
                ((Panel)grid.Rows[Index.Value].FindControl("popTestado")).Visible = true;
                pnlGridResultados.Update();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    lrtDetalle.ShowDanger(ex.Message);
                }
            }

            _oDeclaracion = oDeclaracion;
        }

        protected void btnAprobarFinalizar_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            try
            {
                oDeclaracion.E_OBSERVACIONES_MARCADO = txtE_OBSERVACIONES_MARCADO.Text;
                oDeclaracion.FinalizarTestado();
                txtV_OBSERVACIONES_TESTADO.Text = oDeclaracion.V_OBSERVACIONES_TESTADO;
                lrtDetalle.ShowSuccess("Se finalizó correctamente el testado");
                AlertaBusqueda.ShowSuccess("Se finalizó correctamente el testado");
                btnAprobarFinalizar.Enabled = false;
                btnAprobar.Enabled = true;

                ((Image)grid.Rows[Index.Value].FindControl("NID_ESTADO_TESTADO")).ImageUrl = String.Concat("~/Images/CAT_ESTADO_TESTADO/", oDeclaracion.NID_ESTADO_TESTADO, ".png");
                ((Literal)grid.Rows[Index.Value].FindControl("V_ESTADO_TESTADO")).Text = oDeclaracion.V_ESTADO_TESTADO;
                ((Literal)grid.Rows[Index.Value].FindControl("ltrPopTestado")).Text = oDeclaracion.V_OBSERVACIONES_TESTADO;
                ((Button)grid.Rows[Index.Value].FindControl("btnAprobarFinalizar")).Enabled = false;
                ((Button)grid.Rows[Index.Value].FindControl("btnAprobar")).Enabled = true;

                Resultados[Row.Value].NID_ESTADO_TESTADO = oDeclaracion.NID_ESTADO_TESTADO;
                Resultados[Row.Value].V_ESTADO_TESTADO = oDeclaracion.V_ESTADO_TESTADO;
                ((Panel)grid.Rows[Index.Value].FindControl("popTestado")).Visible = true;
                pnlGridResultados.Update();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    lrtDetalle.ShowDanger(ex.Message);
                    AlertaBusqueda.ShowDanger(ex.Message);
                }
            }

            _oDeclaracion = oDeclaracion;
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            try
            {
                oDeclaracion.E_OBSERVACIONES_MARCADO = txtE_OBSERVACIONES_MARCADO.Text;
                oDeclaracion.AprobarTestado();
                mdlTestar.Hide();
                AlertaBusqueda.ShowSuccess("Se aprobó correctamente el testado");
                pnlTestar.Enabled = false;
                btnAprobarFinalizar.Enabled = false;


                ((Image)grid.Rows[Index.Value].FindControl("NID_ESTADO_TESTADO")).ImageUrl = String.Concat("~/Images/CAT_ESTADO_TESTADO/", oDeclaracion.NID_ESTADO_TESTADO, ".png");
                ((Literal)grid.Rows[Index.Value].FindControl("V_ESTADO_TESTADO")).Text = oDeclaracion.V_ESTADO_TESTADO;
                ((Literal)grid.Rows[Index.Value].FindControl("ltrPopTestado")).Text = oDeclaracion.V_OBSERVACIONES_TESTADO;
                ((Button)grid.Rows[Index.Value].FindControl("btnAprobar")).Enabled = false;
                Resultados[Row.Value].NID_ESTADO_TESTADO = oDeclaracion.NID_ESTADO_TESTADO;
                Resultados[Row.Value].V_ESTADO_TESTADO = oDeclaracion.V_ESTADO_TESTADO;
                pnlGridResultados.Update();

                this.Row = null;
                this.Index = null;
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    lrtDetalle.ShowDanger(ex.Message);
                }
            }

            _oDeclaracion = oDeclaracion;
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            Dec_Mantenimiento.Declaracion(oDeclaracion);

            _oDeclaracion = oDeclaracion;
        }

        protected void brnPDFTestado_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            DeclaracionTestada(oDeclaracion);

            _oDeclaracion = oDeclaracion;
        }

        public static void DeclaracionTestada(blld_DECLARACION oDeclaracion)
        {
            switch (oDeclaracion.NID_TIPO_DECLARACION)
            {
                case 1:
                    ImprimirInicial(oDeclaracion, false);
                    break;
                case 2:
                    ImprimirModificacion(oDeclaracion, false);
                    break;
                case 3:
                    ImprimirConclusion(oDeclaracion, false);
                    break;
                default:
                    break;
            }
        }

        public static void ImprimirInicial(blld_DECLARACION oDeclaracion, Boolean lImprimeMarcaDeAgua)
        {
            String Preeliminar = lImprimeMarcaDeAgua ? "Preliminar" : "Naaaa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(FileServiceCredentials, 5, "DECLARACION_INICIAL_TESTADA", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,Preeliminar}.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName + ".pdf");
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        public static void ImprimirModificacion(blld_DECLARACION oDeclaracion, Boolean lImprimeMarcaDeAgua)
        {
            String Preeliminar = lImprimeMarcaDeAgua ? "Preliminar" : "Naaaa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(FileServiceCredentials, 5, "DECLARACION_MODIFICACION_TESTA", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,Preeliminar
                                                                               ,oDeclaracion.C_EJERCICIO}.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();
            
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        public static void ImprimirConclusion(blld_DECLARACION oDeclaracion, Boolean lImprimeMarcaDeAgua)
        {
            String Preeliminar = lImprimeMarcaDeAgua ? "Preliminar" : "Naaaa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(FileServiceCredentials, 5, "DECLARACION_CONCLUSION_TESTA", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,Preeliminar
                                                                               ,oDeclaracion.C_EJERCICIO}.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }


    }
}