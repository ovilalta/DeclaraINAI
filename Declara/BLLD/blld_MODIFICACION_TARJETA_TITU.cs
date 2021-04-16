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
    public partial class blld_MODIFICACION_TARJETA_TITU : bll_MODIFICACION_TARJETA_TITU
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_TARJETA_TITU()
        : base()
        {
        }

        public blld_MODIFICACION_TARJETA_TITU(MODELDeclara_V2.MODIFICACION_TARJETA_TITU MODIFICACION_TARJETA_TITU)
        : base(MODIFICACION_TARJETA_TITU)
        {
        }

        public  blld_MODIFICACION_TARJETA_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, NID_DEPENDIENTE)
        {
        }

       


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
