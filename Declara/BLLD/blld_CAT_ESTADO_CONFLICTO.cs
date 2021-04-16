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
    public partial class blld_CAT_ESTADO_CONFLICTO : bll_CAT_ESTADO_CONFLICTO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_ESTADO_CONFLICTO()
        : base()
        {
        }

        public blld_CAT_ESTADO_CONFLICTO(MODELDeclara_V2.CAT_ESTADO_CONFLICTO CAT_ESTADO_CONFLICTO)
        : base(CAT_ESTADO_CONFLICTO)
        {
        }

        public  blld_CAT_ESTADO_CONFLICTO(Int32 NID_ESTADO_CONFLICTO)
        : base(NID_ESTADO_CONFLICTO)
        {
        }

        public blld_CAT_ESTADO_CONFLICTO(Int32 NID_ESTADO_CONFLICTO, String V_ESTADO_CONFLICTO)
        : base(NID_ESTADO_CONFLICTO, V_ESTADO_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
