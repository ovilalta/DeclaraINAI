using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_FORMA_ADQUISICION : dal_CAT_FORMA_ADQUISICION
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_FORMA_ADQUISICION() : base() { }
        internal dald_CAT_FORMA_ADQUISICION(CAT_FORMA_ADQUISICION CAT_FORMA_ADQUISICION) : base(CAT_FORMA_ADQUISICION) { }
        internal dald_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION)
        : base(NID_FORMA_ADQUISICION) { }
        internal dald_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION, String V_FORMA_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_FORMA_ADQUISICION, V_FORMA_ADQUISICION, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
