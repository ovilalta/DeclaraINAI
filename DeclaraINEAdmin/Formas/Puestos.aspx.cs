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

namespace DeclaraINEAdmin.Formas
{
    public partial class Puesto : Pagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("Puestos.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            blld__l_CAT_PUESTO o = new blld__l_CAT_PUESTO();

            if (txtPuesto.Text != String.Empty) o.VID_PUESTO = new Declara_V2.StringFilter(txtPuesto.Text, StringFilter.FilterType.like);
            if (txtNivel.Text != String.Empty) o.VID_NIVEL = new Declara_V2.StringFilter(txtNivel.Text, StringFilter.FilterType.like);
            if (txtDPuesto.Text != String.Empty) o.V_PUESTO = new Declara_V2.StringFilter(txtDPuesto.Text, StringFilter.FilterType.like);
            if (dpActivo.SelectedValue != String.Empty) o.L_ACTIVO = Convert.ToBoolean(Convert.ToInt32(dpActivo.SelectedValue));
            o.select();
            grdPuestos.DataSource = o.lista_CAT_PUESTO;
            grdPuestos.DataBind();
        }

        protected void btnPuestoActivo_Click(object sender, EventArgs e)
        {
            String NID_PUESTO = ((Button)sender).CommandArgument;
            blld__l_CAT_PUESTO l = new blld__l_CAT_PUESTO();
            l.NID_PUESTO = new Declara_V2.IntegerFilter(Convert.ToInt32(NID_PUESTO));
            l.select();

            blld_CAT_PUESTO o = new blld_CAT_PUESTO(Convert.ToInt32(NID_PUESTO));
            o.L_ACTIVO = Convert.ToBoolean((l.lista_CAT_PUESTO[0].L_ACTIVO) ? false : true);
            o.update();

            l = new blld__l_CAT_PUESTO();

            if (txtPuesto.Text != String.Empty) l.VID_PUESTO = new Declara_V2.StringFilter(txtPuesto.Text, StringFilter.FilterType.like);
            if (txtNivel.Text != String.Empty) l.VID_NIVEL = new Declara_V2.StringFilter(txtNivel.Text, StringFilter.FilterType.like);
            if (txtDPuesto.Text != String.Empty) l.V_PUESTO = new Declara_V2.StringFilter(txtDPuesto.Text, StringFilter.FilterType.like);
            if (dpActivo.SelectedValue != String.Empty) l.L_ACTIVO = Convert.ToBoolean(Convert.ToInt32(dpActivo.SelectedValue));
            l.select();
            grdPuestos.DataSource = l.lista_CAT_PUESTO;
            grdPuestos.DataBind();
        }

        protected void btnNuevoPuesto_Click(object sender, EventArgs e)
        {
            appPuesto.Show();
            txtNPuesto.Text = String.Empty;
            txtNivelNuevo.Text = String.Empty;
            txtVPuesto.Text = String.Empty;
            chPuestoActivo.Checked = false;
        }


        protected void btnGuardarPuesto_Click(object sender, EventArgs e)
        {
            try
            {
                blld_CAT_PUESTO o = new blld_CAT_PUESTO(txtNPuesto.Text, txtNivelNuevo.Text, txtVPuesto.Text, chPuestoActivo.Checked);
                o.update();
                AlertaSuperiorPuesto.ShowSuccess("Puesto Guardado con exito");
            }
            catch (Exception ex)
            {
                AlertaSuperiorPuesto.ShowDanger(ex.Message);
            }
        }



        protected void btnCerrarPuesto_Click(object sender, EventArgs e)
        {
            appPuesto.Hide();
        }

    }
}