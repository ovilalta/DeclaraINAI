using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_VALOR_ADQUISICION : bll_CAT_VALOR_ADQUISICION
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_VALOR_ADQUISICION() : base() { }
        public blld_CAT_VALOR_ADQUISICION(MODELDeclara_V2.CAT_VALOR_ADQUISICION CAT_VALOR_ADQUISICION) : base(CAT_VALOR_ADQUISICION) { }
        public blld_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION) : base(NID_VALOR_ADQUISICION) { }

//        public blld_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION, String V_VALOR_ADQUISICION)
//        : base(NID_VALOR_ADQUISICION, V_VALOR_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
