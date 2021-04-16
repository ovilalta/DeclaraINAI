using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;

namespace Declara_V2.MODELextended
{
    public class ALTA_VEHICULO_ADEUDO : MODELDeclara_V2.ALTA_VEHICULO_ADEUDO
    {

     #region *** Atributos extendidos ***

        public Int32 NID_MARCA { get; set; }
        public String C_MODELO { get; set; }
        public String V_DESCRIPCION { get; set; }
        public DateTime F_ADQUISICION { get; set; }
        public Int32 NID_TIPO_COMPRA { get; set; }
        public Int32 NID_USO { get; set; }
        public Decimal M_VALOR_VEHICULO { get; set; }
        public Int32 NID_PATRIMONIO { get; set; }


        public enum Properties
        {
            VID_NOMBRE,
            VID_FECHA,
            VID_HOMOCLAVE,
            NID_DECLARACION,
            NID_VEHICULO,
            NID_ADEUDO,
            NID_MARCA,
            C_MODELO,
            V_DESCRIPCION,
            F_ADQUISICION,
            NID_TIPO_COMPRA,
            NID_USO,
            M_VALOR_VEHICULO,
            NID_PATRIMONIO,
        }

     #endregion

    }
}
