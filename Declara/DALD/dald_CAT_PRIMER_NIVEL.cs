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
    internal partial class dald_CAT_PRIMER_NIVEL : dal_CAT_PRIMER_NIVEL
    {

     #region *** Atributos ***

        internal List<CAT_SEGUNDO_NIVEL> _CAT_SEGUNDO_NIVELs
        {
            get
            {
                MODELDeclara_V2.cnxDeclara dbInt = new  MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.CAT_SEGUNDO_NIVEL
                              where
                                   p.VID_PRIMER_NIVEL == VID_PRIMER_NIVEL
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_CAT_PRIMER_NIVEL()
        : base() { }

        internal dald_CAT_PRIMER_NIVEL(CAT_PRIMER_NIVEL CAT_PRIMER_NIVEL)
        : base(CAT_PRIMER_NIVEL) { }

        internal dald_CAT_PRIMER_NIVEL(String VID_PRIMER_NIVEL)
        : base(VID_PRIMER_NIVEL) { }

        public dald_CAT_PRIMER_NIVEL(String VID_PRIMER_NIVEL, String V_PRIMER_NIVEL, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_PRIMER_NIVEL, V_PRIMER_NIVEL, C_INICIO, C_FIN, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
