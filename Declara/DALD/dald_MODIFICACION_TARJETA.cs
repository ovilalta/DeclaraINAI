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
    internal partial class dald_MODIFICACION_TARJETA : dal_MODIFICACION_TARJETA
    {

     #region *** Atributos ***

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

        internal Boolean L_ACTIVO => oCAT_INST_FINANCIERA.L_ACTIVO;

        internal void Reload_CAT_INST_FINANCIERA() => _oCAT_INST_FINANCIERA = null;


        #endregion * CAT_INST_FINANCIERA *


        internal List<MODIFICACION_TARJETA_TITU> _MODIFICACION_TARJETA_TITUs
        {
            get
            {
               MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
                return (from p in dbInt.MODIFICACION_TARJETA_TITU
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION &&
                                   p.E_NUMERO == E_NUMERO
                              select p).ToList();
            }
        }


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_TARJETA()
        : base() { }

        internal dald_MODIFICACION_TARJETA(MODIFICACION_TARJETA MODIFICACION_TARJETA)
        : base(MODIFICACION_TARJETA) { }

        internal dald_MODIFICACION_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO) { }

        public dald_MODIFICACION_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_INSTITUCION, String V_NUMERO_CORTO, Decimal M_PAGOS, Decimal M_SALDO, String E_NUMERO_ASOCIACION, Boolean L_ACTIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_INSTITUCION, V_NUMERO_CORTO, M_PAGOS, M_SALDO, E_NUMERO_ASOCIACION, L_ACTIVA, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
