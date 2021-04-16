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
    public partial class blld_PATRIMONIO_ADEUDO : bll_PATRIMONIO_ADEUDO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_PATRIMONIO_ADEUDO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_PATRIMONIO_ADEUDO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_PATRIMONIO_ADEUDO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_PATRIMONIO_ADEUDO.NID_PATRIMONIO; }
        //        }


        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_PAIS => datos_PATRIMONIO_ADEUDO.NID_PAIS; 

        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String CID_ENTIDAD_FEDERATIVA => datos_PATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVA; 

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        new public String V_LUGAR  => datos_PATRIMONIO_ADEUDO.V_LUGAR; 

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_INSTITUCION  => datos_PATRIMONIO_ADEUDO.NID_INSTITUCION; 

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        new public String V_OTRA => datos_PATRIMONIO_ADEUDO.V_OTRA; 

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_TIPO_ADEUDO => datos_PATRIMONIO_ADEUDO.NID_TIPO_ADEUDO; 

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Decimal M_ORIGINAL  => datos_PATRIMONIO_ADEUDO.M_ORIGINAL; 

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Decimal M_SALDO => datos_PATRIMONIO_ADEUDO.M_SALDO; 

        [StringLength(1023)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_CUENTA
        {
            get
            {
                if (String.IsNullOrEmpty(datos_PATRIMONIO_ADEUDO.E_CUENTA))
                    return String.Empty;
                return DesEncripta(datos_PATRIMONIO_ADEUDO.E_CUENTA);
            }
        }

        public DateTime F_ADEUDO => datos_PATRIMONIO_ADEUDO.F_ADEUDO;

        public String V_PAIS => datos_PATRIMONIO_ADEUDO.V_PAIS;

        #endregion


        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
