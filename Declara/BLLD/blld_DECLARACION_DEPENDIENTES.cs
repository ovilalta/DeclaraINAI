using Declara_V2.BLL;
using Declara_V2.Exceptions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_DEPENDIENTES : bll_DECLARACION_DEPENDIENTES
    {

        #region *** Atributos ***


        #region * CAT_TIPO_DEPENDIENTES *


        [StringLength(63)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo T I P O_ D E P E N D I E N T E es requerido ")]
        [DisplayName("T I P O_ D E P E N D I E N T E")]
        public String V_TIPO_DEPENDIENTE => datos_DECLARACION_DEPENDIENTES.V_TIPO_DEPENDIENTE;

        #endregion * CAT_TIPO_DEPENDIENTES *



        #endregion


        #region *** Constructores ***

        private blld_DECLARACION_DEPENDIENTES()
        : base()
        {
        }

        public blld_DECLARACION_DEPENDIENTES(MODELDeclara_V2.DECLARACION_DEPENDIENTES DECLARACION_DEPENDIENTES)
        : base(DECLARACION_DEPENDIENTES)
        {
        }

        public blld_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE)
        {
        }

        public blld_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO, String E_DOMICILIO, Boolean L_CIUDADANO_EXTRANJERO, String E_CURP
                                                               , Int32 NID_ACTIVIDAD_LABORAL
                                                               , String E_OBSERVACIONES
                                                               , String E_OBSERVACIONES_MARCADO
                                                               , String V_OBSERVACIONES_TESTADO
                                                               , Boolean L_MISMO_DOMICILIO_DECLARANTE, Boolean L_ACTIVO)
        : base(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE, NID_TIPO_DEPENDIENTE, E_NOMBRE, E_PRIMER_A, E_SEGUNDO_A, F_NACIMIENTO, E_RFC, L_DEPENDE_ECO, E_DOMICILIO, L_CIUDADANO_EXTRANJERO, E_CURP
                                                               , NID_ACTIVIDAD_LABORAL
                                                               , E_OBSERVACIONES
                                                               , E_OBSERVACIONES_MARCADO
                                                               , V_OBSERVACIONES_TESTADO
                                                               , L_MISMO_DOMICILIO_DECLARANTE, L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException)
        {
        }


        #endregion


        #region *** Metodos ***


        #endregion

    }
}
