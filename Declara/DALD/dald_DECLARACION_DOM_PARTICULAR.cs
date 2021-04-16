using Declara_V2.DAL;
using Declara_V2.Exceptions;
using MODELDeclara_V2;
using System;

namespace Declara_V2.DALD
{
    internal partial class dald_DECLARACION_DOM_PARTICULAR : dal_DECLARACION_DOM_PARTICULAR
    {

        #region *** Atributos ***


        #endregion


        #region *** Constructores ***

        internal dald_DECLARACION_DOM_PARTICULAR()
        : base() { }

        internal dald_DECLARACION_DOM_PARTICULAR(DECLARACION_DOM_PARTICULAR DECLARACION_DOM_PARTICULAR)
        : base(DECLARACION_DOM_PARTICULAR) { }

        internal dald_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }

        public dald_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_CORREO, String V_TEL_PARTICULAR, String V_TEL_CELULAR, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, String V_ENTIDAD_FEDERATIVA, String V_MUNICIPIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)

            : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_CORREO, V_TEL_PARTICULAR, V_TEL_CELULAR, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, V_ENTIDAD_FEDERATIVA, V_MUNICIPIO, lOpcionesRegistroExistente) { }



        #endregion


        #region *** Metodos ***


        #endregion

    }
}
