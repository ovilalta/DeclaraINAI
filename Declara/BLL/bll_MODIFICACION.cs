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
    public  class bll_MODIFICACION : _bllSistema
    {

        internal dald_MODIFICACION datos_MODIFICACION;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_MODIFICACION.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_MODIFICACION.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_MODIFICACION.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_MODIFICACION.NID_DECLARACION;

        [DisplayName("")]
        public System.Nullable<Boolean> L_PRESENTO_DEC
        {
          get => datos_MODIFICACION.L_PRESENTO_DEC;
          set => datos_MODIFICACION.L_PRESENTO_DEC = value;
        }


        public System.Nullable<DateTime> F_INICIO
        {
            get => datos_MODIFICACION.F_INICIO;
            set => datos_MODIFICACION.F_INICIO = value;
        }

        public System.Nullable<DateTime> F_FIN
        {
            get => datos_MODIFICACION.F_FIN;
            set => datos_MODIFICACION.F_FIN = value;
        }

        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION() => datos_MODIFICACION = new dald_MODIFICACION();

        public bll_MODIFICACION(MODELDeclara_V2.MODIFICACION MODIFICACION) => datos_MODIFICACION = new dald_MODIFICACION(MODIFICACION);

        public bll_MODIFICACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) => datos_MODIFICACION = new dald_MODIFICACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

        public bll_MODIFICACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, System.Nullable<Boolean> L_PRESENTO_DEC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION = new dald_MODIFICACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, L_PRESENTO_DEC, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION.update();
        }

        public void delete()
        {
            datos_MODIFICACION.delete();
        }

        public void reload()
        {
            datos_MODIFICACION.reload();
        }

     #endregion

    }
}
