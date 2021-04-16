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
    public partial class blld_CAT_CODIGO_POSTAL : bll_CAT_CODIGO_POSTAL
    {

     #region *** Atributos ***


        #region * CAT_MUNICIPIO *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_MUNICIPIO => datos_CAT_CODIGO_POSTAL.V_MUNICIPIO;

        #endregion * CAT_MUNICIPIO *



     #endregion


     #region *** Constructores ***

        private blld_CAT_CODIGO_POSTAL()
        : base()
        {
        }

        public blld_CAT_CODIGO_POSTAL(MODELDeclara_V2.CAT_CODIGO_POSTAL CAT_CODIGO_POSTAL)
        : base(CAT_CODIGO_POSTAL)
        {
        }

        public  blld_CAT_CODIGO_POSTAL(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String CID_CODIGO_POSTAL, Int32 NID_COLONIA)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, CID_CODIGO_POSTAL, NID_COLONIA)
        {
        }

        public blld_CAT_CODIGO_POSTAL(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String CID_CODIGO_POSTAL, Int32 NID_COLONIA, String V_COLONIA)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, CID_CODIGO_POSTAL, NID_COLONIA, V_COLONIA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
