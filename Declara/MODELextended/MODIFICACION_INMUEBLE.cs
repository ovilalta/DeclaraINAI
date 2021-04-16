using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_INMUEBLE : MODELDeclara_V2.MODIFICACION_INMUEBLE
    {

     #region *** Atributos extendidos ***

        public String V_TIPO { get; set; }
        public String V_USO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_PATRIMONIO,
            NID_TIPO,
            F_ADQUISICION,
            NID_USO,
            E_UBICACION,
            N_TERRENO,
            N_CONSTRUCCION,
            M_VALOR_INMUEBLE,
            V_TIPO,
            V_USO,
        }

     #endregion

    }
}
