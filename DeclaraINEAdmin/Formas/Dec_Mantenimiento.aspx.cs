using System;
using System.Collections.Generic;
using System.Globalization;
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


namespace DeclaraINEAdmin.Formas
{
    public partial class Dec_Mantenimiento : Pagina
    {
        public List<Int32> EjercicioAnio = new List<Int32>();

        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["Object1"];
            set => SessionAdd("Object1", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("Dec_Mantenimiento.aspx");
            if (!IsPostBack)
            {
                blld__l_CAT_TIPO_DECLARACION o = new blld__l_CAT_TIPO_DECLARACION();
                o.select();

                dpNT.DataBinder<blld__l_CAT_TIPO_DECLARACION>(new blld__l_CAT_TIPO_DECLARACION(), CAT_TIPO_DECLARACION.Properties.NID_TIPO_DECLARACION, CAT_TIPO_DECLARACION.Properties.V_TIPO_DECLARACION);

                dpED.DataBinder<blld__l_CAT_ESTADO_DECLARACION>(new blld__l_CAT_ESTADO_DECLARACION(), CAT_ESTADO_DECLARACION.Properties.NID_ESTADO, CAT_ESTADO_DECLARACION.Properties.V_ESTADO);
                foreach (ListItem item in dpED.Items)
                {
                    if ((new String[] { "1", "2", "3" }).Contains(item.Value))
                        item.Selected = true;
                }

                for (int i = 2010; i <= DateTime.Now.Year; i++)
                {
                    EjercicioAnio.Add(i);
                }

                txtFInicio_C.EndDate = DateTime.Today.AddDays(0);
                txtFFin_C.EndDate = DateTime.Today.AddDays(0);

                chNRFC.Checked = true;
                chnED.Checked = true;

            }
            pnlchchNRFC.Visible = chNRFC.Checked;
            pnlchNTD.Visible = chNTD.Checked;
            pnlchnFD.Visible = chnFD.Checked;
            pnlchnED.Visible = chnED.Checked;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                blld__l_DECLARACION_DIARIA o = new blld__l_DECLARACION_DIARIA();
                List<DECLARACION_DIARIA> Result = new List<DECLARACION_DIARIA>();

                if (chNRFC.Checked) if (txtRFC.Text != String.Empty)
                    {
                        if (txtRFC.Text.Length < 3) throw new CustomException("Escriba más caracteres para realizar la busqueda");
                    }
                    else
                        throw new CustomException("Debes completar los campos");

                //
                if (chNRFC.Checked) o.V_RFC = new Declara_V2.StringFilter(txtRFC.Text, StringFilter.FilterType.like);
                if (chnED.Checked)
                {
                    foreach (ListItem item in dpED.Items)
                    {
                        if (item.Selected)
                        {
                            o.NID_ESTADOs.Add(Convert.ToInt32(item.Value));
                        }
                    }
                }
                if (chNTD.Checked)
                {
                    foreach (ListItem item in dpNT.Items)
                    {
                        if (item.Selected)
                        {
                            o.NID_TIPO_DECLARACIONs.Add(Convert.ToInt32(item.Value));
                        }
                    }
                }
                if (chnFD.Checked) o.F_ENVIO = new DateTimeFilter(txtFInicio.Date(esMX), txtFFin.Date(esMX));
                o.select();
                foreach (DECLARACION_DIARIA i in o.lista_DECLARACION_DIARIA)
                    Result.Add(i);

                //
                o = new blld__l_DECLARACION_DIARIA();
                if (chNRFC.Checked) o.V_NOMBRE_COMPLETO = new Declara_V2.StringFilter(txtRFC.Text, StringFilter.FilterType.like);
                if (chNTD.Checked)
                {
                    foreach (ListItem item in dpNT.Items)
                    {
                        if (item.Selected)
                        {
                            o.NID_TIPO_DECLARACIONs.Add(Convert.ToInt32(item.Value));
                        }
                    }
                }
                if (chnED.Checked)
                {
                    foreach (ListItem item in dpED.Items)
                    {
                        if (item.Selected)
                        {
                            o.NID_ESTADOs.Add(Convert.ToInt32(item.Value));
                        }
                    }
                }
                if (chnFD.Checked) o.F_ENVIO = new DateTimeFilter(txtFInicio.Date(esMX), txtFFin.Date(esMX));
                o.select();
                foreach (DECLARACION_DIARIA i in o.lista_DECLARACION_DIARIA)
                    if (!Result.Where(p => p.VID_NOMBRE == i.VID_NOMBRE && p.VID_FECHA == i.VID_FECHA && p.VID_HOMOCLAVE == i.VID_HOMOCLAVE).Any())
                        Result.Add(i);

                //
                o = new blld__l_DECLARACION_DIARIA();
                if (chNRFC.Checked) o.V_NOMBRE_COMPLETO_ESTILO2 = new Declara_V2.StringFilter(txtRFC.Text, StringFilter.FilterType.like);
                if (chNTD.Checked)
                {
                    foreach (ListItem item in dpNT.Items)
                    {
                        if (item.Selected)
                        {
                            o.NID_TIPO_DECLARACIONs.Add(Convert.ToInt32(item.Value));
                        }
                    }
                }
                if (chnED.Checked)
                {
                    foreach (ListItem item in dpED.Items)
                    {
                        if (item.Selected)
                        {
                            o.NID_ESTADOs.Add(Convert.ToInt32(item.Value));
                        }
                    }
                }
                if (chnFD.Checked) o.F_ENVIO = new DateTimeFilter(txtFInicio.Date(esMX), txtFFin.Date(esMX));
                o.select();
                foreach (DECLARACION_DIARIA i in o.lista_DECLARACION_DIARIA)
                    if (!Result.Where(p => p.VID_NOMBRE == i.VID_NOMBRE && p.VID_FECHA == i.VID_FECHA && p.VID_HOMOCLAVE == i.VID_HOMOCLAVE).Any())
                        Result.Add(i);

                grdDec.DataSource = Result;
                grdDec.DataBind();

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaBusqueda.ShowDanger(ex.Message);
                else
                    throw ex;
            }
        }

        protected void btnGridDeclaracion_Click(object sender, EventArgs e)
        {
            try
            {
                String Index = Convert.ToString(((Button)sender).CommandArgument);
                String[] r = Index.Split(new char[] { '@' });
                String RFC = r[0];
                Int32 NID_DECLARACION = Convert.ToInt32(r[1]);

                blld_DECLARACION oDeclaracion = new blld_DECLARACION(RFC.Substring(0, 4), RFC.Substring(4, 6), RFC.Substring(10, 3), NID_DECLARACION);

                Declaracion(oDeclaracion);
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                    AlertaBusqueda.ShowDanger(ex.Message);
                else new CustomException("La declaracion se encuentra eliminada");
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

        public void btnGridDeclaracionConflicto_Click(object sender, EventArgs e)
        {
            try
            {
                String Index = Convert.ToString(((Button)sender).CommandArgument);
                String[] r = Index.Split(new char[] { '@' });
                String RFC = r[0];
                Int32 NID_DECLARACION = Convert.ToInt32(r[1]);

                blld_USUARIO oUsuario = new blld_USUARIO(RFC.Substring(0, 4), RFC.Substring(4, 6), RFC.Substring(10, 3));
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, NID_DECLARACION);
                //DeclaraINE.Formas.ConsultaDeclaraciones.ImprimirDeclaracionConflicto(oDeclaracion, false);

            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    AlertaBusqueda.ShowDanger(ex.Message);
                }
                else new CustomException("La declaracion se encuentra eliminada");
            }
        }

