using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_BIEN_ENAJENADO : bll_CAT_BIEN_ENAJENADO
    {

        #region *** Propiedades ***
//    new public Int32 NID_BIEN_ENAJENADO => datos_CAT_BIEN_ENAJENADO.NID_BIEN_ENAJENADO;
//    new public String V_BIEN_ENAJENADO
//        {
//            get => datos_CAT_BIEN_ENAJENADO.V_BIEN_ENAJENADO;
//            set => datos_CAT_BIEN_ENAJENADO.V_BIEN_ENAJENADO = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO, String V_BIEN_ENAJENADO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_BIEN_ENAJENADO = NID_BIEN_ENAJENADO; 
            this.V_BIEN_ENAJENADO = V_BIEN_ENAJENADO;
            datos_CAT_BIEN_ENAJENADO = new dald_CAT_BIEN_ENAJENADO(_NID_BIEN_ENAJENADO, this.V_BIEN_ENAJENADO, lOpcionesRegistroExistente);
        }
        public blld_CAT_BIEN_ENAJENADO(String V_BIEN_ENAJENADO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_BIEN_ENAJENADO = dald_CAT_BIEN_ENAJENADO.nNuevo_NID_BIEN_ENAJENADO();
            this.V_BIEN_ENAJENADO = V_BIEN_ENAJENADO;
            datos_CAT_BIEN_ENAJENADO = new dald_CAT_BIEN_ENAJENADO(_NID_BIEN_ENAJENADO, this.V_BIEN_ENAJENADO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
