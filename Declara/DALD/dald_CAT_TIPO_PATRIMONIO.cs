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
    internal partial class dald_CAT_TIPO_PATRIMONIO : dal_CAT_TIPO_PATRIMONIO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_PATRIMONIO()
        : base() { }

        internal dald_CAT_TIPO_PATRIMONIO(CAT_TIPO_PATRIMONIO CAT_TIPO_PATRIMONIO)
        : base(CAT_TIPO_PATRIMONIO) { }

        internal dald_CAT_TIPO_PATRIMONIO(Int32 NID_TIPO)
        : base(NID_TIPO) { }

        public dald_CAT_TIPO_PATRIMONIO(Int32 NID_TIPO, String V_TIPO, Int32 C_NATURALEZA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO, V_TIPO, C_NATURALEZA, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
