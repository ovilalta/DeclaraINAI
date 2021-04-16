using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_SECTOR : dal_CAT_SECTOR
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_SECTOR() : base() { }
        internal dald_CAT_SECTOR(CAT_SECTOR CAT_SECTOR) : base(CAT_SECTOR) { }
        internal dald_CAT_SECTOR(Int32 NID_SECTOR)
        : base(NID_SECTOR) { }
        internal dald_CAT_SECTOR(Int32 NID_SECTOR, String V_SECTOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_SECTOR, V_SECTOR, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
