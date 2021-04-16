using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_VEHICULO : MODELDeclara_V2.ALTA_VEHICULO
    {

     #region *** Atributos extendidos ***

        public String V_USO { get; set; }
        public String V_TIPO_COMPRA { get; set; }
        public String V_MARCA { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_VEHICULO,
            NID_MARCA,
            C_MODELO,
            V_DESCRIPCION,
            F_ADQUISICION,
            NID_TIPO_VEHICULO,
            NID_USO,
            M_VALOR_VEHICULO,
            NID_PATRIMONIO,
            V_USO,
            V_TIPO_COMPRA,
            V_MARCA,
        }

     #endregion

    }
}
