using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class H_PATRIMONIO_INMUEBLE : MODELDeclara_V2.H_PATRIMONIO_INMUEBLE
    {

     #region *** Atributos extendidos ***

        public Decimal M_VALOR { get; set; }
        public Int32 NID_DEC_INCOR { get; set; }
        public DateTime F_INCORPORACION { get; set; }
        public Int32 NID_DEC_ULT_MOD { get; set; }
        public DateTime F_MODIFICACION { get; set; }
        public Boolean L_ACTIVO { get; set; }
        public DateTime F_REGISTRO { get; set; }
        public String V_TIPO { get; set; }
        public String V_USO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_PATRIMONIO,
            NID_HISTORICO,
            NID_TIPO,
            F_ADQUISICION,
            NID_USO,
            E_UBICACION,
            N_TERRENO,
            N_CONSTRUCCION,
            M_VALOR_INMUEBLE,
            M_VALOR,
            NID_DEC_INCOR,
            F_INCORPORACION,
            NID_DEC_ULT_MOD,
            F_MODIFICACION,
            L_ACTIVO,
            F_REGISTRO,
            V_TIPO,
            V_USO,
        }

     #endregion

    }
}
