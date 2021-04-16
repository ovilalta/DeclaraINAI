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
    public  class bll_ALTA_TARJETA : _bllSistema
    {

        internal dald_ALTA_TARJETA datos_ALTA_TARJETA;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_ALTA_TARJETA.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_ALTA_TARJETA.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_ALTA_TARJETA.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_ALTA_TARJETA.NID_DECLARACION;

        [Key]
        [StringLength(1023)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_NUMERO => datos_ALTA_TARJETA.E_NUMERO;

        [StringLength(5)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_NUMERO_CORTO
        {
          get => datos_ALTA_TARJETA.V_NUMERO_CORTO;
          set => datos_ALTA_TARJETA.V_NUMERO_CORTO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_SALDO
        {
          get => datos_ALTA_TARJETA.M_SALDO;
          set => datos_ALTA_TARJETA.M_SALDO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TITULAR
        {
          get => datos_ALTA_TARJETA.NID_TITULAR;
          set => datos_ALTA_TARJETA.NID_TITULAR = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_TARJETA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_TARJETA() => datos_ALTA_TARJETA = new dald_ALTA_TARJETA();

        public bll_ALTA_TARJETA(MODELDeclara_V2.ALTA_TARJETA ALTA_TARJETA) => datos_ALTA_TARJETA = new dald_ALTA_TARJETA(ALTA_TARJETA);

        public bll_ALTA_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO) => datos_ALTA_TARJETA = new dald_ALTA_TARJETA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO);

        public bll_ALTA_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, String V_NUMERO_CORTO, Decimal M_SALDO, Int32 NID_TITULAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_ALTA_TARJETA = new dald_ALTA_TARJETA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, V_NUMERO_CORTO, M_SALDO, NID_TITULAR, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA_TARJETA.update();
        }

        public void delete()
        {
            datos_ALTA_TARJETA.delete();
        }

        public void reload()
        {
            datos_ALTA_TARJETA.reload();
        }

     #endregion

    }
}
