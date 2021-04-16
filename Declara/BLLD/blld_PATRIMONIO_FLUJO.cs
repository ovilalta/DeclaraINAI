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
    public partial class blld_PATRIMONIO_FLUJO : bll_PATRIMONIO_FLUJO
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_PATRIMONIO_FLUJO()
        : base()
        {
        }

        public blld_PATRIMONIO_FLUJO(MODELDeclara_V2.PATRIMONIO_FLUJO PATRIMONIO_FLUJO)
        : base(PATRIMONIO_FLUJO)
        {
        }

        public  blld_PATRIMONIO_FLUJO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE)
        {
        }

        public blld_PATRIMONIO_FLUJO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Decimal M_INGRESOS, Decimal M_EGRESOS)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, M_INGRESOS, M_EGRESOS, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
