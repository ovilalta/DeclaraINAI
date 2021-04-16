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
    public partial class blld_DECLARACION_PERSONALES : bll_DECLARACION_PERSONALES
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_DECLARACION_PERSONALES.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_DECLARACION_PERSONALES.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_DECLARACION_PERSONALES.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_DECLARACION_PERSONALES.NID_DECLARACION; }
        //        }


        new public String C_GENERO
        {
            get => datos_DECLARACION_PERSONALES.C_GENERO;
            set
            {
                datos_DECLARACION_PERSONALES.C_GENERO = value;
                if (!value.Equals(datos_DECLARACION_PERSONALES.C_GENERO))
                    datos_DECLARACION_PERSONALES.oNacionalidad = null;
            }
        }

        [StringLength(18)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El campo C U R P es requerido ")]
        [DisplayName("C U R P")]
        new public String C_CURP
        {
            get => datos_DECLARACION_PERSONALES.C_CURP;
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length != 18)
                    throw new CustomException("Debe escribir una CURP válida");
                datos_DECLARACION_PERSONALES.C_CURP = value;
            }
        }

        //        public String C_CURP
        //        {
        //          get { return datos_DECLARACION_PERSONALES.C_CURP; }
        //          set { datos_DECLARACION_PERSONALES.C_CURP = value; }
        //        }


        new public Int32 NID_PAIS
        {
            get => datos_DECLARACION_PERSONALES.NID_PAIS;
            set
            {
                if (!value.Equals(datos_DECLARACION_PERSONALES.NID_PAIS))
                {
                    datos_DECLARACION_PERSONALES.oPais = null;
                    datos_DECLARACION_PERSONALES.oEntidad = null;
                }
                datos_DECLARACION_PERSONALES.NID_PAIS = value;

            }
        }


        new public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA;
            set
            {
                if (!value.Equals(datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA))
                    datos_DECLARACION_PERSONALES.oEntidad = null;
                datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA = value;

            }
        }


        new public Int32 NID_NACIONALIDAD
        {
            get => datos_DECLARACION_PERSONALES.NID_NACIONALIDAD;
            set
            {
                if (!value.Equals(datos_DECLARACION_PERSONALES.NID_NACIONALIDAD))
                    datos_DECLARACION_PERSONALES.oNacionalidad = null;
                datos_DECLARACION_PERSONALES.NID_NACIONALIDAD = value;

            }
        }


        new public Int32 NID_ESTADO_CIVIL
        {
            get { return datos_DECLARACION_PERSONALES.NID_ESTADO_CIVIL; }
            set => datos_DECLARACION_PERSONALES.NID_ESTADO_CIVIL = value;
        }

        public String V_PAIS_NACIMIENTO => datos_DECLARACION_PERSONALES.V_PAIS_NACIMIENTO;

        public String V_ENTIDAD_NACIMIENTO => datos_DECLARACION_PERSONALES.V_ENTIDAD_NACIMIENTO;

        public String V_NACIONALIDAD (Char C_GENERO)
        {
            return datos_DECLARACION_PERSONALES.V_NACIONALIDAD(C_GENERO);
        }
        // SME-NF-I
        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_PERSONALES.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_PERSONALES.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_PERSONALES.E_OBSERVACIONES = String.Empty;
                else
                    datos_DECLARACION_PERSONALES.E_OBSERVACIONES = Encripta(value);
            }
        }
        new public String E_OBSERVACIONES_MARCADO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_PERSONALES.E_OBSERVACIONES_MARCADO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_PERSONALES.E_OBSERVACIONES_MARCADO);
            }
            set
            {
                ValidarEstadoTestado(NID_ESTADO_TESTADO);

                if (String.IsNullOrEmpty(value.Trim().Trim('|').Trim('|')))
                {
                    datos_DECLARACION_PERSONALES.E_OBSERVACIONES_MARCADO = String.Empty;
                    datos_DECLARACION_PERSONALES.V_OBSERVACIONES_TESTADO = String.Empty;
                }
                else
                {
                    datos_DECLARACION_PERSONALES.E_OBSERVACIONES_MARCADO = Encripta(value);
                    datos_DECLARACION_PERSONALES.V_OBSERVACIONES_TESTADO = Testa(value);

                }
            }
        }
        new public String V_OBSERVACIONES_TESTADO => String.IsNullOrEmpty(datos_DECLARACION_PERSONALES.V_OBSERVACIONES_TESTADO) ? String.Empty : datos_DECLARACION_PERSONALES.V_OBSERVACIONES_TESTADO.Replace("¦", "█");
        #endregion

        // SME-NF-F
        #region *** Constructores (Extended) ***

        public blld_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_GENERO, String C_CURP, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_NACIONALIDAD, Int32 NID_ESTADO_CIVIL, System.Nullable<Boolean> L_SERVIDOR_ANTERIOR, System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_INICIO, System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_FIN, String E_OBSERVACIONES, Int32 NID_REGIMEN_MATRIMONIAL)
    : base()
        {
            if (String.IsNullOrEmpty(C_GENERO))
                throw new CustomException("Debe seleccionar un género");
            if (String.IsNullOrEmpty(C_CURP) || C_CURP.Length != 18)
                throw new CustomException("Debe escribir una CURP válida");
            // SME-NF-I
            this.E_OBSERVACIONES = Encripta(E_OBSERVACIONES);
            //this.E_OBSERVACIONES_MARCADO = null;
            String E_OBSERVACIONES_MARCADO = null;
            String V_OBSERVACIONES_TESTADO = null;
            Int32 NID_ESTADO_TESTADO = 0;
            datos_DECLARACION_PERSONALES = new dald_DECLARACION_PERSONALES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, C_GENERO, C_CURP, NID_PAIS, CID_ENTIDAD_FEDERATIVA, NID_NACIONALIDAD, NID_ESTADO_CIVIL, L_SERVIDOR_ANTERIOR, F_SERVIDOR_ANTERIOR_INICIO, F_SERVIDOR_ANTERIOR_FIN, this.E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
            dald_DECLARACION_REGIMEN_MATRIMONIAL rm = new dald_DECLARACION_REGIMEN_MATRIMONIAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, 1, NID_REGIMEN_MATRIMONIAL,ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
            // SME-NF-F
        }

        #endregion


        #region *** Metodos (Extended) ***


        #endregion

    }
}
