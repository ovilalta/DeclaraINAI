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
    public partial class blld_CAT_TIPO_DEPENDIENTES : bll_CAT_TIPO_DEPENDIENTES
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_DEPENDIENTES()
        : base()
        {
        }

        public blld_CAT_TIPO_DEPENDIENTES(MODELDeclara_V2.CAT_TIPO_DEPENDIENTES CAT_TIPO_DEPENDIENTES)
        : base(CAT_TIPO_DEPENDIENTES)
        {
        }

        public  blld_CAT_TIPO_DEPENDIENTES(Int32 NID_TIPO_DEPENDIENTE)
        : base(NID_TIPO_DEPENDIENTE)
        {
        }

        public blld_CAT_TIPO_DEPENDIENTES(Int32 NID_TIPO_DEPENDIENTE, String V_TIPO_DEPENDIENTE)
        : base(NID_TIPO_DEPENDIENTE, V_TIPO_DEPENDIENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
