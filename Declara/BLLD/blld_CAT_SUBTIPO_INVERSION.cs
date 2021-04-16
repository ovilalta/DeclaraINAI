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
    public partial class blld_CAT_SUBTIPO_INVERSION : bll_CAT_SUBTIPO_INVERSION
    {

     #region *** Atributos ***


        #region * CAT_TIPO_INVERSION *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_INVERSION => datos_CAT_SUBTIPO_INVERSION.V_TIPO_INVERSION;

        #endregion * CAT_TIPO_INVERSION *



     #endregion


     #region *** Constructores ***

        private blld_CAT_SUBTIPO_INVERSION()
        : base()
        {
        }

        public blld_CAT_SUBTIPO_INVERSION(MODELDeclara_V2.CAT_SUBTIPO_INVERSION CAT_SUBTIPO_INVERSION)
        : base(CAT_SUBTIPO_INVERSION)
        {
        }

        public  blld_CAT_SUBTIPO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION)
        : base(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION)
        {
        }

        public blld_CAT_SUBTIPO_INVERSION(Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, String V_SUBTIPO_INVERSION, Boolean L_ACTIVO)
        : base(NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, V_SUBTIPO_INVERSION,L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
