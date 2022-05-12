using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using System.IO;
using Declara_V2.BLLD;
using System.Data.SqlClient;
using System.Data;

namespace DeclaraINE.Formas.declaracionFiscalSustituirPdf
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


        protected void Page_Load(object sender, EventArgs e)
        {
            //Poner logica de previsualizacion

            string FileName = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;

            string anio = DateTime.Today.Year.ToString();
            string rutaDirectorio = "\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + anio;

            string fileExtension = Path.GetExtension(FileUpload1.FileName);
            

            string ruta = rutaDirectorio + "\\";
            string path = AppDomain.CurrentDomain.BaseDirectory + ruta;


            //pdfFiscal.Attributes["src"] = path + FileName + ".pdf";
            //pdfembed.Attributes["src"] = path + FileName + ".pdf";

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
                string nombreArchivo = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;

                string ruta = rutaDirectorio + "\\";
                string path = AppDomain.CurrentDomain.BaseDirectory + ruta;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                if (fileExtension.ToLower() == ".pdf")
                {
                    FileUpload1.SaveAs(Server.MapPath("~" + ruta + nombreArchivo + fileExtension));
                    //string usuarioObligado = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;

                    QstBox.AskSuccess("Proceso Satisfactorio", "Su acuse fiscal se sustituyó de manera correcta!");
                    EliminaRFC(nombreArchivo);
                    //MsgBox.ShowSuccess("Proceso Satisfactorio", "Su acuse fiscal se sustituyó de manera correcta!");
                }
                else
                {

                    MsgBox.ShowDanger("Cuidado", "El acuse debe ser en formato pdf, revisar el archivo a cargar, por favor!");

                }

            }

        }


        protected void QstBox_Yes(object Sender, EventArgs e)
        {


            Response.Redirect("../Index.aspx");
        }

        protected void QstBox_No(object Sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        private void EliminaRFC(string RFC)
        {



            #region Logica quitar Permisos para visualizar boton acuse fiscal

            var buildDirFiscal = HttpRuntime.AppDomainAppPath;
            var filePathFiscal = buildDirFiscal + @"\bin\CargaAcuseFiscalExcepcion.txt";
            var fileTemp = buildDirFiscal + @"\bin\fileTemp.txt";

            using (StreamWriter fileWrite = new StreamWriter(fileTemp))
            {
                using (StreamReader fileFiscal = new StreamReader(filePathFiscal))
                {
                    string lineFiscal;

                    while ((lineFiscal = fileFiscal.ReadLine()) != null)
                    {

                        if (RFC != lineFiscal)
                        {
                            fileWrite.WriteLine(lineFiscal);
                        }
                    }
                    fileFiscal.Close();
                }
            }

            //aqui se renombrea el archivo temporal
            File.Delete(filePathFiscal);
            File.Move(fileTemp, filePathFiscal);

            #endregion

        }


        //protected void btnAtras_Click(object sender, EventArgs e)
        //{
        //    //Atras regresara a la pantalla principal
        //    Response.Redirect("../Index.aspx");

        //}



    }
}