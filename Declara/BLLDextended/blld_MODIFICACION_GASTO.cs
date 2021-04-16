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
// Extended
    public partial class blld_MODIFICACION_GASTO : bll_MODIFICACION_GASTO
    {

     #region *** Atributos (Extended) ***

//        public String VID_NOMBRE
//        {
//          get { return datos_MODIFICACION_GASTO.VID_NOMBRE; }
//        }

//        public String VID_FECHA
//        {
//          get { return datos_MODIFICACION_GASTO.VID_FECHA; }
//        }

//        public String VID_HOMOCLAVE
//        {
//          get { return datos_MODIFICACION_GASTO.VID_HOMOCLAVE; }
//        }

//        public Int32 NID_DECLARACION
//        {
//          get { return datos_MODIFICACION_GASTO.NID_DECLARACION; }
//        }

//        public Int32 NID_GASTO
//        {
//          get { return datos_MODIFICACION_GASTO.NID_GASTO; }
//        }


//        public String V_GASTO
//        {
//          get { return datos_MODIFICACION_GASTO.V_GASTO; }
//          set { datos_MODIFICACION_GASTO.V_GASTO = value; }
//        }


//        public Decimal M_GASTO
//        {
//          get { return datos_MODIFICACION_GASTO.M_GASTO; }
//          set { datos_MODIFICACION_GASTO.M_GASTO = value; }
//        }


//        public Boolean L_AUTOGENERADO
//        {
//          get { return datos_MODIFICACION_GASTO.L_AUTOGENERADO; }
//          set { datos_MODIFICACION_GASTO.L_AUTOGENERADO = value; }
//        }


//        public System.Nullable<Int32> NID_PATRIMONIO_ASC
//        {
//          get { return datos_MODIFICACION_GASTO.NID_PATRIMONIO_ASC; }
//          set { datos_MODIFICACION_GASTO.NID_PATRIMONIO_ASC = value; }
//        }


     #endregion


     #region *** Constructores (Extended) ***

        public blld_MODIFICACION_GASTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION,Int32 NID_TIPO_GASTO,  String V_GASTO, Decimal M_GASTO, Boolean L_AUTOGENERADO, System.Nullable<Int32> NID_PATRIMONIO_ASC)
        : base()
        {
            Int32 NID_GASTO = dald_MODIFICACION_GASTO.nNuevo_NID_GASTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            datos_MODIFICACION_GASTO = new dald_MODIFICACION_GASTO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_GASTO, NID_TIPO_GASTO, V_GASTO, M_GASTO, L_AUTOGENERADO, NID_PATRIMONIO_ASC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


     #endregion


     #region *** Metodos (Extended) ***


     #endregion

    }
}
