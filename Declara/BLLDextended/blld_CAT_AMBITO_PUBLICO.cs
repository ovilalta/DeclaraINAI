using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_CAT_AMBITO_PUBLICO : bll_CAT_AMBITO_PUBLICO
    {

        #region *** Propiedades ***
//    new public Int32 NID_AMBITO_PUBLICO => datos_CAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO;
//    new public String V_AMBITO_PUBLICO
//        {
//            get => datos_CAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO;
//            set => datos_CAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO, String V_AMBITO_PUBLICO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO; 
            this.V_AMBITO_PUBLICO = V_AMBITO_PUBLICO;
            datos_CAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO(_NID_AMBITO_PUBLICO, this.V_AMBITO_PUBLICO, lOpcionesRegistroExistente);
        }
        public blld_CAT_AMBITO_PUBLICO(String V_AMBITO_PUBLICO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_AMBITO_PUBLICO = dald_CAT_AMBITO_PUBLICO.nNuevo_NID_AMBITO_PUBLICO();
            this.V_AMBITO_PUBLICO = V_AMBITO_PUBLICO;
            datos_CAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO(_NID_AMBITO_PUBLICO, this.V_AMBITO_PUBLICO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
