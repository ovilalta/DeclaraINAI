using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Conclusion
{
    public partial class pgConBieneVehiculos : System.Web.UI.UserControl
    {
        public List<blld_ALTA_VEHICULO> listVehiculosDecInicial
        {
            set
            {
                grdVehiculosDecInicial.DataSource = value;
                grdVehiculosDecInicial.DataBind();
            }
        }
        public List<blld_MODIFICACION_VEHICULO> listVehiculos
        {
            set
            {
                grdVehiculosModificacion.DataSource = value;
                grdVehiculosModificacion.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdVehiculos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((CheckBox)e.Row.FindControl("chAdeudo")).Checked = ((blld_DECLARACION)Session["object1"]).ALTA.ALTA_VEHICULOs[e.Row.RowIndex].ALTA_ADEUDOs.Any();
                ((Literal)e.Row.FindControl("ltrTitulares")).Text = ((blld_DECLARACION)Session["object1"]).ALTA.ALTA_VEHICULOs[e.Row.RowIndex].ALTA_VEHICULO_TITULARs.Count.ToString();
            }
        }

        protected void grdVehiculosModificacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["object1"];

                blld_PATRIMONIO_VEHICULO oPaVehiculo = new blld_PATRIMONIO_VEHICULO(
                    oDeclaracion.VID_NOMBRE
                    , oDeclaracion.VID_FECHA
                    , oDeclaracion.VID_HOMOCLAVE
                    , Convert.ToInt32(oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs[e.Row.RowIndex].NID_PATRIMONIO)
                    );

                blld_CAT_TIPO_VEHICULO oCatVehiculo = new blld_CAT_TIPO_VEHICULO(1);
                blld_CAT_MARCA_VEHICULO oCatMarcaVehiculo = new blld_CAT_MARCA_VEHICULO(oPaVehiculo.NID_MARCA);
                ((Image)e.Row.FindControl("imgTipo")).ImageUrl = String.Concat("~/Images/CAT_TIPO_VEHICULO/", "1", ".png");
                ((Literal)e.Row.FindControl("ltrTipo")).Text = "1";       //oCatVehiculo.V_TIPO_VEHICULO.ToString();                
                ((Literal)e.Row.FindControl("ltrMarcaMod")).Text = oCatMarcaVehiculo.V_MARCA;
                ((CheckBox)e.Row.FindControl("chAdeudoModificacion")).Checked = ((blld_DECLARACION)Session["object1"]).MODIFICACION.MODIFICACION_VEHICULOs[e.Row.RowIndex].MODIFICACION_VEHICULO_ADEUs.Any();
                ((Literal)e.Row.FindControl("ltrTitularesModificacion")).Text = ((blld_DECLARACION)Session["object1"]).MODIFICACION.MODIFICACION_VEHICULOs[e.Row.RowIndex].MODIFICACION_VEHICULO_TITUs.Count.ToString();
            }
        }


    }
}