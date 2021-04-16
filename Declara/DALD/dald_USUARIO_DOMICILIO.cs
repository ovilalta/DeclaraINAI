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
    internal partial class dald_USUARIO_DOMICILIO : dal_USUARIO_DOMICILIO
    {

     #region *** Atributos ***

        #region * CAT_MUNICIPIO *

        dald_CAT_MUNICIPIO _oCAT_MUNICIPIO;
        dald_CAT_MUNICIPIO oCAT_MUNICIPIO
        {
            get
            {
                if(_oCAT_MUNICIPIO == null) _oCAT_MUNICIPIO= new dald_CAT_MUNICIPIO(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO);
                return _oCAT_MUNICIPIO;
            }
        }

        internal String V_MUNICIPIO => oCAT_MUNICIPIO.V_MUNICIPIO;

        internal void Reload_CAT_MUNICIPIO() => _oCAT_MUNICIPIO = null;


        #endregion * CAT_MUNICIPIO *


        #region * CAT_TIPO_DOMICILIO *

        dald_CAT_TIPO_DOMICILIO _oCAT_TIPO_DOMICILIO;
        dald_CAT_TIPO_DOMICILIO oCAT_TIPO_DOMICILIO
        {
            get
            {
                if(_oCAT_TIPO_DOMICILIO == null) _oCAT_TIPO_DOMICILIO= new dald_CAT_TIPO_DOMICILIO(NID_TIPO_DOMICILIO);
                return _oCAT_TIPO_DOMICILIO;
            }
        }

        internal String V_TIPO_DOMICILIO => oCAT_TIPO_DOMICILIO.V_TIPO_DOMICILIO;

        internal void Reload_CAT_TIPO_DOMICILIO() => _oCAT_TIPO_DOMICILIO = null;


        #endregion * CAT_TIPO_DOMICILIO *



     #endregion


     #region *** Constructores ***

        internal dald_USUARIO_DOMICILIO()
        : base() { }

        internal dald_USUARIO_DOMICILIO(USUARIO_DOMICILIO USUARIO_DOMICILIO)
        : base(USUARIO_DOMICILIO) { }

        internal dald_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DOMICILIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO) { }

        public dald_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DOMICILIO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String C_CODIGO_POSTAL, String E_DIRECCION, Int32 NID_TIPO_DOMICILIO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, C_CODIGO_POSTAL, E_DIRECCION, NID_TIPO_DOMICILIO, L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
