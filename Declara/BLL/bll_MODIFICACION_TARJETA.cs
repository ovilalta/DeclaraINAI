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
    public  class bll_MODIFICACION_TARJETA : _bllSistema
    {

        internal dald_MODIFICACION_TARJETA datos_MODIFICACION_TARJETA;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_TARJETA.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_TARJETA.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_TARJETA.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_TARJETA.NID_DECLARACION;

        [Key]
        [StringLength(800)]
        [Required(ErrorMessage = "El campo N U M E R O es requerido ")]
        [DisplayName("N U M E R O")]
        public String E_NUMERO => datos_MODIFICACION_TARJETA.E_NUMERO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo I D_ I N S T I T U C I O N es requerido ")]
        [DisplayName("I D_ I N S T I T U C I O N")]
        public Int32 NID_INSTITUCION
        {
          get => datos_MODIFICACION_TARJETA.NID_INSTITUCION;
          set => datos_MODIFICACION_TARJETA.NID_INSTITUCION = value;
        }

        [StringLength(5)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo N U M E R O_ C O R T O es requerido ")]
        [DisplayName("N U M E R O_ C O R T O")]
        public String V_NUMERO_CORTO
        {
          get => datos_MODIFICACION_TARJETA.V_NUMERO_CORTO;
          set => datos_MODIFICACION_TARJETA.V_NUMERO_CORTO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo P A G O S es requerido ")]
        [DisplayName("P A G O S")]
        public Decimal M_PAGOS
        {
          get => datos_MODIFICACION_TARJETA.M_PAGOS;
          set => datos_MODIFICACION_TARJETA.M_PAGOS = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo S A L D O es requerido ")]
        [DisplayName("S A L D O")]
        public Decimal M_SALDO
        {
          get => datos_MODIFICACION_TARJETA.M_SALDO;
          set => datos_MODIFICACION_TARJETA.M_SALDO = value;
        }

        [StringLength(1023)]
        [DataType(DataType.MultilineText)]
        [DisplayName("N U M E R O_ A S O C I A C I O N")]
        public String E_NUMERO_ASOCIACION
        {
          get => datos_MODIFICACION_TARJETA.E_NUMERO_ASOCIACION;
          set => datos_MODIFICACION_TARJETA.E_NUMERO_ASOCIACION = value;
        }

        [Required(ErrorMessage = "El campo A C T I V A es requerido ")]
        [DisplayName("A C T I V A")]
        public Boolean L_ACTIVA
        {
          get => datos_MODIFICACION_TARJETA.L_ACTIVA;
          set => datos_MODIFICACION_TARJETA.L_ACTIVA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_TARJETA.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_TARJETA() => datos_MODIFICACION_TARJETA = new dald_MODIFICACION_TARJETA();

        public bll_MODIFICACION_TARJETA(MODELDeclara_V2.MODIFICACION_TARJETA MODIFICACION_TARJETA) => datos_MODIFICACION_TARJETA = new dald_MODIFICACION_TARJETA(MODIFICACION_TARJETA);

        public bll_MODIFICACION_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO) => datos_MODIFICACION_TARJETA = new dald_MODIFICACION_TARJETA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO);

        public bll_MODIFICACION_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_INSTITUCION, String V_NUMERO_CORTO, Decimal M_PAGOS, Decimal M_SALDO, String E_NUMERO_ASOCIACION, Boolean L_ACTIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_TARJETA = new dald_MODIFICACION_TARJETA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_INSTITUCION, V_NUMERO_CORTO, M_PAGOS, M_SALDO, E_NUMERO_ASOCIACION, L_ACTIVA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_TARJETA.update();
        }

        public void delete()
        {
            datos_MODIFICACION_TARJETA.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_TARJETA.reload();
        }

     #endregion

    }
}
