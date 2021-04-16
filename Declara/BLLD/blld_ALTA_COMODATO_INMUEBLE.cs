using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_COMODATO_INMUEBLE : bll_ALTA_COMODATO_INMUEBLE
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_ALTA_COMODATO_INMUEBLE() : base() { }
        public blld_ALTA_COMODATO_INMUEBLE(MODELDeclara_V2.ALTA_COMODATO_INMUEBLE ALTA_COMODATO_INMUEBLE) : base(ALTA_COMODATO_INMUEBLE) { }
        public blld_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO) { }

//        public blld_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO, NID_TIPO, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
