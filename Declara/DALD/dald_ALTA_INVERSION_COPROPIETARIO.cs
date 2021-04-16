using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_ALTA_INVERSION_COPROPIETARIO : dal_ALTA_INVERSION_COPROPIETARIO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_ALTA_INVERSION_COPROPIETARIO() : base() { }
        internal dald_ALTA_INVERSION_COPROPIETARIO(ALTA_INVERSION_COPROPIETARIO ALTA_INVERSION_COPROPIETARIO) : base(ALTA_INVERSION_COPROPIETARIO) { }
        internal dald_ALTA_INVERSION_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_COPROPIETARIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_COPROPIETARIO) { }
        internal dald_ALTA_INVERSION_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_COPROPIETARIO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_COPROPIETARIO, CID_TIPO_PERSONA, V_NOMBRE, V_RFC, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
