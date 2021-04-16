using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_TITULAR : dal_CAT_TITULAR
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_TITULAR() : base() { }
        internal dald_CAT_TITULAR(CAT_TITULAR CAT_TITULAR) : base(CAT_TITULAR) { }
        internal dald_CAT_TITULAR(Int32 NID_TITULAR)
        : base(NID_TITULAR) { }
        internal dald_CAT_TITULAR(Int32 NID_TITULAR, String V_TITULAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TITULAR, V_TITULAR, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
