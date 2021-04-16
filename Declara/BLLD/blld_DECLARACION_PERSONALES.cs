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
    public partial class blld_DECLARACION_PERSONALES : bll_DECLARACION_PERSONALES
    {

     #region *** Atributos ***


        #region * CAT_ESTADO_CIVIL *


        [StringLength(511)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_ESTADO_CIVIL => datos_DECLARACION_PERSONALES.V_ESTADO_CIVIL;

        #endregion * CAT_ESTADO_CIVIL *



     #endregion


     #region *** Constructores ***

        private blld_DECLARACION_PERSONALES()
        : base()
        {
        }

        public blld_DECLARACION_PERSONALES(MODELDeclara_V2.DECLARACION_PERSONALES DECLARACION_PERSONALES)
        : base(DECLARACION_PERSONALES)
        {
        }

        public  blld_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION)
        {
        }

        //public blld_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_GENERO, String C_CURP, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String NID_NACIONALIDAD, Int32 NID_ESTADO_CIVIL)
        //: base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_GENERO, C_CURP, NID_PAIS, CID_ENTIDAD_FEDERATIVA, NID_NACIONALIDAD, NID_ESTADO_CIVIL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        //{
        //}


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
