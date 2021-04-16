using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_NIVEL_ESCOLARIDAD : dal_CAT_NIVEL_ESCOLARIDAD
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_NIVEL_ESCOLARIDAD() : base() { }
        internal dald_CAT_NIVEL_ESCOLARIDAD(CAT_NIVEL_ESCOLARIDAD CAT_NIVEL_ESCOLARIDAD) : base(CAT_NIVEL_ESCOLARIDAD) { }
        internal dald_CAT_NIVEL_ESCOLARIDAD(Int32 NID_NIVEL_ESCOLARIDAD)
        : base(NID_NIVEL_ESCOLARIDAD) { }
        internal dald_CAT_NIVEL_ESCOLARIDAD(Int32 NID_NIVEL_ESCOLARIDAD, String V_NIVEL_ESCOLARIDAD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_NIVEL_ESCOLARIDAD, V_NIVEL_ESCOLARIDAD, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
