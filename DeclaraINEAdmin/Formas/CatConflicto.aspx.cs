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

namespace DeclaraINEAdmin.Formas
{
    public partial class CatConflicto : Pagina
    {
        blld_CAT_CONFLICTO_RUBRO _CAT_CONFLICTO_RUBRO
        {
            get => (blld_CAT_CONFLICTO_RUBRO)Session["object1"];
            set => SessionAdd("object1", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("CatConflicto.aspx");
            if (!IsPostBack)
            {
                blld__l_CAT_CONFLICTO_RUBRO oR = new blld__l_CAT_CONFLICTO_RUBRO();
                oR.select();
                gridRubros.DataSource = oR.lista_CAT_CONFLICTO_RUBRO;
                gridRubros.DataBind();
            }

        }

        protected void btnEditarRubro_Click(object sender, EventArgs e)
        {

            blld_CAT_CONFLICTO_RUBRO o = new blld_CAT_CONFLICTO_RUBRO(Convert.ToInt32(((Button)sender).CommandArgument));
            appAgregarRubro.Show(true);
            appAgregarRubro.HeaderText = "Editar Rubro";
            txtVRubro.Enabled = false;
            btnGuardarRubroUpdate.Visible = true;
            txtVRubro.Text = o.V_RUBRO;
            btnGuardarRubro.Visible = false;
            btnGuardarRubroUpdate.Visible = true;
            txtFInicialNewRubro.Text = o.C_INICIO;
            txtFFinalNewRubro.Text = o.C_FIN;

            txtFInicialNewRubro.Attributes.Add("requerido", "btnGuardarRubroUpdate");
            txtFFinalNewRubro.Attributes.Add("requerido", "btnGuardarRubroUpdate");


            _CAT_CONFLICTO_RUBRO = o;
        }

        protected void btnAgregarRubro_Click(object sender, EventArgs e)
        {
            appAgregarRubro.Show(true);
            appAgregarRubro.HeaderText = "Agregar Nuevo Rubro";
            txtVRubro.Enabled = true;
            btnGuardarRubroUpdate.Visible = false;
            txtVRubro.Text = String.Empty;
            btnGuardarRubroUpdate.Visible = false;
            btnGuardarRubro.Visible = true;
            txtFInicialNewRubro.Text = "2018";
            txtFFinalNewRubro.Text = "2099";

            txtVRubro.Attributes.Add("requerido", "btnGuardarRubro");
            txtFInicialNewRubro.Attributes.Add("requerido", "btnGuardarRubro");
            txtFFinalNewRubro.Attributes.Add("requerido", "btnGuardarRubro");

        }

        protected void btnCerrarAgregarRubro_Click(object sender, EventArgs e)
        {
            appAgregarRubro.Hide();
        }

        protected void btnGuardarRubro_Click(object sender, EventArgs e)
        {
            try
            {
                blld_CAT_CONFLICTO_RUBRO o = new blld_CAT_CONFLICTO_RUBRO(txtVRubro.Text, txtFInicialNewRubro.Text, txtFFinalNewRubro.Text);
                appAgregarRubro.Hide();
                _CAT_CONFLICTO_RUBRO = o;

                blld__l_CAT_CONFLICTO_RUBRO oR = new blld__l_CAT_CONFLICTO_RUBRO();
                oR.select();
                gridRubros.DataSource = oR.lista_CAT_CONFLICTO_RUBRO;
                gridRubros.DataBind();

                pnlGridRubros.Update();
                AlertaRubros.ShowSuccess("Agregado correctamente");
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaRubro.ShowDanger(ex.Message);
                else
                    throw ex;
            }

        }

        protected void btnGuardarRubroUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                blld_CAT_CONFLICTO_RUBRO oCAT_CONFLICTO_RUBRO = _CAT_CONFLICTO_RUBRO;
                oCAT_CONFLICTO_RUBRO.C_INICIO = txtFInicialNewRubro.Text;
                oCAT_CONFLICTO_RUBRO.C_FIN = txtFFinalNewRubro.Text;
                oCAT_CONFLICTO_RUBRO.update();

                appAgregarRubro.Hide();
                blld__l_CAT_CONFLICTO_RUBRO oR = new blld__l_CAT_CONFLICTO_RUBRO();
                oR.select();
                gridRubros.DataSource = oR.lista_CAT_CONFLICTO_RUBRO;
                gridRubros.DataBind();
                pnlGridRubros.Update();

                AlertaRubros.ShowSuccess("Actuaizado correctamente");
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaRubro.ShowDanger(ex.Message);
                else
                    throw ex;
            }
        }

