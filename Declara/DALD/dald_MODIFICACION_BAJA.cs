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
    internal partial class dald_MODIFICACION_BAJA : dal_MODIFICACION_BAJA
    {

     #region *** Atributos ***

        #region * CAT_TIPO_BAJA *

        dald_CAT_TIPO_BAJA _oCAT_TIPO_BAJA;
        dald_CAT_TIPO_BAJA oCAT_TIPO_BAJA
        {
            get
            {
                if(_oCAT_TIPO_BAJA == null) _oCAT_TIPO_BAJA= new dald_CAT_TIPO_BAJA(NID_TIPO_BAJA);
                return _oCAT_TIPO_BAJA;
            }
        }

        internal String V_TIPO_BAJA => oCAT_TIPO_BAJA.V_TIPO_BAJA;

        internal void Reload_CAT_TIPO_BAJA() => _oCAT_TIPO_BAJA = null;


        #endregion * CAT_TIPO_BAJA *



     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_BAJA()
        : base() { }

        internal dald_MODIFICACION_BAJA(MODIFICACION_BAJA MODIFICACION_BAJA)
        : base(MODIFICACION_BAJA) { }

        internal dald_MODIFICACION_BAJA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO) { }

        public dald_MODIFICACION_BAJA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_BAJA, F_BAJA, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
