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
    public partial class blld_ALTA_INMUEBLE_ADEUDO : bll_ALTA_INMUEBLE_ADEUDO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_ALTA_INMUEBLE_ADEUDO()
        : base()
        {
        }

        public blld_ALTA_INMUEBLE_ADEUDO(MODELDeclara_V2.ALTA_INMUEBLE_ADEUDO ALTA_INMUEBLE_ADEUDO)
        : base(ALTA_INMUEBLE_ADEUDO)
        {
        }

        public  blld_ALTA_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_ADEUDO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_ADEUDO)
        {
        }

        public blld_ALTA_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_ADEUDO, System.Nullable<Boolean> L_DIF)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_ADEUDO, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
