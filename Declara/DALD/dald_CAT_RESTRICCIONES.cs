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
    internal partial class dald_CAT_RESTRICCIONES : dal_CAT_RESTRICCIONES
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_RESTRICCIONES()
        : base() { }

        internal dald_CAT_RESTRICCIONES(CAT_RESTRICCIONES CAT_RESTRICCIONES)
        : base(CAT_RESTRICCIONES) { }

        internal dald_CAT_RESTRICCIONES(Int32 NID_RESTRICCION)
        : base(NID_RESTRICCION) { }

        public dald_CAT_RESTRICCIONES(Int32 NID_RESTRICCION, String V_RESTRICCION, Boolean L_VIGENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_RESTRICCION, V_RESTRICCION, L_VIGENTE, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
