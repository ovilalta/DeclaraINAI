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
    public  class bll_PATRIMONIO_ADEUDO : _bllSistema
    {

        internal dald_PATRIMONIO_ADEUDO datos_PATRIMONIO_ADEUDO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_PATRIMONIO_ADEUDO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_PATRIMONIO_ADEUDO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_PATRIMONIO_ADEUDO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_PATRIMONIO_ADEUDO.NID_PATRIMONIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS
        {
          get => datos_PATRIMONIO_ADEUDO.NID_PAIS;
          set => datos_PATRIMONIO_ADEUDO.NID_PAIS = value;
        }

        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_ENTIDAD_FEDERATIVA
        {
          get => datos_PATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVA;
          set => datos_PATRIMONIO_ADEUDO.CID_ENTIDAD_FEDERATIVA = value;
        }

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        public String V_LUGAR
        {
          get => datos_PATRIMONIO_ADEUDO.V_LUGAR;
          set => datos_PATRIMONIO_ADEUDO.V_LUGAR = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_INSTITUCION
        {
          get => datos_PATRIMONIO_ADEUDO.NID_INSTITUCION;
          set => datos_PATRIMONIO_ADEUDO.NID_INSTITUCION = value;
        }

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("")]
        public String V_OTRA
        {
          get => datos_PATRIMONIO_ADEUDO.V_OTRA;
          set => datos_PATRIMONIO_ADEUDO.V_OTRA = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_ADEUDO
        {
          get => datos_PATRIMONIO_ADEUDO.NID_TIPO_ADEUDO;
          set => datos_PATRIMONIO_ADEUDO.NID_TIPO_ADEUDO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_ORIGINAL
        {
          get => datos_PATRIMONIO_ADEUDO.M_ORIGINAL;
          set => datos_PATRIMONIO_ADEUDO.M_ORIGINAL = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_SALDO
        {
          get => datos_PATRIMONIO_ADEUDO.M_SALDO;
          set => datos_PATRIMONIO_ADEUDO.M_SALDO = value;
        }

        [StringLength(1023)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_CUENTA
        {
          get => datos_PATRIMONIO_ADEUDO.E_CUENTA;
          set => datos_PATRIMONIO_ADEUDO.E_CUENTA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_PATRIMONIO_ADEUDO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_PATRIMONIO_ADEUDO() => datos_PATRIMONIO_ADEUDO = new dald_PATRIMONIO_ADEUDO();

        public bll_PATRIMONIO_ADEUDO(MODELDeclara_V2.PATRIMONIO_ADEUDO PATRIMONIO_ADEUDO) => datos_PATRIMONIO_ADEUDO = new dald_PATRIMONIO_ADEUDO(PATRIMONIO_ADEUDO);

        public bll_PATRIMONIO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO) => datos_PATRIMONIO_ADEUDO = new dald_PATRIMONIO_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO);

        public bll_PATRIMONIO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_PATRIMONIO_ADEUDO = new dald_PATRIMONIO_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_PATRIMONIO_ADEUDO.update();
        }

        public void delete()
        {
            datos_PATRIMONIO_ADEUDO.delete();
        }

        public void reload()
        {
            datos_PATRIMONIO_ADEUDO.reload();
        }

     #endregion

    }
}
