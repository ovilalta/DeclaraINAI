using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Conclusion
{
    public partial class pgConBienesMuebles : System.Web.UI.UserControl
    {
        public List<blld_ALTA_MUEBLE> listMueblesDecInicial
        {
            set
            {
                grdBienesDecInicial.DataSource = value;
                grdBienesDecInicial.DataBind();
            }
        }

        public List<blld_MODIFICACION_MUEBLE> listMuebles
        {
            set
            {
                grdBienesModificacion.DataSource = value;
                grdBienesModificacion.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdBienesModificacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["object1"];

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                blld_PATRIMONIO_MUEBLE oP = new blld_PATRIMONIO_MUEBLE(oDeclaracion.VID_NOMBRE
                    , oDeclaracion.VID_FECHA
                    , oDeclaracion.VID_HOMOCLAVE
                    , Convert.ToInt32(oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs[e.Row.RowIndex].NID_PATRIMONIO)
                    );

                ((Literal)e.Row.FindControl("ltrTipo")).Text = oP.V_TIPO.ToString();

                ((Literal)e.Row.FindControl("ltrTitularesModificacion")).Text = ((blld_DECLARACION)Session["object1"]).MODIFICACION.MODIFICACION_MUEBLEs[e.Row.RowIndex].MODIFICACION_MUEBLE_TITULARs.Count.ToString();
            }

        }

        protected void grdBienesDecInicial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Literal)e.Row.FindControl("ltrTitulares")).Text = ((blld_DECLARACION)Session["object1"]).ALTA.ALTA_MUEBLEs[e.Row.RowIndex].ALTA_MUEBLE_TITULARs.Count.ToString();
            }
        }
    }
}