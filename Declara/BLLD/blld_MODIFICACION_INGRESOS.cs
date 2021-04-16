using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
    public partial class blld_MODIFICACION_INGRESOS : bll_MODIFICACION_INGRESOS
    {

     #region *** Atributos ***



     #endregion


     #region *** Constructores ***

        private blld_MODIFICACION_INGRESOS()
        : base()
        {
        }

        public blld_MODIFICACION_INGRESOS(MODELDeclara_V2.MODIFICACION_INGRESOS MODIFICACION_INGRESOS)
        : base(MODIFICACION_INGRESOS)
        {
        }

        public  blld_MODIFICACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO)
        {
        }

        public blld_MODIFICACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String E_ESPECIFICAR, String E_ESPECIFICAR_COMPLEMENTO, Decimal M_INGRESO, Char C_TITULAR)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO, E_ESPECIFICAR, E_ESPECIFICAR_COMPLEMENTO, M_INGRESO,  C_TITULAR)
        {
        }


     #endregion


     #region *** Metodos ***


     #endregion

    }
}
