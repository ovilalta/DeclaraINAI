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
    public partial class blld_PATRIMONIO_INVERSION : bll_PATRIMONIO_INVERSION
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.NID_PATRIMONIO; }
        //        }


        //        public Int32 NID_TIPO_INVERSION
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.NID_TIPO_INVERSION; }
        //          set { datos_PATRIMONIO_INVERSION.NID_TIPO_INVERSION = value; }
        //        }


        //        public Int32 NID_SUBTIPO_INVERSION
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSION; }
        //          set { datos_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSION = value; }
        //        }


        //        public Int32 NID_INSTITUCION
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.NID_INSTITUCION; }
        //          set { datos_PATRIMONIO_INVERSION.NID_INSTITUCION = value; }
        //        }


        //        public String E_CUENTA
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.E_CUENTA; }
        //          set { datos_PATRIMONIO_INVERSION.E_CUENTA = value; }
        //        }


        //        public String V_CUENTA_CORTO
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.V_CUENTA_CORTO; }
        //          set { datos_PATRIMONIO_INVERSION.V_CUENTA_CORTO = value; }
        //        }


        //        public String V_OTRO
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.V_OTRO; }
        //          set { datos_PATRIMONIO_INVERSION.V_OTRO = value; }
        //        }


        //        public Decimal M_SALDO
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.M_SALDO; }
        //          set { datos_PATRIMONIO_INVERSION.M_SALDO = value; }
        //        }


        //        public Int32 NID_PAIS
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.NID_PAIS; }
        //          set { datos_PATRIMONIO_INVERSION.NID_PAIS = value; }
        //        }


        //        public String CID_ENTIDAD_FEDERATIVA
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVA; }
        //          set { datos_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVA = value; }
        //        }


        //        public String V_LUGAR
        //        {
        //          get { return datos_PATRIMONIO_INVERSION.V_LUGAR; }
        //          set { datos_PATRIMONIO_INVERSION.V_LUGAR = value; }
        //        }


        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_TIPO_INVERSION => datos_PATRIMONIO_INVERSION.NID_TIPO_INVERSION; 

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_SUBTIPO_INVERSION => datos_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSION; 

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public Int32 NID_INSTITUCION  => datos_PATRIMONIO_INVERSION.NID_INSTITUCION; 

        [StringLength(1023)]
        [DataType(DataType.MultilineText)]
        [DisplayName("")]
        new public String E_CUENTA
        {
            get
            {
                if (String.IsNullOrEmpty(datos_PATRIMONIO_INVERSION.E_CUENTA))
                    return String.Empty;
               return DesEncripta(datos_PATRIMONIO_INVERSION.E_CUENTA);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_PATRIMONIO_INVERSION.E_CUENTA = String.Empty;
                else
                datos_PATRIMONIO_INVERSION.E_CUENTA = Encripta(value);
            }
        }

        [StringLength(5)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        new public String V_CUENTA_CORTO => datos_PATRIMONIO_INVERSION.V_CUENTA_CORTO; 

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        public String V_OTRO
        {
            get => datos_PATRIMONIO_INVERSION.V_OTRO;
            set => datos_PATRIMONIO_INVERSION.V_OTRO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_SALDO
        {
            get => datos_PATRIMONIO_INVERSION.M_SALDO;
            set => datos_PATRIMONIO_INVERSION.M_SALDO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS
        {
            get => datos_PATRIMONIO_INVERSION.NID_PAIS;
            set => datos_PATRIMONIO_INVERSION.NID_PAIS = value;
        }

        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVA;
            set => datos_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVA = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        public String V_LUGAR
        {
            get => datos_PATRIMONIO_INVERSION.V_LUGAR;
            set => datos_PATRIMONIO_INVERSION.V_LUGAR = value;
        }


        public String V_PAIS => datos_PATRIMONIO_INVERSION.V_PAIS;

        public String V_TIPO_INVERSION => datos_PATRIMONIO_INVERSION.V_TIPO_INVERSION;


     #endregion


     #region *** Constructores (Extended) ***


     #endregion


     #region *** Metodos (Extended) ***


     #endregion

    }
}
