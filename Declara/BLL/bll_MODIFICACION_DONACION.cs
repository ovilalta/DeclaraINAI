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
    public  class bll_MODIFICACION_DONACION : _bllSistema
    {

        internal dald_MODIFICACION_DONACION datos_MODIFICACION_DONACION;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_MODIFICACION_DONACION.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_MODIFICACION_DONACION.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_DONACION.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_DONACION.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PATRIMONIO => datos_MODIFICACION_DONACION.NID_PATRIMONIO;

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_ESPECIFICA
        {
          get => datos_MODIFICACION_DONACION.E_ESPECIFICA;
          set => datos_MODIFICACION_DONACION.E_ESPECIFICA = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_BENIFICIARIO
        {
            get => datos_MODIFICACION_DONACION.E_BENIFICIARIO;
            set => datos_MODIFICACION_DONACION.E_BENIFICIARIO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_DONACION.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_DONACION() => datos_MODIFICACION_DONACION = new dald_MODIFICACION_DONACION();

        public bll_MODIFICACION_DONACION(MODELDeclara_V2.MODIFICACION_DONACION MODIFICACION_DONACION) => datos_MODIFICACION_DONACION = new dald_MODIFICACION_DONACION(MODIFICACION_DONACION);

        public bll_MODIFICACION_DONACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) => datos_MODIFICACION_DONACION = new dald_MODIFICACION_DONACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);

        public bll_MODIFICACION_DONACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, String V_ESPECIFICA,String E_BENIFICIARIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_DONACION = new dald_MODIFICACION_DONACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, V_ESPECIFICA, E_BENIFICIARIO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_DONACION.update();
        }

        public void delete()
        {
            datos_MODIFICACION_DONACION.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_DONACION.reload();
        }

     #endregion

    }
}
