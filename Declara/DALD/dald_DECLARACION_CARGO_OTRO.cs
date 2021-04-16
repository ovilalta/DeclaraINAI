using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_CARGO_OTRO : dal_DECLARACION_CARGO_OTRO
    {

        #region *** Propiedades ***
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


        #region * CAT_MUNICIPIO *
        private dald_CAT_MUNICIPIO _oCAT_MUNICIPIO { get; set; }
        internal dald_CAT_MUNICIPIO oCAT_MUNICIPIO
        {
            get
            {
                if (_oCAT_MUNICIPIO == null) _oCAT_MUNICIPIO = new dald_CAT_MUNICIPIO(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO);
                return _oCAT_MUNICIPIO;
            }
        }
        internal void Reload_CAT_MUNICIPIO() => _oCAT_MUNICIPIO = null;

        #endregion * CAT_MUNICIPIO *


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
        internal dald_DECLARACION_CARGO_OTRO() : base() { }
        internal dald_DECLARACION_CARGO_OTRO(DECLARACION_CARGO_OTRO DECLARACION_CARGO_OTRO) : base(DECLARACION_CARGO_OTRO) { }
        internal dald_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }
        internal dald_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String VID_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, Boolean L_HONORARIOS, String V_NIVEL_EMPLEO, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, String V_TEL_LABORAL, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_OBSERVACIONES, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, VID_NOMBRE_ENTE, V_AREA_ADSCRIPCION, V_CARGO, L_HONORARIOS, V_NIVEL_EMPLEO, V_FUNCION_PRINCIPAL, F_POSESION, V_TEL_LABORAL, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_OBSERVACIONES, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
