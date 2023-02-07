using Declara_V2.BLLD;
using System;
using System.IO;
using System.Web;
using System.Linq;
using DeclaraINE.file;
using System.Collections.Generic;
using Declara_V2.MODELextended;
using Declara_V2;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.BLL;

namespace DeclaraINE.Formas.DeclaracionConflicto
{
    public partial class _Conflicto : System.Web.UI.MasterPage
    {

        protected void Page_Error(object sender, EventArgs e)
        {
        }
        protected void SessionAdd(String ObjectName, Object Objeto)
        {
            if (Session[ObjectName] == null) Session.Add(ObjectName, Objeto);
            else Session[ObjectName] = Objeto;
        }
        protected Object ControlDeNavegacion
        {
            get => Session["ControlDeNavegacion"];
            set => SessionAdd("ControlDeNavegacion", value);
        }


        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        public void CambiaEstadoDeclaracion(int param)
        {
            //ACTUALIZAR FECHA CON SP
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            string connString = db.Database.Connection.ConnectionString;
            string sql = "SP_CambiaEstadoDeclaracion";
            string sql2 = "SP_RecuperaUltimaDeclaracion";
            int rpta = 0;
            int numeroDeclaracion = 0;
            string ultimaDeclaracion = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(sql2, conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        da.SelectCommand.Parameters.Add(new SqlParameter("@vid_nombre", _oUsuario.VID_NOMBRE));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@vid_fecha", _oUsuario.VID_FECHA));
                        da.SelectCommand.Parameters.Add(new SqlParameter("@vid_homo", _oUsuario.VID_HOMOCLAVE));

                        DataTable dt = new DataTable();
                        dt.Clear();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ultimaDeclaracion = dt.Rows[i]["NID_DECLARACION"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            numeroDeclaracion = Convert.ToInt32(ultimaDeclaracion);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vid_nombre", _oUsuario.VID_NOMBRE);
                        cmd.Parameters.AddWithValue("@vid_fecha", _oUsuario.VID_FECHA);
                        cmd.Parameters.AddWithValue("@vid_homo", _oUsuario.VID_HOMOCLAVE);
                        cmd.Parameters.AddWithValue("@nid_declaracion", numeroDeclaracion);
                        cmd.Parameters.AddWithValue("@param", param);

                        rpta = cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    rpta = 0;
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {

            blld_USUARIO oUsuario = _oUsuario;
            CambiaEstadoDeclaracion(1);
            blld__l_DECLARACION oBusqueda = new blld__l_DECLARACION();
            oBusqueda.VID_NOMBRE = new Declara_V2.StringFilter(oUsuario.VID_NOMBRE);
            oBusqueda.VID_FECHA = new Declara_V2.StringFilter(oUsuario.VID_FECHA);
            oBusqueda.VID_HOMOCLAVE = new Declara_V2.StringFilter(oUsuario.VID_HOMOCLAVE);
            oBusqueda.NID_TIPO_DECLARACION = new Declara_V2.IntegerFilter(2);
            oBusqueda.NID_ESTADO = new Declara_V2.IntegerFilter(2);            
            oBusqueda.select();
            //datos_DECLARACION = new dald_DECLARACION(oBusqueda.lista_DECLARACION.Last());
            //blld_DECLARACION oDeclaracion = new blld_DECLARACION(oBusqueda.lista_DECLARACION.Last());
            
            //SessionAdd("oDeclaracion", oDeclaracion);


            if (!oBusqueda.lista_DECLARACION.Any())
            {

                //datos_DECLARACION = new dald_DECLARACION(oBusquedaDeclaracion.lista_DECLARACION.Last());
                //SessionAdd("oDeclaracion", oDeclaracion1);
            }
            else
            {
                blld_DECLARACION oDeclaracion1 = new blld_DECLARACION(oUsuario.VID_NOMBRE
                                                                    , oUsuario.VID_FECHA
                                                                    , oUsuario.VID_HOMOCLAVE
                                                                    //, (DateTime.Now.Year - 1).ToString()
                                                                    , 2
                                                                    , true);
                SessionAdd("oDeclaracion", oDeclaracion1);
            }


            if (_oDeclaracion == null)
                Response.Redirect("~/Formas/Index.aspx");
           blld_DECLARACION oDeclaracion = _oDeclaracion;
            
            //blld_USUARIO oUsuario = _oUsuario;
            blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
            oPuesto.select();
            if (String.IsNullOrEmpty(Page.Title))
                Page.Title = "Declaración Conflicto";
            else
                Page.Title = String.Concat("Declaración Conflicto: ", Page.Title);
            if (!IsPostBack)
            {
                // this.lblEjercicio.Text = string.Concat("Ejercicio :", oDeclaracion.C_EJERCICIO);
                this.lblEjercicio.Text = string.Empty;
                this.lblIdentificacion.Text = string.Concat("Declaración Conflicto ", oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, " - ", oUsuario.V_NOMBRE_COMPLETO);
            }
            CambiaEstadoDeclaracion(2);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Error += new System.EventHandler(this.Page_Error);
            if (!IsPostBack)
            {
                _oUsuario.ExtenderSesion();
            }
        }
        internal void links_DatosGenerales(ref blld_DECLARACION oDeclaracion)
        {
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonales.CssClass = "complete";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticular.CssClass = "complete";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
            {
                lkCargo.CssClass = "complete";
                this.lblEjercicio.Visible = true;
            }
            else
                this.lblEjercicio.Visible = false;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboral.CssClass = "complete";


            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicos.CssClass = "complete";

            //if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 16).First().L_ESTADO.Value)
            //    lnkDatosCurriculares.CssClass = "complete";

            //if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 17).First().L_ESTADO.Value)
            //    lnkExperienciaLaboral.CssClass = "complete";

        }


        public void links_Bienes(ref blld_DECLARACION oDeclaracion)
        {
            //if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
            //    lkBienesInmuebles.CssClass = "complete";

            //if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
            //    lkBienesMuebles.CssClass = "complete";

            //if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
            //    lkVehiculos.CssClass = "complete";
        }


        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            //IDeclaracionInicial pageInterface = Page as IDeclaracionInicial;
            //if (pageInterface != null)
            //{
            //    pageInterface.Anterior();
            //}
            Response.Redirect("../Index.aspx");
        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    IDeclaracionInicial pageInterface = Page as IDeclaracionInicial;
        //    if (pageInterface != null)
        //    {
        //        pageInterface.Guardar();
        //    }

        //}

        public void ActualizaFecha()
        {
            //ACTUALIZAR FECHA CON SP
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            string connString = db.Database.Connection.ConnectionString;
            string sql = "SP_FechaActualizaDecConflicto";
            int rpta = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vid_nombre", _oUsuario.VID_NOMBRE);
                        cmd.Parameters.AddWithValue("@vid_fecha", _oUsuario.VID_FECHA);
                        cmd.Parameters.AddWithValue("@vid_homo", _oUsuario.VID_HOMOCLAVE);
                        cmd.Parameters.AddWithValue("@nid_declaracion", _oDeclaracion.NID_DECLARACION);


                        rpta = cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    rpta = 0;
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            ActualizaFecha();
            CambiaEstadoDeclaracion(2);
            Response.Redirect("../Index.aspx");
        }

        protected void lkDatosPersonales_Click(object sender, EventArgs e)
        {

            try
            {

                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).SubSeccionActiva = DatosGenerales.SubSecciones.DomicilioParticular;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).lBanderaActualizaAnterior = false;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).Anterior();
                btnAnterior.Visible = false;
            }
            catch
            {
                Response.Redirect("DatosGenerales.aspx");
            }
        }

