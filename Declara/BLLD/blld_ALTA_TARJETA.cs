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
    public partial class blld_ALTA_TARJETA : bll_ALTA_TARJETA
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_ALTA_TARJETA()
        : base()
        {
        }

        public blld_ALTA_TARJETA(MODELDeclara_V2.ALTA_TARJETA ALTA_TARJETA)
        : base(ALTA_TARJETA)
        {
        }

        public  blld_ALTA_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO)
        {
        }

        public blld_ALTA_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, String V_NUMERO_CORTO, Decimal M_SALDO, Int32 NID_TITULAR)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO, V_NUMERO_CORTO, M_SALDO, NID_TITULAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
