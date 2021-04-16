using Declara_V2.BLLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using System.Globalization;
using AlanWebControls;

namespace DeclaraINE.Formas
{
    public partial class AvisoPrivacidadDeclaracionModificacion : Pagina
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
            oBusqueda.NID_TIPO_DECLARACION = new Declara_V2.IntegerFilter(2);
            oBusqueda.NID_ESTADO = new Declara_V2.IntegerFilter(1);
            oBusqueda.select();
            if (!oBusqueda.lista_DECLARACION.Any())
            {
                //QstBox.AskWarning("Los servidores públicos desde el nivel de jefe de departamento u homólogo hasta el de Consejero Presidente, sean de plaza presupuestal o contratados por honorarios, así como aquellos que manejen o apliquen recursos económicos y/o intervengan en la adjudicación de pedidos o contratos, están obligados a presentar la declaración de situación y de <b>modificación patrimonial</b> ante el <b>Órgano Interno de Control de este Instituto Nacional Electoral.</b><br><br><br> <h3><p style='color:#FF0000';> ¿Realmente desea realizar la declaración de Modificación Patrimonial? </p></h3>");
                ValidaDeclaracion();
            }
            else {
               
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE
                                                                    , oUsuario.VID_FECHA
                                                                    , oUsuario.VID_HOMOCLAVE
                                                                    //, (DateTime.Now.Year - 1).ToString()
                                                                    , 2
                                                                    ,true);
                SessionAdd("oDeclaracion", oDeclaracion);
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeclaracionModificacion\\DatosGenerales.aspx");
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void QstBox_No(object Sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }


        protected void ValidaDeclaracion()
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                ////int checa_mes = DateTime.Now.Month;
                ////int AnioDecla = 0;
                ////if (checa_mes >= 1 && checa_mes <= 4)
                ////    AnioDecla = DateTime.Now.Year - 2;
                ////else
                ////    AnioDecla = DateTime.Now.Year - 1;
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE
                                                                    , oUsuario.VID_FECHA
                                                                    , oUsuario.VID_HOMOCLAVE
                                                                    , 2
                                                                    , true);
                SessionAdd("oDeclaracion", oDeclaracion);
                //  Response.Redirect("AvisoPrivacidadDeclaracionModificacion.aspx");
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
                else
                {
                    throw ex;
                }
            }
        }


        protected void QstBox_Yes(object Sender, EventArgs e)
        {
            try
            {
                blld_USUARIO oUsuario = _oUsuario;
                ////int checa_mes = DateTime.Now.Month;
                ////int AnioDecla = 0;
                ////if (checa_mes >= 1 && checa_mes <= 4)
                ////    AnioDecla = DateTime.Now.Year - 2;
                ////else
                ////    AnioDecla = DateTime.Now.Year - 1;
                blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE
                                                                    , oUsuario.VID_FECHA
                                                                    , oUsuario.VID_HOMOCLAVE
                                                                    , 2
                                                                    ,true);
                SessionAdd("oDeclaracion", oDeclaracion);
              //  Response.Redirect("AvisoPrivacidadDeclaracionModificacion.aspx");
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
                else
                {
                    throw ex;
                }
            }
        }
    }
}