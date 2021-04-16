using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_SECTOR : bll_CAT_SECTOR
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_SECTOR() : base() { }
        public blld_CAT_SECTOR(MODELDeclara_V2.CAT_SECTOR CAT_SECTOR) : base(CAT_SECTOR) { }
        public blld_CAT_SECTOR(Int32 NID_SECTOR) : base(NID_SECTOR) { }

//        public blld_CAT_SECTOR(Int32 NID_SECTOR, String V_SECTOR)
//        : base(NID_SECTOR, V_SECTOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
