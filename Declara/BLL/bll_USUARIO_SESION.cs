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
    public  class bll_USUARIO_SESION : _bllSistema
    {

        internal dald_USUARIO_SESION datos_USUARIO_SESION;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_USUARIO_SESION.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_USUARIO_SESION.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_USUARIO_SESION.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_SESION => datos_USUARIO_SESION.NID_SESION;

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_IP
        {
          get => datos_USUARIO_SESION.V_IP;
          set => datos_USUARIO_SESION.V_IP = value;
        }

        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_MAQUINA_USUARIO
        {
          get => datos_USUARIO_SESION.V_MAQUINA_USUARIO;
          set => datos_USUARIO_SESION.V_MAQUINA_USUARIO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_INICIO
        {
          get => datos_USUARIO_SESION.F_INICIO;
          set => datos_USUARIO_SESION.F_INICIO = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_FIN
        {
          get => datos_USUARIO_SESION.F_FIN;
          set => datos_USUARIO_SESION.F_FIN = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_USUARIO_SESION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_USUARIO_SESION() => datos_USUARIO_SESION = new dald_USUARIO_SESION();

        public bll_USUARIO_SESION(MODELDeclara_V2.USUARIO_SESION USUARIO_SESION) => datos_USUARIO_SESION = new dald_USUARIO_SESION(USUARIO_SESION);

        public bll_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_SESION) => datos_USUARIO_SESION = new dald_USUARIO_SESION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION);

        public bll_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_SESION, String V_IP, String V_MAQUINA_USUARIO, DateTime F_INICIO, DateTime F_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_USUARIO_SESION = new dald_USUARIO_SESION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION, V_IP, V_MAQUINA_USUARIO, F_INICIO, F_FIN, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_USUARIO_SESION.update();
        }

        public void delete()
        {
            datos_USUARIO_SESION.delete();
        }

        public void reload()
        {
            datos_USUARIO_SESION.reload();
        }

     #endregion

    }
}
