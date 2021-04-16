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
    public partial class blld_DECLARACION_CARGO : bll_DECLARACION_CARGO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_DECLARACION_CARGO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_DECLARACION_CARGO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_DECLARACION_CARGO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_DECLARACION_CARGO.NID_DECLARACION; }
        //        }


        //        public Int32 NID_PUESTO
        //        {
        //          get { return datos_DECLARACION_CARGO.NID_PUESTO; }
        //          set { datos_DECLARACION_CARGO.NID_PUESTO = value; }
        //        }


        public String V_FUNCION_PRINCIPAL
        {
            get { return datos_DECLARACION_CARGO.V_FUNCION_PRINCIPAL; }
            set { datos_DECLARACION_CARGO.V_FUNCION_PRINCIPAL = value; }
        }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo P O S E S I O N es requerido ")]
        [DisplayName("P O S E S I O N")]
        new public DateTime F_POSESION
        {
            get => datos_DECLARACION_CARGO.F_POSESION;
            set
                {
                if (F_INICIO > value)
 
                    throw new CustomException("La fecha de toma de posesión del cargo actual no puede ser menor que la fecha de ingreso al instituto");
                if (value > DateTime.Today)

                    throw new CustomException("La fecha no puede ser mayor que la fecha actual");

                datos_DECLARACION_CARGO.F_POSESION = value;
            }
        }


        //[Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha no está dentro del rango")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo I N I C I O es requerido ")]
        [DisplayName("I N I C I O")]
        new public DateTime F_INICIO
        {
            get => datos_DECLARACION_CARGO.F_INICIO;
            set
            {
                if (value > DateTime.Today)
                    throw new CustomException("La fecha de ingreso al instituto no puede ser mayor que la fecha actual");
                datos_DECLARACION_CARGO.F_INICIO = value;
            }
        }

        private Int32 NID_ESTADO_TESTADOInicial => 0;
        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_CARGO.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_CARGO.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_CARGO.E_OBSERVACIONES = String.Empty;
                else
                    datos_DECLARACION_CARGO.E_OBSERVACIONES = Encripta(value);
            }
        }


        //        public String VID_PRIMER_NIVEL
        //        {
        //          get { return datos_DECLARACION_CARGO.VID_PRIMER_NIVEL; }
        //          set { datos_DECLARACION_CARGO.VID_PRIMER_NIVEL = value; }
        //        }


        //        public String VID_SEGUNDO_NIVEL
        //        {
        //          get { return datos_DECLARACION_CARGO.VID_SEGUNDO_NIVEL; }
        //          set { datos_DECLARACION_CARGO.VID_SEGUNDO_NIVEL = value; }
        //        }

        public String V_PRIMER_NIVEL => datos_DECLARACION_CARGO.V_PRIMER_NIVEL;


        #endregion


        #region *** Constructores (Extended) ***

        public blld_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, string V_FUNCION_PRINCIPAL, DateTime F_POSESION, DateTime F_INICIO, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL)
          : base()
        {
            this.E_OBSERVACIONES = null;
            String E_OBSERVACIONES_MARCADO = null;
            String V_OBSERVACIONES_TESTADO = null;

            if (F_INICIO > DateTime.Today)
                throw new CustomException("La fecha de ingreso al instituto no puede ser mayor que la fecha actual");

            if (F_INICIO > F_POSESION)
                throw new CustomException("La fecha de toma de posesión del cargo actual no puede ser menor que la fecha de ingreso al instituto");

            datos_DECLARACION_CARGO = new dald_DECLARACION_CARGO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PUESTO, V_DENOMINACION, V_FUNCION_PRINCIPAL, F_POSESION, F_INICIO, VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL, E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, NID_ESTADO_TESTADOInicial, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
        }
        #endregion


        #region *** Metodos (Extended) ***

        new public void update()
        {
            if (F_INICIO > DateTime.Today)
                throw new CustomException("La fecha de ingreso al instituto no puede ser mayor que la fecha actual");

            if (F_INICIO > F_POSESION)
                throw new CustomException("La fecha de toma de posesión del cargo actual no puede ser menor que la fecha de ingreso al instituto");
            base.update();
        }

        #endregion

    }
}
