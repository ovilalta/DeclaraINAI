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
    public partial class blld_CAT_DENOMINACION : bll_CAT_DENOMINACION
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_DENOMINACION()
        : base()
        {
        }

        public blld_CAT_DENOMINACION(MODELDeclara_V2.CAT_DENOMINACION CAT_DENOMINACION)
        : base(CAT_DENOMINACION)
        {
        }

        public  blld_CAT_DENOMINACION(Int32 NID_DENOMINACION)
        : base(NID_DENOMINACION)
        {
        }

        public blld_CAT_DENOMINACION(Int32 NID_DENOMINACION, String V_DENOMINACION)
        : base(NID_DENOMINACION, V_DENOMINACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
