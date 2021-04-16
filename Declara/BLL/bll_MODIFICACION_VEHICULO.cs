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
    public  class bll_MODIFICACION_VEHICULO : _bllSistema
    {

        internal dald_MODIFICACION_VEHICULO datos_MODIFICACION_VEHICULO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_VEHICULO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_VEHICULO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_VEHICULO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_VEHICULO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_VEHICULO.NID_PATRIMONIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ M A R C A es requerido ")]
        [DisplayName("I D_ M A R C A")]
        public Int32 NID_MARCA
        {
          get => datos_MODIFICACION_VEHICULO.NID_MARCA;
          set => datos_MODIFICACION_VEHICULO.NID_MARCA = value;
        }

        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo M O D E L O es requerido ")]
        [DisplayName("M O D E L O")]
        public String C_MODELO
        {
          get => datos_MODIFICACION_VEHICULO.C_MODELO;
          set => datos_MODIFICACION_VEHICULO.C_MODELO = value;
        }

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo D E S C R I P C I O N es requerido ")]
        [DisplayName("D E S C R I P C I O N")]
        public String V_DESCRIPCION
        {
          get => datos_MODIFICACION_VEHICULO.V_DESCRIPCION;
          set => datos_MODIFICACION_VEHICULO.V_DESCRIPCION = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo A D Q U I S I C I O N es requerido ")]
        [DisplayName("A D Q U I S I C I O N")]
        public DateTime F_ADQUISICION
        {
          get => datos_MODIFICACION_VEHICULO.F_ADQUISICION;
          set => datos_MODIFICACION_VEHICULO.F_ADQUISICION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ U S O es requerido ")]
        [DisplayName("I D_ U S O")]
        public Int32 NID_USO
        {
          get => datos_MODIFICACION_VEHICULO.NID_USO;
          set => datos_MODIFICACION_VEHICULO.NID_USO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo V A L O R_ V E H I C U L O es requerido ")]
        [DisplayName("V A L O R_ V E H I C U L O")]
        public Decimal M_VALOR_VEHICULO
        {
          get => datos_MODIFICACION_VEHICULO.M_VALOR_VEHICULO;
          set => datos_MODIFICACION_VEHICULO.M_VALOR_VEHICULO = value;
        }

        [Required(ErrorMessage = "El campo M O D I F I C A D O es requerido ")]
        [DisplayName("M O D I F I C A D O")]
        public Boolean L_MODIFICADO
        {
          get => datos_MODIFICACION_VEHICULO.L_MODIFICADO;
          set => datos_MODIFICACION_VEHICULO.L_MODIFICADO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_VEHICULO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_VEHICULO() => datos_MODIFICACION_VEHICULO = new dald_MODIFICACION_VEHICULO();

        public bll_MODIFICACION_VEHICULO(MODELDeclara_V2.MODIFICACION_VEHICULO MODIFICACION_VEHICULO) => datos_MODIFICACION_VEHICULO = new dald_MODIFICACION_VEHICULO(MODIFICACION_VEHICULO);

        public bll_MODIFICACION_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_VEHICULO = new dald_MODIFICACION_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO, Boolean L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_VEHICULO = new dald_MODIFICACION_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_USO, M_VALOR_VEHICULO, L_MODIFICADO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_VEHICULO.update();
        }

        public void delete()
        {
            datos_MODIFICACION_VEHICULO.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_VEHICULO.reload();
        }

     #endregion

    }
}
