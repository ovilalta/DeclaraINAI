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
    public partial class blld_DECLARACION_DOM_LABORAL : bll_DECLARACION_DOM_LABORAL
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_DECLARACION_DOM_LABORAL.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_DECLARACION_DOM_LABORAL.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_DECLARACION_DOM_LABORAL.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_DECLARACION_DOM_LABORAL.NID_DECLARACION; }
        //        }


        //        public String C_CODIGO_POSTAL
        //        {
        //          get { return datos_DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL; }
        //          set { datos_DECLARACION_DOM_LABORAL.C_CODIGO_POSTAL = value; }
        //        }


        new public Int32 NID_PAIS
        {
            get => datos_DECLARACION_DOM_LABORAL.NID_PAIS;
            set
            {
                if (!value.Equals(datos_DECLARACION_DOM_LABORAL.NID_PAIS))
                {
                    datos_DECLARACION_DOM_LABORAL.oPais = null;
                    datos_DECLARACION_DOM_LABORAL.oEntidad = null;
                    datos_DECLARACION_DOM_LABORAL.oMunicipio = null;
                }
                datos_DECLARACION_DOM_LABORAL.NID_PAIS = value;
            }
        }


        new public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA;
            set
            {
                if (!value.Equals(datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA))
                {
                    datos_DECLARACION_DOM_LABORAL.oEntidad = null;
                    datos_DECLARACION_DOM_LABORAL.oMunicipio = null;
                }
                datos_DECLARACION_DOM_LABORAL.CID_ENTIDAD_FEDERATIVA = value;
            }
        }


        new public String CID_MUNICIPIO
        {
            get => datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIO;
            set
            {
                if (!value.Equals(datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIO))
                    datos_DECLARACION_DOM_LABORAL.oMunicipio = null;
                datos_DECLARACION_DOM_LABORAL.CID_MUNICIPIO = value;
            }
        }


        //        public String V_DOMICILIO
        //        {
        //          get { return datos_DECLARACION_DOM_LABORAL.V_DOMICILIO; }
        //          set { datos_DECLARACION_DOM_LABORAL.V_DOMICILIO = value; }
        //        }


        //        public String V_CORREO_LABORAL
        //        {
        //          get { return datos_DECLARACION_DOM_LABORAL.V_CORREO_LABORAL; }
        //          set { datos_DECLARACION_DOM_LABORAL.V_CORREO_LABORAL = value; }
        //        }


        //        public String V_TEL_LABORAL
        //        {
        //          get { return datos_DECLARACION_DOM_LABORAL.V_TEL_LABORAL; }
        //          set { datos_DECLARACION_DOM_LABORAL.V_TEL_LABORAL = value; }
        //        }

        public String V_PAIS => datos_DECLARACION_DOM_LABORAL.V_PAIS;
        public String V_ENTIDAD_FEDERATIVA => datos_DECLARACION_DOM_LABORAL.V_ENTIDAD_FEDERATIVA;
        public String V_MUNICIPIO => datos_DECLARACION_DOM_LABORAL.V_MUNICIPIO;

        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo  es requerido ")]
        [DisplayName("")]
        new public String V_DOMICILIO
        {
            get => datos_DECLARACION_DOM_LABORAL.V_DOMICILIO;
            set
            {
                if (value.Length < 0)
                    throw new CustomException("La longitud del domicilio debe ser por lo menos de 8 caractéres");
                else
                    datos_DECLARACION_DOM_LABORAL.V_DOMICILIO = value;
            }
        }

        #endregion


        #region *** Constructores (Extended) ***

        public blld_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_CORREO_LABORAL, String V_TEL_LABORAL)
         : base()
        {
            
            if (V_DOMICILIO.Length < 0)
                throw new CustomException("La longitud del domicilio debe ser por lo menos de 8 caractéres");
            datos_DECLARACION_DOM_LABORAL = new dald_DECLARACION_DOM_LABORAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_CODIGO_POSTAL, NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, V_COLONIA, V_DOMICILIO, V_CORREO_LABORAL, V_TEL_LABORAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
