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
    internal partial class dald_CAT_TIPO_INMUEBLE : dal_CAT_TIPO_INMUEBLE
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_INMUEBLE()
        : base() { }

        internal dald_CAT_TIPO_INMUEBLE(CAT_TIPO_INMUEBLE CAT_TIPO_INMUEBLE)
        : base(CAT_TIPO_INMUEBLE) { }

        internal dald_CAT_TIPO_INMUEBLE(Int32 NID_TIPO)
        : base(NID_TIPO) { }

        public dald_CAT_TIPO_INMUEBLE(Int32 NID_TIPO, String V_TIPO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO, V_TIPO,L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
