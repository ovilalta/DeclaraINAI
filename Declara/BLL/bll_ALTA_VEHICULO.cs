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
    public  class bll_ALTA_VEHICULO : _bllSistema
    {

        internal dald_ALTA_VEHICULO datos_ALTA_VEHICULO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_ALTA_VEHICULO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_ALTA_VEHICULO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_ALTA_VEHICULO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_ALTA_VEHICULO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ V E H I C U L O es requerido ")]
        [DisplayName("I D_ V E H I C U L O")]
        public Int32 NID_VEHICULO => datos_ALTA_VEHICULO.NID_VEHICULO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ M A R C A es requerido ")]
        [DisplayName("I D_ M A R C A")]
        public Int32 NID_MARCA
        {
          get => datos_ALTA_VEHICULO.NID_MARCA;
          set => datos_ALTA_VEHICULO.NID_MARCA = value;
        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo M O D E L O es requerido ")]
        [DisplayName("M O D E L O")]
        public String C_MODELO
        {
          get => datos_ALTA_VEHICULO.C_MODELO;
          set => datos_ALTA_VEHICULO.C_MODELO = value;
        }

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo D E S C R I P C I O N es requerido ")]
        [DisplayName("D E S C R I P C I O N")]
        public String V_DESCRIPCION
        {
          get => datos_ALTA_VEHICULO.V_DESCRIPCION;
          set => datos_ALTA_VEHICULO.V_DESCRIPCION = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo A D Q U I S I C I O N es requerido ")]
        [DisplayName("A D Q U I S I C I O N")]
        public DateTime F_ADQUISICION
        {
          get => datos_ALTA_VEHICULO.F_ADQUISICION;
          set => datos_ALTA_VEHICULO.F_ADQUISICION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O_ V E H I C U L O es requerido ")]
        [DisplayName("I D_ T I P O_ V E H I C U L O")]
        public Int32 NID_TIPO_VEHICULO
        {
          get => datos_ALTA_VEHICULO.NID_TIPO_VEHICULO;
          set => datos_ALTA_VEHICULO.NID_TIPO_VEHICULO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ U S O es requerido ")]
        [DisplayName("I D_ U S O")]
        public Int32 NID_USO
        {
          get => datos_ALTA_VEHICULO.NID_USO;
          set => datos_ALTA_VEHICULO.NID_USO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo V A L O R_ V E H I C U L O es requerido ")]
        [DisplayName("V A L O R_ V E H I C U L O")]
        public Decimal M_VALOR_VEHICULO
        {
          get => datos_ALTA_VEHICULO.M_VALOR_VEHICULO;
          set => datos_ALTA_VEHICULO.M_VALOR_VEHICULO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO
        {
          get => datos_ALTA_VEHICULO.NID_PATRIMONIO;
          set => datos_ALTA_VEHICULO.NID_PATRIMONIO = value;
        }

        public System.Nullable<Int32> NID_PAIS
        //public Int32 NID_PAIS
        {
            get => datos_ALTA_VEHICULO.NID_PAIS;
            set => datos_ALTA_VEHICULO.NID_PAIS = value;
        }
        public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_VEHICULO.CID_ENTIDAD_FEDERATIVA;
            set => datos_ALTA_VEHICULO.CID_ENTIDAD_FEDERATIVA = value;
        }
        public String V_TIPO_MONEDA
        {
            get => datos_ALTA_VEHICULO.V_TIPO_MONEDA;
            set => datos_ALTA_VEHICULO.V_TIPO_MONEDA = value;
        }

        public String E_NUMERO_SERIE
        {
            get => datos_ALTA_VEHICULO.E_NUMERO_SERIE;
            set => datos_ALTA_VEHICULO.E_NUMERO_SERIE = value;
        }
        public String E_NOMBRE_TRANSMISOR
        {
            get => datos_ALTA_VEHICULO.E_NOMBRE_TRANSMISOR;
            set => datos_ALTA_VEHICULO.E_NOMBRE_TRANSMISOR = value;
        }
        public String E_RFC_TRANSMISOR
        {
            get => datos_ALTA_VEHICULO.E_RFC_TRANSMISOR;
            set => datos_ALTA_VEHICULO.E_RFC_TRANSMISOR = value;
        }

        public String CID_TIPO_PERSONA_TRANSMISOR
        {
            get => datos_ALTA_VEHICULO.CID_TIPO_PERSONA_TRANSMISOR;
            set => datos_ALTA_VEHICULO.CID_TIPO_PERSONA_TRANSMISOR = value;
        }

        public Int32 NID_RELACION_TRANSMISOR
        {
            get => datos_ALTA_VEHICULO.NID_RELACION_TRANSMISOR;
            set => datos_ALTA_VEHICULO.NID_RELACION_TRANSMISOR = value;
        }
        public System.Nullable<Int32> NID_FORMA_ADQUISICION
        {
            get => datos_ALTA_VEHICULO.NID_FORMA_ADQUISICION;
            set => datos_ALTA_VEHICULO.NID_FORMA_ADQUISICION = value;
        }

        public System.Nullable<Int32> NID_FORMA_PAGO
        {
            get => datos_ALTA_VEHICULO.NID_FORMA_PAGO;
            set => datos_ALTA_VEHICULO.NID_FORMA_PAGO = value;
        }
        public String E_OBSERVACIONES
        {
            get => datos_ALTA_VEHICULO.E_OBSERVACIONES;
            set => datos_ALTA_VEHICULO.E_OBSERVACIONES = value;
        }

        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_VEHICULO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_VEHICULO() => datos_ALTA_VEHICULO = new dald_ALTA_VEHICULO();

        public bll_ALTA_VEHICULO(MODELDeclara_V2.ALTA_VEHICULO ALTA_VEHICULO) => datos_ALTA_VEHICULO = new dald_ALTA_VEHICULO(ALTA_VEHICULO);

        public bll_ALTA_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO) => datos_ALTA_VEHICULO = new dald_ALTA_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO);

        public bll_ALTA_VEHICULO(String VID_NOMBRE
            , String VID_FECHA
            , String VID_HOMOCLAVE
            , Int32 NID_DECLARACION
            , Int32 NID_VEHICULO
            , Int32 NID_MARCA
            , String C_MODELO
            , String V_DESCRIPCION
            , DateTime F_ADQUISICION
            , Int32 NID_TIPO_VEHICULO
            , Int32 NID_USO
            , Decimal M_VALOR_VEHICULO
            , Int32 NID_PATRIMONIO
            , Int32 NID_PAIS
            , String CID_ENTIDAD_FEDERATIVA
            , String CID_TIPO_PERSONA_TRANSMISOR
            , String E_NOMBRE_TRANSMISOR
            , String E_RFC_TRANSMISOR
            , Int32 NID_RELACION_TRANSMISOR
            , String V_TIPO_MONEDA
            , String E_NUMERO_SERIE
            , Int32 NID_FORMA_ADQUISICION
            , Int32 NID_FORMA_PAGO
            , String E_OBSERVACIONES
            , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
            ) => datos_ALTA_VEHICULO = new dald_ALTA_VEHICULO(VID_NOMBRE
                                            , VID_FECHA
                                            , VID_HOMOCLAVE
                                            , NID_DECLARACION
                                            , NID_VEHICULO
                                            , NID_MARCA
                                            , C_MODELO
                                            , V_DESCRIPCION
                                            , F_ADQUISICION
                                            , NID_TIPO_VEHICULO
                                            , NID_USO
                                            , M_VALOR_VEHICULO
                                            , NID_PATRIMONIO
                                            , NID_PAIS
                                            , CID_ENTIDAD_FEDERATIVA
                                            , CID_TIPO_PERSONA_TRANSMISOR
                                            , E_NOMBRE_TRANSMISOR
                                            , E_RFC_TRANSMISOR
                                            , NID_RELACION_TRANSMISOR
                                            , V_TIPO_MONEDA
                                            , E_NUMERO_SERIE
                                            , NID_FORMA_ADQUISICION
                                            , NID_FORMA_PAGO
                                            , E_OBSERVACIONES
                                            , lOpcionesRegistroExistente
                                            );

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA_VEHICULO.update();
        }

        public void delete()
        {
            datos_ALTA_VEHICULO.delete();
        }

        public void reload()
        {
            datos_ALTA_VEHICULO.reload();
        }

     #endregion

    }
}
