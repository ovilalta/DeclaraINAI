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
    internal partial class dald_USUARIO_CORREO : dal_USUARIO_CORREO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_USUARIO_CORREO()
        : base() { }

        internal dald_USUARIO_CORREO(USUARIO_CORREO USUARIO_CORREO)
        : base(USUARIO_CORREO) { }

        internal dald_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO) { }

        public dald_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Boolean L_PRINCIPAL, Boolean L_ACTIVO, Boolean L_CONFIRMADO,Int32 N_CODIGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, L_PRINCIPAL, L_ACTIVO, L_CONFIRMADO, N_CODIGO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
