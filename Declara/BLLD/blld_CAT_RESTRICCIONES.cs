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
    public partial class blld_CAT_RESTRICCIONES : bll_CAT_RESTRICCIONES
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_RESTRICCIONES()
        : base()
        {
        }

        public blld_CAT_RESTRICCIONES(MODELDeclara_V2.CAT_RESTRICCIONES CAT_RESTRICCIONES)
        : base(CAT_RESTRICCIONES)
        {
        }

        public  blld_CAT_RESTRICCIONES(Int32 NID_RESTRICCION)
        : base(NID_RESTRICCION)
        {
        }

        public blld_CAT_RESTRICCIONES(Int32 NID_RESTRICCION, String V_RESTRICCION, Boolean L_VIGENTE)
        : base(NID_RESTRICCION, V_RESTRICCION, L_VIGENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
