using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class CONFLICTO_RESPUESTA : MODELDeclara_V2.CONFLICTO_RESPUESTA
    {

     #region *** Atributos extendidos ***

        public String V_RUBRO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_CONFLICTO,
            NID_RUBRO,
            NID_ENCABEZADO,
            NID_PREGUNTA,
            V_RESPUESTA,
            V_RUBRO,
        }

     #endregion

    }
}
