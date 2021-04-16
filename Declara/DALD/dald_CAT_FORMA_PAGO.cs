using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_FORMA_PAGO : dal_CAT_FORMA_PAGO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_FORMA_PAGO() : base() { }
        internal dald_CAT_FORMA_PAGO(CAT_FORMA_PAGO CAT_FORMA_PAGO) : base(CAT_FORMA_PAGO) { }
        internal dald_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO)
        : base(NID_FORMA_PAGO) { }
        internal dald_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO, String V_FORMA_PAGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_FORMA_PAGO, V_FORMA_PAGO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
