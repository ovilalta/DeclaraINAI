using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_AMBITO_PUBLICO : bll_CAT_AMBITO_PUBLICO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_AMBITO_PUBLICO() : base() { }
        public blld_CAT_AMBITO_PUBLICO(MODELDeclara_V2.CAT_AMBITO_PUBLICO CAT_AMBITO_PUBLICO) : base(CAT_AMBITO_PUBLICO) { }
        public blld_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO) : base(NID_AMBITO_PUBLICO) { }

//        public blld_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO, String V_AMBITO_PUBLICO)
//        : base(NID_AMBITO_PUBLICO, V_AMBITO_PUBLICO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
