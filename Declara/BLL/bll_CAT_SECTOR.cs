using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_SECTOR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_SECTOR datos_CAT_SECTOR { get; set; }
        public Int32 NID_SECTOR => datos_CAT_SECTOR.NID_SECTOR;
        public String V_SECTOR
        {
            get => datos_CAT_SECTOR.V_SECTOR;
            set => datos_CAT_SECTOR.V_SECTOR = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_SECTOR.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_SECTOR() => datos_CAT_SECTOR = new dald_CAT_SECTOR();
        public bll_CAT_SECTOR(MODELDeclara_V2.CAT_SECTOR CAT_SECTOR) => datos_CAT_SECTOR = new dald_CAT_SECTOR(CAT_SECTOR);
        public bll_CAT_SECTOR(Int32 NID_SECTOR) => datos_CAT_SECTOR = new dald_CAT_SECTOR(NID_SECTOR);

//        public bll_CAT_SECTOR(Int32 NID_SECTOR, String V_SECTOR)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_SECTOR = new dald_CAT_SECTOR();
//            Int32 _NID_SECTOR = NID_SECTOR; 
//            this.V_SECTOR = V_SECTOR;
//            datos_CAT_SECTOR = new dald_CAT_SECTOR(_NID_SECTOR, this.NID_SECTOR, this.V_SECTOR, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_SECTOR.update();
        }
        public void delete()
        {
            datos_CAT_SECTOR.delete();
        }
        public void reload()
        {
            datos_CAT_SECTOR.reload();
        }

        #endregion

    }
}
