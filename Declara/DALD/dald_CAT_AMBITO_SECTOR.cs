using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_AMBITO_SECTOR : dal_CAT_AMBITO_SECTOR
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_AMBITO_SECTOR() : base() { }
        internal dald_CAT_AMBITO_SECTOR(CAT_AMBITO_SECTOR CAT_AMBITO_SECTOR) : base(CAT_AMBITO_SECTOR) { }
        internal dald_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR)
        : base(NID_AMBITO_SECTOR) { }
        internal dald_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR, String V_AMBITO_SECTOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_AMBITO_SECTOR, V_AMBITO_SECTOR, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
