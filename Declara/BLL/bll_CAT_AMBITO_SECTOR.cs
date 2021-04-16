using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_AMBITO_SECTOR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_AMBITO_SECTOR datos_CAT_AMBITO_SECTOR { get; set; }
        public Int32 NID_AMBITO_SECTOR => datos_CAT_AMBITO_SECTOR.NID_AMBITO_SECTOR;
        public String V_AMBITO_SECTOR
        {
            get => datos_CAT_AMBITO_SECTOR.V_AMBITO_SECTOR;
            set => datos_CAT_AMBITO_SECTOR.V_AMBITO_SECTOR = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_AMBITO_SECTOR.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_AMBITO_SECTOR() => datos_CAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR();
        public bll_CAT_AMBITO_SECTOR(MODELDeclara_V2.CAT_AMBITO_SECTOR CAT_AMBITO_SECTOR) => datos_CAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR(CAT_AMBITO_SECTOR);
        public bll_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR) => datos_CAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR(NID_AMBITO_SECTOR);

//        public bll_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR, String V_AMBITO_SECTOR)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR();
//            Int32 _NID_AMBITO_SECTOR = NID_AMBITO_SECTOR; 
//            this.V_AMBITO_SECTOR = V_AMBITO_SECTOR;
//            datos_CAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR(_NID_AMBITO_SECTOR, this.NID_AMBITO_SECTOR, this.V_AMBITO_SECTOR, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_AMBITO_SECTOR.update();
        }
        public void delete()
        {
            datos_CAT_AMBITO_SECTOR.delete();
        }
        public void reload()
        {
            datos_CAT_AMBITO_SECTOR.reload();
        }

        #endregion

    }
}
