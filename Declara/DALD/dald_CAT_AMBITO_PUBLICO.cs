using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_AMBITO_PUBLICO : dal_CAT_AMBITO_PUBLICO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_CAT_AMBITO_PUBLICO() : base() { }
        internal dald_CAT_AMBITO_PUBLICO(CAT_AMBITO_PUBLICO CAT_AMBITO_PUBLICO) : base(CAT_AMBITO_PUBLICO) { }
        internal dald_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO)
        : base(NID_AMBITO_PUBLICO) { }
        internal dald_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO, String V_AMBITO_PUBLICO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_AMBITO_PUBLICO, V_AMBITO_PUBLICO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
