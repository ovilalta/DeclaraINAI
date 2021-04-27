using Declara_V2.BLLD;
using System;
using System.IO;
using System.Web;
using System.Linq;
using DeclaraINE.file;
using System.Collections.Generic;
using Declara_V2.MODELextended;
using Declara_V2;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace DeclaraINE.Formas
{
    public partial class ActivacionesAdmin : Pagina
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
                Page.Title = "Activación de cuenta";
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
        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void btnDescargar_Actualizar(object sender, EventArgs e)
        {
            if (txtRFC.Text == "" || txtRFC.Text == null)
            {
                msgBox.ShowDanger("Debe especificar un RFC.");
            }
            else
            {
                string VID_NOMBRE = txtRFC.Text.Substring(0, 4);
                string VID_FECHA = txtRFC.Text.Substring(4, 6);
                string VID_HOMOCLAVE = txtRFC.Text.Substring(10, 3);
                blld_USUARIO oUsuario = new blld_USUARIO(VID_NOMBRE
                       , VID_FECHA
                       , VID_HOMOCLAVE);
                try
                {
                    oUsuario.ActivarAdmin(txtRFC.Text);
                    msgBox.ShowSuccess("Se ha activado el usuario con RFC: " + txtRFC.Text + " con éxito.");
                }
                catch (Exception ex)
                {
                    msgBox.ShowDanger(ex.Message);
                }
            }
        }
    }
}