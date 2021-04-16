using AlanWebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dumm
{
    public partial class Menu : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.LinkButton1.Attributes.Remove("href");
                //this.LinkButton1.Attributes.Add("href", "#");
                List<MenuNode> l = new List<MenuNode>
                {
                    new MenuNode { Nid = 1, Text = "Usuario", Deep = 0, Active = true, HasChilds = true, ImageUrl= "~/images/icons/ColorX32/Alt.png"},
                    new MenuNode { Nid = 2, Text = "Evaluacion Patrimonial", Deep = 0, Active = false, HasChilds = false },
                    new MenuNode { Nid = 3, Text = "Catalogos", Deep = 0, Active = false, HasChilds = false },
          

                    new MenuNode { Nid = 4, Text = "Cambio de Contraseña", Deep = 1, ParentId = 1, Active = false, Href="@.aspx"},
                    new MenuNode { Nid = 5, Text = "Declaraciones", Deep = 1, ParentId = 1, Active = false,   Href="@.aspx"},

                    new MenuNode { Nid = 6, Text = "Patrimonial", Deep = 1, ParentId = 2, Active = false, Href="@.aspx"},
                    new MenuNode { Nid = 7, Text = "Consulta", Deep = 1, ParentId = 2, Active = false, Href="@.aspx"},


                    new MenuNode { Nid = 8, Text = "Confricto de Interes", Deep = 1, ParentId = 3, Active = false, Href="@.aspx"},
                    new MenuNode { Nid = 9, Text = "Niveles", Deep = 1, ParentId = 3, Active = false, Href="@.aspx"},
                    new MenuNode { Nid = 10, Text = "Areas", Deep = 1, ParentId = 3, Active = false, Href="@.aspx"},

                };
                menu11.ParentIdField = "ParentId";
                menu11.IdField = "Nid";
                menu11.TextField = "Text";
                menu11.ImageUrlField = "ImageUrl";
                menu11.HrefField = "Href";
                menu11.ToolTipField = "Text";
                menu11.DataBind(l);
            }
            else
            {
            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            menu11.Activate("juanjua.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            menu11.Activate("cuatro.aspx");
        }
    }
}