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
    internal partial class dald_DECLARACION_DOM_LABORAL : dal_DECLARACION_DOM_LABORAL
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_DECLARACION_DOM_LABORAL()
        : base() { }

        internal dald_DECLARACION_DOM_LABORAL(DECLARACION_DOM_LABORAL DECLARACION_DOM_LABORAL)
        : base(DECLARACION_DOM_LABORAL) { }

        internal dald_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION) { }

        public dald_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO,String V_COLONIA, String V_DOMICILIO, String V_CORREO_LABORAL, String V_TEL_LABORAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_CORREO_LABORAL, V_TEL_LABORAL, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
