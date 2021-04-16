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
    public  class bll_MODIFICACION_INMUEBLE_ADEUDO : _bllSistema
    {

        internal dald_MODIFICACION_INMUEBLE_ADEUDO datos_MODIFICACION_INMUEBLE_ADEUDO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_INMUEBLE_ADEUDO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_INMUEBLE_ADEUDO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_INMUEBLE_ADEUDO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_INMUEBLE_ADEUDO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_INMUEBLE_ADEUDO.NID_PATRIMONIO;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O_ A D E U D O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O_ A D E U D O")]
        public Int32 NID_PATRIMONIO_ADEUDO => datos_MODIFICACION_INMUEBLE_ADEUDO.NID_PATRIMONIO_ADEUDO;



        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_INMUEBLE_ADEUDO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_INMUEBLE_ADEUDO() => datos_MODIFICACION_INMUEBLE_ADEUDO = new dald_MODIFICACION_INMUEBLE_ADEUDO();

        public bll_MODIFICACION_INMUEBLE_ADEUDO(MODELDeclara_V2.MODIFICACION_INMUEBLE_ADEUDO MODIFICACION_INMUEBLE_ADEUDO) => datos_MODIFICACION_INMUEBLE_ADEUDO = new dald_MODIFICACION_INMUEBLE_ADEUDO(MODIFICACION_INMUEBLE_ADEUDO);

        public bll_MODIFICACION_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO) => datos_MODIFICACION_INMUEBLE_ADEUDO = new dald_MODIFICACION_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO);

        public bll_MODIFICACION_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_INMUEBLE_ADEUDO = new dald_MODIFICACION_INMUEBLE_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO, L_DIF, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_INMUEBLE_ADEUDO.update();
        }

        public void delete()
        {
            datos_MODIFICACION_INMUEBLE_ADEUDO.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_INMUEBLE_ADEUDO.reload();
        }

     #endregion

    }
}
