using Declara_V2.BLLD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace DeclaraINAI.Formas.Administrador
{
    public partial class AdministradoresBitacora : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        string connString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;

            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            connString = db.Database.Connection.ConnectionString;

            if (!IsPostBack)
            {
                // Ruta del archivo
                string rutaArchivo = Server.MapPath("~/Formas/Administrador/AdministradoresBitacora.txt");
                
                List<DatoArchivo> datos = LeerArchivo(rutaArchivo);

                gvExcelData.DataSource = datos;
                gvExcelData.DataBind();

            }
        }

        private List<DatoArchivo> LeerArchivo(string ruta)
        {
            List<DatoArchivo> lineas = new List<DatoArchivo>();

            if (File.Exists(ruta))
            {
                foreach (string linea in File.ReadAllLines(ruta))
                {
                    lineas.Add(new DatoArchivo { Rfc = linea });
                }
            }
            else
            {
                lineas.Add(new DatoArchivo { Rfc = "El archivo no se encontró." });
            }

            return lineas;
        }


        public class DatoArchivo
        {
            public string Rfc { get; set; }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevoDato = txtNuevoPermiso.Text.Trim();

            if (!string.IsNullOrEmpty(nuevoDato))
            {
                if (nuevoDato.Length==13)
                {
                    // Ruta del archivo
                    string rutaArchivo = Server.MapPath("~/Formas/Administrador/AdministradoresBitacora.txt");

                    // Escribir el nuevo dato al archivo
                    File.AppendAllText(rutaArchivo, nuevoDato.ToUpper() + Environment.NewLine);

                    // Limpiar el campo de texto
                    txtNuevoPermiso.Text = "";

                    //Registra la búsqueda en bitácora
                    BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                        , "Agregar admin bitácora", "Se agregó como admin bitácora a: " + nuevoDato);

                    // Recargar los datos en el GridView
                    CargarDatos();
                }
                else
                {
                    // Manejar casos donde el campo esté vacío (opcional)
                    Response.Write("<script>alert('Por favor, ingrese un RFC válido de 13 caracteres.');</script>");
                }
                
            }
            else
            {
                // Manejar casos donde el campo esté vacío (opcional)
                Response.Write("<script>alert('Por favor, ingrese un RFC válido.');</script>");
            }
        }

        private void CargarDatos()
        {
            string rutaArchivo = Server.MapPath("~/Formas/Administrador/AdministradoresBitacora.txt");
            List<DatoArchivo> datos = LeerArchivo(rutaArchivo);

            gvExcelData.DataSource = datos;
            gvExcelData.DataBind();
        }

        protected void gvExcelData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                // Obtener el índice del registro a eliminar
                int indice = Convert.ToInt32(e.CommandArgument);

                // Ruta del archivo
                string rutaArchivo = Server.MapPath("~/Formas/Administrador/AdministradoresBitacora.txt");

                // Leer todas las líneas del archivo
                List<string> lineas = new List<string>(File.ReadAllLines(rutaArchivo));

                if (indice >= 0 && indice < lineas.Count)
                {
                    string valorEliminado = lineas[indice];
                    // Eliminar la línea correspondiente
                    lineas.RemoveAt(indice);

                    // Sobrescribir el archivo con las líneas restantes
                    File.WriteAllLines(rutaArchivo, lineas);

                    //Registra la búsqueda en bitácora
                    BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                        , "Eliminar admin bitácora", "Se eliminó como admin bitácora a: " + valorEliminado);
                    // Recargar los datos en el GridView
                    //CargarDatos();
                }
                CargarDatos();
            }
        }
    }
}

