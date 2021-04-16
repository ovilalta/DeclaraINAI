using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_NIVEL_ESCOLARIDAD : bll_CAT_NIVEL_ESCOLARIDAD
    {

        #region *** Propiedades ***
//    new public Int32 NID_NIVEL_ESCOLARIDAD => datos_CAT_NIVEL_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD;
//    new public String V_NIVEL_ESCOLARIDAD
//        {
//            get => datos_CAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD;
//            set => datos_CAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_NIVEL_ESCOLARIDAD(Int32 NID_NIVEL_ESCOLARIDAD, String V_NIVEL_ESCOLARIDAD)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_NIVEL_ESCOLARIDAD = NID_NIVEL_ESCOLARIDAD; 
            this.V_NIVEL_ESCOLARIDAD = V_NIVEL_ESCOLARIDAD;
            datos_CAT_NIVEL_ESCOLARIDAD = new dald_CAT_NIVEL_ESCOLARIDAD(_NID_NIVEL_ESCOLARIDAD, this.V_NIVEL_ESCOLARIDAD, lOpcionesRegistroExistente);
        }
        public blld_CAT_NIVEL_ESCOLARIDAD(String V_NIVEL_ESCOLARIDAD)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_NIVEL_ESCOLARIDAD = dald_CAT_NIVEL_ESCOLARIDAD.nNuevo_NID_NIVEL_ESCOLARIDAD();
            this.V_NIVEL_ESCOLARIDAD = V_NIVEL_ESCOLARIDAD;
            datos_CAT_NIVEL_ESCOLARIDAD = new dald_CAT_NIVEL_ESCOLARIDAD(_NID_NIVEL_ESCOLARIDAD, this.V_NIVEL_ESCOLARIDAD, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
