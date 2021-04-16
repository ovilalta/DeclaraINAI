using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_CARGO_OTRO : bll_DECLARACION_CARGO_OTRO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_DECLARACION_CARGO_OTRO() : base() { }
        public blld_DECLARACION_CARGO_OTRO(MODELDeclara_V2.DECLARACION_CARGO_OTRO DECLARACION_CARGO_OTRO) : base(DECLARACION_CARGO_OTRO) { }
        public blld_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }

//        public blld_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String VID_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, Boolean L_HONORARIOS, String V_NIVEL_EMPLEO, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, String V_TEL_LABORAL, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_OBSERVACIONES)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_NIVEL_GOBIERNO, NID_AMBITO_PUBLICO, VID_NOMBRE_ENTE, V_AREA_ADSCRIPCION, V_CARGO, L_HONORARIOS, V_NIVEL_EMPLEO, V_FUNCION_PRINCIPAL, F_POSESION, V_TEL_LABORAL, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_OBSERVACIONES, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
