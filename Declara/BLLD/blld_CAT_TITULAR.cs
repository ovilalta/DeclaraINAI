using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_TITULAR : bll_CAT_TITULAR
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_TITULAR() : base() { }
        public blld_CAT_TITULAR(MODELDeclara_V2.CAT_TITULAR CAT_TITULAR) : base(CAT_TITULAR) { }
        public blld_CAT_TITULAR(Int32 NID_TITULAR) : base(NID_TITULAR) { }

//        public blld_CAT_TITULAR(Int32 NID_TITULAR, String V_TITULAR)
//        : base(NID_TITULAR, V_TITULAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
