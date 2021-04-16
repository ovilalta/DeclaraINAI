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
    public  class bll_PATRIMONIO_TITULAR : _bllSistema
    {

        internal dald_PATRIMONIO_TITULAR datos_PATRIMONIO_TITULAR;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_PATRIMONIO_TITULAR.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_PATRIMONIO_TITULAR.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_PATRIMONIO_TITULAR.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_PATRIMONIO_TITULAR.NID_PATRIMONIO;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DEPENDIENTE => datos_PATRIMONIO_TITULAR.NID_DEPENDIENTE;



        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_PATRIMONIO_TITULAR.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_PATRIMONIO_TITULAR() => datos_PATRIMONIO_TITULAR = new dald_PATRIMONIO_TITULAR();

        public bll_PATRIMONIO_TITULAR(MODELDeclara_V2.PATRIMONIO_TITULAR PATRIMONIO_TITULAR) => datos_PATRIMONIO_TITULAR = new dald_PATRIMONIO_TITULAR(PATRIMONIO_TITULAR);

        public bll_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE) => datos_PATRIMONIO_TITULAR = new dald_PATRIMONIO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE);

        public bll_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_PATRIMONIO_TITULAR = new dald_PATRIMONIO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, L_DIF, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_PATRIMONIO_TITULAR.update();
        }

        public void delete()
        {
            datos_PATRIMONIO_TITULAR.delete();
        }

        public void reload()
        {
            datos_PATRIMONIO_TITULAR.reload();
        }

     #endregion

    }
}