        protected void btnEditarRubroPregunta_Click(object sender, EventArgs e)
        {
            blld_CAT_CONFLICTO_RUBRO o = new blld_CAT_CONFLICTO_RUBRO(Convert.ToInt32(((Button)sender).CommandArgument));
            appAgregarRubroPregunta.Show(true);
            appAgregarRubroPregunta.HeaderText = "Preguntas";

            _CAT_CONFLICTO_RUBRO = o;

            blld__l_CAT_CONFLICTO_PREGUNTA oP = new blld__l_CAT_CONFLICTO_PREGUNTA();
            oP.NID_RUBRO = new Declara_V2.IntegerFilter(o.NID_RUBRO);
            oP.select();

            if (oP.lista_CAT_CONFLICTO_PREGUNTA.Count() > 0)
            {
                ltrSinOpciones.Visible = false;
                gridRubroPregunta.Visible = true;
                gridRubroPregunta.DataSource = oP.lista_CAT_CONFLICTO_PREGUNTA;
                gridRubroPregunta.DataBind();
            }
            else
            {
                ltrSinOpciones.Visible = true;
                gridRubroPregunta.Visible = false;
            }
        }

        protected void btnCerrarPrguntaAgregar_Click(object sender, EventArgs e)
        {
            appAgregarRubroPregunta.Hide();
        }


        protected void btnAgregarPrgunta_Click(object sender, EventArgs e)
        {
            appAgregarRubroPregunta.Hide();
            appPregunta.Show(true);
            appPregunta.HeaderText = "Agregar pregunta";
            txtPregunta.Enabled = true;
            cbPreguntas.Checked = false;
            txtPregunta.Text = String.Empty;
            pnlPOps.Visible = false;
            txtPreguntaFechaInicio.Text = "2018";
            txtPreguntaFechaFin.Text = "2099";
            btnGuardarRubroPregunta.Visible = true;
            btnGuardarRubroPreguntaUpdate.Visible = false;
            txtPregunta.Attributes.Add("requerido", "btnGuardarRubroPregunta");
            txtPreguntaFechaInicio.Attributes.Add("requerido", "btnGuardarRubroPregunta");
            txtPreguntaFechaFin.Attributes.Add("requerido", "btnGuardarRubroPregunta");


        }


        public class Respuesta
        {
            public string v_respuesta { get; set; }

        }

        protected void gridRubroPregunta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String vRUBRO = ((Literal)e.Row.FindControl("ltrOps")).Text;
                String[] Vtxt = vRUBRO.Split(new char[] { '|' });
                int tmp = 0;

