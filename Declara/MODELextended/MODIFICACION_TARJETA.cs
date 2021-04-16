using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_TARJETA : MODELDeclara_V2.MODIFICACION_TARJETA
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
            M_PAGOS,
            M_GASTOS,
            E_NUMERO_ASOCIACION,
            L_ACTIVA,
            M_SALDO,
            NID_INSTITUCION,
        }

     #endregion

    }
}
