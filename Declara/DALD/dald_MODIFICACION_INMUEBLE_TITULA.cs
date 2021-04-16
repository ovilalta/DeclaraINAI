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
    internal partial class dald_MODIFICACION_INMUEBLE_TITULA : dal_MODIFICACION_INMUEBLE_TITULA
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_INMUEBLE_TITULA()
        : base() { }

        internal dald_MODIFICACION_INMUEBLE_TITULA(MODIFICACION_INMUEBLE_TITULA MODIFICACION_INMUEBLE_TITULA)
        : base(MODIFICACION_INMUEBLE_TITULA) { }

        internal dald_MODIFICACION_INMUEBLE_TITULA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE) { }

        public dald_MODIFICACION_INMUEBLE_TITULA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
