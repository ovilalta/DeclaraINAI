using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_TARJETA : MODELDeclara_V2.ALTA_TARJETA
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            E_NUMERO,
            V_NUMERO_CORTO,
            M_SALDO,
            NID_TITULAR,
        }

     #endregion

    }
}
