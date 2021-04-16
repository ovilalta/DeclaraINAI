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
    public  class bll_USUARIO_REC_PASS : _bllSistema
    {

        internal dald_USUARIO_REC_PASS datos_USUARIO_REC_PASS;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_USUARIO_REC_PASS.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_USUARIO_REC_PASS.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_USUARIO_REC_PASS.VID_HOMOCLAVE;

        [Key]
        [StringLength(255)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_CORREO => datos_USUARIO_REC_PASS.V_CORREO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 N_USOS
        {
          get => datos_USUARIO_REC_PASS.N_USOS;
          set => datos_USUARIO_REC_PASS.N_USOS = value;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public DateTime F_SOLICITUD
        {
          get => datos_USUARIO_REC_PASS.F_SOLICITUD;
          set => datos_USUARIO_REC_PASS.F_SOLICITUD = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_USUARIO_REC_PASS.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_USUARIO_REC_PASS() => datos_USUARIO_REC_PASS = new dald_USUARIO_REC_PASS();

        public bll_USUARIO_REC_PASS(MODELDeclara_V2.USUARIO_REC_PASS USUARIO_REC_PASS) => datos_USUARIO_REC_PASS = new dald_USUARIO_REC_PASS(USUARIO_REC_PASS);

        public bll_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO) => datos_USUARIO_REC_PASS = new dald_USUARIO_REC_PASS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO);

        public bll_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Int32 N_USOS, DateTime F_SOLICITUD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_USUARIO_REC_PASS = new dald_USUARIO_REC_PASS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, N_USOS, F_SOLICITUD, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_USUARIO_REC_PASS.update();
        }

        public void delete()
        {
            datos_USUARIO_REC_PASS.delete();
        }

        public void reload()
        {
            datos_USUARIO_REC_PASS.reload();
        }

     #endregion

    }
}
