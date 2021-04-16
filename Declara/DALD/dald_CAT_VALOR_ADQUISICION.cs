using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_VALOR_ADQUISICION : dal_CAT_VALOR_ADQUISICION
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_VALOR_ADQUISICION() : base() { }
        internal dald_CAT_VALOR_ADQUISICION(CAT_VALOR_ADQUISICION CAT_VALOR_ADQUISICION) : base(CAT_VALOR_ADQUISICION) { }
        internal dald_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION)
        : base(NID_VALOR_ADQUISICION) { }
        internal dald_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION, String V_VALOR_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_VALOR_ADQUISICION, V_VALOR_ADQUISICION, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
