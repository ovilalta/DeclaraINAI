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
    internal partial class dald_CAT_TIPO_DECLARACION : dal_CAT_TIPO_DECLARACION
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_DECLARACION()
        : base() { }

        internal dald_CAT_TIPO_DECLARACION(CAT_TIPO_DECLARACION CAT_TIPO_DECLARACION)
        : base(CAT_TIPO_DECLARACION) { }

        internal dald_CAT_TIPO_DECLARACION(Int32 NID_TIPO_DECLARACION)
        : base(NID_TIPO_DECLARACION) { }

        public dald_CAT_TIPO_DECLARACION(Int32 NID_TIPO_DECLARACION, String V_TIPO_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO_DECLARACION, V_TIPO_DECLARACION, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
