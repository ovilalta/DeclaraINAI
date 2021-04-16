using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_ESCOLARIDAD : dal_DECLARACION_ESCOLARIDAD
    {

        #region *** Propiedades ***
        #region * CAT_NIVEL_ESCOLARIDAD *
        private dald_CAT_NIVEL_ESCOLARIDAD _oCAT_NIVEL_ESCOLARIDAD { get; set; }
        internal dald_CAT_NIVEL_ESCOLARIDAD oCAT_NIVEL_ESCOLARIDAD
        {
            get
            {
                if (_oCAT_NIVEL_ESCOLARIDAD == null) _oCAT_NIVEL_ESCOLARIDAD = new dald_CAT_NIVEL_ESCOLARIDAD(NID_NIVEL_ESCOLARIDAD);
                return _oCAT_NIVEL_ESCOLARIDAD;
            }
        }
        internal void Reload_CAT_NIVEL_ESCOLARIDAD() => _oCAT_NIVEL_ESCOLARIDAD = null;

        #endregion * CAT_NIVEL_ESCOLARIDAD *


        #region * CAT_ESTADO_ESCOLARIDAD *
        private dald_CAT_ESTADO_ESCOLARIDAD _oCAT_ESTADO_ESCOLARIDAD { get; set; }
        internal dald_CAT_ESTADO_ESCOLARIDAD oCAT_ESTADO_ESCOLARIDAD
        {
            get
            {
                if (_oCAT_ESTADO_ESCOLARIDAD == null) _oCAT_ESTADO_ESCOLARIDAD = new dald_CAT_ESTADO_ESCOLARIDAD(NID_ESTADO_ESCOLARIDAD);
                return _oCAT_ESTADO_ESCOLARIDAD;
            }
        }
        internal void Reload_CAT_ESTADO_ESCOLARIDAD() => _oCAT_ESTADO_ESCOLARIDAD = null;

        #endregion * CAT_ESTADO_ESCOLARIDAD *


        #region * CAT_DOCUMENTO_OBTENIDO *
        private dald_CAT_DOCUMENTO_OBTENIDO _oCAT_DOCUMENTO_OBTENIDO { get; set; }
        internal dald_CAT_DOCUMENTO_OBTENIDO oCAT_DOCUMENTO_OBTENIDO
        {
            get
            {
                if (_oCAT_DOCUMENTO_OBTENIDO == null) _oCAT_DOCUMENTO_OBTENIDO = new dald_CAT_DOCUMENTO_OBTENIDO(NID_DOCUMENTO_OBTENIDO);
                return _oCAT_DOCUMENTO_OBTENIDO;
            }
        }
        internal void Reload_CAT_DOCUMENTO_OBTENIDO() => _oCAT_DOCUMENTO_OBTENIDO = null;

        #endregion * CAT_DOCUMENTO_OBTENIDO *


        #region * CAT_PAIS *
        private dald_CAT_PAIS _oCAT_PAIS { get; set; }
        internal dald_CAT_PAIS oCAT_PAIS
        {
            get
            {
                if (_oCAT_PAIS == null) _oCAT_PAIS = new dald_CAT_PAIS(NID_PAIS);
                return _oCAT_PAIS;
            }
        }
        internal void Reload_CAT_PAIS() => _oCAT_PAIS = null;

        #endregion * CAT_PAIS *


        #endregion


        #region *** Constructores ***
        internal dald_DECLARACION_ESCOLARIDAD() : base() { }
        internal dald_DECLARACION_ESCOLARIDAD(DECLARACION_ESCOLARIDAD DECLARACION_ESCOLARIDAD) : base(DECLARACION_ESCOLARIDAD) { }
        internal dald_DECLARACION_ESCOLARIDAD(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ESCOLARIDAD)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ESCOLARIDAD) { }
        internal dald_DECLARACION_ESCOLARIDAD(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ESCOLARIDAD, Int32 NID_NIVEL_ESCOLARIDAD, String V_INSTITUCION_EDUCATIVA, String V_CARRERA, Int32 NID_ESTADO_ESCOLARIDAD, Int32 NID_DOCUMENTO_OBTENIDO, DateTime F_OBTENCION, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ESCOLARIDAD, NID_NIVEL_ESCOLARIDAD, V_INSTITUCION_EDUCATIVA, V_CARRERA, NID_ESTADO_ESCOLARIDAD, NID_DOCUMENTO_OBTENIDO, F_OBTENCION, NID_PAIS, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
