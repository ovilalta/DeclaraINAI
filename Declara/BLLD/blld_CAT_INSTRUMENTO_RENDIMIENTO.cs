using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_INSTRUMENTO_RENDIMIENTO : bll_CAT_INSTRUMENTO_RENDIMIENTO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_INSTRUMENTO_RENDIMIENTO() : base() { }
        public blld_CAT_INSTRUMENTO_RENDIMIENTO(MODELDeclara_V2.CAT_INSTRUMENTO_RENDIMIENTO CAT_INSTRUMENTO_RENDIMIENTO) : base(CAT_INSTRUMENTO_RENDIMIENTO) { }
        public blld_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO) : base(NID_INSTRUMENTO_RENDIMIENTO) { }

//        public blld_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO, String V_INSTRUMENTO_RENDIMIENTO)
//        : base(NID_INSTRUMENTO_RENDIMIENTO, V_INSTRUMENTO_RENDIMIENTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
