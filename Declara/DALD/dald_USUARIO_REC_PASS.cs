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
    internal partial class dald_USUARIO_REC_PASS : dal_USUARIO_REC_PASS
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_USUARIO_REC_PASS()
        : base() { }

        internal dald_USUARIO_REC_PASS(USUARIO_REC_PASS USUARIO_REC_PASS)
        : base(USUARIO_REC_PASS) { }

        internal dald_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO) { }

        public dald_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Int32 N_USOS, DateTime F_SOLICITUD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, N_USOS, F_SOLICITUD, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
