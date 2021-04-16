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
    internal partial class dald_ALTA_INMUEBLE : dal_ALTA_INMUEBLE
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


        internal void Reload_CAT_USO_INMUEBLE() => _oCAT_USO_INMUEBLE = null;


        #endregion * CAT_USO_INMUEBLE *


        internal List<ALTA_INMUEBLE_ADEUDO> _ALTA_INMUEBLE_ADEUDOs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.ALTA_INMUEBLE_ADEUDO
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.NID_INMUEBLE == NID_INMUEBLE
                              select p).ToList();
            }
        }

        internal List<ALTA_INMUEBLE_TITULAR> _ALTA_INMUEBLE_TITULARs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.ALTA_INMUEBLE_TITULAR
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.NID_INMUEBLE == NID_INMUEBLE
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_ALTA_INMUEBLE()
        : base() { }

        internal dald_ALTA_INMUEBLE(ALTA_INMUEBLE ALTA_INMUEBLE)
        : base(ALTA_INMUEBLE) { }

        internal dald_ALTA_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE) { }

        public dald_ALTA_INMUEBLE(
                                    String VID_NOMBRE
                                    , String VID_FECHA
                                    , String VID_HOMOCLAVE
                                    , Int32 NID_DECLARACION
                                    , Int32 NID_INMUEBLE
                                    , Int32 NID_TIPO
                                    , DateTime F_ADQUISICION
                                    , Int32 NID_USO
                                    , String E_UBICACION
                                    , Decimal N_TERRENO
                                    , Decimal N_CONSTRUCCION
                                    , Decimal M_VALOR_INMUEBLE
                                    , Int32 NID_PATRIMONIO
                                    , Decimal N_PORCENTAJE_DECLARANTE
                                    , String CID_TIPO_PERSONA_TRANSMISOR
                                    , String E_NOMBRE_TRANSMISOR
                                    , String E_RFC_TRANSMISOR
                                    , Int32 NID_RELACION_TRANSMISOR
                                    , String V_TIPO_MONEDA
                                    , String E_REGISTRO_PUBLICO_PROPIEDAD
                                    , Int32 NID_VALOR_ADQUISICION
                                    , Int32 NID_FORMA_ADQUISICION
                                    , Int32 NID_FORMA_PAGO
                                    , String E_OBSERVACIONES
                                    , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
                                 )
        : base(
                VID_NOMBRE
              , VID_FECHA
              , VID_HOMOCLAVE
              , NID_DECLARACION
              , NID_INMUEBLE
              , NID_TIPO
              , F_ADQUISICION
              , NID_USO
              , E_UBICACION
              , N_TERRENO
              , N_CONSTRUCCION
              , M_VALOR_INMUEBLE
              , NID_PATRIMONIO
              , N_PORCENTAJE_DECLARANTE
              , CID_TIPO_PERSONA_TRANSMISOR
              , E_NOMBRE_TRANSMISOR
              , E_RFC_TRANSMISOR
              , NID_RELACION_TRANSMISOR
              , V_TIPO_MONEDA
              , E_REGISTRO_PUBLICO_PROPIEDAD
              , NID_VALOR_ADQUISICION
              , NID_FORMA_ADQUISICION
              , NID_FORMA_PAGO
              , E_OBSERVACIONES
              , lOpcionesRegistroExistente
              )  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
