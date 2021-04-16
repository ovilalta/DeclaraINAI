using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_EGRESOS : dal_DECLARACION_EGRESOS
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_DECLARACION_EGRESOS() : base() { }
        internal dald_DECLARACION_EGRESOS(DECLARACION_EGRESOS DECLARACION_EGRESOS) : base(DECLARACION_EGRESOS) { }
        internal dald_DECLARACION_EGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EGRESO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EGRESO) { }
        internal dald_DECLARACION_EGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EGRESO, V_CONCEPTO, M_DECLARANTE, M_DEPENDIENTE, M_SUMA, N_NIVEL, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
