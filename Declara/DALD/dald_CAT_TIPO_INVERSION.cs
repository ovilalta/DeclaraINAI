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
    internal partial class dald_CAT_TIPO_INVERSION : dal_CAT_TIPO_INVERSION
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_INVERSION()
        : base() { }

        internal dald_CAT_TIPO_INVERSION(CAT_TIPO_INVERSION CAT_TIPO_INVERSION)
        : base(CAT_TIPO_INVERSION) { }

        internal dald_CAT_TIPO_INVERSION(Int32 NID_TIPO_INVERSION)
        : base(NID_TIPO_INVERSION) { }

        public dald_CAT_TIPO_INVERSION(Int32 NID_TIPO_INVERSION, String V_TIPO_INVERSION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO_INVERSION, V_TIPO_INVERSION,L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
