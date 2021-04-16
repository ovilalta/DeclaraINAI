using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_ESTADO_ESCOLARIDAD : bll_CAT_ESTADO_ESCOLARIDAD
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_ESTADO_ESCOLARIDAD() : base() { }
        public blld_CAT_ESTADO_ESCOLARIDAD(MODELDeclara_V2.CAT_ESTADO_ESCOLARIDAD CAT_ESTADO_ESCOLARIDAD) : base(CAT_ESTADO_ESCOLARIDAD) { }
        public blld_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD) : base(NID_ESTADO_ESCOLARIDAD) { }

//        public blld_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD, String V_ESTADO_ESCOLARIDAD)
//        : base(NID_ESTADO_ESCOLARIDAD, V_ESTADO_ESCOLARIDAD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
