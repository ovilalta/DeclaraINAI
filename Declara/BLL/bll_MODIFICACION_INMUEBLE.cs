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
    public  class bll_MODIFICACION_INMUEBLE : _bllSistema
    {

        internal dald_MODIFICACION_INMUEBLE datos_MODIFICACION_INMUEBLE;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_INMUEBLE.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_INMUEBLE.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_INMUEBLE.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_INMUEBLE.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_INMUEBLE.NID_PATRIMONIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O es requerido ")]
        [DisplayName("I D_ T I P O")]
        public Int32 NID_TIPO
        {
          get => datos_MODIFICACION_INMUEBLE.NID_TIPO;
          set => datos_MODIFICACION_INMUEBLE.NID_TIPO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo A D Q U I S I C I O N es requerido ")]
        [DisplayName("A D Q U I S I C I O N")]
        public DateTime F_ADQUISICION
        {
          get => datos_MODIFICACION_INMUEBLE.F_ADQUISICION;
          set => datos_MODIFICACION_INMUEBLE.F_ADQUISICION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ U S O es requerido ")]
        [DisplayName("I D_ U S O")]
        public Int32 NID_USO
        {
          get => datos_MODIFICACION_INMUEBLE.NID_USO;
          set => datos_MODIFICACION_INMUEBLE.NID_USO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo U B I C A C I O N es requerido ")]
        [DisplayName("U B I C A C I O N")]
        public String E_UBICACION
        {
          get => datos_MODIFICACION_INMUEBLE.E_UBICACION;
          set => datos_MODIFICACION_INMUEBLE.E_UBICACION = value;
        }

        //[Range(-79228162514264337593543950335,79228162514264337593543950335, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression(@"^\d+\.\d{0,4}$")]
        [Required(ErrorMessage = "El campo T E R R E N O es requerido ")]
        [DisplayName("T E R R E N O")]
        public Decimal N_TERRENO
        {
          get => datos_MODIFICACION_INMUEBLE.N_TERRENO;
          set => datos_MODIFICACION_INMUEBLE.N_TERRENO = value;
        }

        //[Range(-79228162514264337593543950335,79228162514264337593543950335, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression(@"^\d+\.\d{0,4}$")]
        [Required(ErrorMessage = "El campo C O N S T R U C C I O N es requerido ")]
        [DisplayName("C O N S T R U C C I O N")]
        public Decimal N_CONSTRUCCION
        {
          get => datos_MODIFICACION_INMUEBLE.N_CONSTRUCCION;
          set => datos_MODIFICACION_INMUEBLE.N_CONSTRUCCION = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo V A L O R_ I N M U E B L E es requerido ")]
        [DisplayName("V A L O R_ I N M U E B L E")]
        public Decimal M_VALOR_INMUEBLE
        {
          get => datos_MODIFICACION_INMUEBLE.M_VALOR_INMUEBLE;
          set => datos_MODIFICACION_INMUEBLE.M_VALOR_INMUEBLE = value;
        }

        [DisplayName("M O D I F I C A D O")]
        public System.Nullable<Boolean> L_MODIFICADO
        {
          get => datos_MODIFICACION_INMUEBLE.L_MODIFICADO;
          set => datos_MODIFICACION_INMUEBLE.L_MODIFICADO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_INMUEBLE.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_INMUEBLE() => datos_MODIFICACION_INMUEBLE = new dald_MODIFICACION_INMUEBLE();

        public bll_MODIFICACION_INMUEBLE(MODELDeclara_V2.MODIFICACION_INMUEBLE MODIFICACION_INMUEBLE) => datos_MODIFICACION_INMUEBLE = new dald_MODIFICACION_INMUEBLE(MODIFICACION_INMUEBLE);

        public bll_MODIFICACION_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_INMUEBLE = new dald_MODIFICACION_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE, System.Nullable<Boolean> L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_INMUEBLE = new dald_MODIFICACION_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, L_MODIFICADO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_INMUEBLE.update();
        }

        public void delete()
        {
            datos_MODIFICACION_INMUEBLE.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_INMUEBLE.reload();
        }

     #endregion

    }
}
