using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_EXPERIENCIA_LABORAL : bll_DECLARACION_EXPERIENCIA_LABORAL
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_DECLARACION_EXPERIENCIA_LABORAL() : base() { }
        public blld_DECLARACION_EXPERIENCIA_LABORAL(MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL DECLARACION_EXPERIENCIA_LABORAL) : base(DECLARACION_EXPERIENCIA_LABORAL) { }
        public blld_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EXPERIENCIA_LABORAL) { }

//        public blld_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE, String V_RFC, String V_AREA_ADSCRIPCION, String V_PUESTO, String V_FUNCION_PRINCIPAL, Int32 NID_SECTOR, DateTime F_INGRESO, DateTime F_EGRESO, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EXPERIENCIA_LABORAL, NID_AMBITO_SECTOR, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, V_NOMBRE, V_RFC, V_AREA_ADSCRIPCION, V_PUESTO, V_FUNCION_PRINCIPAL, NID_SECTOR, F_INGRESO, F_EGRESO, NID_PAIS, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
