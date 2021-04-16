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
    public partial class blld_CAT_ENTIDAD_FEDERATIVA : bll_CAT_ENTIDAD_FEDERATIVA
    {

     #region *** Atributos ***


        #region * CAT_PAIS *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_PAIS => datos_CAT_ENTIDAD_FEDERATIVA.V_PAIS;


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_NACIONALIDAD_M => datos_CAT_ENTIDAD_FEDERATIVA.V_NACIONALIDAD_M;


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_NACIONALIDAD_F => datos_CAT_ENTIDAD_FEDERATIVA.V_NACIONALIDAD_F;

        #endregion * CAT_PAIS *



     #endregion


     #region *** Constructores ***

        //private blld_CAT_ENTIDAD_FEDERATIVA()
        //: base()
        //{
        //}

        public blld_CAT_ENTIDAD_FEDERATIVA(MODELDeclara_V2.CAT_ENTIDAD_FEDERATIVA CAT_ENTIDAD_FEDERATIVA)
        : base(CAT_ENTIDAD_FEDERATIVA)
        {
        }

        public  blld_CAT_ENTIDAD_FEDERATIVA(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA)
        {
        }

        public blld_CAT_ENTIDAD_FEDERATIVA(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_ENTIDAD_FEDERATIVA)
        : base(NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_ENTIDAD_FEDERATIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
