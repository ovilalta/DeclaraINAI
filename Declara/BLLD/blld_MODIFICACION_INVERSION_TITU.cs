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
    public partial class blld_MODIFICACION_INVERSION_TITU : bll_MODIFICACION_INVERSION_TITU
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_INVERSION_TITU()
        : base()
        {
        }

        public blld_MODIFICACION_INVERSION_TITU(MODELDeclara_V2.MODIFICACION_INVERSION_TITU MODIFICACION_INVERSION_TITU)
        : base(MODIFICACION_INVERSION_TITU)
        {
        }

        public  blld_MODIFICACION_INVERSION_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE)
        {
        }

        public blld_MODIFICACION_INVERSION_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Boolean L_DIF)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
