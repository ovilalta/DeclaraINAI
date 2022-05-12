﻿using Declara_V2.BLLD;
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

            #region Logica Permisos Admin para menu
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
                LkFiscal.Visible = false;
            }
            else
            {
                btnAdmin.Visible = true;
                LkFiscal.Visible = true;
            }
            #endregion  

            #region Logica Permisos para visualizar boton acuse fiscal
            string lineFiscal;
            bool excepFiscal = false;
            var buildDirFiscal = HttpRuntime.AppDomainAppPath;
            var filePathFiscal = buildDirFiscal + @"\bin\CargaAcuseFiscalExcepcion.txt";
            StreamReader fileFiscal = new StreamReader(filePathFiscal);
            while ((lineFiscal = fileFiscal.ReadLine()) != null)
            {
                if (VID_RFC.Equals(lineFiscal))
                {
                    excepFiscal = true;
                }
            }
            fileFiscal.Close();
            if (excepFiscal == false)
            {

                LkFiscal.Visible = false;
            }
            else
            {

                LkFiscal.Visible = true;
            }
            #endregion  

            LabNombre.Text = oUsuario.V_NOMBRE_COMPLETO;
            labFecha.Text = DateTime.Today.ToString("dd/MMMM/yyyy", new CultureInfo("es-MX")).ToUpper();

            if (!IsPostBack)
            {
                if (DateTime.Now < FechaIni || DateTime.Now > FechaFin)
                {
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



        protected void lkFiscal_Click(object sender, EventArgs e)
        {
            //Pantalla para sustituir el archivo pdf del acuse fiscal
            Response.Redirect("DeclaracionFiscal\\declaracionFiscalSustituirPdf.aspx");

        }

    }
}