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
    public  class bll_USUARIO_DOMICILIO : _bllSistema
    {

        internal dald_USUARIO_DOMICILIO datos_USUARIO_DOMICILIO;

     #region *** Atributos ***

        [Key]
        [StringLength(4)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_NOMBRE => datos_USUARIO_DOMICILIO.VID_NOMBRE;

        [Key]
        [StringLength(6)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_FECHA => datos_USUARIO_DOMICILIO.VID_FECHA;

        [Key]
        [StringLength(3)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String VID_HOMOCLAVE => datos_USUARIO_DOMICILIO.VID_HOMOCLAVE;

        [Key]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_DOMICILIO => datos_USUARIO_DOMICILIO.NID_DOMICILIO;

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_PAIS
        {
          get => datos_USUARIO_DOMICILIO.NID_PAIS;
          set => datos_USUARIO_DOMICILIO.NID_PAIS = value;
        }

        [StringLength(2)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_ENTIDAD_FEDERATIVA
        {
          get => datos_USUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVA;
          set => datos_USUARIO_DOMICILIO.CID_ENTIDAD_FEDERATIVA = value;
        }

        [StringLength(3)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String CID_MUNICIPIO
        {
          get => datos_USUARIO_DOMICILIO.CID_MUNICIPIO;
          set => datos_USUARIO_DOMICILIO.CID_MUNICIPIO = value;
        }

        [StringLength(5)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String C_CODIGO_POSTAL
        {
          get => datos_USUARIO_DOMICILIO.C_CODIGO_POSTAL;
          set => datos_USUARIO_DOMICILIO.C_CODIGO_POSTAL = value;
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String E_DIRECCION
        {
          get => datos_USUARIO_DOMICILIO.E_DIRECCION;
          set => datos_USUARIO_DOMICILIO.E_DIRECCION = value;
        }

        [Range(Int32.MinValue, Int32.MaxValue, ErrorMessage = "Por favor ingresa un número válido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor ingresa un número válido")]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Int32 NID_TIPO_DOMICILIO
        {
          get => datos_USUARIO_DOMICILIO.NID_TIPO_DOMICILIO;
          set => datos_USUARIO_DOMICILIO.NID_TIPO_DOMICILIO = value;
        }

        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_ACTIVO
        {
          get => datos_USUARIO_DOMICILIO.L_ACTIVO;
          set => datos_USUARIO_DOMICILIO.L_ACTIVO = value;
        }


        #region aux

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_USUARIO_DOMICILIO.lEsNuevoRegistro; }
        }

        #endregion 



     #endregion


     #region *** Constructores ***

        public bll_USUARIO_DOMICILIO() => datos_USUARIO_DOMICILIO = new dald_USUARIO_DOMICILIO();

        public bll_USUARIO_DOMICILIO(MODELDeclara_V2.USUARIO_DOMICILIO USUARIO_DOMICILIO) => datos_USUARIO_DOMICILIO = new dald_USUARIO_DOMICILIO(USUARIO_DOMICILIO);

        public bll_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DOMICILIO) => datos_USUARIO_DOMICILIO = new dald_USUARIO_DOMICILIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO);

        public bll_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DOMICILIO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String C_CODIGO_POSTAL, String E_DIRECCION, Int32 NID_TIPO_DOMICILIO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente) => datos_USUARIO_DOMICILIO = new dald_USUARIO_DOMICILIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, C_CODIGO_POSTAL, E_DIRECCION, NID_TIPO_DOMICILIO, L_ACTIVO, lOpcionesRegistroExistente);

     #endregion


     #region *** Metodos ***

        public void update()
        {
            datos_USUARIO_DOMICILIO.update();
        }

        public void delete()
        {
            datos_USUARIO_DOMICILIO.delete();
        }

        public void reload()
        {
            datos_USUARIO_DOMICILIO.reload();
        }

     #endregion

    }
}
