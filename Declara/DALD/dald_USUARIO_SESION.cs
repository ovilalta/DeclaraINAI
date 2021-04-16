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
    internal partial class dald_USUARIO_SESION : dal_USUARIO_SESION
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_USUARIO_SESION()
        : base() { }

        internal dald_USUARIO_SESION(USUARIO_SESION USUARIO_SESION)
        : base(USUARIO_SESION) { }

        internal dald_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_SESION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION) { }

        public dald_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_SESION, String V_IP, String V_MAQUINA_USUARIO, DateTime F_INICIO, DateTime F_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION, V_IP, V_MAQUINA_USUARIO, F_INICIO, F_FIN, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
