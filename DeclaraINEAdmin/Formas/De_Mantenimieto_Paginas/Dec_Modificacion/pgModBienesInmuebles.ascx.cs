using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModBienesInmuebles : System.Web.UI.UserControl
    {
        public List<blld_ALTA_INMUEBLE> listInmueblesDecInicial
        {
            set
            {
                grdBienesInmueblesDecInicial.DataSource = value;
                grdBienesInmueblesDecInicial.DataBind();
            }
        }
 
        public List<blld_MODIFICACION_INMUEBLE> listInmuebles
        {
            set
            {
                grdBienesInmueblesModificacion.DataSource = value;
                grdBienesInmueblesModificacion.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
 
        protected void grdBienesInmuebles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                //Declaracion de Inicial
                ((CheckBox)e.Row.FindControl("chAdeudo")).Checked = ((blld_DECLARACION)Session["object1"]).ALTA.ALTA_INMUEBLEs[e.Row.RowIndex].ALTA_ADEUDOs.Any();
                ((Literal)e.Row.FindControl("ltrTitulares")).Text = ((blld_DECLARACION)Session["object1"]).ALTA.ALTA_INMUEBLEs[e.Row.RowIndex].ALTA_INMUEBLE_TITULARs.Count.ToString();
            }

        }

        protected void grdBienesInmueblesModificacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Declaracion de Modificacion
                ((CheckBox)e.Row.FindControl("chAdeudoModificacion")).Checked = ((blld_DECLARACION)Session["object1"]).MODIFICACION.MODIFICACION_INMUEBLEs[e.Row.RowIndex].MODIFICACION_INMUEBLE_ADEUDOs.Any();
                ((Literal)e.Row.FindControl("ltrTitularesModificacion")).Text = ((blld_DECLARACION)Session["object1"]).MODIFICACION.MODIFICACION_INMUEBLEs[e.Row.RowIndex].MODIFICACION_INMUEBLE_TITULAs.Count.ToString();
            }
        }
    }
}