using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_ALTA_COMODATO_INMUEBLE : dal_ALTA_COMODATO_INMUEBLE
    {

        #region *** Propiedades ***
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


        #region * CAT_TIPO_INMUEBLE *
        private dald_CAT_TIPO_INMUEBLE _oCAT_TIPO_INMUEBLE { get; set; }
        internal dald_CAT_TIPO_INMUEBLE oCAT_TIPO_INMUEBLE
        {
            get
            {
                if (_oCAT_TIPO_INMUEBLE == null) _oCAT_TIPO_INMUEBLE = new dald_CAT_TIPO_INMUEBLE(NID_TIPO);
                return _oCAT_TIPO_INMUEBLE;
            }
        }
        internal void Reload_CAT_TIPO_INMUEBLE() => _oCAT_TIPO_INMUEBLE = null;

        #endregion * CAT_TIPO_INMUEBLE *


        #endregion


        #region *** Constructores ***
        internal dald_ALTA_COMODATO_INMUEBLE() : base() { }
        internal dald_ALTA_COMODATO_INMUEBLE(ALTA_COMODATO_INMUEBLE ALTA_COMODATO_INMUEBLE) : base(ALTA_COMODATO_INMUEBLE) { }
        internal dald_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO) { }
        internal dald_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO, NID_TIPO, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
