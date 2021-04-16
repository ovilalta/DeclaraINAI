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
    internal partial class dald_MODIFICACION_INMUEBLE_ADEUDO : dal_MODIFICACION_INMUEBLE_ADEUDO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_INMUEBLE_ADEUDO()
        : base() { }

        internal dald_MODIFICACION_INMUEBLE_ADEUDO(MODIFICACION_INMUEBLE_ADEUDO MODIFICACION_INMUEBLE_ADEUDO)
        : base(MODIFICACION_INMUEBLE_ADEUDO) { }

        internal dald_MODIFICACION_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO) { }

        public dald_MODIFICACION_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO, L_DIF, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
