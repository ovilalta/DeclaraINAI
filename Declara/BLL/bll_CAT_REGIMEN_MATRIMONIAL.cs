using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_REGIMEN_MATRIMONIAL : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_REGIMEN_MATRIMONIAL datos_CAT_REGIMEN_MATRIMONIAL { get; set; }
        public Int32 NID_REGIMEN_MATRIMONIAL => datos_CAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL;
        public String V_REGIMEN_MATRIMONIAL
        {
            get => datos_CAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL;
            set => datos_CAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_REGIMEN_MATRIMONIAL.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_REGIMEN_MATRIMONIAL() => datos_CAT_REGIMEN_MATRIMONIAL = new dald_CAT_REGIMEN_MATRIMONIAL();
        public bll_CAT_REGIMEN_MATRIMONIAL(MODELDeclara_V2.CAT_REGIMEN_MATRIMONIAL CAT_REGIMEN_MATRIMONIAL) => datos_CAT_REGIMEN_MATRIMONIAL = new dald_CAT_REGIMEN_MATRIMONIAL(CAT_REGIMEN_MATRIMONIAL);
        public bll_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL) => datos_CAT_REGIMEN_MATRIMONIAL = new dald_CAT_REGIMEN_MATRIMONIAL(NID_REGIMEN_MATRIMONIAL);

//        public bll_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL, String V_REGIMEN_MATRIMONIAL)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_REGIMEN_MATRIMONIAL = new dald_CAT_REGIMEN_MATRIMONIAL();
//            Int32 _NID_REGIMEN_MATRIMONIAL = NID_REGIMEN_MATRIMONIAL; 
//            this.V_REGIMEN_MATRIMONIAL = V_REGIMEN_MATRIMONIAL;
//            datos_CAT_REGIMEN_MATRIMONIAL = new dald_CAT_REGIMEN_MATRIMONIAL(_NID_REGIMEN_MATRIMONIAL, this.NID_REGIMEN_MATRIMONIAL, this.V_REGIMEN_MATRIMONIAL, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_REGIMEN_MATRIMONIAL.update();
        }
        public void delete()
        {
            datos_CAT_REGIMEN_MATRIMONIAL.delete();
        }
        public void reload()
        {
            datos_CAT_REGIMEN_MATRIMONIAL.reload();
        }

        #endregion

    }
}
