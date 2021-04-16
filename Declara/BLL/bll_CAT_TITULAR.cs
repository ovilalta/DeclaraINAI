using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_TITULAR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_TITULAR datos_CAT_TITULAR { get; set; }
        public Int32 NID_TITULAR => datos_CAT_TITULAR.NID_TITULAR;
        public String V_TITULAR
        {
            get => datos_CAT_TITULAR.V_TITULAR;
            set => datos_CAT_TITULAR.V_TITULAR = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_TITULAR.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_TITULAR() => datos_CAT_TITULAR = new dald_CAT_TITULAR();
        public bll_CAT_TITULAR(MODELDeclara_V2.CAT_TITULAR CAT_TITULAR) => datos_CAT_TITULAR = new dald_CAT_TITULAR(CAT_TITULAR);
        public bll_CAT_TITULAR(Int32 NID_TITULAR) => datos_CAT_TITULAR = new dald_CAT_TITULAR(NID_TITULAR);

//        public bll_CAT_TITULAR(Int32 NID_TITULAR, String V_TITULAR)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_TITULAR = new dald_CAT_TITULAR();
//            Int32 _NID_TITULAR = NID_TITULAR; 
//            this.V_TITULAR = V_TITULAR;
//            datos_CAT_TITULAR = new dald_CAT_TITULAR(_NID_TITULAR, this.NID_TITULAR, this.V_TITULAR, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_TITULAR.update();
        }
        public void delete()
        {
            datos_CAT_TITULAR.delete();
        }
        public void reload()
        {
            datos_CAT_TITULAR.reload();
        }

        #endregion

    }
}
