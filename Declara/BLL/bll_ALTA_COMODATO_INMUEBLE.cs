using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_ALTA_COMODATO_INMUEBLE : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_ALTA_COMODATO_INMUEBLE datos_ALTA_COMODATO_INMUEBLE { get; set; }
        public String VID_NOMBRE => datos_ALTA_COMODATO_INMUEBLE.VID_NOMBRE;
        public String VID_FECHA => datos_ALTA_COMODATO_INMUEBLE.VID_FECHA;
        public String VID_HOMOCLAVE => datos_ALTA_COMODATO_INMUEBLE.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_ALTA_COMODATO_INMUEBLE.NID_DECLARACION;
        public Int32 NID_COMODATO => datos_ALTA_COMODATO_INMUEBLE.NID_COMODATO;
        public Int32 NID_TIPO
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_TIPO;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_TIPO = value;
        }
        public String C_CODIGO_POSTAL
        {
            get => datos_ALTA_COMODATO_INMUEBLE.C_CODIGO_POSTAL;
            set => datos_ALTA_COMODATO_INMUEBLE.C_CODIGO_POSTAL = value;
        }
        public Int32 NID_PAIS
        {
            get => datos_ALTA_COMODATO_INMUEBLE.NID_PAIS;
            set => datos_ALTA_COMODATO_INMUEBLE.NID_PAIS = value;
        }
        public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVA;
            set => datos_ALTA_COMODATO_INMUEBLE.CID_ENTIDAD_FEDERATIVA = value;
        }
        public String CID_MUNICIPIO
        {
            get => datos_ALTA_COMODATO_INMUEBLE.CID_MUNICIPIO;
            set => datos_ALTA_COMODATO_INMUEBLE.CID_MUNICIPIO = value;
        }
        public String V_COLONIA
        {
            get => datos_ALTA_COMODATO_INMUEBLE.V_COLONIA;
            set => datos_ALTA_COMODATO_INMUEBLE.V_COLONIA = value;
        }
        public String V_DOMICILIO
        {
            get => datos_ALTA_COMODATO_INMUEBLE.V_DOMICILIO;
            set => datos_ALTA_COMODATO_INMUEBLE.V_DOMICILIO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_COMODATO_INMUEBLE.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_ALTA_COMODATO_INMUEBLE() => datos_ALTA_COMODATO_INMUEBLE = new dald_ALTA_COMODATO_INMUEBLE();
        public bll_ALTA_COMODATO_INMUEBLE(MODELDeclara_V2.ALTA_COMODATO_INMUEBLE ALTA_COMODATO_INMUEBLE) => datos_ALTA_COMODATO_INMUEBLE = new dald_ALTA_COMODATO_INMUEBLE(ALTA_COMODATO_INMUEBLE);
        public bll_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) => datos_ALTA_COMODATO_INMUEBLE = new dald_ALTA_COMODATO_INMUEBLE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO);

//        public bll_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_ALTA_COMODATO_INMUEBLE = new dald_ALTA_COMODATO_INMUEBLE();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_COMODATO = NID_COMODATO; 
//            this.NID_TIPO = NID_TIPO;
//            this.C_CODIGO_POSTAL = C_CODIGO_POSTAL;
//            this.NID_PAIS = NID_PAIS;
//            this.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
//            this.CID_MUNICIPIO = CID_MUNICIPIO;
//            this.V_COLONIA = V_COLONIA;
//            this.V_DOMICILIO = V_DOMICILIO;
//            datos_ALTA_COMODATO_INMUEBLE = new dald_ALTA_COMODATO_INMUEBLE(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_COMODATO, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_COMODATO, this.NID_TIPO, this.C_CODIGO_POSTAL, this.NID_PAIS, this.CID_ENTIDAD_FEDERATIVA, this.CID_MUNICIPIO, this.V_COLONIA, this.V_DOMICILIO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_ALTA_COMODATO_INMUEBLE.update();
        }
        public void delete()
        {
            datos_ALTA_COMODATO_INMUEBLE.delete();
        }
        public void reload()
        {
            datos_ALTA_COMODATO_INMUEBLE.reload();
        }

        #endregion

    }
}
