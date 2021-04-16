using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_NIVEL_GOBIERNO : bll_CAT_NIVEL_GOBIERNO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_NIVEL_GOBIERNO() : base() { }
        public blld_CAT_NIVEL_GOBIERNO(MODELDeclara_V2.CAT_NIVEL_GOBIERNO CAT_NIVEL_GOBIERNO) : base(CAT_NIVEL_GOBIERNO) { }
        public blld_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO) : base(NID_NIVEL_GOBIERNO) { }

//        public blld_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO, String V_NIVEL_GOBIERNO)
//        : base(NID_NIVEL_GOBIERNO, V_NIVEL_GOBIERNO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
