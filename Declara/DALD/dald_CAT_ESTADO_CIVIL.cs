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
    internal partial class dald_CAT_ESTADO_CIVIL : dal_CAT_ESTADO_CIVIL
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_ESTADO_CIVIL()
        : base() { }

        internal dald_CAT_ESTADO_CIVIL(CAT_ESTADO_CIVIL CAT_ESTADO_CIVIL)
        : base(CAT_ESTADO_CIVIL) { }

        internal dald_CAT_ESTADO_CIVIL(Int32 NID_ESTADO_CIVIL)
        : base(NID_ESTADO_CIVIL) { }

        public dald_CAT_ESTADO_CIVIL(Int32 NID_ESTADO_CIVIL, String V_ESTADO_CIVIL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_ESTADO_CIVIL, V_ESTADO_CIVIL, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
