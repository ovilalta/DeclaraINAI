using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class H_PATRIMONIO_TITULAR : MODELDeclara_V2.H_PATRIMONIO_TITULAR
    {

     #region *** Atributos extendidos ***



        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_PATRIMONIO,
            NID_DEPENDIENTE,
            NID_HISTORICO,
            L_DIF,
        }

     #endregion

    }
}
