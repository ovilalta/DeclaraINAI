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
    public partial class blld_DECLARACION_RESTRICCIONES : bll_DECLARACION_RESTRICCIONES
    {

     #region *** Atributos ***


        #region * CAT_RESTRICCIONES *


        [StringLength(255)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_RESTRICCION => datos_DECLARACION_RESTRICCIONES.V_RESTRICCION;


        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public Boolean L_VIGENTE => datos_DECLARACION_RESTRICCIONES.L_VIGENTE;

        #endregion * CAT_RESTRICCIONES *



     #endregion


     #region *** Constructores ***

        private blld_DECLARACION_RESTRICCIONES()
        : base()
        {
        }

        public blld_DECLARACION_RESTRICCIONES(MODELDeclara_V2.DECLARACION_RESTRICCIONES DECLARACION_RESTRICCIONES)
        : base(DECLARACION_RESTRICCIONES)
        {
        }

        public  blld_DECLARACION_RESTRICCIONES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION)
        {
        }

        public blld_DECLARACION_RESTRICCIONES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION, Boolean L_RESPUESTA, Boolean L_AUTO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION, L_RESPUESTA, L_AUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
