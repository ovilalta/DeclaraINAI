using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Inicio
{
    public partial class Inversiones : System.Web.UI.UserControl
    {
        public List<blld_ALTA_INVERSION> Invesiones
        {
            set
            {
                grdInvesiones.DataSource = value;
                grdInvesiones.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdInvesiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Literal)e.Row.FindControl("ltrInstitucion")).Text = ((blld_DECLARACION)Session["Object1"]).ALTA.ALTA_INVERSIONs[e.Row.RowIndex].V_INSTITUCION.ToString();
                ((Literal)e.Row.FindControl("ltrTitulares")).Text = ((blld_DECLARACION)Session["Object1"]).ALTA.ALTA_INVERSIONs[e.Row.RowIndex].ALTA_INVERSION_TITULARs.Count.ToString();
            }
        }


    }
}