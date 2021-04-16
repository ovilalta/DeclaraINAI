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
    public  class bll_ALTA_INVERSION : _bllSistema
    {

        internal dald_ALTA_INVERSION datos_ALTA_INVERSION;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_ALTA_INVERSION.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_ALTA_INVERSION.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_ALTA_INVERSION.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_ALTA_INVERSION.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ I N V E R S I O N es requerido ")]
        [DisplayName("I D_ I N V E R S I O N")]
        public Int32 NID_INVERSION => datos_ALTA_INVERSION.NID_INVERSION;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O_ I N V E R S I O N es requerido ")]
        [DisplayName("I D_ T I P O_ I N V E R S I O N")]
        public Int32 NID_TIPO_INVERSION
        {
          get => datos_ALTA_INVERSION.NID_TIPO_INVERSION;
          set => datos_ALTA_INVERSION.NID_TIPO_INVERSION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ S U B T I P O_ I N V E R S I O N es requerido ")]
        [DisplayName("I D_ S U B T I P O_ I N V E R S I O N")]
        public Int32 NID_SUBTIPO_INVERSION
        {
          get => datos_ALTA_INVERSION.NID_SUBTIPO_INVERSION;
          set => datos_ALTA_INVERSION.NID_SUBTIPO_INVERSION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ I N S T I T U C I O N es requerido ")]
        [DisplayName("I D_ I N S T I T U C I O N")]
        public Int32 NID_INSTITUCION
        {
          get => datos_ALTA_INVERSION.NID_INSTITUCION;
          set => datos_ALTA_INVERSION.NID_INSTITUCION = value;
        }

        [StringLength(1023)]
        [DataType(DataType.MultilineText)]
        [DisplayName("C U E N T A")]
        public String E_CUENTA
        {
          get => datos_ALTA_INVERSION.E_CUENTA;
          set => datos_ALTA_INVERSION.E_CUENTA = value;
        }

        [StringLength(5)]
        [DataType(DataType.Text)]
        [DisplayName("C U E N T A_ C O R T O")]
        public String V_CUENTA_CORTO
        {
          get => datos_ALTA_INVERSION.V_CUENTA_CORTO;
          set => datos_ALTA_INVERSION.V_CUENTA_CORTO = value;
        }

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("O T R O")]
        public String V_OTRO
        {
          get => datos_ALTA_INVERSION.V_OTRO;
          set => datos_ALTA_INVERSION.V_OTRO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo S A L D O es requerido ")]
        [DisplayName("S A L D O")]
        public Decimal M_SALDO
        {
          get => datos_ALTA_INVERSION.M_SALDO;
          set => datos_ALTA_INVERSION.M_SALDO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ P A I S es requerido ")]
        [DisplayName("I D_ P A I S")]
        public Int32 NID_PAIS
        {
          get => datos_ALTA_INVERSION.NID_PAIS;
          set => datos_ALTA_INVERSION.NID_PAIS = value;
        }

        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I D_ E N T I D A D_ F E D E R A T I V A es requerido ")]
        [DisplayName("I D_ E N T I D A D_ F E D E R A T I V A")]
        public String CID_ENTIDAD_FEDERATIVA
        {
          get => datos_ALTA_INVERSION.CID_ENTIDAD_FEDERATIVA;
          set => datos_ALTA_INVERSION.CID_ENTIDAD_FEDERATIVA = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [DisplayName("L U G A R")]
        public String V_LUGAR
        {
          get => datos_ALTA_INVERSION.V_LUGAR;
          set => datos_ALTA_INVERSION.V_LUGAR = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo A P E R T U R A es requerido ")]
        [DisplayName("A P E R T U R A")]
        public DateTime F_APERTURA
        {
          get => datos_ALTA_INVERSION.F_APERTURA;
          set => datos_ALTA_INVERSION.F_APERTURA = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO
        {
          get => datos_ALTA_INVERSION.NID_PATRIMONIO;
          set => datos_ALTA_INVERSION.NID_PATRIMONIO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_INVERSION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_INVERSION() => datos_ALTA_INVERSION = new dald_ALTA_INVERSION();

        public bll_ALTA_INVERSION(MODELDeclara_V2.ALTA_INVERSION ALTA_INVERSION) => datos_ALTA_INVERSION = new dald_ALTA_INVERSION(ALTA_INVERSION);

        public bll_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION) => datos_ALTA_INVERSION = new dald_ALTA_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION);

        public bll_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, DateTime F_APERTURA, Int32 NID_PATRIMONIO, String V_RFC, String V_TIPOMONEDA, String V_TERCEROTIPO, String V_TERCERONOMBRE, String V_TERCERORFC, String E_OBSERVACIONES, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_ALTA_INVERSION = new dald_ALTA_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, F_APERTURA, NID_PATRIMONIO, V_RFC, V_TIPOMONEDA, E_OBSERVACIONES, lOpcionesRegistroExistente);

        #endregion


        #region *** Metodos ***

        public void update()
        {
            datos_ALTA_INVERSION.update();
        }

        public void delete()
        {
            datos_ALTA_INVERSION.delete();
        }

        public void reload()
        {
            datos_ALTA_INVERSION.reload();
        }

     #endregion

    }
}
