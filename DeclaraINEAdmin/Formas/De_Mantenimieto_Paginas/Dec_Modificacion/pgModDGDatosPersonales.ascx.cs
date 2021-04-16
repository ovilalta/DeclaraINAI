using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion
{
    public partial class pgModDGDatosPersonales : System.Web.UI.UserControl
    {
        public String Nombre
        {
            get => ltrNombre.Text;
            set => ltrNombre.Text = value;
        }
        public String RFC
        {
            get => ltrRFC.Text;
            set => ltrRFC.Text = value;
        }
        public String FechaNacimiento
        {
            get => ltrFechaNacimiento.Text;
            set => ltrFechaNacimiento.Text = value;
        }
        public String Sexo
        {
            get => ltrSexo.Text;
            set => ltrSexo.Text = value;
        }
        public String CURP
        {
            get => ltrCURP.Text;
            set => ltrCURP.Text = value;
        }
        public String LugarNacimiento
        {
            get => ltrLugar.Text;
            set => ltrLugar.Text = value;
        }
        public String Nacionalidad
        {
            get => ltrNacionalidad.Text;
            set => ltrNacionalidad.Text = value;
        }
        public String Civil
        {
            get => ltrCivil.Text;
            set => ltrCivil.Text = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}