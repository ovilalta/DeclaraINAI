using Declara_V2.BLL;
using Declara_V2.DALD;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using System;
using System.Linq;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_EXPERIENCIA_LABORAL : bll_DECLARACION_EXPERIENCIA_LABORAL
    {

        #region *** Propiedades ***
        //    new public String VID_NOMBRE => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_NOMBRE;
        //    new public String VID_FECHA => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_FECHA;
        //    new public String VID_HOMOCLAVE => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_HOMOCLAVE;
        //    new public Int32 NID_DECLARACION => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_DECLARACION;
        //    new public Int32 NID_EXPERIENCIA_LABORAL => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_EXPERIENCIA_LABORAL;
        //    new public Int32 NID_AMBITO_SECTOR
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTOR;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTOR = value;
        //        }
        //    new public Int32 NID_NIVEL_GOBIERNO
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNO;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNO = value;
        //        }
        //    new public Int32 NID_AMBITO_PUBLICO
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICO;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICO = value;
        //        }
        //    new public String V_NOMBRE
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_NOMBRE;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_NOMBRE = value;
        //        }
        //    new public String V_RFC
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_RFC;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_RFC = value;
        //        }
        //    new public String V_AREA_ADSCRIPCION
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCION;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCION = value;
        //        }
        //    new public String V_PUESTO
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_PUESTO;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_PUESTO = value;
        //        }
        //    new public String V_FUNCION_PRINCIPAL
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPAL;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPAL = value;
        //        }
        //    new public Int32 NID_SECTOR
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_SECTOR;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_SECTOR = value;
        //        }
        //    new public DateTime F_INGRESO
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.F_INGRESO;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.F_INGRESO = value;
        //        }
        //    new public DateTime F_EGRESO
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.F_EGRESO;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.F_EGRESO = value;
        //        }
        //    new public Int32 NID_PAIS
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_PAIS;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_PAIS = value;
        //        }
        new public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES = String.Empty;
                else
                    datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES = Encripta(value);
            }
        }

        new public String V_SECTOR
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_EXPERIENCIA_LABORAL.V_SECTOR))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_EXPERIENCIA_LABORAL.V_SECTOR);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_EXPERIENCIA_LABORAL.V_SECTOR = String.Empty;
                else
                    datos_DECLARACION_EXPERIENCIA_LABORAL.V_SECTOR = Encripta(value);
            }
        }


        new public String E_OBSERVACIONES_MARCADO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO))
                    return String.Empty;
                return DesEncripta(datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO);
            }
            set
            {
                ValidarEstadoTestado(NID_ESTADO_TESTADO);

                if (String.IsNullOrEmpty(value.Trim().Trim('|').Trim('|')))
                {
                    datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO = String.Empty;
                    datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO = String.Empty;
                }
                else
                {
                    datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO = Encripta(value);
                    datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO = Testa(value);

                }
            }
        }

        new public String V_OBSERVACIONES_TESTADO => String.IsNullOrEmpty(datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO) ? String.Empty : datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO.Replace("¦", "█");



        //    new public String E_OBSERVACIONES_MARCADO
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO = value;
        //        }
        //    new public String V_OBSERVACIONES_TESTADO
        //        {
        //            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO;
        //            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO = value;
        //        }
        //    new public Int32 NID_ESTADO_TESTADO => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADO;
        public String V_PAIS => datos_DECLARACION_EXPERIENCIA_LABORAL.oCAT_PAIS.V_PAIS;
        public String V_NACIONALIDAD_M => datos_DECLARACION_EXPERIENCIA_LABORAL.oCAT_PAIS.V_NACIONALIDAD_M;
        public String V_NACIONALIDAD_F => datos_DECLARACION_EXPERIENCIA_LABORAL.oCAT_PAIS.V_NACIONALIDAD_F;
        public String V_ESTADO_TESTADO => datos_DECLARACION_EXPERIENCIA_LABORAL.oCAT_ESTADO_TESTADO.V_ESTADO_TESTADO;
        //public new String V_SECTOR => datos_DECLARACION_EXPERIENCIA_LABORAL.oCAT_SECTOR.V_SECTOR;
        public String V_AMBITO_SECTOR => datos_DECLARACION_EXPERIENCIA_LABORAL.oCAT_AMBITO_SECTOR.V_AMBITO_SECTOR;
        public String V_NIVEL_GOBIERNO => datos_DECLARACION_EXPERIENCIA_LABORAL.oCAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO;
        public String V_AMBITO_PUBLICO => datos_DECLARACION_EXPERIENCIA_LABORAL.oCAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO;
        private Int32 NID_ESTADO_TESTADOInicial => 0;

        #endregion


        #region *** Constructores ***
        //public blld_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE, String V_RFC, String V_AREA_ADSCRIPCION, String V_PUESTO, String V_FUNCION_PRINCIPAL, Int32 NID_SECTOR, DateTime F_INGRESO, DateTime F_EGRESO, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO)
        //    : base()
        //{
        //    ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
        //    String _VID_NOMBRE = VID_NOMBRE; 
        //    String _VID_FECHA = VID_FECHA; 
        //    String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
        //    Int32 _NID_DECLARACION = NID_DECLARACION; 
        //    Int32 _NID_EXPERIENCIA_LABORAL = NID_EXPERIENCIA_LABORAL; 
        //    this.NID_AMBITO_SECTOR = NID_AMBITO_SECTOR;
        //    this.NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO;
        //    this.NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO;
        //    this.V_NOMBRE = V_NOMBRE;
        //    this.V_RFC = V_RFC;
        //    this.V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION;
        //    this.V_PUESTO = V_PUESTO;
        //    this.V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL;
        //    this.NID_SECTOR = NID_SECTOR;
        //    this.F_INGRESO = F_INGRESO;
        //    this.F_EGRESO = F_EGRESO;
        //    this.NID_PAIS = NID_PAIS;
        //    this.E_OBSERVACIONES = E_OBSERVACIONES;
        //    this.E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO;
        //    this.V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO;
        //    datos_DECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADO = NID_ESTADO_TESTADOInicial;
        //    datos_DECLARACION_EXPERIENCIA_LABORAL = new dald_DECLARACION_EXPERIENCIA_LABORAL(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_EXPERIENCIA_LABORAL, this.NID_AMBITO_SECTOR, this.NID_NIVEL_GOBIERNO, this.NID_AMBITO_PUBLICO, this.V_NOMBRE, this.V_RFC, this.V_AREA_ADSCRIPCION, this.V_PUESTO, this.V_FUNCION_PRINCIPAL, this.NID_SECTOR, this.F_INGRESO, this.F_EGRESO, this.NID_PAIS, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
        //}
        public blld_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE, String V_RFC, String V_AREA_ADSCRIPCION, String V_PUESTO, String V_FUNCION_PRINCIPAL, Int32 NID_SECTOR, DateTime F_INGRESO, DateTime F_EGRESO, Int32 NID_PAIS, String E_OBSERVACIONES)
            : base()
        {

            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE;
            String _VID_FECHA = VID_FECHA;
            String _VID_HOMOCLAVE = VID_HOMOCLAVE;
            Int32 _NID_DECLARACION = NID_DECLARACION;
            Int32 _NID_EXPERIENCIA_LABORAL = dald_DECLARACION_EXPERIENCIA_LABORAL.nNuevo_NID_EXPERIENCIA_LABORAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.NID_AMBITO_SECTOR = NID_AMBITO_SECTOR;
            this.NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO;
            this.NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO;
            this.V_NOMBRE = V_NOMBRE;
            this.V_RFC = V_RFC;
            this.V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION;
            this.V_PUESTO = V_PUESTO;
            this.V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL;
            this.NID_SECTOR = NID_SECTOR;
            this.F_INGRESO = F_INGRESO;
            this.F_EGRESO = F_EGRESO;
            this.NID_PAIS = NID_PAIS;
            this.E_OBSERVACIONES = E_OBSERVACIONES;
            //     this.V_SECTOR = V_SECTOR;
            String E_OBSERVACIONES_MARCADO = null;
            String V_OBSERVACIONES_TESTADO = null;
            datos_DECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADO = NID_ESTADO_TESTADOInicial;
            datos_DECLARACION_EXPERIENCIA_LABORAL = new dald_DECLARACION_EXPERIENCIA_LABORAL(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_EXPERIENCIA_LABORAL, this.NID_AMBITO_SECTOR, this.NID_NIVEL_GOBIERNO, this.NID_AMBITO_PUBLICO, this.V_NOMBRE, this.V_RFC, this.V_AREA_ADSCRIPCION, this.V_PUESTO, this.V_FUNCION_PRINCIPAL, this.NID_SECTOR, this.F_INGRESO, this.F_EGRESO, this.NID_PAIS, datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES, E_OBSERVACIONES_MARCADO, V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO,  lOpcionesRegistroExistente);

        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
