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
    public  class bll_PATRIMONIO_VEHICULO : _bllSistema
    {

        internal dald_PATRIMONIO_VEHICULO datos_PATRIMONIO_VEHICULO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_PATRIMONIO_VEHICULO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_PATRIMONIO_VEHICULO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_PATRIMONIO_VEHICULO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_PATRIMONIO_VEHICULO.NID_PATRIMONIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_MARCA
        {
          get => datos_PATRIMONIO_VEHICULO.NID_MARCA;
          set => datos_PATRIMONIO_VEHICULO.NID_MARCA = value;
        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String C_MODELO
        {
          get => datos_PATRIMONIO_VEHICULO.C_MODELO;
          set => datos_PATRIMONIO_VEHICULO.C_MODELO = value;
        }

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_DESCRIPCION
        {
          get => datos_PATRIMONIO_VEHICULO.V_DESCRIPCION;
          set => datos_PATRIMONIO_VEHICULO.V_DESCRIPCION = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_ADQUISICION
        {
          get => datos_PATRIMONIO_VEHICULO.F_ADQUISICION;
          set => datos_PATRIMONIO_VEHICULO.F_ADQUISICION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_USO
        {
          get => datos_PATRIMONIO_VEHICULO.NID_USO;
          set => datos_PATRIMONIO_VEHICULO.NID_USO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_VALOR_VEHICULO
        {
          get => datos_PATRIMONIO_VEHICULO.M_VALOR_VEHICULO;
          set => datos_PATRIMONIO_VEHICULO.M_VALOR_VEHICULO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_PATRIMONIO_VEHICULO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_PATRIMONIO_VEHICULO() => datos_PATRIMONIO_VEHICULO = new dald_PATRIMONIO_VEHICULO();

        public bll_PATRIMONIO_VEHICULO(MODELDeclara_V2.PATRIMONIO_VEHICULO PATRIMONIO_VEHICULO) => datos_PATRIMONIO_VEHICULO = new dald_PATRIMONIO_VEHICULO(PATRIMONIO_VEHICULO);

        public bll_PATRIMONIO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO) => datos_PATRIMONIO_VEHICULO = new dald_PATRIMONIO_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);

        public bll_PATRIMONIO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_PATRIMONIO_VEHICULO = new dald_PATRIMONIO_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_PATRIMONIO_VEHICULO.update();
        }

        public void delete()
        {
            datos_PATRIMONIO_VEHICULO.delete();
        }

        public void reload()
        {
            datos_PATRIMONIO_VEHICULO.reload();
        }

     #endregion

    }
}
