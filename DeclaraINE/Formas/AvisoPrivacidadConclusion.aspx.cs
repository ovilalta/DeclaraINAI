using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using System;
using System.Linq;

namespace DeclaraINAI.Formas
{
    public partial class AvisoPrivacidadConclusion : Pagina
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
            oBusqueda.NID_TIPO_DECLARACION = new Declara_V2.IntegerFilter(3);
            oBusqueda.NID_ESTADO = new Declara_V2.IntegerFilter(1);
            oBusqueda.select();
            if (!oBusqueda.lista_DECLARACION.Any())
            {
                QstBox.AskWarning("Cuando el servidor público concluye su encargo dispone de <b>60 días naturales</b> para presentar su <b>declaración patrimonial de conclusión</b>.<br><br><br> <h5 style='color:#FF0000';> ¿Realmente desea realizar la declaración de Conclusión? </h5>");
            }
            else
            {
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE
                                                                    , oUsuario.VID_FECHA
                                                                    , oUsuario.VID_HOMOCLAVE
                                                                    //, (DateTime.Now.Year - 1).ToString()
                                                                    , 3
                                                                    , true);
                SessionAdd("oDeclaracion", oDeclaracion);
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeclaracionConclusion" +
                "\\DatosGenerales.aspx");
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
                                                                    //, (DateTime.Now.Year - 1).ToString()
                                                                    , 3
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
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}