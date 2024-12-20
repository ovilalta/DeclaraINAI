using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_CARGO_OTRO : bll_DECLARACION_CARGO_OTRO
    {

        #region *** Propiedades ***
//    new public String VID_NOMBRE => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE;
//    new public String VID_FECHA => datos_DECLARACION_CARGO_OTRO.VID_FECHA;
//    new public String VID_HOMOCLAVE => datos_DECLARACION_CARGO_OTRO.VID_HOMOCLAVE;
//    new public Int32 NID_DECLARACION => datos_DECLARACION_CARGO_OTRO.NID_DECLARACION;
//    new public Int32 NID_NIVEL_GOBIERNO
//        {
//            get => datos_DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO;
//            set => datos_DECLARACION_CARGO_OTRO.NID_NIVEL_GOBIERNO = value;
//        }
//    new public Int32 NID_AMBITO_PUBLICO
//        {
//            get => datos_DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO;
//            set => datos_DECLARACION_CARGO_OTRO.NID_AMBITO_PUBLICO = value;
//        }
//    new public String VID_NOMBRE_ENTE
//        {
//            get => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTE;
//            set => datos_DECLARACION_CARGO_OTRO.VID_NOMBRE_ENTE = value;
//        }
//    new public String V_AREA_ADSCRIPCION
//        {
//            get => datos_DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCION;
//            set => datos_DECLARACION_CARGO_OTRO.V_AREA_ADSCRIPCION = value;
//        }
//    new public String V_CARGO
//        {
//            get => datos_DECLARACION_CARGO_OTRO.V_CARGO;
//            set => datos_DECLARACION_CARGO_OTRO.V_CARGO = value;
//        }
//    new public Boolean L_HONORARIOS
//        {
//            get => datos_DECLARACION_CARGO_OTRO.L_HONORARIOS;
//            set => datos_DECLARACION_CARGO_OTRO.L_HONORARIOS = value;
//        }
//    new public String V_NIVEL_EMPLEO
//        {
//            get => datos_DECLARACION_CARGO_OTRO.V_NIVEL_EMPLEO;
//            set => datos_DECLARACION_CARGO_OTRO.V_NIVEL_EMPLEO = value;
//        }
//    new public String V_FUNCION_PRINCIPAL
//        {
//            get => datos_DECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPAL;
//            set => datos_DECLARACION_CARGO_OTRO.V_FUNCION_PRINCIPAL = value;
//        }
//    new public DateTime F_POSESION
//        {
//            get => datos_DECLARACION_CARGO_OTRO.F_POSESION;
//            set => datos_DECLARACION_CARGO_OTRO.F_POSESION = value;
//        }
//    new public String V_TEL_LABORAL
//        {
//            get => datos_DECLARACION_CARGO_OTRO.V_TEL_LABORAL;
//            set => datos_DECLARACION_CARGO_OTRO.V_TEL_LABORAL = value;
//        }
//    new public String C_CODIGO_POSTAL
//        {
//            get => datos_DECLARACION_CARGO_OTRO.C_CODIGO_POSTAL;
//            set => datos_DECLARACION_CARGO_OTRO.C_CODIGO_POSTAL = value;
//        }
//    new public Int32 NID_PAIS
//        {
//            get => datos_DECLARACION_CARGO_OTRO.NID_PAIS;
//            set => datos_DECLARACION_CARGO_OTRO.NID_PAIS = value;
//        }
//    new public String CID_ENTIDAD_FEDERATIVA
//        {
//            get => datos_DECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVA;
//            set => datos_DECLARACION_CARGO_OTRO.CID_ENTIDAD_FEDERATIVA = value;
//        }
//    new public String CID_MUNICIPIO
//        {
//            get => datos_DECLARACION_CARGO_OTRO.CID_MUNICIPIO;
//            set => datos_DECLARACION_CARGO_OTRO.CID_MUNICIPIO = value;
//        }
//    new public String V_COLONIA
//        {
//            get => datos_DECLARACION_CARGO_OTRO.V_COLONIA;
//            set => datos_DECLARACION_CARGO_OTRO.V_COLONIA = value;
//        }
//    new public String V_DOMICILIO
//        {
//            get => datos_DECLARACION_CARGO_OTRO.V_DOMICILIO;
//            set => datos_DECLARACION_CARGO_OTRO.V_DOMICILIO = value;
//        }
//    new public String V_OBSERVACIONES
//        {
//            get => datos_DECLARACION_CARGO_OTRO.V_OBSERVACIONES;
//            set => datos_DECLARACION_CARGO_OTRO.V_OBSERVACIONES = value;
//        }
        public String V_NIVEL_GOBIERNO => datos_DECLARACION_CARGO_OTRO.oCAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO;
        public String V_MUNICIPIO => datos_DECLARACION_CARGO_OTRO.oCAT_MUNICIPIO.V_MUNICIPIO;
        public String V_NIVEL_GOBIERNO_CAT_NIVEL_GOBIERNO => datos_DECLARACION_CARGO_OTRO.oCAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO;
        public String V_AMBITO_PUBLICO => datos_DECLARACION_CARGO_OTRO.oCAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO;

        #endregion


        #region *** Constructores ***
        public blld_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String VID_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, Boolean L_HONORARIOS, String V_NIVEL_EMPLEO, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, String V_TEL_LABORAL, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_OBSERVACIONES)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            this.NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO;
            this.NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO;
            this.VID_NOMBRE_ENTE = VID_NOMBRE_ENTE;
            this.V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION;
            this.V_CARGO = V_CARGO;
            this.L_HONORARIOS = L_HONORARIOS;
            this.V_NIVEL_EMPLEO = V_NIVEL_EMPLEO;
            this.V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL;
            this.F_POSESION = F_POSESION;
            this.V_TEL_LABORAL = V_TEL_LABORAL;
            this.C_CODIGO_POSTAL = C_CODIGO_POSTAL;
            this.NID_PAIS = NID_PAIS;
            this.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
            this.CID_MUNICIPIO = CID_MUNICIPIO;
            this.V_COLONIA = V_COLONIA;
            this.V_DOMICILIO = V_DOMICILIO;
            this.V_OBSERVACIONES = V_OBSERVACIONES;
            datos_DECLARACION_CARGO_OTRO = new dald_DECLARACION_CARGO_OTRO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, this.NID_NIVEL_GOBIERNO, this.NID_AMBITO_PUBLICO, this.VID_NOMBRE_ENTE, this.V_AREA_ADSCRIPCION, this.V_CARGO, this.L_HONORARIOS, this.V_NIVEL_EMPLEO, this.V_FUNCION_PRINCIPAL, this.F_POSESION, this.V_TEL_LABORAL, this.C_CODIGO_POSTAL, this.NID_PAIS, this.CID_ENTIDAD_FEDERATIVA, this.CID_MUNICIPIO, this.V_COLONIA, this.V_DOMICILIO, this.V_OBSERVACIONES, lOpcionesRegistroExistente);
        }
        public blld_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String VID_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, Boolean L_HONORARIOS, String V_NIVEL_EMPLEO, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, String V_TEL_LABORAL, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_OBSERVACIONES)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = dald_DECLARACION_CARGO_OTRO.nNuevo_NID_DECLARACION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
            this.NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO;
            this.NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO;
            this.VID_NOMBRE_ENTE = VID_NOMBRE_ENTE;
            this.V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION;
            this.V_CARGO = V_CARGO;
            this.L_HONORARIOS = L_HONORARIOS;
            this.V_NIVEL_EMPLEO = V_NIVEL_EMPLEO;
            this.V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL;
            this.F_POSESION = F_POSESION;
            this.V_TEL_LABORAL = V_TEL_LABORAL;
            this.C_CODIGO_POSTAL = C_CODIGO_POSTAL;
            this.NID_PAIS = NID_PAIS;
            this.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
            this.CID_MUNICIPIO = CID_MUNICIPIO;
            this.V_COLONIA = V_COLONIA;
            this.V_DOMICILIO = V_DOMICILIO;
            this.V_OBSERVACIONES = V_OBSERVACIONES;
            datos_DECLARACION_CARGO_OTRO = new dald_DECLARACION_CARGO_OTRO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, this.NID_NIVEL_GOBIERNO, this.NID_AMBITO_PUBLICO, this.VID_NOMBRE_ENTE, this.V_AREA_ADSCRIPCION, this.V_CARGO, this.L_HONORARIOS, this.V_NIVEL_EMPLEO, this.V_FUNCION_PRINCIPAL, this.F_POSESION, this.V_TEL_LABORAL, this.C_CODIGO_POSTAL, this.NID_PAIS, this.CID_ENTIDAD_FEDERATIVA, this.CID_MUNICIPIO, this.V_COLONIA, this.V_DOMICILIO, this.V_OBSERVACIONES, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