        public void btnGridDeclaracionAcuse_Click(object sender, EventArgs e)
        {
            try
            {
                String Index = Convert.ToString(((Button)sender).CommandArgument);
                String[] r = Index.Split(new char[] { '@' });
                String RFC = r[0];
                Int32 NID_DECLARACION = Convert.ToInt32(r[1]);

                blld_DECLARACION oDeclaracion = new blld_DECLARACION(RFC.Substring(0, 4), RFC.Substring(4, 6), RFC.Substring(10, 3), NID_DECLARACION);

                Acuse(oDeclaracion);
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
        public static void Acuse(blld_DECLARACION oDeclaracion)
        {
            switch (oDeclaracion.NID_TIPO_DECLARACION)
            {
                case 1:
                    //DeclaraINE.Formas.ConsultaDeclaraciones.ImprimirDeclaracionInicialAcuse(oDeclaracion);
                    break;
                case 2:
                   // DeclaraINE.Formas.ConsultaDeclaraciones.ImprimirDeclaracionModificacionAcuse(oDeclaracion);
                    break;
                case 3:
                  //  DeclaraINE.Formas.ConsultaDeclaraciones.ImprimirDeclaracionConclusionAcuse(oDeclaracion);
                    break;
                default:
                    break;
            }
        }
        protected void btnEditarDeclaracionApartados_Click(object sender, EventArgs e)
        {
            try
            {
                String Index = Convert.ToString(((Button)sender).CommandArgument);

                String[] r = Index.Split(new char[] { '@' });
                String RFC = r[0];
                Int32 NID_DECLARACION = Convert.ToInt32(r[1]);

                String VID_NOMBRE = RFC.Substring(0, 4);
                String VID_FECHA = RFC.Substring(4, 6);
                String VID_HOMOCLAVE = RFC.Substring(10, 3);

                blld_DECLARACION oDeclaracion = new blld_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                _oDeclaracion = oDeclaracion;


                if (oDeclaracion.NID_ESTADO != 6)
                {
                    switch (oDeclaracion.NID_TIPO_DECLARACION)
                    {
                        case 1:

                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
                                imgDatosGeneralesI.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO.Value)
                                imgBienesI.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                                imgInversionesI.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                                imgAdeudosI.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                                imgObservacionesI.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                                imgConflictoInteresI.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                                imgEnvioI.Src = "~/Content/ok.png";

                            pnlDI.Visible = true;
                            pnlDM.Visible = false;
                            pnlDC.Visible = false;
                            appApartados.Show(true);
                            appApartados.HeaderText = "Declaración de Inicio - Apartados ";
                            break;
                        case 2:


                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
                                imgDatosGeneralesM.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO.Value)
                                imgBienesM.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                                imgInversionesM.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                                imgAdeudosM.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                                imgObservacionesM.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                                imgConflictoInteresM.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                                imgEnvioM.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 16).First().L_ESTADO.Value)
                                imgIngresosM.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 28).First().L_ESTADO.Value)
                                imgGastosM.Src = "~/Content/ok.png";

                            pnlDM.Visible = true;
                            pnlDI.Visible = false;
                            pnlDC.Visible = false;
                            appApartados.Show(true);
                            appApartados.HeaderText = "Declaración de Modificación - Apartados";

