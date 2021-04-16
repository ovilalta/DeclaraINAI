using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_RELACION_TRANSMISOR : bll_CAT_RELACION_TRANSMISOR
    {

        #region *** Propiedades ***
//    new public Int32 NID_RELACION_TRANSMISOR => datos_CAT_RELACION_TRANSMISOR.NID_RELACION_TRANSMISOR;
//    new public String V_RELACION_TRANSMISOR
//        {
//            get => datos_CAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISOR;
//            set => datos_CAT_RELACION_TRANSMISOR.V_RELACION_TRANSMISOR = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR, String V_RELACION_TRANSMISOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_RELACION_TRANSMISOR = NID_RELACION_TRANSMISOR; 
            this.V_RELACION_TRANSMISOR = V_RELACION_TRANSMISOR;
            datos_CAT_RELACION_TRANSMISOR = new dald_CAT_RELACION_TRANSMISOR(_NID_RELACION_TRANSMISOR, this.V_RELACION_TRANSMISOR, lOpcionesRegistroExistente);
        }
        public blld_CAT_RELACION_TRANSMISOR(String V_RELACION_TRANSMISOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_RELACION_TRANSMISOR = dald_CAT_RELACION_TRANSMISOR.nNuevo_NID_RELACION_TRANSMISOR();
            this.V_RELACION_TRANSMISOR = V_RELACION_TRANSMISOR;
            datos_CAT_RELACION_TRANSMISOR = new dald_CAT_RELACION_TRANSMISOR(_NID_RELACION_TRANSMISOR, this.V_RELACION_TRANSMISOR, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
