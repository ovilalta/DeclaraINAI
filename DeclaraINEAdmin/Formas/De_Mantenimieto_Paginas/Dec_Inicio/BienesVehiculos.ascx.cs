using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Inicio
{
    public partial class BienesVehiculos : System.Web.UI.UserControl
    {
        public List<blld_ALTA_VEHICULO> listVehiculos
        {
            set
            {
                grdVehiculos.DataSource = value;
                grdVehiculos.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void grdVehiculos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((CheckBox)e.Row.FindControl("chAdeudo")).Checked = ((blld_DECLARACION)Session["Object1"]).ALTA.ALTA_VEHICULOs[e.Row.RowIndex].ALTA_ADEUDOs.Any();
                ((Literal)e.Row.FindControl("ltrTitulares")).Text = ((blld_DECLARACION)Session["Object1"]).ALTA.ALTA_VEHICULOs[e.Row.RowIndex].ALTA_VEHICULO_TITULARs.Count.ToString();
            }
        }



    }
}