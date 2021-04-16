using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DeclaraINEAdmin.Formas
{
    public partial class RegistroDeclarante : Pagina
    {

        public static CultureInfo esMX => new CultureInfo("es-MX");

        protected void Page_Load(object sender, EventArgs e)
        {
            ////((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("RegistroDeclarante.aspx");
            if (!IsPostBack)
            {
                ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("RegistroDeclarante.aspx");
                txtFecha_C.EndDate = DateTime.Today.AddYears(-18);
                txtFIngreso_C.EndDate = DateTime.Today.AddDays(0);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                //if (txtPasswordConfirma.Text.Trim() != txtPassword.Text.Trim())
                //    throw new CustomException("La contraseña y la confirmación no coinciden");

                blld_USUARIO o = new blld_USUARIO(false,
                      txtVID_NOMBRE.Text
                    , txtVID_FECHA.Text
                    , txtVID_HOMOCLAVE.Text
                                                         //, String.Concat(txtVID_NOMBRE.Text, txtVID_FECHA.Text, txtVID_HOMOCLAVE.Text)
                                                         , txtNombre.Text.Trim()
                                                         , txtPrimerApellido.Text.Trim()
                                                         , txtSegundoApellido.Text.Trim()
                                                         , txtFecha.Date(esMX)
                                                         , txtCorreo.Text
                                                         , txtFIngreso.Date(esMX));

                MsgBox.ShowSuccess("El usuario se dio de alta exitosamente");

            }
            catch (Exception ex)
            {
                MsgBox.ShowDanger(ex.Message);


            }
        }

    }
}