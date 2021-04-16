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
    public  class bll_DECLARACION_RESTRICCIONES : _bllSistema
    {

        internal dald_DECLARACION_RESTRICCIONES datos_DECLARACION_RESTRICCIONES;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_DECLARACION_RESTRICCIONES.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_DECLARACION_RESTRICCIONES.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_DECLARACION_RESTRICCIONES.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_DECLARACION_RESTRICCIONES.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_RESTRICCION => datos_DECLARACION_RESTRICCIONES.NID_RESTRICCION;

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public System.Nullable<Boolean> L_RESPUESTA
        {
          get => datos_DECLARACION_RESTRICCIONES.L_RESPUESTA;
          set => datos_DECLARACION_RESTRICCIONES.L_RESPUESTA = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_AUTO
        {
          get => datos_DECLARACION_RESTRICCIONES.L_AUTO;
          set => datos_DECLARACION_RESTRICCIONES.L_AUTO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_RESTRICCIONES.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_DECLARACION_RESTRICCIONES() => datos_DECLARACION_RESTRICCIONES = new dald_DECLARACION_RESTRICCIONES();

        public bll_DECLARACION_RESTRICCIONES(MODELDeclara_V2.DECLARACION_RESTRICCIONES DECLARACION_RESTRICCIONES) => datos_DECLARACION_RESTRICCIONES = new dald_DECLARACION_RESTRICCIONES(DECLARACION_RESTRICCIONES);

        public bll_DECLARACION_RESTRICCIONES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION) => datos_DECLARACION_RESTRICCIONES = new dald_DECLARACION_RESTRICCIONES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION);

        public bll_DECLARACION_RESTRICCIONES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION, Boolean L_RESPUESTA, Boolean L_AUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_DECLARACION_RESTRICCIONES = new dald_DECLARACION_RESTRICCIONES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION, L_RESPUESTA, L_AUTO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_DECLARACION_RESTRICCIONES.update();
        }

        public void delete()
        {
            datos_DECLARACION_RESTRICCIONES.delete();
        }

        public void reload()
        {
            datos_DECLARACION_RESTRICCIONES.reload();
        }

     #endregion

    }
}
