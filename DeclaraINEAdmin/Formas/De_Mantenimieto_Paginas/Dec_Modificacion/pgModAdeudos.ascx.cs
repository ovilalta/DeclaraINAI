using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using System.Globalization;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModAdeudos : System.Web.UI.UserControl
    {
 
        public List<blld_MODIFICACION_ADEUDO> listAdeudos
        {
            set
            {
                grdAdeudosModificacion.DataSource = value;
                grdAdeudosModificacion.DataBind();
            }
        }

        public List<blld_ALTA_ADEUDO> listAdeudosDecInicial
{
            set
            {
                grdAdeudos.DataSource = value;
                grdAdeudos.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdAdeudosModificacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                blld_PATRIMONIO_ADEUDO oPA = new blld_PATRIMONIO_ADEUDO(
                                        ((blld_DECLARACION)Session["object1"]).VID_NOMBRE
                    , ((blld_DECLARACION)Session["object1"]).VID_FECHA
                    , ((blld_DECLARACION)Session["object1"]).VID_HOMOCLAVE
                    , Convert.ToInt32(((blld_DECLARACION)Session["object1"]).MODIFICACION.MODIFICACION_ADEUDOs[e.Row.RowIndex].NID_PATRIMONIO)

                    );

                blld_CAT_TIPO_ADEUDO oCatAdeudo = new blld_CAT_TIPO_ADEUDO(oPA.NID_TIPO_ADEUDO);

                blld_CAT_PAIS oCatPais = new blld_CAT_PAIS(oPA.NID_PAIS);
                blld_CAT_INST_FINANCIERA oCatFinanciera = new blld_CAT_INST_FINANCIERA(oPA.NID_INSTITUCION);
                ((Literal)e.Row.FindControl("ltrNumeroCuentaMod")).Text = oPA.E_CUENTA;
                ((Literal)e.Row.FindControl("ltrFechaMod")).Text = oPA.F_ADEUDO.ToString("dd/MM/yyyy", new CultureInfo("es-MX"));

                ((Image)e.Row.FindControl("imgTipoMod")).ImageUrl = String.Concat("~/Images/CAT_TIPO_ADEUDO/", oPA.NID_TIPO_ADEUDO, ".png");
                ((Literal)e.Row.FindControl("ltrTipoMod")).Text = oCatAdeudo.V_TIPO_ADEUDO;
                ((Literal)e.Row.FindControl("ltrPaisMod")).Text = oCatPais.V_PAIS;
                ((Literal)e.Row.FindControl("ltrInstitucionMod")).Text = oCatFinanciera.V_INSTITUCION;
            }
        }

        protected void grdAdudos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }

        }
    }
}