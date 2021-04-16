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
    internal partial class dald_CAT_SEGUNDO_NIVEL : dal_CAT_SEGUNDO_NIVEL
    {

     #region *** Atributos ***

        #region * CAT_PRIMER_NIVEL *

        dald_CAT_PRIMER_NIVEL _oCAT_PRIMER_NIVEL;
        dald_CAT_PRIMER_NIVEL oCAT_PRIMER_NIVEL
        {
            get
            {
                if(_oCAT_PRIMER_NIVEL == null) _oCAT_PRIMER_NIVEL= new dald_CAT_PRIMER_NIVEL(VID_PRIMER_NIVEL);
                return _oCAT_PRIMER_NIVEL;
            }
        }

        internal String V_PRIMER_NIVEL => oCAT_PRIMER_NIVEL.V_PRIMER_NIVEL;

        internal void Reload_CAT_PRIMER_NIVEL() => _oCAT_PRIMER_NIVEL = null;


        #endregion * CAT_PRIMER_NIVEL *


        internal List<DECLARACION_CARGO> _DECLARACION_CARGOs
        {
            get
            {
                MODELDeclara_V2.cnxDeclara dbInt = new  MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.DECLARACION_CARGO
                              where
                                   p.VID_PRIMER_NIVEL == VID_PRIMER_NIVEL &&
                                   p.VID_SEGUNDO_NIVEL == VID_SEGUNDO_NIVEL
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_CAT_SEGUNDO_NIVEL()
        : base() { }

        internal dald_CAT_SEGUNDO_NIVEL(CAT_SEGUNDO_NIVEL CAT_SEGUNDO_NIVEL)
        : base(CAT_SEGUNDO_NIVEL) { }

        internal dald_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL)
        : base(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL) { }

        public dald_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String V_SEGUNDO_NIVEL, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, V_SEGUNDO_NIVEL, C_INICIO, C_FIN, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
