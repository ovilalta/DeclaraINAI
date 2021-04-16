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
    public partial class blld_MODIFICACION_VEHICULO_ADEU : bll_MODIFICACION_VEHICULO_ADEU
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_VEHICULO_ADEU()
        : base()
        {
        }

        public blld_MODIFICACION_VEHICULO_ADEU(MODELDeclara_V2.MODIFICACION_VEHICULO_ADEU MODIFICACION_VEHICULO_ADEU)
        : base(MODIFICACION_VEHICULO_ADEU)
        {
        }

        public  blld_MODIFICACION_VEHICULO_ADEU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO)
        {
        }

        public blld_MODIFICACION_VEHICULO_ADEU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO, Boolean L_DIF)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
