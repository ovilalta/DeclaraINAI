using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModEnvio : System.Web.UI.UserControl
    {
        public System.Nullable<Boolean> DecPublica
        {
            set
            {
                if (value.HasValue)
                {
                    chDecPublica.Checked = value.Value;
                }
                else
                {
                    chDecPublica.Checked = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}