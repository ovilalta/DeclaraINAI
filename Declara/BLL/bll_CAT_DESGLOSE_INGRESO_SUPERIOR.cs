using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_DESGLOSE_INGRESO_SUPERIOR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_DESGLOSE_INGRESO_SUPERIOR datos_CAT_DESGLOSE_INGRESO_SUPERIOR { get; set; }
        public Int32 NID_INGRESO_SUPERIOR => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIOR;
        public String V_INGRESO_SUPERIOR
        {
            get => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR;
            set => datos_CAT_DESGLOSE_INGRESO_SUPERIOR.V_INGRESO_SUPERIOR = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_DESGLOSE_INGRESO_SUPERIOR.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_DESGLOSE_INGRESO_SUPERIOR() => datos_CAT_DESGLOSE_INGRESO_SUPERIOR = new dald_CAT_DESGLOSE_INGRESO_SUPERIOR();
        public bll_CAT_DESGLOSE_INGRESO_SUPERIOR(MODELDeclara_V2.CAT_DESGLOSE_INGRESO_SUPERIOR CAT_DESGLOSE_INGRESO_SUPERIOR) => datos_CAT_DESGLOSE_INGRESO_SUPERIOR = new dald_CAT_DESGLOSE_INGRESO_SUPERIOR(CAT_DESGLOSE_INGRESO_SUPERIOR);
        public bll_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR) => datos_CAT_DESGLOSE_INGRESO_SUPERIOR = new dald_CAT_DESGLOSE_INGRESO_SUPERIOR(NID_INGRESO_SUPERIOR);

//        public bll_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR, String V_INGRESO_SUPERIOR)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_DESGLOSE_INGRESO_SUPERIOR = new dald_CAT_DESGLOSE_INGRESO_SUPERIOR();
//            Int32 _NID_INGRESO_SUPERIOR = NID_INGRESO_SUPERIOR; 
//            this.V_INGRESO_SUPERIOR = V_INGRESO_SUPERIOR;
//            datos_CAT_DESGLOSE_INGRESO_SUPERIOR = new dald_CAT_DESGLOSE_INGRESO_SUPERIOR(_NID_INGRESO_SUPERIOR, this.NID_INGRESO_SUPERIOR, this.V_INGRESO_SUPERIOR, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR.update();
        }
        public void delete()
        {
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR.delete();
        }
        public void reload()
        {
            datos_CAT_DESGLOSE_INGRESO_SUPERIOR.reload();
        }

        #endregion

    }
}
