
using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using System;
using System.Linq;

namespace DeclaraINAI.Formas
{
    public partial class AvisoPrivacidadDeclaracionInicial : Pagina
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

        blld_DECLARACION_APARTADO _APARTADO
        {
            get => (blld_DECLARACION_APARTADO)Session["APARTADO"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_oUsuario == null)
                Response.Redirect("Login.aspx");

            //if (_oDeclaracion == null)
            //    Response.Redirect("Index.aspx");
            if (!IsPostBack)
            {
                Apartados();
            }

        }
        private void Apartados()
        {
            blld_USUARIO oUsuario = _oUsuario;
            blld__l_DECLARACION oBusqueda = new blld__l_DECLARACION();
            oBusqueda.VID_NOMBRE = new Declara_V2.StringFilter(oUsuario.VID_NOMBRE);
            oBusqueda.VID_FECHA = new Declara_V2.StringFilter(oUsuario.VID_FECHA);
            oBusqueda.VID_HOMOCLAVE = new Declara_V2.StringFilter(oUsuario.VID_HOMOCLAVE);
            oBusqueda.NID_TIPO_DECLARACION = new Declara_V2.IntegerFilter(1);
            oBusqueda.NID_ESTADO = new Declara_V2.IntegerFilter(1);
            oBusqueda.select();
            if (!oBusqueda.lista_DECLARACION.Any())
            {
                QstBox.AskWarning(" Una vez que el servidor público ha iniciado su encargo debe presentar su <b>declaración patrimonial inicial</b> dentro de los <b>60 días naturales</b> siguientes. </b><br><br><br> <h3><p style='color:#FF0000';> ¿Realmente desea realizar la declaración de Inicio?</p></h3>");
            }
            else
            {
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE
                                                                                   , oUsuario.VID_FECHA
                                                                                   , oUsuario.VID_HOMOCLAVE
                                                                                   //, DateTime.Now.Year.ToString()
                                                                                   , 1
                                                                                   , true);
                SessionAdd("oDeclaracion", oDeclaracion);
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("DeclaracionInicial\\DatosGenerales.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE
                                                                    , oUsuario.VID_FECHA
                                                                    , oUsuario.VID_HOMOCLAVE
                                                                    //, DateTime.Now.Year.ToString()
                                                                    , 1
                                                                    , true);
                SessionAdd("oDeclaracion", oDeclaracion);
            }
            catch (Exception ex)
            {
                if (ex is CustomException || ex is ConvertionException)
                {
                    try { Session.Remove("oDeclaracion"); } catch { }
                    SessionAdd("oMensaje", ex.Message);
                    Response.Redirect("Index.aspx");
                    //MsgBox.ShowDanger(ex.Message);
                }
                else throw ex;
            }

        }

    }
}