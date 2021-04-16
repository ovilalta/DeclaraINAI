using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Conclusion
{
    public partial class pgConObservaciones : System.Web.UI.UserControl
    {
        public String Observacion
        {
            get => ltrObserva.Text;
            set => ltrObserva.Text = value;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}