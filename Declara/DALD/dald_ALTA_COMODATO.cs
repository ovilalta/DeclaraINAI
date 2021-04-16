using System;
using System.Collections.Generic;
using System.Linq;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DAL;

namespace Declara_V2.DALD
{
    internal partial class dald_ALTA_COMODATO : dal_ALTA_COMODATO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        internal dald_ALTA_COMODATO() : base() { }
        internal dald_ALTA_COMODATO(ALTA_COMODATO ALTA_COMODATO) : base(ALTA_COMODATO) { }
        internal dald_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO) { }
        internal dald_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, String CID_TIPO_PERSONA, String E_TITULAR, String E_RFC, Int32 NID_TIPO_RELACION, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO, CID_TIPO_PERSONA, E_TITULAR, E_RFC, NID_TIPO_RELACION, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, lOpcionesRegistroExistente) { }

        #endregion


        #region *** Metodos ***


        #endregion

    }
}
