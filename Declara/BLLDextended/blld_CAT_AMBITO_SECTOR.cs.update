using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_AMBITO_SECTOR : bll_CAT_AMBITO_SECTOR
    {

        #region *** Propiedades ***
//    new public Int32 NID_AMBITO_SECTOR => datos_CAT_AMBITO_SECTOR.NID_AMBITO_SECTOR;
//    new public String V_AMBITO_SECTOR
//        {
//            get => datos_CAT_AMBITO_SECTOR.V_AMBITO_SECTOR;
//            set => datos_CAT_AMBITO_SECTOR.V_AMBITO_SECTOR = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR, String V_AMBITO_SECTOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_AMBITO_SECTOR = NID_AMBITO_SECTOR; 
            this.V_AMBITO_SECTOR = V_AMBITO_SECTOR;
            datos_CAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR(_NID_AMBITO_SECTOR, this.V_AMBITO_SECTOR, lOpcionesRegistroExistente);
        }
        public blld_CAT_AMBITO_SECTOR(String V_AMBITO_SECTOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_AMBITO_SECTOR = dald_CAT_AMBITO_SECTOR.nNuevo_NID_AMBITO_SECTOR();
            this.V_AMBITO_SECTOR = V_AMBITO_SECTOR;
            datos_CAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR(_NID_AMBITO_SECTOR, this.V_AMBITO_SECTOR, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
