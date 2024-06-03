using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using System;
using System.Linq;
using System.Data.Entity.Core.Objects;

namespace DeclaraINAI.Formas
{
    public partial class AvisoPrivacidadConflicto : Pagina
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_oUsuario == null)
                Response.Redirect("Login.aspx");

            //if (_oDeclaracion == null)
            //    Response.Redirect("Index.aspx");
            if (!IsPostBack)
            {
                //Apartados();
            }
        }
        private void Apartados()
        {
            int Decla=0;
            blld_USUARIO oUsuario = _oUsuario;
            Decla=TomaDesicion(oUsuario.VID_NOMBRE,oUsuario.VID_FECHA,oUsuario.VID_HOMOCLAVE);
            blld__l_DECLARACION oBusqueda = new blld__l_DECLARACION();
            oBusqueda.VID_NOMBRE = new Declara_V2.StringFilter(oUsuario.VID_NOMBRE);
            oBusqueda.VID_FECHA = new Declara_V2.StringFilter(oUsuario.VID_FECHA);
            oBusqueda.VID_HOMOCLAVE = new Declara_V2.StringFilter(oUsuario.VID_HOMOCLAVE);
            oBusqueda.NID_TIPO_DECLARACION = new Declara_V2.IntegerFilter(Decla);
            //oBusqueda.NID_ESTADO = new Declara_V2.IntegerFilter(1);
            oBusqueda.select();
            if (oBusqueda.lista_DECLARACION.Any())
            {
                QstBox.AskWarning("Para Poder presentar declaración de conflicto de Intereses antes deberá tener por lo menos una declaración incial o de modificación enviada</b>.</b><br><br><br> <h3><p style='color:#FF0000';> ¿Realmente desea realizar la declaración de Conflicto? </p></h3>");
            }
            else
            {
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE
                                                                    , oUsuario.VID_FECHA
                                                                    , oUsuario.VID_HOMOCLAVE
                                                                    //, (DateTime.Now.Year - 1).ToString()
                                                                    , Decla
                                                                    , true);
                SessionAdd("oDeclaracion", oDeclaracion);
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            int Decla = 0;
            int Regreso;
            blld_USUARIO oUsuario = _oUsuario;
           
            Decla = TomaDesicion(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE);
            
            if(Decla==0)
            {
                QstBox.AskWarning("Para Poder presentar declaración de conflicto de Intereses antes deberá tener por lo menos una declaración incial o de modificación enviada</b>.</b><br><br><br> <h3><p style='color:#FF0000';> ¿Realmente desea realizar la declaración de Conflicto? </p></h3>");
            }
            else
            {


                try
                {
                   
                    
                    Decla = TomaDesicion(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE);

                    //blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, Decla);

                    blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, Decla);

                    Regreso = CreaRegistro(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, oDeclaracion.NID_TIPO_DECLARACION, oDeclaracion.C_EJERCICIO, Decla);
                    
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO = false;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().update();
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO = false;
                    oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().update();
                    SessionAdd("oDeclaracion", oDeclaracion);

                }
                catch
                {

                }

                Response.Redirect("DeclaracionConflicto" +
                       "\\DatosGenerales.aspx");

            }

            //try
            //{ 
            //blld_USUARIO oUsuario = _oUsuario;
            //int Decla = 0;
            //int Regreso;
            //Decla = TomaDesicion(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE);

            //blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, Decla);

            //Regreso = CreaRegistro(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE, oDeclaracion.NID_TIPO_DECLARACION, oDeclaracion.C_EJERCICIO, oDeclaracion.NID_DECLARACION);

            //oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO = false;
            //oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().update();
            //oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO = false;
            //oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().update();
            //SessionAdd("oDeclaracion", oDeclaracion);

            //}
            //catch
            //{
            //   
            //}

            //Response.Redirect("DeclaracionConflicto" +
            //       "\\DatosGenerales.aspx");

        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void QstBox_No(object Sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void QstBox_Yes(object Sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                int Decla = 0;
                int Regreso;
                Decla = TomaDesicion(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE);

                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, Decla);
              
                Regreso =CreaRegistro(oDeclaracion.VID_NOMBRE, oDeclaracion.VID_FECHA, oDeclaracion.VID_HOMOCLAVE,oDeclaracion.NID_TIPO_DECLARACION, oDeclaracion.C_EJERCICIO, oDeclaracion.NID_DECLARACION);
                //Valida el tipo de Declaracion paso por aqui
             
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().L_ESTADO = false;
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 14).First().update();
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().L_ESTADO = false;
                oDeclaracion.DECLARACION_APARTADOs.Where(p => p.NID_APARTADO == 15).First().update();
                SessionAdd("oDeclaracion", oDeclaracion);
                
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    try { Session.Remove("oDeclaracion"); } catch { }
                    SessionAdd("oMensaje", ex.Message);
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    throw ex;
                }
            }
        }
        internal static int TomaDesicion(string Nombre,string Fecha,string Homo)
        {

            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in dbInt.DECLARACION
                              where p.VID_NOMBRE == Nombre && p.VID_FECHA == Fecha && p.VID_HOMOCLAVE == Homo && p.NID_TIPO_DECLARACION != 3 && p.NID_ESTADO >1 && p.NID_ESTADO < 6

                              select p.NID_DECLARACION ).Max());
                return query;

            }
            catch
            {
                return 0;
            }
        }
        internal static int CreaRegistro(string Nombre, string Fecha, string Homo,int NID_TIPO_DECLARACION,string EJERCICIO,int NID_DECLARACION)
        {
           
            MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
            ObjectParameter nNID_DECLARACION = new ObjectParameter("NID_DECLARACION", NID_DECLARACION);

            /*sme*/


            if (NID_TIPO_DECLARACION > 0 & NID_TIPO_DECLARACION < 4)
                dbInt.paDECLARACION_NUEVA(Nombre, Fecha, Homo, NID_TIPO_DECLARACION, EJERCICIO, nNID_DECLARACION);
            else
                throw new CustomException("Error en tipo de declaración");
            return 0;

        }
    }
}