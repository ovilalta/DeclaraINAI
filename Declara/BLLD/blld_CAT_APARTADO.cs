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
    public partial class blld_CAT_APARTADO : bll_CAT_APARTADO
    {

     #region *** Atributos ***


    


     #endregion


     #region *** Constructores ***

        private blld_CAT_APARTADO()
        : base()
        {
        }

        public blld_CAT_APARTADO(MODELDeclara_V2.CAT_APARTADO CAT_APARTADO)
        : base(CAT_APARTADO)
        {
        }

        public  blld_CAT_APARTADO(Int32 NID_APARTADO)
        : base(NID_APARTADO)
        {
        }

        //public blld_CAT_APARTADO(Int32 NID_APARTADO, String V_APARTADO, System.Nullable<Int32> NID_APARTADO_SUPERIOR, System.Nullable<Int32> N_APARTADO)
        //: base(NID_APARTADO, V_APARTADO, NID_APARTADO_SUPERIOR, N_APARTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


     #endregion


     #region *** Metodos ***

      
    


     #endregion

    }
}
