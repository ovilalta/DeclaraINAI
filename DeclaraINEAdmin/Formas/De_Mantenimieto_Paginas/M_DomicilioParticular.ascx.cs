using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas
{
    public partial class M_DomicilioParticular : System.Web.UI.UserControl
    {
        public String CP
        {
            get => ltrCP.Text;
            set => ltrCP.Text = value;
        }
        public String Pais
        {
            get => ltrPais.Text;
            set => ltrPais.Text = value;
        }
        public String Entidad
        {
            get => ltrEntidad.Text;
            set => ltrEntidad.Text = value;
        }
        public String Municipio
        {
            get => ltrMunicipio.Text;
            set => ltrMunicipio.Text = value;
        }

        public String Colonia
        {
            get => ltrColonia.Text;
            set => ltrColonia.Text = value;
        }
        public String Calle
        {
            get => ltrCalle.Text;
            set => ltrCalle.Text = value;
        }
        public String Correo
        {
            get => ltrMail.Text;
            set => ltrMail.Text = value;
        }
        public String TParticular
        {
            get => ltrTelefonoP.Text;
            set => ltrTelefonoP.Text = value;
        }
        public String TCelular
        {
            get => ltrTelefonoC.Text;
            set => ltrTelefonoC.Text = value;
        }
 
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}