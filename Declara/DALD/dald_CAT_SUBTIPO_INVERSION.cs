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
    internal partial class dald_CAT_SUBTIPO_INVERSION : dal_CAT_SUBTIPO_INVERSION
    {

     #region *** Atributos ***

        #region * CAT_TIPO_INVERSION *

        dald_CAT_TIPO_INVERSION _oCAT_TIPO_INVERSION;
        dald_CAT_TIPO_INVERSION oCAT_TIPO_INVERSION
        {
            get
            {
                if(_oCAT_TIPO_INVERSION == null) _oCAT_TIPO_INVERSION= new dald_CAT_TIPO_INVERSION(NID_TIPO_INVERSION);
                return _oCAT_TIPO_INVERSION;
            }
        }

        internal String V_TIPO_INVERSION => oCAT_TIPO_INVERSION.V_TIPO_INVERSION;

        internal void Reload_CAT_TIPO_INVERSION() => _oCAT_TIPO_INVERSION = null;


        #endregion * CAT_TIPO_INVERSION *



     #endregion


     #region *** Constructores ***

        internal dald_CAT_SUBTIPO_INVERSION()
        : base() { }

        internal dald_CAT_SUBTIPO_INVERSION(CAT_SUBTIPO_INVERSION CAT_SUBTIPO_INVERSION)
        : base(CAT_SUBTIPO_INVERSION) { }

        internal dald_CAT_SUBTIPO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION)
        : base(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION) { }

        public dald_CAT_SUBTIPO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, String V_SUBTIPO_INVERSION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, V_SUBTIPO_INVERSION,L_ACTIVO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
