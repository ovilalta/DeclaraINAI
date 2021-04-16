using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_EXPERIENCIA_LABORAL : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_DECLARACION_EXPERIENCIA_LABORAL datos_DECLARACION_EXPERIENCIA_LABORAL { get; set; }
        public String VID_NOMBRE => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_NOMBRE;
        public String VID_FECHA => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_FECHA;
        public String VID_HOMOCLAVE => datos_DECLARACION_EXPERIENCIA_LABORAL.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_DECLARACION;
        public Int32 NID_EXPERIENCIA_LABORAL => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_EXPERIENCIA_LABORAL;
        public Int32 NID_AMBITO_SECTOR
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTOR;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_SECTOR = value;
        }
        public Int32 NID_NIVEL_GOBIERNO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_NIVEL_GOBIERNO = value;
        }
        public Int32 NID_AMBITO_PUBLICO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_AMBITO_PUBLICO = value;
        }
        public String V_NOMBRE
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_NOMBRE;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_NOMBRE = value;
        }
        public String V_RFC
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_RFC;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_RFC = value;
        }
        public String V_AREA_ADSCRIPCION
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCION;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_AREA_ADSCRIPCION = value;
        }
        public String V_PUESTO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_PUESTO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_PUESTO = value;
        }
        public String V_FUNCION_PRINCIPAL
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPAL;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_FUNCION_PRINCIPAL = value;
        }
        public Int32 NID_SECTOR
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_SECTOR;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_SECTOR = value;
        }
        public DateTime F_INGRESO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.F_INGRESO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.F_INGRESO = value;
        }
        public DateTime F_EGRESO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.F_EGRESO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.F_EGRESO = value;
        }
        public Int32 NID_PAIS
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_PAIS;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_PAIS = value;
        }
        public String E_OBSERVACIONES
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES = value;
        }        public String V_SECTOR
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_SECTOR;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_SECTOR = value;
        }
        public String E_OBSERVACIONES_MARCADO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.E_OBSERVACIONES_MARCADO = value;
        }
        public String V_OBSERVACIONES_TESTADO
        {
            get => datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO;
            set => datos_DECLARACION_EXPERIENCIA_LABORAL.V_OBSERVACIONES_TESTADO = value;
        }
        public Int32 NID_ESTADO_TESTADO => datos_DECLARACION_EXPERIENCIA_LABORAL.NID_ESTADO_TESTADO;

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_EXPERIENCIA_LABORAL.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_DECLARACION_EXPERIENCIA_LABORAL() => datos_DECLARACION_EXPERIENCIA_LABORAL = new dald_DECLARACION_EXPERIENCIA_LABORAL();
        public bll_DECLARACION_EXPERIENCIA_LABORAL(MODELDeclara_V2.DECLARACION_EXPERIENCIA_LABORAL DECLARACION_EXPERIENCIA_LABORAL) => datos_DECLARACION_EXPERIENCIA_LABORAL = new dald_DECLARACION_EXPERIENCIA_LABORAL(DECLARACION_EXPERIENCIA_LABORAL);
        public bll_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL) => datos_DECLARACION_EXPERIENCIA_LABORAL = new dald_DECLARACION_EXPERIENCIA_LABORAL(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EXPERIENCIA_LABORAL);

//        public bll_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE, String V_RFC, String V_AREA_ADSCRIPCION, String V_PUESTO, String V_FUNCION_PRINCIPAL, Int32 NID_SECTOR, DateTime F_INGRESO, DateTime F_EGRESO, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_DECLARACION_EXPERIENCIA_LABORAL = new dald_DECLARACION_EXPERIENCIA_LABORAL();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_EXPERIENCIA_LABORAL = NID_EXPERIENCIA_LABORAL; 
//            this.NID_AMBITO_SECTOR = NID_AMBITO_SECTOR;
//            this.NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO;
//            this.NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO;
//            this.V_NOMBRE = V_NOMBRE;
//            this.V_RFC = V_RFC;
//            this.V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION;
//            this.V_PUESTO = V_PUESTO;
//            this.V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL;
//            this.NID_SECTOR = NID_SECTOR;
//            this.F_INGRESO = F_INGRESO;
//            this.F_EGRESO = F_EGRESO;
//            this.NID_PAIS = NID_PAIS;
//            this.E_OBSERVACIONES = E_OBSERVACIONES;
//            this.E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO;
//            this.V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO;
//            this.NID_ESTADO_TESTADO = NID_ESTADO_TESTADO;
//            datos_DECLARACION_EXPERIENCIA_LABORAL = new dald_DECLARACION_EXPERIENCIA_LABORAL(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_EXPERIENCIA_LABORAL, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_EXPERIENCIA_LABORAL, this.NID_AMBITO_SECTOR, this.NID_NIVEL_GOBIERNO, this.NID_AMBITO_PUBLICO, this.V_NOMBRE, this.V_RFC, this.V_AREA_ADSCRIPCION, this.V_PUESTO, this.V_FUNCION_PRINCIPAL, this.NID_SECTOR, this.F_INGRESO, this.F_EGRESO, this.NID_PAIS, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_DECLARACION_EXPERIENCIA_LABORAL.update();
        }
        public void delete()
        {
            datos_DECLARACION_EXPERIENCIA_LABORAL.delete();
        }
        public void reload()
        {
            datos_DECLARACION_EXPERIENCIA_LABORAL.reload();
        }

        #endregion

    }
}
