using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_NIVEL_GOBIERNO : dal_CAT_NIVEL_GOBIERNO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_NIVEL_GOBIERNO() : base() { }
        internal dald_CAT_NIVEL_GOBIERNO(CAT_NIVEL_GOBIERNO CAT_NIVEL_GOBIERNO) : base(CAT_NIVEL_GOBIERNO) { }
        internal dald_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO)
        : base(NID_NIVEL_GOBIERNO) { }
        internal dald_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO, String V_NIVEL_GOBIERNO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_NIVEL_GOBIERNO, V_NIVEL_GOBIERNO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
