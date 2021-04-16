using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_REGIMEN_MATRIMONIAL : bll_CAT_REGIMEN_MATRIMONIAL
    {

        #region *** Propiedades ***
//    new public Int32 NID_REGIMEN_MATRIMONIAL => datos_CAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL;
//    new public String V_REGIMEN_MATRIMONIAL
//        {
//            get => datos_CAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL;
//            set => datos_CAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL, String V_REGIMEN_MATRIMONIAL)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_REGIMEN_MATRIMONIAL = NID_REGIMEN_MATRIMONIAL; 
            this.V_REGIMEN_MATRIMONIAL = V_REGIMEN_MATRIMONIAL;
            datos_CAT_REGIMEN_MATRIMONIAL = new dald_CAT_REGIMEN_MATRIMONIAL(_NID_REGIMEN_MATRIMONIAL, this.V_REGIMEN_MATRIMONIAL, lOpcionesRegistroExistente);
        }
        public blld_CAT_REGIMEN_MATRIMONIAL(String V_REGIMEN_MATRIMONIAL)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_REGIMEN_MATRIMONIAL = dald_CAT_REGIMEN_MATRIMONIAL.nNuevo_NID_REGIMEN_MATRIMONIAL();
            this.V_REGIMEN_MATRIMONIAL = V_REGIMEN_MATRIMONIAL;
            datos_CAT_REGIMEN_MATRIMONIAL = new dald_CAT_REGIMEN_MATRIMONIAL(_NID_REGIMEN_MATRIMONIAL, this.V_REGIMEN_MATRIMONIAL, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
