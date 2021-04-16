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
    internal partial class dald_CAT_TIPO_ADEUDO : dal_CAT_TIPO_ADEUDO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_ADEUDO()
        : base() { }

        internal dald_CAT_TIPO_ADEUDO(CAT_TIPO_ADEUDO CAT_TIPO_ADEUDO)
        : base(CAT_TIPO_ADEUDO) { }

        internal dald_CAT_TIPO_ADEUDO(Int32 NID_TIPO_ADEUDO)
        : base(NID_TIPO_ADEUDO) { }

        public dald_CAT_TIPO_ADEUDO(Int32 NID_TIPO_ADEUDO, String V_TIPO_ADEUDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO_ADEUDO, V_TIPO_ADEUDO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
