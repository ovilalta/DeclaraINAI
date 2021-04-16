using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_REGIMEN_MATRIMONIAL : dal_CAT_REGIMEN_MATRIMONIAL
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_REGIMEN_MATRIMONIAL() : base() { }
        internal dald_CAT_REGIMEN_MATRIMONIAL(CAT_REGIMEN_MATRIMONIAL CAT_REGIMEN_MATRIMONIAL) : base(CAT_REGIMEN_MATRIMONIAL) { }
        internal dald_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL)
        : base(NID_REGIMEN_MATRIMONIAL) { }
        internal dald_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL, String V_REGIMEN_MATRIMONIAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_REGIMEN_MATRIMONIAL, V_REGIMEN_MATRIMONIAL, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
