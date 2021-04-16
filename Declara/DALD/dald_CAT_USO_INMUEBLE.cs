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
    internal partial class dald_CAT_USO_INMUEBLE : dal_CAT_USO_INMUEBLE
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_USO_INMUEBLE()
        : base() { }

        internal dald_CAT_USO_INMUEBLE(CAT_USO_INMUEBLE CAT_USO_INMUEBLE)
        : base(CAT_USO_INMUEBLE) { }

        internal dald_CAT_USO_INMUEBLE(Int32 NID_USO)
        : base(NID_USO) { }

        public dald_CAT_USO_INMUEBLE(Int32 NID_USO, String V_USO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_USO, V_USO,L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
