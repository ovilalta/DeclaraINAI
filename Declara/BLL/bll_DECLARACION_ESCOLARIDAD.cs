using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_ESCOLARIDAD : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_DECLARACION_ESCOLARIDAD datos_DECLARACION_ESCOLARIDAD { get; set; }
        public String VID_NOMBRE => datos_DECLARACION_ESCOLARIDAD.VID_NOMBRE;
        public String VID_FECHA => datos_DECLARACION_ESCOLARIDAD.VID_FECHA;
        public String VID_HOMOCLAVE => datos_DECLARACION_ESCOLARIDAD.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_DECLARACION_ESCOLARIDAD.NID_DECLARACION;
        public Int32 NID_ESCOLARIDAD => datos_DECLARACION_ESCOLARIDAD.NID_ESCOLARIDAD;
        public Int32 NID_NIVEL_ESCOLARIDAD
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD;
            set => datos_DECLARACION_ESCOLARIDAD.NID_NIVEL_ESCOLARIDAD = value;
        }
        public String V_INSTITUCION_EDUCATIVA
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVA;
            set => datos_DECLARACION_ESCOLARIDAD.V_INSTITUCION_EDUCATIVA = value;
        }
        public String V_CARRERA
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_CARRERA;
            set => datos_DECLARACION_ESCOLARIDAD.V_CARRERA = value;
        }
        public Int32 NID_ESTADO_ESCOLARIDAD => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD;
        public Int32 NID_DOCUMENTO_OBTENIDO
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDO;
            set => datos_DECLARACION_ESCOLARIDAD.NID_DOCUMENTO_OBTENIDO = value;
        }
        public DateTime F_OBTENCION
        {
            get => datos_DECLARACION_ESCOLARIDAD.F_OBTENCION;
            set => datos_DECLARACION_ESCOLARIDAD.F_OBTENCION = value;
        }
        public Int32 NID_PAIS
        {
            get => datos_DECLARACION_ESCOLARIDAD.NID_PAIS;
            set => datos_DECLARACION_ESCOLARIDAD.NID_PAIS = value;
        }
        public String E_OBSERVACIONES
        {
            get => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES;
            set => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES = value;
        }
        public String E_OBSERVACIONES_MARCADO
        {
            get => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADO;
            set => datos_DECLARACION_ESCOLARIDAD.E_OBSERVACIONES_MARCADO = value;
        }
        public String V_OBSERVACIONES_TESTADO
        {
            get => datos_DECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADO;
            set => datos_DECLARACION_ESCOLARIDAD.V_OBSERVACIONES_TESTADO = value;
        }
        public Int32 NID_ESTADO_TESTADO => datos_DECLARACION_ESCOLARIDAD.NID_ESTADO_TESTADO;

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_ESCOLARIDAD.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_DECLARACION_ESCOLARIDAD() => datos_DECLARACION_ESCOLARIDAD = new dald_DECLARACION_ESCOLARIDAD();
        public bll_DECLARACION_ESCOLARIDAD(MODELDeclara_V2.DECLARACION_ESCOLARIDAD DECLARACION_ESCOLARIDAD) => datos_DECLARACION_ESCOLARIDAD = new dald_DECLARACION_ESCOLARIDAD(DECLARACION_ESCOLARIDAD);
        public bll_DECLARACION_ESCOLARIDAD(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ESCOLARIDAD) => datos_DECLARACION_ESCOLARIDAD = new dald_DECLARACION_ESCOLARIDAD(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ESCOLARIDAD);

//        public bll_DECLARACION_ESCOLARIDAD(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ESCOLARIDAD, Int32 NID_NIVEL_ESCOLARIDAD, String V_INSTITUCION_EDUCATIVA, String V_CARRERA, Int32 NID_ESTADO_ESCOLARIDAD, Int32 NID_DOCUMENTO_OBTENIDO, DateTime F_OBTENCION, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_DECLARACION_ESCOLARIDAD = new dald_DECLARACION_ESCOLARIDAD();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_ESCOLARIDAD = NID_ESCOLARIDAD; 
//            this.NID_NIVEL_ESCOLARIDAD = NID_NIVEL_ESCOLARIDAD;
//            this.V_INSTITUCION_EDUCATIVA = V_INSTITUCION_EDUCATIVA;
//            this.V_CARRERA = V_CARRERA;
//            this.NID_ESTADO_ESCOLARIDAD = NID_ESTADO_ESCOLARIDAD;
//            this.NID_DOCUMENTO_OBTENIDO = NID_DOCUMENTO_OBTENIDO;
//            this.F_OBTENCION = F_OBTENCION;
//            this.NID_PAIS = NID_PAIS;
//            this.E_OBSERVACIONES = E_OBSERVACIONES;
//            this.E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO;
//            this.V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO;
//            this.NID_ESTADO_TESTADO = NID_ESTADO_TESTADO;
//            datos_DECLARACION_ESCOLARIDAD = new dald_DECLARACION_ESCOLARIDAD(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_ESCOLARIDAD, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_ESCOLARIDAD, this.NID_NIVEL_ESCOLARIDAD, this.V_INSTITUCION_EDUCATIVA, this.V_CARRERA, this.NID_ESTADO_ESCOLARIDAD, this.NID_DOCUMENTO_OBTENIDO, this.F_OBTENCION, this.NID_PAIS, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_DECLARACION_ESCOLARIDAD.update();
        }
        public void delete()
        {
            datos_DECLARACION_ESCOLARIDAD.delete();
        }
        public void reload()
        {
            datos_DECLARACION_ESCOLARIDAD.reload();
        }

        #endregion

    }
}
