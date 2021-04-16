using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_COMODATO_VEHICULO : bll_ALTA_COMODATO_VEHICULO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        private blld_ALTA_COMODATO_VEHICULO() : base() { }
        public blld_ALTA_COMODATO_VEHICULO(MODELDeclara_V2.ALTA_COMODATO_VEHICULO ALTA_COMODATO_VEHICULO) : base(ALTA_COMODATO_VEHICULO) { }
        public blld_ALTA_COMODATO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO) { }

//        public blld_ALTA_COMODATO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO_VEHICULO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, String E_NUMERO_SERIE, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO, NID_TIPO_VEHICULO, NID_MARCA, C_MODELO, V_DESCRIPCION, E_NUMERO_SERIE, NID_PAIS, CID_ENTIDAD_FEDERATIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
