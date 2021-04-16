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
    internal partial class dald_CAT_ESTADO_DECLARACION : dal_CAT_ESTADO_DECLARACION
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_ESTADO_DECLARACION()
        : base() { }

        internal dald_CAT_ESTADO_DECLARACION(CAT_ESTADO_DECLARACION CAT_ESTADO_DECLARACION)
        : base(CAT_ESTADO_DECLARACION) { }

        internal dald_CAT_ESTADO_DECLARACION(Int32 NID_ESTADO)
        : base(NID_ESTADO) { }

        public dald_CAT_ESTADO_DECLARACION(Int32 NID_ESTADO, String V_ESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_ESTADO, V_ESTADO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
