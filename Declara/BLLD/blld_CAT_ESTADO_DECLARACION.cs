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
    public partial class blld_CAT_ESTADO_DECLARACION : bll_CAT_ESTADO_DECLARACION
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_ESTADO_DECLARACION()
        : base()
        {
        }

        public blld_CAT_ESTADO_DECLARACION(MODELDeclara_V2.CAT_ESTADO_DECLARACION CAT_ESTADO_DECLARACION)
        : base(CAT_ESTADO_DECLARACION)
        {
        }

        public  blld_CAT_ESTADO_DECLARACION(Int32 NID_ESTADO)
        : base(NID_ESTADO)
        {
        }

        public blld_CAT_ESTADO_DECLARACION(Int32 NID_ESTADO, String V_ESTADO)
        : base(NID_ESTADO, V_ESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
