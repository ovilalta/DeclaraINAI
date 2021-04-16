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
    public  class bll_ALTA_ADEUDO : _bllSistema
    {

        internal dald_ALTA_ADEUDO datos_ALTA_ADEUDO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_ALTA_ADEUDO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_ALTA_ADEUDO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_ALTA_ADEUDO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_ALTA_ADEUDO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ A D E U D O es requerido ")]
        [DisplayName("I D_ A D E U D O")]
        public Int32 NID_ADEUDO => datos_ALTA_ADEUDO.NID_ADEUDO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ P A I S es requerido ")]
        [DisplayName("I D_ P A I S")]
        public Int32 NID_PAIS
        {
          get => datos_ALTA_ADEUDO.NID_PAIS;
          set => datos_ALTA_ADEUDO.NID_PAIS = value;
        }

        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I D_ E N T I D A D_ F E D E R A T I V A es requerido ")]
        [DisplayName("I D_ E N T I D A D_ F E D E R A T I V A")]
        public String CID_ENTIDAD_FEDERATIVA
        {
          get => datos_ALTA_ADEUDO.CID_ENTIDAD_FEDERATIVA;
          set => datos_ALTA_ADEUDO.CID_ENTIDAD_FEDERATIVA = value;
        }

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("L U G A R")]
        public String V_LUGAR
        {
          get => datos_ALTA_ADEUDO.V_LUGAR;
          set => datos_ALTA_ADEUDO.V_LUGAR = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ I N S T I T U C I O N es requerido ")]
        [DisplayName("I D_ I N S T I T U C I O N")]
        public Int32 NID_INSTITUCION
        {
          get => datos_ALTA_ADEUDO.NID_INSTITUCION;
          set => datos_ALTA_ADEUDO.NID_INSTITUCION = value;
        }

        [StringLength(150)]
        [DataType(DataType.Text)]
        [DisplayName("O T R A")]
        public String V_OTRA
        {
          get => datos_ALTA_ADEUDO.V_OTRA;
          set => datos_ALTA_ADEUDO.V_OTRA = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ T I P O_ A D E U D O es requerido ")]
        [DisplayName("I D_ T I P O_ A D E U D O")]
        public Int32 NID_TIPO_ADEUDO
        {
          get => datos_ALTA_ADEUDO.NID_TIPO_ADEUDO;
          set => datos_ALTA_ADEUDO.NID_TIPO_ADEUDO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo A D E U D O es requerido ")]
        [DisplayName("A D E U D O")]
        public DateTime F_ADEUDO
        {
          get => datos_ALTA_ADEUDO.F_ADEUDO;
          set => datos_ALTA_ADEUDO.F_ADEUDO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo O R I G I N A L es requerido ")]
        [DisplayName("O R I G I N A L")]
        public Decimal M_ORIGINAL
        {
          get => datos_ALTA_ADEUDO.M_ORIGINAL;
          set => datos_ALTA_ADEUDO.M_ORIGINAL = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo S A L D O es requerido ")]
        [DisplayName("S A L D O")]
        public Decimal M_SALDO
        {
          get => datos_ALTA_ADEUDO.M_SALDO;
          set => datos_ALTA_ADEUDO.M_SALDO = value;
        }

        [StringLength(1023)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo C U E N T A es requerido ")]
        [DisplayName("C U E N T A")]
        public String E_CUENTA
        {
          get => datos_ALTA_ADEUDO.E_CUENTA;
          set => datos_ALTA_ADEUDO.E_CUENTA = value;
        }

        [Required(ErrorMessage = "El campo A U T O G E N E R A D O es requerido ")]
        [DisplayName("A U T O G E N E R A D O")]
        public Boolean L_AUTOGENERADO
        {
          get => datos_ALTA_ADEUDO.L_AUTOGENERADO;
          set => datos_ALTA_ADEUDO.L_AUTOGENERADO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO
        {
          get => datos_ALTA_ADEUDO.NID_PATRIMONIO;
          set => datos_ALTA_ADEUDO.NID_PATRIMONIO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_ADEUDO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_ADEUDO() => datos_ALTA_ADEUDO = new dald_ALTA_ADEUDO();

        public bll_ALTA_ADEUDO(MODELDeclara_V2.ALTA_ADEUDO ALTA_ADEUDO) => datos_ALTA_ADEUDO = new dald_ALTA_ADEUDO(ALTA_ADEUDO);

        public bll_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO) => datos_ALTA_ADEUDO = new dald_ALTA_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO);

        public bll_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, String V_TIPO_MONEDA, String E_RFC, String E_OBSERVACIONES, String CID_TIPO_PERSONA_OTORGANTE, Boolean L_AUTOGENERADO, Int32 NID_PATRIMONIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_ALTA_ADEUDO = new dald_ALTA_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, V_TIPO_MONEDA, E_RFC, E_OBSERVACIONES, CID_TIPO_PERSONA_OTORGANTE, L_AUTOGENERADO, NID_PATRIMONIO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA_ADEUDO.update();
        }

        public void delete()
        {
            datos_ALTA_ADEUDO.delete();
        }

        public void reload()
        {
            datos_ALTA_ADEUDO.reload();
        }

     #endregion

    }
}
