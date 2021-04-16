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
    public  class bll_H_PATRIMONIO_INMUEBLE : _bllSistema
    {

        internal dald_H_PATRIMONIO_INMUEBLE datos_H_PATRIMONIO_INMUEBLE;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_H_PATRIMONIO_INMUEBLE.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_H_PATRIMONIO_INMUEBLE.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_H_PATRIMONIO_INMUEBLE.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_H_PATRIMONIO_INMUEBLE.NID_PATRIMONIO;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_HISTORICO => datos_H_PATRIMONIO_INMUEBLE.NID_HISTORICO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_TIPO;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_TIPO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_ADQUISICION
        {
          get => datos_H_PATRIMONIO_INMUEBLE.F_ADQUISICION;
          set => datos_H_PATRIMONIO_INMUEBLE.F_ADQUISICION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_USO
        {
          get => datos_H_PATRIMONIO_INMUEBLE.NID_USO;
          set => datos_H_PATRIMONIO_INMUEBLE.NID_USO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_UBICACION
        {
          get => datos_H_PATRIMONIO_INMUEBLE.E_UBICACION;
          set => datos_H_PATRIMONIO_INMUEBLE.E_UBICACION = value;
        }

        
        [RegularExpression(@"^\d+\.\d{0,4}$")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal N_TERRENO
        {
          get => datos_H_PATRIMONIO_INMUEBLE.N_TERRENO;
          set => datos_H_PATRIMONIO_INMUEBLE.N_TERRENO = value;
        }

        
        [RegularExpression(@"^\d+\.\d{0,4}$")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal N_CONSTRUCCION
        {
          get => datos_H_PATRIMONIO_INMUEBLE.N_CONSTRUCCION;
          set => datos_H_PATRIMONIO_INMUEBLE.N_CONSTRUCCION = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_VALOR_INMUEBLE
        {
          get => datos_H_PATRIMONIO_INMUEBLE.M_VALOR_INMUEBLE;
          set => datos_H_PATRIMONIO_INMUEBLE.M_VALOR_INMUEBLE = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_H_PATRIMONIO_INMUEBLE.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_H_PATRIMONIO_INMUEBLE() => datos_H_PATRIMONIO_INMUEBLE = new dald_H_PATRIMONIO_INMUEBLE();

        public bll_H_PATRIMONIO_INMUEBLE(MODELDeclara_V2.H_PATRIMONIO_INMUEBLE H_PATRIMONIO_INMUEBLE) => datos_H_PATRIMONIO_INMUEBLE = new dald_H_PATRIMONIO_INMUEBLE(H_PATRIMONIO_INMUEBLE);

        public bll_H_PATRIMONIO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO) => datos_H_PATRIMONIO_INMUEBLE = new dald_H_PATRIMONIO_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);

        public bll_H_PATRIMONIO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_H_PATRIMONIO_INMUEBLE = new dald_H_PATRIMONIO_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_H_PATRIMONIO_INMUEBLE.update();
        }

        public void delete()
        {
            datos_H_PATRIMONIO_INMUEBLE.delete();
        }

        public void reload()
        {
            datos_H_PATRIMONIO_INMUEBLE.reload();
        }

     #endregion

    }
}
