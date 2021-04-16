using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Inicio
{
    public partial class BienesOtrosBienes : System.Web.UI.UserControl
    {
        public List<blld_ALTA_MUEBLE> Mubles
        {
            set
            {
                grdBienes.DataSource = value;
                grdBienes.DataBind();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdBienes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Literal)e.Row.FindControl("ltrTitulares")).Text = ((blld_DECLARACION)Session["Object1"]).ALTA.ALTA_MUEBLEs[e.Row.RowIndex].ALTA_MUEBLE_TITULARs.Count.ToString();
            }
        }



    }
}