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
    public  class bll_MODIFICACION_BAJA : _bllSistema
    {

        internal dald_MODIFICACION_BAJA datos_MODIFICACION_BAJA;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_MODIFICACION_BAJA.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_MODIFICACION_BAJA.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_BAJA.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_BAJA.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_BAJA.NID_PATRIMONIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_BAJA
        {
          get => datos_MODIFICACION_BAJA.NID_TIPO_BAJA;
          set => datos_MODIFICACION_BAJA.NID_TIPO_BAJA = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_BAJA
        {
          get => datos_MODIFICACION_BAJA.F_BAJA;
          set => datos_MODIFICACION_BAJA.F_BAJA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_BAJA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_BAJA() => datos_MODIFICACION_BAJA = new dald_MODIFICACION_BAJA();

        public bll_MODIFICACION_BAJA(MODELDeclara_V2.MODIFICACION_BAJA MODIFICACION_BAJA) => datos_MODIFICACION_BAJA = new dald_MODIFICACION_BAJA(MODIFICACION_BAJA);

        public bll_MODIFICACION_BAJA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_BAJA = new dald_MODIFICACION_BAJA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_BAJA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_BAJA = new dald_MODIFICACION_BAJA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_BAJA, F_BAJA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_BAJA.update();
        }

        public void delete()
        {
            datos_MODIFICACION_BAJA.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_BAJA.reload();
        }

     #endregion

    }
}
