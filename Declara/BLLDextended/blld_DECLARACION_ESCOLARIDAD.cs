using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_ESCOLARIDAD : bll_DECLARACION_ESCOLARIDAD
    {

        #region *** Propiedades ***
        //    new public String VID_NOMBRE => datos_DECLARACION_ESCOLARIDAD.VID_NOMBRE;
        //    new public String VID_FECHA => datos_DECLARACION_ESCOLARIDAD.VID_FECHA;
        //    new public String VID_HOMOCLAVE => datos_DECLARACION_ESCOLARIDAD.VID_HOMOCLAVE;
        //    new public Int32 NID_DECLARACION => datos_DECLARACION_ESCOLARIDAD.NID_DECLARACION;
        //    new public Int32 NID_ESCOLARIDAD => datos_DECLARACION_ESCOLARIDAD.NID_ESCOLARIDAD;
        //    new public Int32 NID_NIVEL_ESCOLARIDAD
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD;
        //            set => datos_DECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD = value;
        //        }
        //    new public String V_INSTITUCION_EDUCATIVA
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVA;
        //            set => datos_DECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVA = value;
        //        }
        //    new public String V_CARRERA
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.V_CARRERA;
        //            set => datos_DECLARACION_ESCOLARIDAD.V_CARRERA = value;
        //        }
        new public Int32 NID_ESTADO_ESCOLARIDAD
        {
            get
            {
                return datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD;
            }
            set
            {
                datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD = value;
            }
        }
        //    new public Int32 NID_DOCUMENTO_OBTENIDO
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDO;
        //            set => datos_DECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDO = value;
        //        }
        //    new public DateTime F_OBTENCION
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.F_OBTENCION;
        //            set => datos_DECLARACION_ESCOLARIDAD.F_OBTENCION = value;
        //        }
        //    new public Int32 NID_PAIS
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.NID_PAIS;
        //            set => datos_DECLARACION_ESCOLARIDAD.NID_PAIS = value;
        //        }
        //    new public String E_OBSERVACIONES
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES;
        //            set => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES = value;
        //        }
        //    new public String E_OBSERVACIONES_MARCADO
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADO;
        //            set => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADO = value;
        //        }
        //    new public String V_OBSERVACIONES_TESTADO
        //        {
        //            get => datos_DECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADO;
        //            set => datos_DECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADO = value;
        //        }
        //    new public Int32 NID_ESTADO_TESTADO => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADO;
        public String V_NIVEL_ESCOLARIDAD => datos_DECLARACION_ESCOLARIDAD.oCAT_NIVEL_ESCOLARIDAD.V_NIVEL_ESCOLARIDAD;
        public String V_ESTADO_ESCOLARIDAD => datos_DECLARACION_ESCOLARIDAD.oCAT_ESTADO_ESCOLARIDAD.V_ESTADO_ESCOLARIDAD;
        public String V_DOCUMENTO_OBTENIDO => datos_DECLARACION_ESCOLARIDAD.oCAT_DOCUMENTO_OBTENIDO.V_DOCUMENTO_OBTENIDO;
        public String V_PAIS => datos_DECLARACION_ESCOLARIDAD.oCAT_PAIS.V_PAIS;
        public String V_NACIONALIDAD_M => datos_DECLARACION_ESCOLARIDAD.oCAT_PAIS.V_NACIONALIDAD_M;
        public String V_NACIONALIDAD_F => datos_DECLARACION_ESCOLARIDAD.oCAT_PAIS.V_NACIONALIDAD_F;
        //private Int32 NID_ESTADO_ESCOLARIDADInicial => 1;
        private Int32 NID_ESTADO_TESTADOInicial => 0;

        #endregion


        #region *** Constructores ***
        //public blld_DECLARACION_ESCOLARIDAD(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ESCOLARIDAD, Int32 NID_NIVEL_ESCOLARIDAD, String V_INSTITUCION_EDUCATIVA, String V_CARRERA, Int32 NID_DOCUMENTO_OBTENIDO, DateTime F_OBTENCION, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO)
        //    : base()
        //{
        //    ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
        //    String _VID_NOMBRE = VID_NOMBRE; 
        //    String _VID_FECHA = VID_FECHA; 
        //    String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
        //    Int32 _NID_DECLARACION = NID_DECLARACION; 
        //    Int32 _NID_ESCOLARIDAD = NID_ESCOLARIDAD; 
        //    this.NID_NIVEL_ESCOLARIDAD = NID_NIVEL_ESCOLARIDAD;
        //    this.V_INSTITUCION_EDUCATIVA = V_INSTITUCION_EDUCATIVA;
        //    this.V_CARRERA = V_CARRERA;
        //    datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD = NID_ESTADO_ESCOLARIDADInicial;
        //    this.NID_DOCUMENTO_OBTENIDO = NID_DOCUMENTO_OBTENIDO;
        //    this.F_OBTENCION = F_OBTENCION;
        //    this.NID_PAIS = NID_PAIS;
        //    this.E_OBSERVACIONES = E_OBSERVACIONES;
        //    this.E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO;
        //    this.V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO;
        //    datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADO = NID_ESTADO_TESTADOInicial;
        //    datos_DECLARACION_ESCOLARIDAD = new dald_DECLARACION_ESCOLARIDAD(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_ESCOLARIDAD, this.NID_NIVEL_ESCOLARIDAD, this.V_INSTITUCION_EDUCATIVA, this.V_CARRERA, this.NID_ESTADO_ESCOLARIDAD, this.NID_DOCUMENTO_OBTENIDO, this.F_OBTENCION, this.NID_PAIS, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
        //}
        public blld_DECLARACION_ESCOLARIDAD(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_ESCOLARIDAD, String V_INSTITUCION_EDUCATIVA, String V_CARRERA,Int32 NID_ESTADO_ESCOLARIDAD, Int32 NID_DOCUMENTO_OBTENIDO, DateTime F_OBTENCION, Int32 NID_PAIS, String E_OBSERVACIONES)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_ESCOLARIDAD = dald_DECLARACION_ESCOLARIDAD.nNuevo_NID_ESCOLARIDAD(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.NID_NIVEL_ESCOLARIDAD = NID_NIVEL_ESCOLARIDAD;
            this.V_INSTITUCION_EDUCATIVA = V_INSTITUCION_EDUCATIVA;
            this.V_CARRERA = V_CARRERA;
            datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD = NID_ESTADO_ESCOLARIDAD;
            this.NID_DOCUMENTO_OBTENIDO = NID_DOCUMENTO_OBTENIDO;
            this.F_OBTENCION = F_OBTENCION;
            this.NID_PAIS = NID_PAIS;
            this.E_OBSERVACIONES = E_OBSERVACIONES;
            this.E_OBSERVACIONES_MARCADO = null;
            this.V_OBSERVACIONES_TESTADO = null;
            datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADO = NID_ESTADO_TESTADOInicial;
            datos_DECLARACION_ESCOLARIDAD = new dald_DECLARACION_ESCOLARIDAD(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_ESCOLARIDAD, this.NID_NIVEL_ESCOLARIDAD, this.V_INSTITUCION_EDUCATIVA, this.V_CARRERA, this.NID_ESTADO_ESCOLARIDAD, this.NID_DOCUMENTO_OBTENIDO, this.F_OBTENCION, this.NID_PAIS, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
