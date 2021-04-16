using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_INMUEBLE : MODELDeclara_V2.ALTA_INMUEBLE
    {

     #region *** Atributos extendidos ***

        public String V_TIPO_COMPRA { get; set; }
        public String V_TIPO { get; set; }
        public String V_USO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_INMUEBLE,
            NID_TIPO,
            F_ADQUISICION,
            NID_TIPO_COMPRA,
            NID_USO,
            E_UBICACION,
            N_TERRENO,
            N_CONSTRUCCION,
            M_VALOR_INMUEBLE,
            NID_PATRIMONIO,
            V_TIPO_COMPRA,
            V_TIPO,
            V_USO,
        }

     #endregion

    }
}
