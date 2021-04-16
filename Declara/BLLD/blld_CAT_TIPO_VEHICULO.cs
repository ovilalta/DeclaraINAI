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
    public partial class blld_CAT_TIPO_VEHICULO : bll_CAT_TIPO_VEHICULO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_VEHICULO()
        : base()
        {
        }

        public blld_CAT_TIPO_VEHICULO(MODELDeclara_V2.CAT_TIPO_VEHICULO CAT_TIPO_VEHICULO)
        : base(CAT_TIPO_VEHICULO)
        {
        }

        public  blld_CAT_TIPO_VEHICULO(Int32 NID_TIPO_VEHICULO)
        : base(NID_TIPO_VEHICULO)
        {
        }

        public blld_CAT_TIPO_VEHICULO(Int32 NID_TIPO_VEHICULO, String V_TIPO_VEHICULO)
        : base(NID_TIPO_VEHICULO, V_TIPO_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
