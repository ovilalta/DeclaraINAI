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
    internal partial class dald_CAT_TIPO_DEPENDIENTES : dal_CAT_TIPO_DEPENDIENTES
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_DEPENDIENTES()
        : base() { }

        internal dald_CAT_TIPO_DEPENDIENTES(CAT_TIPO_DEPENDIENTES CAT_TIPO_DEPENDIENTES)
        : base(CAT_TIPO_DEPENDIENTES) { }

        internal dald_CAT_TIPO_DEPENDIENTES(Int32 NID_TIPO_DEPENDIENTE)
        : base(NID_TIPO_DEPENDIENTE) { }

        public dald_CAT_TIPO_DEPENDIENTES(Int32 NID_TIPO_DEPENDIENTE, String V_TIPO_DEPENDIENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO_DEPENDIENTE, V_TIPO_DEPENDIENTE, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
