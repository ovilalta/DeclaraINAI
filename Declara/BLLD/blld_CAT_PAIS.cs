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
    public partial class blld_CAT_PAIS : bll_CAT_PAIS
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_PAIS()
        : base()
        {
        }

        public blld_CAT_PAIS(MODELDeclara_V2.CAT_PAIS CAT_PAIS)
        : base(CAT_PAIS)
        {
        }

        public  blld_CAT_PAIS(Int32 NID_PAIS)
        : base(NID_PAIS)
        {
        }

        public blld_CAT_PAIS(Int32 NID_PAIS, String V_PAIS, String V_NACIONALIDAD_M, String V_NACIONALIDAD_F)
        : base(NID_PAIS, V_PAIS, V_NACIONALIDAD_M, V_NACIONALIDAD_F, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
