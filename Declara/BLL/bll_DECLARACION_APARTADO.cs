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
    public  class bll_DECLARACION_APARTADO : _bllSistema
    {

        internal dald_DECLARACION_APARTADO datos_DECLARACION_APARTADO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_DECLARACION_APARTADO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_DECLARACION_APARTADO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_DECLARACION_APARTADO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_DECLARACION_APARTADO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_APARTADO => datos_DECLARACION_APARTADO.NID_APARTADO;

        [DisplayName("")]
        public System.Nullable<Boolean> L_ESTADO
        {
          get => datos_DECLARACION_APARTADO.L_ESTADO;
          set => datos_DECLARACION_APARTADO.L_ESTADO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_APARTADO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_DECLARACION_APARTADO() => datos_DECLARACION_APARTADO = new dald_DECLARACION_APARTADO();

        public bll_DECLARACION_APARTADO(MODELDeclara_V2.DECLARACION_APARTADO DECLARACION_APARTADO) => datos_DECLARACION_APARTADO = new dald_DECLARACION_APARTADO(DECLARACION_APARTADO);

        public bll_DECLARACION_APARTADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_APARTADO) => datos_DECLARACION_APARTADO = new dald_DECLARACION_APARTADO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO);

        public bll_DECLARACION_APARTADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_APARTADO, System.Nullable<Boolean> L_ESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_DECLARACION_APARTADO = new dald_DECLARACION_APARTADO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_APARTADO, L_ESTADO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_DECLARACION_APARTADO.update();
        }

        public void delete()
        {
            datos_DECLARACION_APARTADO.delete();
        }

        public void reload()
        {
            datos_DECLARACION_APARTADO.reload();
        }

     #endregion

    }
}
