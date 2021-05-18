using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using System.IO;
using Declara_V2.BLLD;

namespace DeclaraINE.Formas.DeclaracionFiscal
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            //set => SessionAdd("oUsuario", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                string anio = DateTime.Today.Year.ToString();
                string rutaDirectorio = "\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + anio;

                string fileExtension = Path.GetExtension(FileUpload1.FileName);
                string nombreArchivo = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;
                //string ruta = "\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + FileUpload1.FileName;
                string ruta = rutaDirectorio + "\\";  //+ nombreArchivo+fileExtension;
                string path = AppDomain.CurrentDomain.BaseDirectory + ruta;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                if (fileExtension.ToLower() == ".pdf")
                {
                    if (File.Exists(path + nombreArchivo + fileExtension))
                    {
                        //Label1.Text = "El archivo ya existe";
                        //Label1.ForeColor = System.Drawing.Color.Red;
                        MsgBox.ShowDanger("Cuidado", "El archivo ya existe");
                    }
                    else
                    {
                        //FileUpload1.SaveAs(Server.MapPath("~\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + FileUpload1.FileName));
                        //FileUpload1.SaveAs(Server.MapPath("~\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + nombreArchivo +  fileExtension));
                        //FileUpload1.SaveAs(Server.MapPath(path + nombreArchivo + fileExtension));
                        FileUpload1.SaveAs(Server.MapPath("~" + ruta + nombreArchivo + fileExtension));
                        //Label1.Text = "Archivo guardado";
                        //Label1.ForeColor = System.Drawing.Color.Green;
                        MsgBox.ShowSuccess("Archivo Guardado", "Carga de Acuse Fiscal Exitoso");
                    }

                }
                else
                {

                    MsgBox.ShowDanger("Cuidado", "El acuse debe ser en formato pdf, revisar el archivo a cargar, por favor!");
                    //Label1.Text = "El acuse debe ser en formato pdf, revisar el archivo a cargar, por favor!";
                    //Label1.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                MsgBox.ShowDanger("Cuidado", "Por favor, seleccione su acuse de la Declaración Fiscal");
                
                //Label1.Text = "Por favor, seleccione su acuse de la Declaración Fiscal";
                //Label1.ForeColor = System.Drawing.Color.Red;
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

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        
    }
}