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
    public partial class blld_CAT_TIPO_DECLARACION : bll_CAT_TIPO_DECLARACION
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_CAT_TIPO_DECLARACION()
        : base()
        {
        }

        public blld_CAT_TIPO_DECLARACION(MODELDeclara_V2.CAT_TIPO_DECLARACION CAT_TIPO_DECLARACION)
        : base(CAT_TIPO_DECLARACION)
        {
        }

        public  blld_CAT_TIPO_DECLARACION(Int32 NID_TIPO_DECLARACION)
        : base(NID_TIPO_DECLARACION)
        {
        }

        public blld_CAT_TIPO_DECLARACION(Int32 NID_TIPO_DECLARACION, String V_TIPO_DECLARACION)
        : base(NID_TIPO_DECLARACION, V_TIPO_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
