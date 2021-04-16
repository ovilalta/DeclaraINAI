using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_NIVEL_ESCOLARIDAD : bll_CAT_NIVEL_ESCOLARIDAD
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_NIVEL_ESCOLARIDAD() : base() { }
        public blld_CAT_NIVEL_ESCOLARIDAD(MODELDeclara_V2.CAT_NIVEL_ESCOLARIDAD CAT_NIVEL_ESCOLARIDAD) : base(CAT_NIVEL_ESCOLARIDAD) { }
        public blld_CAT_NIVEL_ESCOLARIDAD(Int32 NID_NIVEL_ESCOLARIDAD) : base(NID_NIVEL_ESCOLARIDAD) { }

//        public blld_CAT_NIVEL_ESCOLARIDAD(Int32 NID_NIVEL_ESCOLARIDAD, String V_NIVEL_ESCOLARIDAD)
//        : base(NID_NIVEL_ESCOLARIDAD, V_NIVEL_ESCOLARIDAD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
