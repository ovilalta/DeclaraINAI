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
// Extended
    public partial class blld_PATRIMONIO_MUEBLE : bll_PATRIMONIO_MUEBLE
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_PATRIMONIO_MUEBLE.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_PATRIMONIO_MUEBLE.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_PATRIMONIO_MUEBLE.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_PATRIMONIO_MUEBLE.NID_PATRIMONIO; }
        //        }


        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_TIPO  => datos_PATRIMONIO_MUEBLE.NID_TIPO; 

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_ESPECIFICACION
        {
            get
            {
                if (String.IsNullOrEmpty(datos_PATRIMONIO_MUEBLE.E_ESPECIFICACION))
                    return String.Empty;
              return DesEncripta(datos_PATRIMONIO_MUEBLE.E_ESPECIFICACION);
            }
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Decimal M_VALOR => datos_PATRIMONIO_MUEBLE.M_VALOR; 


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
