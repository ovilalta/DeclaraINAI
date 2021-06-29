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

namespace DeclaraINE.Formas.DeclaracionFiscal
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
            //bool obligado=false;
            //if  (!IsPostBack)
            //{
            //    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            //    string connString = db.Database.Connection.ConnectionString;


            //    using (SqlConnection conn = new SqlConnection(connString))

            //    {
            //        try
            //        {
            //            using (SqlCommand cmd = new SqlCommand("Sp_Recupera_FiscalObligado", conn))
            //            {

            //                cmd.CommandType = CommandType.StoredProcedure;
            //                cmd.Parameters.Add(new SqlParameter("@rfc", _oUsuario.VID_NOMBRE+_oUsuario.VID_FECHA+_oUsuario.VID_HOMOCLAVE));

            //                conn.Open();
            //                obligado = Convert.ToBoolean( cmd.ExecuteScalar()); //Con el executeScalar solo recuperas un solo valor
            //                conn.Close();

            //                if (obligado == true)
            //                {
            //                    si.Checked = true;
            //                    //FileUpload1.Visible = true;
            //                }
            //                else
            //                {
            //                    no.Checked = true;
            //                    //FileUpload1.Visible = false;
            //                }

            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine("Error: " + ex.Message);
            //        }
            //    }


            //}

            //if (si.Checked)
            //{
            //    FileUpload1.Visible = true;
            //}

            //if (no.Checked)
            //{
            //    FileUpload1.Visible = false;
            //}

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

        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //    //if (si.Checked==true)
        //    //{
        //         if (FileUpload1.HasFile )
        //                    {
        //                        string anio = DateTime.Today.Year.ToString();
        //                        string rutaDirectorio = "\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + anio;

        //                        string fileExtension = Path.GetExtension(FileUpload1.FileName);
        //                        string nombreArchivo = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;
        //                        //string ruta = "\\Formas\\DeclaracionFiscal\\pdfFiscales\\" + FileUpload1.FileName;
        //                        string ruta = rutaDirectorio + "\\";  //+ nombreArchivo+fileExtension;
        //                        string path = AppDomain.CurrentDomain.BaseDirectory + ruta;

        //                        if (!Directory.Exists(path))
        //                        {
        //                            Directory.CreateDirectory(path);
        //                        }


        //                        if (fileExtension.ToLower() == ".pdf")
        //                        {
        //                            if (File.Exists(path + nombreArchivo + fileExtension))
        //                            {

        //                                MsgBox.ShowDanger("Cuidado", "El archivo ya existe");
        //                            }
        //                            else
        //                            {

        //                                FileUpload1.SaveAs(Server.MapPath("~" + ruta + nombreArchivo + fileExtension));
        //                                string usuarioObligado = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;
        //                                //if (si.Checked==true)
        //                                //{
        //                                    //Incluir actualizacion a BD tabla USUARIO en el campo OBL_DECLARACION

        //                                    bool obligado = true;
        //                                    ActualizaObligadoFiscal(usuarioObligado, obligado);
        //                                //}
        //                                //else
        //                                //{
        //                                    //Incluir actualizacion a BD tabla USUARIO en el campo OBL_DECLARACION

        //                                //}

        //                                MsgBox.ShowSuccess("Archivo Guardado", "Carga de Acuse Fiscal y guardado de dato obligado fiscal, Exitoso! ");
        //                            }

        //                        }
        //                        else
        //                        {

        //                                MsgBox.ShowDanger("Cuidado", "El acuse debe ser en formato pdf, revisar el archivo a cargar, por favor!");

        //                        }

        //                    }
        //         else
        //         {
        //            MsgBox.ShowDanger("Cuidado", "Por favor, seleccione su acuse de la Declaración Fiscal");               
        //         }
        //    //}
        //    //else
        //    //{
        //    //    string usuarioObligado = _oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE;
        //    //    bool obligado = false;
        //    //    ActualizaObligadoFiscal(usuarioObligado, obligado);
        //    //    MsgBox.ShowSuccess("Datos Guardados", "Guardado de dato obligado fiscal, Exitoso! ");
        //    //}



        //}

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
                QstBox.AskWarning("Bajo protesta de decir verdad, ¿Eres obligado a presentar declaración fiscal ante el SAT?");
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
            //No hagas nada 
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