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
using DeclaraINAI.file;
using System.Collections.Generic;
using System.Security.Cryptography;
using AlanWebControls;




namespace DeclaraINAI.Formas.Administrador
{
    public partial class CargaDeclaraciones : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //blld_USUARIO oUsuario = _oUsuario;
            //string VID_RFC = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE;
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //DirectoryInfo di = new DirectoryInfo(path + "Formas\\DeclaracionFiscal\\pdfFiscales\\");
            //DirectoryInfo[] dirInfos = di.GetDirectories("*.*");

            //foreach (var i in dirInfos)
            //{
            //    //ddlLista.Items.Add(i.Name);
            //}

            //if (!IsPostBack)
            //{
            //    Page.Title = "DescargaAcusesFiscales";
            //    string line;
            //    bool excep = false;
            //    var buildDir = HttpRuntime.AppDomainAppPath;
            //    var filePath = buildDir + @"\Formas\Administrador\Administradores.txt";
                
            //    StreamReader file = new StreamReader(filePath);
            //    while ((line = file.ReadLine()) != null)
            //    {
            //        if (VID_RFC.Equals(line))
            //        {
            //            excep = true;
            //        }
            //    }
            //    file.Close();
            //    if (excep == false)
            //    {
            //        Response.Redirect("..\\Index.aspx");
            //    }
            //}
        }
        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void uploadFile_Click(object sender, EventArgs e)
        {
            if (UploadImages.HasFiles)
            {
                try
                {

                    int i = 0;
                    foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                    {
                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/versionesPublicas/"), uploadedFile.FileName));
                       
                        i ++;
                    }
                        listofuploadedfiles.Text += i.ToString() + " Archivos cargados con éxito";
                }
                catch (Exception ex)
                {

                    //ex.Message();
                }
            }
        }



    }
 }

