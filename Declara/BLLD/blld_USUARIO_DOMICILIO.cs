using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public partial class blld_USUARIO_DOMICILIO : bll_USUARIO_DOMICILIO
    {

     #region *** Atributos ***


        #region * CAT_MUNICIPIO *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_MUNICIPIO => datos_USUARIO_DOMICILIO.V_MUNICIPIO;

        #endregion * CAT_MUNICIPIO *


        #region * CAT_TIPO_DOMICILIO *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO_DOMICILIO => datos_USUARIO_DOMICILIO.V_TIPO_DOMICILIO;

        #endregion * CAT_TIPO_DOMICILIO *



     #endregion


     #region *** Constructores ***

        private blld_USUARIO_DOMICILIO()
        : base()
        {
        }

        public blld_USUARIO_DOMICILIO(MODELDeclara_V2.USUARIO_DOMICILIO USUARIO_DOMICILIO)
        : base(USUARIO_DOMICILIO)
        {
        }

        public  blld_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DOMICILIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO)
        {
        }

        public blld_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DOMICILIO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String C_CODIGO_POSTAL, String E_DIRECCION, Int32 NID_TIPO_DOMICILIO, Boolean L_ACTIVO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, C_CODIGO_POSTAL, E_DIRECCION, NID_TIPO_DOMICILIO, L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
