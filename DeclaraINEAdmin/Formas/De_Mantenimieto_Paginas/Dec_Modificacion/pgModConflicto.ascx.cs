using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModConflicto : System.Web.UI.UserControl
    {
        public List<blld_CONFLICTO_RUBRO> DecConflicto
        {
            set
            {

                grdRubros.DataSource = value;
                grdRubros.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdRubros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["object1"];
                Int32 NID_RUBRO = Convert.ToInt32(((Label)e.Row.FindControl("NID_RUBRO")).Text);

                blld__l_CONFLICTO obc = new blld__l_CONFLICTO();
                obc.VID_NOMBRE = new Declara_V2.StringFilter(oDeclaracion.VID_NOMBRE);
                obc.VID_FECHA = new Declara_V2.StringFilter(oDeclaracion.VID_FECHA);
                obc.VID_HOMOCLAVE = new Declara_V2.StringFilter(oDeclaracion.VID_HOMOCLAVE);
                obc.NID_DEC_ASOS = new Declara_V2.IntegerFilter(oDeclaracion.NID_DECLARACION);
                obc.select();
                blld_CONFLICTO  oConflicto = new blld_CONFLICTO(obc.lista_CONFLICTO.First());
                ((GridView)e.Row.FindControl("grdRespuestas")).DataSource = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs;
                ((GridView)e.Row.FindControl("grdRespuestas")).DataBind();
            }
        }

        protected void grdRespuestas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["object1"];
                Int32 NID_CONFLICTO = Convert.ToInt32(((Label)e.Row.FindControl("NID_CONFLICTO")).Text);
                Int32 NID_RUBRO = Convert.ToInt32(((Label)e.Row.FindControl("NID_RUBRO")).Text);
                Int32 NID_ENCABEZADO = Convert.ToInt32(((Label)e.Row.FindControl("NID_ENCABEZADO")).Text);

                blld_CONFLICTO oConflicto = new blld_CONFLICTO(
                           oDeclaracion.VID_NOMBRE
                    , oDeclaracion.VID_FECHA
                    , oDeclaracion.VID_HOMOCLAVE
                    , NID_CONFLICTO
                    );

                ((Literal)e.Row.FindControl("ltrNombre")).Text = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().CONFLICTO_RESPUESTAs.Where(p => p.NID_PREGUNTA == 1).First().V_RESPUESTA;
                ((Literal)e.Row.FindControl("ltrParentesco")).Text = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().CONFLICTO_RESPUESTAs.Where(p => p.NID_PREGUNTA == 2).First().V_RESPUESTA;
                ((Literal)e.Row.FindControl("ltrEntidad")).Text = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().CONFLICTO_RESPUESTAs.Where(p => p.NID_PREGUNTA == 3).First().V_RESPUESTA;
                ((CheckBox)e.Row.FindControl("chDecPublica")).Checked = oConflicto.CONFLICTO_RUBROs.Where(p => p.NID_RUBRO == NID_RUBRO).First().CONFLICTO_ENCABEZADOs.Where(p => p.NID_ENCABEZADO == NID_ENCABEZADO).First().L_CONFLICTO.Value;

            }
        }



    }
}