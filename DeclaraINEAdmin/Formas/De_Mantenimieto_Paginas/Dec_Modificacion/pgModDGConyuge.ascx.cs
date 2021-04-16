using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModDGConyuge : System.Web.UI.UserControl
    {
        public List<blld_DECLARACION_DEPENDIENTES> LisDep
        {
            set
            {
                grdDEP.DataSource = value;
                grdDEP.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}