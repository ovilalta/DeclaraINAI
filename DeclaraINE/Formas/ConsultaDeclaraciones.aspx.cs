using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using System.IO;
using DeclaraINE.file;
using DeclaraINE.Legacy;
using Declara_V2;

namespace DeclaraINE.Formas
{
    public partial class ConsultaDeclaraciones : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            pnlDeclaracionPatrimonial.Visible = false;
            pnlDeclaracionConflicto.Visible = false;
            pnlDeclaracionAnteriores.Visible = false;

            blld_USUARIO oUsuario = _oUsuario;
            string VID_RFC = oUsuario.VID_NOMBRE + oUsuario.VID_FECHA + oUsuario.VID_HOMOCLAVE;
            if (!IsPostBack)
            {
                Page.Title = "Consulta de Declaraciones";
                pnlDeclaracionPatrimonial.Visible = true;
                ltrSubTitulo.Text = "Declaración Patrimonial";
                oUsuario.Reload_DECLARACIONs();
                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                o.VID_NOMBRE = new Declara_V2.StringFilter(oUsuario.VID_NOMBRE);
                o.VID_FECHA = new Declara_V2.StringFilter(oUsuario.VID_FECHA);
                o.VID_HOMOCLAVE = new Declara_V2.StringFilter(oUsuario.VID_HOMOCLAVE);
                o.NID_ESTADOs.FilterCondition = ListFilter.FilterConditions.Negated;
                o.NID_ESTADOs.Add(1);
                o.NID_ESTADOs.Add(6);
                o.NID_ESTADOs.Add(7);
                o.select();
                List<Declara_V2.BLLD.DeclaracionesInformeDetalle> Declaraciones = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();
                List<Declara_V2.BLLD.DeclaracionesInformeDetalle> DeclaracionesAntiguas = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();

                blld_DECLARACION oDeclaracion;

                if (o.lista_DECLARACION_DIARIA.Any())
                {
                    oDeclaracion = new blld_DECLARACION
                                                              (
                                                                VID_RFC.Substring(0, 4)
                                                              , VID_RFC.Substring(4, 6)
                                                              , VID_RFC.Substring(10, 3)
                                                              , o.lista_DECLARACION_DIARIA.Last().NID_DECLARACION
                                                               );
                }
                else
                {
                    try
                    {
                        oDeclaracion = new blld_DECLARACION
                                                              (
                                                                VID_RFC.Substring(0, 4)
                                                              , VID_RFC.Substring(4, 6)
                                                              , VID_RFC.Substring(10, 3)
                                                              , 1
                                                               );
                    }
                    catch
                    { }
                }
                blld_USUARIO oUsuarioDeclaracion = new blld_USUARIO
                                                         (
                                                               VID_RFC.Substring(0, 4)
                                                             , VID_RFC.Substring(4, 6)
                                                             , VID_RFC.Substring(10, 3)
                                                          );

                foreach (DECLARACION_DIARIA dec in o.lista_DECLARACION_DIARIA)
                {
                    Declaraciones.Add(
                                      new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                            2
                                          , dec.C_EJERCICIO
                                          , dec.NID_DECLARACION
                                          , dec.NID_TIPO_DECLARACION
                                          , dec.F_ENVIO.ToString()
                                          , dec.NID_ESTADO)
                                                                      );
                }
                try
                {
                    DeclaraINE.Legacy.fileSoapClient DeclaracionesAnteriores = new DeclaraINE.Legacy.fileSoapClient();
                    ListaDeclara[] ListaAnteriores = DeclaracionesAnteriores.Consulta(VID_RFC);
                    ListaAnt2010[] listaAnt2010 = DeclaracionesAnteriores.Consulta2010(VID_RFC);
                    DeclaracionesAnteriores.Close();


                    for (int x = 0; x < ListaAnteriores.Count(); x++)
                    {
                        Int32 NID_TIPO;
                        switch (ListaAnteriores[x].T_D)
                        {
                            case 1:
                                NID_TIPO = 1;
                                break;
                            case 2:
                                NID_TIPO = 3;
                                break;
                            case 4:
                                NID_TIPO = 2;
                                break;
                            default:
                                NID_TIPO = 0;
                                break;
                        }
                        DeclaracionesAntiguas.Add(
                                               new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                                1
                                              , ListaAnteriores[x].Anio.ToString()
                                              , ListaAnteriores[x].ID_Declara
                                              , NID_TIPO
                                              , ListaAnteriores[x].RFC + "," + ListaAnteriores[x].Num_Empleado
                                               // , ListaAnteriores[x].Num_Empleado));
                                               , ListaAnteriores[x].Clasifica));
                    }
                    // ListaAnt2010[] listaAnt2010 = DeclaracionesAnteriores.Consulta2010(VID_RFC);
                    // DeclaracionesAnteriores.Close();
                    for (int y = 0; y < listaAnt2010.Count(); y++)
                    {
                        Int32 NID_TIPO_ANT;
                        switch (listaAnt2010[y].TIP_DECLARACION)
                        {
                            case "1":
                                NID_TIPO_ANT = 1;
                                break;
                                NID_TIPO_ANT = 3;
                                break;
                            case "4":
                                NID_TIPO_ANT = 2;
                                break;
                            default:
                                NID_TIPO_ANT = 0;
                                break;
                        }

                        DeclaracionesAntiguas.Add(
                                              new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                               0
                                             , listaAnt2010[y].ANIO.ToString()
                                             , listaAnt2010[y].ID_DECLARACION
                                             , NID_TIPO_ANT
                                             , listaAnt2010[y].RFC
                                             , 2));
                        //pnlDeclaracionAnteriores.Visible = true;
                        //grdDAnt.DataSource = DeclaracionesAntiguas.OrderBy(p => p.C_EJERCICIO).ToArray();
                        //grdDAnt.DataBind();
                    }

                    grdDAnt.DataSource = DeclaracionesAntiguas.OrderBy(p => p.C_EJERCICIO).ToArray();
                    grdDAnt.DataBind();

                }
                catch { }


                grdDP.DataSource = Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToArray();
                grdDP.DataBind();

            }

        }
        //Responsiva de uso de medios
       

        //Declaracion Patrimonial
        protected void btnDeclaracionPatrimonial_Click(object sender, EventArgs e)
        {
            ltrSubTitulo.Text = "Declaración Patrimonial";
            blld_USUARIO oUsuario = _oUsuario;

            grdDP.DataBind(oUsuario.DECLARACIONs.Where(p => (new Int32[] { 2, 3, 4, 5 }).Contains(p.NID_ESTADO)));
            pnlDeclaracionPatrimonial.Visible = true;
        }

        protected void btnDeclaracionConflicto_Click(object sender, EventArgs e)
        {
            ltrSubTitulo.Text = "Declaración Intereses";

            blld_USUARIO oUsuario = _oUsuario;
            //grdDCF.DataBind(oUsuario.DECLARACIONs);
            pnlDeclaracionConflicto.Visible = true;
        }

        protected void btnDeclaracionAnteriores_Click(object sender, EventArgs e)
        {
            ltrSubTitulo.Text = "Declaraciones Anteriores a 2018";
            blld_USUARIO oUsuario = _oUsuario;
            //int Cuenta = 0;
            // grdDAnt.DataBind(oUsuario.DECLARACIONs.Where(p => (new Int32[] { 2, 3, 4, 5 }).Contains(p.NID_ESTADO)));
            pnlDeclaracionAnteriores.Visible = true;
            grdDAnt.Visible = true;
            // Cuenta= grdDAnt.Rows.Count;

        }


        protected void btnGridDeclaracion_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);

            switch (oDeclaracion.NID_TIPO_DECLARACION)
            {
                case 1:
                    ImprimirInicial(oDeclaracion, false);
                    break;
                case 2:
                    ImprimirModificacion(oDeclaracion, false);
                    break;
                case 3:
                    ImprimirConclusion(oDeclaracion, false);
                    break;
                default:
                    break;
            }
        }

        public static void ImprimirInicial(blld_DECLARACION oDeclaracion, Boolean lImprimeMarcaDeAgua)
        {
            String Preeliminar = lImprimeMarcaDeAgua ? "Preliminar" : "Naaaa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorIdyFecha(Pagina.FileServiceCredentials, 5, "DECLARACION_INICIAL",oDeclaracion.F_ENVIO.Value, new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,Preeliminar}.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        public static void ImprimirModificacion(blld_DECLARACION oDeclaracion, Boolean lPreliminar)
        {

            String strPreeliminar = lPreliminar ? "Preliminar" : "naa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorIdyFecha(Pagina.FileServiceCredentials, 5, "DECLARACION_MODIFICACION", oDeclaracion.F_ENVIO.Value, new List<Object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,strPreeliminar
                                                                               ,oDeclaracion.C_EJERCICIO}.ToArray()
                                                                               );
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString().Replace("\\", String.Empty), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        public static void ImprimirConclusion(blld_DECLARACION oDeclaracion, Boolean lPreliminar)
        {

            String strPreeliminar = lPreliminar ? "Preliminar" : "naa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorIdyFecha(Pagina.FileServiceCredentials, 5, "DECLARACION_CONCLUSION", oDeclaracion.F_ENVIO.Value, new List<Object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,strPreeliminar
                                                                               ,oDeclaracion.C_EJERCICIO}.ToArray()
                                                                               );
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        protected void btnGridDeclaracionConflicto_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
            //string[] Datos = ((Button)sender).CommandArgument.ToString().Split(new char[] { ',' });
            //Int32 NID_DECLARACION = Convert.ToInt32(Datos[0]);

            //String Origen = Datos[1];
            //if (Origen == "2")
            //{
            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);
            ImprimirDeclaracionConflicto(oDeclaracion, false);
            // }
            //else
            //{
            //    ConfliHistorico(Num_Empleado, Llave);
            //}
        }

        protected void btnGridDeclaracionAcuse_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
            // string[] Datos = ((Button)sender).CommandArgument.ToString().Split(new char[] { ',' });
            // Int32 NID_DECLARACION = Convert.ToInt32(Datos[0]);
            // //string Num_Empleado = "0";
            //// string Ejercicio = Datos[2];
            // String Origen = Datos[1];


            // string T_d = Datos[4];

            //if(Origen=="2")
            //{ 
            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);

            switch (oDeclaracion.NID_TIPO_DECLARACION)
            {
                case 1:
                    ImprimirDeclaracionInicialAcuse(oDeclaracion);
                    break;
                case 2:
                    ImprimirDeclaracionModificacionAcuse(oDeclaracion);
                    break;
                case 3:
                    ImprimirDeclaracionConclusionAcuse(oDeclaracion);
                    break;
                default:
                    break;
            }
            //}
            //else if(Origen=="1")
            //{
            //    Num_Empleado = Datos[6];
            //    DeclaHistorico(Num_Empleado, NID_DECLARACION.ToString(), T_d, Ejercicio, "Acuse");
            //}
            //else
            //{
            //    string llave = Datos[6];
            //    AcuseAnt2010(llave);
            //}
        }

      

        public static void ImprimirDeclaracionConflicto(blld_DECLARACION oDeclaracion, Boolean lPreeliminar)
        {

            String strPreeliminar = lPreeliminar ? "Preliminar" : "nhaa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 5, "CONFLICTO_INTERES", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION}.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        public static void ImprimirDeclaracionInicialAcuse(blld_DECLARACION oDeclaracion)
        {

            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 5, "ACUSE_INICIAL", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }
        public static void ImprimirDeclaracionModificacionAcuse(blld_DECLARACION oDeclaracion)
        {

            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 5, "ACUSE_MODIFICACION", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        public static void ImprimirDeclaracionConclusionAcuse(blld_DECLARACION oDeclaracion)
        {

            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 5, "ACUSE_CONCLUSION", new List<object> { oDeclaracion.VID_NOMBRE
                                                                               ,oDeclaracion.VID_FECHA
                                                                               ,oDeclaracion.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        protected void lkVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnGuardarRes_Click(object sender, EventArgs e)
        {

        }



        protected void btnGridDeclaraciónConflicto_Click(object sender, EventArgs e)
        {

        }

        protected void btnGridDeclaracionConflictoAcuse_Click(object sender, EventArgs e)
        {

        }

        protected void btnGridDeclaracionAnterior_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            // Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
            string[] Datos = ((Button)sender).CommandArgument.ToString().Split(new char[] { ',' });
            Int32 NID_DECLARACION = Convert.ToInt32(Datos[0]);
            string Num_Empleado = Datos[6];
            string Ejercicio = Datos[2];
            String Origen = "1";
            string T_d = Datos[4];
            String Llave = Datos[5];
            //String Noemp = Datos[6];
            if (Convert.ToInt32(Ejercicio) < 2010)
            {
                Origen = "3";

            }

            if (Origen == "1")
            {
                DeclaracionHistorico(Num_Empleado, NID_DECLARACION.ToString(), T_d, Ejercicio, "");
            }
            else
            {
                DeclaAnt2010(Llave);
            }
        }

        protected void btnGridDeclaracionConflictoAnterior_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            //Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
            string[] Datos = ((Button)sender).CommandArgument.ToString().Split(new char[] { ',' });
            Int32 NID_DECLARACION = Convert.ToInt32(Datos[0]);
            string Num_Empleado = Datos[3];
            string Llave = Datos[2];
            //String Origen = Datos[4];

            ConfliHistorico(Num_Empleado, Llave);

        }

        protected void btnGridDeclaraciónAnteriorAcuse_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            // Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
            string[] Datos = ((Button)sender).CommandArgument.ToString().Split(new char[] { ',' });
            Int32 NID_DECLARACION = Convert.ToInt32(Datos[0]);
            string Num_Empleado = "0";
            string Ejercicio = Datos[2];
            String Origen = "1";


            string T_d = Datos[4];
            if (Convert.ToInt32(Ejercicio) < 2010)
                Origen = "3";
            if (Origen == "1")
            {
                Num_Empleado = Datos[6];
                DeclaHistorico(Num_Empleado, NID_DECLARACION.ToString(), T_d, Ejercicio, "Acuse");
            }
            else if (Origen == "3")
            {
                string llave = Datos[6];
                AcuseAnt2010(llave);
            }
        }
        private void DeclaracionHistorico(string Emps, string Ids, string T_ds, string Anios, string Rep)
        {
            Int32 Tipo = 0;
            Int32 Ianio = Convert.ToInt32(Anios);
            byte[] b1 = null;
            switch (T_ds)
            {
                case "Inicial":
                    Tipo = 1;
                    break;
                case "Modificación":
                    Ianio = Ianio + 1;
                    Tipo = 4;
                    break;
                case "Conclusión":
                    Tipo = 2;
                    break;
                default:
                    break;
            }
            DeclaraINE.Legacy.fileSoapClient o = new Legacy.fileSoapClient();
            FileStream fs1;
            if (Tipo == 1)
            {
                b1 = o.Inicial(Convert.ToInt32(Emps), Convert.ToInt32(Ids), Tipo, Ianio, Rep);
            }
            if (Tipo == 4)
            {
                b1 = o.Modificacion(Convert.ToInt32(Emps), Convert.ToInt32(Ids), Tipo, Ianio, Rep);
            }
            else
            {
                b1 = o.Conclusion(Convert.ToInt32(Emps), Convert.ToInt32(Ids), Tipo, Ianio, Rep);
            }

            String Nombre = String.Concat(T_ds, Emps, Anios, ".pdf");
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Nombre);

            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + Nombre);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }
        private void DeclaHistorico(string Emps, string Ids, string T_ds, string Anios, string Rep)
        {
            Int32 Tipo = 0;
            Int32 Ianio = Convert.ToInt32(Anios);
            switch (T_ds)
            {
                case "Inicial":
                    Tipo = 1;
                    break;
                case "Modificación":
                    Ianio = Ianio + 1;
                    Tipo = 4;
                    break;
                case "Conclusión":
                    Tipo = 2;
                    break;
                default:
                    break;
            }
            DeclaraINE.Legacy.fileSoapClient o = new Legacy.fileSoapClient();
            FileStream fs1;
            byte[] b1 = o.Acuse(Convert.ToInt32(Emps), Convert.ToInt32(Ids), Tipo, Ianio, Rep);
            String Nombre = String.Concat(T_ds, Emps, Anios, ".pdf");
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Nombre);

            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + Nombre);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        private void ConfliHistorico(string Emps, string Ids)
        {
            string Dia = Ids.Substring(0, 10);
            Int32 Emp = Convert.ToInt32(Emps.ToString());
            Int32 Control = Convert.ToInt32(Ids.Substring(10, 2));

            DeclaraINE.Legacy.fileSoapClient o = new Legacy.fileSoapClient();
            FileStream fs1;
            byte[] b1 = o.Conflicto(Dia, Emp, Control);
            String Nombre = String.Concat("Conflicto", Emps, "_", Control, ".pdf");
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Nombre);

            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + Nombre);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }
        private void DeclaAnt2010(string Nombre)
        {

            DeclaraINE.Legacy.fileSoapClient o = new Legacy.fileSoapClient();
            FileStream fs1;
            byte[] b1 = o.DeclaraAnt2010(Nombre, "pdf");
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Nombre, ".pdf");
            //String File = b1.ToString();
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + Nombre);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            //System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }
        private void AcuseAnt2010(string Nombre1)
        {

            DeclaraINE.Legacy.fileSoapClient o = new Legacy.fileSoapClient();
            FileStream fs1;
            byte[] b1 = o.AcuseAnt2010(Nombre1, "pdf");

            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Nombre1, ".pdf");
            //String File = b1.ToString();
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + Nombre1);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            //System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }



 
    }
}