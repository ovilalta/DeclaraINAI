using AlanWebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<MenuNode> l = new List<MenuNode>
                {
                    new MenuNode { Nid = 1, Text = "Inicio", Deep = 0, Active = true, HasChilds = true, },
                    new MenuNode { Nid = 2, Text = "Inicio", ParentId=1, Active = true, HasChilds = false, Href="./Index.aspx", ImageUrl= "~/images/icons/ColorX32/Cottage.png" },
                    new MenuNode { Nid = 3, Text = "Declaraciones", Deep = 0, Active = true, HasChilds = true, },
                    new MenuNode { Nid = 4, Text = "Declaracion de Inicio", ParentId=3, Active = true, HasChilds = false, Href="DeclaracionInicial/DatosGenerales.aspx", ImageUrl= "~/images/icons/ColorX32/Geo-fence.png" },
                    new MenuNode { Nid = 5, Text = "Declaraciones de Modificación", ParentId=3, Active = false, HasChilds = false, ImageUrl= "~/images/icons/ColorX32/Edit.png" },
                    new MenuNode { Nid = 6, Text = "Declaraciones de Conclusión", ParentId=3, Active = false, HasChilds = false, ImageUrl= "~/images/icons/ColorX32/Finish Flag.png"},
                    new MenuNode { Nid = 7, Text = "Declaraciones de Confilcto de Interes", ParentId=3, Active = false, HasChilds = false, ImageUrl= "~/images/icons/ColorX32/Yin Yang.png"},
                    new MenuNode { Nid = 8, Text = "Datos Personales", Deep = 0, Active = true, HasChilds = false, },
                    new MenuNode { Nid = 9, Text = "Modificar Datos Personales",ParentId=8, Active = false, HasChilds = false, ImageUrl= "~/images/icons/ColorX32/Family Man Woman.png" },
                    new MenuNode { Nid = 10, Text = "Patrimonio", Deep = 0, Active = true, HasChilds = false, },
                    new MenuNode { Nid = 11, Text = "Patrimonio",ParentId=10, Active = true, HasChilds = false, ImageUrl= "~/images/icons/ColorX32/Genealogy.png" },
                };

                //menu11.ParentIdField = "ParentId";
                //menu11.IdField = "Nid";
                //menu11.TextField = "Text";
                //menu11.ImageUrlField = "ImageUrl";
                //menu11.HrefField = "Href";
                //menu11.ToolTipField = "Text";
                //menu11.DataBind(l);

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}