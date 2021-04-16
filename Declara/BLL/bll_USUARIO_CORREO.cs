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
    public  class bll_USUARIO_CORREO : _bllSistema
    {

        internal dald_USUARIO_CORREO datos_USUARIO_CORREO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_USUARIO_CORREO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_USUARIO_CORREO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_USUARIO_CORREO.VID_HOMOCLAVE;

        [Key]
        [StringLength(255)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_CORREO => datos_USUARIO_CORREO.V_CORREO;

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_PRINCIPAL
        {
          get => datos_USUARIO_CORREO.L_PRINCIPAL;
          set => datos_USUARIO_CORREO.L_PRINCIPAL = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_ACTIVO
        {
          get => datos_USUARIO_CORREO.L_ACTIVO;
          set => datos_USUARIO_CORREO.L_ACTIVO = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_CONFIRMADO
        {
          get => datos_USUARIO_CORREO.L_CONFIRMADO;
          set => datos_USUARIO_CORREO.L_CONFIRMADO = value;
        }

        public Int32 N_CODIGO
        {
            get => datos_USUARIO_CORREO.N_CODIGO;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_USUARIO_CORREO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_USUARIO_CORREO() => datos_USUARIO_CORREO = new dald_USUARIO_CORREO();

        public bll_USUARIO_CORREO(MODELDeclara_V2.USUARIO_CORREO USUARIO_CORREO) => datos_USUARIO_CORREO = new dald_USUARIO_CORREO(USUARIO_CORREO);

        public bll_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO) => datos_USUARIO_CORREO = new dald_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO);

        public bll_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Boolean L_PRINCIPAL, Boolean L_ACTIVO, Boolean L_CONFIRMADO,Int32 N_CODIGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_USUARIO_CORREO = new dald_USUARIO_CORREO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO, L_PRINCIPAL, L_ACTIVO, L_CONFIRMADO, N_CODIGO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_USUARIO_CORREO.update();
        }

        public void delete()
        {
            datos_USUARIO_CORREO.delete();
        }

        public void reload()
        {
            datos_USUARIO_CORREO.reload();
        }

     #endregion

    }
}
