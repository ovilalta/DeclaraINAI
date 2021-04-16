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
    public  class bll_MODIFICACION_GASTO : _bllSistema
    {

        internal dald_MODIFICACION_GASTO datos_MODIFICACION_GASTO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_MODIFICACION_GASTO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_MODIFICACION_GASTO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_MODIFICACION_GASTO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_MODIFICACION_GASTO.NID_DECLARACION;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_GASTO => datos_MODIFICACION_GASTO.NID_GASTO;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_GASTO
        {
            get => datos_MODIFICACION_GASTO.NID_TIPO_GASTO;
            set => datos_MODIFICACION_GASTO.NID_TIPO_GASTO = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_GASTO
        {
          get => datos_MODIFICACION_GASTO.V_GASTO;
          set => datos_MODIFICACION_GASTO.V_GASTO = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Decimal M_GASTO
        {
          get => datos_MODIFICACION_GASTO.M_GASTO;
          set => datos_MODIFICACION_GASTO.M_GASTO = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_AUTOGENERADO
        {
          get => datos_MODIFICACION_GASTO.L_AUTOGENERADO;
          set => datos_MODIFICACION_GASTO.L_AUTOGENERADO = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [DisplayName("")]
        public System.Nullable<Int32> NID_PATRIMONIO_ASC
        {
          get => datos_MODIFICACION_GASTO.NID_PATRIMONIO_ASC;
          set => datos_MODIFICACION_GASTO.NID_PATRIMONIO_ASC = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_GASTO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_MODIFICACION_GASTO() => datos_MODIFICACION_GASTO = new dald_MODIFICACION_GASTO();

        public bll_MODIFICACION_GASTO(MODELDeclara_V2.MODIFICACION_GASTO MODIFICACION_GASTO) => datos_MODIFICACION_GASTO = new dald_MODIFICACION_GASTO(MODIFICACION_GASTO);

        public bll_MODIFICACION_GASTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_GASTO) => datos_MODIFICACION_GASTO = new dald_MODIFICACION_GASTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_GASTO);

        public bll_MODIFICACION_GASTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_GASTO,Int32 NID_TIPO_GASTO, String V_GASTO, Decimal M_GASTO, Boolean L_AUTOGENERADO, System.Nullable<Int32> NID_PATRIMONIO_ASC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_MODIFICACION_GASTO = new dald_MODIFICACION_GASTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_GASTO, NID_TIPO_GASTO, V_GASTO, M_GASTO, L_AUTOGENERADO, NID_PATRIMONIO_ASC, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_MODIFICACION_GASTO.update();
        }

        public void delete()
        {
            datos_MODIFICACION_GASTO.delete();
        }

        public void reload()
        {
            datos_MODIFICACION_GASTO.reload();
        }

     #endregion

    }
}
