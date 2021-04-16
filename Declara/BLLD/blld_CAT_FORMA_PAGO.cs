using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_FORMA_PAGO : bll_CAT_FORMA_PAGO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_FORMA_PAGO() : base() { }
        public blld_CAT_FORMA_PAGO(MODELDeclara_V2.CAT_FORMA_PAGO CAT_FORMA_PAGO) : base(CAT_FORMA_PAGO) { }
        public blld_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO) : base(NID_FORMA_PAGO) { }

//        public blld_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO, String V_FORMA_PAGO)
//        : base(NID_FORMA_PAGO, V_FORMA_PAGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
