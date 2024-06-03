using Declara_V2.BLLD;
using System;
using System.IO;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Spire.Xls;
using System.Windows.Forms;
using System.Linq;
using DeclaraINAI.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using AlanWebControls;

namespace DeclaraINAI.Formas.DeclaracionFiscal
{
    //System.Web.UI.Page
    public partial class WebForm1 : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }

        protected void FiscalObligado_CheckedChanged(Object sender, EventArgs e)
        {
            //if (si.Checked)
            //{
            //    FileUpload1.Visible = true;
            //}

            //if (no.Checked)
            //{
            //    FileUpload1.Visible = false;
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //Poner logica de previsualizacion

            //string FileName = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;
            string FileName = _oUsuario.V_NOMBRE_COMPLETO.Replace(" ","");

            string anio = DateTime.Today.Year.ToString();
            string rutaBase = HttpContext.Current.Server.MapPath("~") + "\\Formas\\DeclaracionFiscal\\";
            string rutaDirectorio = "pdfFiscales\\" + anio;

            string path = rutaDirectorio + "\\" + FileName + ".pdf";
            
            bool existe = File.Exists(rutaBase+path);

            if (existe)
            {
                pdfFiscal.Attributes["src"] = rutaDirectorio + "\\" + FileName + ".pdf";
            }


        }

        protected void ActualizaObligadoFiscal(string usuarioObligado, bool obligado)
        {
            string VID_NOMBRE = usuarioObligado.Substring(0, 4);
            string VID_FECHA = usuarioObligado.Substring(4, 6);
            string VID_HOMOCLAVE = usuarioObligado.Substring(10, 3);
            blld_USUARIO oUsuario = new blld_USUARIO(VID_NOMBRE
                   , VID_FECHA
                   , VID_HOMOCLAVE);
            try
            {
                oUsuario.ObligadoFiscalCambio(oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE, obligado);
                //MsgBox.ShowSuccess("Se ha guardado el dato de obligación fiscal con éxito.");
            }
            catch (Exception ex)
            {
                //MsgBox.ShowDanger(ex.Message);
            }
        }



        protected void btnVerTutorial_Click(object sender, EventArgs e)
        {
            mdlTutorial.Show(true);
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mdlTutorial.Hide();
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string anio = DateTime.Today.Year.ToString();
                string rutaDirectorio = "\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + anio;

                string fileExtension = Path.GetExtension(FileUpload1.FileName);
                // string nombreArchivo = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;
                string nombreArchivo = _oUsuario.V_NOMBRE_COMPLETO.Replace(" ", "");
                string ruta = rutaDirectorio + "\\";
                string path = AppDomain.CurrentDomain.BaseDirectory + ruta;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                if (fileExtension.ToLower() == ".pdf")
                {
                    if (File.Exists(path + nombreArchivo + fileExtension))
                    {

                        MsgBox.ShowDanger("Cuidado", "El archivo ya existe");
                    }
                    else
                    {

                        FileUpload1.SaveAs(Server.MapPath("~" + ruta + nombreArchivo + fileExtension));
                        string usuarioObligado = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;


                        bool obligado = true;
                        ActualizaObligadoFiscal(usuarioObligado, obligado);

                        marcaApartado(22);
                        //blld_DECLARACION oDeclaracion = _oDeclaracion;

                        MsgBox.ShowSuccess("Archivo Guardado", "Carga de Acuse Fiscal  guardado con éxito! ");
                        Response.Redirect("../DeclaracionModificacion/Envio.aspx");
                    }

                }
                else
                {

                    MsgBox.ShowDanger("Cuidado", "El acuse debe ser en formato pdf, revisar el archivo a cargar, por favor!");

                }

            }
            else
            {
                //Meter condiciones para validar si existe el archivo pdf
                string anio = DateTime.Today.Year.ToString();
                string rutaDirectorio = "\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + anio;


                //string nombreArchivo = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;
                string nombreArchivo = _oUsuario.V_NOMBRE_COMPLETO.Replace(" ", "");

                string ruta = rutaDirectorio + "\\";
                string path = AppDomain.CurrentDomain.BaseDirectory + ruta;


                if (File.Exists(path + nombreArchivo + ".pdf"))
                {
                    Response.Redirect("../DeclaracionModificacion/Envio.aspx");
                }
                else
                {
                    QstBox.AskWarning("Bajo protesta de decir verdad, ¿Eres obligado a presentar declaración fiscal ante el SAT?");
                }

            }

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

            Response.Redirect("../DeclaracionModificacion/Observaciones.aspx");

        }

        private void marcaApartado(int NID_APARTADO)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO.HasValue)
            {
                if (!oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO.Value)
                {
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO = true;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().update();
                }
            }
            else
            {
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().L_ESTADO = true;
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == NID_APARTADO).First().update();
            }
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {

        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            string usuarioObligado = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;
            bool obligado = false;
            ActualizaObligadoFiscal(usuarioObligado, obligado);
            marcaApartado(22);
            //blld_DECLARACION oDeclaracion = _oDeclaracion;
            Response.Redirect("../DeclaracionModificacion/Envio.aspx");
        }


    }
}