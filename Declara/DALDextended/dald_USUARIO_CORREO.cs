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
    internal partial class dald_USUARIO_CORREO : dal_USUARIO_CORREO
    {

        #region *** Atributos (Extended) ***


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        internal static Boolean EsPrincipal(string vID_NOMBRE, string vID_FECHA, string vID_HOMOCLAVE)
        {
            MODELDeclara_V2.cnxDeclara db = new cnxDeclara();
            try
            {
                return !Convert.ToBoolean((from p in db.USUARIO_CORREO
                        where p.VID_NOMBRE == vID_NOMBRE &&
                              p.VID_FECHA == vID_FECHA &&
                              p.VID_HOMOCLAVE == vID_HOMOCLAVE &&
                              p.L_ACTIVO
                        select p).Count());
            }
            catch
            {
                return true;
            }
        }

        internal static bool ExisteCorreo(string v_CORREO)
        {
            try
            {
                MODELDeclara_V2.cnxDeclara db = new cnxDeclara();
                return Convert.ToBoolean((from p in db.USUARIO_CORREO
                                           where p.V_CORREO == v_CORREO &&
                                                 p.L_CONFIRMADO &&
                                                 p.L_ACTIVO
                                           select p).Count());
            }
            catch
            {
                return false;
            }
        }

        internal static bool CorreoActivo(string v_CORREO)
        {
            try
            {
                MODELDeclara_V2.cnxDeclara db = new cnxDeclara();
                return Convert.ToBoolean((from p in db.USUARIO_CORREO
                                          where p.V_CORREO == v_CORREO &&
                                                p.L_ACTIVO
                                          select p).Count());
            }
            catch
            {
                return false;
            }
        }

        internal static bool CorreoConfirmado(string v_CORREO)
        {
            try
            {
                MODELDeclara_V2.cnxDeclara db = new cnxDeclara();
                return Convert.ToBoolean((from p in db.USUARIO_CORREO
                                          where p.V_CORREO == v_CORREO &&
                                                p.L_CONFIRMADO
                                          select p).Count());
            }
            catch
            {
                return false;
            }
        }
        #endregion

    }
}
