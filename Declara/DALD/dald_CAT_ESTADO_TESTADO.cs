using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2;
using Declara_V2.DAL;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_ESTADO_TESTADO : dal_CAT_ESTADO_TESTADO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_ESTADO_TESTADO()
        : base() { }

        internal dald_CAT_ESTADO_TESTADO(CAT_ESTADO_TESTADO CAT_ESTADO_TESTADO)
        : base(CAT_ESTADO_TESTADO) { }

        internal dald_CAT_ESTADO_TESTADO(Int32 NID_ESTADO_TESTADO)
        : base(NID_ESTADO_TESTADO) { }

        public dald_CAT_ESTADO_TESTADO(Int32 NID_ESTADO_TESTADO, String V_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_ESTADO_TESTADO, V_ESTADO_TESTADO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
