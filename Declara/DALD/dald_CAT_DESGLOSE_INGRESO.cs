using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_CAT_DESGLOSE_INGRESO : dal_CAT_DESGLOSE_INGRESO
    {

        #region *** Propiedades ***
        #region * CAT_DESGLOSE_INGRESO_SUPERIOR *
        private dald_CAT_DESGLOSE_INGRESO_SUPERIOR _oCAT_DESGLOSE_INGRESO_SUPERIOR { get; set; }
        internal dald_CAT_DESGLOSE_INGRESO_SUPERIOR oCAT_DESGLOSE_INGRESO_SUPERIOR
        {
            get
            {
                if (_oCAT_DESGLOSE_INGRESO_SUPERIOR == null) _oCAT_DESGLOSE_INGRESO_SUPERIOR = new dald_CAT_DESGLOSE_INGRESO_SUPERIOR(NID_INGRESO_SUPERIOR);
                return _oCAT_DESGLOSE_INGRESO_SUPERIOR;
            }
        }
        internal void Reload_CAT_DESGLOSE_INGRESO_SUPERIOR() => _oCAT_DESGLOSE_INGRESO_SUPERIOR = null;

        #endregion * CAT_DESGLOSE_INGRESO_SUPERIOR *


        #endregion


        #region *** Constructores ***
        internal dald_CAT_DESGLOSE_INGRESO() : base() { }
        internal dald_CAT_DESGLOSE_INGRESO(CAT_DESGLOSE_INGRESO CAT_DESGLOSE_INGRESO) : base(CAT_DESGLOSE_INGRESO) { }
        internal dald_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO)
        : base(NID_INGRESO_SUPERIOR, NID_INGRESO) { }
        internal dald_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO, String V_INGRESO, Boolean L_VIGENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(NID_INGRESO_SUPERIOR, NID_INGRESO, V_INGRESO, L_VIGENTE, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
