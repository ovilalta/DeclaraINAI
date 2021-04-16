using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_FORMA_ADQUISICION : bll_CAT_FORMA_ADQUISICION
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_FORMA_ADQUISICION() : base() { }
        public blld_CAT_FORMA_ADQUISICION(MODELDeclara_V2.CAT_FORMA_ADQUISICION CAT_FORMA_ADQUISICION) : base(CAT_FORMA_ADQUISICION) { }
        public blld_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION) : base(NID_FORMA_ADQUISICION) { }

//        public blld_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION, String V_FORMA_ADQUISICION)
//        : base(NID_FORMA_ADQUISICION, V_FORMA_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
