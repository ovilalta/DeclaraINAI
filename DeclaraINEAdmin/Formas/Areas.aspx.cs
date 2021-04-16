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
using System.Drawing;
using Declara_V2.Exceptions;

namespace DeclaraINEAdmin.Formas
{
    public partial class Areas : Pagina
    {
        public List<Int32> liAnios = new List<Int32>();

        blld__l_CAT_PRIMER_NIVEL _CAT_PRIMER_NIVEL
        {
            get => (blld__l_CAT_PRIMER_NIVEL)Session["oCAT_PRIMER_NIVEL"];
            set => SessionAdd("oCAT_PRIMER_NIVEL", value);
        }

        blld__l_CAT_SEGUNDO_NIVEL _CAT_SEGUNDO_NIVEL
        {
            get => (blld__l_CAT_SEGUNDO_NIVEL)Session["oCAT_SEGUNDO_NIVEL"];
            set => SessionAdd("oCAT_SEGUNDO_NIVEL", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("Areas.aspx");
            if (!IsPostBack)
            {

                for (int i = 2010; i <= DateTime.Now.Year; i++)
                {
                    liAnios.Add(i);
                }

                dpAnioIPE.DataSource = liAnios.ToList();
                dpAnioIPE.DataBind();
                dpAnioIPE.Items.Insert(0, new ListItem("", ""));

                dpAnioIFE.DataSource = liAnios.ToList();
                dpAnioIFE.DataBind();
                dpAnioIFE.Items.Insert(0, new ListItem("", ""));
                dpAnioIFE.Items.Add(new ListItem("2099", "2099"));

                txtAAInicio.DataSource = liAnios.ToList();
                txtAAInicio.DataBind();
                txtAAInicio.Items.Insert(0, new ListItem("", ""));

                txtAAFin.DataSource = liAnios.ToList();
                txtAAFin.DataBind();
                txtAAFin.Items.Insert(0, new ListItem("", ""));
                txtAAFin.Items.Add(new ListItem("2099", "2099"));





                btnAgregarUA.Visible = true;
                for (int i = 2010; i <= DateTime.Now.Year; i++)
                {
                    liAnios.Add(i);
                }
                dpAnioIP.DataSource = liAnios.ToList();
                dpAnioIP.DataBind();
                dpAnioIP.Items.Insert(0, new ListItem("", ""));

                dpAnioFP.DataSource = liAnios.ToList();
                dpAnioFP.DataBind();
                dpAnioFP.Items.Insert(0, new ListItem("", ""));


            }


            pnlchNUnidad.Visible = chNUnidad.Checked;
            pnlchNomUNIDAD.Visible = chNomUNIDAD.Checked;
            pnlchFINICIAL.Visible = chFINICIAL.Checked;
            pnlchFFINAL.Visible = chFFINAL.Checked;



        }

        //protected void rbPN_CheckedChanged(object sender, EventArgs e)
        //{
        //    pnlSN.Visible = !rbPN.Checked;
        //    pnlPN.Visible = rbPN.Checked;
        //    pnlSNB.Visible = false;
        //    btnAgregarUA.Visible = true;
        //    for (int i = 2010; i <= DateTime.Now.Year; i++)
        //    {
        //        liAnios.Add(i);
        //    }
        //    dpAnioIP.DataSource = liAnios.ToList();
        //    dpAnioIP.DataBind();
        //    dpAnioIP.Items.Insert(0, new ListItem("", ""));

        //    dpAnioFP.DataSource = liAnios.ToList();
        //    dpAnioFP.DataBind();
        //    dpAnioFP.Items.Insert(0, new ListItem("", ""));
        //}

        //protected void rbSN_CheckedChanged(object sender, EventArgs e)
        //{
        //    pnlPN.Visible = !rbSN.Checked;
        //    pnlSN.Visible = rbSN.Checked;
        //    pnlPNB.Visible = false;
        //    btnAgregarUA.Visible = false;
        //    for (int i = 2010; i <= DateTime.Now.Year; i++)
        //    {
        //        liAnios.Add(i);
        //    }
        //    dpAnioIS.DataSource = liAnios.ToList();
        //    dpAnioIS.DataBind();
        //    dpAnioIS.Items.Insert(0, new ListItem("", ""));

        //    dpAnioFS.DataSource = liAnios.ToList();
        //    dpAnioFS.DataBind();
        //    dpAnioFS.Items.Insert(0, new ListItem("", ""));
        //}

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                blld__l_CAT_PRIMER_NIVEL o = new blld__l_CAT_PRIMER_NIVEL();

                //if (txtPD.Text != String.Empty) o.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(txtPD.Text, StringFilter.FilterType.like);
                //if (txtPDescription.Text != String.Empty) o.V_PRIMER_NIVEL = new Declara_V2.StringFilter(txtPDescription.Text, StringFilter.FilterType.like);
                //if (dpAnioIP.SelectedValue != String.Empty) o.C_INICIO = new Declara_V2.StringFilter(dpAnioIP.SelectedValue);
                //if (dpAnioFP.SelectedValue != String.Empty) o.C_FIN = new Declara_V2.StringFilter(dpAnioFP.SelectedValue);

                if (chNUnidad.Checked) { if (txtPD.Text != String.Empty) { o.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(txtPD.Text, StringFilter.FilterType.like); } else { throw new CustomException("Debes completar todos los campos"); } }
                if (chNomUNIDAD.Checked) { if (txtPDescription.Text != String.Empty) { o.V_PRIMER_NIVEL = new Declara_V2.StringFilter(txtPDescription.Text, StringFilter.FilterType.like); } else { throw new CustomException("Debes completar todos los campos"); } }
                if (chFINICIAL.Checked) { if (dpAnioIP.SelectedValue != String.Empty) { o.C_INICIO = new Declara_V2.StringFilter(dpAnioIP.SelectedValue); } else { throw new CustomException("Debes completar todos los campos"); } }
                if (chFFINAL.Checked) { if (dpAnioFP.SelectedValue != String.Empty) { o.C_FIN = new Declara_V2.StringFilter(dpAnioFP.SelectedValue); } else { throw new CustomException("Debes completar todos los campos"); } }


                o.select();
                grdPrimerNivel.DataSource = o.lista_CAT_PRIMER_NIVEL;
                grdPrimerNivel.DataBind();

                _CAT_PRIMER_NIVEL = o;


                btnAgregarUA.Visible = true;

                //if (rbSN.Checked)
                //{
                //    blld__l_CAT_SEGUNDO_NIVEL o = new blld__l_CAT_SEGUNDO_NIVEL();
                //    if (txtSDescription.Text != String.Empty) o.V_SEGUNDO_NIVEL = new Declara_V2.StringFilter(txtSDescription.Text, StringFilter.FilterType.like);
                //    if (dpAnioIS.SelectedValue != String.Empty) o.C_INICIO = new Declara_V2.StringFilter(dpAnioIS.SelectedValue);
                //    if (dpAnioFS.SelectedValue != String.Empty) o.C_FIN = new Declara_V2.StringFilter(dpAnioFS.SelectedValue);

                //    o.select();
                //    grdSegundoNivel.DataSource = o.lista_CAT_SEGUNDO_NIVEL;
                //    grdSegundoNivel.DataBind();

                //    _CAT_SEGUNDO_NIVEL = o;

                //    pnlSNB.Visible = true;
                //    btnAgregarUA.Visible = false;
                //}
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


        protected void btnEditarPN_Click(object sender, EventArgs e)
        {
            appAgregarUA.HeaderText = "Editar Unidad Administrativa";
            appAgregarUA.Show(true);
            btnGuardarUA.Visible = false;
            btnGuardarUA_Update.Visible = true;

            String VID_PRIMER_NIVEL = ((Button)sender).CommandArgument;

            blld__l_CAT_PRIMER_NIVEL o = new blld__l_CAT_PRIMER_NIVEL();
            o.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(VID_PRIMER_NIVEL); ;
            o.select();

            txtUANumero.Text = o.lista_CAT_PRIMER_NIVEL[0].VID_PRIMER_NIVEL.ToString();
            txtUANumero.Enabled = false;
            txtUANombre.Text = o.lista_CAT_PRIMER_NIVEL[0].V_PRIMER_NIVEL.ToString();
            txtUANombre.Enabled = false;
            dpAnioIPE.SelectedValue = o.lista_CAT_PRIMER_NIVEL[0].C_INICIO.ToString();
            dpAnioIFE.SelectedValue = o.lista_CAT_PRIMER_NIVEL[0].C_FIN.ToString();

        }

        protected void btnBuscarAA_Click(object sender, EventArgs e)
        {
            appConsultaAA.HeaderText = "Áreas de Adscripción";
            appConsultaAA.Show(true);
            String VID_PRIMER_NIVEL = ((Button)sender).CommandArgument;

            blld__l_CAT_SEGUNDO_NIVEL o = new blld__l_CAT_SEGUNDO_NIVEL();
            o.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(VID_PRIMER_NIVEL);
            o.select();
            grdAA.DataSource = o.lista_CAT_SEGUNDO_NIVEL;
            grdAA.DataBind();
            if (grdAA.Rows.Count > 0) grdAApnl.Visible = true;
            _CAT_SEGUNDO_NIVEL = o;
        }

        protected void btnEditarSN_Click(object sender, EventArgs e)
        {
            blld__l_CAT_PRIMER_NIVEL ip = _CAT_PRIMER_NIVEL;
            blld__l_CAT_SEGUNDO_NIVEL o = _CAT_SEGUNDO_NIVEL;
            appConsultaAA.Hide();

            appAgregarAA.HeaderText = "Editar Unidad Administrativa";
            appAgregarAA.Show(true);
            btnGuardarAA.Visible = false;
            btnGuardarAA_Update.Visible = true;

            String VID_SEGUNDO_NIVEL = ((Button)sender).CommandArgument;


            ip.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(o.lista_CAT_SEGUNDO_NIVEL[0].VID_PRIMER_NIVEL.ToString());
            ip.select();

            o.VID_SEGUNDO_NIVEL = new Declara_V2.StringFilter(VID_SEGUNDO_NIVEL);
            o.select();

            txtAAUNumeroUA.Text = ip.lista_CAT_PRIMER_NIVEL[0].VID_PRIMER_NIVEL.ToString();
            txtAAUNumeroUA.Enabled = false;
            txtAAUNombreUA.Text = ip.lista_CAT_PRIMER_NIVEL[0].V_PRIMER_NIVEL.ToString();
            txtAAUNombreUA.Enabled = false;

            //txtAANumero.Text = o.lista_CAT_SEGUNDO_NIVEL[0].VID_SEGUNDO_NIVEL.ToString();
            //txtAANumero.Enabled = false;
            txtAANombre.Text = o.lista_CAT_SEGUNDO_NIVEL[0].V_SEGUNDO_NIVEL.ToString();
            txtAANombre.Enabled = false;
            txtAAInicio.SelectedValue = o.lista_CAT_SEGUNDO_NIVEL[0].C_INICIO.ToString();
            txtAAFin.SelectedValue = o.lista_CAT_SEGUNDO_NIVEL[0].C_FIN.ToString();
        }

        protected void btnEditarBSN_Click(object sender, EventArgs e)
        {
            appAgregarAA.HeaderText = "Editar Unidad Administrativa";
            appAgregarAA.Show(true);

            btnGuardarAA.Visible = false;
            btnGuardarAA_Update.Visible = true;

            blld__l_CAT_PRIMER_NIVEL ip = _CAT_PRIMER_NIVEL;
            blld__l_CAT_SEGUNDO_NIVEL o = _CAT_SEGUNDO_NIVEL;

            String VID_SEGUNDO_NIVEL = ((Button)sender).CommandArgument;


            o.VID_SEGUNDO_NIVEL = new Declara_V2.StringFilter(VID_SEGUNDO_NIVEL);

            o.select();

            txtAAUNombreUA.Text = ip.lista_CAT_PRIMER_NIVEL[0].V_PRIMER_NIVEL.ToString();
            txtAAUNombreUA.Enabled = false;

            txtAANombre.Text = o.lista_CAT_SEGUNDO_NIVEL[0].V_SEGUNDO_NIVEL.ToString();
            txtAANombre.Enabled = false;
            txtAAInicio.SelectedValue = o.lista_CAT_SEGUNDO_NIVEL[0].C_INICIO.ToString();
            txtAAFin.SelectedValue = o.lista_CAT_SEGUNDO_NIVEL[0].C_FIN.ToString();
        }

        protected void btnAgregarUA_Click(object sender, EventArgs e)
        {
            appAgregarUA.HeaderText = "Agregar Unidad Administrativa";
            appAgregarUA.Show(true);
            btnGuardarUA.Visible = true;
            btnGuardarUA_Update.Visible = false;
            txtUANumero.Text = String.Empty;
            txtUANumero.Enabled = true;
            txtUANombre.Text = String.Empty;
            txtUANombre.Enabled = true;
            dpAnioIPE.SelectedValue = String.Empty;
            dpAnioIFE.SelectedValue = String.Empty;
        }



        protected void btnCerrarAgregarUA_Click(object sender, EventArgs e)
        {
            appAgregarUA.Hide();
        }

        protected void btnGuardarUA_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUANumero.Text != String.Empty && txtUANombre.Text != String.Empty && dpAnioIPE.SelectedValue != String.Empty && dpAnioIFE.SelectedValue != String.Empty)
                {
                    if (Convert.ToInt32(dpAnioIPE.SelectedValue) > Convert.ToInt32(dpAnioIFE.SelectedValue)) throw new CustomException("Las Fechas son incorrectas");
                    blld_CAT_PRIMER_NIVEL o = new blld_CAT_PRIMER_NIVEL(txtUANumero.Text, txtUANombre.Text, dpAnioIPE.SelectedValue, dpAnioIFE.SelectedValue);
                    o.update();
                    AlertaSuperiorUA.ShowSuccess("Unidad Agregada");
                }
                else
                    AlertaSuperiorUA.ShowDanger("Debes completar todos los campos");
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    AlertaSuperiorUA.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void btnGuardarUA_Update_Click(object sender, EventArgs e)
        {
            try
            {

                if (dpAnioIPE.SelectedValue != String.Empty && dpAnioIFE.SelectedValue != String.Empty)
                {
                    if (Convert.ToInt32(dpAnioIPE.SelectedValue) > Convert.ToInt32(dpAnioIFE.SelectedValue)) throw new CustomException("Las Fechas son incorrectas");
                    blld_CAT_PRIMER_NIVEL u = new blld_CAT_PRIMER_NIVEL(txtUANumero.Text);
                    u.C_INICIO = dpAnioIPE.SelectedValue;
                    u.C_FIN = dpAnioIFE.SelectedValue;
                    u.update();
                    AlertaSuperiorUA.ShowSuccess("Unidad Actualizada");
                }
                else
                    AlertaSuperiorUA.ShowDanger("Debes completar todos los campos");
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    AlertaSuperiorUA.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }


        protected void btnGuardarAA_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAANombre.Text != String.Empty && txtAAInicio.SelectedValue != String.Empty && txtAAFin.SelectedValue != String.Empty)
                {
                    if (Convert.ToInt32(txtAAInicio.SelectedValue) > Convert.ToInt32(txtAAFin.SelectedValue)) throw new CustomException("Las Fechas son incorrectas");
                    blld__l_CAT_PRIMER_NIVEL ip = _CAT_PRIMER_NIVEL;
                    blld__l_CAT_SEGUNDO_NIVEL sp = _CAT_SEGUNDO_NIVEL;
                    //blld_CAT_SEGUNDO_NIVEL u = new blld_CAT_SEGUNDO_NIVEL(txtAAUNumero.Text, txtAANumero.Text, txtAANombre.Text, txtAAInicio.SelectedValue.ToString(), txtAAFin.SelectedValue.ToString());
                    blld_CAT_SEGUNDO_NIVEL u = new blld_CAT_SEGUNDO_NIVEL(ip.VID_PRIMER_NIVEL.Value, ip.VID_PRIMER_NIVEL.Value, txtAANombre.Text, txtAAInicio.SelectedValue.ToString(), txtAAFin.SelectedValue.ToString());

                    u.update();
                    AlertaSuperiorAA.ShowSuccess("Area Agregada");
                }
                else
                    AlertaSuperiorAA.ShowDanger("Acomprete todos los campos");
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    AlertaSuperiorAA.ShowDanger(ex.Message);
                }

            }
        }

        protected void btnAgregarAA_Click(object sender, EventArgs e)
        {
            appConsultaAA.Hide();

            appAgregarAA.HeaderText = "Nueva Unidad Administrativa";
            appAgregarAA.Show(true);
            btnGuardarAA.Visible = true;
            btnGuardarAA_Update.Visible = false;

            blld__l_CAT_PRIMER_NIVEL ip = _CAT_PRIMER_NIVEL;

            blld__l_CAT_SEGUNDO_NIVEL o = _CAT_SEGUNDO_NIVEL;
            txtAAUNombreUA.Text = ip.lista_CAT_PRIMER_NIVEL[0].V_PRIMER_NIVEL.ToString();
            txtAAUNombreUA.Enabled = false;

            txtAANombre.Enabled = true;
            txtAANombre.Text = String.Empty;
            txtAAInicio.SelectedValue = String.Empty;
            txtAAFin.SelectedValue = String.Empty;

        }

        protected void btnGuardarAA_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAAInicio.SelectedValue != String.Empty && txtAAFin.SelectedValue != String.Empty)
                {
                    if (Convert.ToInt32(txtAAInicio.SelectedValue) > Convert.ToInt32(txtAAFin.SelectedValue)) throw new CustomException("Las Fechas son incorrectas");
                    blld__l_CAT_SEGUNDO_NIVEL sp = _CAT_SEGUNDO_NIVEL;
                    blld_CAT_SEGUNDO_NIVEL u = new blld_CAT_SEGUNDO_NIVEL(sp.VID_PRIMER_NIVEL.Value, sp.VID_SEGUNDO_NIVEL.Value);
                    u.C_INICIO = txtAAInicio.SelectedValue;
                    u.C_FIN = txtAAFin.SelectedValue;
                    u.update();
                    AlertaSuperiorAA.ShowSuccess("Area Actualizada");
                }
                else
                    AlertaSuperiorAA.ShowDanger("Acomprete todos los campos");
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    AlertaSuperiorAA.ShowDanger(ex.Message);
                }
                else throw ex;
            }
        }

        protected void btnCerrarAgregarAA_Click(object sender, EventArgs e)
        {
            appAgregarAA.Hide();

            blld__l_CAT_PRIMER_NIVEL o = new blld__l_CAT_PRIMER_NIVEL();
            if (txtPD.Text != String.Empty) o.VID_PRIMER_NIVEL = new Declara_V2.StringFilter(txtPD.Text, StringFilter.FilterType.like);
            if (txtPDescription.Text != String.Empty) o.V_PRIMER_NIVEL = new Declara_V2.StringFilter(txtPDescription.Text, StringFilter.FilterType.like);
            if (dpAnioIP.SelectedValue != String.Empty) o.C_INICIO = new Declara_V2.StringFilter(dpAnioIP.SelectedValue);
            if (dpAnioFP.SelectedValue != String.Empty) o.C_FIN = new Declara_V2.StringFilter(dpAnioFP.SelectedValue);
            o.select();
            grdPrimerNivel.DataSource = o.lista_CAT_PRIMER_NIVEL;
            grdPrimerNivel.DataBind();
        }

        protected void btnCerrarConsultaAA_Click(object sender, EventArgs e)
        {
            appConsultaAA.Hide();
        }


    }
}