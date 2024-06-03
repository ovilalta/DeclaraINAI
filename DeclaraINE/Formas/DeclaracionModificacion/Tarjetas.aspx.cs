using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas.DeclaracionModificacion
{
    public partial class Tarjetas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((HtmlAnchor)Master.FindControl("aTarjetas")).Attributes.Add("class", "active");
            }
        }
    }
}