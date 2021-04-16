using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class PATRIMONIO_TARJETA : MODELDeclara_V2.PATRIMONIO_TARJETA
    {

     #region *** Atributos extendidos ***

        public String V_INSTITUCION { get; set; }
        public Boolean L_ACTIVO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            E_NUMERO,
            NID_INSTITUCION,
            V_NUMERO_CORTO,
            M_SALDO,
            L_ACTIVA,
            V_INSTITUCION,
            L_ACTIVO,
        }

     #endregion

    }
}
