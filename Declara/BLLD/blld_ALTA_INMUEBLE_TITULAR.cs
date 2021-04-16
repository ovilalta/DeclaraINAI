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
    public partial class blld_ALTA_INMUEBLE_TITULAR : bll_ALTA_INMUEBLE_TITULAR
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_ALTA_INMUEBLE_TITULAR()
        : base()
        {
        }

        public blld_ALTA_INMUEBLE_TITULAR(MODELDeclara_V2.ALTA_INMUEBLE_TITULAR ALTA_INMUEBLE_TITULAR)
        : base(ALTA_INMUEBLE_TITULAR)
        {
        }

        public  blld_ALTA_INMUEBLE_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_DEPENDIENTE)
        {
        }

        //public blld_ALTA_INMUEBLE_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_DEPENDIENTE, Boolean L_DIF)
        //: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_DEPENDIENTE, L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
