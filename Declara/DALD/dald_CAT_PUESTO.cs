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
    internal partial class dald_CAT_PUESTO : dal_CAT_PUESTO
    {

     #region *** Atributos ***

        internal List<DECLARACION_CARGO> _DECLARACION_CARGOs
        {
            get
            {
                MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.DECLARACION_CARGO
                              where
                                   p.NID_PUESTO == NID_PUESTO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_CAT_PUESTO()
        : base() { }

        internal dald_CAT_PUESTO(CAT_PUESTO CAT_PUESTO)
        : base(CAT_PUESTO) { }

        internal dald_CAT_PUESTO(Int32 NID_PUESTO)
        : base(NID_PUESTO) { }

        public dald_CAT_PUESTO(Int32 NID_PUESTO, String VID_PUESTO, String VID_NIVEL, String V_PUESTO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_PUESTO, VID_PUESTO, VID_NIVEL, V_PUESTO, L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
