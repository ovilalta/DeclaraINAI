using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_RELACION_TRANSMISOR : dal_CAT_RELACION_TRANSMISOR
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_RELACION_TRANSMISOR() : base() { }
        internal dald_CAT_RELACION_TRANSMISOR(CAT_RELACION_TRANSMISOR CAT_RELACION_TRANSMISOR) : base(CAT_RELACION_TRANSMISOR) { }
        internal dald_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR)
        : base(NID_RELACION_TRANSMISOR) { }
        internal dald_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR, String V_RELACION_TRANSMISOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_RELACION_TRANSMISOR, V_RELACION_TRANSMISOR, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
