using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_PERSONALES : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_DECLARACION_PERSONALES datos_DECLARACION_PERSONALES { get; set; }
        public String VID_NOMBRE => datos_DECLARACION_PERSONALES.VID_NOMBRE;
        public String VID_FECHA => datos_DECLARACION_PERSONALES.VID_FECHA;
        public String VID_HOMOCLAVE => datos_DECLARACION_PERSONALES.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_DECLARACION_PERSONALES.NID_DECLARACION;
        public String C_GENERO
        {
            get => datos_DECLARACION_PERSONALES.C_GENERO;
            set => datos_DECLARACION_PERSONALES.C_GENERO = value;
        }
        public String C_CURP
        {
            get => datos_DECLARACION_PERSONALES.C_CURP;
            set => datos_DECLARACION_PERSONALES.C_CURP = value;
        }
        public Int32 NID_PAIS
        {
            get => datos_DECLARACION_PERSONALES.NID_PAIS;
            set => datos_DECLARACION_PERSONALES.NID_PAIS = value;
        }
        public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA;
            set => datos_DECLARACION_PERSONALES.CID_ENTIDAD_FEDERATIVA = value;
        }
        public Int32 NID_NACIONALIDAD
        {
            get => datos_DECLARACION_PERSONALES.NID_NACIONALIDAD;
            set => datos_DECLARACION_PERSONALES.NID_NACIONALIDAD = value;
        }
        public Int32 NID_ESTADO_CIVIL => datos_DECLARACION_PERSONALES.NID_ESTADO_CIVIL;
        public System.Nullable<Boolean> L_SERVIDOR_ANTERIOR
        {
            get => datos_DECLARACION_PERSONALES.L_SERVIDOR_ANTERIOR;
            set => datos_DECLARACION_PERSONALES.L_SERVIDOR_ANTERIOR = value;
        }
        public System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_INICIO
        {
            get => datos_DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_INICIO;
            set => datos_DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_INICIO = value;
        }
        public System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_FIN
        {
            get => datos_DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_FIN;
            set => datos_DECLARACION_PERSONALES.F_SERVIDOR_ANTERIOR_FIN = value;
        }
        public String E_OBSERVACIONES
        {
            get => datos_DECLARACION_PERSONALES.E_OBSERVACIONES;
            set => datos_DECLARACION_PERSONALES.E_OBSERVACIONES = value;
        }
        public String E_OBSERVACIONES_MARCADO
        {
            get => datos_DECLARACION_PERSONALES.E_OBSERVACIONES_MARCADO;
            set => datos_DECLARACION_PERSONALES.E_OBSERVACIONES_MARCADO = value;
        }
        public String V_OBSERVACIONES_TESTADO
        {
            get => datos_DECLARACION_PERSONALES.V_OBSERVACIONES_TESTADO;
            set => datos_DECLARACION_PERSONALES.V_OBSERVACIONES_TESTADO = value;
        }
        public Int32 NID_ESTADO_TESTADO => datos_DECLARACION_PERSONALES.NID_ESTADO_TESTADO;

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_PERSONALES.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_DECLARACION_PERSONALES() => datos_DECLARACION_PERSONALES = new dald_DECLARACION_PERSONALES();
        public bll_DECLARACION_PERSONALES(MODELDeclara_V2.DECLARACION_PERSONALES DECLARACION_PERSONALES) => datos_DECLARACION_PERSONALES = new dald_DECLARACION_PERSONALES(DECLARACION_PERSONALES);
        public bll_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) => datos_DECLARACION_PERSONALES = new dald_DECLARACION_PERSONALES(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

//        public bll_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_GENERO, String C_CURP, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_NACIONALIDAD, Int32 NID_ESTADO_CIVIL, System.Nullable<Boolean> L_SERVIDOR_ANTERIOR, System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_INICIO, System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_FIN, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_DECLARACION_PERSONALES = new dald_DECLARACION_PERSONALES();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            this.C_GENERO = C_GENERO;
//            this.C_CURP = C_CURP;
//            this.NID_PAIS = NID_PAIS;
//            this.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
//            this.NID_NACIONALIDAD = NID_NACIONALIDAD;
//            this.NID_ESTADO_CIVIL = NID_ESTADO_CIVIL;
//            this.L_SERVIDOR_ANTERIOR = L_SERVIDOR_ANTERIOR;
//            this.F_SERVIDOR_ANTERIOR_INICIO = F_SERVIDOR_ANTERIOR_INICIO;
//            this.F_SERVIDOR_ANTERIOR_FIN = F_SERVIDOR_ANTERIOR_FIN;
//            this.E_OBSERVACIONES = E_OBSERVACIONES;
//            this.E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO;
//            this.V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO;
//            this.NID_ESTADO_TESTADO = NID_ESTADO_TESTADO;
//            datos_DECLARACION_PERSONALES = new dald_DECLARACION_PERSONALES(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.C_GENERO, this.C_CURP, this.NID_PAIS, this.CID_ENTIDAD_FEDERATIVA, this.NID_NACIONALIDAD, this.NID_ESTADO_CIVIL, this.L_SERVIDOR_ANTERIOR, this.F_SERVIDOR_ANTERIOR_INICIO, this.F_SERVIDOR_ANTERIOR_FIN, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_DECLARACION_PERSONALES.update();
        }
        public void delete()
        {
            datos_DECLARACION_PERSONALES.delete();
        }
        public void reload()
        {
            datos_DECLARACION_PERSONALES.reload();
        }

        #endregion

    }
}
