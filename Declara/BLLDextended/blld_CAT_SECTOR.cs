using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_SECTOR : bll_CAT_SECTOR
    {

        #region *** Propiedades ***
//    new public Int32 NID_SECTOR => datos_CAT_SECTOR.NID_SECTOR;
//    new public String V_SECTOR
//        {
//            get => datos_CAT_SECTOR.V_SECTOR;
//            set => datos_CAT_SECTOR.V_SECTOR = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_SECTOR(Int32 NID_SECTOR, String V_SECTOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_SECTOR = NID_SECTOR; 
            this.V_SECTOR = V_SECTOR;
            datos_CAT_SECTOR = new dald_CAT_SECTOR(_NID_SECTOR, this.V_SECTOR, lOpcionesRegistroExistente);
        }
        public blld_CAT_SECTOR(String V_SECTOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_SECTOR = dald_CAT_SECTOR.nNuevo_NID_SECTOR();
            this.V_SECTOR = V_SECTOR;
            datos_CAT_SECTOR = new dald_CAT_SECTOR(_NID_SECTOR, this.V_SECTOR, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
