using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_REGIMEN_MATRIMONIAL : bll_CAT_REGIMEN_MATRIMONIAL
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_REGIMEN_MATRIMONIAL() : base() { }
        public blld_CAT_REGIMEN_MATRIMONIAL(MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL CAT_REGIMEN_MATRIMONIAL) : base(CAT_REGIMEN_MATRIMONIAL) { }
        public blld_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL) : base(NID_REGIMEN_MATRIMONIAL) { }

//        public blld_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL, String V_REGIMEN_MATRIMONIAL)
//        : base(NID_REGIMEN_MATRIMONIAL, V_REGIMEN_MATRIMONIAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
