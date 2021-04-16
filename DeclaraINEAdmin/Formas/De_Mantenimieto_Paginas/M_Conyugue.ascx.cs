using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Declara_V2.BLLD;


namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas
{
    public partial class M_Conyugue : System.Web.UI.UserControl
    {

        //public String Nombre
        //{
        //    get => ltrNombre.Text;
        //    set => ltrNombre.Text = value;
        //}
        //public String Parentesco
        //{
        //    get => ltrParentesco.Text;
        //    set => ltrParentesco.Text = value;
        //}
        //public Boolean Dependiente
        //{
        //    get => cbxDependiente.Checked;
        //    set => cbxDependiente.Checked = value;
        //}
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