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
    public partial class blld_MODIFICACION_INGRESOS : bll_MODIFICACION_INGRESOS
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_INGRESOS.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_INGRESOS.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_INGRESOS.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_INGRESOS.NID_DECLARACION; }
        //        }

        //        public Int32 NID_INGRESO
        //        {
        //          get { return datos_MODIFICACION_INGRESOS.NID_INGRESO; }
        //        }


        //        public String E_ESPECIFICAR
        //        {
        //          get { return datos_MODIFICACION_INGRESOS.E_ESPECIFICAR; }
        //          set { datos_MODIFICACION_INGRESOS.E_ESPECIFICAR = value; }
        //        }


        //        public Decimal M_INGRESO
        //        {
        //          get { return datos_MODIFICACION_INGRESOS.M_INGRESO; }
        //          set { datos_MODIFICACION_INGRESOS.M_INGRESO = value; }
        //        }
        new public string E_ESPECIFICAR_COMPLEMENTO
        {
            get
            {
                if (datos_MODIFICACION_INGRESOS.NID_INGRESO == 15 || datos_MODIFICACION_INGRESOS.NID_INGRESO == 117)
                {
                    if (String.IsNullOrEmpty(datos_MODIFICACION_INGRESOS.E_ESPECIFICAR_COMPLEMENTO))
                        return String.Empty;
                    return DesEncripta(datos_MODIFICACION_INGRESOS.E_ESPECIFICAR_COMPLEMENTO);
                }
                else
                    return datos_MODIFICACION_INGRESOS.E_ESPECIFICAR_COMPLEMENTO;
            }
            set
            {
                if (datos_MODIFICACION_INGRESOS.NID_INGRESO == 15 || datos_MODIFICACION_INGRESOS.NID_INGRESO == 117)
                {
                    if (String.IsNullOrEmpty(value))
                        datos_MODIFICACION_INGRESOS.E_ESPECIFICAR_COMPLEMENTO = String.Empty;
                    else
                        datos_MODIFICACION_INGRESOS.E_ESPECIFICAR_COMPLEMENTO = Encripta(value);
                }
                else
                    datos_MODIFICACION_INGRESOS.E_ESPECIFICAR_COMPLEMENTO = value;

            }
        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_ESPECIFICAR, String E_ESPECIFICAR_COMPLEMENTO, Decimal M_INGRESO, Char C_TITULAR)
        : base()
        {
            Int32 NID_INGRESO = dald_MODIFICACION_INGRESOS.nNuevo_NID_INGRESO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            datos_MODIFICACION_INGRESOS = new dald_MODIFICACION_INGRESOS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO, E_ESPECIFICAR, E_ESPECIFICAR_COMPLEMENTO, M_INGRESO, C_TITULAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


        #endregion


        #region *** Metodos (Extended) ***
        public String Protege_dato(String Dato)
        {
            if (String.IsNullOrEmpty(Dato))
                return String.Empty;
            return DesEncripta(Dato);
        }

        #endregion

    }
}
