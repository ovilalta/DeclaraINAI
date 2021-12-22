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
    internal partial class dald_ALTA_MUEBLE : dal_ALTA_MUEBLE
    {

        #region *** Atributos ***

        #region * CAT_TIPO_MUEBLE *

        dald_CAT_TIPO_MUEBLE _oCAT_TIPO_MUEBLE;
        dald_CAT_TIPO_MUEBLE oCAT_TIPO_MUEBLE
        {
            get
            {
                if (_oCAT_TIPO_MUEBLE == null) _oCAT_TIPO_MUEBLE = new dald_CAT_TIPO_MUEBLE(NID_TIPO);
                return _oCAT_TIPO_MUEBLE;
            }
        }

        internal String V_TIPO => oCAT_TIPO_MUEBLE.V_TIPO;

        internal Boolean L_ACTIVO => oCAT_TIPO_MUEBLE.L_ACTIVO;

        internal void Reload_CAT_TIPO_MUEBLE() => _oCAT_TIPO_MUEBLE = null;


        #endregion * CAT_TIPO_MUEBLE *


        internal List<ALTA_MUEBLE_TITULAR> _ALTA_MUEBLE_TITULARs
        {
            get
            {
                MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.ALTA_MUEBLE_TITULAR
                        where
                             p.VID_NOMBRE == VID_NOMBRE &&
                             p.VID_FECHA == VID_FECHA &&
                             p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                             p.NID_DECLARACION == NID_DECLARACION &&
                             p.NID_MUEBLE == NID_MUEBLE
                        select p).ToList();
            }
        }


        #endregion


        #region *** Constructores ***

        internal dald_ALTA_MUEBLE()
        : base() { }

        internal dald_ALTA_MUEBLE(ALTA_MUEBLE ALTA_MUEBLE)
        : base(ALTA_MUEBLE) { }

        internal dald_ALTA_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE) { }

        public dald_ALTA_MUEBLE(String VID_NOMBRE
                                , String VID_FECHA
                                , String VID_HOMOCLAVE
                                , Int32 NID_DECLARACION
                                , Int32 NID_MUEBLE
                                , Int32 NID_TIPO
                                , String E_ESPECIFICACION
                                , Decimal M_VALOR
                                , Int32 NID_PATRIMONIO
                                , Boolean L_CREDITO
                                , DateTime F_ADQUISICION
                                , String CID_TIPO_PERSONA_TRANSMISOR
                                , String E_NOMBRE_TRANSMISOR
                                , String E_RFC_TRANSMISOR
                                , Int32 NID_RELACION_TRANSMISOR
                                , String V_TIPO_MONEDA
                                , Int32 NID_FORMA_ADQUISICION
                                , Int32 NID_FORMA_PAGO
                                , String E_OBSERVACIONES
                                , String D_ESPECIFICACION
                                , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
                                )
        : base(VID_NOMBRE
                , VID_FECHA
                , VID_HOMOCLAVE
                , NID_DECLARACION
                , NID_MUEBLE
                , NID_TIPO
                , E_ESPECIFICACION
                , M_VALOR
                , NID_PATRIMONIO
                , L_CREDITO
                , F_ADQUISICION
                , CID_TIPO_PERSONA_TRANSMISOR
                , E_NOMBRE_TRANSMISOR
                , E_RFC_TRANSMISOR
                , NID_RELACION_TRANSMISOR
                , V_TIPO_MONEDA
                , NID_FORMA_ADQUISICION
                , NID_FORMA_PAGO
                , E_OBSERVACIONES
                ,D_ESPECIFICACION
                , lOpcionesRegistroExistente
              )
        { }



        #endregion


        #region *** Metodos ***


        #endregion

    }
}
