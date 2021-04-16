using Declara_V2.DAL;
using Declara_V2.Exceptions;
using System;

namespace Declara_V2.DALD
{
    // Extended
    internal partial class dald_DECLARACION_CARGO : dal_DECLARACION_CARGO
    {

        #region *** Atributos (Extended) ***

        public String V_PRIMER_NIVEL => oCAT_SEGUNDO_NIVEL.V_PRIMER_NIVEL;

        #endregion


        #region *** Constructores (Extended) ***


        public dald_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, DateTime F_INICIO, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
            : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, V_FUNCION_PRINCIPAL, F_POSESION, F_INICIO, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, lOpcionesRegistroExistente) { }



        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
