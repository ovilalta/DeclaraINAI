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
    public partial class blld_CAT_USO_INMUEBLE : bll_CAT_USO_INMUEBLE
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_USO_INMUEBLE()
        : base()
        {
        }

        public blld_CAT_USO_INMUEBLE(MODELDeclara_V2.CAT_USO_INMUEBLE CAT_USO_INMUEBLE)
        : base(CAT_USO_INMUEBLE)
        {
        }

        public  blld_CAT_USO_INMUEBLE(Int32 NID_USO)
        : base(NID_USO)
        {
        }

        public blld_CAT_USO_INMUEBLE(Int32 NID_USO, String V_USO, Boolean L_ACTIVO)
        : base(NID_USO, V_USO,L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
