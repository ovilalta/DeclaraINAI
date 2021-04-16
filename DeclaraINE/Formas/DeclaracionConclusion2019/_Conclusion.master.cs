using AlanWebControls;
using Declara_V2.BLLD;
using DeclaraINE.file;
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

namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class _Conclusion : System.Web.UI.MasterPage
    {

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
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = _oUsuario;
            this.lblEjercicio.Text = string.Concat("Ejercicio :", oDeclaracion.C_EJERCICIO);
            this.lblIdentificacion.Text = string.Concat("Declaración de Conclusión ", oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, " - ", oUsuario.V_NOMBRE_COMPLETO);
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
            {
                liBienes.Visible = true;
                liInversiones.Visible = true;
                imgAdeudos.Visible = true;
                liAdeudos.Visible = true;
                liObservaciones.Visible = true;
                liConflictoInteres.Visible = true;
                liEnvio.Visible = true;
                //////liIngresos.Visible = true;
                //////liGastos.Visible = true;
                menu2.Visible = true;
                menu3.Visible = true;
                menu4.Visible = true;
                menu5.Visible = true;
                menu6.Visible = true;
                menu7.Visible = true;
                //////menu8.Visible = true;
                //////menu9.Visible = true;
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                    this.lblEjercicio.Visible = true;
                else
                    this.lblEjercicio.Visible = false;
                imgDatosGenerales.Src = "../../Content/ok.png";
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO.Value)
                    imgBienes.Src = "../../Content/ok.png";
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                    imgInversiones.Src = "../../Content/ok.png";
                if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                    imgAdeudos.Src = "../../Content/ok.png";
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


                links_Bienes(ref oDeclaracion);
                links_Inversiones(ref oDeclaracion);
                links_Adeudos(ref oDeclaracion);

            }

            links_DatosGenerales(ref oDeclaracion);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
                this.lblEjercicio.Visible = true;
                lkCargo.CssClass = "complete";
             }
            else
                this.lblEjercicio.Visible = false;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboral.CssClass = "complete";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicos.CssClass = "complete";
        }


        public void links_Bienes(ref blld_DECLARACION oDeclaracion)
        {

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesAct.CssClass = "complete";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesAct.CssClass = "complete";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosAct.CssClass = "complete";

            //if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 21).First().L_ESTADO.Value)
            //    lkDesincorpora.CssClass = "complete";
        }

        public void links_Inversiones(ref blld_DECLARACION oDeclaracion)
        {
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 24).First().L_ESTADO.Value)
                lkInversionesAct.CssClass = "complete";
        }

        public void links_Adeudos(ref blld_DECLARACION oDeclaracion)
        {
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 26).First().L_ESTADO.Value)
                lkAdeudosAct.CssClass = "complete";

        }

        //////public void links_Gastos(ref blld_DECLARACION oDeclaracion)
        //////{
        //////    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 29).First().L_ESTADO.Value)
        //////        lkTarjetas.CssClass = "complete";

        //////    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 30).First().L_ESTADO.Value)
        //////        lkImpuestos.CssClass = "complete";

        //////    if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 31).First().L_ESTADO.Value)
        //////        lkOtrosGastos.CssClass = "complete";
        //////}


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
    
        protected void lkInversiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("InversionesModifica.aspx");
        }

        protected void lkAdeudos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdeudosModifica.aspx");
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

        public static void Imprimir(blld_DECLARACION oDeclaracion,Boolean lPreliminar)
        {

            String strPreeliminar = lPreliminar ? "Preliminar" : "naa";
            file.fileSoapClient o = new file.fileSoapClient();
            FileStream fs1;
            SerializedFile sf = o.ObtenReportePorId(Pagina.FileServiceCredentials, 5, "DECLARACION_CONCLUSION", new List<Object> { oDeclaracion.VID_NOMBRE
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

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Declara_V2.BLLD.blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["oDeclaracion"];
            Imprimir(oDeclaracion,true);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void lkIngresos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ingresos.aspx");
        }

        protected void lkBienesInmueblesAct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificaInmuebles.aspx");
        }

        protected void lkBienesMueblesAct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificaMuebles.aspx");
        }

        protected void lkVehiculosAct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificaVehiculos.aspx");
        }

        protected void lkDesincorpora_Click(object sender, EventArgs e)
        {
            Response.Redirect("Desincorpora.aspx");
        }

        protected void lkInversionesAct_Click(object sender, EventArgs e)
        {
            Response.Redirect("InversionesModifica.aspx");
        }

        protected void lkAdeudosAct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdeudosModifica.aspx");
        }

        protected void lkTarjetas_Click(object sender, EventArgs e)
        {
            Response.Redirect("TarjetasDeCredito.aspx");
        }

        protected void lkImpuestos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImpuestosYRetenciones.aspx");
        }

        protected void lkOtrosGastos_Click(object sender, EventArgs e)
        {
            Response.Redirect("OtrosGastos.aspx");
        }


        protected void lkImprimir4_Click(object sender, EventArgs e)
        {
            Declara_V2.BLLD.blld_DECLARACION oDeclaracion = (blld_DECLARACION)Session["oDeclaracion"];
           ConsultaDeclaraciones.ImprimirDeclaracionConflicto(oDeclaracion,true);
        }
    }
    internal interface IDeclaracionInicial
    {
        void Anterior();
        //void Guardar();
        void Siguiente();
    }
}