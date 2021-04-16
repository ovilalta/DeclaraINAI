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
    internal partial class dald_PATRIMONIO : dal_PATRIMONIO
    {

     #region *** Atributos ***

        #region * CAT_TIPO_PATRIMONIO *

        dald_CAT_TIPO_PATRIMONIO _oCAT_TIPO_PATRIMONIO;
        dald_CAT_TIPO_PATRIMONIO oCAT_TIPO_PATRIMONIO
        {
            get
            {
                if(_oCAT_TIPO_PATRIMONIO == null) _oCAT_TIPO_PATRIMONIO= new dald_CAT_TIPO_PATRIMONIO(NID_TIPO);
                return _oCAT_TIPO_PATRIMONIO;
            }
        }

        internal String V_TIPO => oCAT_TIPO_PATRIMONIO.V_TIPO;

        internal Int32 C_NATURALEZA => oCAT_TIPO_PATRIMONIO.C_NATURALEZA;

        internal void Reload_CAT_TIPO_PATRIMONIO() => _oCAT_TIPO_PATRIMONIO = null;


        #endregion * CAT_TIPO_PATRIMONIO *


        internal List<H_PATRIMONIO> _H_PATRIMONIOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.H_PATRIMONIO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_PATRIMONIO == NID_PATRIMONIO
                              select p).ToList();
            }
        }

        internal List<PATRIMONIO_TITULAR> _PATRIMONIO_TITULARs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.PATRIMONIO_TITULAR
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_PATRIMONIO == NID_PATRIMONIO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_PATRIMONIO()
        : base() { }

        internal dald_PATRIMONIO(PATRIMONIO PATRIMONIO)
        : base(PATRIMONIO) { }

        internal dald_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO) { }

        public dald_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, M_VALOR, NID_DEC_INCOR, F_INCORPORACION, NID_DEC_ULT_MOD, F_MODIFICACION, L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
