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
    public partial class blld_PATRIMONIO_INMUEBLE : bll_PATRIMONIO_INMUEBLE
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_PATRIMONIO_INMUEBLE.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_PATRIMONIO_INMUEBLE.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_PATRIMONIO_INMUEBLE.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_PATRIMONIO_INMUEBLE.NID_PATRIMONIO; }
        //        }


        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_TIPO => datos_PATRIMONIO_INMUEBLE.NID_TIPO; 

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public DateTime F_ADQUISICION => datos_PATRIMONIO_INMUEBLE.F_ADQUISICION; 

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_USO => datos_PATRIMONIO_INMUEBLE.NID_USO; 

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_UBICACION
        {
            get
            {
                if (String.IsNullOrEmpty(datos_PATRIMONIO_INMUEBLE.E_UBICACION))
                    return String.Empty;
                return DesEncripta(datos_PATRIMONIO_INMUEBLE.E_UBICACION);
            }
        }

        [RegularExpression(@"^\d+\.\d{0,4}$")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Decimal N_TERRENO => datos_PATRIMONIO_INMUEBLE.N_TERRENO; 


        [RegularExpression(@"^\d+\.\d{0,4}$")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Decimal N_CONSTRUCCION => datos_PATRIMONIO_INMUEBLE.N_CONSTRUCCION; 

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Decimal M_VALOR_INMUEBLE  => datos_PATRIMONIO_INMUEBLE.M_VALOR_INMUEBLE; 


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