                String var = String.Empty;
                Int32 n = Vtxt.Length;
                if (n == 1 || n == 3)
                {
                    if (vRUBRO.Replace("||", "") == String.Empty) ((Literal)e.Row.FindControl("ltrOps")).Text = "    Respuesta abierta";
                    else
                        ((Literal)e.Row.FindControl("ltrOps")).Text = vRUBRO.Replace("||", "");
                }
                else
                {
                    foreach (String o in Vtxt.ToList())
                    {
                        if (tmp > 1) var += " - " + o + "<br />";
                        tmp = tmp + 1;
                    }
                    ((Literal)e.Row.FindControl("ltrOps")).Text = var;
                }

            }
        }
        protected void btnEditarPregunta_Click(object sender, EventArgs e)
        {
            Int32 NID_PREGUNTA = Convert.ToInt32(((Button)sender).CommandArgument);

            appAgregarRubroPregunta.Hide();
            appPregunta.Show(true);
            appPregunta.HeaderText = "Editar pregunta";
            btnGuardarRubroPregunta.Visible = false;
            btnGuardarRubroPreguntaUpdate.Visible = true;

            blld_CAT_CONFLICTO_RUBRO o = _CAT_CONFLICTO_RUBRO;

            blld__l_CAT_CONFLICTO_PREGUNTA oP = new blld__l_CAT_CONFLICTO_PREGUNTA();
            oP.NID_RUBRO = new Declara_V2.IntegerFilter(o.NID_RUBRO);
            oP.NID_PREGUNTA = new Declara_V2.IntegerFilter(NID_PREGUNTA);
            oP.select();
            txtPregunta.Enabled = false;
            ltrnp.Text = NID_PREGUNTA.ToString();
            txtPregunta.Text = oP.lista_CAT_CONFLICTO_PREGUNTA[0].V_RUBRO;

            String vRUBRO = oP.lista_CAT_CONFLICTO_PREGUNTA[0].V_OPCIONES;

            if (vRUBRO != null && vRUBRO != String.Empty)
            {
                String[] Vtxt = vRUBRO.Split(new char[] { '|' });
                List<Respuesta> listOps = new List<Respuesta>();

                pnlPOps.Visible = true;
                foreach (String r in Vtxt.ToList())
                {
                    if (r.Length != 0) listOps.Add(new Respuesta() { v_respuesta = r });
                }
                grdPreOpciones.DataSource = listOps;
                grdPreOpciones.DataBind();
                cbPreguntas.Checked = true;
            }
            else
            {
                pnlPOps.Visible = false;
                cbPreguntas.Checked = false;
            }

            txtPreguntaFechaInicio.Text = oP.lista_CAT_CONFLICTO_PREGUNTA[0].C_INICIO;
            txtPreguntaFechaFin.Text = oP.lista_CAT_CONFLICTO_PREGUNTA[0].C_FIN;
            txtPregunta.Attributes.Add("requerido", "btnGuardarRubroPreguntaUpdate");
            txtPreguntaFechaInicio.Attributes.Add("requerido", "btnGuardarRubroPreguntaUpdate");
            txtPreguntaFechaFin.Attributes.Add("requerido", "btnGuardarRubroPreguntaUpdate");
        }


        //-----Modal Preguntas 


        protected void cbPreguntas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPreguntas.Checked)
            {
                appPregunta.Hide();
                mppRespuestaTMP.Show(true);
                mppRespuestaTMP.HeaderText = "Editar opciones";

                List<Respuesta> Op = new List<Respuesta>();
                foreach (GridViewRow row in grdPreOpciones.Rows)
                {
                    if (((Literal)row.FindControl("txtOpciones")).Text != String.Empty)
                    {
                        Op.Add(new Respuesta() { v_respuesta = ((Literal)row.FindControl("txtOpciones")).Text });
                    }
                }
                grdPreOpcionesTMP.DataSource = Op.ToList();
                grdPreOpcionesTMP.DataBind();
            }
            else
            {

                if (grdPreOpciones.Rows.Count > 1)
                {
                    appPregunta.Hide();
                    appOpcionesPregunta.Show(true);
                    appOpcionesPregunta.HeaderText = "Cambio de opción";
                    cbPreguntas.Checked = true;
                }
                else
                {
                    cbPreguntas.Checked = false;
                    pnlPOps.Visible = false;
                }



            }
        }

        protected void btnCerrarPregunta_Click(object sender, EventArgs e)
        {
            appOpcionesPregunta.Hide();
            appPregunta.Show(true);
        }

        protected void btnOpcionesPregunta_Click(object sender, EventArgs e)
        {
            appOpcionesPregunta.Hide();
            appPregunta.Show(true);
            cbPreguntas.Checked = false;
            pnlPOps.Visible = false;
        }


        protected void btnCerrarRubroPregunta_Click(object sender, EventArgs e)
        {
            grdPreOpciones.DataSource = String.Empty;
            grdPreOpciones.DataBind();

            appPregunta.Hide();
            blld_CAT_CONFLICTO_RUBRO o = _CAT_CONFLICTO_RUBRO;
            appAgregarRubroPregunta.Show(true);
            appAgregarRubroPregunta.HeaderText = "Preguntas";

            blld__l_CAT_CONFLICTO_PREGUNTA oP = new blld__l_CAT_CONFLICTO_PREGUNTA();
            oP.NID_RUBRO = new Declara_V2.IntegerFilter(o.NID_RUBRO);
            oP.select();

            gridRubroPregunta.DataSource = oP.lista_CAT_CONFLICTO_PREGUNTA;
            gridRubroPregunta.DataBind();
        }

        protected void btnGuardarRubroPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                blld_CAT_CONFLICTO_RUBRO o = _CAT_CONFLICTO_RUBRO;

                String vRespuesta = String.Empty;
                if (cbPreguntas.Checked)
                {
                    int rows = grdPreOpciones.Rows.Count;
                    vRespuesta = "||";
                    foreach (GridViewRow row in grdPreOpciones.Rows)
                    {
                        if (((Literal)row.FindControl("txtOpciones")).Text != String.Empty)
                        {
                            if (vRespuesta.Length != 0)
                            {
                                if (vRespuesta[vRespuesta.Length - 1] != '|')
                                {
                                    vRespuesta += "|";
                                }
                            }
                            vRespuesta += ((Literal)row.FindControl("txtOpciones")).Text;
                            if (rows != 1) vRespuesta += "|";
                        }
                        else
                        {
                            if (vRespuesta[vRespuesta.Length - 1] == '|')
                            {
                                vRespuesta = vRespuesta.Remove(vRespuesta.Length - 1);
                            }
                            //if ( rows == 1) vRespuesta = null;
                        }
                        rows = rows - 1;
                    }
                }
                else
                {
                    vRespuesta = null;
                }
                o.Add_CAT_CONFLICTO_PREGUNTAs(txtPregunta.Text, vRespuesta, txtPreguntaFechaInicio.Text, txtPreguntaFechaFin.Text);

                appPregunta.Hide();
                appAgregarRubroPregunta.Show(true);
                AlertaRubroPregunta.ShowSuccess("Agregado correctamente");
                _CAT_CONFLICTO_RUBRO = o;

                blld__l_CAT_CONFLICTO_PREGUNTA oP = new blld__l_CAT_CONFLICTO_PREGUNTA();
                oP.NID_RUBRO = new Declara_V2.IntegerFilter(o.NID_RUBRO);
                oP.select();


                if (oP.lista_CAT_CONFLICTO_PREGUNTA.Count() > 0)
                {
                    ltrSinOpciones.Visible = false;
                    gridRubroPregunta.Visible = true;
                    gridRubroPregunta.DataSource = oP.lista_CAT_CONFLICTO_PREGUNTA;
                    gridRubroPregunta.DataBind();
                }
                else
                {
                    ltrSinOpciones.Visible = true;
                    gridRubroPregunta.Visible = false;
                }

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaPregunta.ShowDanger(ex.Message);
                else
                    throw ex;
            }
        }

        protected void btnGuardarRubroPreguntaUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                blld_CAT_CONFLICTO_RUBRO o = _CAT_CONFLICTO_RUBRO;
                Int32 NID_PREGUNTA = Convert.ToInt32(ltrnp.Text);
                blld_CAT_CONFLICTO_PREGUNTA op = new blld_CAT_CONFLICTO_PREGUNTA(o.NID_RUBRO, NID_PREGUNTA);
                String vRespuesta = String.Empty;
                if (cbPreguntas.Checked)
                {
                    int rows = grdPreOpciones.Rows.Count;
                    vRespuesta = "||";
                    foreach (GridViewRow row in grdPreOpciones.Rows)
                    {
                        if (((Literal)row.FindControl("txtOpciones")).Text != String.Empty)
                        {

                            if (vRespuesta.Length != 0)
                            {
                                if (vRespuesta[vRespuesta.Length - 1] != '|')
                                {
                                    vRespuesta += "|";
                                }
                            }
                            vRespuesta += ((Literal)row.FindControl("txtOpciones")).Text;
                            if (rows != 1) vRespuesta += "|";
                        }
                        else
                        {
                            if (vRespuesta[vRespuesta.Length - 1] == '|')
                            {
                                vRespuesta = vRespuesta.Remove(vRespuesta.Length - 1);
                            }
                            //if (rows == 1) vRespuesta = null;
                        }
                        rows = rows - 1;
                    }
                }
                else
                {
                    vRespuesta = null;
                }
                op.V_OPCIONES = vRespuesta;
                op.C_INICIO = txtPreguntaFechaInicio.Text;
                op.C_FIN = txtPreguntaFechaFin.Text;
                op.update();

                _CAT_CONFLICTO_RUBRO = o;

                grdPreOpciones.DataSource = String.Empty;
                grdPreOpciones.DataBind();
                appPregunta.Hide();
                appAgregarRubroPregunta.Show(true);
                AlertaRubroPregunta.ShowSuccess("Actualizado correctamente");

                blld__l_CAT_CONFLICTO_PREGUNTA oP = new blld__l_CAT_CONFLICTO_PREGUNTA();
                oP.NID_RUBRO = new Declara_V2.IntegerFilter(o.NID_RUBRO);
                oP.select();

                if (oP.lista_CAT_CONFLICTO_PREGUNTA.Count() > 0)
                {
                    ltrSinOpciones.Visible = false;
                    gridRubroPregunta.Visible = true;
                    gridRubroPregunta.DataSource = oP.lista_CAT_CONFLICTO_PREGUNTA;
                    gridRubroPregunta.DataBind();
                }
                else
                {
                    ltrSinOpciones.Visible = true;
                    gridRubroPregunta.Visible = false;
                }
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaPregunta.ShowDanger(ex.Message);
                else
                    throw ex;
            }

        }

        protected void btnEditarOpcionEditarTMP_Click(object sender, EventArgs e)
        {
            appPregunta.Hide();
            mppRespuestaTMP.Show(true);
            mppRespuestaTMP.HeaderText = "Editar opciones ";

            List<Respuesta> Op = new List<Respuesta>();
            foreach (GridViewRow row in grdPreOpciones.Rows)
            {
                if (((Literal)row.FindControl("txtOpciones")).Text != String.Empty)
                {
                    Op.Add(new Respuesta() { v_respuesta = ((Literal)row.FindControl("txtOpciones")).Text });
                }
            }
            grdPreOpcionesTMP.DataSource = Op.ToList();
            grdPreOpcionesTMP.DataBind();

        }


        // Mod Edicion de Preguntas
        protected void btnAgregarOpcionTMP_Click(object sender, EventArgs e)
        {
            try
            {
                List<Respuesta> Op = new List<Respuesta>();
                foreach (GridViewRow row in grdPreOpcionesTMP.Rows)
                {
                    Op.Add(new Respuesta() { v_respuesta = ((TextBox)row.FindControl("txtOpciones")).Text });
                }
                Op.Add(new Respuesta() { v_respuesta = "" });
                grdPreOpcionesTMP.DataSource = Op.ToList();
                grdPreOpcionesTMP.DataBind();
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AletaRespuestaTMP.ShowDanger(ex.Message);
                else
                    throw ex;
            }

        }

        protected void btnGuardarRespuestaTMP_Click(object sender, EventArgs e)
        {
            List<Respuesta> Op = new List<Respuesta>();
            foreach (GridViewRow row in grdPreOpcionesTMP.Rows)
            {
                if (((TextBox)row.FindControl("txtOpciones")).Text != String.Empty)
                {
                    Op.Add(new Respuesta() { v_respuesta = ((TextBox)row.FindControl("txtOpciones")).Text });
                }
            }
            grdPreOpciones.DataSource = Op.ToList();
            grdPreOpciones.DataBind();
            mppRespuestaTMP.Hide();
            appPregunta.Show(true);

            if (Op.Count == 0)
            {
                cbPreguntas.Checked = false;
                pnlPOps.Visible = false;
            }
            else
            {
                cbPreguntas.Checked = true;
                pnlPOps.Visible = true;
            }
        }

        protected void btnCerrarRespuestaTMP_Click(object sender, EventArgs e)
        {

            List<Respuesta> Op = new List<Respuesta>();
            foreach (GridViewRow row in grdPreOpciones.Rows)
            {
                if (((Literal)row.FindControl("txtOpciones")).Text != String.Empty)
                {
                    Op.Add(new Respuesta() { v_respuesta = ((Literal)row.FindControl("txtOpciones")).Text });
                }
            }
            mppRespuestaTMP.Hide();
            appPregunta.Show(true);

            if (Op.Count == 0)
            {
                cbPreguntas.Checked = false;
                pnlPOps.Visible = false;
            }
            else
            {
                cbPreguntas.Checked = true;
                pnlPOps.Visible = true;
            }
            grdPreOpcionesTMP.DataSource = String.Empty;
            grdPreOpcionesTMP.DataBind();
        }




    }
}