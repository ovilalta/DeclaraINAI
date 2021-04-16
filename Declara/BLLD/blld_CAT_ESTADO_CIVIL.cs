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
    public partial class blld_CAT_ESTADO_CIVIL : bll_CAT_ESTADO_CIVIL
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_ESTADO_CIVIL()
        : base()
        {
        }

        public blld_CAT_ESTADO_CIVIL(MODELDeclara_V2.CAT_ESTADO_CIVIL CAT_ESTADO_CIVIL)
        : base(CAT_ESTADO_CIVIL)
        {
        }

        public  blld_CAT_ESTADO_CIVIL(Int32 NID_ESTADO_CIVIL)
        : base(NID_ESTADO_CIVIL)
        {
        }

        public blld_CAT_ESTADO_CIVIL(Int32 NID_ESTADO_CIVIL, String V_ESTADO_CIVIL)
        : base(NID_ESTADO_CIVIL, V_ESTADO_CIVIL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
