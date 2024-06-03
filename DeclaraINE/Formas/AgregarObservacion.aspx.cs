using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using System.IO;
using Declara_V2.BLLD;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using iText.Layout.Element;

namespace DeclaraINAI.Formas
{

    public partial class AgregarObservacion : System.Web.UI.Page
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            //set => SessionAdd("oUsuario", value);
        }

        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            //set => SessionAdd("oDeclaracion", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IconoPDF.Visible = false;
            blld_USUARIO oUsuario = _oUsuario;
            int idDec;
            idDec = Convert.ToInt32(Request.QueryString["idDec"]);
            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, idDec);

            string rutaDirectorio = "/pdfAclaraciones/";
            string fileExtension = Path.GetExtension(SubirArchivoAclara.FileName);
            string nombreArchivo = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE + "_" + idDec;
            string ruta = rutaDirectorio + "\\";
            string path = AppDomain.CurrentDomain.BaseDirectory + ruta;
            string rutaFile = path + nombreArchivo + fileExtension;


            if (File.Exists(path + nombreArchivo + ".pdf") || File.Exists(path + nombreArchivo + ".doc") || File.Exists(path + nombreArchivo + ".docx"))
            {
                IconoPDF.Visible = true;
            }

            if (!IsPostBack)
            {


                //Agregar opcion para recuperar la info del campo de aclaraciones
                MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                string connString = db.Database.Connection.ConnectionString;

                string sql = "SP_Busca_Texto_Aclaracion";

                using (SqlConnection conn = new SqlConnection(connString))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {

                        SqlCommand sqlCommand = new SqlCommand(sql, conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        da.SelectCommand = sqlCommand;

                        da.SelectCommand.Parameters.Add(new SqlParameter("@VID_NOMBRE", oUsuario.VID_NOMBRE));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@VID_FECHA", oUsuario.VID_FECHA));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@VID_HOMOCLAVE", oUsuario.VID_HOMOCLAVE));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@NID_DECLARACION", idDec));

                        conn.Open();

                        txtObservaciones.Text = sqlCommand.ExecuteScalar().ToString();

                        conn.Close();

                    }

                }
            }

        }


        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaDeclaracion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            int idDec;

            idDec = Convert.ToInt32(Request.QueryString["idDec"]);
            string rutaFile = "";
            string ruta = "";
            string nombreArchivo = "";
            string fileExtension = "";
            string path = "";
            string aclaraciones = txtObservaciones.Text;

            if (txtObservaciones.Text != null || txtObservaciones.Text != "")
            {

                try
                {
                    if (SubirArchivoAclara.HasFile)
                    {
                        string rutaDirectorio = "/pdfAclaraciones/";
                        fileExtension = Path.GetExtension(SubirArchivoAclara.FileName);
                        nombreArchivo = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE + "_" + idDec;
                        ruta = rutaDirectorio + "\\";
                        path = AppDomain.CurrentDomain.BaseDirectory + ruta;
                        rutaFile = path + nombreArchivo + fileExtension;
                        if (File.Exists(path + nombreArchivo + fileExtension))
                        {

                            msgBox.ShowDanger("Cuidado", "El archivo ya existe");
                            return;
                        }
                        else
                        {
                            SubirArchivoAclara.SaveAs(Server.MapPath("~" + ruta + nombreArchivo + fileExtension));
                        }
                    }
                    else
                    {

                        string rutaDirectorio = "/pdfAclaraciones/";
                        fileExtension = Path.GetExtension(SubirArchivoAclara.FileName);
                        nombreArchivo = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE + "_" + idDec;
                        ruta = rutaDirectorio + "\\";
                        path = AppDomain.CurrentDomain.BaseDirectory + ruta;
                        rutaFile = path + nombreArchivo + fileExtension;


                        if (File.Exists(path + nombreArchivo + ".pdf"))
                        {
                            rutaFile = path + nombreArchivo + ".pdf";

                        }

                        if (File.Exists(path + nombreArchivo + ".doc"))
                        {
                            rutaFile = path + nombreArchivo + ".doc";
                        }
                        if (File.Exists(path + nombreArchivo + ".docx"))
                        {
                            rutaFile = path + nombreArchivo + ".docx";
                        }
                    }

                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    string connString = db.Database.Connection.ConnectionString;

                    string sql = "SP_Inserta_Texto_Aclaracion";

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {

                            SqlCommand sqlCommand = new SqlCommand(sql, conn)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            da.SelectCommand = sqlCommand;

                            da.SelectCommand.Parameters.Add(new SqlParameter("@VID_NOMBRE", oUsuario.VID_NOMBRE));
                            da.SelectCommand.Parameters.Add(new SqlParameter("@VID_FECHA", oUsuario.VID_FECHA));
                            da.SelectCommand.Parameters.Add(new SqlParameter("@VID_HOMOCLAVE", oUsuario.VID_HOMOCLAVE));
                            da.SelectCommand.Parameters.Add(new SqlParameter("@NID_DECLARACION", idDec));
                            da.SelectCommand.Parameters.Add(new SqlParameter("@TEXTO_ACLARA", aclaraciones));
                            da.SelectCommand.Parameters.Add(new SqlParameter("@RUTA_FILE", rutaFile));


                            int rowafected = da.SelectCommand.ExecuteNonQuery();
                            conn.Close();

                        }

                    }
                    msgBox.ShowSuccess("Se agregó de manera correcta la aclaración");
                }
                catch (Exception ex)
                {

                    msgBox.ShowDanger("Falló el guardado de la aclaración y su archivo");
                }
            }
            else
            {
                msgBox.ShowDanger("El campo de aclaraciones no puede estar vacío al guardar, si desea cancelar la aclaración dé clic en el botón 'Regresar'.");
            }




        }



    }
}