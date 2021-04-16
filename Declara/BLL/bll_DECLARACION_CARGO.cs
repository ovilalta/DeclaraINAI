using Declara_V2.DALD;
using Declara_V2.Exceptions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_CARGO : _bllSistema
    {

        internal dald_DECLARACION_CARGO datos_DECLARACION_CARGO;

        #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_DECLARACION_CARGO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_DECLARACION_CARGO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_DECLARACION_CARGO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_DECLARACION_CARGO.NID_DECLARACION;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ P U E S T O es requerido ")]
        [DisplayName("I D_ P U E S T O")]
        public Int32 NID_PUESTO
        {
            get => datos_DECLARACION_CARGO.NID_PUESTO;
            set => datos_DECLARACION_CARGO.NID_PUESTO = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo D E N O M I N A C I O N es requerido ")]
        [DisplayName("D E N O M I N A C I O N")]
        public String V_DENOMINACION
        {
            get => datos_DECLARACION_CARGO.V_DENOMINACION;
            set => datos_DECLARACION_CARGO.V_DENOMINACION = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo P O S E S I O N es requerido ")]
        [DisplayName("P O S E S I O N")]
        public DateTime F_POSESION
        {
            get => datos_DECLARACION_CARGO.F_POSESION;
            set => datos_DECLARACION_CARGO.F_POSESION = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        public DateTime F_INICIO
        {
            get => datos_DECLARACION_CARGO.F_INICIO;
            set => datos_DECLARACION_CARGO.F_INICIO = value;
        }

        [StringLength(8)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I D_ P R I M E R_ N I V E L es requerido ")]
        [DisplayName("I D_ P R I M E R_ N I V E L")]
        public String VID_PRIMER_NIVEL
        {
            get => datos_DECLARACION_CARGO.VID_PRIMER_NIVEL;
            set => datos_DECLARACION_CARGO.VID_PRIMER_NIVEL = value;
        }

        [StringLength(8)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I D_ S E G U N D O_ N I V E L es requerido ")]
        [DisplayName("I D_ S E G U N D O_ N I V E L")]
        public String VID_SEGUNDO_NIVEL
        {
            get => datos_DECLARACION_CARGO.VID_SEGUNDO_NIVEL;
            set => datos_DECLARACION_CARGO.VID_SEGUNDO_NIVEL = value;
        }
        public String E_OBSERVACIONES
        {
            get => datos_DECLARACION_CARGO.E_OBSERVACIONES;
            set => datos_DECLARACION_CARGO.E_OBSERVACIONES = value;
        }

        public String V_FUNCION_PRINCIPAL
        {
            get => datos_DECLARACION_CARGO.V_FUNCION_PRINCIPAL;
            set => datos_DECLARACION_CARGO.V_FUNCION_PRINCIPAL = value;
        }
        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_CARGO.lEsNuevoRegistro; }
        }

        #endregion



        #endregion


        #region *** Constructores ***

        public bll_DECLARACION_CARGO() => datos_DECLARACION_CARGO = new dald_DECLARACION_CARGO();

        public bll_DECLARACION_CARGO(MODELDeclara_V2.DECLARACION_CARGO DECLARACION_CARGO) => datos_DECLARACION_CARGO = new dald_DECLARACION_CARGO(DECLARACION_CARGO);

        public bll_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) => datos_DECLARACION_CARGO = new dald_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

        public bll_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, DateTime F_POSESION, DateTime F_INICIO, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, int NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_DECLARACION_CARGO = new dald_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, V_FUNCION_PRINCIPAL, F_POSESION, F_INICIO, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, lOpcionesRegistroExistente);

        #endregion


        #region *** Metodos ***

        public void update()
        {
            datos_DECLARACION_CARGO.update();
        }

        public void delete()
        {
            datos_DECLARACION_CARGO.delete();
        }

        public void reload()
        {
            datos_DECLARACION_CARGO.reload();
        }

        #endregion

    }
}
