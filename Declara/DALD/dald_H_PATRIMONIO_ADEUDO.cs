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
    internal partial class dald_H_PATRIMONIO_ADEUDO : dal_H_PATRIMONIO_ADEUDO
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

        internal String V_ENTIDAD_FEDERATIVA => oCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA;

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



     #endregion


     #region *** Constructores ***

        internal dald_H_PATRIMONIO_ADEUDO()
        : base() { }

        internal dald_H_PATRIMONIO_ADEUDO(H_PATRIMONIO_ADEUDO H_PATRIMONIO_ADEUDO)
        : base(H_PATRIMONIO_ADEUDO) { }

        internal dald_H_PATRIMONIO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO) { }

        public dald_H_PATRIMONIO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_INSTITUCION, Int32 NID_TIPO_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, NID_INSTITUCION, NID_TIPO_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
