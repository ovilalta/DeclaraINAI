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
using DeclaraINAI.file;
using System.Collections.Generic;

namespace DeclaraINAI.Formas.DeclaracionConclusion
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
                this.SiNo.Checked = true;

                ((Button)Master.FindControl("btnAnterior")).Visible = true;
                ((Button)Master.FindControl("btnSiguiente")).Text = "Enviar";
                ((Button)Master.FindControl("btnSiguiente")).CssClass = "send";
                ((Button)Master.FindControl("btnSiguiente")).ToolTip = "Enviar declaración";
                cambiarBoton();
                PostBackTrigger trigger = new PostBackTrigger();
                trigger.ControlID = btnPrevisualizar.UniqueID;
                ((UpdatePanel)Master.FindControl("pnlMain")).Triggers.Add(trigger);

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

                    ////String VersionDeclaracion = string.Empty;
                    ////blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                    ////blld_DECLARACION oDeclaracion = _oDeclaracion;
                    ////oPuesto.select();

                    ////var obligado = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single().L_OBLIGADO;
                    ////if (obligado.Equals(true))
                    ////    VersionDeclaracion = "DECLARACION_CONCLUSION";
                    ////else
                    ////    VersionDeclaracion = "DECLARACION_CONCLUSION_SIMPLI";

                    ////file.fileSoapClient o = new file.fileSoapClient();
                    ////FileStream fs1;
                    ////SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { _oUsuario.VID_NOMBRE
                    ////                                                           ,_oUsuario.VID_FECHA
                    ////                                                           ,_oUsuario.VID_HOMOCLAVE
                    ////                                                           ,_oDeclaracion.NID_DECLARACION
                    ////                                                           ,"Preliminarx"}.ToArray());

                    ////registro.V_HASH = GetSHA1(sf.FileBytes.ToString());
                    ////registro.B_FILE_DECLARACION = sf.FileBytes;
                    db.SaveChanges();

                    //    _oDeclaracion.enviar(SiNo.Checked);
                    QstBox.AskSuccess("Se enviaron correctamente las declaraciones. ¿Desea consultar los acuses?");
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
            Response.Redirect("Observaciones.aspx");
        }

        public void Guardar()
        {
        }

        public void Siguiente()
        {
            btnPrevisualizar_Click(null, null);
        }

        protected void btnPrevisualizar_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;

            if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
            {
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO = true;
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().update();
                _oDeclaracion = oDeclaracion;
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
                    QstBoxEnviar.AskWarning("¿Desea enviar las declaraciones?  <br />Debe tomar en cuenta que una vez enviadas las declaraciones no podrá hacer modificaciones.");
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

        public static string GetSHA1(String texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }

    }
}