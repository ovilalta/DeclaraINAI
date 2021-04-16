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
    internal partial class dald_ALTA_INVERSION : dal_ALTA_INVERSION
    {

        #region *** Atributos ***

        #region * CAT_ENTIDAD_FEDERATIVA *

        dald_CAT_ENTIDAD_FEDERATIVA _oCAT_ENTIDAD_FEDERATIVA;
        dald_CAT_ENTIDAD_FEDERATIVA oCAT_ENTIDAD_FEDERATIVA
        {
            get
            {
                if (_oCAT_ENTIDAD_FEDERATIVA == null) _oCAT_ENTIDAD_FEDERATIVA = new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
                return _oCAT_ENTIDAD_FEDERATIVA;
            }
        }

        // internal String V_ENTIDAD_FEDERATIVA => oCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA;

        internal void Reload_CAT_ENTIDAD_FEDERATIVA() => _oCAT_ENTIDAD_FEDERATIVA = null;


        #endregion * CAT_ENTIDAD_FEDERATIVA *


        #region * CAT_SUBTIPO_INVERSION *

        dald_CAT_SUBTIPO_INVERSION _oCAT_SUBTIPO_INVERSION;
        dald_CAT_SUBTIPO_INVERSION oCAT_SUBTIPO_INVERSION
        {
            get
            {
                if (_oCAT_SUBTIPO_INVERSION == null) _oCAT_SUBTIPO_INVERSION = new dald_CAT_SUBTIPO_INVERSION(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION);
                return _oCAT_SUBTIPO_INVERSION;
            }
        }

        internal String V_SUBTIPO_INVERSION => oCAT_SUBTIPO_INVERSION.V_SUBTIPO_INVERSION;

        internal void Reload_CAT_SUBTIPO_INVERSION() => _oCAT_SUBTIPO_INVERSION = null;


        #endregion * CAT_SUBTIPO_INVERSION *





        #region * CAT_TIPO_INVERSION *

        dald_CAT_TIPO_INVERSION _oCAT_TIPO_INVERSION;
        dald_CAT_TIPO_INVERSION oCAT_TIPO_INVERSION
        {
            get
            {
                if (_oCAT_TIPO_INVERSION == null) _oCAT_TIPO_INVERSION = new dald_CAT_TIPO_INVERSION(NID_TIPO_INVERSION);
                return _oCAT_TIPO_INVERSION;
            }
        }

        internal String V_TIPO_INVERSION => oCAT_TIPO_INVERSION.V_TIPO_INVERSION;

        internal void Reload_CAT_TIPO_INVERSION() => _oCAT_TIPO_INVERSION = null;


        #endregion * CAT_TIPO_INVERSION *





        #region * CAT_INST_FINANCIERA *

        dald_CAT_INST_FINANCIERA _oCAT_INST_FINANCIERA;
        dald_CAT_INST_FINANCIERA oCAT_INST_FINANCIERA
        {
            get
            {
                if (_oCAT_INST_FINANCIERA == null) _oCAT_INST_FINANCIERA = new dald_CAT_INST_FINANCIERA(NID_INSTITUCION);
                return _oCAT_INST_FINANCIERA;
            }
        }

        internal String V_INSTITUCION => oCAT_INST_FINANCIERA.V_INSTITUCION;

        internal void Reload_CAT_INST_FINANCIERA() => _oCAT_INST_FINANCIERA = null;


        #endregion * CAT_INST_FINANCIERA *


        internal List<ALTA_INVERSION_TITULAR> _ALTA_INVERSION_TITULARs
        {
            get
            {
                MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.ALTA_INVERSION_TITULAR
                        where
                             p.VID_NOMBRE == VID_NOMBRE &&
                             p.VID_FECHA == VID_FECHA &&
                             p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                             p.NID_DECLARACION == NID_DECLARACION &&
                             p.NID_INVERSION == NID_INVERSION
                        select p).ToList();
            }
        }


        #endregion


        #region *** Constructores ***

        internal dald_ALTA_INVERSION()
        : base() { }

        internal dald_ALTA_INVERSION(ALTA_INVERSION ALTA_INVERSION)
        : base(ALTA_INVERSION) { }

        internal dald_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION) { }

        public dald_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, DateTime F_APERTURA, Int32 NID_PATRIMONIO, String V_RFC_INVERSION, String V_TIPO_MONEDA,  String E_OBSERVACIONES, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, F_APERTURA, NID_PATRIMONIO, V_RFC_INVERSION, V_TIPO_MONEDA, E_OBSERVACIONES, lOpcionesRegistroExistente) { }



        #endregion


        #region *** Metodos ***


        #endregion

    }
}
