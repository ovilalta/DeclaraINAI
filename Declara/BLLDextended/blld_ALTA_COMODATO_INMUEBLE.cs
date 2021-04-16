using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_COMODATO_INMUEBLE : bll_ALTA_COMODATO_INMUEBLE
    {

        #region *** Propiedades ***
//    new public String VID_NOMBRE => datos_ALTA_COMODATO_INMUEBLE.VID_NOMBRE;
//    new public String VID_FECHA => datos_ALTA_COMODATO_INMUEBLE.VID_FECHA;
//    new public String VID_HOMOCLAVE => datos_ALTA_COMODATO_INMUEBLE.VID_HOMOCLAVE;
//    new public Int32 NID_DECLARACION => datos_ALTA_COMODATO_INMUEBLE.NID_DECLARACION;
//    new public Int32 NID_COMODATO => datos_ALTA_COMODATO_INMUEBLE.NID_COMODATO;
//    new public Int32 NID_TIPO
//        {
//            get => datos_ALTA_COMODATO_INMUEBLE.NID_TIPO;
//            set => datos_ALTA_COMODATO_INMUEBLE.NID_TIPO = value;
//        }
//    new public String C_CODIGO_POSTAL
//        {
//            get => datos_ALTA_COMODATO_INMUEBLE.C_CODIGO_POSTAL;
//            set => datos_ALTA_COMODATO_INMUEBLE.C_CODIGO_POSTAL = value;
//        }
//    new public Int32 NID_PAIS
//        {
//            get => datos_ALTA_COMODATO_INMUEBLE.NID_PAIS;
//            set => datos_ALTA_COMODATO_INMUEBLE.NID_PAIS = value;
//        }
//    new public String CID_ENTIDAD_FEDERATIVA
//        {
//            get => datos_ALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVA;
//            set => datos_ALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVA = value;
//        }
//    new public String CID_MUNICIPIO
//        {
//            get => datos_ALTA_COMODATO_INMUEBLE.CID_MUNICIPIO;
//            set => datos_ALTA_COMODATO_INMUEBLE.CID_MUNICIPIO = value;
//        }
//    new public String V_COLONIA
//        {
//            get => datos_ALTA_COMODATO_INMUEBLE.V_COLONIA;
//            set => datos_ALTA_COMODATO_INMUEBLE.V_COLONIA = value;
//        }
//    new public String V_DOMICILIO
//        {
//            get => datos_ALTA_COMODATO_INMUEBLE.V_DOMICILIO;
//            set => datos_ALTA_COMODATO_INMUEBLE.V_DOMICILIO = value;
//        }
        public String V_MUNICIPIO => datos_ALTA_COMODATO_INMUEBLE.oCAT_MUNICIPIO.V_MUNICIPIO;
        public String V_TIPO => datos_ALTA_COMODATO_INMUEBLE.oCAT_TIPO_INMUEBLE.V_TIPO;
        public Boolean L_ACTIVO => datos_ALTA_COMODATO_INMUEBLE.oCAT_TIPO_INMUEBLE.L_ACTIVO;

        #endregion


        #region *** Constructores ***
        public blld_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO)
            : base()
        {
            //ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_COMODATO = NID_COMODATO; 
            this.NID_TIPO = NID_TIPO;
            this.C_CODIGO_POSTAL = C_CODIGO_POSTAL;
            this.NID_PAIS = NID_PAIS;
            this.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
            this.CID_MUNICIPIO = CID_MUNICIPIO;
            this.V_COLONIA = V_COLONIA;
            this.V_DOMICILIO = V_DOMICILIO;
            datos_ALTA_COMODATO_INMUEBLE = new dald_ALTA_COMODATO_INMUEBLE(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_COMODATO, this.NID_TIPO, this.C_CODIGO_POSTAL, this.NID_PAIS, this.CID_ENTIDAD_FEDERATIVA, this.CID_MUNICIPIO, this.V_COLONIA, this.V_DOMICILIO, lOpcionesRegistroExistente);
        }
        public blld_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_TIPO, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_COMODATO = dald_ALTA_COMODATO_INMUEBLE.nNuevo_NID_COMODATO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.NID_TIPO = NID_TIPO;
            this.C_CODIGO_POSTAL = C_CODIGO_POSTAL;
            this.NID_PAIS = NID_PAIS;
            this.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
            this.CID_MUNICIPIO = CID_MUNICIPIO;
            this.V_COLONIA = V_COLONIA;
            this.V_DOMICILIO = V_DOMICILIO;
            datos_ALTA_COMODATO_INMUEBLE = new dald_ALTA_COMODATO_INMUEBLE(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_COMODATO, this.NID_TIPO, this.C_CODIGO_POSTAL, this.NID_PAIS, this.CID_ENTIDAD_FEDERATIVA, this.CID_MUNICIPIO, this.V_COLONIA, this.V_DOMICILIO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
