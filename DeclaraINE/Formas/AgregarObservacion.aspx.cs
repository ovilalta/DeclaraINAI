using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using System.IO;
using Declara_V2.BLLD;
using System.Web.Services;

namespace DeclaraINE.Formas
{
    
    public partial class AgregarObservacion : System.Web.UI.Page
    {
        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            //set => SessionAdd("oUsuario", value);
        }

        blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            //set => SessionAdd("oDeclaracion", value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            int idDec;
            idDec = Convert.ToInt32(Request.QueryString["idDec"]);
            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, idDec);

            //txtObservaciones.Text = oDeclaracion.E_OBSERVACIONES_MARCADO;
            //Prueba para recuperar datos, aqui debe recuperarse el dato del campo nuevo de aclaraciones
            //txtObservaciones.Text = oUsuario.V_NOMBRE_COMPLETO;
        }


        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaDeclaracion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;
            int idDec;
            string textoTest;
            idDec = Convert.ToInt32(Request.QueryString["idDec"]);
            blld_DECLARACION oDeclaracion = new blld_DECLARACION(oUsuario.VID_NOMBRE, oUsuario.VID_FECHA, oUsuario.VID_HOMOCLAVE, idDec);

            //oDeclaracion.ACLARACIONES = txtObservaciones.Text;
            textoTest = txtObservaciones.Text;
            //msgBox.ShowDanger(textoTest);

        }

        
                
    }
}