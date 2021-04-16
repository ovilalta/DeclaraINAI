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
    internal partial class dald_MODIFICACION_DONACION : dal_MODIFICACION_DONACION
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_DONACION()
        : base() { }

        internal dald_MODIFICACION_DONACION(MODIFICACION_DONACION MODIFICACION_DONACION)
        : base(MODIFICACION_DONACION) { }

        internal dald_MODIFICACION_DONACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO) { }

        public dald_MODIFICACION_DONACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, String V_ESPECIFICA,String E_BENIFICIARIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, V_ESPECIFICA, E_BENIFICIARIO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
