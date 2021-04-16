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
    public partial class blld_CAT_INST_FINANCIERA : bll_CAT_INST_FINANCIERA
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_INST_FINANCIERA()
        : base()
        {
        }

        public blld_CAT_INST_FINANCIERA(MODELDeclara_V2.CAT_INST_FINANCIERA CAT_INST_FINANCIERA)
        : base(CAT_INST_FINANCIERA)
        {
        }

        public  blld_CAT_INST_FINANCIERA(Int32 NID_INSTITUCION)
        : base(NID_INSTITUCION)
        {
        }

        public blld_CAT_INST_FINANCIERA(Int32 NID_INSTITUCION, String V_INSTITUCION, Boolean L_ACTIVO)
        : base(NID_INSTITUCION, V_INSTITUCION,L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
