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
    public  class bll_H_PATRIMONIO_INVERSION : _bllSistema
    {

        internal dald_H_PATRIMONIO_INVERSION datos_H_PATRIMONIO_INVERSION;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_H_PATRIMONIO_INVERSION.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_H_PATRIMONIO_INVERSION.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_H_PATRIMONIO_INVERSION.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_H_PATRIMONIO_INVERSION.NID_PATRIMONIO;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_HISTORICO => datos_H_PATRIMONIO_INVERSION.NID_HISTORICO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_INVERSION
        {
          get => datos_H_PATRIMONIO_INVERSION.NID_TIPO_INVERSION;
          set => datos_H_PATRIMONIO_INVERSION.NID_TIPO_INVERSION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_SUBTIPO_INVERSION
        {
          get => datos_H_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSION;
          set => datos_H_PATRIMONIO_INVERSION.NID_SUBTIPO_INVERSION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_INSTITUCION
        {
          get => datos_H_PATRIMONIO_INVERSION.NID_INSTITUCION;
          set => datos_H_PATRIMONIO_INVERSION.NID_INSTITUCION = value;
        }

        [StringLength(1023)]
        [DataType(DataType.MultilineText)]
        [DisplayName("")]
        public String E_CUENTA
        {
          get => datos_H_PATRIMONIO_INVERSION.E_CUENTA;
          set => datos_H_PATRIMONIO_INVERSION.E_CUENTA = value;
        }

        [StringLength(5)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        public String V_CUENTA_CORTO
        {
          get => datos_H_PATRIMONIO_INVERSION.V_CUENTA_CORTO;
          set => datos_H_PATRIMONIO_INVERSION.V_CUENTA_CORTO = value;
        }

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        public String V_OTRO
        {
          get => datos_H_PATRIMONIO_INVERSION.V_OTRO;
          set => datos_H_PATRIMONIO_INVERSION.V_OTRO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_SALDO
        {
          get => datos_H_PATRIMONIO_INVERSION.M_SALDO;
          set => datos_H_PATRIMONIO_INVERSION.M_SALDO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS
        {
          get => datos_H_PATRIMONIO_INVERSION.NID_PAIS;
          set => datos_H_PATRIMONIO_INVERSION.NID_PAIS = value;
        }

        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_ENTIDAD_FEDERATIVA
        {
          get => datos_H_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVA;
          set => datos_H_PATRIMONIO_INVERSION.CID_ENTIDAD_FEDERATIVA = value;
        }

        [StringLength(127)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        public String V_LUGAR
        {
          get => datos_H_PATRIMONIO_INVERSION.V_LUGAR;
          set => datos_H_PATRIMONIO_INVERSION.V_LUGAR = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_H_PATRIMONIO_INVERSION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_H_PATRIMONIO_INVERSION() => datos_H_PATRIMONIO_INVERSION = new dald_H_PATRIMONIO_INVERSION();

        public bll_H_PATRIMONIO_INVERSION(MODELDeclara_V2.H_PATRIMONIO_INVERSION H_PATRIMONIO_INVERSION) => datos_H_PATRIMONIO_INVERSION = new dald_H_PATRIMONIO_INVERSION(H_PATRIMONIO_INVERSION);

        public bll_H_PATRIMONIO_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO) => datos_H_PATRIMONIO_INVERSION = new dald_H_PATRIMONIO_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);

        public bll_H_PATRIMONIO_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_H_PATRIMONIO_INVERSION = new dald_H_PATRIMONIO_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO, NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_H_PATRIMONIO_INVERSION.update();
        }

        public void delete()
        {
            datos_H_PATRIMONIO_INVERSION.delete();
        }

        public void reload()
        {
            datos_H_PATRIMONIO_INVERSION.reload();
        }

     #endregion

    }
}
