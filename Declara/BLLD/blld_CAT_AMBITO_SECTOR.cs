using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_AMBITO_SECTOR : bll_CAT_AMBITO_SECTOR
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_AMBITO_SECTOR() : base() { }
        public blld_CAT_AMBITO_SECTOR(MODELDeclara_V2.CAT_AMBITO_SECTOR CAT_AMBITO_SECTOR) : base(CAT_AMBITO_SECTOR) { }
        public blld_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR) : base(NID_AMBITO_SECTOR) { }

//        public blld_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR, String V_AMBITO_SECTOR)
//        : base(NID_AMBITO_SECTOR, V_AMBITO_SECTOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
