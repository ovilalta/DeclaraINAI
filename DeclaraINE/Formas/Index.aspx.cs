using Declara_V2.BLLD;
using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;

namespace DeclaraINE.Formas
{
    public partial class Index : Pagina
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
            DateTime FechaIni = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["FechaIniMod"]);
            DateTime FechaFin = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["FechaFinMod"]);
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
                btnAdmin.Visible = false;
                
                //btnAdmin2.Visible = false;
                //btnAdmin3.Visible = false;
                //btnAdmin4.Visible = false;
                //btnAdmin5.Visible = false;
                //btnAdmin6.Visible = false;
                //btnAdmin7.Visible = false;
            }
            else
            {
                btnAdmin.Visible = true;

                //btnAdmin2.Visible = true;
                //btnAdmin3.Visible = true;
                //btnAdmin4.Visible = true;
                //btnAdmin5.Visible = true;
                //btnAdmin6.Visible = true;
                //btnAdmin7.Visible = true;

            }

            

            LabNombre.Text = oUsuario.V_NOMBRE_COMPLETO;
            labFecha.Text = DateTime.Today.ToString("dd/MMMM/yyyy", new CultureInfo("es-MX")).ToUpper();

            if (!IsPostBack)
            {
                if (DateTime.Now < FechaIni || DateTime.Now > FechaFin) {
                    LinkButton22.Enabled = false;
                    lkModificacion.Enabled = false;
                }
                

                QstBox.AskWarning("<b>Compañero(a) Servidor(a) Público(a):</b><br/>De conformidad con los artículos 26, 27, 32," +
                    " 33, 46, 47 y 48 de la LGRA todos los servidores públicos tenemos la obligación de presentar las declaraciones" +
                    " de situación patrimonial, de intereses y la constancia de presentación de declaración fiscal, bajo protesta " +
                    "de decir verdad y ante el Órgano Interno de Control, en los términos, plazos y modalidad que establece la propia " +
                    "legislación aplicable; así como cumplir el Código de Ética. ¿Realmente deseas comenzar a llenar tu Declaración de " +
                    "Situación Patrimonial y de Intereses, así como la constancia de presentación de declaración fiscal?</p></h3>");

                _oUsuario.ExtenderSesion();
                this.Page.Title = "Menú Principal";
                
                if (clsSistema.lActivaAviso)
                    pnlAviso.Visible = true;
                else
                    pnlAviso.Visible = false;
            }
            try
            {
                if (Session["oMensaje"] != null)
                {
                    QstBox.AskWarning((String)Session["oMensaje"]);
                    QstBox.YesText = "Aceptar";
                    QstBox.NoText = "Cerrar";
                    QstBox.NoCssClass = "ocultarBoton ";
                    Session.Remove("oMensaje");
                }
            }
            catch
            {
            }

        }

        protected void QstBox_No(object Sender, EventArgs e)
        {

        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AvisoPrivacidadDeclaracionInicial.aspx", false);
            //try
            //{
            //    blld_USUARIO oUsuario = _oUsuario;
            //    blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE
            //                                                        , oUsuario.VID_FECHA
            //                                                        , oUsuario.VID_HOMOCLAVE
            //                                                        , DateTime.Now.Year.ToString()
            //                                                        ,1);
            //    SessionAdd("oDeclaracion", oDeclaracion);
            //    Response.Redirect("AvisoPrivacidadDeclaracionInicial.aspx",false);
            //}
            //catch (Exception ex)
            //{
            //    if (ex is CustomException || ex is ConvertionException)
            //    {
            //        MsgBox.ShowDanger(ex.Message);
            //    }
            //    else throw ex;
            //}
        }
        protected void btnConsultaDeclaracion_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaDeclaracion.aspx");
        }

        protected void btnPatrimonio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patrimonio\\Patrimonio.aspx");
        }

        protected void lkModificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AvisoPrivacidadDeclaracionModificacion.aspx");
            
        }
        protected void lkConclusion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AvisoPrivacidadConclusion.aspx");
            
        }


        protected void lkAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministracionCuenta.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            _oUsuario.FinalizarSesion();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void lkConflicto_Click(object sender, EventArgs e)
        {
            //Response.Redirect("DeclaracionConflicto\\Conflicto.aspx"); //Activar de nuevo la llamada de la declaración de conflicto de intereses
            Response.Redirect("AvisoPrivacidadConflicto.aspx");
        }

        protected void lkFiscal_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeclaracionFiscal\\declaracionFiscal.aspx");
        }

        

       

        
    }
}