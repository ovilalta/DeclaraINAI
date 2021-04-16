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
    internal partial class dald_CAT_CONFLICTO_PREGUNTA : dal_CAT_CONFLICTO_PREGUNTA
    {

     #region *** Atributos ***

        #region * CAT_CONFLICTO_RUBRO *

        dald_CAT_CONFLICTO_RUBRO _oCAT_CONFLICTO_RUBRO;
        dald_CAT_CONFLICTO_RUBRO oCAT_CONFLICTO_RUBRO
        {
            get
            {
                if(_oCAT_CONFLICTO_RUBRO == null) _oCAT_CONFLICTO_RUBRO= new dald_CAT_CONFLICTO_RUBRO(NID_RUBRO);
                return _oCAT_CONFLICTO_RUBRO;
            }
        }

        internal String V_RUBRO_CAT_CONFLICTO_PREGUNTA => oCAT_CONFLICTO_RUBRO.V_RUBRO;

        internal String C_INICIO_CAT_CONFLICTO_PREGUNTA => oCAT_CONFLICTO_RUBRO.C_INICIO;

        internal String C_FIN_CAT_CONFLICTO_PREGUNTA => oCAT_CONFLICTO_RUBRO.C_FIN;

        internal void Reload_CAT_CONFLICTO_RUBRO() => _oCAT_CONFLICTO_RUBRO = null;


        #endregion * CAT_CONFLICTO_RUBRO *


        internal List<CONFLICTO_RESPUESTA> _CONFLICTO_RESPUESTAs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.CONFLICTO_RESPUESTA
                              where
                                   p.NID_RUBRO == NID_RUBRO &&
                                   p.NID_PREGUNTA == NID_PREGUNTA
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_CAT_CONFLICTO_PREGUNTA()
        : base() { }

        internal dald_CAT_CONFLICTO_PREGUNTA(CAT_CONFLICTO_PREGUNTA CAT_CONFLICTO_PREGUNTA)
        : base(CAT_CONFLICTO_PREGUNTA) { }

        internal dald_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, Int32 NID_PREGUNTA)
        : base(NID_RUBRO, NID_PREGUNTA) { }

        public dald_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, Int32 NID_PREGUNTA, String V_RUBRO, String V_OPCIONES, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_RUBRO, NID_PREGUNTA, V_RUBRO, V_OPCIONES, C_INICIO, C_FIN, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
