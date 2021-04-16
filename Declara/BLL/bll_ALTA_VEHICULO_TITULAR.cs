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
    public  class bll_ALTA_VEHICULO_TITULAR : _bllSistema
    {

        internal dald_ALTA_VEHICULO_TITULAR datos_ALTA_VEHICULO_TITULAR;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_ALTA_VEHICULO_TITULAR.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_ALTA_VEHICULO_TITULAR.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_ALTA_VEHICULO_TITULAR.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_ALTA_VEHICULO_TITULAR.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_VEHICULO => datos_ALTA_VEHICULO_TITULAR.NID_VEHICULO;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DEPENDIENTE => datos_ALTA_VEHICULO_TITULAR.NID_DEPENDIENTE;




        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_VEHICULO_TITULAR.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_ALTA_VEHICULO_TITULAR() => datos_ALTA_VEHICULO_TITULAR = new dald_ALTA_VEHICULO_TITULAR();

        public bll_ALTA_VEHICULO_TITULAR(MODELDeclara_V2.ALTA_VEHICULO_TITULAR ALTA_VEHICULO_TITULAR) => datos_ALTA_VEHICULO_TITULAR = new dald_ALTA_VEHICULO_TITULAR(ALTA_VEHICULO_TITULAR);

        public bll_ALTA_VEHICULO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO, Int32 NID_DEPENDIENTE) => datos_ALTA_VEHICULO_TITULAR = new dald_ALTA_VEHICULO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, NID_DEPENDIENTE);

        public bll_ALTA_VEHICULO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_ALTA_VEHICULO_TITULAR = new dald_ALTA_VEHICULO_TITULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO, NID_DEPENDIENTE, L_DIF, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_ALTA_VEHICULO_TITULAR.update();
        }

        public void delete()
        {
            datos_ALTA_VEHICULO_TITULAR.delete();
        }

        public void reload()
        {
            datos_ALTA_VEHICULO_TITULAR.reload();
        }

     #endregion

    }
}
