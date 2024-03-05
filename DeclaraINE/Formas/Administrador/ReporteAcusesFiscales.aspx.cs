using Declara_V2.BLLD;
using System;
using System.IO;
using System.IO.Compression ;
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
using DeclaraINE.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using AlanWebControls;



namespace DeclaraINE.Formas.Administrador
{
    public partial class ReporteAcusesFiscales : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            blld_USUARIO oUsuario = _oUsuario;
            string VID_RFC = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(path + "Formas\\DeclaracionFiscal\\pdfFiscales\\");
            DirectoryInfo[] dirInfos = di.GetDirectories("*.*");

            foreach (var i in dirInfos)
            {
                ddlLista.Items.Add(i.Name);
            }

            if (!IsPostBack)
            {
                Page.Title = "ReporteAcusesFiscales";
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
            }
        }
        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

       

        
        protected void btnDescargar_Actualizar(object sender, EventArgs e)
        {
            int contadorPDF = 0;
            string anio = ddlLista.SelectedValue;
            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "Formas\\DeclaracionFiscal\\pdfFiscales\\" + ddlLista.SelectedValue;   //Asigna ruta donde se guardaran los archivos pdf

            string[] archivos = Directory.GetFiles(rutaDirectorio);
            foreach (var item in archivos)
            {
                if (Path.GetExtension(item).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    contadorPDF ++;
                }
            }

            TotalAcusesFiscales.Text = "El total de acuses fiscales en el año: " + anio + " es: " + contadorPDF.ToString();
         }
     
    }
 }

