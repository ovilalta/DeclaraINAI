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
    public  class bll_PATRIMONIO_DEPENDIENTES : _bllSistema
    {

        internal dald_PATRIMONIO_DEPENDIENTES datos_PATRIMONIO_DEPENDIENTES;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_PATRIMONIO_DEPENDIENTES.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_PATRIMONIO_DEPENDIENTES.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DEPENDIENTE => datos_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_DEPENDIENTE
        {
          get => datos_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE;
          set => datos_PATRIMONIO_DEPENDIENTES.NID_TIPO_DEPENDIENTE = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_NOMBRE
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_NOMBRE;
          set => datos_PATRIMONIO_DEPENDIENTES.E_NOMBRE = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_PRIMER_A
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_PRIMER_A;
          set => datos_PATRIMONIO_DEPENDIENTES.E_PRIMER_A = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_SEGUNDO_A
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A;
          set => datos_PATRIMONIO_DEPENDIENTES.E_SEGUNDO_A = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_NACIMIENTO
        {
          get => datos_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO;
          set => datos_PATRIMONIO_DEPENDIENTES.F_NACIMIENTO = value;
        }

        [StringLength(13)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        public String E_RFC
        {
          get => datos_PATRIMONIO_DEPENDIENTES.E_RFC;
          set => datos_PATRIMONIO_DEPENDIENTES.E_RFC = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_DEPENDE_ECO
        {
          get => datos_PATRIMONIO_DEPENDIENTES.L_DEPENDE_ECO;
          set => datos_PATRIMONIO_DEPENDIENTES.L_DEPENDE_ECO = value;
        }

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [DisplayName("")]
        public String V_DOMICILIO
        {
          get => datos_PATRIMONIO_DEPENDIENTES.V_DOMICILIO;
          set => datos_PATRIMONIO_DEPENDIENTES.V_DOMICILIO = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_ACTIVO
        {
          get => datos_PATRIMONIO_DEPENDIENTES.L_ACTIVO;
          set => datos_PATRIMONIO_DEPENDIENTES.L_ACTIVO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_PATRIMONIO_DEPENDIENTES.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_PATRIMONIO_DEPENDIENTES() => datos_PATRIMONIO_DEPENDIENTES = new dald_PATRIMONIO_DEPENDIENTES();

        public bll_PATRIMONIO_DEPENDIENTES(MODELDeclara_V2.PATRIMONIO_DEPENDIENTES PATRIMONIO_DEPENDIENTES) => datos_PATRIMONIO_DEPENDIENTES = new dald_PATRIMONIO_DEPENDIENTES(PATRIMONIO_DEPENDIENTES);

        public bll_PATRIMONIO_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DEPENDIENTE) => datos_PATRIMONIO_DEPENDIENTES = new dald_PATRIMONIO_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DEPENDIENTE);

        public bll_PATRIMONIO_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO, String V_DOMICILIO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_PATRIMONIO_DEPENDIENTES = new dald_PATRIMONIO_DEPENDIENTES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DEPENDIENTE, NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, L_DEPENDE_ECO, V_DOMICILIO, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_PATRIMONIO_DEPENDIENTES.update();
        }

        public void delete()
        {
            datos_PATRIMONIO_DEPENDIENTES.delete();
        }

        public void reload()
        {
            datos_PATRIMONIO_DEPENDIENTES.reload();
        }

     #endregion

    }
}
