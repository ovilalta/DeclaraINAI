using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_COMODATO : bll_ALTA_COMODATO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_ALTA_COMODATO() : base() { }
        public blld_ALTA_COMODATO(MODELDeclara_V2.ALTA_COMODATO ALTA_COMODATO) : base(ALTA_COMODATO) { }
        public blld_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO) { }

//        public blld_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, String CID_TIPO_PERSONA, String E_TITULAR, String E_RFC, Int32 NID_TIPO_RELACION, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO, CID_TIPO_PERSONA, E_TITULAR, E_RFC, NID_TIPO_RELACION, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
