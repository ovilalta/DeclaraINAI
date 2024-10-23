using Declara_V2.BLLD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;



namespace DeclaraINAI.Formas.Administrador
{
    public partial class VisualizarVencimientosDeclaraciones : Pagina
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
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                DateTime fechaFiltrar = DateTime.Today.AddDays(-90);

                // Consulta para obtener los datos
                string query = "SELECT * FROM ReporteVencimientoDeclaraciones WHERE FechaAplicacion > @fechaFiltrar";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fechaFiltrar", fechaFiltrar);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Enlazar los datos al GridView
                    gvExcelData.DataSource = dt;
                    gvExcelData.DataBind();
                }
            }
        }

        protected void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            // Obtenemos el CheckBox que disparó el evento
            CheckBox chkActivo = (CheckBox)sender;

            // Obtenemos el ID de la fila en la que se hizo clic
            GridViewRow row = (GridViewRow)chkActivo.NamingContainer;
            int id = Convert.ToInt32(gvExcelData.DataKeys[row.RowIndex].Value);

            // El valor del CheckBox
            bool isChecked = chkActivo.Checked;

            // Actualizamos la base de datos con el nuevo estado del CheckBox
            UpdateActivo(id, isChecked);

            // Volver a enlazar los datos después de actualizar la base de datos
            //CargarDatos();
            BindGridView();
        }       

        private void UpdateActivo(int id, bool activo)
        {
            // Aquí implementas la lógica para actualizar la base de datos
            // Conexión a la base de datos y consulta de actualización
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            connString = db.Database.Connection.ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "UPDATE ReporteVencimientoDeclaraciones SET EstatusCumplimiento = @Activo WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Activo", activo);
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        protected void gvExcelData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el valor del campo "Activo" (true/false)
                bool isChecked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "EstatusCumplimiento"));

                // Si está marcado, poner el texto en verde
                if (isChecked)
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
                // Si no está marcado, poner el texto en rojo
                else
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void gvExcelData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Poner el GridView en modo de edición para la fila seleccionada
            gvExcelData.EditIndex = e.NewEditIndex;
            BindGridView(); // Método para volver a enlazar los datos
        }

        protected void gvExcelData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtener los valores actualizados de la fila en edición
            int id = Convert.ToInt32(gvExcelData.DataKeys[e.RowIndex].Value.ToString());
            string correoPersonal = ((TextBox)gvExcelData.Rows[e.RowIndex].Cells[8].Controls[0]).Text;
            string celularPersonal = ((TextBox)gvExcelData.Rows[e.RowIndex].Cells[9].Controls[0]).Text;
            string observaciones = ((TextBox)gvExcelData.Rows[e.RowIndex].Cells[10].Controls[0]).Text;


            // Lógica para actualizar en la base de datos
            ActualizarRegistroEnBaseDeDatos(id, correoPersonal, celularPersonal, observaciones);

            // Salir del modo de edición y volver a enlazar los datos
            gvExcelData.EditIndex = -1;
            BindGridView();
        }

        protected void gvExcelData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Salir del modo de edición sin realizar cambios
            gvExcelData.EditIndex = -1;
            BindGridView();
        }

        private void ActualizarRegistroEnBaseDeDatos(int id, string correoPersonal, string celularPersonal , string observaciones)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            connString = db.Database.Connection.ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "UPDATE ReporteVencimientoDeclaraciones SET CorreoPersonal = @correoPersonal, CelularPersonal = @celularPersonal, Observaciones = @observaciones WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@correoPersonal", correoPersonal);
                    cmd.Parameters.AddWithValue("@celularPersonal", celularPersonal);
                    cmd.Parameters.AddWithValue("@observaciones", observaciones);
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

    }
}

