using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using System.Globalization;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModIngresos : System.Web.UI.UserControl
    {
        public String F_INGRESO
        {
            get => txtF_INGRESO.Text;
            set => txtF_INGRESO.Text = value;
        }
        public String F_FINAL
        {
            get => txtF_FINAL.Text;
            set => txtF_FINAL.Text = value;
        }
        public String IngresosCargo
        {
            get => moneytxtIngresosCargo.Text;
            set => moneytxtIngresosCargo.Text = value;
        }
 
        public String Otros
        {
            get => moneytxtOtros.Text;
            set => moneytxtOtros.Text = value;
        }
        public String ingresosC
        {
            get => moneytxtingresosC.Text;
            set => moneytxtingresosC.Text = value;
        }
        public String ingresosT
        {
            get => moneytxtingresosT.Text;
            set => moneytxtingresosT.Text = value;
        }
        public System.Nullable<Boolean> Presento
        {
            set
            {
                if (value.HasValue)
                {
                    cbPresento.Checked = value.Value;
                }
                else
                {
                    cbPresento.Checked = false;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
       

        }


    }
}