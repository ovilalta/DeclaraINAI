using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_MUEBLE_COPROPIETARIO : bll_ALTA_MUEBLE_COPROPIETARIO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        //private blld_ALTA_MUEBLE_COPROPIETARIO() : base() { }
        public blld_ALTA_MUEBLE_COPROPIETARIO(MODELDeclara_V2.ALTA_MUEBLE_COPROPIETARIO ALTA_MUEBLE_COPROPIETARIO) : base(ALTA_MUEBLE_COPROPIETARIO) { }
        public blld_ALTA_MUEBLE_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE, Int32 NID_COPROPIETARIO) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_COPROPIETARIO) { }

//        public blld_ALTA_MUEBLE_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE, Int32 NID_COPROPIETARIO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE, NID_COPROPIETARIO, CID_TIPO_PERSONA, V_NOMBRE, V_RFC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
