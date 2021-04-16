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
    internal partial class dald_MODIFICACION_MUEBLE : dal_MODIFICACION_MUEBLE
    {

     #region *** Atributos ***

        #region * CAT_TIPO_MUEBLE *

        dald_CAT_TIPO_MUEBLE _oCAT_TIPO_MUEBLE;
        dald_CAT_TIPO_MUEBLE oCAT_TIPO_MUEBLE
        {
            get
            {
                if(_oCAT_TIPO_MUEBLE == null) _oCAT_TIPO_MUEBLE= new dald_CAT_TIPO_MUEBLE(NID_TIPO);
                return _oCAT_TIPO_MUEBLE;
            }
        }

        internal String V_TIPO => oCAT_TIPO_MUEBLE.V_TIPO;

        internal Boolean L_ACTIVO => oCAT_TIPO_MUEBLE.L_ACTIVO;

        internal void Reload_CAT_TIPO_MUEBLE() => _oCAT_TIPO_MUEBLE = null;


        #endregion * CAT_TIPO_MUEBLE *


        internal List<MODIFICACION_MUEBLE_TITULAR> _MODIFICACION_MUEBLE_TITULARs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_MUEBLE_TITULAR
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.NID_PATRIMONIO == NID_PATRIMONIO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_MUEBLE()
        : base() { }

        internal dald_MODIFICACION_MUEBLE(MODIFICACION_MUEBLE MODIFICACION_MUEBLE)
        : base(MODIFICACION_MUEBLE) { }

        internal dald_MODIFICACION_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO) { }

        public dald_MODIFICACION_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO, String E_ESPECIFICACION, Decimal M_VALOR, Boolean L_MODIFICADO, DateTime F_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO, E_ESPECIFICACION, M_VALOR, L_MODIFICADO, F_ADQUISICION, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
