using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_DEPENDIENTES_PRIVADO : bll_DECLARACION_DEPENDIENTES_PRIVADO
    {

        #region *** Propiedades ***
        #endregion


        #region *** Constructores ***
        public blld_DECLARACION_DEPENDIENTES_PRIVADO() : base() { }
        public blld_DECLARACION_DEPENDIENTES_PRIVADO(MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO DECLARACION_DEPENDIENTES_PRIVADO) : base(DECLARACION_DEPENDIENTES_PRIVADO) { }
        public blld_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE) : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE) { }

//        public blld_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, String V_NOMBRE, String V_CARGO, String V_RFC, DateTime F_INGRESO, Int32 NID_SECTOR, Decimal M_SALARIO_MENSUAL, Boolean L_PROVEEDOR)
//        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, V_NOMBRE, V_CARGO, V_RFC, F_INGRESO, NID_SECTOR, M_SALARIO_MENSUAL, L_PROVEEDOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException) { }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
