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
    public partial class blld_CAT_TIPO_DOMICILIO : bll_CAT_TIPO_DOMICILIO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_DOMICILIO()
        : base()
        {
        }

        public blld_CAT_TIPO_DOMICILIO(MODELDeclara_V2.CAT_TIPO_DOMICILIO CAT_TIPO_DOMICILIO)
        : base(CAT_TIPO_DOMICILIO)
        {
        }

        public  blld_CAT_TIPO_DOMICILIO(Int32 NID_TIPO_DOMICILIO)
        : base(NID_TIPO_DOMICILIO)
        {
        }

        public blld_CAT_TIPO_DOMICILIO(Int32 NID_TIPO_DOMICILIO, String V_TIPO_DOMICILIO)
        : base(NID_TIPO_DOMICILIO, V_TIPO_DOMICILIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
