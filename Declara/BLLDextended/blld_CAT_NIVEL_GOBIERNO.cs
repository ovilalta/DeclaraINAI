using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_NIVEL_GOBIERNO : bll_CAT_NIVEL_GOBIERNO
    {

        #region *** Propiedades ***
//    new public Int32 NID_NIVEL_GOBIERNO => datos_CAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNO;
//    new public String V_NIVEL_GOBIERNO
//        {
//            get => datos_CAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO;
//            set => datos_CAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO, String V_NIVEL_GOBIERNO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO; 
            this.V_NIVEL_GOBIERNO = V_NIVEL_GOBIERNO;
            datos_CAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO(_NID_NIVEL_GOBIERNO, this.V_NIVEL_GOBIERNO, lOpcionesRegistroExistente);
        }
        public blld_CAT_NIVEL_GOBIERNO(String V_NIVEL_GOBIERNO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_NIVEL_GOBIERNO = dald_CAT_NIVEL_GOBIERNO.nNuevo_NID_NIVEL_GOBIERNO();
            this.V_NIVEL_GOBIERNO = V_NIVEL_GOBIERNO;
            datos_CAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO(_NID_NIVEL_GOBIERNO, this.V_NIVEL_GOBIERNO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
