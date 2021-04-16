using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_TITULAR : bll_CAT_TITULAR
    {

        #region *** Propiedades ***
//    new public Int32 NID_TITULAR => datos_CAT_TITULAR.NID_TITULAR;
//    new public String V_TITULAR
//        {
//            get => datos_CAT_TITULAR.V_TITULAR;
//            set => datos_CAT_TITULAR.V_TITULAR = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_TITULAR(Int32 NID_TITULAR, String V_TITULAR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_TITULAR = NID_TITULAR; 
            this.V_TITULAR = V_TITULAR;
            datos_CAT_TITULAR = new dald_CAT_TITULAR(_NID_TITULAR, this.V_TITULAR, lOpcionesRegistroExistente);
        }
        public blld_CAT_TITULAR(String V_TITULAR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_TITULAR = dald_CAT_TITULAR.nNuevo_NID_TITULAR();
            this.V_TITULAR = V_TITULAR;
            datos_CAT_TITULAR = new dald_CAT_TITULAR(_NID_TITULAR, this.V_TITULAR, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
