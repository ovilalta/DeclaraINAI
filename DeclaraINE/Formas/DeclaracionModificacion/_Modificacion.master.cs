using AlanWebControls;
using Declara_V2.BLLD;
using DeclaraINAI.file;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas.DeclaracionModificacion
{
    public partial class _Modificacion : System.Web.UI.MasterPage
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
        protected void Page_Init(object sender, EventArgs e)
        {
            if (_oDeclaracion == null)
                Response.Redirect("~/Formas/Index.aspx");

            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
            oPuesto.select();
            if (String.IsNullOrEmpty(Page.Title))
                Page.Title = "Declaración Modificación";
            else
                Page.Title = String.Concat("Declaración Modificación: ", Page.Title);
            if (!IsPostBack)
            {
                this.lblEjercicio.Text = string.Concat("Ejercicio :", oDeclaracion.C_EJERCICIO);
                this.lblIdentificacion.Text = string.Concat("Declaración Modificación ", oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, " - ", oUsuario.V_NOMBRE_COMPLETO);
            }
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
            {
                var o = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single();
                bool? obligado = o.L_OBLIGADO;
                if (obligado != null)
                    if (obligado.Equals(false))
                    {
                        lkDependientesEconomicos.Visible = false;

                    }
                    else
                    {
                        lkDependientesEconomicos.Visible = true;

                    }
            }

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
            {

                var o = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single();

                bool? obligado = o.L_OBLIGADO;
                if (obligado != null)
                {
                    if (obligado.Equals(false))
                    {
                        liBienes.Visible = false;
                        liInversiones.Visible = false;
                        imgAdeudos.Visible = false;
                        liAdeudos.Visible = false;
                        //liObservaciones.Visible = true;
                        liComodato.Visible = false;
                        liConflictoInteres.Visible = false;
                        lkDependientesEconomicos.Visible = false;
                    }
                    else
                    {
                        liBienes.Visible = true;
                        liInversiones.Visible = true;
                        imgAdeudos.Visible = true;
                        liAdeudos.Visible = true;
                        liComodato.Visible = true;
                        liConflictoInteres.Visible = true;
                        //liFiscal.Visible = true;
                    }

                    //Mostramos los botones de vista previa
                    lkImprimir1.Visible = true;
                    LinkButton1.Visible = true;
                    lkImprimir2.Visible = true;
                    lkImprimir6.Visible = true;
                    lkImprimir3.Visible = true;
                    LinkButton4.Visible = true;
                    lkImprimir4.Visible = true;
                    lkImprimir8.Visible = true;
                    lkImprimir5.Visible = true;
                }

                liObservaciones.Visible = true;
                liFiscal.Visible = true;
                liIngresos.Visible = true;
                //liDesemp.Visible = true;

                liEnvio.Visible = true;
                menu2.Visible = true;
                menu3.Visible = true;
                menu4.Visible = true;
                menu5.Visible = true;
                menu6.Visible = true;
                menu7.Visible = true;
                menu8.Visible = true;
                menu9.Visible = true;
                menu10.Visible = true;
                menu17.Visible = true;

                imgDatosGenerales.Src = "../../Content/ok.png";
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                    this.lblEjercicio.Visible = true;
                else
                    this.lblEjercicio.Visible = false;
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO.Value)
                    imgBienes.Src = "../../Content/ok.png";
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                {
                    imgInversiones.Src = "../../Content/ok.png";
                    lkInversiones.CssClass = "complete";
                }
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                {
                    imgAdeudos.Src = "../../Content/ok.png";
                    lkAdeudos.CssClass = "complete";
                }
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                {
                    imgObservaciones.Src = "../../Content/ok.png";
                    lkObservaciones.CssClass = "complete";
                }
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                {
                    imgConflictoInteres.Src = "../../Content/ok.png";
                    lknConflicto.CssClass = "complete";
                }
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                {
                    imgEnvio.Src = "../../Content/ok.png";
                    lkEnvio.CssClass = "complete";
                }

                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                {
                    imgIngresos.Src = "../../Content/ok.png";
                    lkIngresos.CssClass = "complete";
                }

                //if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                //{
                //    imgDesemp.Src = "../../Content/ok.png";
                //    lkDesemp.CssClass = "complete";
                //}

                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                {
                    imgComodato.Src = "../../Content/ok.png";
                    lkComodato.CssClass = "complete";
                }

                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 22).First().L_ESTADO.Value)
                {
                    imgFiscal.Src = "../../Content/ok.png";
                    lkFiscal.CssClass = "complete";
                }

                links_Bienes(ref oDeclaracion);
            }

            links_DatosGenerales(ref oDeclaracion);
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

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 16).First().L_ESTADO.Value)
                lnkDatosCurriculares.CssClass = "complete";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 17).First().L_ESTADO.Value)
                lnkExperienciaLaboral.CssClass = "complete";

        }


        public void links_Bienes(ref blld_DECLARACION oDeclaracion)
        {
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                lkBienesInmuebles.CssClass = "complete";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                lkBienesMuebles.CssClass = "complete";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                lkVehiculos.CssClass = "complete";
        }


        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            IDeclaracionInicial pageInterface = Page as IDeclaracionInicial;
            if (pageInterface != null)
            {
                pageInterface.Anterior();
            }
        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    IDeclaracionInicial pageInterface = Page as IDeclaracionInicial;
        //    if (pageInterface != null)
        //    {
        //        pageInterface.Guardar();
        //    }

        //}

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            IDeclaracionInicial pageInterface = Page as IDeclaracionInicial;
            if (pageInterface != null)
            {
                pageInterface.Siguiente();
            }
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
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).SubSeccionActiva = DatosGenerales.SubSecciones.Cargo;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).lBanderaActualizaAnterior = false;
                ((DatosGenerales)((Panel)ChildContent2.FindControl(DatosGenerales.Paneles.pnlDatosPersonales.ToString())).Page).Siguiente();
            }
            catch
            {
                ControlDeNavegacion = DatosGenerales.SubSecciones.Cargo;
                Response.Redirect("DatosGenerales.aspx");
            }
        }

        protected void lkDependientesEconomicos_Click(object sender, EventArgs e)
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
        protected void lkBienesInmuebles_Click(object sender, EventArgs e)
        {
            try
            {
                btnAnterior.Visible = true;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.BienesInmuebles.ToString())).Page).SubSeccionActiva = Bienes.SubSecciones.BienesInmuebles;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.OtrosBienes.ToString())).Page).lBanderaActualizaAnterior = false;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.Vehiculos.ToString())).Page).Siguiente();
            }
            catch (Exception ex)
            {
                ControlDeNavegacion = Bienes.SubSecciones.BienesInmuebles;
                Response.Redirect("Bienes.aspx");
            }
        }

        protected void lkBienesMuebles_Click(object sender, EventArgs e)
        {
            try
            {
                btnAnterior.Visible = true;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.BienesInmuebles.ToString())).Page).SubSeccionActiva = Bienes.SubSecciones.OtrosBienes;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.OtrosBienes.ToString())).Page).lBanderaActualizaAnterior = false;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.Vehiculos.ToString())).Page).Siguiente();
            }
            catch
            {
                ControlDeNavegacion = Bienes.SubSecciones.OtrosBienes;
                Response.Redirect("Bienes.aspx");
            }
        }


        protected void lkVehiculos_Click(object sender, EventArgs e)
        {
            try
            {
                btnAnterior.Visible = true;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.BienesInmuebles.ToString())).Page).SubSeccionActiva = Bienes.SubSecciones.Vehiculos;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.OtrosBienes.ToString())).Page).lBanderaActualizaAnterior = false;
                ((Bienes)((Panel)ChildContent2.FindControl(Bienes.SubSecciones.Vehiculos.ToString())).Page).Siguiente();
            }
            catch
            {
                ControlDeNavegacion = Bienes.SubSecciones.Vehiculos;
                Response.Redirect("Bienes.aspx");
            }
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

        protected void lkFiscal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DeclaracionFiscal/declaracionFiscal.aspx");
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
            try
            {

                String VersionDeclaracion = string.Empty;
                blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                oPuesto.select();

                var obligado = oPuesto.lista_CAT_PUESTO.ToList().Where(p => p.NID_PUESTO.Equals(oDeclaracion.DECLARACION_CARGO.NID_PUESTO)).Single().L_OBLIGADO;
                if (obligado.Equals(true))
                    VersionDeclaracion = "DECLARACION_MODIFICACION";
                else
                    VersionDeclaracion = "DECLARACION_MODIFICACION_SIMPLI";

                String Preeliminar = lImprimeMarcaDeAgua ? "Preliminar" : "Naaaa";
                file.fileSoapClient o = new file.fileSoapClient();
                FileStream fs1;
                SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, VersionDeclaracion, new List<object> { oDeclaracion.VID_NOMBRE
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
                //System.IO.File.Delete(File);
                //HttpContext.Current.Response.End();

            }
            catch (Exception ex)
            {
            }
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

        public static void ImprimirAcuseModificacion(blld_DECLARACION oDeclaracion, blld_USUARIO oUsuario)
        {

            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 2020, "ACUSE_MODIFICACION", new List<object> { oUsuario.VID_NOMBRE
                                                                               ,oUsuario.VID_FECHA
                                                                               ,oUsuario.VID_HOMOCLAVE
                                                                               ,oDeclaracion.NID_DECLARACION
                                                                               ,"Preliminarx"}.ToArray());
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + sf.FileName);
            HttpContext.Current.Response.OutputStream.Write(sf.FileBytes, 0, sf.FileBytes.Length);
            HttpContext.Current.Response.OutputStream.Close();
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

    }
    internal interface IDeclaracionInicial
    {
        void Anterior();
        //void Guardar();
        void Siguiente();
    }
}

