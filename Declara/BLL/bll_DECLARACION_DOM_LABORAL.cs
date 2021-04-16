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
    public  class bll_DECLARACION_DOM_LABORAL : _bllSistema
    {

        internal dald_DECLARACION_DOM_LABORAL datos_DECLARACION_DOM_LABORAL;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_DECLARACION_DOM_LABORAL.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_DECLARACION_DOM_LABORAL.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_DECLARACION_DOM_LABORAL.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DECLARACION => datos_DECLARACION_DOM_LABORAL.NID_DECLARACION;

        [StringLength(5)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String C_CODIGO_POSTAL
        {
          get => datos_DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL;
          set => datos_DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS
        {
          get => datos_DECLARACION_DOM_LABORAL.NID_PAIS;
          set => datos_DECLARACION_DOM_LABORAL.NID_PAIS = value;
        }

        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_ENTIDAD_FEDERATIVA
        {
          get => datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA;
          set => datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA = value;
        }

        [StringLength(3)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_MUNICIPIO
        {
          get => datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIO;
          set => datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIO = value;
        }

        [StringLength(255)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_COLONIA
        {
          get => datos_DECLARACION_DOM_LABORAL.V_COLONIA;
          set => datos_DECLARACION_DOM_LABORAL.V_COLONIA = value;
        }

        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_DOMICILIO
        {
          get => datos_DECLARACION_DOM_LABORAL.V_DOMICILIO;
          set => datos_DECLARACION_DOM_LABORAL.V_DOMICILIO = value;
        }

        [StringLength(511)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_CORREO_LABORAL
        {
          get => datos_DECLARACION_DOM_LABORAL.V_CORREO_LABORAL;
          set => datos_DECLARACION_DOM_LABORAL.V_CORREO_LABORAL = value;
        }

        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TEL_LABORAL
        {
          get => datos_DECLARACION_DOM_LABORAL.V_TEL_LABORAL;
          set => datos_DECLARACION_DOM_LABORAL.V_TEL_LABORAL = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_DOM_LABORAL.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_DECLARACION_DOM_LABORAL() => datos_DECLARACION_DOM_LABORAL = new dald_DECLARACION_DOM_LABORAL();

        public bll_DECLARACION_DOM_LABORAL(MODELDeclara_V2.DECLARACION_DOM_LABORAL DECLARACION_DOM_LABORAL) => datos_DECLARACION_DOM_LABORAL = new dald_DECLARACION_DOM_LABORAL(DECLARACION_DOM_LABORAL);

        public bll_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) => datos_DECLARACION_DOM_LABORAL = new dald_DECLARACION_DOM_LABORAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

        public bll_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_CORREO_LABORAL, String V_TEL_LABORAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_DECLARACION_DOM_LABORAL = new dald_DECLARACION_DOM_LABORAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_CORREO_LABORAL, V_TEL_LABORAL, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_DECLARACION_DOM_LABORAL.update();
        }

        public void delete()
        {
            datos_DECLARACION_DOM_LABORAL.delete();
        }

        public void reload()
        {
            datos_DECLARACION_DOM_LABORAL.reload();
        }

     #endregion

    }
}
