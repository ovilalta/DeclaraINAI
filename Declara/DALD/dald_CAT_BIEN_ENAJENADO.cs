using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_BIEN_ENAJENADO : dal_CAT_BIEN_ENAJENADO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_BIEN_ENAJENADO() : base() { }
        internal dald_CAT_BIEN_ENAJENADO(CAT_BIEN_ENAJENADO CAT_BIEN_ENAJENADO) : base(CAT_BIEN_ENAJENADO) { }
        internal dald_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO)
        : base(NID_BIEN_ENAJENADO) { }
        internal dald_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO, String V_BIEN_ENAJENADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_BIEN_ENAJENADO, V_BIEN_ENAJENADO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
