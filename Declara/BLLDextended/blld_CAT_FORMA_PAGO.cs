using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_FORMA_PAGO : bll_CAT_FORMA_PAGO
    {

        #region *** Propiedades ***
//    new public Int32 NID_FORMA_PAGO => datos_CAT_FORMA_PAGO.NID_FORMA_PAGO;
//    new public String V_FORMA_PAGO
//        {
//            get => datos_CAT_FORMA_PAGO.V_FORMA_PAGO;
//            set => datos_CAT_FORMA_PAGO.V_FORMA_PAGO = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO, String V_FORMA_PAGO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_FORMA_PAGO = NID_FORMA_PAGO; 
            this.V_FORMA_PAGO = V_FORMA_PAGO;
            datos_CAT_FORMA_PAGO = new dald_CAT_FORMA_PAGO(_NID_FORMA_PAGO, this.V_FORMA_PAGO, lOpcionesRegistroExistente);
        }
        public blld_CAT_FORMA_PAGO(String V_FORMA_PAGO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_FORMA_PAGO = dald_CAT_FORMA_PAGO.nNuevo_NID_FORMA_PAGO();
            this.V_FORMA_PAGO = V_FORMA_PAGO;
            datos_CAT_FORMA_PAGO = new dald_CAT_FORMA_PAGO(_NID_FORMA_PAGO, this.V_FORMA_PAGO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
