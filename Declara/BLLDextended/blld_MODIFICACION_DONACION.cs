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
    public partial class blld_MODIFICACION_DONACION : bll_MODIFICACION_DONACION
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_DONACION.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_DONACION.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_DONACION.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_DONACION.NID_DECLARACION; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_DONACION.NID_PATRIMONIO; }
        //        }


        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_ESPECIFICA
        {
            get
            {
                if (String.IsNullOrEmpty(datos_MODIFICACION_DONACION.E_ESPECIFICA))
                    return String.Empty;
                return DesEncripta(datos_MODIFICACION_DONACION.E_ESPECIFICA);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_MODIFICACION_DONACION.E_ESPECIFICA = String.Empty;
                else datos_MODIFICACION_DONACION.E_ESPECIFICA = Encripta(value);
            }
        }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String E_BENIFICIARIO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_MODIFICACION_DONACION.E_BENIFICIARIO))
                    return String.Empty;
                return DesEncripta(datos_MODIFICACION_DONACION.E_BENIFICIARIO);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_MODIFICACION_DONACION.E_BENIFICIARIO = String.Empty;
                else datos_MODIFICACION_DONACION.E_BENIFICIARIO = Encripta(value);
            }
        }


        #endregion


        #region *** Constructores (Extended) ***


        public blld_MODIFICACION_DONACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, String V_ESPECIFICA, String E_BENIFICIARIO)
: base()
        {
            if (!String.IsNullOrEmpty(E_ESPECIFICA))
                E_ESPECIFICA = Encripta(E_ESPECIFICA);
            if (!String.IsNullOrEmpty(E_BENIFICIARIO))
                E_BENIFICIARIO = Encripta(E_BENIFICIARIO);
            datos_MODIFICACION_DONACION = new dald_MODIFICACION_DONACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, V_ESPECIFICA, E_BENIFICIARIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
