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
    public partial class blld_CAT_TIPO_ADEUDO : bll_CAT_TIPO_ADEUDO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_ADEUDO()
        : base()
        {
        }

        public blld_CAT_TIPO_ADEUDO(MODELDeclara_V2.CAT_TIPO_ADEUDO CAT_TIPO_ADEUDO)
        : base(CAT_TIPO_ADEUDO)
        {
        }

        public  blld_CAT_TIPO_ADEUDO(Int32 NID_TIPO_ADEUDO)
        : base(NID_TIPO_ADEUDO)
        {
        }

        public blld_CAT_TIPO_ADEUDO(Int32 NID_TIPO_ADEUDO, String V_TIPO_ADEUDO)
        : base(NID_TIPO_ADEUDO, V_TIPO_ADEUDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
