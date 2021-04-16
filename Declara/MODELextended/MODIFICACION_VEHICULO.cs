using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class MODIFICACION_VEHICULO : MODELDeclara_V2.MODIFICACION_VEHICULO
    {

     #region *** Atributos extendidos ***

        public String V_USO { get; set; }
        public String V_MARCA { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_PATRIMONIO,
            NID_MARCA,
            C_MODELO,
            V_DESCRIPCION,
            F_ADQUISICION,
            NID_TIPO_COMPRA,
            NID_USO,
            M_VALOR_VEHICULO,
            V_USO,
            V_MARCA,
        }

     #endregion

    }
}
