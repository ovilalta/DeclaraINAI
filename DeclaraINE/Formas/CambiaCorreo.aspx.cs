using Declara_V2.BLLD;
using System;
using System.IO;
using System.Web;
using System.Linq;
using DeclaraINAI.file;
using System.Collections.Generic;
using Declara_V2.MODELextended;
using Declara_V2;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using Declara_V2.BLL;

namespace DeclaraINAI.Formas
{
    public partial class CambiaCorreo : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;

            string VID_RFC = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE;
            if (!IsPostBack)
            {
                Page.Title = "Correo alterno";
                string line;
                bool excep = false;
                var buildDir = HttpRuntime.AppDomainAppPath;
                var filePath = buildDir + @"\Formas\Administrador\Administradores.txt";
                StreamReader file = new StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    if (VID_RFC.Equals(line))
                    {
                        excep = true;
                    }
                }
                file.Close();
                if (excep == false)
                {
                    Response.Redirect("..\\Index.aspx");
                }
            }
        }
        protected void btnDescargar_Actualizar(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = new blld_USUARIO(txtRFC.Text);
            try
            {
                bool CorreoValidar = _bllSistema.IsValidEmail(txtCorreoPers.Text); //Envía datos capturados para validar si tiene el formato de correo electrónico
                //Si la validación de formato de correo electrónica es verdadera, procede con la inserción del dato.
                if (CorreoValidar)
                {
                    oUsuario.Reload_USUARIO_CORREOs();
                    oUsuario.Add_USUARIO_CORREOs(txtCorreoPers.Text, false, true);
                    string vCorreo = blld_USUARIO_REC_PASS.SolicitaRecuperacionV2(txtRFC.Text);
                    oUsuario.FinalizarSesion(); //OEVM 20230606 
                    msgx.ShowSuccess("Se ha enviado un correo a " + vCorreo + ", con un enlace para restablecer su contraseña");
                }
                else
                {
                    msgx.ShowDanger("El texto capturado " + txtCorreoPers.Text + ", no es un correo electrónico");
                }
            }
            catch (Exception ex)
            {
                msgx.ShowDanger(ex.Message);
            }
        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}