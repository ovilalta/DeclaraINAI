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
    internal partial class dald_CAT_MUNICIPIO : dal_CAT_MUNICIPIO
    {

     #region *** Atributos ***

        #region * CAT_ENTIDAD_FEDERATIVA *

        dald_CAT_ENTIDAD_FEDERATIVA _oCAT_ENTIDAD_FEDERATIVA;
        dald_CAT_ENTIDAD_FEDERATIVA oCAT_ENTIDAD_FEDERATIVA
        {
            get
            {
                if(_oCAT_ENTIDAD_FEDERATIVA == null) _oCAT_ENTIDAD_FEDERATIVA= new dald_CAT_ENTIDAD_FEDERATIVA(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
                return _oCAT_ENTIDAD_FEDERATIVA;
            }
        }

        internal String V_ENTIDAD_FEDERATIVA => oCAT_ENTIDAD_FEDERATIVA.V_ENTIDAD_FEDERATIVA;

        internal void Reload_CAT_ENTIDAD_FEDERATIVA() => _oCAT_ENTIDAD_FEDERATIVA = null;


        #endregion * CAT_ENTIDAD_FEDERATIVA *



     #endregion


     #region *** Constructores ***

        internal dald_CAT_MUNICIPIO()
        : base() { }

        internal dald_CAT_MUNICIPIO(CAT_MUNICIPIO CAT_MUNICIPIO)
        : base(CAT_MUNICIPIO) { }

        internal dald_CAT_MUNICIPIO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO) { }

        public dald_CAT_MUNICIPIO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_MUNICIPIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_MUNICIPIO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
