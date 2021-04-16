using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModInversiones : System.Web.UI.UserControl
    {
        public List<blld_ALTA_INVERSION> listInversionesDecInicial
        {
            set
            {
                grdInversionesDecInicial.DataSource = value;
                grdInversionesDecInicial.DataBind();
            }
        }

        public List<blld_MODIFICACION_INVERSION> listInversiones
        {
            set
            {
                grdInversionesModificacion.DataSource = value;
                grdInversionesModificacion.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdInversionesDecInicial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                blld__l_CAT_SUBTIPO_INVERSION oSubInversion = new blld__l_CAT_SUBTIPO_INVERSION();
                oSubInversion.select();
                ((Literal)e.Row.FindControl("ltrSubtipo")).Text = oSubInversion.lista_CAT_SUBTIPO_INVERSION.Where(p => p.NID_SUBTIPO_INVERSION == ((blld_DECLARACION)Session["object1"]).ALTA.ALTA_INVERSIONs[e.Row.RowIndex].NID_SUBTIPO_INVERSION).First().V_SUBTIPO_INVERSION.ToString();
                ((Literal)e.Row.FindControl("ltrTipo")).Text = ((blld_DECLARACION)Session["object1"]).ALTA.ALTA_INVERSIONs[e.Row.RowIndex].V_TIPO_INVERSION.ToString();
                ((Literal)e.Row.FindControl("ltrInstitucion")).Text = ((blld_DECLARACION)Session["Object1"]).ALTA.ALTA_INVERSIONs[e.Row.RowIndex].V_INSTITUCION.ToString();
                ((Literal)e.Row.FindControl("ltrTitulares")).Text = ((blld_DECLARACION)Session["object1"]).ALTA.ALTA_INVERSIONs[e.Row.RowIndex].ALTA_INVERSION_TITULARs.Count.ToString();
            }
        }

        protected void grdInversionesModificacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["object1"];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                blld_PATRIMONIO_INVERSION oI = new blld_PATRIMONIO_INVERSION(
                 oDeclaracion.VID_NOMBRE
                 , oDeclaracion.VID_FECHA
                 , oDeclaracion.VID_HOMOCLAVE
                 , Convert.ToInt32(oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Row.RowIndex].NID_PATRIMONIO)
                 );
                blld__l_CAT_INST_FINANCIERA oInversion = new blld__l_CAT_INST_FINANCIERA();
                oInversion.select();
                blld__l_CAT_SUBTIPO_INVERSION oSubInversion = new blld__l_CAT_SUBTIPO_INVERSION();
                oSubInversion.select();
                blld__l_CAT_PAIS oPais = new blld__l_CAT_PAIS();
                oPais.select();

                //            blld_ALTA_INVERSION oInv = new blld_ALTA_INVERSION(oDeclaracion.VID_NOMBRE
                //, oDeclaracion.VID_FECHA
                //, oDeclaracion.VID_HOMOCLAVE
                //, Convert.ToInt32(oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Row.RowIndex].NID_DECLARACION)
                //    , Convert.ToInt32(oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Row.RowIndex]),
                //    Convert.ToInt32(oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs[e.Row.RowIndex].NID_PATRIMONIO.ToString()
                //             )

                ((Image)e.Row.FindControl("imgTipoModificacion")).ImageUrl = String.Concat("~/Images/CAT_TIPO_INVERSION/", oI.NID_TIPO_INVERSION, ".png");
                ((Literal)e.Row.FindControl("ltrTipoModificacion")).Text = oI.V_TIPO_INVERSION;
                ((Literal)e.Row.FindControl("ltrSubtipoModificacion")).Text = oSubInversion.lista_CAT_SUBTIPO_INVERSION.Where(p => p.NID_SUBTIPO_INVERSION == oI.NID_SUBTIPO_INVERSION).First().V_SUBTIPO_INVERSION.ToString();
                ((Literal)e.Row.FindControl("ltrInstitucionModificacion")).Text = oInversion.lista_CAT_INST_FINANCIERA.Where(p => p.NID_INSTITUCION == oI.NID_INSTITUCION).First().V_INSTITUCION.ToString();
                ((Literal)e.Row.FindControl("ltrPaisModificacion")).Text = oPais.lista_CAT_PAIS.Where(p => p.NID_PAIS == oI.NID_PAIS).First().V_PAIS.ToString();

          
                    //((Literal)e.Row.FindControl("ltrFechaModificacion")).Text = oDeclaracion.ALTA.ALTA_INVERSIONs[e.Row.RowIndex].F_APERTURA.ToString("dd/MM/yyyy");
      
                    ((Literal)e.Row.FindControl("ltrFechaModificacion")).Text = "1";
            

                ((Literal)e.Row.FindControl("ltrNumeroCuentaModificacion")).Text = oI.V_CUENTA_CORTO.ToString();
                ((Literal)e.Row.FindControl("moneytxtValorModificacion")).Text = oI.M_SALDO.ToString("C");
                ((Literal)e.Row.FindControl("ltrTitularesModificacion")).Text = ((blld_DECLARACION)Session["object1"]).MODIFICACION.MODIFICACION_INVERSIONs[e.Row.RowIndex].MODIFICACION_INVERSION_TITUs.Count.ToString();
            }
        }


    }
}