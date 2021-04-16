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
    public partial class blld_CAT_TIPO_INVERSION : bll_CAT_TIPO_INVERSION
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_INVERSION()
        : base()
        {
        }

        public blld_CAT_TIPO_INVERSION(MODELDeclara_V2.CAT_TIPO_INVERSION CAT_TIPO_INVERSION)
        : base(CAT_TIPO_INVERSION)
        {
        }

        public  blld_CAT_TIPO_INVERSION(Int32 NID_TIPO_INVERSION)
        : base(NID_TIPO_INVERSION)
        {
        }

        public blld_CAT_TIPO_INVERSION(Int32 NID_TIPO_INVERSION, String V_TIPO_INVERSION, Boolean L_ACTIVO)
        : base(NID_TIPO_INVERSION, V_TIPO_INVERSION,L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
