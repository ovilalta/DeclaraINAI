using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_INGRESOS : bll_DECLARACION_INGRESOS
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_DECLARACION_INGRESOS() : base() { }
        public blld_DECLARACION_INGRESOS(MODELDeclara_V2.DECLARACION_INGRESOS DECLARACION_INGRESOS) : base(DECLARACION_INGRESOS) { }
        public blld_DECLARACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO) { }

//        public blld_DECLARACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO, V_CONCEPTO, M_DECLARANTE, M_DEPENDIENTE, M_SUMA, N_NIVEL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
