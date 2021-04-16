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
    public  class bll_PATRIMONIO : _bllSistema
    {

        internal dald_PATRIMONIO datos_PATRIMONIO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_PATRIMONIO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_PATRIMONIO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_PATRIMONIO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_PATRIMONIO.NID_PATRIMONIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO
        {
          get => datos_PATRIMONIO.NID_TIPO;
          set => datos_PATRIMONIO.NID_TIPO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_VALOR
        {
          get => datos_PATRIMONIO.M_VALOR;
          set => datos_PATRIMONIO.M_VALOR = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DEC_INCOR
        {
          get => datos_PATRIMONIO.NID_DEC_INCOR;
          set => datos_PATRIMONIO.NID_DEC_INCOR = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_INCORPORACION
        {
          get => datos_PATRIMONIO.F_INCORPORACION;
          set => datos_PATRIMONIO.F_INCORPORACION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DEC_ULT_MOD
        {
          get => datos_PATRIMONIO.NID_DEC_ULT_MOD;
          set => datos_PATRIMONIO.NID_DEC_ULT_MOD = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_MODIFICACION
        {
          get => datos_PATRIMONIO.F_MODIFICACION;
          set => datos_PATRIMONIO.F_MODIFICACION = value;
        }

        [StringLength(1)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_ACTIVO
        {
          get => datos_PATRIMONIO.L_ACTIVO;
          set => datos_PATRIMONIO.L_ACTIVO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_REGISTRO => datos_PATRIMONIO.F_REGISTRO;


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_PATRIMONIO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_PATRIMONIO() => datos_PATRIMONIO = new dald_PATRIMONIO();

        public bll_PATRIMONIO(MODELDeclara_V2.PATRIMONIO PATRIMONIO) => datos_PATRIMONIO = new dald_PATRIMONIO(PATRIMONIO);

        public bll_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO) => datos_PATRIMONIO = new dald_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);

        public bll_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_PATRIMONIO = new dald_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, M_VALOR, NID_DEC_INCOR, F_INCORPORACION, NID_DEC_ULT_MOD, F_MODIFICACION, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_PATRIMONIO.update();
        }

        public void delete()
        {
            datos_PATRIMONIO.delete();
        }

        public void reload()
        {
            datos_PATRIMONIO.reload();
        }

     #endregion

    }
}