                            break;
                        case 3:

                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 1).First().L_ESTADO.Value)
                                imgDatosGeneralesC.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 7).First().L_ESTADO.Value)
                                imgBienesC.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                                imgInversionesC.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                                imgAdeudosC.Src = "~/Content/ok.png";
                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                                imgObservacionesC.Src = "~/Content/ok.png";

                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                                imgConflictoInteresC.Src = "~/Content/ok.png";

                            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                                imgEnvioC.Src = "~/Content/ok.png";

                            pnlDC.Visible = true;
                            pnlDI.Visible = false;
                            pnlDM.Visible = false;
                            appApartados.Show(true);
                            appApartados.HeaderText = "Declaración de Conclusión - Apartados";

                            break;

                        default:
                            break;
                    }

                }
                else
                    MsgBox.ShowDanger("La Declaración fue eliminada");

            }
            catch (Exception ex)
            {
                if (ex is CustomException)
                {
                    MsgBox.ShowDanger(ex.Message);
                }
                else MsgBox.ShowDanger(ex.Message);
            }
        }

        protected void btnEditarApartados_Click(object sender, EventArgs e)
        {
            String Index = Convert.ToString(((Button)sender).CommandArgument);

            String[] r = Index.Split(new char[] { '@' });
            String RFC = r[0];
            Int32 NID_APARTADO = Convert.ToInt32(r[1]);
        }

        protected void btnCerrarappApartados_Click(object sender, EventArgs e)
        {
            appApartados.Hide();
        }

        protected void btnCerrarappApartadoSelect_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Hide();
            appApartados.Show(true);
        }

        //-------------------------------------------------

        #region Declaracion Inicio
        protected void btnEditarDatosGeneralesI_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Inicio - Datos Generales";
            menu1I.Visible = true;
            blld_USUARIO oUsuario = new blld_USUARIO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE);
            DGDatosPersonales.Nombre = oUsuario.V_NOMBRE_COMPLETO;
            DGDatosPersonales.RFC = oDeclaracion.VID_NOMBRE + oDeclaracion.VID_FECHA + oDeclaracion.VID_HOMOCLAVE;
            DGDatosPersonales.FechaNacimiento = oUsuario.F_NACIMIENTO.ToString(strFormatoFecha);
            DGDatosPersonales.Sexo = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
            DGDatosPersonales.CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
            DGDatosPersonales.LugarNacimiento = oDeclaracion.DECLARACION_PERSONALES.V_ENTIDAD_NACIMIENTO;
            DGDatosPersonales.Nacionalidad = oDeclaracion.DECLARACION_PERSONALES.V_PAIS_NACIMIENTO;
            DGDatosPersonales.Civil = oDeclaracion.DECLARACION_PERSONALES.V_ESTADO_CIVIL;
            DGDatosPersonales.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesI.CssClass = "complete";
            else
                lkDatosPersonalesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularI.CssClass = "complete";
            else
                lkDomicilioParticularI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoI.CssClass = "complete";
            else
                lkCargoI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralI.CssClass = "complete";
            else
                lkDomicilioLaboralI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosI.CssClass = "complete";
            else
                lkDependientesEconomicosI.CssClass = "completeNone";

        }

        protected void btnEditarBienesI_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Inicio - Bienes";
            menu2I.Visible = true;
            BienesInmuebles.listInmuebles = oDeclaracion.ALTA.ALTA_INMUEBLEs;
            BienesInmuebles.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                lkBienesInmueblesI.CssClass = "complete";
            else
                lkBienesInmueblesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                lkBienesMueblesI.CssClass = "complete";
            else
                lkBienesMueblesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                lkVehiculosI.CssClass = "complete";
            else
                lkVehiculosI.CssClass = "completeNone";
        }

        protected void btnEditarInversionesI_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Inicio - Inversiones";
            menu3I.Visible = true;
            Inversiones.Invesiones = oDeclaracion.ALTA.ALTA_INVERSIONs;
            Inversiones.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                lkInversionesI.CssClass = "complete";
            else
                lkInversionesI.CssClass = "completeNone";
        }

        protected void btnEditarAdeudosI_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Inicio - Adeudos";
            menu4I.Visible = true;
            Adeudos.listAdeudo = oDeclaracion.ALTA.ALTA_ADEUDOs;
            Adeudos.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                lkAdeudosI.CssClass = "complete";
            else
                lkAdeudosI.CssClass = "completeNone";
        }

        protected void btnEditarObservacionesI_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Inicio - Observaciones";
            menu5I.Visible = true;
            Observaciones.Observacion = oDeclaracion.E_OBSERVACIONES;
            Observaciones.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                lkObservacionesI.CssClass = "complete";
            else
                lkObservacionesI.CssClass = "completeNone";
        }

        protected void btnEditarInteresesI_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Inicio - Declaración de Intereses";
            menu6I.Visible = true;
            blld__l_CONFLICTO olistConflicto = new blld__l_CONFLICTO();
            olistConflicto.VID_NOMBRE = new Declara_V2.StringFilter(oDeclaracion.VID_NOMBRE);
            olistConflicto.VID_FECHA = new Declara_V2.StringFilter(oDeclaracion.VID_FECHA);
            olistConflicto.VID_HOMOCLAVE = new Declara_V2.StringFilter(oDeclaracion.VID_HOMOCLAVE);
            olistConflicto.NID_DEC_ASOS = new Declara_V2.IntegerFilter(oDeclaracion.NID_DECLARACION);
            olistConflicto.select();
            blld_CONFLICTO oConflicto = new blld_CONFLICTO(olistConflicto.lista_CONFLICTO.First());
            DeclaracionInteres.lisConflicto = oConflicto.CONFLICTO_RUBROs;
            DeclaracionInteres.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                lknConflictoI.CssClass = "complete";
            else
                lknConflictoI.CssClass = "completeNone";
        }

        protected void btnEditarEnvíoI_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Inicio - Envío";
            DecEnvio.DecPublica = oDeclaracion.L_AUTORIZA_PUBLICAR.Value;
            menu7I.Visible = true;
            DecEnvio.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                lkEnvioI.CssClass = "complete";
            else
                lkEnvioI.CssClass = "completeNone";
        }
        #endregion


        #region Declaracion Modificacion

        protected void btnEditarDatosGeneralesM_Click(object sender, EventArgs e)
        {

            appApartadoSelectInicio.Show(true);
            appApartados.Hide();

            blld_DECLARACION oDeclaracion = _oDeclaracion;

            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Datos Generales";
            menu1M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesM.CssClass = "complete";
            else
                lkDatosPersonalesM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularM.CssClass = "complete";
            else
                lkDomicilioParticularM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoM.CssClass = "complete";
            else
                lkCargoM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralM.CssClass = "complete";
            else
                lkDomicilioLaboralM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosM.CssClass = "complete";
            else
                lkDependientesEconomicosM.CssClass = "completeNone";

            blld_USUARIO oUsuario = new blld_USUARIO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE);
            pgModDGDatosPersonales.Nombre = oUsuario.V_NOMBRE_COMPLETO;
            pgModDGDatosPersonales.RFC = oDeclaracion.VID_NOMBRE + oDeclaracion.VID_FECHA + oDeclaracion.VID_HOMOCLAVE;
            pgModDGDatosPersonales.FechaNacimiento = oUsuario.F_NACIMIENTO.ToString(strFormatoFecha);
            pgModDGDatosPersonales.Sexo = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
            pgModDGDatosPersonales.CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
            pgModDGDatosPersonales.LugarNacimiento = oDeclaracion.DECLARACION_PERSONALES.V_ENTIDAD_NACIMIENTO;
            pgModDGDatosPersonales.Nacionalidad = oDeclaracion.DECLARACION_PERSONALES.V_PAIS_NACIMIENTO;
            pgModDGDatosPersonales.Civil = oDeclaracion.DECLARACION_PERSONALES.V_ESTADO_CIVIL;
            pgModDGDatosPersonales.Visible = true;
            menu1M.Visible = true;
        }

        protected void btnEditarBienesM_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            //M_Cargo.Visible = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Bienes";
            menu2M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesActM.CssClass = "complete";
            else
                lkBienesInmueblesActM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesActM.CssClass = "complete";
            else
                lkBienesMueblesActM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosActM.CssClass = "complete";
            else
                lkVehiculosActM.CssClass = "completeNone";
            pgModBienesInmuebles.listInmueblesDecInicial = oDeclaracion.ALTA.ALTA_INMUEBLEs;
            pgModBienesInmuebles.listInmuebles = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs;
            pgModBienesInmuebles.Visible = true;
        }

        protected void btnEditarInversionesM_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            //M_Cargo.Visible = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Inversiones";
            menu3M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 24).First().L_ESTADO.Value)
                lkInversionesActM.CssClass = "complete";
            else
                lkInversionesActM.CssClass = "completeNone";
            pgModInversiones.listInversionesDecInicial = oDeclaracion.ALTA.ALTA_INVERSIONs;
            pgModInversiones.listInversiones = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs;
            pgModInversiones.Visible = true;
        }

        protected void btnEditarAdeudosM_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            //M_Cargo.Visible = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Adeudos";
            menu4M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 26).First().L_ESTADO.Value)
                lkAdeudosActM.CssClass = "complete";
            else
                lkAdeudosActM.CssClass = "completeNone";
            pgModAdeudos.listAdeudosDecInicial = oDeclaracion.ALTA.ALTA_ADEUDOs;
            pgModAdeudos.listAdeudos = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs;
            pgModAdeudos.Visible = true;
        }

        protected void btnEditarIngresosM_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            //M_Cargo.Visible = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Ingresos";
            menu8M.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 16).First().L_ESTADO.Value)
                lkIngresosM.CssClass = "complete";
            else
                lkIngresosM.CssClass = "completeNone";

            pgModIngresos.F_INGRESO = oDeclaracion.MODIFICACION.F_INICIO.Value.ToString("dd/MM/yyy", new CultureInfo("es-MX"));
            pgModIngresos.F_FINAL = oDeclaracion.MODIFICACION.F_FIN.Value.ToString("dd/MM/yyy", new CultureInfo("es-MX"));
            pgModIngresos.Presento = oDeclaracion.MODIFICACION.L_PRESENTO_DEC;
            pgModIngresos.IngresosCargo = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.C_TITULAR == 'D' && p.NID_INGRESO == 0).First().M_INGRESO.ToString("C");
            pgModIngresos.Otros = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.C_TITULAR == 'D' & p.NID_INGRESO != 0).Select(p => p.M_INGRESO).Sum().ToString("C");
            pgModIngresos.ingresosC = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.C_TITULAR == 'C').Select(p => p.M_INGRESO).Sum().ToString("C");
            pgModIngresos.ingresosT = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Select(p => p.M_INGRESO).Sum().ToString("C");

            pgModIngresos.Visible = true;
        }

        protected void btnEditarObservacionesM_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            //M_Cargo.Visible = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Observaciones";
            menu5M.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                lkObservacionesM.CssClass = "complete";
            else
                lkObservacionesM.CssClass = "completeNone";

            pgModObservaciones.Observacion = oDeclaracion.E_OBSERVACIONES;
            pgModObservaciones.Visible = true;
        }

        protected void btnEditarGastosM_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            //M_Cargo.Visible = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Gastos";
            menu9M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 29).First().L_ESTADO.Value)
                lkTarjetasM.CssClass = "complete";
            else
                lkTarjetasM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 30).First().L_ESTADO.Value)
                lkImpuestos.CssClass = "complete";
            else
                lkImpuestos.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 31).First().L_ESTADO.Value)
                lkOtrosGastosM.CssClass = "complete";
            else
                lkOtrosGastosM.CssClass = "completeNone";
            pgModTarjetas.listTarjetas = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs;
            pgModTarjetas.Visible = true;

        }

        protected void btnEditarInteresesM_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();

            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Declaración de Intereses";
            menu6M.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                lknConflictoM.CssClass = "complete";
            else
                lknConflictoM.CssClass = "completeNone";

            blld__l_CONFLICTO obc = new blld__l_CONFLICTO();
            obc.VID_NOMBRE = new Declara_V2.StringFilter(oDeclaracion.VID_NOMBRE);
            obc.VID_FECHA = new Declara_V2.StringFilter(oDeclaracion.VID_FECHA);
            obc.VID_HOMOCLAVE = new Declara_V2.StringFilter(oDeclaracion.VID_HOMOCLAVE);
            obc.NID_DEC_ASOS = new Declara_V2.IntegerFilter(oDeclaracion.NID_DECLARACION);
            obc.select();
            blld_CONFLICTO oConflicto = new blld_CONFLICTO(obc.lista_CONFLICTO.First());
            pgModConflicto.DecConflicto = oConflicto.CONFLICTO_RUBROs;
            pgModConflicto.Visible = true;
        }

        protected void btnEditarEnvíoM_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            //M_Cargo.Visible = false;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Modificación - Envío";
            menu7M.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                lkEnvioM.CssClass = "complete";
            else
                lkEnvioM.CssClass = "completeNone";

            pgModEnvio.DecPublica = oDeclaracion.L_AUTORIZA_PUBLICAR;
            pgModEnvio.Visible = true;
        }
        #endregion


        #region Declaracion Conclusion
        protected void btnEditarDatosGeneralesC_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            appApartadoSelectInicio.HeaderText = "Declaración de Conclusion - Datos Generales";
            menu1C.Visible = true;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesC.CssClass = "complete";
            else
                lkDatosPersonalesC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularC.CssClass = "complete";
            else
                lkDomicilioParticularC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoC.CssClass = "complete";
            else
                lkCargoC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralC.CssClass = "complete";
            else
                lkDomicilioLaboralC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosC.CssClass = "complete";
            else
                lkDependientesEconomicosC.CssClass = "completeNone";

            blld_USUARIO oUsuario = new blld_USUARIO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE);
            pgConDatosPersonales.Nombre = oUsuario.V_NOMBRE_COMPLETO;
            pgConDatosPersonales.RFC = oDeclaracion.VID_NOMBRE + oDeclaracion.VID_FECHA + oDeclaracion.VID_HOMOCLAVE;
            pgConDatosPersonales.FechaNacimiento = oUsuario.F_NACIMIENTO.ToString(strFormatoFecha);
            pgConDatosPersonales.Sexo = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
            pgConDatosPersonales.CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
            pgConDatosPersonales.LugarNacimiento = oDeclaracion.DECLARACION_PERSONALES.V_ENTIDAD_NACIMIENTO;
            pgConDatosPersonales.Nacionalidad = oDeclaracion.DECLARACION_PERSONALES.V_PAIS_NACIMIENTO;
            pgConDatosPersonales.Civil = oDeclaracion.DECLARACION_PERSONALES.V_ESTADO_CIVIL;
            pgConDatosPersonales.Visible = true;
            menu1C.Visible = true;
        }

        protected void btnEditarBienesC_Click(object sender, EventArgs e)
        {
            appApartados.Hide();
            appApartadoSelectInicio.Show(true);
            appApartadoSelectInicio.HeaderText = "Declaración de Conclusion - Bienes";
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu2C.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesActC.CssClass = "complete";
            else
                lkBienesInmueblesActC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesActC.CssClass = "complete";
            else
                lkBienesMueblesActC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosActC.CssClass = "complete";
            else
                lkVehiculosActC.CssClass = "completeNone";
            pgConBienesInmuebles.listInmueblesDecInicial = oDeclaracion.ALTA.ALTA_INMUEBLEs;
            pgConBienesInmuebles.listInmuebles = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs;
            pgConBienesInmuebles.Visible = true;
        }

        protected void btnEditarInversionesC_Click(object sender, EventArgs e)
        {
            appApartados.Hide();
            appApartadoSelectInicio.Show(true);
            appApartadoSelectInicio.HeaderText = "Declaración de Conclusion - Inversiones";
            menu3C.Visible = true;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 24).First().L_ESTADO.Value)
                lkInversionesActC.CssClass = "complete";
            else
                lkInversionesActC.CssClass = "completeNone";
            pgConInversiones.listInversionesDecInicial = oDeclaracion.ALTA.ALTA_INVERSIONs;
            pgConInversiones.listInversiones = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs;
            pgConInversiones.Visible = true;
        }

        protected void btnEditarAdeudosC_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            appApartadoSelectInicio.HeaderText = "Declaración de Conclusion - Adeudos";
            menu4C.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 26).First().L_ESTADO.Value)
                lkAdeudosActC.CssClass = "complete";
            else
                lkAdeudosActC.CssClass = "completeNone";
            pgConAdeudos.listAdeudosDecInicial = oDeclaracion.ALTA.ALTA_ADEUDOs;
            pgConAdeudos.listAdeudos = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs;
            pgConAdeudos.Visible = true;
        }

        protected void btnEditarObservacionesC_Click(object sender, EventArgs e)
        {
            appApartados.Hide();
            appApartadoSelectInicio.Show(true);
            appApartadoSelectInicio.HeaderText = "Declaración de Conclusion - Observaciones";
            menu5C.Visible = true;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                lkObservacionesC.CssClass = "complete";
            else
                lkObservacionesC.CssClass = "completeNone";
            pgConObservaciones.Observacion = oDeclaracion.E_OBSERVACIONES;
            pgConObservaciones.Visible = true;
        }

        protected void btnEditarInteresesC_Click(object sender, EventArgs e)
        {
            appApartados.Hide();
            appApartadoSelectInicio.Show(true);
            appApartadoSelectInicio.HeaderText = "Declaración de Conclusion - Declaración de Intereses";
            menu6C.Visible = true;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                lknConflictoC.CssClass = "complete";
            else
                lknConflictoC.CssClass = "completeNone";
            blld__l_CONFLICTO obc = new blld__l_CONFLICTO();
            obc.VID_NOMBRE = new Declara_V2.StringFilter(oDeclaracion.VID_NOMBRE);
            obc.VID_FECHA = new Declara_V2.StringFilter(oDeclaracion.VID_FECHA);
            obc.VID_HOMOCLAVE = new Declara_V2.StringFilter(oDeclaracion.VID_HOMOCLAVE);
            obc.NID_DEC_ASOS = new Declara_V2.IntegerFilter(oDeclaracion.NID_DECLARACION);
            obc.select();
            blld_CONFLICTO oConflicto = new blld_CONFLICTO(obc.lista_CONFLICTO.First());
            pgConConflicto.DecConflicto = oConflicto.CONFLICTO_RUBROs;
            pgConConflicto.Visible = true;
        }

        protected void btnEditarEnvíoC_Click(object sender, EventArgs e)
        {
            appApartadoSelectInicio.Show(true);
            appApartados.Hide();
            appApartadoSelectInicio.HeaderText = "Declaración de Conclusion - Envio";
            menu7C.Visible = true;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                lkEnvioC.CssClass = "complete";
            else
                lkEnvioC.CssClass = "completeNone";
            pgConEnvio.DecPublica = oDeclaracion.L_AUTORIZA_PUBLICAR;
            pgConEnvio.Visible = true;
        }
        #endregion


        #region Apartados Declaracion Inicio
        //-----------------------------------------------------------------
        //Sub apartadosInicio | DATOS GENERALES
        protected void lkDatosPersonalesI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = new blld_USUARIO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE);
            DGDatosPersonales.Nombre = oUsuario.V_NOMBRE_COMPLETO;
            DGDatosPersonales.RFC = oDeclaracion.VID_NOMBRE + oDeclaracion.VID_FECHA + oDeclaracion.VID_HOMOCLAVE;
            DGDatosPersonales.FechaNacimiento = oUsuario.F_NACIMIENTO.ToString(strFormatoFecha);
            DGDatosPersonales.Sexo = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
            DGDatosPersonales.CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
            DGDatosPersonales.LugarNacimiento = oDeclaracion.DECLARACION_PERSONALES.V_ENTIDAD_NACIMIENTO;
            DGDatosPersonales.Nacionalidad = oDeclaracion.DECLARACION_PERSONALES.V_PAIS_NACIMIENTO;
            DGDatosPersonales.Civil = oDeclaracion.DECLARACION_PERSONALES.V_ESTADO_CIVIL;

            menu1I.Visible = true;
            DGDatosPersonales.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesI.CssClass = "complete";
            else
                lkDatosPersonalesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularI.CssClass = "complete";
            else
                lkDomicilioParticularI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoI.CssClass = "complete";
            else
                lkCargoI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralI.CssClass = "complete";
            else
                lkDomicilioLaboralI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosI.CssClass = "complete";
            else
                lkDependientesEconomicosI.CssClass = "completeNone";
        }

        protected void lkDomicilioParticularI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            DGDomicilioParticular.CP = oDeclaracion.DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL.ToString();
            DGDomicilioParticular.Municipio = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_MUNICIPIO;
            DGDomicilioParticular.Colonia = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_COLONIA;
            DGDomicilioParticular.Calle = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_DOMICILIO;
            DGDomicilioParticular.Correo = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO;
            DGDomicilioParticular.TParticular = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR;
            DGDomicilioParticular.TCelular = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR;

            menu1I.Visible = true;
            DGDomicilioParticular.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesI.CssClass = "complete";
            else
                lkDatosPersonalesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularI.CssClass = "complete";
            else
                lkDomicilioParticularI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoI.CssClass = "complete";
            else
                lkCargoI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralI.CssClass = "complete";
            else
                lkDomicilioLaboralI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosI.CssClass = "complete";
            else
                lkDependientesEconomicosI.CssClass = "completeNone";
        }

        protected void lkCargoI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            DGCargo.ClavePuesto = oDeclaracion.DECLARACION_CARGO.V_PUESTO.ToString();
            DGCargo.ClaveNivel = oDeclaracion.DECLARACION_CARGO.VID_NIVEL.ToString();
            blld_CAT_PUESTO oPuesto = new blld_CAT_PUESTO(oDeclaracion.DECLARACION_CARGO.VID_PUESTO, oDeclaracion.DECLARACION_CARGO.NID_PUESTO);
            DGCargo.DenominacionPuesto = oPuesto.V_PUESTO_COMPUESTO;
            DGCargo.DenominacionCargo = oDeclaracion.DECLARACION_CARGO.V_DENOMINACION;
            DGCargo.UA = oDeclaracion.DECLARACION_CARGO.V_PRIMER_NIVEL;
            DGCargo.AreaAdscripcion = oDeclaracion.DECLARACION_CARGO.V_SEGUNDO_NIVEL;
            DGCargo.FechaPosesion = oDeclaracion.DECLARACION_CARGO.F_POSESION.ToString(strFormatoFecha);
            DGCargo.FechaIngreso = oDeclaracion.DECLARACION_CARGO.F_INICIO.ToString(strFormatoFecha);

            menu1I.Visible = true;
            DGCargo.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesI.CssClass = "complete";
            else
                lkDatosPersonalesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularI.CssClass = "complete";
            else
                lkDomicilioParticularI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoI.CssClass = "complete";
            else
                lkCargoI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralI.CssClass = "complete";
            else
                lkDomicilioLaboralI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosI.CssClass = "complete";
            else
                lkDependientesEconomicosI.CssClass = "completeNone";
        }

        protected void lkDomicilioLaboralI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            DGDomicilioLaboral.CP = oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL;
            blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL);

            DGDomicilioLaboral.Municipio = oCodigo.V_MUNICIPIO;
            DGDomicilioLaboral.Colonia = oCodigo.V_COLONIA;
            DGDomicilioLaboral.Calle = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO;
            DGDomicilioLaboral.Correo = oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL;

            try { DGDomicilioLaboral.TParticular = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[0]; } catch { }
            try { DGDomicilioLaboral.TParticular = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[1]; } catch { }

            menu1I.Visible = true;
            DGDomicilioLaboral.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesI.CssClass = "complete";
            else
                lkDatosPersonalesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularI.CssClass = "complete";
            else
                lkDomicilioParticularI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoI.CssClass = "complete";
            else
                lkCargoI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralI.CssClass = "complete";
            else
                lkDomicilioLaboralI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosI.CssClass = "complete";
            else
                lkDependientesEconomicosI.CssClass = "completeNone";
        }

        protected void lkDependientesEconomicosI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            DGConyuge.LisDep = oDeclaracion.DECLARACION_DEPENDIENTESs;
            DGConyuge.Visible = true;
            menu1I.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesI.CssClass = "complete";
            else
                lkDatosPersonalesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularI.CssClass = "complete";
            else
                lkDomicilioParticularI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoI.CssClass = "complete";
            else
                lkCargoI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralI.CssClass = "complete";
            else
                lkDomicilioLaboralI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosI.CssClass = "complete";
            else
                lkDependientesEconomicosI.CssClass = "completeNone";
        }

        //Sub apartados  Inicio | BIENES

        protected void lkBienesInmueblesI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu2I.Visible = true;
            BienesInmuebles.Visible = true;

            BienesInmuebles.listInmuebles = oDeclaracion.ALTA.ALTA_INMUEBLEs;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                lkBienesInmueblesI.CssClass = "complete";
            else
                lkBienesInmueblesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                lkBienesMueblesI.CssClass = "complete";
            else
                lkBienesMueblesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                lkVehiculosI.CssClass = "complete";
            else
                lkVehiculosI.CssClass = "completeNone";
        }
        //sub apartado Inicio |
        protected void lkBienesMueblesI_Click(object sender, EventArgs e)
        {
            menu2I.Visible = true;
            BienesOtrosBienes.Visible = true;

            blld_DECLARACION oDeclaracion = _oDeclaracion;
            BienesOtrosBienes.Mubles = oDeclaracion.ALTA.ALTA_MUEBLEs;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                lkBienesInmueblesI.CssClass = "complete";
            else
                lkBienesInmueblesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                lkBienesMueblesI.CssClass = "complete";
            else
                lkBienesMueblesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                lkVehiculosI.CssClass = "complete";
            else
                lkVehiculosI.CssClass = "completeNone";

        }
        //sub apartado Inicio |
        protected void lkVehiculosI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu2I.Visible = true;
            BienesVehiculos.listVehiculos = oDeclaracion.ALTA.ALTA_VEHICULOs;
            BienesVehiculos.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 8).First().L_ESTADO.Value)
                lkBienesInmueblesI.CssClass = "complete";
            else
                lkBienesInmueblesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 9).First().L_ESTADO.Value)
                lkBienesMueblesI.CssClass = "complete";
            else
                lkBienesMueblesI.CssClass = "completeNone";

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 10).First().L_ESTADO.Value)
                lkVehiculosI.CssClass = "complete";
            else
                lkVehiculosI.CssClass = "completeNone";
        }

        //sub apartado Inicio | Inversiones
        protected void lkInversionesI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu3I.Visible = true;
            Inversiones.Invesiones = oDeclaracion.ALTA.ALTA_INVERSIONs;
            Inversiones.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 11).First().L_ESTADO.Value)
                lkInversionesI.CssClass = "complete";
            else
                lkInversionesI.CssClass = "completeNone";
        }
        //sub apartado Inicio | Adeudos
        protected void lkAdeudosI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu4I.Visible = true;
            Adeudos.listAdeudo = oDeclaracion.ALTA.ALTA_ADEUDOs;
            Adeudos.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 12).First().L_ESTADO.Value)
                lkAdeudosI.CssClass = "complete";
            else
                lkAdeudosI.CssClass = "completeNone";
        }
        //sub apartado Inicio | Observaciones
        protected void lkObservacionesI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu5I.Visible = true;
            Observaciones.Observacion = oDeclaracion.E_OBSERVACIONES;
            Observaciones.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                lkObservacionesI.CssClass = "complete";
            else
                lkObservacionesI.CssClass = "completeNone";
        }
        //sub apartado Inicio | Conflicto
        protected void lknConflictoI_Click(object sender, EventArgs e)
        {
            menu6I.Visible = true;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld__l_CONFLICTO oListConflicto = new blld__l_CONFLICTO();
            oListConflicto.VID_NOMBRE = new Declara_V2.StringFilter(oDeclaracion.VID_NOMBRE);
            oListConflicto.VID_FECHA = new Declara_V2.StringFilter(oDeclaracion.VID_FECHA);
            oListConflicto.VID_HOMOCLAVE = new Declara_V2.StringFilter(oDeclaracion.VID_HOMOCLAVE);
            oListConflicto.NID_DEC_ASOS = new Declara_V2.IntegerFilter(oDeclaracion.NID_DECLARACION);
            oListConflicto.select();

            blld_CONFLICTO oConflicto = new blld_CONFLICTO(oListConflicto.lista_CONFLICTO.First());
            DeclaracionInteres.lisConflicto = oConflicto.CONFLICTO_RUBROs;
            DeclaracionInteres.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                lknConflictoI.CssClass = "complete";
            else
                lknConflictoI.CssClass = "completeNone";
        }
        //sub apartado Inicio | Envio
        protected void lkEnvioI_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            DecEnvio.DecPublica = oDeclaracion.L_AUTORIZA_PUBLICAR.Value;
            menu7I.Visible = true;
            DecEnvio.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                lkEnvioI.CssClass = "complete";
            else
                lkEnvioI.CssClass = "completeNone";
        }

        #endregion


        #region Apartados Declaracion Modificacion
        //Sub apartado  Modificacion
        protected void lkDatosPersonalesM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = new blld_USUARIO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE);
            pgModDGDatosPersonales.Nombre = oUsuario.V_NOMBRE_COMPLETO;
            pgModDGDatosPersonales.RFC = oDeclaracion.VID_NOMBRE + oDeclaracion.VID_FECHA + oDeclaracion.VID_HOMOCLAVE;
            pgModDGDatosPersonales.FechaNacimiento = oUsuario.F_NACIMIENTO.ToString(strFormatoFecha);
            pgModDGDatosPersonales.Sexo = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
            pgModDGDatosPersonales.CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
            pgModDGDatosPersonales.LugarNacimiento = oDeclaracion.DECLARACION_PERSONALES.V_ENTIDAD_NACIMIENTO;
            pgModDGDatosPersonales.Nacionalidad = oDeclaracion.DECLARACION_PERSONALES.V_PAIS_NACIMIENTO;
            pgModDGDatosPersonales.Civil = oDeclaracion.DECLARACION_PERSONALES.V_ESTADO_CIVIL;
            pgModDGDatosPersonales.Visible = true;
            menu1M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesM.CssClass = "complete";
            else
                lkDatosPersonalesM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularM.CssClass = "complete";
            else
                lkDomicilioParticularM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoM.CssClass = "complete";
            else
                lkCargoM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralM.CssClass = "complete";
            else
                lkDomicilioLaboralM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosM.CssClass = "complete";
            else
                lkDependientesEconomicosM.CssClass = "completeNone";

        }
        //Sub apartado  Modificacion
        protected void lkDomicilioParticularM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            pgModDGDomicilioParticular.CP = oDeclaracion.DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL.ToString();
            pgModDGDomicilioParticular.Municipio = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_MUNICIPIO;
            pgModDGDomicilioParticular.Colonia = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_COLONIA;
            pgModDGDomicilioParticular.Calle = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_DOMICILIO;
            pgModDGDomicilioParticular.Correo = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO;
            pgModDGDomicilioParticular.TParticular = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR;
            pgModDGDomicilioParticular.TCelular = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR;
            pgModDGDomicilioParticular.Visible = true;

            menu1M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesM.CssClass = "complete";
            else
                lkDatosPersonalesM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularM.CssClass = "complete";
            else
                lkDomicilioParticularM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoM.CssClass = "complete";
            else
                lkCargoM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralM.CssClass = "complete";
            else
                lkDomicilioLaboralM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosM.CssClass = "complete";
            else
                lkDependientesEconomicosM.CssClass = "completeNone";

        }
        //Sub apartado  Modificacion
        protected void lkCargoM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgModDGCargo.ClavePuesto = oDeclaracion.DECLARACION_CARGO.V_PUESTO.ToString();
            pgModDGCargo.ClaveNivel = oDeclaracion.DECLARACION_CARGO.VID_NIVEL.ToString();
            blld_CAT_PUESTO oPuesto = new blld_CAT_PUESTO(oDeclaracion.DECLARACION_CARGO.VID_PUESTO, oDeclaracion.DECLARACION_CARGO.NID_PUESTO);
            pgModDGCargo.DenominacionPuesto = oPuesto.V_PUESTO_COMPUESTO;
            pgModDGCargo.DenominacionCargo = oDeclaracion.DECLARACION_CARGO.V_DENOMINACION;
            pgModDGCargo.UA = oDeclaracion.DECLARACION_CARGO.V_PRIMER_NIVEL;
            pgModDGCargo.AreaAdscripcion = oDeclaracion.DECLARACION_CARGO.V_SEGUNDO_NIVEL;
            pgModDGCargo.FechaPosesion = oDeclaracion.DECLARACION_CARGO.F_POSESION.ToString(strFormatoFecha);
            pgModDGCargo.FechaIngreso = oDeclaracion.DECLARACION_CARGO.F_INICIO.ToString(strFormatoFecha);
            pgModDGCargo.Visible = true;
            menu1M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesM.CssClass = "complete";
            else
                lkDatosPersonalesM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularM.CssClass = "complete";
            else
                lkDomicilioParticularM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoM.CssClass = "complete";
            else
                lkCargoM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralM.CssClass = "complete";
            else
                lkDomicilioLaboralM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosM.CssClass = "complete";
            else
                lkDependientesEconomicosM.CssClass = "completeNone";


        }
        //Sub apartado  Modificacion
        protected void lkDomicilioLaboralM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgModDGDomicilioLaboral.CP = oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL;
            blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL);

            pgModDGDomicilioLaboral.Municipio = oCodigo.V_MUNICIPIO;
            pgModDGDomicilioLaboral.Colonia = oCodigo.V_COLONIA;
            pgModDGDomicilioLaboral.Calle = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO;
            pgModDGDomicilioLaboral.Correo = oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL;

            try { DGDomicilioLaboral.TParticular = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[0]; } catch { }
            try { DGDomicilioLaboral.TParticular = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[1]; } catch { }
            pgModDGDomicilioLaboral.Visible = true;
            menu1M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesM.CssClass = "complete";
            else
                lkDatosPersonalesM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularM.CssClass = "complete";
            else
                lkDomicilioParticularM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoM.CssClass = "complete";
            else
                lkCargoM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralM.CssClass = "complete";
            else
                lkDomicilioLaboralM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosM.CssClass = "complete";
            else
                lkDependientesEconomicosM.CssClass = "completeNone";

        }
        //Sub apartado  Modificacion
        protected void lkDependientesEconomicosM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgModDGConyuge.LisDep = oDeclaracion.DECLARACION_DEPENDIENTESs;
            pgModDGConyuge.Visible = true;
            menu1M.Visible = true;
            //
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesM.CssClass = "complete";
            else
                lkDatosPersonalesM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularM.CssClass = "complete";
            else
                lkDomicilioParticularM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoM.CssClass = "complete";
            else
                lkCargoM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralM.CssClass = "complete";
            else
                lkDomicilioLaboralM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosM.CssClass = "complete";
            else
                lkDependientesEconomicosM.CssClass = "completeNone";

        }

        //Sub apartado  Modificacion | BIENES
        protected void lkBienesInmueblesActM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu2M.Visible = true;
            pgModBienesInmuebles.listInmueblesDecInicial = oDeclaracion.ALTA.ALTA_INMUEBLEs;
            pgModBienesInmuebles.listInmuebles = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs;
            pgModBienesInmuebles.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesActM.CssClass = "complete";
            else
                lkBienesInmueblesActM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesActM.CssClass = "complete";
            else
                lkBienesMueblesActM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosActM.CssClass = "complete";
            else
                lkVehiculosActM.CssClass = "completeNone";
        }

        protected void lkBienesMueblesActM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu2M.Visible = true;
            pgModBienesMuebles.listMueblesDecInicial = oDeclaracion.ALTA.ALTA_MUEBLEs;
            pgModBienesMuebles.listMuebles = oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs;
            pgModBienesMuebles.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesActM.CssClass = "complete";
            else
                lkBienesInmueblesActM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesActM.CssClass = "complete";
            else
                lkBienesMueblesActM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosActM.CssClass = "complete";
            else
                lkVehiculosActM.CssClass = "completeNone";
        }

        protected void lkVehiculosActM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu2M.Visible = true;
            pgModBienesVehiculos.listVehiculosDecInicial = oDeclaracion.ALTA.ALTA_VEHICULOs;
            pgModBienesVehiculos.listVehiculos = oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs;
            pgModBienesVehiculos.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesActM.CssClass = "complete";
            else
                lkBienesInmueblesActM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesActM.CssClass = "complete";
            else
                lkBienesMueblesActM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosActM.CssClass = "complete";
            else
                lkVehiculosActM.CssClass = "completeNone";
        }

        //Sub apartado  Modificacion |
        protected void lkInversionesActM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgModInversiones.listInversionesDecInicial = oDeclaracion.ALTA.ALTA_INVERSIONs;
            pgModInversiones.listInversiones = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs;
            pgModInversiones.Visible = true;

            menu3C.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 24).First().L_ESTADO.Value)
                lkInversionesActC.CssClass = "complete";
            else
                lkInversionesActC.CssClass = "completeNone";
        }

        //Sub apartado  Modificacion |
        protected void lkAdeudosActM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu4M.Visible = true;
            pgModAdeudos.listAdeudosDecInicial = oDeclaracion.ALTA.ALTA_ADEUDOs;
            pgModAdeudos.listAdeudos = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs;
            pgModAdeudos.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 26).First().L_ESTADO.Value)
                lkAdeudosActM.CssClass = "complete";
            else
                lkAdeudosActM.CssClass = "completeNone";

        }
        //Sub apartado  Modificacion | Ingresos
        protected void lkIngresosM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu8M.Visible = true;
            pgModIngresos.F_INGRESO = oDeclaracion.MODIFICACION.F_INICIO.Value.ToString("dd/MM/yyy", new CultureInfo("es-MX"));
            pgModIngresos.F_FINAL = oDeclaracion.MODIFICACION.F_FIN.Value.ToString("dd/MM/yyy", new CultureInfo("es-MX"));
            pgModIngresos.Presento = oDeclaracion.MODIFICACION.L_PRESENTO_DEC;
            pgModIngresos.IngresosCargo = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.C_TITULAR == 'D' && p.NID_INGRESO == 0).First().M_INGRESO.ToString("C");
            pgModIngresos.Otros = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.C_TITULAR == 'D' & p.NID_INGRESO != 0).Select(p => p.M_INGRESO).Sum().ToString("C");
            pgModIngresos.ingresosC = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Where(p => p.C_TITULAR == 'C').Select(p => p.M_INGRESO).Sum().ToString("C");
            pgModIngresos.ingresosT = oDeclaracion.MODIFICACION.MODIFICACION_INGRESOSs.Select(p => p.M_INGRESO).Sum().ToString("C");

            pgModIngresos.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 16).First().L_ESTADO.Value)
                lkIngresosM.CssClass = "complete";
            else
                lkIngresosM.CssClass = "completeNone";
        }

        //Sub apartado  Modificacion |
        protected void lkTarjetasM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu9M.Visible = true;
            pgModTarjetas.listTarjetas = oDeclaracion.MODIFICACION.MODIFICACION_TARJETAs;
            pgModTarjetas.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 29).First().L_ESTADO.Value)
                lkTarjetasM.CssClass = "complete";
            else
                lkTarjetasM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 30).First().L_ESTADO.Value)
                lkImpuestos.CssClass = "complete";
            else
                lkImpuestos.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 31).First().L_ESTADO.Value)
                lkOtrosGastosM.CssClass = "complete";
            else
                lkOtrosGastosM.CssClass = "completeNone";
        }
        //Sub apartado  Modificacion |
        protected void lkImpuestos_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu9M.Visible = true;
            pgModImpuestos.listImpuesto = oDeclaracion.MODIFICACION.MODIFICACION_GASTOs;
            pgModImpuestos.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 29).First().L_ESTADO.Value)
                lkTarjetasM.CssClass = "complete";
            else
                lkTarjetasM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 30).First().L_ESTADO.Value)
                lkImpuestos.CssClass = "complete";
            else
                lkImpuestos.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 31).First().L_ESTADO.Value)
                lkOtrosGastosM.CssClass = "complete";
            else
                lkOtrosGastosM.CssClass = "completeNone";
        }
        //Sub apartado  Modificacion |
        protected void lkOtrosGastosM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu9M.Visible = true;
            pgModOtrosGastos.listOtrosGastos = oDeclaracion.MODIFICACION.MODIFICACION_GASTOs;
            pgModOtrosGastos.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 29).First().L_ESTADO.Value)
                lkTarjetasM.CssClass = "complete";
            else
                lkTarjetasM.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 30).First().L_ESTADO.Value)
                lkImpuestos.CssClass = "complete";
            else
                lkImpuestos.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 31).First().L_ESTADO.Value)
                lkOtrosGastosM.CssClass = "complete";
            else
                lkOtrosGastosM.CssClass = "completeNone";

        }
        //Sub apartado  Modificacion |
        protected void lkObservacionesM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu5M.Visible = true;
            pgModObservaciones.Observacion = oDeclaracion.E_OBSERVACIONES;
            pgModObservaciones.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                lkObservacionesM.CssClass = "complete";
            else
                lkObservacionesM.CssClass = "completeNone";
        }
        //Sub apartado  Modificacion |
        protected void lknConflictoM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu6M.Visible = true;
            blld__l_CONFLICTO obc = new blld__l_CONFLICTO();
            obc.VID_NOMBRE = new Declara_V2.StringFilter(oDeclaracion.VID_NOMBRE);
            obc.VID_FECHA = new Declara_V2.StringFilter(oDeclaracion.VID_FECHA);
            obc.VID_HOMOCLAVE = new Declara_V2.StringFilter(oDeclaracion.VID_HOMOCLAVE);
            obc.NID_DEC_ASOS = new Declara_V2.IntegerFilter(oDeclaracion.NID_DECLARACION);
            obc.select();
            blld_CONFLICTO oConflicto = new blld_CONFLICTO(obc.lista_CONFLICTO.First());
            pgModConflicto.DecConflicto = oConflicto.CONFLICTO_RUBROs;
            pgModConflicto.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                lknConflictoM.CssClass = "complete";
            else
                lknConflictoM.CssClass = "completeNone";
        }
        //Sub apartado  Modificacion |
        protected void lkEnvioM_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            menu7M.Visible = true;
            pgModEnvio.DecPublica = oDeclaracion.L_AUTORIZA_PUBLICAR;
            pgModEnvio.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                lkEnvioM.CssClass = "complete";
            else
                lkEnvioM.CssClass = "completeNone";
        }

        #endregion


        #region Apartados Declaracion de Conclusion
        protected void lkDatosPersonalesC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld_USUARIO oUsuario = new blld_USUARIO(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE);
            pgConDatosPersonales.Nombre = oUsuario.V_NOMBRE_COMPLETO;
            pgConDatosPersonales.RFC = oDeclaracion.VID_NOMBRE + oDeclaracion.VID_FECHA + oDeclaracion.VID_HOMOCLAVE;
            pgConDatosPersonales.FechaNacimiento = oUsuario.F_NACIMIENTO.ToString(strFormatoFecha);
            pgConDatosPersonales.Sexo = oDeclaracion.DECLARACION_PERSONALES.C_GENERO;
            pgConDatosPersonales.CURP = oDeclaracion.DECLARACION_PERSONALES.C_CURP;
            pgConDatosPersonales.LugarNacimiento = oDeclaracion.DECLARACION_PERSONALES.V_ENTIDAD_NACIMIENTO;
            pgConDatosPersonales.Nacionalidad = oDeclaracion.DECLARACION_PERSONALES.V_PAIS_NACIMIENTO;
            pgConDatosPersonales.Civil = oDeclaracion.DECLARACION_PERSONALES.V_ESTADO_CIVIL;
            pgConDatosPersonales.Visible = true;
            menu1C.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesC.CssClass = "complete";
            else
                lkDatosPersonalesC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularC.CssClass = "complete";
            else
                lkDomicilioParticularC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoC.CssClass = "complete";
            else
                lkCargoC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralC.CssClass = "complete";
            else
                lkDomicilioLaboralC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosC.CssClass = "complete";
            else
                lkDependientesEconomicosC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion | Bienes
        protected void lkDomicilioParticularC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgConDomicilioParticular.CP = oDeclaracion.DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL.ToString();
            pgConDomicilioParticular.Municipio = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_MUNICIPIO;
            pgConDomicilioParticular.Colonia = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_COLONIA;
            pgConDomicilioParticular.Calle = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_DOMICILIO;
            pgConDomicilioParticular.Correo = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_CORREO;
            pgConDomicilioParticular.TParticular = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR;
            pgConDomicilioParticular.TCelular = oDeclaracion.DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR;
            pgConDomicilioParticular.Visible = true;
            menu1C.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesC.CssClass = "complete";
            else
                lkDatosPersonalesC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularC.CssClass = "complete";
            else
                lkDomicilioParticularC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoC.CssClass = "complete";
            else
                lkCargoC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralC.CssClass = "complete";
            else
                lkDomicilioLaboralC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosC.CssClass = "complete";
            else
                lkDependientesEconomicosC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion | Bienes
        protected void lkCargoC_Click(object sender, EventArgs e)
        {

            blld_DECLARACION oDeclaracion = _oDeclaracion;

            pgConCargo.ClavePuesto = oDeclaracion.DECLARACION_CARGO.V_PUESTO.ToString();
            pgConCargo.ClaveNivel = oDeclaracion.DECLARACION_CARGO.VID_NIVEL.ToString();
            blld_CAT_PUESTO oPuesto = new blld_CAT_PUESTO(oDeclaracion.DECLARACION_CARGO.VID_PUESTO, oDeclaracion.DECLARACION_CARGO.NID_PUESTO);
            pgConCargo.DenominacionPuesto = oPuesto.V_PUESTO_COMPUESTO;
            pgConCargo.DenominacionCargo = oDeclaracion.DECLARACION_CARGO.V_DENOMINACION;
            pgConCargo.UA = oDeclaracion.DECLARACION_CARGO.V_PRIMER_NIVEL;
            pgConCargo.AreaAdscripcion = oDeclaracion.DECLARACION_CARGO.V_SEGUNDO_NIVEL;
            pgConCargo.FechaPosesion = oDeclaracion.DECLARACION_CARGO.F_POSESION.ToString(strFormatoFecha);
            pgConCargo.FechaIngreso = oDeclaracion.DECLARACION_CARGO.F_INICIO.ToString(strFormatoFecha);
            pgConCargo.Visible = true;
            menu1C.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesC.CssClass = "complete";
            else
                lkDatosPersonalesC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularC.CssClass = "complete";
            else
                lkDomicilioParticularC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoC.CssClass = "complete";
            else
                lkCargoC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralC.CssClass = "complete";
            else
                lkDomicilioLaboralC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosC.CssClass = "complete";
            else
                lkDependientesEconomicosC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion | Bienes
        protected void lkDomicilioLaboralC_Click(object sender, EventArgs e)
        {
            menu1C.Visible = true;
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            pgConDomicilioLaboral.CP = oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL;
            blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(oDeclaracion.DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL);

            pgConDomicilioLaboral.Municipio = oCodigo.V_MUNICIPIO;
            pgConDomicilioLaboral.Colonia = oCodigo.V_COLONIA;
            pgConDomicilioLaboral.Calle = oDeclaracion.DECLARACION_DOM_LABORAL.V_DOMICILIO;
            pgConDomicilioLaboral.Correo = oDeclaracion.DECLARACION_DOM_LABORAL.V_CORREO_LABORAL;

            try { pgConDomicilioLaboral.TParticular = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[0]; } catch { }
            try { pgConDomicilioLaboral.TParticular = oDeclaracion.DECLARACION_DOM_LABORAL.V_TEL_LABORAL.Split('|')[1]; } catch { }
            pgConDomicilioLaboral.Visible = true;


            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesC.CssClass = "complete";
            else
                lkDatosPersonalesC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularC.CssClass = "complete";
            else
                lkDomicilioParticularC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoC.CssClass = "complete";
            else
                lkCargoC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralC.CssClass = "complete";
            else
                lkDomicilioLaboralC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosC.CssClass = "complete";
            else
                lkDependientesEconomicosC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion | Bienes
        protected void lkDependientesEconomicosC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgConConyugue.LisDep = oDeclaracion.DECLARACION_DEPENDIENTESs;
            pgConConyugue.Visible = true;

            menu1C.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 2).First().L_ESTADO.Value)
                lkDatosPersonalesC.CssClass = "complete";
            else
                lkDatosPersonalesC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 3).First().L_ESTADO.Value)
                lkDomicilioParticularC.CssClass = "complete";
            else
                lkDomicilioParticularC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 4).First().L_ESTADO.Value)
                lkCargoC.CssClass = "complete";
            else
                lkCargoC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 5).First().L_ESTADO.Value)
                lkDomicilioLaboralC.CssClass = "complete";
            else
                lkDomicilioLaboralC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 6).First().L_ESTADO.Value)
                lkDependientesEconomicosC.CssClass = "complete";
            else
                lkDependientesEconomicosC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion | Bienes
        protected void lkBienesInmueblesActC_Click(object sender, EventArgs e)
        {
            menu2C.Visible = true;
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgConBienesInmuebles.listInmueblesDecInicial = oDeclaracion.ALTA.ALTA_INMUEBLEs;
            pgConBienesInmuebles.listInmuebles = oDeclaracion.MODIFICACION.MODIFICACION_INMUEBLEs;

            pgConBienesInmuebles.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesActC.CssClass = "complete";
            else
                lkBienesInmueblesActC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesActC.CssClass = "complete";
            else
                lkBienesMueblesActC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosActC.CssClass = "complete";
            else
                lkVehiculosActC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion | Bienes
        protected void lkBienesMueblesActC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgConBienesMuebles.listMueblesDecInicial = oDeclaracion.ALTA.ALTA_MUEBLEs;
            pgConBienesMuebles.listMuebles = oDeclaracion.MODIFICACION.MODIFICACION_MUEBLEs;
            pgConBienesMuebles.Visible = true;
            menu2C.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesActC.CssClass = "complete";
            else
                lkBienesInmueblesActC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesActC.CssClass = "complete";
            else
                lkBienesMueblesActC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosActC.CssClass = "complete";
            else
                lkVehiculosActC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion |
        protected void lkVehiculosActC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgConBieneVehiculos.listVehiculosDecInicial = oDeclaracion.ALTA.ALTA_VEHICULOs;
            pgConBieneVehiculos.listVehiculos = oDeclaracion.MODIFICACION.MODIFICACION_VEHICULOs;
            pgConBieneVehiculos.Visible = true;
            menu2C.Visible = true;

            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 18).First().L_ESTADO.Value)
                lkBienesInmueblesActC.CssClass = "complete";
            else
                lkBienesInmueblesActC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 19).First().L_ESTADO.Value)
                lkBienesMueblesActC.CssClass = "complete";
            else
                lkBienesMueblesActC.CssClass = "completeNone";
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 20).First().L_ESTADO.Value)
                lkVehiculosActC.CssClass = "complete";
            else
                lkVehiculosActC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion |
        protected void lkInversionesActC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;

            pgConInversiones.listInversionesDecInicial = oDeclaracion.ALTA.ALTA_INVERSIONs;
            pgConInversiones.listInversiones = oDeclaracion.MODIFICACION.MODIFICACION_INVERSIONs;
            pgConInversiones.Visible = true;
            menu3C.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 24).First().L_ESTADO.Value)
                lkInversionesActC.CssClass = "complete";
            else
                lkInversionesActC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion |
        protected void lkAdeudosActC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgConAdeudos.listAdeudosDecInicial = oDeclaracion.ALTA.ALTA_ADEUDOs;
            pgConAdeudos.listAdeudos = oDeclaracion.MODIFICACION.MODIFICACION_ADEUDOs;
            pgConAdeudos.Visible = true;
            menu4C.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 26).First().L_ESTADO.Value)
                lkAdeudosActC.CssClass = "complete";
            else
                lkAdeudosActC.CssClass = "completeNone";
        }


        //Sub apartado  Conclusion |
        protected void lkObservacionesC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgConObservaciones.Observacion = oDeclaracion.E_OBSERVACIONES;
            pgConObservaciones.Visible = true;
            menu5C.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 13).First().L_ESTADO.Value)
                lkObservacionesC.CssClass = "complete";
            else
                lkObservacionesC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion |
        protected void lknConflictoC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            blld__l_CONFLICTO olistConflicto = new blld__l_CONFLICTO();
            olistConflicto.VID_NOMBRE = new Declara_V2.StringFilter(oDeclaracion.VID_NOMBRE);
            olistConflicto.VID_FECHA = new Declara_V2.StringFilter(oDeclaracion.VID_FECHA);
            olistConflicto.VID_HOMOCLAVE = new Declara_V2.StringFilter(oDeclaracion.VID_HOMOCLAVE);
            olistConflicto.NID_DEC_ASOS = new Declara_V2.IntegerFilter(oDeclaracion.NID_DECLARACION);
            olistConflicto.select();
            blld_CONFLICTO oConflicto = new blld_CONFLICTO(olistConflicto.lista_CONFLICTO.First());
            pgConConflicto.DecConflicto = oConflicto.CONFLICTO_RUBROs;
            pgConConflicto.Visible = true;
            menu6C.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO.Value)
                lknConflictoC.CssClass = "complete";
            else
                lknConflictoC.CssClass = "completeNone";
        }
        //Sub apartado  Conclusion |
        protected void lkEnvioC_Click(object sender, EventArgs e)
        {
            blld_DECLARACION oDeclaracion = _oDeclaracion;
            pgConEnvio.DecPublica = oDeclaracion.L_AUTORIZA_PUBLICAR;
            pgConEnvio.Visible = true;
            menu7C.Visible = true;
            if (oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO.Value)
                lkEnvioC.CssClass = "complete";
            else
                lkEnvioC.CssClass = "completeNone";
        }




        #endregion


        protected void grdDec_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String Index = ((Label)e.Row.FindControl("LabRFC")).Text;

                String[] r = Index.Split(new char[] { '@' });
                String RFC = r[0];
                Int32 NID_DECLARACION = Convert.ToInt32(r[1]);

                blld_DECLARACION oDeclaracion = new blld_DECLARACION(RFC.Substring(0, 4), RFC.Substring(4, 6), RFC.Substring(10, 3), NID_DECLARACION);
                
                switch (oDeclaracion.NID_TIPO_DECLARACION)
                {
                    case 1:
                        ((Image)e.Row.FindControl("imgTipo")).ImageUrl = String.Concat("~/Images/CAT_TIPO_DECLARACION/inicial1.png");
                        break;
                    case 2:
                        switch (oDeclaracion.DECLARACION_PERSONALES.C_GENERO)
                        {
                            case "M":
                                ((Image)e.Row.FindControl("imgTipo")).ImageUrl = String.Concat("~/Images/CAT_TIPO_DECLARACION/modificacionM1.png");
                                break;

                            case "F":
                                ((Image)e.Row.FindControl("imgTipo")).ImageUrl = String.Concat("~/Images/CAT_TIPO_DECLARACION/modificacionF1.png");
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        ((Image)e.Row.FindControl("imgTipo")).ImageUrl = String.Concat("~/Images/CAT_TIPO_DECLARACION/conclusion1.png");

                        break;
                }
            }
        }



    }
}