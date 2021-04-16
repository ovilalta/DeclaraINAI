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
    internal partial class dald_CAT_DENOMINACION : dal_CAT_DENOMINACION
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_DENOMINACION()
        : base() { }

        internal dald_CAT_DENOMINACION(CAT_DENOMINACION CAT_DENOMINACION)
        : base(CAT_DENOMINACION) { }

        internal dald_CAT_DENOMINACION(Int32 NID_DENOMINACION)
        : base(NID_DENOMINACION) { }

        public dald_CAT_DENOMINACION(Int32 NID_DENOMINACION, String V_DENOMINACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_DENOMINACION, V_DENOMINACION, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
