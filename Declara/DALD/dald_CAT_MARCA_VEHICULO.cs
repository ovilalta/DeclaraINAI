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
    internal partial class dald_CAT_MARCA_VEHICULO : dal_CAT_MARCA_VEHICULO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_MARCA_VEHICULO()
        : base() { }

        internal dald_CAT_MARCA_VEHICULO(CAT_MARCA_VEHICULO CAT_MARCA_VEHICULO)
        : base(CAT_MARCA_VEHICULO) { }

        internal dald_CAT_MARCA_VEHICULO(Int32 NID_MARCA)
        : base(NID_MARCA) { }

        public dald_CAT_MARCA_VEHICULO(Int32 NID_MARCA, String V_MARCA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_MARCA, V_MARCA, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
