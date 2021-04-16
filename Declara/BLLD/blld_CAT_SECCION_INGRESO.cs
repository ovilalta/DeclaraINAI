using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_SECCION_INGRESO : bll_CAT_SECCION_INGRESO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_CAT_SECCION_INGRESO() : base() { }
        public blld_CAT_SECCION_INGRESO(MODELDeclara_V2.CAT_SECCION_INGRESO CAT_SECCION_INGRESO) : base(CAT_SECCION_INGRESO) { }
        public blld_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO) : base(NID_SECCION, NID_RUBRO) { }

//        public blld_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO, String V_RUBRO, Boolean L_VIGENTE, String CID_TIPO, Int32 NID_RUBRO_SUMA, String C_TITULAR, String V_CATALOGO)
//        : base(NID_SECCION, NID_RUBRO, V_RUBRO, L_VIGENTE, CID_TIPO, NID_RUBRO_SUMA, C_TITULAR, V_CATALOGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
