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
    internal partial class dald_CAT_TIPO_MUEBLE : dal_CAT_TIPO_MUEBLE
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_MUEBLE()
        : base() { }

        internal dald_CAT_TIPO_MUEBLE(CAT_TIPO_MUEBLE CAT_TIPO_MUEBLE)
        : base(CAT_TIPO_MUEBLE) { }

        internal dald_CAT_TIPO_MUEBLE(Int32 NID_TIPO)
        : base(NID_TIPO) { }

        public dald_CAT_TIPO_MUEBLE(Int32 NID_TIPO, String V_TIPO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO, V_TIPO,L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
