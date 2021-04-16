using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_DOCUMENTO_OBTENIDO : dal_CAT_DOCUMENTO_OBTENIDO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_DOCUMENTO_OBTENIDO() : base() { }
        internal dald_CAT_DOCUMENTO_OBTENIDO(CAT_DOCUMENTO_OBTENIDO CAT_DOCUMENTO_OBTENIDO) : base(CAT_DOCUMENTO_OBTENIDO) { }
        internal dald_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO)
        : base(NID_DOCUMENTO_OBTENIDO) { }
        internal dald_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO, String V_DOCUMENTO_OBTENIDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_DOCUMENTO_OBTENIDO, V_DOCUMENTO_OBTENIDO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
