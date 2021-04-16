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
    public partial class blld_ALTA_ADEUDO_TITULAR : bll_ALTA_ADEUDO_TITULAR
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_ALTA_ADEUDO_TITULAR()
        : base()
        {
        }

        public blld_ALTA_ADEUDO_TITULAR(MODELDeclara_V2.ALTA_ADEUDO_TITULAR ALTA_ADEUDO_TITULAR)
        : base(ALTA_ADEUDO_TITULAR)
        {
        }

        public  blld_ALTA_ADEUDO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_DEPENDIENTE)
        {
        }

        public blld_ALTA_ADEUDO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_DEPENDIENTE, Boolean L_DIF)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_DEPENDIENTE, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
