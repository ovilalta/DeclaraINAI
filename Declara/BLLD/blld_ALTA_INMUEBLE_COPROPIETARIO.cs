using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_INMUEBLE_COPROPIETARIO : bll_ALTA_INMUEBLE_COPROPIETARIO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        //sme private blld_ALTA_INMUEBLE_COPROPIETARIO() : base() { }
        public blld_ALTA_INMUEBLE_COPROPIETARIO(MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO ALTA_INMUEBLE_COPROPIETARIO) : base(ALTA_INMUEBLE_COPROPIETARIO) { }
        public blld_ALTA_INMUEBLE_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_COPROPIETARIO) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_COPROPIETARIO) { }

//        public blld_ALTA_INMUEBLE_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_COPROPIETARIO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_COPROPIETARIO, CID_TIPO_PERSONA, V_NOMBRE, V_RFC, NID_PAIS, CID_ENTIDAD_FEDERATIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
