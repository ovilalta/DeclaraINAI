using Declara_V2.BLLD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;

namespace DeclaraINAI.Formas
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
            //DateTime FechaBtnEnvMod = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["FechaActBtnEnvMod"]);

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

            #region Logica Permisos Admin para menu bitacora
            string lineBitacora;
            bool excepBitacora = false;
            var buildDirBitacora = HttpRuntime.AppDomainAppPath;
            var filePathBitacora = buildDir + @"\Formas\Administrador\AdministradoresBitacora.txt";
            StreamReader fileBitacora = new StreamReader(filePathBitacora);
            while ((lineBitacora = fileBitacora.ReadLine()) != null)
            {
                if (VID_RFC.Equals(lineBitacora))
                {
                    excepBitacora = true;
                }
            }
            fileBitacora.Close();
            if (excepBitacora == false)
            {
                btnAdminBitacora.Visible = false;
                
            }
            else
            {
                btnAdminBitacora.Visible = true;                
            }
            #endregion

            //Agregar logica para revisar si existe autorizacion para usar la edicion de conflicto de intereses
            MODELDeclara_V2.cnxDeclara dbBuscaConflictoI = new MODELDeclara_V2.cnxDeclara();
            string connStringConflictoI = dbBuscaConflictoI.Database.Connection.ConnectionString;
            string sqlConflictoIBuscar = "SP_BuscaRfcConflictoI";
            bool excepConflictoI = false;
            using (SqlConnection connConflictoI = new SqlConnection(connStringConflictoI))
            {
                try
                {
                    connConflictoI.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlConflictoIBuscar, connConflictoI))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.Default);

                        if (drd != null)
                        {

                            while (drd.Read())
                            {
                                string rfcTemp = drd.GetString(0);
                                if (rfcTemp == VID_RFC)
                                {
                                    excepConflictoI = true;
                                }
                            }
                            connConflictoI.Close();
                        }

                        if (excepConflictoI == false)
                        {
                            lkConflicto.Enabled = false;
                        }
                        else
                        {
                            lkConflicto.Enabled = true;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                

                #region Logica Permisos para visualizar boton acuse fiscal

                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                string connString = db.Database.Connection.ConnectionString;
                string sql = "SP_BuscaRfcAcuseFiscal";
                bool excepFiscal = false;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.Default);

                            if (drd != null)
                            {
                                while (drd.Read())
                                {
                                    string rfcTemp = drd.GetString(0);
                                    if (rfcTemp == VID_RFC)
                                    {
                                        excepFiscal = true;
                                    }
                                }
                                conn.Close();
                            }

                            if (excepFiscal == false)
                            {
                                LkFiscal.Visible = false;
                            }
                            else
                            {
                                LkFiscal.Visible = true;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                }

                #endregion

                LabNombre.Text = oUsuario.V_NOMBRE_COMPLETO;
                labFecha.Text = DateTime.Today.ToString("dd/MMMM/yyyy", new CultureInfo("es-MX")).ToUpper();

                if (!IsPostBack)
                {
                    //Condicion para activar el boton de modificacion dentro del periodo autorizado
                    if (DateTime.Now < FechaIni || DateTime.Now > FechaFin)
                    {
                        LinkButton22.Enabled = false;
                        lkModificacion.Enabled = false;
                    }


                    QstBox.AskWarning("<b>Compañero(a) Servidor(a) Público(a):</b><br/>De conformidad con los artículos 26, 27, 32," +
                        " 33, 46, 47 y 48 de la LGRA todos los servidores públicos tenemos la obligación de presentar las declaraciones" +
                        " de situación patrimonial, de intereses y la constancia de presentación de declaración fiscal, bajo protesta " +
                        "de decir verdad y ante el Órgano Interno de Control, en los términos, plazos y modalidad que establece la propia " +
                        "legislación aplicable; así como cumplir el Código de Ética y Código de Conducta. ¿Desea ingresar a su cuenta en DeclaraINAI?</p></h3>");

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
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            Session.Remove("oUsuario");
            Response.Redirect("Login.aspx");
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }

        protected void btnBitacora_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador/ReporteBitacora.aspx", false);
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

        protected void lkConflicto_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeclaracionConflicto\\Conflicto.aspx");
        }

    }
}