using Declara_V2.BLLD;
using System;
using System.IO;
using System.Web;
using System.Linq;
using DeclaraINAI.file;
using System.Collections.Generic;
using Declara_V2.MODELextended;
using Declara_V2;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Web.Configuration;
using System.Web.Services;
using System.Security.Permissions;
using iText.StyledXmlParser.Css.Selector.Item;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;

namespace DeclaraINAI.Formas.Administrador
{
    public partial class ConsultaCatalogoPuestos : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        private void PopulateDropDownList()
        {
            blld__l_CAT_PRIMER_NIVEL oPrimerNivel = new blld__l_CAT_PRIMER_NIVEL();
            oPrimerNivel.OrderByCriterios.Add(new Declara_V2.Order(CAT_PRIMER_NIVEL.Properties.V_PRIMER_NIVEL));
            oPrimerNivel.select();

            cmbVID_PRIMER_NIVEL.DataSource = oPrimerNivel.lista_CAT_PRIMER_NIVEL.OrderBy(x => x.V_PRIMER_NIVEL);
            cmbVID_PRIMER_NIVEL.DataTextField = "V_PRIMER_NIVEL"; // Ajuste aquí: Debe ser el nombre de la propiedad de la clase
            cmbVID_PRIMER_NIVEL.DataValueField = "VID_PRIMER_NIVEL"; // Ajuste aquí: Debe ser el nombre de la propiedad de la clase
            cmbVID_PRIMER_NIVEL.DataBind();

            // Opcional: Añadir un ítem por defecto al inicio de la lista
            cmbVID_PRIMER_NIVEL.Items.Insert(0, new ListItem("---- Seleccione una Unidad Administrativa ----", "0"));
            cmbVID_PRIMER_NIVEL.Items.Insert(41, new ListItem("Eventuales", "EV-"));
            cmbVID_PRIMER_NIVEL.Items.Insert(42, new ListItem("Honorarios", "CH-"));
        }

       protected void cmbVID_PRIMER_NIVEL_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVID_PRIMER_NIVEL_TextChanged(cmbVID_PRIMER_NIVEL, null);
        }

        protected void txtVID_PRIMER_NIVEL_TextChanged(object sender, EventArgs e)
        {
            // Aquí manejas el cambio del texto, por ejemplo:
            string selectedValue = cmbVID_PRIMER_NIVEL.SelectedValue;
            // Lógica adicional basada en el valor seleccionado
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            string VID_RFC = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE;

            if (!IsPostBack)
            {
                Page.Title = "Consulta catálogo de puestos";
                string line;
                bool excep = false;
                var buildDir = HttpRuntime.AppDomainAppPath;
                var filePath = buildDir + @"\Formas\Administrador\Administradores.txt";
                StreamReader file = new StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    if (VID_RFC.Equals(line))
                    {
                        excep = true;
                    }
                }
                file.Close();
                if (excep == false)
                {
                    Response.Redirect("..\\Index.aspx");
                }
                PopulateDropDownList();
            }


        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            if (cmbVID_PRIMER_NIVEL.SelectedValue != "0")
            {
                blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                oPuesto.select();

                //listaCatalogoPuestos = oPuesto.lista_CAT_PUESTO.ToList();
                //grdDP.DataSource = listaCatalogoPuestos.OrderBy(p => p.VID_PUESTO).ThenBy(p => p.V_PUESTO).ToArray();
                grdDP.DataSource = oPuesto.lista_CAT_PUESTO
                    .Where(p => p.VID_PUESTO.Substring(0, 3) == cmbVID_PRIMER_NIVEL.SelectedValue.Substring(0, 3))
                    .OrderBy(p => p.VID_PUESTO)
                    .ThenBy(p => p.V_PUESTO)
                    .ToArray();
                grdDP.DataBind();
            }

            //Registra la búsqueda en bitácora
            BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                , "Consulta catálogo de puestos", "Se consulta el catálogo de puestos de: " + cmbVID_PRIMER_NIVEL.SelectedItem.Text);
        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void grdDP_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        protected void grdDP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int nidPuesto = 0;
            string clavePuesto = txtVidPuesto.Text;
            string nivelPuesto = (txtVidNivel.Text).ToUpper();
            string descripcionPuesto = txtVPuesto.Text;
            string NombreUa = "";
            bool obligado = false;
            if (rbActivo.Checked) obligado = true;
            else if (rbInactivo.Checked) obligado = false;

            string inicioUA = clavePuesto.Substring(0, 3);

            blld__l_CAT_PUESTO oCatPuesto = new blld__l_CAT_PUESTO();
            oCatPuesto.select();

            nidPuesto = oCatPuesto.lista_CAT_PUESTO.OrderByDescending(p => p.NID_PUESTO).Select(p=>p.NID_PUESTO).First() + 1;
            NombreUa = oCatPuesto.lista_CAT_PUESTO.Where(p=>p.VID_PUESTO.Substring(0,3) == inicioUA).Select(p=>p.NOMBRE_UA).First();

            string entityConnectionString = ConfigurationManager.ConnectionStrings["cnxDeclara"].ConnectionString;
            // Crear un constructor de cadena de conexión de Entity Framework
            var entityBuilder = new EntityConnectionStringBuilder(entityConnectionString);
            // Obtener la cadena de conexión específica de SQL Server de la cadena de conexión de Entity Framework
            string providerConnectionString = entityBuilder.ProviderConnectionString;
            using (SqlConnection conn = new SqlConnection(providerConnectionString))
            {
                string query = "INSERT INTO CAT_PUESTO (NID_PUESTO, VID_PUESTO, VID_NIVEL, V_PUESTO, L_ACTIVO, L_OBLIGADO, NOMBRE_UA)" +
                    " VALUES (@NID_PUESTO, @VID_PUESTO, @VID_NIVEL, @V_PUESTO, @L_ACTIVO, @L_OBLIGADO, @NOMBRE_UA)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NID_PUESTO", nidPuesto);
                    cmd.Parameters.AddWithValue("@VID_PUESTO", clavePuesto);
                    cmd.Parameters.AddWithValue("@VID_NIVEL", nivelPuesto);
                    cmd.Parameters.AddWithValue("@V_PUESTO", descripcionPuesto);
                    cmd.Parameters.AddWithValue("@L_ACTIVO", true);
                    cmd.Parameters.AddWithValue("@L_OBLIGADO", obligado);
                    cmd.Parameters.AddWithValue("@NOMBRE_UA", NombreUa);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // Clear the textboxes
            txtVidPuesto.Text = "";
            txtVidNivel.Text = "";
            txtVPuesto.Text = "";

            //Registra la búsqueda en bitácora
            BitacoraAdmin.RegistraBitacoraAdmin(_oUsuario.VID_NOMBRE + _oUsuario.VID_FECHA + _oUsuario.VID_HOMOCLAVE
                , "Inserta un nuevo puesto en el catálogo", "Se agregó el puesto con clave: " + clavePuesto + " nivel de puesto: " + nivelPuesto + " con descripción: " + descripcionPuesto + " en la UA: " + NombreUa);

            //Close the modal
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal').modal('hide');", true);
        }
    }
}