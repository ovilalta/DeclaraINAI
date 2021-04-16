using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_VALOR_ADQUISICION : bll_CAT_VALOR_ADQUISICION
    {

        #region *** Propiedades ***
//    new public Int32 NID_VALOR_ADQUISICION => datos_CAT_VALOR_ADQUISICION.NID_VALOR_ADQUISICION;
//    new public String V_VALOR_ADQUISICION
//        {
//            get => datos_CAT_VALOR_ADQUISICION.V_VALOR_ADQUISICION;
//            set => datos_CAT_VALOR_ADQUISICION.V_VALOR_ADQUISICION = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION, String V_VALOR_ADQUISICION)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_VALOR_ADQUISICION = NID_VALOR_ADQUISICION; 
            this.V_VALOR_ADQUISICION = V_VALOR_ADQUISICION;
            datos_CAT_VALOR_ADQUISICION = new dald_CAT_VALOR_ADQUISICION(_NID_VALOR_ADQUISICION, this.V_VALOR_ADQUISICION, lOpcionesRegistroExistente);
        }
        public blld_CAT_VALOR_ADQUISICION(String V_VALOR_ADQUISICION)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_VALOR_ADQUISICION = dald_CAT_VALOR_ADQUISICION.nNuevo_NID_VALOR_ADQUISICION();
            this.V_VALOR_ADQUISICION = V_VALOR_ADQUISICION;
            datos_CAT_VALOR_ADQUISICION = new dald_CAT_VALOR_ADQUISICION(_NID_VALOR_ADQUISICION, this.V_VALOR_ADQUISICION, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
