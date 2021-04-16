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
    public  class bll_MODIFICACION_MUEBLE_TITULAR : _bllSistema
    {

        internal dald_MODIFICACION_MUEBLE_TITULAR datos_MODIFICACION_MUEBLE_TITULAR;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo I D_ N O M B R E es requerido ")]
        [DisplayName("I D_ N O M B R E")]
        public String VID_NOMBRE => datos_MODIFICACION_MUEBLE_TITULAR.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo I D_ F E C H A es requerido ")]
        [DisplayName("I D_ F E C H A")]
        public String VID_FECHA => datos_MODIFICACION_MUEBLE_TITULAR.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo I D_ H O M O C L A V E es requerido ")]
        [DisplayName("I D_ H O M O C L A V E")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_MUEBLE_TITULAR.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E C L A R A C I O N es requerido ")]
        [DisplayName("I D_ D E C L A R A C I O N")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_MUEBLE_TITULAR.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo I D_ P A T R I M O N I O es requerido ")]
        [DisplayName("I D_ P A T R I M O N I O")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_MUEBLE_TITULAR.NID_PATRIMONIO;

        [Key]
        [Required(ErrorMessage = "El campo I D_ D E P E N D I E N T E es requerido ")]
        [DisplayName("I D_ D E P E N D I E N T E")]
        public Int32 NID_DEPENDIENTE => datos_MODIFICACION_MUEBLE_TITULAR.NID_DEPENDIENTE;



        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_MUEBLE_TITULAR.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_MUEBLE_TITULAR() => datos_MODIFICACION_MUEBLE_TITULAR = new dald_MODIFICACION_MUEBLE_TITULAR();

        public bll_MODIFICACION_MUEBLE_TITULAR(MODELDeclara_V2.MODIFICACION_MUEBLE_TITULAR MODIFICACION_MUEBLE_TITULAR) => datos_MODIFICACION_MUEBLE_TITULAR = new dald_MODIFICACION_MUEBLE_TITULAR(MODIFICACION_MUEBLE_TITULAR);

        public bll_MODIFICACION_MUEBLE_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE) => datos_MODIFICACION_MUEBLE_TITULAR = new dald_MODIFICACION_MUEBLE_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE);

        public bll_MODIFICACION_MUEBLE_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_MUEBLE_TITULAR = new dald_MODIFICACION_MUEBLE_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_MUEBLE_TITULAR.update();
        }

        public void delete()
        {
            datos_MODIFICACION_MUEBLE_TITULAR.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_MUEBLE_TITULAR.reload();
        }

     #endregion

    }
}
