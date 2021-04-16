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
    internal partial class dald_CONFLICTO_RUBRO : dal_CONFLICTO_RUBRO
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

        internal String V_RUBRO => oCAT_CONFLICTO_RUBRO.V_RUBRO;

        internal String C_INICIO => oCAT_CONFLICTO_RUBRO.C_INICIO;

        internal String C_FIN => oCAT_CONFLICTO_RUBRO.C_FIN;

        internal void Reload_CAT_CONFLICTO_RUBRO() => _oCAT_CONFLICTO_RUBRO = null;


        #endregion * CAT_CONFLICTO_RUBRO *


        internal List<CONFLICTO_ENCABEZADO> _CONFLICTO_ENCABEZADOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.CONFLICTO_ENCABEZADO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_CONFLICTO == NID_CONFLICTO &&
                                   p.NID_RUBRO == NID_RUBRO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_CONFLICTO_RUBRO()
        : base() { }

        internal dald_CONFLICTO_RUBRO(CONFLICTO_RUBRO CONFLICTO_RUBRO)
        : base(CONFLICTO_RUBRO) { }

        internal dald_CONFLICTO_RUBRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO) { }


        public dald_CONFLICTO_RUBRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, System.Nullable<Boolean> L_RESPUESTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, L_RESPUESTA, lOpcionesRegistroExistente) { }


        #endregion


        #region *** Metodos ***


        #endregion

    }
}
