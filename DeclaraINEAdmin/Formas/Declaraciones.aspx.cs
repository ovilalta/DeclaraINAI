using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using System.Text.RegularExpressions;
using System.Globalization;
using DeclaraINEAdmin.Legacy;
using System.IO;
using DeclaraINEAdmin.file;
using DeclaraINE.file;
using DeclaraINE.Legacy;

namespace DeclaraINEAdmin.Formas
{
    public partial class Declaraciones : Pagina
    {

        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        DeclaraINEAdmin.file.DeclaracionesInforme Detalle
        {
            get => (DeclaraINEAdmin.file.DeclaracionesInforme)Session["Object2"];
            set => SessionAdd("Object2", value);
        }

        String VID_RFC
        {
            get => (String)ViewState["VID_RFC"];
            set => ViewState["VID_RFC"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("Declaraciones.aspx");
            if (!IsPostBack)
            {

                if (((clsUsuario)Session["oUsuario"]).VID_USUARIO == "edgar.rodriguezb")
                    Button1.Visible = true;


            }
            chNRFC.Checked = true;
            pnlchchNRFC.Visible = chNRFC.Checked;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBusqueda.Text.Length < 3)
                    throw new CustomException("Escriba más caracteres para realizar la busqueda");

                blld__l_USUARIO ListaUsuario = new blld__l_USUARIO();
                List<USUARIO> resultado = new List<USUARIO>();

                ListaUsuario.VID_RFC = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                ListaUsuario.select();
                foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                    resultado.Add(u);

                //ListaUsuario = new blld__l_USUARIO();
                //ListaUsuario.VID_FECHA = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                //ListaUsuario.select();
                //foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                //    if (!resultado.Contains(u))
                //    resultado.Add(u);

                //ListaUsuario = new blld__l_USUARIO();
                //ListaUsuario.VID_HOMOCLAVE = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                //ListaUsuario.select();
                //foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                //    if (!resultado.Contains(u))
                //        resultado.Add(u);

                ListaUsuario = new blld__l_USUARIO();
                ListaUsuario.V_NOMBRE_COMPLETO_ESTILO1 = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                ListaUsuario.select();
                foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                    if (!resultado.Where(p => p.VID_NOMBRE == u.VID_NOMBRE && p.VID_FECHA == u.VID_FECHA && p.VID_HOMOCLAVE == u.VID_HOMOCLAVE).Any())
                        resultado.Add(u);

                ListaUsuario = new blld__l_USUARIO();
                ListaUsuario.V_NOMBRE_COMPLETO_ESTILO2 = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                ListaUsuario.select();
                foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                    if (!resultado.Where(p => p.VID_NOMBRE == u.VID_NOMBRE && p.VID_FECHA == u.VID_FECHA && p.VID_HOMOCLAVE == u.VID_HOMOCLAVE).Any())
                        resultado.Add(u);

                //ListaUsuario = new blld__l_USUARIO();
                //ListaUsuario.V_SEGUNDO_A = new Declara_V2.StringFilter(txtBusqueda.Text, StringFilter.FilterType.like);
                //ListaUsuario.select();
                //foreach (USUARIO u in ListaUsuario.lista_USUARIO)
                //    if (!resultado.Contains(u))
                //        resultado.Add(u);



                SessionAdd("Object1", resultado);
                grdUsuario.DataSource = resultado;
                grdUsuario.DataBind();
                if (!resultado.Any())
                    throw new CustomException("La busqueda no generó ningun resultado");
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaBusqueda.ShowDanger(ex.Message);
                else
                    throw ex;
            }
        }

