using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using DeclaraINEAdmin.file;

namespace DeclaraINEAdmin.Formas
{
    public partial class Transparencia : Pagina
    {
        private static List<Int32> Trimestre1 => new List<int> { 1, 2, 3 };
        private static List<Int32> Trimestre2 => new List<int> { 4, 5, 6 };
        private static List<Int32> Trimestre3 => new List<int> { 7, 8, 9 };
        private static List<Int32> Trimestre4 => new List<int> { 10, 11, 12 };
        private static List<List<Int32>> Trimestres => new List<List<int>> { Trimestre1, Trimestre2, Trimestre3, Trimestre4 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("Transparencia.aspx");

                List<Int32> Agni = new List<int>();
                for (int x = 2018; x <= DateTime.Today.Year; x++)
                    Agni.Add(x);
                cmbAgno.DataSource = Agni;
                cmbAgno.DataBind();

                if (Trimestre1.Contains(DateTime.Today.Month))
                {
                    cmbAgno.SelectedValue = (DateTime.Today.Year - 1).ToString();
                    cmbTrimestre.SelectedIndex = 3;
                }
                else if (Trimestre2.Contains(DateTime.Today.Month))
                {
                    cmbAgno.SelectedValue = (DateTime.Today.Year).ToString();
                    cmbTrimestre.SelectedIndex = 0;
                }
                else if (Trimestre3.Contains(DateTime.Today.Month))
                {
                    cmbAgno.SelectedValue = (DateTime.Today.Year).ToString();
                    cmbTrimestre.SelectedIndex = 1;
                }
                else if (Trimestre4.Contains(DateTime.Today.Month))
                {
                    cmbAgno.SelectedValue = (DateTime.Today.Year).ToString();
                    cmbTrimestre.SelectedIndex = 2;
                }
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAgno.SelectedValue == "2018" && cmbTrimestre.SelectedIndex == 0)
                    throw new CustomException("Esta funcionalidad no esta habilitada para el primer trimestre de 2018");
                blld__l_DECLARACION_DIARIA Lista = new blld__l_DECLARACION_DIARIA();
                Lista.NID_ENVIO_ANIO = new Declara_V2.IntegerFilter(cmbAgno.SelectedValue());
                if (cmbTrimestre.SelectedIndex == 0)
                    foreach (Int32 i in Trimestre1)
                        Lista.NID_ENVIO_MESs.Add(i);
                else if (cmbTrimestre.SelectedIndex == 1)
                    foreach (Int32 i in Trimestre2)
                        Lista.NID_ENVIO_MESs.Add(i);
                else if (cmbTrimestre.SelectedIndex == 2)
                    foreach (Int32 i in Trimestre3)
                        Lista.NID_ENVIO_MESs.Add(i);
                else if (cmbTrimestre.SelectedIndex == 3)
                    foreach (Int32 i in Trimestre4)
                        Lista.NID_ENVIO_MESs.Add(i);
                if (cbxSoloPublicas.Checked)
                    Lista.L_AUTORIZA_PUBLICAR = true;
                Lista.NID_ESTADOs.Add(2);
                Lista.NID_ESTADOs.Add(3);
                Lista.select();
                if (Lista.lista_DECLARACION_DIARIA.Where(p => (new List<Int32> { 1, 2, 3 }).Contains(p.NID_ESTADO_TESTADO)).Any())
                    throw new CustomException("Restan " + Lista.lista_DECLARACION_DIARIA.Where(p => (new List<Int32> { 1, 2, 3 }).Contains(p.NID_ESTADO_TESTADO)).Count().ToString() + " declaraciones por aprobar el testado");

