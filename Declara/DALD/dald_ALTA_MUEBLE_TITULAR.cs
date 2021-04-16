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
    internal partial class dald_ALTA_MUEBLE_TITULAR : dal_ALTA_MUEBLE_TITULAR
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_ALTA_MUEBLE_TITULAR()
        : base() { }

        internal dald_ALTA_MUEBLE_TITULAR(ALTA_MUEBLE_TITULAR ALTA_MUEBLE_TITULAR)
        : base(ALTA_MUEBLE_TITULAR) { }

        internal dald_ALTA_MUEBLE_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_DEPENDIENTE) { }

        public dald_ALTA_MUEBLE_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_DEPENDIENTE, L_DIF, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
