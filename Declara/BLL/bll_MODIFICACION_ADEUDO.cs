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
    public  class bll_MODIFICACION_ADEUDO : _bllSistema
    {

        internal dald_MODIFICACION_ADEUDO datos_MODIFICACION_ADEUDO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_ADEUDO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_ADEUDO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_ADEUDO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_ADEUDO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_ADEUDO.NID_PATRIMONIO;

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo P A G O S es requerido ")]
        [DisplayName("P A G O S")]
        public Decimal M_PAGOS
        {
          get => datos_MODIFICACION_ADEUDO.M_PAGOS;
          set => datos_MODIFICACION_ADEUDO.M_PAGOS = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo S A L D O S es requerido ")]
        [DisplayName("S A L D O S")]
        public Decimal M_SALDOS
        {
          get => datos_MODIFICACION_ADEUDO.M_SALDOS;
          set => datos_MODIFICACION_ADEUDO.M_SALDOS = value;
        }

        [Required(ErrorMessage = "El campo C A N C E L A D O es requerido ")]
        [DisplayName("C A N C E L A D O")]
        public Boolean L_CANCELADO
        {
          get => datos_MODIFICACION_ADEUDO.L_CANCELADO;
          set => datos_MODIFICACION_ADEUDO.L_CANCELADO = value;
        }

        [Required(ErrorMessage = "El campo M O D I F I C A D O es requerido ")]
        [DisplayName("M O D I F I C A D O")]
        public Boolean L_MODIFICADO
        {
          get => datos_MODIFICACION_ADEUDO.L_MODIFICADO;
          set => datos_MODIFICACION_ADEUDO.L_MODIFICADO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_ADEUDO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_ADEUDO() => datos_MODIFICACION_ADEUDO = new dald_MODIFICACION_ADEUDO();

        public bll_MODIFICACION_ADEUDO(MODELDeclara_V2.MODIFICACION_ADEUDO MODIFICACION_ADEUDO) => datos_MODIFICACION_ADEUDO = new dald_MODIFICACION_ADEUDO(MODIFICACION_ADEUDO);

        public bll_MODIFICACION_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_ADEUDO = new dald_MODIFICACION_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Decimal M_PAGOS, Decimal M_SALDOS, Boolean L_CANCELADO, Boolean L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_ADEUDO = new dald_MODIFICACION_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, M_PAGOS, M_SALDOS, L_CANCELADO, L_MODIFICADO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_ADEUDO.update();
        }

        public void delete()
        {
            datos_MODIFICACION_ADEUDO.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_ADEUDO.reload();
        }

     #endregion

    }
}
