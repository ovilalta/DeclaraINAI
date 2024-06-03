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
    public partial class CargaAcusesFiscales : Pagina
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
                //ddlLista.Items.Add(i.Name);
            }

            if (!IsPostBack)
            {
                Page.Title = "DescargaAcusesFiscales";
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

       

        //public static void DeleteFolder(string fullPath)
        //{
        //    if (System.IO.Directory.Exists(fullPath))
        //    {
        //        System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(fullPath)
        //        {
        //            Attributes = System.IO.FileAttributes.Normal
        //        };
        //        foreach (var info in directory.GetFileSystemInfos("*", System.IO.SearchOption.AllDirectories))
        //        {
        //            System.IO.FileInfo fInfo = info as System.IO.FileInfo;
        //            if (fInfo != null) info.Attributes = System.IO.FileAttributes.Normal;
        //        }
        //        System.Threading.Thread.Sleep(100);
        //        directory.Delete(true);
        //    }
        //}
        //public static void CreateEmptyDirectory(string fullPath)
        //{
        //    if (!System.IO.Directory.Exists(fullPath))
        //    {
        //        System.IO.Directory.CreateDirectory(fullPath);
        //    }
        //}

        protected void uploadFile_Click(object sender, EventArgs e)
        {
            if (UploadImages.HasFiles)
            {
                try
                {

                    int i = 0;
                    foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                    {
                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/versionesFiscales/"), uploadedFile.FileName));
                        //listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
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
        //protected void btnDescargar_Actualizar(object sender, EventArgs e)
        //{

        //    //string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "Formas\\DeclaracionFiscal\\pdfFiscales\\" + ddlLista.SelectedValue;   //Asigna ruta donde se guardaran los archivos pdf
        //    string startPath = AppDomain.CurrentDomain.BaseDirectory + "Formas\\zip2";
        //    //string zipPath = AppDomain.CurrentDomain.BaseDirectory + "Formas\\zip2" + "\\AcusesFiscales" + ddlLista.SelectedValue + ".zip"; //URL for your Zip file

        //        DeleteFolder(startPath);  //Limpia el folder para asegurar que no tenga archivos
        //        CreateEmptyDirectory(startPath); //Crea el folder de nueva cuenta para ser utilizado
        //        //ZipFile.CreateFromDirectory(rutaDirectorio, zipPath, CompressionLevel.Optimal, true);
                

        //                    //HttpContext.Current.Response.ClearContent();
        //                    //HttpContext.Current.Response.Clear();
        //                    //HttpContext.Current.Response.ContentType = "application/zip"; // sf.MimeType;
        //                    ////HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=AcusesFiscales"+ ddlLista.SelectedValue+ ".zip");
        //                    ////HttpContext.Current.Response.WriteFile(zipPath);
        //                    //HttpContext.Current.Response.Flush();
        //                    ////System.IO.File.Delete(zipPath);
        //                    //HttpContext.Current.Response.End();
        // }
     
    }
 }

