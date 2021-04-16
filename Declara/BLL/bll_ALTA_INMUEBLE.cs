using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public  class bll_ALTA_INMUEBLE : _bllSistema
    {

        internal dald_ALTA_INMUEBLE datos_ALTA_INMUEBLE;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_ALTA_INMUEBLE.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_ALTA_INMUEBLE.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_ALTA_INMUEBLE.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_ALTA_INMUEBLE.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ I N M U E B L E es requerido ")]
        [DisplayName("I D_ I N M U E B L E")]
        public Int32 NID_INMUEBLE => datos_ALTA_INMUEBLE.NID_INMUEBLE;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O es requerido ")]
        [DisplayName("I D_ T I P O")]
        public Int32 NID_TIPO
        {
          get => datos_ALTA_INMUEBLE.NID_TIPO;
          set => datos_ALTA_INMUEBLE.NID_TIPO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo A D Q U I S I C I O N es requerido ")]
        [DisplayName("A D Q U I S I C I O N")]
        public DateTime F_ADQUISICION
        {
          get => datos_ALTA_INMUEBLE.F_ADQUISICION;
          set => datos_ALTA_INMUEBLE.F_ADQUISICION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ U S O es requerido ")]
        [DisplayName("I D_ U S O")]
        public Int32 NID_USO
        {
          get => datos_ALTA_INMUEBLE.NID_USO;
          set => datos_ALTA_INMUEBLE.NID_USO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo U B I C A C I O N es requerido ")]
        [DisplayName("U B I C A C I O N")]
        public String E_UBICACION
        {
          get => datos_ALTA_INMUEBLE.E_UBICACION;
          set => datos_ALTA_INMUEBLE.E_UBICACION = value;
        }

        //[Range(-79228162514264337593543950335,79228162514264337593543950335, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression(@"^\d+\.\d{0,4}$")]
        [Required(ErrorMessage = "El campo T E R R E N O es requerido ")]
        [DisplayName("T E R R E N O")]
        public Decimal N_TERRENO
        {
          get => datos_ALTA_INMUEBLE.N_TERRENO;
          set => datos_ALTA_INMUEBLE.N_TERRENO = value;
        }

        //[Range(-79228162514264337593543950335,79228162514264337593543950335, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression(@"^\d+\.\d{0,4}$")]
        [Required(ErrorMessage = "El campo C O N S T R U C C I O N es requerido ")]
        [DisplayName("C O N S T R U C C I O N")]
        public Decimal N_CONSTRUCCION
        {
          get => datos_ALTA_INMUEBLE.N_CONSTRUCCION;
          set => datos_ALTA_INMUEBLE.N_CONSTRUCCION = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo V A L O R_ I N M U E B L E es requerido ")]
        [DisplayName("V A L O R_ I N M U E B L E")]
        public Decimal M_VALOR_INMUEBLE
        {
          get => datos_ALTA_INMUEBLE.M_VALOR_INMUEBLE;
          set => datos_ALTA_INMUEBLE.M_VALOR_INMUEBLE = value;
        }

        public String V_TIPO_MONEDA
        {
            get => datos_ALTA_INMUEBLE.V_TIPO_MONEDA;
            set => datos_ALTA_INMUEBLE.V_TIPO_MONEDA = value;
        }

        [Range(0,100, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Required(ErrorMessage = "El campo P O R C E N T A J E es requerido ")]
        [DisplayName("P O R C E N T A J E")]

        public Decimal N_PORCENTAJE_DECLARANTE
        {
            get => datos_ALTA_INMUEBLE.N_PORCENTAJE_DECLARANTE;
            set => datos_ALTA_INMUEBLE.N_PORCENTAJE_DECLARANTE = value;
        }

        public String E_REGISTRO_PUBLICO_PROPIEDAD
        {
            get => datos_ALTA_INMUEBLE.E_REGISTRO_PUBLICO_PROPIEDAD;
            set => datos_ALTA_INMUEBLE.E_REGISTRO_PUBLICO_PROPIEDAD = value;
        }
        public String E_NOMBRE_TRANSMISOR
        {
            get => datos_ALTA_INMUEBLE.E_NOMBRE_TRANSMISOR;
            set => datos_ALTA_INMUEBLE.E_NOMBRE_TRANSMISOR = value;
        }
        public String E_RFC_TRANSMISOR
        {
            get => datos_ALTA_INMUEBLE.E_RFC_TRANSMISOR;
            set => datos_ALTA_INMUEBLE.E_RFC_TRANSMISOR = value;
        }

        public String CID_TIPO_PERSONA_TRANSMISOR
        {
            get => datos_ALTA_INMUEBLE.CID_TIPO_PERSONA_TRANSMISOR;
            set => datos_ALTA_INMUEBLE.CID_TIPO_PERSONA_TRANSMISOR = value;
        }

        public Int32 NID_VALOR_ADQUISICION
        {
            get => datos_ALTA_INMUEBLE.NID_VALOR_ADQUISICION;
            set => datos_ALTA_INMUEBLE.NID_VALOR_ADQUISICION = value;
        }

        public Int32 NID_RELACION_TRANSMISOR
        {
            get => datos_ALTA_INMUEBLE.NID_RELACION_TRANSMISOR;
            set => datos_ALTA_INMUEBLE.NID_RELACION_TRANSMISOR = value;
        }

        public System.Nullable<Int32> NID_FORMA_ADQUISICION
        {
            get => datos_ALTA_INMUEBLE.NID_FORMA_ADQUISICION;
            set => datos_ALTA_INMUEBLE.NID_FORMA_ADQUISICION = value;
        }

        public System.Nullable<Int32> NID_FORMA_PAGO
        {
            get => datos_ALTA_INMUEBLE.NID_FORMA_PAGO;
            set => datos_ALTA_INMUEBLE.NID_FORMA_PAGO = value;
        }

        public String E_OBSERVACIONES
        {
            get => datos_ALTA_INMUEBLE.E_OBSERVACIONES;
            set => datos_ALTA_INMUEBLE.E_OBSERVACIONES = value;
        }


        //public String E_OBSERVACIONES_MARCADO
        //{
        //    get => datos_ALTA_INMUEBLE.E_OBSERVACIONES_MARCADO;
        //    set => datos_ALTA_INMUEBLE.E_OBSERVACIONES_MARCADO = value;
        //}
        //public String V_OBSERVACIONES_TESTADO
        //{
        //    get => datos_ALTA_INMUEBLE.V_OBSERVACIONES_TESTADO;
        //    set => datos_ALTA_INMUEBLE.V_OBSERVACIONES_TESTADO = value;
        //}



        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO
        {
          get => datos_ALTA_INMUEBLE.NID_PATRIMONIO;
          set => datos_ALTA_INMUEBLE.NID_PATRIMONIO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_INMUEBLE.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_INMUEBLE() => datos_ALTA_INMUEBLE = new dald_ALTA_INMUEBLE();

        public bll_ALTA_INMUEBLE(MODELDeclara_V2.ALTA_INMUEBLE ALTA_INMUEBLE) => datos_ALTA_INMUEBLE = new dald_ALTA_INMUEBLE(ALTA_INMUEBLE);

        public bll_ALTA_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE) => datos_ALTA_INMUEBLE = new dald_ALTA_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE);

        public bll_ALTA_INMUEBLE(
              String VID_NOMBRE
            , String VID_FECHA
            , String VID_HOMOCLAVE
            , Int32 NID_DECLARACION
            , Int32 NID_INMUEBLE
            , Int32 NID_TIPO
            , DateTime F_ADQUISICION
            , Int32 NID_USO
            , String E_UBICACION
            , Decimal N_TERRENO
            , Decimal N_CONSTRUCCION
            , Decimal M_VALOR_INMUEBLE
            , Int32 NID_PATRIMONIO
            , Decimal N_PORCENTAJE_DECLARANTE
            , String CID_TIPO_PERSONA_TRANSMISOR
            , String E_NOMBRE_TRANSMISOR
            , String E_RFC_TRANSMISOR
            , Int32 NID_RELACION_TRANSMISOR
            , String V_TIPO_MONEDA
            , String E_REGISTRO_PUBLICO_PROPIEDAD
            , Int32 NID_VALOR_ADQUISICION
            , Int32 NID_FORMA_ADQUISICION
            , Int32 NID_FORMA_PAGO
            , String E_OBSERVACIONES
            , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
            ) => datos_ALTA_INMUEBLE = new dald_ALTA_INMUEBLE(VID_NOMBRE
                , VID_FECHA
                , VID_HOMOCLAVE
                , NID_DECLARACION
                , NID_INMUEBLE
                , NID_TIPO
                , F_ADQUISICION
                , NID_USO
                , E_UBICACION
                , N_TERRENO
                , N_CONSTRUCCION
                , M_VALOR_INMUEBLE
                , NID_PATRIMONIO
                , N_PORCENTAJE_DECLARANTE
                , CID_TIPO_PERSONA_TRANSMISOR
                , E_NOMBRE_TRANSMISOR
                , E_RFC_TRANSMISOR
                , NID_RELACION_TRANSMISOR
                , V_TIPO_MONEDA
                , E_REGISTRO_PUBLICO_PROPIEDAD
                , NID_VALOR_ADQUISICION
                , NID_FORMA_ADQUISICION
                , NID_FORMA_PAGO
                , E_OBSERVACIONES
                , lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA_INMUEBLE.update();
        }

        public void delete()
        {
            datos_ALTA_INMUEBLE.delete();
        }

        public void reload()
        {
            datos_ALTA_INMUEBLE.reload();
        }

     #endregion

    }
}
