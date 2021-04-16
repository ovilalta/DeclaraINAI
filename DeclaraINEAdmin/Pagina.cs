//using AlanWebControls;
using DeclaraINEAdmin.file;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINEAdmin
{
    public class Pagina : System.Web.UI.Page
    {

        public static CultureInfo esMX => new CultureInfo("es-MX");
        public static String strFormatoFecha
        {
            get
            {
                return "dd/MM/yyyy";
            }
        }

        public static String Object1
        {
            get
            {
                return "Object1";
            }
        }

        public static String Object2
        {
            get
            {
                return "Object2";
            }
        }

        public static SOAPHeaderCredentials FileServiceCredentials
        {
            get
            {
                SOAPHeaderCredentials retorno = new SOAPHeaderCredentials();
                retorno.UserName = "975F5D6B84413C5D76BCDEA6B33337D852BC7EFEAF1218C13141A";
                retorno.Password = "98C2E796B3448F8729695CF68F64205269CA7E993B02B55E745ECDE";
                return retorno;
            }
        }

        protected DateTime ObtenerFechaTextBox(TextBox txt)
        {
            if (String.IsNullOrEmpty(txt.Text)) throw new Exception("Debe escribir una fecha");
            return Convert.ToDateTime(txt.Text);
        }

        protected System.Nullable<DateTime> ObtenerFechaTextBoxNullable(TextBox txt)
        {
            if (String.IsNullOrEmpty(txt.Text)) return null;
            return Convert.ToDateTime(txt.Text);
        }

        protected Int32 ObtenerInt32TextBox(TextBox txt)
        {
            if (String.IsNullOrEmpty(txt.Text)) throw new Exception("Debe escribir un valor");
            else return Convert.ToInt32(txt.Text);
        }

        protected System.Nullable<Int32> ObtenerInt32TextBoxNullable(TextBox txt)
        {
            if (String.IsNullOrEmpty(txt.Text.Trim())) return null;
            else return Convert.ToInt32(txt.Text);
        }

        protected void SessionAdd(String ObjectName, Object Objeto)
        {
            if (Session[ObjectName] == null) Session.Add(ObjectName, Objeto);
            else Session[ObjectName] = Objeto;
        }

        protected void SessionAddSearch(Object Objeto)
        {
            if (Session[Object1] == null) Session.Add(Object1, Objeto);
            else Session[Object1] = Objeto;
        }

        protected void SessionAddDetails(Object Objeto)
        {
            if (Session[Object2] == null) Session.Add(Object2, Objeto);
            else Session[Object2] = Objeto;
        }

        protected static String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        protected static String RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        protected Int32[] ObtenerArregloCheckBoxListInt32(CheckBoxList cbl)
        {
            List<Int32> retorno = new List<int>();
            foreach (ListItem cbx in cbl.Items)
            {
                if (cbx.Selected)
                    retorno.Add(Convert.ToInt32(cbx.Value));
            }
            return retorno.ToArray();
        }

        //protected AlanMessageBox MessageBox
        //{
        //    get { return (AlanMessageBox)Master.FindControl("MessageBox"); }
        //}

        //protected static void ControlaExepciones(Exception ex)
        //{

        //}

        //protected void ControlaExepciones(AlanAlert alt, Exception ex)
        //{

        //}
    }
}