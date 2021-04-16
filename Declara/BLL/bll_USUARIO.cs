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
    public  class bll_USUARIO : _bllSistema
    {

        internal dald_USUARIO datos_USUARIO;
        private ExistingPrimaryKeyException.ExistingPrimaryKeyConditions throwException;

        #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_USUARIO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_USUARIO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_USUARIO.VID_HOMOCLAVE;

        [StringLength(255)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_PASSWORD
        {
          get => datos_USUARIO.V_PASSWORD;
          set => datos_USUARIO.V_PASSWORD = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_NOMBRE
        {
          get => datos_USUARIO.V_NOMBRE;
          set => datos_USUARIO.V_NOMBRE = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_PRIMER_A
        {
          get => datos_USUARIO.V_PRIMER_A;
          set => datos_USUARIO.V_PRIMER_A = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_SEGUNDO_A
        {
          get => datos_USUARIO.V_SEGUNDO_A;
          set => datos_USUARIO.V_SEGUNDO_A = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_NACIMIENTO
        {
          get => datos_USUARIO.F_NACIMIENTO;
          set => datos_USUARIO.F_NACIMIENTO = value;
        }

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ACUSE
        {
          get => datos_USUARIO.V_ACUSE;
          set => datos_USUARIO.V_ACUSE = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_ACTIVO
        {
          get => datos_USUARIO.L_ACTIVO;
          set => datos_USUARIO.L_ACTIVO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [DisplayName("")]
        public DateTime F_INGRESO_INSTITUTO
        {
          get => datos_USUARIO.F_INGRESO_INSTITUTO;
          set => datos_USUARIO.F_INGRESO_INSTITUTO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_REGISTRO => datos_USUARIO.F_REGISTRO;

        [Required(ErrorMessage = "El campo es requerido ")]
        [DisplayName("")]
        public Boolean NVO_INGRESO
        {
            get => datos_USUARIO.NVO_INGRESO;
            set => datos_USUARIO.NVO_INGRESO = value;
        }

        [Required(ErrorMessage = "El campo es requerido ")]
        [DisplayName("")]
        public Boolean OBL_DECLARACION
        {
            get => datos_USUARIO.OBL_DECLARACION;
            set => datos_USUARIO.OBL_DECLARACION = value;
        }

        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_USUARIO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_USUARIO() => datos_USUARIO = new dald_USUARIO();

        public bll_USUARIO(MODELDeclara_V2.USUARIO USUARIO) => datos_USUARIO = new dald_USUARIO(USUARIO);

        public bll_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE) => datos_USUARIO = new dald_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);

        public bll_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_PASSWORD, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_ACUSE, Boolean L_ACTIVO, DateTime F_INGRESO_INSTITUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_USUARIO = new dald_USUARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_PASSWORD, V_NOMBRE, V_PRIMER_A, V_SEGUNDO_A, F_NACIMIENTO, V_ACUSE, L_ACTIVO, F_INGRESO_INSTITUTO, lOpcionesRegistroExistente);

        public bll_USUARIO(string VID_NOMBRE, string VID_FECHA, string VID_HOMOCLAVE, string v_PASSWORD, string v_NOMBRE, string v_PRIMER_A, string v_SEGUNDO_A, DateTime f_NACIMIENTO, string v_ACUSE, bool l_ACTIVO, DateTime f_INGRESO_INSTITUTO, bool nVO_INGRESO, bool oBL_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions throwException) : this(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE)
        {
            V_PASSWORD = v_PASSWORD;
            V_NOMBRE = v_NOMBRE;
            V_PRIMER_A = v_PRIMER_A;
            V_SEGUNDO_A = v_SEGUNDO_A;
            F_NACIMIENTO = f_NACIMIENTO;
            V_ACUSE = v_ACUSE;
            L_ACTIVO = l_ACTIVO;
            F_INGRESO_INSTITUTO = f_INGRESO_INSTITUTO;
            NVO_INGRESO = nVO_INGRESO;
            OBL_DECLARACION = oBL_DECLARACION;
            this.throwException = throwException;
        }

        #endregion


        #region *** Metodos ***

        public void update()
        {
            datos_USUARIO.update();
        }

        public void delete()
        {
            datos_USUARIO.delete();
        }

        public void reload()
        {
            datos_USUARIO.reload();
        }

     #endregion

    }
}
