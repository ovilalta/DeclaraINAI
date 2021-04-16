using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_RELACION_TRANSMISOR : bll_CAT_RELACION_TRANSMISOR
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_RELACION_TRANSMISOR() : base() { }
        public blld_CAT_RELACION_TRANSMISOR(MODELDeclara_V2.CAT_RELACION_TRANSMISOR CAT_RELACION_TRANSMISOR) : base(CAT_RELACION_TRANSMISOR) { }
        public blld_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR) : base(NID_RELACION_TRANSMISOR) { }

//        public blld_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR, String V_RELACION_TRANSMISOR)
//        : base(NID_RELACION_TRANSMISOR, V_RELACION_TRANSMISOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
