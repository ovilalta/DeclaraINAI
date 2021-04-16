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
    public partial class blld_CAT_MUNICIPIO : bll_CAT_MUNICIPIO
    {

     #region *** Atributos ***


        #region * CAT_ENTIDAD_FEDERATIVA *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ENTIDAD_FEDERATIVA => datos_CAT_MUNICIPIO.V_ENTIDAD_FEDERATIVA;

        #endregion * CAT_ENTIDAD_FEDERATIVA *



     #endregion


     #region *** Constructores ***

        private blld_CAT_MUNICIPIO()
        : base()
        {
        }

        public blld_CAT_MUNICIPIO(MODELDeclara_V2.CAT_MUNICIPIO CAT_MUNICIPIO)
        : base(CAT_MUNICIPIO)
        {
        }

        public  blld_CAT_MUNICIPIO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO)
        {
        }

        public blld_CAT_MUNICIPIO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_MUNICIPIO)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_MUNICIPIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
