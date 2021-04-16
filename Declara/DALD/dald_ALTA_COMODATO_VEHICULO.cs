using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_ALTA_COMODATO_VEHICULO : dal_ALTA_COMODATO_VEHICULO
    {

        #region *** Propiedades ***
        #region * CAT_TIPO_VEHICULO *
        private dald_CAT_TIPO_VEHICULO _oCAT_TIPO_VEHICULO { get; set; }
        internal dald_CAT_TIPO_VEHICULO oCAT_TIPO_VEHICULO
        {
            get
            {
                if (_oCAT_TIPO_VEHICULO == null) _oCAT_TIPO_VEHICULO = new dald_CAT_TIPO_VEHICULO(NID_TIPO_VEHICULO);
                return _oCAT_TIPO_VEHICULO;
            }
        }
        internal void Reload_CAT_TIPO_VEHICULO() => _oCAT_TIPO_VEHICULO = null;

        #endregion * CAT_TIPO_VEHICULO *


        #region * CAT_MARCA_VEHICULO *
        private dald_CAT_MARCA_VEHICULO _oCAT_MARCA_VEHICULO { get; set; }
        internal dald_CAT_MARCA_VEHICULO oCAT_MARCA_VEHICULO
        {
            get
            {
                if (_oCAT_MARCA_VEHICULO == null) _oCAT_MARCA_VEHICULO = new dald_CAT_MARCA_VEHICULO(NID_MARCA);
                return _oCAT_MARCA_VEHICULO;
            }
        }
        internal void Reload_CAT_MARCA_VEHICULO() => _oCAT_MARCA_VEHICULO = null;

        #endregion * CAT_MARCA_VEHICULO *


        #region * CAT_ENTIDAD_FEDERATIVA *
        private dald_CAT_ENTIDAD_FEDERATIVA _oCAT_ENTIDAD_FEDERATIVA { get; set; }
        internal dald_CAT_ENTIDAD_FEDERATIVA oCAT_ENTIDAD_FEDERATIVA
        {
            get
            {
                if (_oCAT_ENTIDAD_FEDERATIVA == null) _oCAT_ENTIDAD_FEDERATIVA = new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
                return _oCAT_ENTIDAD_FEDERATIVA;
            }
        }
        internal void Reload_CAT_ENTIDAD_FEDERATIVA() => _oCAT_ENTIDAD_FEDERATIVA = null;

        #endregion * CAT_ENTIDAD_FEDERATIVA *


        #endregion


        #region *** Constructores ***
        internal dald_ALTA_COMODATO_VEHICULO() : base() { }
        internal dald_ALTA_COMODATO_VEHICULO(ALTA_COMODATO_VEHICULO ALTA_COMODATO_VEHICULO) : base(ALTA_COMODATO_VEHICULO) { }
        internal dald_ALTA_COMODATO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO) { }
        internal dald_ALTA_COMODATO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO_VEHICULO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, String E_NUMERO_SERIE, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO, NID_TIPO_VEHICULO, NID_MARCA, C_MODELO, V_DESCRIPCION, E_NUMERO_SERIE, NID_PAIS, CID_ENTIDAD_FEDERATIVA, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
