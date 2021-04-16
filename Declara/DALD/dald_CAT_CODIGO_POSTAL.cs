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
    internal partial class dald_CAT_CODIGO_POSTAL : dal_CAT_CODIGO_POSTAL
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



     #endregion


     #region *** Constructores ***

        internal dald_CAT_CODIGO_POSTAL()
        : base() { }

        internal dald_CAT_CODIGO_POSTAL(CAT_CODIGO_POSTAL CAT_CODIGO_POSTAL)
        : base(CAT_CODIGO_POSTAL) { }

        internal dald_CAT_CODIGO_POSTAL(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String CID_CODIGO_POSTAL, Int32 NID_COLONIA)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, CID_CODIGO_POSTAL, NID_COLONIA) { }

        public dald_CAT_CODIGO_POSTAL(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String CID_CODIGO_POSTAL, Int32 NID_COLONIA, String V_COLONIA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, CID_CODIGO_POSTAL, NID_COLONIA, V_COLONIA, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
