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
    internal partial class dald_CAT_ESTADO_CONFLICTO : dal_CAT_ESTADO_CONFLICTO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_ESTADO_CONFLICTO()
        : base() { }

        internal dald_CAT_ESTADO_CONFLICTO(CAT_ESTADO_CONFLICTO CAT_ESTADO_CONFLICTO)
        : base(CAT_ESTADO_CONFLICTO) { }

        internal dald_CAT_ESTADO_CONFLICTO(Int32 NID_ESTADO_CONFLICTO)
        : base(NID_ESTADO_CONFLICTO) { }

        public dald_CAT_ESTADO_CONFLICTO(Int32 NID_ESTADO_CONFLICTO, String V_ESTADO_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_ESTADO_CONFLICTO, V_ESTADO_CONFLICTO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
