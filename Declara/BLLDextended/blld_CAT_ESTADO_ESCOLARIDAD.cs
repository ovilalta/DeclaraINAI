using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_ESTADO_ESCOLARIDAD : bll_CAT_ESTADO_ESCOLARIDAD
    {

        #region *** Propiedades ***
//    new public Int32 NID_ESTADO_ESCOLARIDAD => datos_CAT_ESTADO_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD;
//    new public String V_ESTADO_ESCOLARIDAD
//        {
//            get => datos_CAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDAD;
//            set => datos_CAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDAD = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD, String V_ESTADO_ESCOLARIDAD)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_ESTADO_ESCOLARIDAD = NID_ESTADO_ESCOLARIDAD; 
            this.V_ESTADO_ESCOLARIDAD = V_ESTADO_ESCOLARIDAD;
            datos_CAT_ESTADO_ESCOLARIDAD = new dald_CAT_ESTADO_ESCOLARIDAD(_NID_ESTADO_ESCOLARIDAD, this.V_ESTADO_ESCOLARIDAD, lOpcionesRegistroExistente);
        }
        public blld_CAT_ESTADO_ESCOLARIDAD(String V_ESTADO_ESCOLARIDAD)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_ESTADO_ESCOLARIDAD = dald_CAT_ESTADO_ESCOLARIDAD.nNuevo_NID_ESTADO_ESCOLARIDAD();
            this.V_ESTADO_ESCOLARIDAD = V_ESTADO_ESCOLARIDAD;
            datos_CAT_ESTADO_ESCOLARIDAD = new dald_CAT_ESTADO_ESCOLARIDAD(_NID_ESTADO_ESCOLARIDAD, this.V_ESTADO_ESCOLARIDAD, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
