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
    internal partial class dald_ALTA_ADEUDO : dal_ALTA_ADEUDO
    {

     #region *** Atributos ***

        #region * CAT_ENTIDAD_FEDERATIVA *

        dald_CAT_ENTIDAD_FEDERATIVA _oCAT_ENTIDAD_FEDERATIVA;
        dald_CAT_ENTIDAD_FEDERATIVA oCAT_ENTIDAD_FEDERATIVA
        {
            get
            {
                if(_oCAT_ENTIDAD_FEDERATIVA == null) _oCAT_ENTIDAD_FEDERATIVA= new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
                return _oCAT_ENTIDAD_FEDERATIVA;
            }
        }

        //internal String V_ENTIDAD_FEDERATIVA => oCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA;

        internal void Reload_CAT_ENTIDAD_FEDERATIVA() => _oCAT_ENTIDAD_FEDERATIVA = null;


        #endregion * CAT_ENTIDAD_FEDERATIVA *


        #region * CAT_TIPO_ADEUDO *

        dald_CAT_TIPO_ADEUDO _oCAT_TIPO_ADEUDO;
        dald_CAT_TIPO_ADEUDO oCAT_TIPO_ADEUDO
        {
            get
            {
                if(_oCAT_TIPO_ADEUDO == null) _oCAT_TIPO_ADEUDO= new dald_CAT_TIPO_ADEUDO(NID_TIPO_ADEUDO);
                return _oCAT_TIPO_ADEUDO;
            }
        }

        internal String V_TIPO_ADEUDO => oCAT_TIPO_ADEUDO.V_TIPO_ADEUDO;

        internal void Reload_CAT_TIPO_ADEUDO() => _oCAT_TIPO_ADEUDO = null;


        #endregion * CAT_TIPO_ADEUDO *


        #region * CAT_INST_FINANCIERA *

        dald_CAT_INST_FINANCIERA _oCAT_INST_FINANCIERA;
        dald_CAT_INST_FINANCIERA oCAT_INST_FINANCIERA
        {
            get
            {
                if(_oCAT_INST_FINANCIERA == null) _oCAT_INST_FINANCIERA= new dald_CAT_INST_FINANCIERA(NID_INSTITUCION);
                return _oCAT_INST_FINANCIERA;
            }
        }

        internal String V_INSTITUCION => oCAT_INST_FINANCIERA.V_INSTITUCION;

        internal void Reload_CAT_INST_FINANCIERA() => _oCAT_INST_FINANCIERA = null;


        #endregion * CAT_INST_FINANCIERA *

        internal List<ALTA_ADEUDO_TITULAR> _ALTA_ADEUDO_TITULARs
        {
            get
            {
                MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.ALTA_ADEUDO_TITULAR
                        where
                             p.VID_NOMBRE == VID_NOMBRE &&
                             p.VID_FECHA == VID_FECHA &&
                             p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                             p.NID_DECLARACION == NID_DECLARACION &&
                             p.NID_ADEUDO == NID_ADEUDO
                        select p).ToList();
            }
        }


        #endregion


        #region *** Constructores ***

        internal dald_ALTA_ADEUDO()
        : base() { }

        internal dald_ALTA_ADEUDO(ALTA_ADEUDO ALTA_ADEUDO)
        : base(ALTA_ADEUDO) { }

        internal dald_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO) { }

        public dald_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO,DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, String V_TIPO_MONEDA, String E_RFC, String E_OBSERVACIONES, String CID_TIPO_PERSONA_OTORGANTE, Boolean L_AUTOGENERADO, Int32 NID_PATRIMONIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO,F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, V_TIPO_MONEDA, E_RFC, E_OBSERVACIONES, CID_TIPO_PERSONA_OTORGANTE, L_AUTOGENERADO, NID_PATRIMONIO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***



     #endregion

    }
}
