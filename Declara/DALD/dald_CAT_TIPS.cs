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
    internal partial class dald_CAT_TIPS : dal_CAT_TIPS
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_CAT_TIPS()
        : base() { }

        internal dald_CAT_TIPS(CAT_TIPS CAT_TIPS)
        : base(CAT_TIPS) { }

        internal dald_CAT_TIPS(Int32 NID_TIP)
        : base(NID_TIP) { }

        public dald_CAT_TIPS(Int32 NID_TIP, String V_TIP, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIP, V_TIP, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
