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
    internal partial class dald_CAT_TIPO_BAJA : dal_CAT_TIPO_BAJA
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_BAJA()
        : base() { }

        internal dald_CAT_TIPO_BAJA(CAT_TIPO_BAJA CAT_TIPO_BAJA)
        : base(CAT_TIPO_BAJA) { }

        internal dald_CAT_TIPO_BAJA(Int32 NID_TIPO_BAJA)
        : base(NID_TIPO_BAJA) { }

        public dald_CAT_TIPO_BAJA(Int32 NID_TIPO_BAJA, String V_TIPO_BAJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO_BAJA, V_TIPO_BAJA, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
