using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_DOCUMENTO_OBTENIDO : bll_CAT_DOCUMENTO_OBTENIDO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_DOCUMENTO_OBTENIDO() : base() { }
        public blld_CAT_DOCUMENTO_OBTENIDO(MODELDeclara_V2.CAT_DOCUMENTO_OBTENIDO CAT_DOCUMENTO_OBTENIDO) : base(CAT_DOCUMENTO_OBTENIDO) { }
        public blld_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO) : base(NID_DOCUMENTO_OBTENIDO) { }

//        public blld_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO, String V_DOCUMENTO_OBTENIDO)
//        : base(NID_DOCUMENTO_OBTENIDO, V_DOCUMENTO_OBTENIDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
