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
    public partial class blld_CAT_TIPS : bll_CAT_TIPS
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPS()
        : base()
        {
        }

        public blld_CAT_TIPS(MODELDeclara_V2.CAT_TIPS CAT_TIPS)
        : base(CAT_TIPS)
        {
        }

        public  blld_CAT_TIPS(Int32 NID_TIP)
        : base(NID_TIP)
        {
        }

        public blld_CAT_TIPS(Int32 NID_TIP, String V_TIP)
        : base(NID_TIP, V_TIP, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
