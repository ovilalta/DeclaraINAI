using Declara_V2.DAL;
using Declara_V2.Exceptions;
using MODELDeclara_V2;
using System;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_EXPERIENCIA_LABORAL : dal_DECLARACION_EXPERIENCIA_LABORAL
    {

        #region *** Propiedades ***
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


        #region * CAT_ESTADO_TESTADO *
        private dald_CAT_ESTADO_TESTADO _oCAT_ESTADO_TESTADO { get; set; }
        internal dald_CAT_ESTADO_TESTADO oCAT_ESTADO_TESTADO
        {
            get
            {
                if (_oCAT_ESTADO_TESTADO == null) _oCAT_ESTADO_TESTADO = new dald_CAT_ESTADO_TESTADO(NID_ESTADO_TESTADO);
                return _oCAT_ESTADO_TESTADO;
            }
        }
        internal void Reload_CAT_ESTADO_TESTADO() => _oCAT_ESTADO_TESTADO = null;

        #endregion * CAT_ESTADO_TESTADO *


        #region * CAT_SECTOR *
        private dald_CAT_SECTOR _oCAT_SECTOR { get; set; }
        internal dald_CAT_SECTOR oCAT_SECTOR
        {
            get
            {
                if (_oCAT_SECTOR == null) _oCAT_SECTOR = new dald_CAT_SECTOR(NID_SECTOR);
                return _oCAT_SECTOR;
            }
        }
        internal void Reload_CAT_SECTOR() => _oCAT_SECTOR = null;

        #endregion * CAT_SECTOR *


        #region * CAT_AMBITO_SECTOR *
        private dald_CAT_AMBITO_SECTOR _oCAT_AMBITO_SECTOR { get; set; }
        internal dald_CAT_AMBITO_SECTOR oCAT_AMBITO_SECTOR
        {
            get
            {
                if (_oCAT_AMBITO_SECTOR == null) _oCAT_AMBITO_SECTOR = new dald_CAT_AMBITO_SECTOR(NID_AMBITO_SECTOR);
                return _oCAT_AMBITO_SECTOR;
            }
        }
        internal void Reload_CAT_AMBITO_SECTOR() => _oCAT_AMBITO_SECTOR = null;

        #endregion * CAT_AMBITO_SECTOR *


        #region * CAT_NIVEL_GOBIERNO *
        private dald_CAT_NIVEL_GOBIERNO _oCAT_NIVEL_GOBIERNO { get; set; }
        internal dald_CAT_NIVEL_GOBIERNO oCAT_NIVEL_GOBIERNO
        {
            get
            {
                if (_oCAT_NIVEL_GOBIERNO == null) _oCAT_NIVEL_GOBIERNO = new dald_CAT_NIVEL_GOBIERNO(NID_NIVEL_GOBIERNO);
                return _oCAT_NIVEL_GOBIERNO;
            }
        }
        internal void Reload_CAT_NIVEL_GOBIERNO() => _oCAT_NIVEL_GOBIERNO = null;

        #endregion * CAT_NIVEL_GOBIERNO *


        #region * CAT_AMBITO_PUBLICO *
        private dald_CAT_AMBITO_PUBLICO _oCAT_AMBITO_PUBLICO { get; set; }
        internal dald_CAT_AMBITO_PUBLICO oCAT_AMBITO_PUBLICO
        {
            get
            {
                if (_oCAT_AMBITO_PUBLICO == null) _oCAT_AMBITO_PUBLICO = new dald_CAT_AMBITO_PUBLICO(NID_AMBITO_PUBLICO);
                return _oCAT_AMBITO_PUBLICO;
            }
        }
        internal void Reload_CAT_AMBITO_PUBLICO() => _oCAT_AMBITO_PUBLICO = null;

        #endregion * CAT_AMBITO_PUBLICO *


        #endregion


        #region *** Constructores ***
        internal dald_DECLARACION_EXPERIENCIA_LABORAL() : base() { }
        internal dald_DECLARACION_EXPERIENCIA_LABORAL(DECLARACION_EXPERIENCIA_LABORAL DECLARACION_EXPERIENCIA_LABORAL) : base(DECLARACION_EXPERIENCIA_LABORAL) { }
        internal dald_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EXPERIENCIA_LABORAL) { }
        internal dald_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE, String V_RFC, String V_AREA_ADSCRIPCION, String V_PUESTO, String V_FUNCION_PRINCIPAL, Int32 NID_SECTOR, DateTime F_INGRESO, DateTime F_EGRESO, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EXPERIENCIA_LABORAL, NID_AMBITO_SECTOR, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, V_NOMBRE, V_RFC, V_AREA_ADSCRIPCION, V_PUESTO, V_FUNCION_PRINCIPAL, NID_SECTOR, F_INGRESO, F_EGRESO, NID_PAIS, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
