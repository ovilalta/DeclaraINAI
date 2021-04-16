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
    public  class bll_ALTA_MUEBLE : _bllSistema
    {

        internal dald_ALTA_MUEBLE datos_ALTA_MUEBLE;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_ALTA_MUEBLE.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_ALTA_MUEBLE.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_ALTA_MUEBLE.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_ALTA_MUEBLE.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ M U E B L E es requerido ")]
        [DisplayName("I D_ M U E B L E")]
        public Int32 NID_MUEBLE => datos_ALTA_MUEBLE.NID_MUEBLE;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O es requerido ")]
        [DisplayName("I D_ T I P O")]
        public Int32 NID_TIPO
        {
          get => datos_ALTA_MUEBLE.NID_TIPO;
          set => datos_ALTA_MUEBLE.NID_TIPO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo E S P E C I F I C A C I O N es requerido ")]
        [DisplayName("E S P E C I F I C A C I O N")]
        public String E_ESPECIFICACION
        {
          get => datos_ALTA_MUEBLE.E_ESPECIFICACION;
          set => datos_ALTA_MUEBLE.E_ESPECIFICACION = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo V A L O R es requerido ")]
        [DisplayName("V A L O R")]
        public Decimal M_VALOR
        {
          get => datos_ALTA_MUEBLE.M_VALOR;
          set => datos_ALTA_MUEBLE.M_VALOR = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO
        {
          get => datos_ALTA_MUEBLE.NID_PATRIMONIO;
          set => datos_ALTA_MUEBLE.NID_PATRIMONIO = value;
        }

        [Required(ErrorMessage = "El campo C R E D I T O es requerido ")]
        [DisplayName("C R E D I T O")]
        public Boolean L_CREDITO
        {
          get => datos_ALTA_MUEBLE.L_CREDITO;
          set => datos_ALTA_MUEBLE.L_CREDITO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo A D Q U I S I C I O N es requerido ")]
        [DisplayName("A D Q U I S I C I O N")]
        public DateTime F_ADQUISICION
        {
          get => datos_ALTA_MUEBLE.F_ADQUISICION;
          set => datos_ALTA_MUEBLE.F_ADQUISICION = value;
        }

        public String V_TIPO_MONEDA
        {
            get => datos_ALTA_MUEBLE.V_TIPO_MONEDA;
            set => datos_ALTA_MUEBLE.V_TIPO_MONEDA = value;
        }

        public String CID_TIPO_PERSONA_TRANSMISOR
        {
            get => datos_ALTA_MUEBLE.CID_TIPO_PERSONA_TRANSMISOR;
            set => datos_ALTA_MUEBLE.CID_TIPO_PERSONA_TRANSMISOR = value;
        }

        public String E_NOMBRE_TRANSMISOR
        {
            get => datos_ALTA_MUEBLE.E_NOMBRE_TRANSMISOR;
            set => datos_ALTA_MUEBLE.E_NOMBRE_TRANSMISOR = value;
        }
        public String E_RFC_TRANSMISOR
        {
            get => datos_ALTA_MUEBLE.E_RFC_TRANSMISOR;
            set => datos_ALTA_MUEBLE.E_RFC_TRANSMISOR = value;
        }

        public Int32 NID_RELACION_TRANSMISOR
        {
            get => datos_ALTA_MUEBLE.NID_RELACION_TRANSMISOR;
            set => datos_ALTA_MUEBLE.NID_RELACION_TRANSMISOR = value;
        }
        public System.Nullable<Int32> NID_FORMA_ADQUISICION
        {
            get => datos_ALTA_MUEBLE.NID_FORMA_ADQUISICION;
            set => datos_ALTA_MUEBLE.NID_FORMA_ADQUISICION = value;
        }

        public System.Nullable<Int32> NID_FORMA_PAGO
        {
            get => datos_ALTA_MUEBLE.NID_FORMA_PAGO;
            set => datos_ALTA_MUEBLE.NID_FORMA_PAGO = value;
        }
        public String E_OBSERVACIONES
        {
            get => datos_ALTA_MUEBLE.E_OBSERVACIONES;
            set => datos_ALTA_MUEBLE.E_OBSERVACIONES = value;
        }
        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_MUEBLE.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_MUEBLE() => datos_ALTA_MUEBLE = new dald_ALTA_MUEBLE();

        public bll_ALTA_MUEBLE(MODELDeclara_V2.ALTA_MUEBLE ALTA_MUEBLE) => datos_ALTA_MUEBLE = new dald_ALTA_MUEBLE(ALTA_MUEBLE);

        public bll_ALTA_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE) => datos_ALTA_MUEBLE = new dald_ALTA_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE);

        public bll_ALTA_MUEBLE(String VID_NOMBRE
            , String VID_FECHA
            , String VID_HOMOCLAVE
            , Int32 NID_DECLARACION
            , Int32 NID_MUEBLE
            , Int32 NID_TIPO
            , String E_ESPECIFICACION
            , Decimal M_VALOR
            , Int32 NID_PATRIMONIO
            , Boolean L_CREDITO
            , DateTime F_ADQUISICION
            , String CID_TIPO_PERSONA_TRANSMISOR
            , String E_NOMBRE_TRANSMISOR
            , String E_RFC_TRANSMISOR
            , Int32 NID_RELACION_TRANSMISOR
            , String V_TIPO_MONEDA
            , Int32 V_FORMA_ADQUISICION
            , Int32 V_FORMA_PAGO
            , String E_OBSERVACIONES
            , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
            ) => datos_ALTA_MUEBLE = new dald_ALTA_MUEBLE(VID_NOMBRE
                                        , VID_FECHA
                                        , VID_HOMOCLAVE
                                        , NID_DECLARACION
                                        , NID_MUEBLE
                                        , NID_TIPO
                                        , E_ESPECIFICACION
                                        , M_VALOR
                                        , NID_PATRIMONIO
                                        , L_CREDITO
                                        , F_ADQUISICION
                                        , CID_TIPO_PERSONA_TRANSMISOR
                                        , E_NOMBRE_TRANSMISOR
                                        , E_RFC_TRANSMISOR
                                        , NID_RELACION_TRANSMISOR
                                        , V_TIPO_MONEDA
                                        , V_FORMA_ADQUISICION
                                        , V_FORMA_PAGO
                                        , E_OBSERVACIONES, 
                                        lOpcionesRegistroExistente
                                        );

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA_MUEBLE.update();
        }

        public void delete()
        {
            datos_ALTA_MUEBLE.delete();
        }

        public void reload()
        {
            datos_ALTA_MUEBLE.reload();
        }

     #endregion

    }
}
