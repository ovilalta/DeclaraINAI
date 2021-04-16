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
    internal partial class dald_CAT_CONFLICTO_RUBRO : dal_CAT_CONFLICTO_RUBRO
    {

     #region *** Atributos ***

        internal List<CAT_CONFLICTO_PREGUNTA> _CAT_CONFLICTO_PREGUNTAs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.CAT_CONFLICTO_PREGUNTA
                              where
                                   p.NID_RUBRO == NID_RUBRO
                              select p).ToList();
            }
        }

        internal List<CONFLICTO_RUBRO> _CONFLICTO_RUBROs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.CONFLICTO_RUBRO
                              where
                                   p.NID_RUBRO == NID_RUBRO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_CAT_CONFLICTO_RUBRO()
        : base() { }

        internal dald_CAT_CONFLICTO_RUBRO(CAT_CONFLICTO_RUBRO CAT_CONFLICTO_RUBRO)
        : base(CAT_CONFLICTO_RUBRO) { }

        internal dald_CAT_CONFLICTO_RUBRO(Int32 NID_RUBRO)
        : base(NID_RUBRO) { }

        public dald_CAT_CONFLICTO_RUBRO(Int32 NID_RUBRO, String V_RUBRO, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_RUBRO, V_RUBRO, C_INICIO, C_FIN, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
