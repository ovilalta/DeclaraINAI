using Declara_V2.DAL;
using Declara_V2.Exceptions;
using MODELDeclara_V2;
using System;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_DEPENDIENTES : dal_DECLARACION_DEPENDIENTES
    {

        #region *** Atributos ***

        #region * CAT_TIPO_DEPENDIENTES *

        dald_CAT_TIPO_DEPENDIENTES _oCAT_TIPO_DEPENDIENTES;
        dald_CAT_TIPO_DEPENDIENTES oCAT_TIPO_DEPENDIENTES
        {
            get
            {
                if (_oCAT_TIPO_DEPENDIENTES == null) _oCAT_TIPO_DEPENDIENTES = new dald_CAT_TIPO_DEPENDIENTES(NID_TIPO_DEPENDIENTE);
                return _oCAT_TIPO_DEPENDIENTES;
            }
        }

        internal String V_TIPO_DEPENDIENTE => oCAT_TIPO_DEPENDIENTES.V_TIPO_DEPENDIENTE;

        internal void Reload_CAT_TIPO_DEPENDIENTES() => _oCAT_TIPO_DEPENDIENTES = null;


        #endregion * CAT_TIPO_DEPENDIENTES *



        #endregion


        #region *** Constructores ***

        internal dald_DECLARACION_DEPENDIENTES()
        : base() { }

        internal dald_DECLARACION_DEPENDIENTES(DECLARACION_DEPENDIENTES DECLARACION_DEPENDIENTES)
        : base(DECLARACION_DEPENDIENTES) { }

        internal dald_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE) { }
        public dald_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO, String E_DOMICILIO
                                                               , Boolean L_CIUDADANO_EXTRANJERO
                                                               , String E_CURP
                                                               , Int32 NID_ACTIVIDAD_LABORAL
                                                               , String E_OBSERVACIONES
                                                               , String E_OBSERVACIONES_MARCADO
                                                               , String V_OBSERVACIONES_TESTADO
                                                               , Boolean L_MISMO_DOMICILIO_DECLARANTE, Boolean L_ACTIVO, Boolean L_PAREJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, L_DEPENDE_ECO, E_DOMICILIO, L_CIUDADANO_EXTRANJERO, E_CURP
                                                               , NID_ACTIVIDAD_LABORAL
                                                               , E_OBSERVACIONES
                                                               , E_OBSERVACIONES_MARCADO
                                                               , V_OBSERVACIONES_TESTADO
                                                               , L_MISMO_DOMICILIO_DECLARANTE, L_ACTIVO, L_PAREJA, lOpcionesRegistroExistente)
        { }



        #endregion


        #region *** Metodos ***


        #endregion

    }
}
