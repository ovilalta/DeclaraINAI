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
    internal partial class dald_CONFLICTO : dal_CONFLICTO
    {

     #region *** Atributos ***

        #region * CAT_ESTADO_CONFLICTO *

        dald_CAT_ESTADO_CONFLICTO _oCAT_ESTADO_CONFLICTO;
        dald_CAT_ESTADO_CONFLICTO oCAT_ESTADO_CONFLICTO
        {
            get
            {
                if(_oCAT_ESTADO_CONFLICTO == null) _oCAT_ESTADO_CONFLICTO= new dald_CAT_ESTADO_CONFLICTO(NID_ESTADO_CONFLICTO);
                return _oCAT_ESTADO_CONFLICTO;
            }
        }

        internal String V_ESTADO_CONFLICTO => oCAT_ESTADO_CONFLICTO.V_ESTADO_CONFLICTO;

        internal void Reload_CAT_ESTADO_CONFLICTO() => _oCAT_ESTADO_CONFLICTO = null;


        #endregion * CAT_ESTADO_CONFLICTO *


        internal List<CONFLICTO_RUBRO> _CONFLICTO_RUBROs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.CONFLICTO_RUBRO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_CONFLICTO == NID_CONFLICTO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_CONFLICTO()
        : base() { }

        internal dald_CONFLICTO(CONFLICTO CONFLICTO)
        : base(CONFLICTO) { }

        internal dald_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO) { }

        public dald_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, System.Nullable<Int32> NID_DEC_ASOS, Int32 NID_ESTADO_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_DEC_ASOS, NID_ESTADO_CONFLICTO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
