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
    internal partial class dald_MODIFICACION_INMUEBLE : dal_MODIFICACION_INMUEBLE
    {

     #region *** Atributos ***

        #region * CAT_TIPO_INMUEBLE *

        dald_CAT_TIPO_INMUEBLE _oCAT_TIPO_INMUEBLE;
        dald_CAT_TIPO_INMUEBLE oCAT_TIPO_INMUEBLE
        {
            get
            {
                if(_oCAT_TIPO_INMUEBLE == null) _oCAT_TIPO_INMUEBLE= new dald_CAT_TIPO_INMUEBLE(NID_TIPO);
                return _oCAT_TIPO_INMUEBLE;
            }
        }

        internal String V_TIPO => oCAT_TIPO_INMUEBLE.V_TIPO;

        internal Boolean L_ACTIVO => oCAT_TIPO_INMUEBLE.L_ACTIVO;

        internal void Reload_CAT_TIPO_INMUEBLE() => _oCAT_TIPO_INMUEBLE = null;


        #endregion * CAT_TIPO_INMUEBLE *


        #region * CAT_USO_INMUEBLE *

        dald_CAT_USO_INMUEBLE _oCAT_USO_INMUEBLE;
        dald_CAT_USO_INMUEBLE oCAT_USO_INMUEBLE
        {
            get
            {
                if(_oCAT_USO_INMUEBLE == null) _oCAT_USO_INMUEBLE= new dald_CAT_USO_INMUEBLE(NID_USO);
                return _oCAT_USO_INMUEBLE;
            }
        }

        internal String V_USO => oCAT_USO_INMUEBLE.V_USO;

        //internal Boolean L_ACTIVO => oCAT_USO_INMUEBLE.L_ACTIVO;

        internal void Reload_CAT_USO_INMUEBLE() => _oCAT_USO_INMUEBLE = null;


        #endregion * CAT_USO_INMUEBLE *


        internal List<MODIFICACION_INMUEBLE_ADEUDO> _MODIFICACION_INMUEBLE_ADEUDOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_INMUEBLE_ADEUDO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.NID_PATRIMONIO == NID_PATRIMONIO
                              select p).ToList();
            }
        }

        internal List<MODIFICACION_INMUEBLE_TITULA> _MODIFICACION_INMUEBLE_TITULAs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_INMUEBLE_TITULA
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

        internal dald_MODIFICACION_INMUEBLE()
        : base() { }

        internal dald_MODIFICACION_INMUEBLE(MODIFICACION_INMUEBLE MODIFICACION_INMUEBLE)
        : base(MODIFICACION_INMUEBLE) { }

        internal dald_MODIFICACION_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO) { }

        public dald_MODIFICACION_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE, System.Nullable<Boolean> L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, L_MODIFICADO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
