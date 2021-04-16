using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_NIVEL_GOBIERNO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_NIVEL_GOBIERNO datos_CAT_NIVEL_GOBIERNO { get; set; }
        public Int32 NID_NIVEL_GOBIERNO => datos_CAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNO;
        public String V_NIVEL_GOBIERNO
        {
            get => datos_CAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO;
            set => datos_CAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_NIVEL_GOBIERNO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_NIVEL_GOBIERNO() => datos_CAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO();
        public bll_CAT_NIVEL_GOBIERNO(MODELDeclara_V2.CAT_NIVEL_GOBIERNO CAT_NIVEL_GOBIERNO) => datos_CAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO(CAT_NIVEL_GOBIERNO);
        public bll_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO) => datos_CAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO(NID_NIVEL_GOBIERNO);

//        public bll_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO, String V_NIVEL_GOBIERNO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO();
//            Int32 _NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO; 
//            this.V_NIVEL_GOBIERNO = V_NIVEL_GOBIERNO;
//            datos_CAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO(_NID_NIVEL_GOBIERNO, this.NID_NIVEL_GOBIERNO, this.V_NIVEL_GOBIERNO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_NIVEL_GOBIERNO.update();
        }
        public void delete()
        {
            datos_CAT_NIVEL_GOBIERNO.delete();
        }
        public void reload()
        {
            datos_CAT_NIVEL_GOBIERNO.reload();
        }

        #endregion

    }
}
