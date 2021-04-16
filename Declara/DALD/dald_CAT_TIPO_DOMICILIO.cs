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
    internal partial class dald_CAT_TIPO_DOMICILIO : dal_CAT_TIPO_DOMICILIO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_DOMICILIO()
        : base() { }

        internal dald_CAT_TIPO_DOMICILIO(CAT_TIPO_DOMICILIO CAT_TIPO_DOMICILIO)
        : base(CAT_TIPO_DOMICILIO) { }

        internal dald_CAT_TIPO_DOMICILIO(Int32 NID_TIPO_DOMICILIO)
        : base(NID_TIPO_DOMICILIO) { }

        public dald_CAT_TIPO_DOMICILIO(Int32 NID_TIPO_DOMICILIO, String V_TIPO_DOMICILIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO_DOMICILIO, V_TIPO_DOMICILIO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