        protected void btnConsultaDeclaraciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (((Button)sender).CommandArgument != "NoGrid")
                    this.VID_RFC = ((Button)sender).CommandArgument;
                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                o.VID_NOMBRE = new Declara_V2.StringFilter(VID_RFC.Substring(0, 4));
                o.VID_FECHA = new Declara_V2.StringFilter(VID_RFC.Substring(4, 6));
                o.VID_HOMOCLAVE = new Declara_V2.StringFilter(VID_RFC.Substring(10, 3));
                o.NID_ESTADOs.FilterCondition = ListFilter.FilterConditions.Negated;
                o.NID_ESTADOs.Add(1);
                o.NID_ESTADOs.Add(6);
                o.NID_ESTADOs.Add(7);
                o.select();
                List<Declara_V2.BLLD.DeclaracionesInformeDetalle> Declaraciones = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();
                String C_CURP = String.Empty;
                String C_GENERO = "S";
                //int Nempleado = 0;
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
                    C_CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
                    C_GENERO = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
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
                        C_CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
                        C_GENERO = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
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
                                          , dec.F_ENVIO.ToString("dd/MM/yyyy")+"."
                                          , dec.NID_ESTADO)
                                                                      );
                }

                DeclaraINEAdmin.Legacy.fileSoapClient DeclaracionesAnteriores = new DeclaraINEAdmin.Legacy.fileSoapClient();
                DeclaraINE.Legacy.fileSoapClient DeclaracionesAnt2010 = new DeclaraINE.Legacy.fileSoapClient();
                DeclaraINEAdmin.Legacy.ListaDeclara[] ListaAnteriores = DeclaracionesAnteriores.Consulta(VID_RFC);
                DeclaraINE.Legacy.ListaAnt2010[] listaAnt2010 = DeclaracionesAnt2010.Consulta2010(VID_RFC);
                DeclaracionesAnteriores.Close();
                DeclaracionesAnt2010.Close();

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
                    Declaraciones.Add(
                                           new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                            1
                                          , ListaAnteriores[x].Anio.ToString()
                                          , ListaAnteriores[x].ID_Declara
                                          , NID_TIPO
                                          , ListaAnteriores[x].Fec_Envio+","+ListaAnteriores[x].Num_Empleado+","+ ListaAnteriores[x].RFC
                                          //, null)); Artificio para llevar en numero de empleado
                                          , ListaAnteriores[x].Clasifica));
            }
          for (int y = 0; y < listaAnt2010.Count(); y++)
            {
                    Int32 NID_TIPO_ANT;
                    switch (listaAnt2010[y].TIP_DECLARACION)
                    {
                        case "1":
                            NID_TIPO_ANT = 1;
                            break;
                        case "2":
                            NID_TIPO_ANT = 3;
                            break;
                        case "4":
                            NID_TIPO_ANT = 2;
                            break;
                        default:
                            NID_TIPO_ANT = 0;
                            break;
            }

                    Declaraciones.Add(
                                          new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                           0
                                         , listaAnt2010[y].ANIO.ToString()
                                         , listaAnt2010[y].ID_DECLARACION
                                         , NID_TIPO_ANT
                                         , listaAnt2010[y].RFC
                                         , 2));

                }

                grdDec.DataSource = Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToArray();
                grdDec.DataBind();

                Declara_V2.BLLD.DeclaracionesInforme DetalleAux = new Declara_V2.BLLD.DeclaracionesInforme(VID_RFC
                                                  , C_CURP
                                                  , oUsuarioDeclaracion.V_NOMBRE_COMPLETO
                                                  , Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToList()
                                                   );


                Detalle = new file.DeclaracionesInforme();
                Detalle.V_FECHA_CONSULTA = DetalleAux.V_FECHA_CONSULTA;
                Detalle.V_HORA_CONSULTA = DetalleAux.V_HORA_CONSULTA;
                Detalle.V_RFC = DetalleAux.V_RFC;
                Detalle.V_CURP = DetalleAux.V_CURP;
                Detalle.V_SELLO = DetalleAux.V_SELLO;
                Detalle.V_NOMBRE = DetalleAux.V_NOMBRE;
                List<DeclaraINEAdmin.file.DeclaracionesInformeDetalle> ListaDeclaraciones = new List<DeclaraINEAdmin.file.DeclaracionesInformeDetalle>();

                foreach (Declara_V2.BLLD.DeclaracionesInformeDetalle item in DetalleAux.DECLARACIONES)
                {
                    Int32 NID_TIPO_DECLARACION = item.NID_TIPO_DECLARACION;
                    if (NID_TIPO_DECLARACION == 2)
                    {
                        switch (C_GENERO)
                        {
                            case "M":
                                NID_TIPO_DECLARACION = 22;
                                break;
                            case "F":
                                NID_TIPO_DECLARACION = 21;
                                break;
                            default:
                                NID_TIPO_DECLARACION = 20;
                                break;
                        }
                    }
                    if (item.NID_ORIGEN == 0)
                        item.F_PRESENTACION = item.C_EJERCICIO;
                    if (item.NID_ORIGEN !=0)
                        item.F_PRESENTACION = item.F_PRESENTACION.Substring(0, 10);
                    ListaDeclaraciones.Add(new file.DeclaracionesInformeDetalle
                    {
                        NID_ORIGEN = item.NID_ORIGEN,
                        C_EJERCICIO = item.C_EJERCICIO,
                        NID_DECLARACION = item.NID_DECLARACION,
                        NID_TIPO_DECLARACION = NID_TIPO_DECLARACION,
                        V_TIPO_DECLARACION = item.V_TIPO_DECLARACION,
                        F_PRESENTACION = item.F_PRESENTACION,
                        NID_ESTADO = item.NID_ESTADO,
                        V_ESTADO = item.V_ESTADO,
                    });
                }

                Detalle.DECLARACIONES = ListaDeclaraciones.ToArray();
                //grdDec.DataSource = Detalle.DECLARACIONES.OrderBy(p => p.NID_ORIGEN).ThenBy(p=> p.C_EJERCICIO);
                //grdDec.DataSource = Detalle.DECLARACIONES;
                //grdDec.DataSource= Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToArray();
                //grdDec.DataBind();

                appConsultaDeclaraciones.Show(true);
                appConsultaDeclaraciones.HeaderText = String.Concat(VID_RFC, " ", oUsuarioDeclaracion.V_NOMBRE_COMPLETO);
            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    AlertaBusqueda.ShowDanger(ex.Message);
                }
                else AlertaBusqueda.ShowDanger(ex.Message);
            }
        }

        protected void btnConsultaDeclaracionesCerrar_Click(object sender, EventArgs e)
        {
            appConsultaDeclaraciones.Hide();
        }


        protected void btnGridDeclaracion_Click(object sender, EventArgs e)
        {
            string Num_Empleado = "0";
            string Ejercicio = "2018";
            string T_d = "0";
            String Llave = "";
           string[] Datos = ((Button)sender).CommandArgument.ToString().Split(new char[] { ',' });
            Int32 NID_DECLARACION = Convert.ToInt32(Datos[0]);
            String Origen = Datos[3];
            if(Origen !="2")
            { 
             Num_Empleado = Datos[6];
             Ejercicio = Datos[2];
             T_d = Datos[4];
             Llave = Datos[5];
            }

            try
            {
               // Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
               if(Origen=="2")
                { 
                        blld_DECLARACION oDeclaracion = new blld_DECLARACION(VID_RFC.Substring(0, 4)
                                                                           , VID_RFC.Substring(4, 6)
                                                                           , VID_RFC.Substring(10, 3)
                                                                           , NID_DECLARACION);
                 

                        Declaracion(oDeclaracion);
                }
                else if(Origen=="1")
                {
                    DeclaracionHistorico(Num_Empleado, NID_DECLARACION.ToString(), T_d, Ejercicio, "");
                }
               else
                {
                    DeclaAnt2010(Llave);
                }
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaBusqueda.ShowDanger(ex.Message);
                else throw ex;
            }
        }


        public void btnGridDeclaracionConflicto_Click(object sender, EventArgs e)
        {




            try
            {
               // Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);

                string[] Datos = ((Button)sender).CommandArgument.ToString().Split(new char[] { ',' });
                
                string Num_Empleado = "0";
                string Llave = "";
                Int32 NID_DECLARACION = Convert.ToInt32(Datos[0]);
                String Origen = Datos[1]; 
                if(Origen!="2")
                {
                    Num_Empleado = Datos[3];
                    Llave = Datos[4];
                 }

                if (Origen=="2")
                {
                    blld_USUARIO oUsuario = new blld_USUARIO(VID_RFC.Substring(0, 4), VID_RFC.Substring(4, 6), VID_RFC.Substring(10, 3));
                    blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);
                    DeclaraINE.Formas.ConsultaDeclaraciones.ImprimirDeclaracionConflicto(oDeclaracion, false);
                }
                else
                {
                    ConfliHistorico(Num_Empleado, Llave);
                }


                
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaBusqueda.ShowDanger(ex.Message);
                else throw ex;
            }
        }

        public void btnGridDeclaracionAcuse_Click(object sender, EventArgs e)
        {
            try
            {
                // Int32 NID_DECLARACION = Convert.ToInt32(((Button)sender).CommandArgument);
                string[] Datos = ((Button)sender).CommandArgument.ToString().Split(new char[] { ','});
                Int32 NID_DECLARACION =Convert.ToInt32( Datos[0]);
                string Num_Empleado = "0";
                string llave = "";
                string Ejercicio = Datos[2];
                String Origen = Datos[3];
                if (Origen == "1")
                    Num_Empleado = Datos[6];
                string T_d = Datos[4];
                if(Origen=="0")
                  llave = Datos[6];
                if (Origen=="2")
                { 
                        blld_DECLARACION oDeclaracion = new blld_DECLARACION(VID_RFC.Substring(0, 4)
                                                                           , VID_RFC.Substring(4, 6)
                                                                           , VID_RFC.Substring(10, 3)
                                                                           , NID_DECLARACION);

                        Acuse(oDeclaracion);
                }
                else if (Origen == "1")
                {
                    DeclaHistorico(Num_Empleado,NID_DECLARACION.ToString(),T_d,Ejercicio,"Acuse");
                }
                else
                {
                    AcuseAnt2010(llave);
                }
            }

            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaBusqueda.ShowDanger(ex.Message);
                else throw ex;
            }
        }

        public static void Acuse(blld_DECLARACION oDeclaracion)
        {
            switch (oDeclaracion.NID_TIPO_DECLARACION)
            {
                case 1:
                    DeclaraINE.Formas.ConsultaDeclaraciones.ImprimirDeclaracionInicialAcuse(oDeclaracion);
                    break;
                case 2:
                    DeclaraINE.Formas.ConsultaDeclaraciones.ImprimirDeclaracionModificacionAcuse(oDeclaracion);
                    break;
                case 3:
                    DeclaraINE.Formas.ConsultaDeclaraciones.ImprimirDeclaracionConclusionAcuse(oDeclaracion);
                    break;
                default:
                    break;
            }
        }


        public static void Declaracion(blld_DECLARACION oDeclaracion)
        {
            switch (oDeclaracion.NID_TIPO_DECLARACION)
            {
                case 1:
                    DeclaraINE.Formas.DeclaracionInicial._Inicial.Imprimir(oDeclaracion, false);
                    break;
                case 2:
                    DeclaraINE.Formas.DeclaracionModificacion._Modificacion.Imprimir(oDeclaracion, false);
                    break;
                case 3:
                    DeclaraINE.Formas.DeclaracionConclusion._Conclusion.Imprimir(oDeclaracion, false);
                    break;
                default:
                    break;
            }
        }

        protected void btnInforme_Click(object sender, EventArgs e)
        {
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            DeclaraINEAdmin.file.SerializedFile sf = o.ObtenReportePorId_DataSource(FileServiceCredentials, 5, "DECLARACIONES_PRESENTADAS", new List<Object> { }.ToArray(), Detalle);
            byte[] b1 = sf.FileBytes;
            String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
            fs1 = new FileStream(File, FileMode.Create);
            fs1.Write(b1, 0, b1.Length);
            fs1.Close();
            fs1 = null;
            o.Close();

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        protected void btnNoEncontrado_Click(object sender, EventArgs e)
        {
            mdlNoEncontado.Show(true);
            txtPrimerApellido.Text = String.Empty;
            txtSegundoApellido.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtRFC1.Text = String.Empty;
            txtRFC2.Text = String.Empty;
            txtRFC3.Text = String.Empty;
            txtCURP.Text = String.Empty;
            VID_RFC = null;
        }

        protected void btnInformeNoEncontrado_Click(object sender, EventArgs e)
        {
            blld__l_DECLARACION oBuscar = new blld__l_DECLARACION();
            oBuscar.VID_NOMBRE = new StringFilter(txtRFC1.Text);
            oBuscar.VID_FECHA = new StringFilter(txtRFC2.Text);
            oBuscar.VID_HOMOCLAVE = new StringFilter(txtRFC3.Text);
            oBuscar.NID_ESTADOs.FilterCondition = ListFilter.FilterConditions.Negated;
            oBuscar.NID_ESTADOs.Add(6);
            oBuscar.NID_ESTADOs.Add(1);
            oBuscar.select();

            if (oBuscar.lista_DECLARACION.Any())
            {
                this.VID_RFC = String.Concat(txtRFC1.Text, txtRFC2.Text, txtRFC3.Text);
                btnConsultaDeclaraciones_Click(sender, e);
                btnInforme_Click(sender, e);
                appConsultaDeclaraciones.Hide();
            }
            else
            {

                DeclaraINEAdmin.Legacy.fileSoapClient DeclaracionesAnteriores = new DeclaraINEAdmin.Legacy.fileSoapClient();
               DeclaraINEAdmin.Legacy.ListaDeclara[] ListaAnteriores;
                try { ListaAnteriores = DeclaracionesAnteriores.Consulta(String.Concat(txtRFC1.Text, txtRFC2.Text, txtRFC3.Text)); }
                catch { ListaAnteriores = new DeclaraINEAdmin.Legacy.ListaDeclara[] { }; }
                DeclaracionesAnteriores.Close();

                if (ListaAnteriores.Any())
                {
                    this.VID_RFC = String.Concat(txtRFC1.Text, txtRFC2.Text, txtRFC3.Text);
                    btnConsultaDeclaraciones_Click(sender, e);
                    btnInforme_Click(sender, e);
                    appConsultaDeclaraciones.Hide();
                }
                else
                {
                    Declara_V2.BLLD.DeclaracionesInforme source = new Declara_V2.BLLD.DeclaracionesInforme(String.Concat(txtRFC1.Text, txtRFC2.Text, txtRFC3.Text)
                                                                                                     , txtCURP.Text
                                                                                                     , String.Concat(txtNombre.Text, " ", txtPrimerApellido.Text, " ", txtSegundoApellido.Text)
                                                                                                     , new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>());

                    DeclaraINEAdmin.file.DeclaracionesInforme otra = new file.DeclaracionesInforme();
                    otra.V_FECHA_CONSULTA = source.V_FECHA_CONSULTA;
                    otra.V_HORA_CONSULTA = source.V_HORA_CONSULTA;
                    otra.V_RFC = source.V_RFC;
                    otra.V_CURP = source.V_CURP;
                    otra.V_SELLO = source.V_SELLO;
                    otra.V_NOMBRE = source.V_NOMBRE;
                    otra.DECLARACIONES = new List<DeclaraINEAdmin.file.DeclaracionesInformeDetalle>().ToArray();


                    file.fileSoapClient o = new file.fileSoapClient();
                    FileStream fs1;
                    DeclaraINEAdmin.file.SerializedFile sf = o.ObtenReportePorId_DataSource(FileServiceCredentials, 5, "DECLARACIONES_PRESENTADAS", new List<Object> { }.ToArray(), otra);
                    byte[] b1 = sf.FileBytes;
                    String File = String.Concat(Path.GetTempPath().ToString(), Path.DirectorySeparatorChar.ToString(), Path.GetRandomFileName().ToString(), "");
                    fs1 = new FileStream(File, FileMode.Create);
                    fs1.Write(b1, 0, b1.Length);
                    fs1.Close();
                    fs1 = null;
                    o.Close();

                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = sf.MimeType;
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
                    HttpContext.Current.Response.WriteFile(File);
                    HttpContext.Current.Response.Flush();
                    System.IO.File.Delete(File);
                    HttpContext.Current.Response.End();
                }
            }
        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            String RFCaux = RFC.CalcularRFC(txtNombre.Text
                                        , txtPrimerApellido.Text
                                        , txtSegundoApellido.Text
                                        , DateTime.Now
                );
            txtRFC1.Text = RFCaux.Substring(0, 4);
        }

        protected void txtRFC3_TextChanged(object sender, EventArgs e)
        {
            txtCURP.Text = String.Concat(txtRFC1.Text, txtRFC2.Text);
        }

        protected void btnCerrarNoEncontrado_Click(object sender, EventArgs e)
        {
            mdlNoEncontado.Hide();
        }

        protected void grdDec_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(((Button)e.Row.FindControl("btnGridDeclaracion")));
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(((Button)e.Row.FindControl("btnGridDeclaracionConflicto")));
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(((Button)e.Row.FindControl("btnGridDeclaracionAcuse")));
            }
        }
        private void DeclaHistorico(string Emps,string Ids,string T_ds,string Anios,string Rep)
        {
            Int32 Tipo=0;
            Int32 Ianio = Convert.ToInt32(Anios);
            switch (T_ds)
            {
                case "Inicial":
                    Tipo=1;
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
            DeclaraINEAdmin.Legacy.fileSoapClient o = new Legacy.fileSoapClient();
            FileStream fs1;
            byte[] b1 =o.Acuse(Convert.ToInt32(Emps), Convert.ToInt32(Ids), Tipo, Ianio, Rep);
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

        private void DeclaracionHistorico(string Emps, string Ids, string T_ds, string Anios, string Rep)
        {
            Int32 Tipo = 0;
            Int32 Ianio = Convert.ToInt32(Anios);
            byte[] b1=null;
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
            DeclaraINEAdmin.Legacy.fileSoapClient o = new Legacy.fileSoapClient();
            FileStream fs1;
            if(Tipo==1)
            {
                b1 =o.Inicial( Convert.ToInt32(Emps), Convert.ToInt32(Ids), Tipo, Ianio, Rep);
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

        private void ConfliHistorico(string Emps, string Ids)
        {
            string Dia = Ids.Substring(0, 10);
            Int32 Emp = Convert.ToInt32(Emps.ToString());
            Int32 Control = Convert.ToInt32(Ids.Substring(10, 2));

            DeclaraINEAdmin.Legacy.fileSoapClient o = new Legacy.fileSoapClient();
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

            DeclaraINE.Legacy.fileSoapClient o = new DeclaraINE.Legacy.fileSoapClient();
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

            DeclaraINE.Legacy.fileSoapClient o = new DeclaraINE.Legacy.fileSoapClient();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region RFCS2
            List<String> str = new List<string>();
            str.Add("ROCP910326NP2");
            str.Add("VEVI760120FN8");
            str.Add("GOMG761006BI1");
            str.Add("HETR900917K80");
            str.Add("ZASA760812AR0");
            str.Add("SOTJ910505P99");
            str.Add("HERO930414KB9");
            str.Add("HEGE7710019E1");
            str.Add("HEGG830708CD0");
            str.Add("HERD920624LT2");
            str.Add("PITM861223787");
            str.Add("DOTJ890107HW3");
            str.Add("SATT830410584");
            str.Add("RESF890112K16");
            str.Add("FAUE930406N56");
            str.Add("FOTS820701EA9");
            str.Add("CUSM870118NK6");
            str.Add("AEHJ730622GC3");
            str.Add("BEJA890418D56");
            str.Add("BAZA890510237");
            str.Add("BAAD910920IL7");
            str.Add("GAPL671017M56");
            str.Add("OEGY800901HA1");
            str.Add("JAAE870707S51");
            str.Add("GARG750416PD0");
            str.Add("LUSJ930812NE2");
            str.Add("VECC880508JX7");
            str.Add("MALJ830803NW4");
            str.Add("JIHJ741216QH2");
            str.Add("BUHA900531RFA");
            str.Add("VAMH600620GTA");
            str.Add("MOSS8906305H2");
            str.Add("MIGJ180327KP2");
            str.Add("HIBE720721Q85");
            str.Add("RECG880810Q81");
            str.Add("AOVG900825PT4");
            str.Add("PONM900412LE0");
            str.Add("CUML930913AQ3");
            str.Add("VAED890918LP7");
            str.Add("LOAJ870817L50");
            str.Add("GACS910117924");
            str.Add("GAGF740605R96");
            str.Add("GACK891017LT1");
            str.Add("ZABA7411197F3");
            str.Add("ROML840922RWA");

            #endregion
            //#region RFCS

            //List<String> str = new List<string>();
            //str.Add("PEAR780415CQ4");
            //str.Add("COMY7909088I2");
            //str.Add("BAAW850314NP4");
            //str.Add("GOVE810123H74");
            //str.Add("GURA8003148BA");
            //str.Add("XEQR631129DU8");
            //str.Add("HEMM8008138Y7");
            //str.Add("GOHR831003UT0");
            //str.Add("CARA701219317");
            //str.Add("SALM700618SC4");
            //str.Add("MAMX5907144C6");
            //str.Add("LEQR830710G1A");
            //str.Add("SARC900411NR2");
            //str.Add("MAMX631109651");
            //str.Add("PIMC800620EB2");
            //str.Add("GAVD870302LZ1");
            //str.Add("MEMC8806184W8");
            //str.Add("ROSZ901126S39");
            //str.Add("DIHA740729488");
            //str.Add("SOOH631029UG8");
            //str.Add("GANO6707272U0");
            //str.Add("RIGG880604N20");
            //str.Add("LOVA6301278Y2");
            //str.Add("ROCO780219FA7");
            //str.Add("IACO851015EK6");
            //str.Add("MICC850423CR8");
            //str.Add("AIDJ750816GT1");
            //str.Add("MOCC920225EJA");
            //str.Add("RUBH660225P99");
            //str.Add("AAAR670810HU8");
            //str.Add("LULU930131381");
            //str.Add("AUBC6906261R3");
            //str.Add("NALJ820421HG7");
            //str.Add("HEOM740713FS3");
            //str.Add("VIGG840116CJ7");
            //str.Add("HETE600310N23");
            //str.Add("GARB6004167UA");
            //str.Add("MAMS880809L6A");
            //str.Add("QUBD750127AQ5");
            //str.Add("CUPR790905EE2");
            //str.Add("SAGY8704089I6");
            //str.Add("AAAL6604142YA");
            //str.Add("ZAMJ851211DB0");
            //str.Add("CECJ6206054G9");
            //str.Add("AEVE791019H85");
            //str.Add("SECL780824V55");
            //str.Add("ZAAG901212NL7");
            //str.Add("LOCX7203254TA");
            //str.Add("HUCE600314SU4");
            //str.Add("GURI690528DR3");
            //str.Add("OIMF6010159Q0");
            //str.Add("RAGO881026PM1");
            //str.Add("AURM6707143A0");
            //str.Add("CARB730819F5A");
            //str.Add("TIVA851129IV6");
            //str.Add("RUCH7505305C7");
            //str.Add("NURA610119Q58");
            //str.Add("GAJU800905229");
            //str.Add("PELE650321B68");
            //str.Add("BAGR780515214");
            //str.Add("GOSM671231TV4");
            //str.Add("SOGM770817MX1");
            //str.Add("MOUJ591212J67");
            //str.Add("AASR790308DZA");
            //str.Add("CAMP8609017L4");
            //str.Add("HECJ721116V66");
            //str.Add("BEMB711012PC2");
            //str.Add("MAMX720924AM0");
            //str.Add("RETM871101IH5");
            //str.Add("MECR550613IGA");
            //str.Add("COLA790628680");
            //str.Add("HECD770812668");
            //str.Add("HETF591010GU3");
            //str.Add("SAJG750918I32");
            //str.Add("MACJ661105CYA");
            //str.Add("BAHR861112519");
            //str.Add("MAHJ781225KE9");
            //str.Add("CAGX780717KH1");
            //str.Add("CAGX820420BR9");
            //str.Add("BACA5611274Z3");
            //str.Add("ROAH640512NP5");
            //str.Add("GAJC6701037C6");
            //str.Add("ROAF840224HY1");
            //str.Add("GACA7302181F8");
            //str.Add("ROMA690120V50");
            //str.Add("CARF7502047J0");
            //str.Add("BEPM7603267X9");
            //str.Add("MECF710309LJ6");
            //str.Add("PEME7409092J5");
            //str.Add("LUMC640707UI6");
            //str.Add("AARL840930V16");
            //str.Add("FEVH820730E9A");
            //str.Add("BARV790320EN2");
            //str.Add("CANR840810PE6");
            //str.Add("BEAA7203245U5");
            //str.Add("MESD7712074F0");
            //str.Add("LETJ761116857");
            //str.Add("MUHJ790117BK5");
            //str.Add("LEGV900518FZ8");
            //str.Add("TELJ700111HP6");
            //str.Add("NOGR6701096PA");
            //str.Add("LUAL7009096H7");
            //str.Add("CASC770323KZ6");
            //str.Add("TOFE820128RW6");
            //str.Add("SABB671204PR5");
            //str.Add("TISI850119NM9");
            //str.Add("VARE671104LJ8");
            //str.Add("PERY8405251Q1");
            //str.Add("EOCJ791130C76");
            //str.Add("OIGL850521E32");
            //str.Add("RIJJ731228FV7");
            //str.Add("SICJ831122MU7");
            //str.Add("VESL6902198TA");
            //str.Add("LOGA760828JS1");
            //str.Add("ROPC820608QY9");
            //str.Add("JUCR7304093L3");
            //str.Add("CACX620423DH9");
            //str.Add("TECM850121U17");
            //str.Add("VEVR681022MK9");
            //str.Add("MOMA740202UE2");
            //str.Add("JIME770921K32");
            //str.Add("VIBO5910055Z9");
            //str.Add("AAGP7603045U5");
            //str.Add("MEAX630523NH7");
            //str.Add("HEHG711019HPA");
            //str.Add("GUSG810703RE4");
            //str.Add("FEGI860831BFA");
            //str.Add("MEMC650101A58");
            //str.Add("SAML800229G73");
            //str.Add("GOCJ750523935");
            //str.Add("VAML891029TF4");
            //str.Add("CAGJ900215TR7");
            //str.Add("LOPC7108056VA");
            //str.Add("MAML7309146U0");
            //str.Add("AADJ6102092N3");
            //str.Add("CURA860827JP3");
            //str.Add("CAMJ6710202H5");
            //str.Add("PEAV711018QD8");
            //str.Add("SUOG690407JN9");
            //str.Add("GOAH810307UJ0");
            //str.Add("CALC820309MU5");
            //str.Add("HEHV8007165X0");
            //str.Add("UIEN6112044L1");
            //str.Add("CELB7008199H2");
            //str.Add("CERD640716M13");
            //str.Add("GODR7801064V2");
            //str.Add("COHJ6809307B4");
            //str.Add("COGX640924545");
            //str.Add("LOJU681126KI0");
            //str.Add("GOHX851024JM6");
            //str.Add("MAGA7410239A5");
            //str.Add("CAGI8501206K7");
            //str.Add("RAJA770320BG7");
            //str.Add("HEOR660507T21");
            //str.Add("LOOY8403311N9");
            //str.Add("MOCJ6501031V2");
            //str.Add("FAGD820304D85");
            //str.Add("SOPG940305GM9");
            //str.Add("AAMG840814QFA");
            //str.Add("OINO780902N74");
            //str.Add("PARA610112IHA");
            //str.Add("LEDE920702CP9");
            //str.Add("GUCJ760215RE4");
            //str.Add("GOJC680716AM0");
            //str.Add("RAPC89102194A");
            //str.Add("PESG870906350");
            //str.Add("BUNE740516AW8");
            //str.Add("BATS760215MW3");
            //str.Add("MAGC851006DJ2");
            //str.Add("RUJE550625EI6");
            //str.Add("EUAA671207FV4");
            //str.Add("POPO830523785");
            //str.Add("OEFJ820628734");
            //str.Add("AASA860512IC3");
            //str.Add("SAQM690923KQ1");
            //str.Add("MECK850514687");
            //str.Add("SACW8911138E3");
            //str.Add("MAMX6708189B0");
            //str.Add("SAEL800925C89");
            //str.Add("CAGX861117BH9");
            //str.Add("PEBA710403HN4");
            //str.Add("LEPH6903256X9");
            //str.Add("NUAE720217QW7");
            //str.Add("DIHL7803283V3");
            //str.Add("GOFE910130GS5");
            //str.Add("CATA8709258E9");
            //str.Add("RALB920503FW3");
            //str.Add("PUBC6311013U5");
            //str.Add("TOLA841122Q73");
            //str.Add("MOSJ7901188T7");
            //str.Add("SACP860221BY6");
            //str.Add("PAVE860103F78");
            //str.Add("LONA9502273N3");
            //str.Add("RELD850818JQ9");
            //str.Add("GALN9008148B5");
            //str.Add("AISR850802L36");
            //str.Add("MAFR900613JA5");
            //str.Add("MABC850724S18");
            //str.Add("MERJ621225RZ5");
            //str.Add("MOBJ731128BV8");
            //str.Add("GAFN810704HCA");
            //str.Add("AIGA691210Q64");
            //str.Add("GEVL910620CT8");
            //str.Add("CASH901228HI7");
            //str.Add("NAGL900917TY0");
            //str.Add("OERM720125DP5");
            //str.Add("VERH900426UZ9");
            //str.Add("VEPL890615DL9");
            //str.Add("MEIL9408076M9");
            //str.Add("RASA8410175ZA");
            //str.Add("MERA830323EB5");
            //str.Add("LOZS680505AX4");
            //str.Add("MAKP570113JI8");
            //str.Add("HIPD820612NM8");
            //str.Add("ZAAA650716FX2");
            //str.Add("JIVA8910261VA");
            //str.Add("GUFN630501RW6");
            //str.Add("COVR7704286FA");
            //str.Add("DUSJ840926GAA");
            //str.Add("MAMX821116JSA");
            //str.Add("IARJ790714QJ8");
            //str.Add("GOSE820731LX7");
            //str.Add("GAAA730720AAA");
            //str.Add("AOYB740408HQ7");
            //str.Add("PATM720601SG8");
            //str.Add("LOGM891113UY3");
            //str.Add("GAEM670223U15");
            //str.Add("AEAL6905023E6");
            //str.Add("HEGJ830508DN3");
            //str.Add("MOLJ720319TU1");
            //str.Add("SAZR730825CH0");
            //str.Add("HEGJ8412211T2");
            //str.Add("HEOJ840525HC7");
            //str.Add("MEGK820221C50");
            //str.Add("AACE7301318V4");
            //str.Add("CIPP830317MY9");
            //str.Add("FOVC85092872A");
            //str.Add("HESC9012291Q3");
            //str.Add("GOVN770530MG1");
            //str.Add("RUML670101C68");
            //str.Add("ROCA6704245S4");
            //str.Add("GAGR750205J11");
            //str.Add("IAAA870427ER6");
            //str.Add("MEGK711104URA");
            //str.Add("BASR820530LY5");
            //str.Add("EIJR8011144R6");
            //str.Add("FIPL891221LP0");
            //str.Add("VANO910615I27");
            //str.Add("CAAJ8904258X3");
            //str.Add("VERG791114AZ8");
            //str.Add("BORJ6805169F2");
            //str.Add("VEMA800610HP2");
            //str.Add("PEGJ881201IA6");
            //str.Add("FAVR810710BM4");
            //str.Add("GOBE851031766");
            //str.Add("ZAAM710116UA7");
            //str.Add("PASE6006219E2");
            //str.Add("COHJ760913RW1");
            //str.Add("GANA851124V82");
            //str.Add("RUNS771008AA9");
            //str.Add("MAMA860507GA7");
            //str.Add("NAHG810417JB8");
            //str.Add("ROBF860417HN1");
            //str.Add("CAIM801025T25");
            //str.Add("BEHC6705315T6");
            //str.Add("GARA7911294M4");
            //str.Add("GARE780113L28");
            //str.Add("RERR530327Q99");
            //str.Add("GEZJ720311A37");
            //str.Add("COTP641028DQ2");
            //str.Add("SARR780402DTA");
            //str.Add("EIGS800505AN5");
            //str.Add("UIMD771106A43");
            //str.Add("AURJ6506273X9");
            //str.Add("ROBE8405178I3");
            //str.Add("CAMI670703TI2");
            //str.Add("HEGL6710178G9");
            //str.Add("GAAL881226ED8");
            //str.Add("BUBL841223220");
            //str.Add("IITT590301RY2");
            //str.Add("TAMD850913EY0");
            //str.Add("LIOO750721BV6");
            //str.Add("EIVA7603248J0");
            //str.Add("MEJR740118AK4");
            //str.Add("TERA700923TK8");
            //str.Add("ROGS770619QI9");
            //str.Add("PIVA800923D81");
            //str.Add("MAES540902CR8");
            //str.Add("CASN830417CX7");
            //str.Add("RAPM790606LJ1");
            //str.Add("OEHF751009KK2");
            //str.Add("TOJN6910215A9");
            //str.Add("CAGF8403162I8");
            //str.Add("JIHJ770830U4A");
            //str.Add("LOSF651216AU0");
            //str.Add("GAHU780418ECA");
            //str.Add("ROHJ830722PCA");
            //str.Add("LUDD9005139Q6");
            //str.Add("CAGX740321KW0");
            //str.Add("CAGX820715328");
            //str.Add("IUMA851205257");
            //str.Add("AACE860127NR3");
            //str.Add("SOGA760221UEA");
            //str.Add("LAAR8506121BA");
            //str.Add("MAMD761110AP1");
            //str.Add("VAMA9303224A5");
            //str.Add("QUCJ7006263E6");
            //str.Add("CANC8803235Z1");
            //str.Add("TUGJ870309BA1");
            //str.Add("MUMB810611AXA");
            //str.Add("GALL731002HY9");
            //str.Add("MAMG7808269W1");
            //str.Add("GOVL7002143L4");
            //str.Add("GOCY790424JI8");
            //str.Add("AIAG870529DWA");
            //str.Add("SAGR8806035I0");
            //str.Add("FOBS810208L66");
            //str.Add("AUFE590405884");
            //str.Add("AEHE851206SZ7");
            //str.Add("BERA690610V40");
            //str.Add("HEGR770517SM8");
            //str.Add("VEBJ821014LL6");
            //str.Add("SESA750627F7A");
            //str.Add("AOTR870830CI6");
            //str.Add("NASE7611267T5");
            //str.Add("MORL741114AX0");
            //str.Add("RIMJ770818846");
            //str.Add("BEBR8906103S4");
            //str.Add("ROMF780930AA7");
            //str.Add("REPL7403152L7");
            //str.Add("VAAA810227EB6");
            //str.Add("GOSS851231B76");
            //str.Add("MOGM730811JS2");
            //str.Add("FOMK880228DG1");
            //str.Add("FOPJ680521J25");
            //str.Add("CAHJ690819311");
            //str.Add("LOCX641102631");
            //str.Add("BOCR700101LZ4");
            //str.Add("AAGJ850618AW5");
            //str.Add("CAGM860223KA7");
            //str.Add("VIFR831018V23");
            //str.Add("GEJM8004258A4");
            //str.Add("RACJ820906JN3");
            //str.Add("CUGH8509191B5");
            //str.Add("JAHG7806236E1");
            //str.Add("PUGJ820822BN0");
            //str.Add("EAMM780830K68");
            //str.Add("SOPI940620P22");
            //str.Add("MAHA920910CG7");
            //str.Add("HEMC610807SI0");
            //str.Add("ROFD830207U86");
            //str.Add("BEMZ911001DA6");
            //str.Add("HEVH810303452");
            //str.Add("GANE670710AH4");
            //str.Add("GAMH9005154G4");
            //str.Add("SAHM680626MR7");
            //str.Add("PEGE890221QW5");
            //str.Add("SACG680511S44");
            //str.Add("CAAA750624432");
            //str.Add("FOVE520418CD6");
            //str.Add("LOAF781021TX5");
            //str.Add("PEFE710922TS9");
            //str.Add("BAAG870727HA2");
            //str.Add("GACM780315RQ2");
            //str.Add("IAOI760409I26");
            //str.Add("MAGF7807256Y4");
            //str.Add("MALO660426SE4");
            //str.Add("SAOM661214UC3");
            //str.Add("HEOA910815AQ2");
            //str.Add("BESP730522H45");
            //str.Add("RAGK8901131I1");
            //str.Add("FIGA6803068S6");
            //str.Add("BIMA760814FC7");
            //str.Add("AEIS7206186H0");
            //str.Add("MUHH740325V27");
            if (!Directory.Exists("C:\\Consultas"))
                Directory.CreateDirectory("C:\\Consultas");
            //File.Create("C:\\Consultas\\NoEncontrados.txt");
            //File.Create("C:\\Consultas\\Errores.txt");
            //File.Create("C:\\Consultas\\Hecho.txt");
            //#endregion
            foreach (String strElement in str)
            {
                try
                {
                    this.VID_RFC = strElement;
                    blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                    o.VID_NOMBRE = new Declara_V2.StringFilter(VID_RFC.Substring(0, 4));
                    o.VID_FECHA = new Declara_V2.StringFilter(VID_RFC.Substring(4, 6));
                    o.VID_HOMOCLAVE = new Declara_V2.StringFilter(VID_RFC.Substring(10, 3));
                    o.NID_ESTADOs.FilterCondition = ListFilter.FilterConditions.Negated;
                    o.NID_ESTADOs.Add(1);
                    o.NID_ESTADOs.Add(6);
                    o.NID_ESTADOs.Add(7);
                    o.select();
                    List<Declara_V2.BLLD.DeclaracionesInformeDetalle> Declaraciones = new List<Declara_V2.BLLD.DeclaracionesInformeDetalle>();
                    String C_CURP = String.Empty;
                    String C_GENERO = "S";
                    //int Nempleado = 0;
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
                        C_CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
                        C_GENERO = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
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
                            C_CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
                            C_GENERO = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
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
                                              , dec.F_ENVIO.ToString("dd/MM/yyyy") + "."
                                              , dec.NID_ESTADO)
                                                                          );
                    }

                    DeclaraINEAdmin.Legacy.fileSoapClient DeclaracionesAnteriores = new DeclaraINEAdmin.Legacy.fileSoapClient();
                    DeclaraINE.Legacy.fileSoapClient DeclaracionesAnt2010 = new DeclaraINE.Legacy.fileSoapClient();
                    DeclaraINEAdmin.Legacy.ListaDeclara[] ListaAnteriores = DeclaracionesAnteriores.Consulta(VID_RFC);
                    DeclaraINE.Legacy.ListaAnt2010[] listaAnt2010 = DeclaracionesAnt2010.Consulta2010(VID_RFC);
                    DeclaracionesAnteriores.Close();
                    DeclaracionesAnt2010.Close();

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
                        Declaraciones.Add(
                                               new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                                1
                                              , ListaAnteriores[x].Anio.ToString()
                                              , ListaAnteriores[x].ID_Declara
                                              , NID_TIPO
                                              , ListaAnteriores[x].Fec_Envio + "," + ListaAnteriores[x].Num_Empleado + "," + ListaAnteriores[x].RFC
                                              //, null)); Artificio para llevar en numero de empleado
                                              , ListaAnteriores[x].Clasifica));
                    }
                    for (int y = 0; y < listaAnt2010.Count(); y++)
                    {
                        Int32 NID_TIPO_ANT;
                        switch (listaAnt2010[y].TIP_DECLARACION)
                        {
                            case "1":
                                NID_TIPO_ANT = 1;
                                break;
                            case "2":
                                NID_TIPO_ANT = 3;
                                break;
                            case "4":
                                NID_TIPO_ANT = 2;
                                break;
                            default:
                                NID_TIPO_ANT = 0;
                                break;
                        }

                        Declaraciones.Add(
                                              new Declara_V2.BLLD.DeclaracionesInformeDetalle(
                                               0
                                             , listaAnt2010[y].ANIO.ToString()
                                             , listaAnt2010[y].ID_DECLARACION
                                             , NID_TIPO_ANT
                                             , listaAnt2010[y].RFC
                                             , 2));

                    }

                    grdDec.DataSource = Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToArray();
                    grdDec.DataBind();

                    Declara_V2.BLLD.DeclaracionesInforme DetalleAux = new Declara_V2.BLLD.DeclaracionesInforme(VID_RFC
                                                      , C_CURP
                                                      , oUsuarioDeclaracion.V_NOMBRE_COMPLETO
                                                      , Declaraciones.OrderBy(p => p.NID_ORIGEN).ThenBy(p => p.C_EJERCICIO).ToList()
                                                       );


                    Detalle = new file.DeclaracionesInforme();
                    Detalle.V_FECHA_CONSULTA = DetalleAux.V_FECHA_CONSULTA;
                    Detalle.V_HORA_CONSULTA = DetalleAux.V_HORA_CONSULTA;
                    Detalle.V_RFC = DetalleAux.V_RFC;
                    Detalle.V_CURP = DetalleAux.V_CURP;
                    Detalle.V_SELLO = DetalleAux.V_SELLO;
                    Detalle.V_NOMBRE = DetalleAux.V_NOMBRE;
                    List<DeclaraINEAdmin.file.DeclaracionesInformeDetalle> ListaDeclaraciones = new List<DeclaraINEAdmin.file.DeclaracionesInformeDetalle>();

                    foreach (Declara_V2.BLLD.DeclaracionesInformeDetalle item in DetalleAux.DECLARACIONES)
                    {
                        Int32 NID_TIPO_DECLARACION = item.NID_TIPO_DECLARACION;
                        if (NID_TIPO_DECLARACION == 2)
                        {
                            switch (C_GENERO)
                            {
                                case "M":
                                    NID_TIPO_DECLARACION = 22;
                                    break;
                                case "F":
                                    NID_TIPO_DECLARACION = 21;
                                    break;
                                default:
                                    NID_TIPO_DECLARACION = 20;
                                    break;
                            }
                        }
                        if (item.NID_ORIGEN == 0)
                            item.F_PRESENTACION = item.C_EJERCICIO;
                        if (item.NID_ORIGEN != 0)
                            item.F_PRESENTACION = item.F_PRESENTACION.Substring(0, 10);
                        ListaDeclaraciones.Add(new file.DeclaracionesInformeDetalle
                        {
                            NID_ORIGEN = item.NID_ORIGEN,
                            C_EJERCICIO = item.C_EJERCICIO,
                            NID_DECLARACION = item.NID_DECLARACION,
                            NID_TIPO_DECLARACION = NID_TIPO_DECLARACION,
                            V_TIPO_DECLARACION = item.V_TIPO_DECLARACION,
                            F_PRESENTACION = item.F_PRESENTACION,
                            NID_ESTADO = item.NID_ESTADO,
                            V_ESTADO = item.V_ESTADO,
                        });
                    }

                    Detalle.DECLARACIONES = ListaDeclaraciones.ToArray();

                    if (Detalle.DECLARACIONES.Count() > 0)
                    {
                        file.fileSoapClient otro = new file.fileSoapClient();
                        FileStream fs1;
                        DeclaraINEAdmin.file.SerializedFile sf = otro.ObtenReportePorId_DataSource(FileServiceCredentials, 5, "DECLARACIONES_PRESENTADAS", new List<Object> { }.ToArray(), Detalle);
                        byte[] b1 = sf.FileBytes;
                        String File = String.Concat("C:\\Consultas", Path.DirectorySeparatorChar, VID_RFC, ".pdf");
                        fs1 = new FileStream(File, FileMode.Create);
                        fs1.Write(b1, 0, b1.Length);
                        fs1.Close();
                        fs1 = null;
                        otro.Close();
                        System.IO.File.AppendAllText("C:\\Consultas\\Hecho.txt", VID_RFC + Environment.NewLine);
                    }
                    else
                    {
                        File.AppendAllText("C:\\Consultas\\NoEncontrados.txt",VID_RFC + Environment.NewLine);
                    }
                  
                }
                catch (Exception ex)
                {
                    File.AppendAllText("C:\\Consultas\\Errores.txt", VID_RFC + ex.Message + Environment.NewLine + Environment.NewLine);
                }
            }
            AlertaBusqueda.ShowSuccess("Listo");
        }
    }
}