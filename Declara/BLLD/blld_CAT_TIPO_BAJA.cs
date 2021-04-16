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
    public partial class blld_CAT_TIPO_BAJA : bll_CAT_TIPO_BAJA
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_BAJA()
        : base()
        {
        }

        public blld_CAT_TIPO_BAJA(MODELDeclara_V2.CAT_TIPO_BAJA CAT_TIPO_BAJA)
        : base(CAT_TIPO_BAJA)
        {
        }

        public  blld_CAT_TIPO_BAJA(Int32 NID_TIPO_BAJA)
        : base(NID_TIPO_BAJA)
        {
        }

        public blld_CAT_TIPO_BAJA(Int32 NID_TIPO_BAJA, String V_TIPO_BAJA)
        : base(NID_TIPO_BAJA, V_TIPO_BAJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
