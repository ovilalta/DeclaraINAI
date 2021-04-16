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
    internal partial class dald_PATRIMONIO_FLUJO : dal_PATRIMONIO_FLUJO
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_PATRIMONIO_FLUJO()
        : base() { }

        internal dald_PATRIMONIO_FLUJO(PATRIMONIO_FLUJO PATRIMONIO_FLUJO)
        : base(PATRIMONIO_FLUJO) { }

        internal dald_PATRIMONIO_FLUJO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE) { }

        public dald_PATRIMONIO_FLUJO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Decimal M_INGRESOS, Decimal M_EGRESOS, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, M_INGRESOS, M_EGRESOS, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
