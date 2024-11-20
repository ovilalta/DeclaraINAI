using Declara_V2.BLLD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Linq.Dynamic;
using System.Linq;
using static Spire.Pdf.General.Render.Font.OpenTypeFile.Table_VDMX;
using System.Collections.Generic;



namespace DeclaraINAI.Formas.Administrador
{
    public partial class ConsultaApartadosDeclaracion : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        //variables globales
        MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
        List<MODELDeclara_V2.DECLARACION> listaSecciones = new List<MODELDeclara_V2.DECLARACION>();
        string vid_nombre = "";
        string vid_fecha = "";
        string vid_homo = "";
        //
        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;

            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();


            if (!IsPostBack)
            {

                BindGrid();
                // Muestra el Panel solo si lblNombre no está vacío
                pnlSecciones.Visible = !string.IsNullOrEmpty(lblNombre.Text);
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string rfcBusqueda = txtRFC.Text.Trim().ToUpper();

            if (!string.IsNullOrEmpty(rfcBusqueda))
            {
                if (rfcBusqueda.Length == 13)
                {
                    vid_nombre = rfcBusqueda.Substring(0, 4);
                    vid_fecha = rfcBusqueda.Substring(4, 6);
                    vid_homo = rfcBusqueda.Substring(10, 3);

                    listaSecciones = db.DECLARACION
                        .Where(d => d.VID_NOMBRE.Equals(vid_nombre)
                        && d.VID_FECHA.Equals(vid_fecha)
                        && d.VID_HOMOCLAVE.Equals(vid_homo)
                        && d.NID_ESTADO == 1)
                        .ToList();

                    if (listaSecciones.Count > 0)
                    {
                        lblNombre.Text = listaSecciones[0].USUARIO.V_NOMBRE + " " + listaSecciones[0].USUARIO.V_PRIMER_A + " " + listaSecciones[0].USUARIO.V_SEGUNDO_A;
                        pnlSecciones.Visible = true;


                        gvSeccionesData.DataSource = listaSecciones[0].DECLARACION_APARTADO;
                        gvSeccionesData.DataBind();
                    }
                    else
                    {
                        //Response.Write("<script>alert('Por favor, ingrese un RFC que sí exista!.');</script>");
                        msgBox.ShowDanger("El RFC que indica no tiene una declaración abierta para editar sus secciones o apartados.");
                    }
                }
                else
                {
                    // Manejar casos donde el campo esté vacío (opcional)
                    msgBox.ShowDanger("Por favor, ingrese un RFC válido de 13 caracteres.");
                   // Response.Write("<script>alert('Por favor, ingrese un RFC válido de 13 caracteres.');</script>");
                }
            }
            else
            {
                // Manejar casos donde el campo esté vacío (opcional)
                msgBox.ShowDanger("Por favor, ingrese un RFC válido.");
                //Response.Write("<script>alert('Por favor, ingrese un RFC válido.');</script>");
            }
        }

        protected void gvSeccionesData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Establece la fila en modo edición
            gvSeccionesData.EditIndex = e.NewEditIndex;
            BindGrid(); // Vuelve a enlazar el GridView
        }

        protected void gvSeccionesData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancela el modo edición
            gvSeccionesData.EditIndex = -1;
            BindGrid(); // Vuelve a enlazar el GridView
        }

        protected void gvSeccionesData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtén los valores únicos desde DataKeys
            string vid_nombre = gvSeccionesData.DataKeys[e.RowIndex].Values["VID_NOMBRE"].ToString();
            string vid_fecha = gvSeccionesData.DataKeys[e.RowIndex].Values["VID_FECHA"].ToString();
            string vid_homo = gvSeccionesData.DataKeys[e.RowIndex].Values["VID_HOMOCLAVE"].ToString();
            string nid_declaracionString = gvSeccionesData.DataKeys[e.RowIndex].Values["NID_DECLARACION"].ToString();
            string nid_ApartadoString = gvSeccionesData.DataKeys[e.RowIndex].Values["NID_APARTADO"].ToString();
            int nid_declaracion = Convert.ToInt32(nid_declaracionString);
            int nid_Apartado = Convert.ToInt32(nid_ApartadoString);

            // Obtén la fila que está siendo editada
            GridViewRow row = gvSeccionesData.Rows[e.RowIndex];

            // Obtén los valores actualizados

            CheckBox chkActivoEdit = (CheckBox)row.FindControl("chkActivoEdit");
            bool nuevoValorActivo = chkActivoEdit.Checked;

            // Actualiza en la base de datos
            using (var db = new MODELDeclara_V2.cnxDeclara())
            {
                var registro = db.DECLARACION_APARTADO.FirstOrDefault(x =>
                    x.VID_NOMBRE == vid_nombre &&
                    x.VID_FECHA == vid_fecha &&
                    x.VID_HOMOCLAVE == vid_homo &&
                    x.NID_DECLARACION == nid_declaracion
                    && x.NID_APARTADO == nid_Apartado);

                if (registro != null)
                {
                    registro.L_ESTADO = nuevoValorActivo; // Actualiza el valor booleano
                    db.SaveChanges(); // Guarda los cambios
                    msgBox.ShowSuccess("Se editó de manera correcta!.");
                }
            }

            // Sal del modo edición y vuelve a enlazar el GridView
            gvSeccionesData.EditIndex = -1;
            BindGrid(); // Método que actualiza los datos del GridView
        }

        protected void BindGrid()
        {
            string rfcBusqueda = txtRFC.Text.Trim().ToUpper();
            if (!string.IsNullOrEmpty(rfcBusqueda))
            {
                vid_nombre = rfcBusqueda.Substring(0, 4);
                vid_fecha = rfcBusqueda.Substring(4, 6);
                vid_homo = rfcBusqueda.Substring(10, 3);
            }
            listaSecciones = db.DECLARACION
                        .Where(d => d.VID_NOMBRE.Equals(vid_nombre)
                        && d.VID_FECHA.Equals(vid_fecha)
                        && d.VID_HOMOCLAVE.Equals(vid_homo)
                        && d.NID_ESTADO == 1)
                        .ToList();

            if (listaSecciones.Count > 0)
            {
                gvSeccionesData.DataSource = listaSecciones[0].DECLARACION_APARTADO;
                gvSeccionesData.DataBind();
            }
        }

    }
}

