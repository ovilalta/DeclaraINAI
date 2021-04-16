using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2;
using Declara_V2.DAL;
using MODELDeclara_V2;
using Declara_V2.Exceptions;



namespace Declara_V2.DALD
{
// Extended
    internal partial class dald_USUARIO_SESION : dal_USUARIO_SESION
    {
        public static object Request { get; private set; }

        #region *** Atributos (Extended) ***


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***



        internal static int nUltimaSesion(string vID_NOMBRE, string vID_FECHA, string vID_HOMOCLAVE)
        {

            try
            {
                cnxDeclara db = new cnxDeclara();
                Int32 retorno;
                retorno = (from p in db.USUARIO_SESION
                           where p.VID_NOMBRE == vID_NOMBRE &&
                                 p.VID_FECHA == vID_FECHA &&
                                 p.VID_HOMOCLAVE == vID_HOMOCLAVE
                           select p.NID_SESION
                           ).Max();
                return retorno;
            }
            catch
            {
                return 0;
            }
        }

        internal static DateTime ULtimaF_Firma(string vID_NOMBRE, string vID_FECHA, string vID_HOMOCLAVE)
        {

            try
            {
                cnxDeclara db = new cnxDeclara();
                DateTime retorno;
                retorno = (from p in db.USUARIO_SESION
                           where p.VID_NOMBRE == vID_NOMBRE &&
                                 p.VID_FECHA == vID_FECHA &&
                                 p.VID_HOMOCLAVE == vID_HOMOCLAVE
                           select p.F_INICIO
                           ).Max();
                return retorno;
            }
            catch
            {
                return Convert.ToDateTime(System.DateTime.Today.ToShortDateString());
            }
        }
        internal static String UltimaIP(string vID_NOMBRE, string vID_FECHA, string vID_HOMOCLAVE)
        {

            try
            {
                cnxDeclara db = new cnxDeclara();
                String retorno;
                retorno = (from p in db.USUARIO_SESION
                           where p.VID_NOMBRE == vID_NOMBRE &&
                                 p.VID_FECHA == vID_FECHA &&
                                 p.VID_HOMOCLAVE == vID_HOMOCLAVE
                           select p.V_IP
                           ).Max();
                return retorno;
            }
            catch
            {
                return "";
            }
        }
       
        internal static int nNuevaSesion(string vID_NOMBRE, string vID_FECHA, string vID_HOMOCLAVE)
        {

            try
            {
                cnxDeclara db = new cnxDeclara();
                Int32 retorno;
                retorno = (from p in db.USUARIO_SESION
                           where p.VID_NOMBRE == vID_NOMBRE &&
                                 p.VID_FECHA == vID_FECHA &&
                                 p.VID_HOMOCLAVE == vID_HOMOCLAVE
                           select p.NID_SESION
                           ).Max() + 1;
                return retorno;
            }
            catch
            {
                return 1;
            }
        }

        #endregion

    }
}
