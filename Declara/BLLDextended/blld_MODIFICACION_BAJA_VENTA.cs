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
    public partial class blld_MODIFICACION_BAJA_VENTA : bll_MODIFICACION_BAJA_VENTA
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_BAJA_VENTA.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_BAJA_VENTA.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_BAJA_VENTA.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_BAJA_VENTA.NID_DECLARACION; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_BAJA_VENTA.NID_PATRIMONIO; }
        //        }


        //        public Int32 NID_TIPO_VENTA
        //        {
        //          get { return datos_MODIFICACION_BAJA_VENTA.NID_TIPO_VENTA; }
        //          set { datos_MODIFICACION_BAJA_VENTA.NID_TIPO_VENTA = value; }
        //        }


        //        public Decimal M_IMPORTE_VENTA
        //        {
        //          get { return datos_MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTA; }
        //          set { datos_MODIFICACION_BAJA_VENTA.M_IMPORTE_VENTA = value; }
        //        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_BENIFICIARIO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_MODIFICACION_BAJA_VENTA.E_BENIFICIARIO))
                    return String.Empty;
                return DesEncripta(datos_MODIFICACION_BAJA_VENTA.E_BENIFICIARIO);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_MODIFICACION_BAJA_VENTA.E_BENIFICIARIO = String.Empty;
                else datos_MODIFICACION_BAJA_VENTA.E_BENIFICIARIO = Encripta(value);
            }
        }

        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_BAJA_VENTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO_VENTA, Decimal M_IMPORTE_VENTA, String E_BENIFICIARIO)
           : base()
        {
            if (String.IsNullOrEmpty(E_BENIFICIARIO))
            { }
            else
                E_BENIFICIARIO = Encripta(E_BENIFICIARIO);

            datos_MODIFICACION_BAJA_VENTA = new dald_MODIFICACION_BAJA_VENTA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_VENTA, M_IMPORTE_VENTA, E_BENIFICIARIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
