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
    public partial class blld_PATRIMONIO_DEPENDIENTES : bll_PATRIMONIO_DEPENDIENTES
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_PATRIMONIO_DEPENDIENTES.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_PATRIMONIO_DEPENDIENTES.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DEPENDIENTE
        //        {
        //          get { return datos_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE; }
        //        }


        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_TIPO_DEPENDIENTE => datos_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE; 

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_NOMBRE
        {
            get
            {
                if (String.IsNullOrEmpty(datos_PATRIMONIO_DEPENDIENTES.E_NOMBRE))
                    return String.Empty;
               return DesEncripta(datos_PATRIMONIO_DEPENDIENTES.E_NOMBRE);
            }
           
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_PRIMER_A
        {
            get
            {
                if (String.IsNullOrEmpty(datos_PATRIMONIO_DEPENDIENTES.E_PRIMER_A))
                    return String.Empty;
                return DesEncripta(datos_PATRIMONIO_DEPENDIENTES.E_PRIMER_A);
            }
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_SEGUNDO_A
        {
            get
            {
                if (String.IsNullOrEmpty(datos_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A))
                    return String.Empty;
                return DesEncripta(datos_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A);
            }
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public DateTime F_NACIMIENTO => datos_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO;

        [StringLength(13)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        new public String E_RFC => datos_PATRIMONIO_DEPENDIENTES.E_RFC; 

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Boolean L_DEPENDE_ECO => datos_PATRIMONIO_DEPENDIENTES.L_DEPENDE_ECO; 

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [DisplayName("")]
        new public String V_DOMICILIO => datos_PATRIMONIO_DEPENDIENTES.V_DOMICILIO; 

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Boolean L_ACTIVO => datos_PATRIMONIO_DEPENDIENTES.L_ACTIVO; 


        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
