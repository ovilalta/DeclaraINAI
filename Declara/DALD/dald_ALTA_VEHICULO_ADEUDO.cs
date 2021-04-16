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
    internal partial class dald_ALTA_VEHICULO_ADEUDO : dal_ALTA_VEHICULO_ADEUDO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_ALTA_VEHICULO_ADEUDO()
        : base() { }

        internal dald_ALTA_VEHICULO_ADEUDO(ALTA_VEHICULO_ADEUDO ALTA_VEHICULO_ADEUDO)
        : base(ALTA_VEHICULO_ADEUDO) { }

        internal dald_ALTA_VEHICULO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO) { }

        public dald_ALTA_VEHICULO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO, Int32 NID_ADEUDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, NID_ADEUDO, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
