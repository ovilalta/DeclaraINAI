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
    public partial class blld_DECLARACION_APARTADO : bll_DECLARACION_APARTADO
    {

     #region *** Atributos ***


        #region * CAT_APARTADO *


        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_APARTADO => datos_DECLARACION_APARTADO.V_APARTADO;


        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [DisplayName("")]
        public System.Nullable<Int32> NID_APARTADO_SUPERIOR => datos_DECLARACION_APARTADO.NID_APARTADO_SUPERIOR;


        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [DisplayName("")]
        public System.Nullable<Int32> N_APARTADO => datos_DECLARACION_APARTADO.N_APARTADO;

        #endregion * CAT_APARTADO *



     #endregion


     #region *** Constructores ***

        private blld_DECLARACION_APARTADO()
        : base()
        {
        }

        public blld_DECLARACION_APARTADO(MODELDeclara_V2.DECLARACION_APARTADO DECLARACION_APARTADO)
        : base(DECLARACION_APARTADO)
        {
        }

        public  blld_DECLARACION_APARTADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_APARTADO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO)
        {
        }

        public blld_DECLARACION_APARTADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_APARTADO, System.Nullable<Boolean> L_ESTADO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO, L_ESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
