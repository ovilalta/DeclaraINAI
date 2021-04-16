using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_ESTADO_ESCOLARIDAD : dal_CAT_ESTADO_ESCOLARIDAD
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_ESTADO_ESCOLARIDAD() : base() { }
        internal dald_CAT_ESTADO_ESCOLARIDAD(CAT_ESTADO_ESCOLARIDAD CAT_ESTADO_ESCOLARIDAD) : base(CAT_ESTADO_ESCOLARIDAD) { }
        internal dald_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD)
        : base(NID_ESTADO_ESCOLARIDAD) { }
        internal dald_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD, String V_ESTADO_ESCOLARIDAD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_ESTADO_ESCOLARIDAD, V_ESTADO_ESCOLARIDAD, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
