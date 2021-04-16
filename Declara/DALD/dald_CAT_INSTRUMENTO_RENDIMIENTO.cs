using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_INSTRUMENTO_RENDIMIENTO : dal_CAT_INSTRUMENTO_RENDIMIENTO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_INSTRUMENTO_RENDIMIENTO() : base() { }
        internal dald_CAT_INSTRUMENTO_RENDIMIENTO(CAT_INSTRUMENTO_RENDIMIENTO CAT_INSTRUMENTO_RENDIMIENTO) : base(CAT_INSTRUMENTO_RENDIMIENTO) { }
        internal dald_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO)
        : base(NID_INSTRUMENTO_RENDIMIENTO) { }
        internal dald_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO, String V_INSTRUMENTO_RENDIMIENTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_INSTRUMENTO_RENDIMIENTO, V_INSTRUMENTO_RENDIMIENTO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
