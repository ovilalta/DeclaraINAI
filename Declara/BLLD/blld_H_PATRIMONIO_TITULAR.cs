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
    public partial class blld_H_PATRIMONIO_TITULAR : bll_H_PATRIMONIO_TITULAR
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_H_PATRIMONIO_TITULAR()
        : base()
        {
        }

        public blld_H_PATRIMONIO_TITULAR(MODELDeclara_V2.H_PATRIMONIO_TITULAR H_PATRIMONIO_TITULAR)
        : base(H_PATRIMONIO_TITULAR)
        {
        }

        public  blld_H_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Int32 NID_HISTORICO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO)
        {
        }

        public blld_H_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Int32 NID_HISTORICO, Boolean L_DIF)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
