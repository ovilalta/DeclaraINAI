using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Conclusion
{
    public partial class pgConCargo : System.Web.UI.UserControl
    {
        public String ClavePuesto
        {
            get => ltrClaveP.Text;
            set => ltrClaveP.Text = value;
        }
        public String ClaveNivel
        {
            get => ltrClaveN.Text;
            set => ltrClaveN.Text = value;
        }
        public String DenominacionPuesto
        {
            get => ltrDenPuesto.Text;
            set => ltrDenPuesto.Text = value;
        }
        public String DenominacionCargo
        {
            get => ltrDenomCargo.Text;
            set => ltrDenomCargo.Text = value;
        }
        public String UA
        {
            get => ltrUA.Text;
            set => ltrUA.Text = value;
        }
        public String AreaAdscripcion
        {
            get => ltrAAd.Text;
            set => ltrAAd.Text = value;
        }
        public String FechaPosesion
        {
            get => ltrFechaPosesion.Text;
            set => ltrFechaPosesion.Text = value;
        }
        public String FechaIngreso
        {
            get => ltrFechaIngreso.Text;
            set => ltrFechaIngreso.Text = value;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}