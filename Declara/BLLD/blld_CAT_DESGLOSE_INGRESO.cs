using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_DESGLOSE_INGRESO : bll_CAT_DESGLOSE_INGRESO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_DESGLOSE_INGRESO() : base() { }
        public blld_CAT_DESGLOSE_INGRESO(MODELDeclara_V2.CAT_DESGLOSE_INGRESO CAT_DESGLOSE_INGRESO) : base(CAT_DESGLOSE_INGRESO) { }
        public blld_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO) : base(NID_INGRESO_SUPERIOR, NID_INGRESO) { }

//        public blld_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO, String V_INGRESO, Boolean L_VIGENTE)
//        : base(NID_INGRESO_SUPERIOR, NID_INGRESO, V_INGRESO, L_VIGENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
