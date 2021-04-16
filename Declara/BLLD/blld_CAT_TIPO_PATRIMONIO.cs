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
    public partial class blld_CAT_TIPO_PATRIMONIO : bll_CAT_TIPO_PATRIMONIO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_PATRIMONIO()
        : base()
        {
        }

        public blld_CAT_TIPO_PATRIMONIO(MODELDeclara_V2.CAT_TIPO_PATRIMONIO CAT_TIPO_PATRIMONIO)
        : base(CAT_TIPO_PATRIMONIO)
        {
        }

        public  blld_CAT_TIPO_PATRIMONIO(Int32 NID_TIPO)
        : base(NID_TIPO)
        {
        }

        public blld_CAT_TIPO_PATRIMONIO(Int32 NID_TIPO, String V_TIPO, Int32 C_NATURALEZA)
        : base(NID_TIPO, V_TIPO, C_NATURALEZA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
