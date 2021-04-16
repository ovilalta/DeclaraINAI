using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_CAT_FORMA_PAGO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_CAT_FORMA_PAGO datos_CAT_FORMA_PAGO { get; set; }
        public Int32 NID_FORMA_PAGO => datos_CAT_FORMA_PAGO.NID_FORMA_PAGO;
        public String V_FORMA_PAGO
        {
            get => datos_CAT_FORMA_PAGO.V_FORMA_PAGO;
            set => datos_CAT_FORMA_PAGO.V_FORMA_PAGO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_CAT_FORMA_PAGO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_CAT_FORMA_PAGO() => datos_CAT_FORMA_PAGO = new dald_CAT_FORMA_PAGO();
        public bll_CAT_FORMA_PAGO(MODELDeclara_V2.CAT_FORMA_PAGO CAT_FORMA_PAGO) => datos_CAT_FORMA_PAGO = new dald_CAT_FORMA_PAGO(CAT_FORMA_PAGO);
        public bll_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO) => datos_CAT_FORMA_PAGO = new dald_CAT_FORMA_PAGO(NID_FORMA_PAGO);

//        public bll_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO, String V_FORMA_PAGO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_CAT_FORMA_PAGO = new dald_CAT_FORMA_PAGO();
//            Int32 _NID_FORMA_PAGO = NID_FORMA_PAGO; 
//            this.V_FORMA_PAGO = V_FORMA_PAGO;
//            datos_CAT_FORMA_PAGO = new dald_CAT_FORMA_PAGO(_NID_FORMA_PAGO, this.NID_FORMA_PAGO, this.V_FORMA_PAGO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_CAT_FORMA_PAGO.update();
        }
        public void delete()
        {
            datos_CAT_FORMA_PAGO.delete();
        }
        public void reload()
        {
            datos_CAT_FORMA_PAGO.reload();
        }

        #endregion

    }
}
