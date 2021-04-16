using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_BIEN_ENAJENADO : bll_CAT_BIEN_ENAJENADO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_BIEN_ENAJENADO() : base() { }
        public blld_CAT_BIEN_ENAJENADO(MODELDeclara_V2.CAT_BIEN_ENAJENADO CAT_BIEN_ENAJENADO) : base(CAT_BIEN_ENAJENADO) { }
        public blld_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO) : base(NID_BIEN_ENAJENADO) { }

//        public blld_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO, String V_BIEN_ENAJENADO)
//        : base(NID_BIEN_ENAJENADO, V_BIEN_ENAJENADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
