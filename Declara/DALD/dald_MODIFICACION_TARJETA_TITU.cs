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
    internal partial class dald_MODIFICACION_TARJETA_TITU : dal_MODIFICACION_TARJETA_TITU
    {

     #region *** Atributos ***


     #endregion


     #region *** Constructores ***

        internal dald_MODIFICACION_TARJETA_TITU()
        : base() { }

        internal dald_MODIFICACION_TARJETA_TITU(MODIFICACION_TARJETA_TITU MODIFICACION_TARJETA_TITU)
        : base(MODIFICACION_TARJETA_TITU) { }

        internal dald_MODIFICACION_TARJETA_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_DEPENDIENTE) { }

        public dald_MODIFICACION_TARJETA_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_DEPENDIENTE, L_DIF, lOpcionesRegistroExistente)  { }



     #endregion


     #region *** Metodos ***


     #endregion

    }
}
