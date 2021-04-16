using AlanWebControls;
using Declara_V2.BLLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace DeclaraINE.Formas.Patrimonio
{
    public partial class _patrimonio : System.Web.UI.MasterPage
    {
        protected void SessionAdd(String ObjectName, Object Objeto)
        {
            if (Session[ObjectName] == null) Session.Add(ObjectName, Objeto);
            else Session[ObjectName] = Objeto;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPatrimonio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patrimonio.aspx");
        }

      

        protected void lkImprimir_Click(object sender, EventArgs e)
        {

        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
    }
}