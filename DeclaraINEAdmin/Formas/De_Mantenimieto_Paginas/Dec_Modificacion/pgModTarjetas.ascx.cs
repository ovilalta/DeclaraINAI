using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModTarjetas : System.Web.UI.UserControl
    {
        public List<blld_MODIFICACION_TARJETA> listTarjetas
        {
            set
            {
                grdTarjetas.DataSource = value;
                grdTarjetas.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdTarjetas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                blld_CAT_INST_FINANCIERA oCatInstitucion = new blld_CAT_INST_FINANCIERA(
                    ((blld_DECLARACION)Session["Object1"]).MODIFICACION.MODIFICACION_TARJETAs[e.Row.RowIndex].NID_INSTITUCION);
                ((Literal)e.Row.FindControl("ltrTitulares")).Text = ((blld_DECLARACION)Session["Object1"]).MODIFICACION.MODIFICACION_TARJETAs[e.Row.RowIndex].MODIFICACION_TARJETA_TITUs.Count.ToString();
                ((Literal)e.Row.FindControl("ltrTipo")).Text = oCatInstitucion.V_INSTITUCION;
            }
        }



    }
}