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
    public partial class blld_CAT_MARCA_VEHICULO : bll_CAT_MARCA_VEHICULO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_MARCA_VEHICULO()
        : base()
        {
        }

        public blld_CAT_MARCA_VEHICULO(MODELDeclara_V2.CAT_MARCA_VEHICULO CAT_MARCA_VEHICULO)
        : base(CAT_MARCA_VEHICULO)
        {
        }

        public  blld_CAT_MARCA_VEHICULO(Int32 NID_MARCA)
        : base(NID_MARCA)
        {
        }

        public blld_CAT_MARCA_VEHICULO(Int32 NID_MARCA, String V_MARCA)
        : base(NID_MARCA, V_MARCA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
