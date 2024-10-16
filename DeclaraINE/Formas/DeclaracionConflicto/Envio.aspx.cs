using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
 
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace DeclaraINAI.Formas.DeclaracionConflicto
{
    public partial class Envio : Pagina, IDeclaracionInicial
    {
        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }

        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            ((HtmlControl)Master.FindControl("liEnvio")).Attributes.Add("class", "active");
            ((HtmlControl)Master.FindControl("menu7")).Attributes.Add("class", "tab-pane fade level1 active in");
            if (!IsPostBack)
            {
              
                ((Button)Master.FindControl("btnAnterior")).Visible = false;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Enviar";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "send";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Enviar declaración";
                cambiarBoton();
                PostBackTrigger trigger = new PostBackTrigger();
                trigger.ControlID = btnPrevisualizar.UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);
                this.SiNo.Checked = true;
                if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                {
                    //QstBoxVistaPDF.AskWarning("Se está generando la vista previa de su declaración, se le notificara por correo a la brevedad.");

                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO = true;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().update();
                    _oDeclaracion = oDeclaracion;
                }
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                ((LinkButton)Master.FindControl("lkEnvio")).CssClass = "completeve";
            else
                ((LinkButton)Master.FindControl("lkEnvio")).CssClass = "active";

        }

        private void cambiarBoton()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
            {
                //    btnPrevisualizar.CssClass = "big pdf";
                //    //lrtAccion.Text = "Vista previa de la declaración";
                //    lrtAccion.Text = "Descarga acuse de recibido";
                //}
                //else
                //{ 
            }
            btnPrevisualizar.CssClass = "big enviar";
            lrtAccion.Text = "Enviar la declaración";

        }

        private void enviar()
        {
            try
            {
                if (_oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO != 0 && p.L_ESTADO == false).Any())
                {
                    MsgBox.ShowDanger("Debe finalizar todos los apartados para poder enviar la declaración");
                }
                else
                {
                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    MODELDeclara_V2.DECLARACION registro = new MODELDeclara_V2.DECLARACION();
                    registro = db.DECLARACION.Find(_oUsuario.VID_NOMBRE, _oUsuario.VID_FECHA, _oUsuario.VID_HOMOCLAVE, _oDeclaracion.NID_DECLARACION);
                    DateTime F_ENVIO = DateTime.Now;
                    registro.F_ENVIO = F_ENVIO;
                    registro.NID_ESTADO = 2;
                    ////registro.V_HASH = String.Concat(_oUsuario.VID_NOMBRE, _oUsuario.VID_FECHA, _oUsuario.VID_HOMOCLAVE, '|', Convert.ToInt16(SiNo.Checked).ToString(), '|', _oDeclaracion.F_REGISTRO, '|', F_ENVIO);
                    db.SaveChanges();

                    //    _oDeclaracion.enviar(SiNo.Checked);
                    QstBox.AskSuccess("Se envió correctamente la declaración ¿Desea consultar el acuse?");
                }
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    if (ex.InnerException != null)
                    {
                        MsgBox.ShowDanger(ex.InnerException.Message);
                    }
                    else
                    {
                        MsgBox.ShowDanger(ex.Message);
                    }
                }
                else
                {
                    if (ex.InnerException == null)
                    {
                        throw ex;
                    }
                    else if (ex.InnerException is CustomException)
                    {
                        MsgBox.ShowDanger(ex.InnerException.Message);
                    }
                    else
                    {
                        throw ex;
                    }
                }


            }

        }
        public string Encripta(String Cadena, Byte[] Key1, Byte[] Key2)
        {
            Cadena = System.Net.WebUtility.HtmlEncode(Cadena);
            byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Key1, Key2), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return String.Concat('|', Convert.ToBase64String(encripted), '|');
        }
        public void Anterior()
        {
            Response.Redirect("Conflicto.aspx");
        }

        public void Guardar()
        {
        }

        public void Siguiente()
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
            {
                QstBoxEnviar.AskWarning("¿Desea enviar la declaración? <br />Debe tomar en cuenta que una vez enviada la declaración no podrá hacer modificaciones");
            }
            else
            {
                MsgBox.ShowDanger("se está generando la vista previa de tu declaracion, intente mas tarde");
            }
        }

        protected void btnPrevisualizar_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;

            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
            {
                //QstBoxVistaPDF.AskWarning("Se está generando la vista previa de su declaración, se le notificara por correo a la brevedad.");

                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO = true;
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().update();
                _oDeclaracion = oDeclaracion;
                //_Inicial.Imprimir(oDeclaracion, true);
                //         _Inicial.ImprimirAcuseInicial(oDeclaracion, oUsuario);

                //             AmprimeAcuse();
            }
            else
            {
                if (_oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO != 0 && p.L_ESTADO == false).Any())
                {
                    MsgBox.ShowDanger("Debe finalizar todos los apartados para poder enviar la declaración");
                }
                else
                {
                    cambiarBoton();
                    QstBoxEnviar.AskWarning("¿Desea enviar la declaración? <br />Debe tomar en cuenta que una vez enviada la declaración no podrá hacer modificaciones");
                }
            }
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {
           //   Response.Redirect("../Index.aspx");
                  Response.Redirect("../ConsultaAcuse.aspx");
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void QstBoxEnviar_Yes(object Sender, EventArgs e)
        {
            enviar();
        }

        protected void QstBoxVistaPDF_Yes(object Sender, EventArgs e)
        {

        }

        protected void QstBoxVistaPDF_No(object Sender, EventArgs e)
        {

        }


        protected void QstBoxEnviar_No(object Sender, EventArgs e)
        {

        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //blld_DECLARACION oDeclaracion = _oDeclaracion;
                //try { _Inicial.Imprimir(oDeclaracion); }
                //catch (Exception ex) { }
            }
        }

        protected void SiNo_CheckedChanged(object sender, EventArgs e)
        {
            _oDeclaracion.L_AUTORIZA_PUBLICAR = SiNo.Checked;
            _oDeclaracion.update();
        }

    }
}