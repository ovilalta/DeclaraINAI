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
    public partial class blld_CONFLICTO_RESPUESTA : bll_CONFLICTO_RESPUESTA
    {

     #region *** Atributos ***


        #region * CAT_CONFLICTO_PREGUNTA *


        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo R U B R O es requerido ")]
        [DisplayName("R U B R O")]
        public String V_RUBRO => datos_CONFLICTO_RESPUESTA.V_RUBRO;


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        public String C_INICIO => datos_CONFLICTO_RESPUESTA.C_INICIO;


        [StringLength(4)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo F I N es requerido ")]
        [DisplayName("F I N")]
        public String C_FIN => datos_CONFLICTO_RESPUESTA.C_FIN;

        #endregion * CAT_CONFLICTO_PREGUNTA *



     #endregion


     #region *** Constructores ***

        private blld_CONFLICTO_RESPUESTA()
        : base()
        {
        }

        public blld_CONFLICTO_RESPUESTA(MODELDeclara_V2.CONFLICTO_RESPUESTA CONFLICTO_RESPUESTA)
        : base(CONFLICTO_RESPUESTA)
        {
        }

        public  blld_CONFLICTO_RESPUESTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, Int32 NID_PREGUNTA)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA)
        {
        }

        public blld_CONFLICTO_RESPUESTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, Int32 NID_PREGUNTA, String V_RESPUESTA)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA, V_RESPUESTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
