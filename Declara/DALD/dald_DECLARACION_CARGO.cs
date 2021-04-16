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
    internal partial class dald_DECLARACION_CARGO : dal_DECLARACION_CARGO
    {

     #region *** Atributos ***

        #region * CAT_PUESTO *

        dald_CAT_PUESTO _oCAT_PUESTO;
        dald_CAT_PUESTO oCAT_PUESTO
        {
            get
            {
                if(_oCAT_PUESTO == null) _oCAT_PUESTO= new dald_CAT_PUESTO(NID_PUESTO);
                return _oCAT_PUESTO;
            }
        }

        internal String VID_PUESTO => oCAT_PUESTO.VID_PUESTO;

        internal String VID_NIVEL => oCAT_PUESTO.VID_NIVEL;

        internal String V_PUESTO => oCAT_PUESTO.V_PUESTO;

        internal Boolean L_ACTIVO => oCAT_PUESTO.L_ACTIVO;

        internal void Reload_CAT_PUESTO() => _oCAT_PUESTO = null;


        #endregion * CAT_PUESTO *


        #region * CAT_SEGUNDO_NIVEL *

        dald_CAT_SEGUNDO_NIVEL _oCAT_SEGUNDO_NIVEL;
        protected dald_CAT_SEGUNDO_NIVEL oCAT_SEGUNDO_NIVEL
        {
            get
            {
                if(_oCAT_SEGUNDO_NIVEL == null) _oCAT_SEGUNDO_NIVEL= new dald_CAT_SEGUNDO_NIVEL(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL);
                return _oCAT_SEGUNDO_NIVEL;
            }
        }

        internal String V_SEGUNDO_NIVEL => oCAT_SEGUNDO_NIVEL.V_SEGUNDO_NIVEL;

        internal String C_INICIO => oCAT_SEGUNDO_NIVEL.C_INICIO;

        internal String C_FIN => oCAT_SEGUNDO_NIVEL.C_FIN;

        internal void Reload_CAT_SEGUNDO_NIVEL() => _oCAT_SEGUNDO_NIVEL = null;


        #endregion * CAT_SEGUNDO_NIVEL *



     #endregion


     #region *** Constructores ***

        internal dald_DECLARACION_CARGO()
        : base() { }

        internal dald_DECLARACION_CARGO(DECLARACION_CARGO DECLARACION_CARGO)
        : base(DECLARACION_CARGO) { }

        internal dald_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }

        //public dald_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, DateTime F_POSESION, DateTime F_INICIO, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL,String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO,Int32 NID_ESTADO_TESTADO,  ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        //: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, F_POSESION, F_INICIO, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL,E_OBSERVACIONES,E_OBSERVACIONES_MARCADO,V_OBSERVACIONES_TESTADO,NID_ESTADO_TESTADO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
