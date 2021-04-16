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
    public  class bll_DECLARACION : _bllSistema
    {

        internal dald_DECLARACION datos_DECLARACION;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_DECLARACION.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_DECLARACION.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_DECLARACION.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_DECLARACION.NID_DECLARACION;

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo E J E R C I C I O es requerido ")]
        [DisplayName("E J E R C I C I O")]
        public String C_EJERCICIO
        {
          get => datos_DECLARACION.C_EJERCICIO;
          set => datos_DECLARACION.C_EJERCICIO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ T I P O_ D E C L A R A C I O N")]
        public Int32 NID_TIPO_DECLARACION
        {
          get => datos_DECLARACION.NID_TIPO_DECLARACION;
          set => datos_DECLARACION.NID_TIPO_DECLARACION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ E S T A D O es requerido ")]
        [DisplayName("I D_ E S T A D O")]
        public Int32 NID_ESTADO => datos_DECLARACION.NID_ESTADO;

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("O B S E R V A C I O N E S")]
        public String E_OBSERVACIONES
        {
          get => datos_DECLARACION.E_OBSERVACIONES;
          set => datos_DECLARACION.E_OBSERVACIONES = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("O B S E R V A C I O N E S_ M A R C A D O")]
        public String E_OBSERVACIONES_MARCADO
        {
          get => datos_DECLARACION.E_OBSERVACIONES_MARCADO;
          set => datos_DECLARACION.E_OBSERVACIONES_MARCADO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("O B S E R V A C I O N E S_ T E S T A D O")]
        public String V_OBSERVACIONES_TESTADO
        {
          get => datos_DECLARACION.V_OBSERVACIONES_TESTADO;
          set => datos_DECLARACION.V_OBSERVACIONES_TESTADO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ E S T A D O_ T E S T A D O es requerido ")]
        [DisplayName("I D_ E S T A D O_ T E S T A D O")]
        public Int32 NID_ESTADO_TESTADO => datos_DECLARACION.NID_ESTADO_TESTADO;

        [Required(ErrorMessage = "El campo A U T O R I Z A_ P U B L I C A R es requerido ")]
        [DisplayName("A U T O R I Z A_ P U B L I C A R")]
        public Boolean L_AUTORIZA_PUBLICAR
        {
          get => datos_DECLARACION.L_AUTORIZA_PUBLICAR;
          set => datos_DECLARACION.L_AUTORIZA_PUBLICAR = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo R E G I S T R O es requerido ")]
        [DisplayName("R E G I S T R O")]
        public DateTime F_REGISTRO => datos_DECLARACION.F_REGISTRO;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [DisplayName("E N V I O")]
        public System.Nullable<DateTime> F_ENVIO
        {
          get => datos_DECLARACION.F_ENVIO;
          set => datos_DECLARACION.F_ENVIO = value;
        }

        [DisplayName("C O N F L I C T O")]
        public System.Nullable<Boolean> L_CONFLICTO
        {
          get => datos_DECLARACION.L_CONFLICTO;
          set => datos_DECLARACION.L_CONFLICTO = value;
        }

        [StringLength(512)]
        [DataType(DataType.MultilineText)]
        [DisplayName("H A S H")]
        public String V_HASH
        {
          get => datos_DECLARACION.V_HASH;
          set => datos_DECLARACION.V_HASH = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_DECLARACION() => datos_DECLARACION = new dald_DECLARACION();

        public bll_DECLARACION(MODELDeclara_V2.DECLARACION DECLARACION) => datos_DECLARACION = new dald_DECLARACION(DECLARACION);

        public bll_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) => datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

        public bll_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_EJERCICIO, Int32 NID_TIPO_DECLARACION, Int32 NID_ESTADO, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, Boolean L_AUTORIZA_PUBLICAR, System.Nullable<DateTime> F_ENVIO, System.Nullable<Boolean> L_CONFLICTO, String V_HASH, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_DECLARACION = new dald_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_EJERCICIO, NID_TIPO_DECLARACION, NID_ESTADO, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, L_AUTORIZA_PUBLICAR, F_ENVIO, L_CONFLICTO, V_HASH, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_DECLARACION.update();
        }

        public void delete()
        {
            datos_DECLARACION.delete();
        }

        public void reload()
        {
            datos_DECLARACION.reload();
        }

     #endregion

    }
}
