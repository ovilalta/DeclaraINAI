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
    public partial class blld_PATRIMONIO_INMUEBLE_ADEUDO : bll_PATRIMONIO_INMUEBLE_ADEUDO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_PATRIMONIO_INMUEBLE_ADEUDO()
        : base()
        {
        }

        public blld_PATRIMONIO_INMUEBLE_ADEUDO(MODELDeclara_V2.PATRIMONIO_INMUEBLE_ADEUDO PATRIMONIO_INMUEBLE_ADEUDO)
        : base(PATRIMONIO_INMUEBLE_ADEUDO)
        {
        }

        public  blld_PATRIMONIO_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO)
        {
        }

        public blld_PATRIMONIO_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO, Boolean L_DIF)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
