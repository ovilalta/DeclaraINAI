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
    public partial class blld_CAT_USO_VEHICULO : bll_CAT_USO_VEHICULO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_USO_VEHICULO()
        : base()
        {
        }

        public blld_CAT_USO_VEHICULO(MODELDeclara_V2.CAT_USO_VEHICULO CAT_USO_VEHICULO)
        : base(CAT_USO_VEHICULO)
        {
        }

        public  blld_CAT_USO_VEHICULO(Int32 NID_USO)
        : base(NID_USO)
        {
        }

        public blld_CAT_USO_VEHICULO(Int32 NID_USO, String V_USO, Boolean L_ACTIVO)
        : base(NID_USO, V_USO,L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
