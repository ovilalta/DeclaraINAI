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
    public  class bll_MODIFICACION_MUEBLE : _bllSistema
    {

        internal dald_MODIFICACION_MUEBLE datos_MODIFICACION_MUEBLE;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_MUEBLE.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_MUEBLE.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_MUEBLE.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_MUEBLE.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_MUEBLE.NID_PATRIMONIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O es requerido ")]
        [DisplayName("I D_ T I P O")]
        public Int32 NID_TIPO
        {
          get => datos_MODIFICACION_MUEBLE.NID_TIPO;
          set => datos_MODIFICACION_MUEBLE.NID_TIPO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo E S P E C I F I C A C I O N es requerido ")]
        [DisplayName("E S P E C I F I C A C I O N")]
        public String E_ESPECIFICACION
        {
          get => datos_MODIFICACION_MUEBLE.E_ESPECIFICACION;
          set => datos_MODIFICACION_MUEBLE.E_ESPECIFICACION = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo V A L O R es requerido ")]
        [DisplayName("V A L O R")]
        public Decimal M_VALOR
        {
          get => datos_MODIFICACION_MUEBLE.M_VALOR;
          set => datos_MODIFICACION_MUEBLE.M_VALOR = value;
        }

        [Required(ErrorMessage = "El campo M O D I F I C A D O es requerido ")]
        [DisplayName("M O D I F I C A D O")]
        public Boolean L_MODIFICADO
        {
          get => datos_MODIFICACION_MUEBLE.L_MODIFICADO;
          set => datos_MODIFICACION_MUEBLE.L_MODIFICADO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo A D Q U I S I C I O N es requerido ")]
        [DisplayName("A D Q U I S I C I O N")]
        public DateTime F_ADQUISICION
        {
          get => datos_MODIFICACION_MUEBLE.F_ADQUISICION;
          set => datos_MODIFICACION_MUEBLE.F_ADQUISICION = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_MUEBLE.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_MUEBLE() => datos_MODIFICACION_MUEBLE = new dald_MODIFICACION_MUEBLE();

        public bll_MODIFICACION_MUEBLE(MODELDeclara_V2.MODIFICACION_MUEBLE MODIFICACION_MUEBLE) => datos_MODIFICACION_MUEBLE = new dald_MODIFICACION_MUEBLE(MODIFICACION_MUEBLE);

        public bll_MODIFICACION_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_MUEBLE = new dald_MODIFICACION_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO, String E_ESPECIFICACION, Decimal M_VALOR, Boolean L_MODIFICADO, DateTime F_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_MUEBLE = new dald_MODIFICACION_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO, E_ESPECIFICACION, M_VALOR, L_MODIFICADO, F_ADQUISICION, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_MUEBLE.update();
        }

        public void delete()
        {
            datos_MODIFICACION_MUEBLE.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_MUEBLE.reload();
        }

     #endregion

    }
}
