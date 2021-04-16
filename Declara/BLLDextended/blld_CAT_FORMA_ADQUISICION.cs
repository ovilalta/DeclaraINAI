using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_FORMA_ADQUISICION : bll_CAT_FORMA_ADQUISICION
    {

        #region *** Propiedades ***
//    new public Int32 NID_FORMA_ADQUISICION => datos_CAT_FORMA_ADQUISICION.NID_FORMA_ADQUISICION;
//    new public String V_FORMA_ADQUISICION
//        {
//            get => datos_CAT_FORMA_ADQUISICION.V_FORMA_ADQUISICION;
//            set => datos_CAT_FORMA_ADQUISICION.V_FORMA_ADQUISICION = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION, String V_FORMA_ADQUISICION)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION; 
            this.V_FORMA_ADQUISICION = V_FORMA_ADQUISICION;
            datos_CAT_FORMA_ADQUISICION = new dald_CAT_FORMA_ADQUISICION(_NID_FORMA_ADQUISICION, this.V_FORMA_ADQUISICION, lOpcionesRegistroExistente);
        }
        public blld_CAT_FORMA_ADQUISICION(String V_FORMA_ADQUISICION)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_FORMA_ADQUISICION = dald_CAT_FORMA_ADQUISICION.nNuevo_NID_FORMA_ADQUISICION();
            this.V_FORMA_ADQUISICION = V_FORMA_ADQUISICION;
            datos_CAT_FORMA_ADQUISICION = new dald_CAT_FORMA_ADQUISICION(_NID_FORMA_ADQUISICION, this.V_FORMA_ADQUISICION, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
