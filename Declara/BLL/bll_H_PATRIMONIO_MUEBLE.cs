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
    public  class bll_H_PATRIMONIO_MUEBLE : _bllSistema
    {

        internal dald_H_PATRIMONIO_MUEBLE datos_H_PATRIMONIO_MUEBLE;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_H_PATRIMONIO_MUEBLE.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_H_PATRIMONIO_MUEBLE.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_H_PATRIMONIO_MUEBLE.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_H_PATRIMONIO_MUEBLE.NID_PATRIMONIO;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_HISTORICO => datos_H_PATRIMONIO_MUEBLE.NID_HISTORICO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO
        {
          get => datos_H_PATRIMONIO_MUEBLE.NID_TIPO;
          set => datos_H_PATRIMONIO_MUEBLE.NID_TIPO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_ESPECIFICACION
        {
          get => datos_H_PATRIMONIO_MUEBLE.E_ESPECIFICACION;
          set => datos_H_PATRIMONIO_MUEBLE.E_ESPECIFICACION = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_VALOR
        {
          get => datos_H_PATRIMONIO_MUEBLE.M_VALOR;
          set => datos_H_PATRIMONIO_MUEBLE.M_VALOR = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_H_PATRIMONIO_MUEBLE.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_H_PATRIMONIO_MUEBLE() => datos_H_PATRIMONIO_MUEBLE = new dald_H_PATRIMONIO_MUEBLE();

        public bll_H_PATRIMONIO_MUEBLE(MODELDeclara_V2.H_PATRIMONIO_MUEBLE H_PATRIMONIO_MUEBLE) => datos_H_PATRIMONIO_MUEBLE = new dald_H_PATRIMONIO_MUEBLE(H_PATRIMONIO_MUEBLE);

        public bll_H_PATRIMONIO_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO) => datos_H_PATRIMONIO_MUEBLE = new dald_H_PATRIMONIO_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);

        public bll_H_PATRIMONIO_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_TIPO, String E_ESPECIFICACION, Int64 M_VALOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_H_PATRIMONIO_MUEBLE = new dald_H_PATRIMONIO_MUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO, E_ESPECIFICACION, M_VALOR, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_H_PATRIMONIO_MUEBLE.update();
        }

        public void delete()
        {
            datos_H_PATRIMONIO_MUEBLE.delete();
        }

        public void reload()
        {
            datos_H_PATRIMONIO_MUEBLE.reload();
        }

     #endregion

    }
}
