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
    public partial class blld_CAT_TIPO_INMUEBLE : bll_CAT_TIPO_INMUEBLE
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_INMUEBLE()
        : base()
        {
        }

        public blld_CAT_TIPO_INMUEBLE(MODELDeclara_V2.CAT_TIPO_INMUEBLE CAT_TIPO_INMUEBLE)
        : base(CAT_TIPO_INMUEBLE)
        {
        }

        public  blld_CAT_TIPO_INMUEBLE(Int32 NID_TIPO)
        : base(NID_TIPO)
        {
        }

        public blld_CAT_TIPO_INMUEBLE(Int32 NID_TIPO, String V_TIPO, Boolean L_ACTIVO)
        : base(NID_TIPO, V_TIPO,L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
