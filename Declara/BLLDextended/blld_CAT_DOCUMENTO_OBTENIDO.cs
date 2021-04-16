using System;
using System.Collections.Generic;
using MODELDeclara;
using Declara.Exceptions;
using Declara.DALD;
using Declara.BLL;

namespace Declara.BLLD
{
    public partial class blld_CAT_DOCUMENTO_OBTENIDO : bll_CAT_DOCUMENTO_OBTENIDO
    {

        #region *** Propiedades ***
//    new public Int32 NID_DOCUMENTO_OBTENIDO => datos_CAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDO;
//    new public String V_DOCUMENTO_OBTENIDO
//        {
//            get => datos_CAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO;
//            set => datos_CAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO, String V_DOCUMENTO_OBTENIDO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_DOCUMENTO_OBTENIDO = NID_DOCUMENTO_OBTENIDO; 
            this.V_DOCUMENTO_OBTENIDO = V_DOCUMENTO_OBTENIDO;
            datos_CAT_DOCUMENTO_OBTENIDO = new dald_CAT_DOCUMENTO_OBTENIDO(_NID_DOCUMENTO_OBTENIDO, this.V_DOCUMENTO_OBTENIDO, lOpcionesRegistroExistente);
        }
        public blld_CAT_DOCUMENTO_OBTENIDO(String V_DOCUMENTO_OBTENIDO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            Int32 _NID_DOCUMENTO_OBTENIDO = dald_CAT_DOCUMENTO_OBTENIDO.nNuevo_NID_DOCUMENTO_OBTENIDO();
            this.V_DOCUMENTO_OBTENIDO = V_DOCUMENTO_OBTENIDO;
            datos_CAT_DOCUMENTO_OBTENIDO = new dald_CAT_DOCUMENTO_OBTENIDO(_NID_DOCUMENTO_OBTENIDO, this.V_DOCUMENTO_OBTENIDO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
