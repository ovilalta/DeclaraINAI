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
    internal partial class dald_ALTA_INMUEBLE_TITULAR : dal_ALTA_INMUEBLE_TITULAR
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_ALTA_INMUEBLE_TITULAR()
        : base() { }

        internal dald_ALTA_INMUEBLE_TITULAR(ALTA_INMUEBLE_TITULAR ALTA_INMUEBLE_TITULAR)
        : base(ALTA_INMUEBLE_TITULAR) { }

        internal dald_ALTA_INMUEBLE_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_DEPENDIENTE) { }

        public dald_ALTA_INMUEBLE_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_DEPENDIENTE, L_DIF, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