                Genera(Lista.lista_DECLARACION_DIARIA);
            }
            catch (Exception ex)
            {
                lrt.ShowDanger(ex.Message);
                //if (ex is CustomException || ex is ConvertionException)
                //{
                //    lrt.ShowDanger(ex.Message);
                //}
                //else { throw ex; }
            }
        }

        private void Genera(List<DECLARACION_DIARIA> lista_DECLARACION_DIARIA)
        {
            String Folder = String.Concat(System.Configuration.ConfigurationManager.AppSettings["CarpetaTransparencia"], cmbAgno.SelectedValue, Path.DirectorySeparatorChar, "T", (cmbTrimestre.SelectedIndex + 1));
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);
            Int32 x = 1;
            while (Directory.Exists(String.Concat(Folder, Path.DirectorySeparatorChar, "V", x)))
                x++;
            Folder = String.Concat(Folder, Path.DirectorySeparatorChar, "V", x);
            Directory.CreateDirectory(Folder);
            Folder += "\\";
            String LogText = String.Concat(DateTime.Now, " : Iniciado ", ((clsUsuario)Session["oUsuario"]).VID_USUARIO,  Environment.NewLine, "\t\t\t", " Inicial: ", lista_DECLARACION_DIARIA.Where(p => p.NID_TIPO_DECLARACION == 1).Count(),
                                                                                                                         Environment.NewLine, "\t\t\t", " Modificación: ", lista_DECLARACION_DIARIA.Where(p => p.NID_TIPO_DECLARACION == 2).Count(),
                                                                                                                         Environment.NewLine, "\t\t\t", " Conclusión: ", lista_DECLARACION_DIARIA.Where(p => p.NID_TIPO_DECLARACION == 3).Count()
                                                                                                                     );
            LogText += "\n\r" +   Environment.NewLine;
            File.WriteAllText(String.Concat(Folder, "_log.txt"), LogText);
            String FileName = String.Empty;
            String ZipFile = String.Concat(Path.GetTempPath().ToString(), Path.GetRandomFileName(), ".zip");
            Directory.CreateDirectory(Folder);

            //if (!Directory.Exists(String.Concat(Folder, "INICIO\\SIN_COMENTARIOS")))
            //    Directory.CreateDirectory(String.Concat(Folder, "INICIO\\SIN_COMENTARIOS"));

            //if (!Directory.Exists(String.Concat(Folder, "INICIO\\COMENTARIOS")))
            //    Directory.CreateDirectory(String.Concat(Folder, "INICIO\\COMENTARIOS"));

            //if (!Directory.Exists(String.Concat(Folder, "MODIFICACION\\SIN_COMENTARIOS")))
            //    Directory.CreateDirectory(String.Concat(Folder, "MODIFICACION\\SIN_COMENTARIOS"));

            //if (!Directory.Exists(String.Concat(Folder, "MODIFICACION\\COMENTARIOS")))
            //    Directory.CreateDirectory(String.Concat(Folder, "MODIFICACION\\COMENTARIOS"));

            //if (!Directory.Exists(String.Concat(Folder, "CONCLUSION\\SIN_COMENTARIOS")))
            //    Directory.CreateDirectory(String.Concat(Folder, "CONCLUSION\\SIN_COMENTARIOS"));

            //if (!Directory.Exists(String.Concat(Folder, "CONCLUSION\\COMENTARIOS")))
            //    Directory.CreateDirectory(String.Concat(Folder, "CONCLUSION\\COMENTARIOS"));


            Int32 Inicial = 0;
            Int32 Modificacion = 0;
            Int32 Conclusion = 0;
            Int32 Error = 0;
            Int32 RowNumber = 0;


            foreach (DECLARACION_DIARIA dec in lista_DECLARACION_DIARIA)
            {
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(
                                                                      dec.VID_NOMBRE
                                                                     , dec.VID_FECHA
                                                                     , dec.VID_HOMOCLAVE
                                                                     , dec.NID_DECLARACION
                                                                     );
                blld_USUARIO oUsuario = new blld_USUARIO(dec.VID_NOMBRE
                                                                     , dec.VID_FECHA
                                                                     , dec.VID_HOMOCLAVE);
                try
                {
                    RowNumber++;
                    FileName = "tr_{aqui}1_" +
                            oDeclaracion.C_EJERCICIO.Trim() +
                            oUsuario.V_NOMBRE.ToLower().Trim().Replace(" ", "_").Trim() + "_" +
                            oUsuario.V_PRIMER_A.ToLower().Trim().Replace(" ", "_").Trim() + "_" +
                            oUsuario.V_SEGUNDO_A.ToLower().Trim().Replace(" ", "_").Trim();
                    //if (oUsuario.V_SEGUNDO_A.Length > 1)
                    //    FileName += oUsuario.V_SEGUNDO_A.Substring(0, 2).Trim().ToUpper().Trim().Replace(" ", "_").Trim();
                    FileName = FileName.Replace("á", "a")
                                       .Replace("é", "e")
                                       .Replace("í", "i")
                                       .Replace("ó", "o")
                                       .Replace("ú", "u")
                                       .Replace("ñ", "n");
                    FileName = DeclaracionTestada(oDeclaracion, Folder, FileName);

                    LogText = String.Concat(DateTime.Now, " : ", RowNumber.ToString().PadLeft(5,'0')," ", FileName, "\n\r", Environment.NewLine);
                    File.AppendAllText(String.Concat(Folder, "_log.txt"), LogText);
                    switch (oDeclaracion.NID_TIPO_DECLARACION)
                    {
                        case 1:
                            Inicial++;
                            break;
                        case 2:
                            Modificacion++;
                            break;
                        case 3:
                            Conclusion++;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        try { System.IO.File.WriteAllText(Clean(String.Concat(Folder, Path.DirectorySeparatorChar.ToString(), FileName, "EXC", oDeclaracion.VID_NOMBRE,DateTime.Now, ".txt")), ex.Message); } catch { }
                        LogText = String.Concat(DateTime.Now, " : Error  ", RowNumber.ToString().PadLeft(5, '0'), " ", FileName, "\n\r", Environment.NewLine);
                        LogText += String.Concat("\t\t\t", ex.Message.Replace("\n", String.Empty).Replace("\r", String.Empty).Replace(Environment.NewLine, String.Empty), Environment.NewLine);
                        File.AppendAllText(String.Concat(Folder, "_log.txt"), LogText);
                        Error++;
                    }
                    catch { }
                }
            }

            LogText = String.Concat(DateTime.Now, " : Finalizado" + Environment.NewLine, "\t\t\t", lista_DECLARACION_DIARIA.Where(p => p.NID_TIPO_DECLARACION == 1).Count(),
                                                                    Environment.NewLine, "\t\t\t", lista_DECLARACION_DIARIA.Where(p => p.NID_TIPO_DECLARACION == 2).Count(),
                                                                    Environment.NewLine, "\t\t\t", lista_DECLARACION_DIARIA.Where(p => p.NID_TIPO_DECLARACION == 3).Count()
                                                                                                                     );
            File.AppendAllText(String.Concat(Folder, "_log.txt"), LogText);
            //System.IO.Compression.ZipFile.CreateFromDirectory(Folder, ZipFile);

            //foreach (FileInfo f in new DirectoryInfo(Folder).GetFiles())
            //    f.Delete();
            //Directory.Delete(Folder);

            //HttpContext.Current.Response.ClearContent();
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.ContentType = "application/zip";
            //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + String.Concat(cmbAgno.SelectedValue, "_Trimestre", cmbTrimestre.SelectedValue, ".zip"));
            //HttpContext.Current.Response.WriteFile(ZipFile);
            //HttpContext.Current.Response.Flush();
            //System.IO.File.Delete(ZipFile);
            //HttpContext.Current.Response.End();
        }

        public static string DeclaracionTestada(blld_DECLARACION oDeclaracion, String Folder, String File)
        {
            String FileName = String.Empty;
            try
            {
                switch (oDeclaracion.NID_TIPO_DECLARACION)
                {
                    case 1:
                        FileName = Clean(File.Replace("{aqui}", "inic").Trim()).Trim();
                        if (oDeclaracion.NID_ESTADO_TESTADO == 0)
                            ImprimirInicial(oDeclaracion, Folder , FileName);
                        else
                            ImprimirInicial(oDeclaracion, Folder , FileName);
                        break;
                    case 2:
                        FileName = Clean(File.Replace("{aqui}", "mod").Trim()).Trim();
                        if (oDeclaracion.NID_ESTADO_TESTADO == 0)
                            ImprimirModificacion(oDeclaracion, Folder , FileName);
                        else
                            ImprimirModificacion(oDeclaracion, Folder , FileName);
                        break;
                    case 3:
                        FileName = Clean(File.Replace("{aqui}", "conc").Trim()).Trim();
                        if (oDeclaracion.NID_ESTADO_TESTADO == 0)
                            ImprimirConclusion(oDeclaracion, Folder , FileName);
                        else
                            ImprimirConclusion(oDeclaracion, Folder , FileName);
                        break;
                    default:
                        break;
                }
                return FileName;
            }
            catch (Exception ex)
            {
                //System.IO.File.WriteAllText(String.Concat(Folder, File, "EXC", oDeclaracion.VID_NOMBRE, ".txt"), ex.Message);
                throw ex;
            }
        }

        private static string Clean(string v)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(v, String.Empty);
        }

        public static void ImprimirInicial(blld_DECLARACION oDeclaracion, String Folder, String File)
        {
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(FileServiceCredentials, 5, "DECLARACION_INICIAL_TESTADA", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"N"}.ToArray());
            byte[] b1 = sf.FileBytes;
            File = String.Concat(Folder, Path.DirectorySeparatorChar.ToString(), File.Trim(), ".pdf");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.ChannelFactory.Close();
            o.Close();
            o.Abort();
            o = null;
        }

        public static void ImprimirModificacion(blld_DECLARACION oDeclaracion, String Folder, String File)
        {
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(FileServiceCredentials, 5, "DECLARACION_MODIFICACION_TESTA", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"N"
                                                                               ,oDeclaracion.C_EJERCICIO}.ToArray());
            byte[] b1 = sf.FileBytes;
            File = String.Concat(Folder, Path.DirectorySeparatorChar.ToString(), File.Trim(), ".pdf");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();

        }

        public static void ImprimirConclusion(blld_DECLARACION oDeclaracion, String Folder, String File)
        {
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(FileServiceCredentials, 5, "DECLARACION_CONCLUSION_TESTA", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"N"
                                                                               ,oDeclaracion.C_EJERCICIO}.ToArray());
            byte[] b1 = sf.FileBytes;
            File = String.Concat(Folder, Path.DirectorySeparatorChar.ToString(), File.Trim(), ".pdf");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();
        }
    }
}