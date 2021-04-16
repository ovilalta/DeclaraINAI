using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public partial class blld_MODIFICACION_GASTO : bll_MODIFICACION_GASTO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_GASTO()
        : base()
        {
        }

        public blld_MODIFICACION_GASTO(MODELDeclara_V2.MODIFICACION_GASTO MODIFICACION_GASTO)
        : base(MODIFICACION_GASTO)
        {
        }

        public  blld_MODIFICACION_GASTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_GASTO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_GASTO)
        {
        }

        public blld_MODIFICACION_GASTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_GASTO,Int32 NID_TIPO_GASTO, String V_GASTO, Decimal M_GASTO, Boolean L_AUTOGENERADO, System.Nullable<Int32> NID_PATRIMONIO_ASC)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_GASTO, NID_TIPO_GASTO, V_GASTO, M_GASTO, L_AUTOGENERADO, NID_PATRIMONIO_ASC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
