using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_REGIMEN_MATRIMONIAL : dal_DECLARACION_REGIMEN_MATRIMONIAL
    {

        #region *** Propiedades ***
        #region * CAT_REGIMEN_MATRIMONIAL *
        private dald_CAT_REGIMEN_MATRIMONIAL _oCAT_REGIMEN_MATRIMONIAL { get; set; }
        internal dald_CAT_REGIMEN_MATRIMONIAL oCAT_REGIMEN_MATRIMONIAL
        {
            get
            {
                if (_oCAT_REGIMEN_MATRIMONIAL == null) _oCAT_REGIMEN_MATRIMONIAL = new dald_CAT_REGIMEN_MATRIMONIAL(NID_REGIMEN_MATRIMONIAL);
                return _oCAT_REGIMEN_MATRIMONIAL;
            }
        }
        internal void Reload_CAT_REGIMEN_MATRIMONIAL() => _oCAT_REGIMEN_MATRIMONIAL = null;

        #endregion * CAT_REGIMEN_MATRIMONIAL *


        #endregion


        #region *** Constructores ***
        internal dald_DECLARACION_REGIMEN_MATRIMONIAL() : base() { }
        internal dald_DECLARACION_REGIMEN_MATRIMONIAL(DECLARACION_REGIMEN_MATRIMONIAL DECLARACION_REGIMEN_MATRIMONIAL) : base(DECLARACION_REGIMEN_MATRIMONIAL) { }
        internal dald_DECLARACION_REGIMEN_MATRIMONIAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN) { }
        internal dald_DECLARACION_REGIMEN_MATRIMONIAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN, Int32 NID_REGIMEN_MATRIMONIAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN, NID_REGIMEN_MATRIMONIAL, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
