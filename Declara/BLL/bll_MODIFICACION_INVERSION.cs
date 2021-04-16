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
    public  class bll_MODIFICACION_INVERSION : _bllSistema
    {

        internal dald_MODIFICACION_INVERSION datos_MODIFICACION_INVERSION;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_INVERSION.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_INVERSION.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_INVERSION.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_INVERSION.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_INVERSION.NID_PATRIMONIO;

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo S A L D O_ A N T E R I O R es requerido ")]
        [DisplayName("S A L D O_ A N T E R I O R")]
        public Decimal M_SALDO_ANTERIOR
        {
          get => datos_MODIFICACION_INVERSION.M_SALDO_ANTERIOR;
          set => datos_MODIFICACION_INVERSION.M_SALDO_ANTERIOR = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo S A L D O_ A C T U A L es requerido ")]
        [DisplayName("S A L D O_ A C T U A L")]
        public Decimal M_SALDO_ACTUAL
        {
          get => datos_MODIFICACION_INVERSION.M_SALDO_ACTUAL;
          set => datos_MODIFICACION_INVERSION.M_SALDO_ACTUAL = value;
        }

        [Required(ErrorMessage = "El campo C A N C E L A D A es requerido ")]
        [DisplayName("C A N C E L A D A")]
        public Boolean L_CANCELADA
        {
          get => datos_MODIFICACION_INVERSION.L_CANCELADA;
          set => datos_MODIFICACION_INVERSION.L_CANCELADA = value;
        }

        [Required(ErrorMessage = "El campo M O D I F I C A D A es requerido ")]
        [DisplayName("M O D I F I C A D A")]
        public Boolean L_MODIFICADA
        {
          get => datos_MODIFICACION_INVERSION.L_MODIFICADA;
          set => datos_MODIFICACION_INVERSION.L_MODIFICADA = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_INVERSION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_INVERSION() => datos_MODIFICACION_INVERSION = new dald_MODIFICACION_INVERSION();

        public bll_MODIFICACION_INVERSION(MODELDeclara_V2.MODIFICACION_INVERSION MODIFICACION_INVERSION) => datos_MODIFICACION_INVERSION = new dald_MODIFICACION_INVERSION(MODIFICACION_INVERSION);

        public bll_MODIFICACION_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_INVERSION = new dald_MODIFICACION_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Decimal M_SALDO_ANTERIOR, Decimal M_SALDO_ACTUAL, Boolean L_CANCELADA, Boolean L_MODIFICADA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_INVERSION = new dald_MODIFICACION_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, M_SALDO_ANTERIOR, M_SALDO_ACTUAL, L_CANCELADA, L_MODIFICADA, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_INVERSION.update();
        }

        public void delete()
        {
            datos_MODIFICACION_INVERSION.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_INVERSION.reload();
        }

     #endregion

    }
}
