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
    public partial class blld_PATRIMONIO_MUEBLE : bll_PATRIMONIO_MUEBLE
    {

     #region *** Atributos ***


        #region * CAT_TIPO_MUEBLE *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO => datos_PATRIMONIO_MUEBLE.V_TIPO;

        #endregion * CAT_TIPO_MUEBLE *



     #endregion


     #region *** Constructores ***

        private blld_PATRIMONIO_MUEBLE()
        : base()
        {
        }

        public blld_PATRIMONIO_MUEBLE(MODELDeclara_V2.PATRIMONIO_MUEBLE PATRIMONIO_MUEBLE)
        : base(PATRIMONIO_MUEBLE)
        {
        }

        public  blld_PATRIMONIO_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO)
        {
        }

        public blld_PATRIMONIO_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_TIPO, String E_ESPECIFICACION, Int64 M_VALOR,DateTime F_ADQUISICION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, E_ESPECIFICACION, M_VALOR, F_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
