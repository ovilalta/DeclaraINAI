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
    public  class bll_MODIFICACION_BAJA_VENTA : _bllSistema
    {

        internal dald_MODIFICACION_BAJA_VENTA datos_MODIFICACION_BAJA_VENTA;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_MODIFICACION_BAJA_VENTA.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_MODIFICACION_BAJA_VENTA.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_BAJA_VENTA.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_BAJA_VENTA.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_BAJA_VENTA.NID_PATRIMONIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_VENTA
        {
          get => datos_MODIFICACION_BAJA_VENTA.NID_TIPO_VENTA;
          set => datos_MODIFICACION_BAJA_VENTA.NID_TIPO_VENTA = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_IMPORTE_VENTA
        {
          get => datos_MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTA;
          set => datos_MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTA = value;
        }


        [Key]
        [StringLength(4000)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_BENIFICIARIO
        {
            get => datos_MODIFICACION_BAJA_VENTA.E_BENIFICIARIO;
            set => datos_MODIFICACION_BAJA_VENTA.E_BENIFICIARIO = value;
        }

        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_BAJA_VENTA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_BAJA_VENTA() => datos_MODIFICACION_BAJA_VENTA = new dald_MODIFICACION_BAJA_VENTA();

        public bll_MODIFICACION_BAJA_VENTA(MODELDeclara_V2.MODIFICACION_BAJA_VENTA MODIFICACION_BAJA_VENTA) => datos_MODIFICACION_BAJA_VENTA = new dald_MODIFICACION_BAJA_VENTA(MODIFICACION_BAJA_VENTA);

        public bll_MODIFICACION_BAJA_VENTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_BAJA_VENTA = new dald_MODIFICACION_BAJA_VENTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_BAJA_VENTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO_VENTA, Decimal M_IMPORTE_VENTA,String E_BENIFICIARIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_BAJA_VENTA = new dald_MODIFICACION_BAJA_VENTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_VENTA, M_IMPORTE_VENTA, E_BENIFICIARIO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_BAJA_VENTA.update();
        }

        public void delete()
        {
            datos_MODIFICACION_BAJA_VENTA.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_BAJA_VENTA.reload();
        }

     #endregion

    }
}
