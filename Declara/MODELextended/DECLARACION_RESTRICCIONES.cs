using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class DECLARACION_RESTRICCIONES : MODELDeclara_V2.DECLARACION_RESTRICCIONES
    {

     #region *** Atributos extendidos ***

        public String V_RESTRICCION { get; set; }
        public String LV_VIGENTE { get; set; }

        public Boolean L_VIGENTE
        {
            get => Convert.ToBoolean(LV_VIGENTE);
            set => LV_VIGENTE = Convert.ToInt16(value).ToString();
        }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_RESTRICCION,
            L_RESPUESTA,
            L_AUTO,
            V_RESTRICCION,
            L_VIGENTE,
        }

     #endregion

    }
}
