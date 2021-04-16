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
    internal partial class dald_CAT_TIPO_VEHICULO : dal_CAT_TIPO_VEHICULO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPO_VEHICULO()
        : base() { }

        internal dald_CAT_TIPO_VEHICULO(CAT_TIPO_VEHICULO CAT_TIPO_VEHICULO)
        : base(CAT_TIPO_VEHICULO) { }

        internal dald_CAT_TIPO_VEHICULO(Int32 NID_TIPO_VEHICULO)
        : base(NID_TIPO_VEHICULO) { }

        public dald_CAT_TIPO_VEHICULO(Int32 NID_TIPO_VEHICULO, String V_TIPO_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO_VEHICULO, V_TIPO_VEHICULO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