        protected void lkDomicilioParticular_Click(object sender, EventArgs e)
        {
            try
            {
                btnAnterior.Visible = true;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).SubSeccionActiva = DatosGenerales.SubSecciones.DatosPersonales;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).lBanderaActualizaAnterior = false;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).Siguiente();
            }
            catch
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DatosPersonales;
                Response.Redirect("DatosGenerales.aspx");
            }
        }

        protected void lkCargo_Click(object sender, EventArgs e)
        {
            try
            {
                btnAnterior.Visible = true;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).SubSeccionActiva = DatosGenerales.SubSecciones.DomicilioParticular;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).lBanderaActualizaAnterior = false;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).Siguiente();
            }
            catch
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioParticular;
                Response.Redirect("DatosGenerales.aspx");
            }
        }

        protected void lkDomicilioLaboral_Click(object sender, EventArgs e)
        {
            try
            {
                btnAnterior.Visible = true;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).SubSeccionActiva = DatosGenerales.SubSecciones.DomicilioLaboral;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).lBanderaActualizaAnterior = false;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).Siguiente();
            }
            catch
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DomicilioLaboral;
                Response.Redirect("DatosGenerales.aspx");
            }
        }

        protected void lkDependientesEconomicos_Click(object sender, EventArgs e)
        {
            try
            {
                btnAnterior.Visible = true;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).SubSeccionActiva = DatosGenerales.SubSecciones.DependienteEconomicos;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).lBanderaActualizaAnterior = false;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).Siguiente();
            }
            catch
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.DependienteEconomicos;
                Response.Redirect("DatosGenerales.aspx");
            }
        }
        protected void lkBienesInmuebles_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    btnAnterior.Visible = true;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.BienesInmuebles.ToString())).Page).SubSeccionActiva = Bienes.SubSecciones.BienesInmuebles;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.OtrosBienes.ToString())).Page).lBanderaActualizaAnterior = false;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.Vehiculos.ToString())).Page).Siguiente();
            //}
            //catch (Exception ex)
            //{
            //    ControlDeNavegacion = Bienes.SubSecciones.BienesInmuebles;
            //    Response.Redirect("Bienes.aspx");
            //}
        }

        protected void lkBienesMuebles_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    btnAnterior.Visible = true;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.BienesInmuebles.ToString())).Page).SubSeccionActiva = Bienes.SubSecciones.OtrosBienes;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.OtrosBienes.ToString())).Page).lBanderaActualizaAnterior = false;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.Vehiculos.ToString())).Page).Siguiente();
            //}
            //catch
            //{
            //    ControlDeNavegacion = Bienes.SubSecciones.OtrosBienes;
            //    Response.Redirect("Bienes.aspx");
            //}
        }


        protected void lkVehiculos_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    btnAnterior.Visible = true;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.BienesInmuebles.ToString())).Page).SubSeccionActiva = Bienes.SubSecciones.Vehiculos;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.OtrosBienes.ToString())).Page).lBanderaActualizaAnterior = false;
            //    ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.Vehiculos.ToString())).Page).Siguiente();
            //}
            //catch
            //{
            //    ControlDeNavegacion = Bienes.SubSecciones.Vehiculos;
            //    Response.Redirect("Bienes.aspx");
            //}
        }

        protected void lkInversiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inversiones.aspx");
        }

        protected void lkAdeudos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adeudos.aspx");
        }

        protected void lkObservaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Observaciones.aspx");
        }

        protected void lknConflicto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Conflicto.aspx");
        }

        protected void lkEnvio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Envio.aspx");
        }

        public static void Imprimir(blld_DECLARACION oDeclaracion, Boolean lImprimeMarcaDeAgua)
        {
            String Preeliminar = lImprimeMarcaDeAgua ? "Preliminar" : "Naaaa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 5, "DECLARACION_INICIAL", new List<object> { oDeclaracion.VID_NOMBRE
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

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Declara_V2.BLLD.blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["oDeclaracion"];
            Imprimir(oDeclaracion, true);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }
        protected void lkImprimir4_Click(object sender, EventArgs e)
        {
            Declara_V2.BLLD.blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["oDeclaracion"];
        }

        protected void lnkDatosCurriculares_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatosCurriculares.aspx");
        }

        protected void lnkExperienciaLaboral_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExperienciaLaboral.aspx");
        }

        protected void lkComodato_Click(object sender, EventArgs e)
        {
            Response.Redirect("Comodato.aspx");
        }

        protected void lkIngresos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ingresos.aspx");
        }

        protected void lkDesemp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Desemp.aspx");
        }

        public static void ImprimirAcuseConclusion(blld_DECLARACION oDeclaracion, blld_USUARIO oUsuario)
        {

            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, "ACUSE_CONCLUSION", new List<object> { oUsuario.VID_NOMBRE
                                                                               ,oUsuario.VID_FECHA
                                                                               ,oUsuario.VID_HOMOCLAVE
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
            HttpContext.Current.Response.ContentType = "application/pdf"; // sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        public static void ImprimirAcuseInicial(blld_DECLARACION oDeclaracion, blld_USUARIO oUsuario)
        {

            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, "ACUSE_MODIFICACON", new List<object> { oUsuario.VID_NOMBRE
                                                                               ,oUsuario.VID_FECHA
                                                                               ,oUsuario.VID_HOMOCLAVE
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
            HttpContext.Current.Response.ContentType = "application/pdf"; // sf.MimeType;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.WriteFile(File);
            HttpContext.Current.Response.Flush();
            System.IO.File.Delete(File);
            HttpContext.Current.Response.End();
        }

        protected void btnImprimir_Click2(object sender, EventArgs e)
        {
            ActualizaFecha();
            CambiaEstadoDeclaracion(2);
            Response.Redirect("../ImprimeActualizacionConflicto.aspx");  
        }


    }
    internal interface IDeclaracionInicial
    {
        void Anterior();
        //void Guardar();
        void Siguiente();
    }
}

