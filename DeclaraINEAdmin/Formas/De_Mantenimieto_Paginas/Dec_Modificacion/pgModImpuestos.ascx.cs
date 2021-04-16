using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;


namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModImpuestos : System.Web.UI.UserControl
    {
        List<blld_MODIFICACION_GASTO> liInpuestos = new List<blld_MODIFICACION_GASTO>();
        public List<blld_MODIFICACION_GASTO> listImpuesto
        {
            set
            {
                foreach(blld_MODIFICACION_GASTO o in value)
                {
                    if(o.NID_TIPO_GASTO == 1)
                        liInpuestos.Add(o);                    
                }
                grdInpuestos.DataSource = liInpuestos;
                grdInpuestos.DataBind();
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}