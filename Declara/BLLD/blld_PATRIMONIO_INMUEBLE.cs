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
    public partial class blld_PATRIMONIO_INMUEBLE : bll_PATRIMONIO_INMUEBLE
    {

     #region *** Atributos ***


        #region * CAT_TIPO_INMUEBLE *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_TIPO => datos_PATRIMONIO_INMUEBLE.V_TIPO;

        #endregion * CAT_TIPO_INMUEBLE *


        #region * CAT_USO_INMUEBLE *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        public String V_USO => datos_PATRIMONIO_INMUEBLE.V_USO;

        #endregion * CAT_USO_INMUEBLE *



     #endregion


     #region *** Constructores ***

        private blld_PATRIMONIO_INMUEBLE()
        : base()
        {
        }

        public blld_PATRIMONIO_INMUEBLE(MODELDeclara_V2.PATRIMONIO_INMUEBLE PATRIMONIO_INMUEBLE)
        : base(PATRIMONIO_INMUEBLE)
        {
        }

        public  blld_PATRIMONIO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO)
        {
        }

        public blld_PATRIMONIO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
