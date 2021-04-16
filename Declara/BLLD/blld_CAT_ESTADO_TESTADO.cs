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
    public partial class blld_CAT_ESTADO_TESTADO : bll_CAT_ESTADO_TESTADO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_ESTADO_TESTADO()
        : base()
        {
        }

        public blld_CAT_ESTADO_TESTADO(MODELDeclara_V2.CAT_ESTADO_TESTADO CAT_ESTADO_TESTADO)
        : base(CAT_ESTADO_TESTADO)
        {
        }

        public  blld_CAT_ESTADO_TESTADO(Int32 NID_ESTADO_TESTADO)
        : base(NID_ESTADO_TESTADO)
        {
        }

        public blld_CAT_ESTADO_TESTADO(Int32 NID_ESTADO_TESTADO, String V_ESTADO_TESTADO)
        : base(NID_ESTADO_TESTADO, V_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
