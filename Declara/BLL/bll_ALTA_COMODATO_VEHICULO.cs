using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_ALTA_COMODATO_VEHICULO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_ALTA_COMODATO_VEHICULO datos_ALTA_COMODATO_VEHICULO { get; set; }
        public String VID_NOMBRE => datos_ALTA_COMODATO_VEHICULO.VID_NOMBRE;
        public String VID_FECHA => datos_ALTA_COMODATO_VEHICULO.VID_FECHA;
        public String VID_HOMOCLAVE => datos_ALTA_COMODATO_VEHICULO.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_ALTA_COMODATO_VEHICULO.NID_DECLARACION;
        public Int32 NID_COMODATO => datos_ALTA_COMODATO_VEHICULO.NID_COMODATO;
        public Int32 NID_TIPO_VEHICULO
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_TIPO_VEHICULO;
            set => datos_ALTA_COMODATO_VEHICULO.NID_TIPO_VEHICULO = value;
        }
        public Int32 NID_MARCA
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_MARCA;
            set => datos_ALTA_COMODATO_VEHICULO.NID_MARCA = value;
        }
        public String C_MODELO
        {
            get => datos_ALTA_COMODATO_VEHICULO.C_MODELO;
            set => datos_ALTA_COMODATO_VEHICULO.C_MODELO = value;
        }
        public String V_DESCRIPCION
        {
            get => datos_ALTA_COMODATO_VEHICULO.V_DESCRIPCION;
            set => datos_ALTA_COMODATO_VEHICULO.V_DESCRIPCION = value;
        }
        public String E_NUMERO_SERIE
        {
            get => datos_ALTA_COMODATO_VEHICULO.E_NUMERO_SERIE;
            set => datos_ALTA_COMODATO_VEHICULO.E_NUMERO_SERIE = value;
        }
        public Int32 NID_PAIS
        {
            get => datos_ALTA_COMODATO_VEHICULO.NID_PAIS;
            set => datos_ALTA_COMODATO_VEHICULO.NID_PAIS = value;
        }
        public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_COMODATO_VEHICULO.CID_ENTIDAD_FEDERATIVA;
            set => datos_ALTA_COMODATO_VEHICULO.CID_ENTIDAD_FEDERATIVA = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_COMODATO_VEHICULO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_ALTA_COMODATO_VEHICULO() => datos_ALTA_COMODATO_VEHICULO = new dald_ALTA_COMODATO_VEHICULO();
        public bll_ALTA_COMODATO_VEHICULO(MODELDeclara_V2.ALTA_COMODATO_VEHICULO ALTA_COMODATO_VEHICULO) => datos_ALTA_COMODATO_VEHICULO = new dald_ALTA_COMODATO_VEHICULO(ALTA_COMODATO_VEHICULO);
        public bll_ALTA_COMODATO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) => datos_ALTA_COMODATO_VEHICULO = new dald_ALTA_COMODATO_VEHICULO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO);

//        public bll_ALTA_COMODATO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO_VEHICULO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, String E_NUMERO_SERIE, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_ALTA_COMODATO_VEHICULO = new dald_ALTA_COMODATO_VEHICULO();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_COMODATO = NID_COMODATO; 
//            this.NID_TIPO_VEHICULO = NID_TIPO_VEHICULO;
//            this.NID_MARCA = NID_MARCA;
//            this.C_MODELO = C_MODELO;
//            this.V_DESCRIPCION = V_DESCRIPCION;
//            this.E_NUMERO_SERIE = E_NUMERO_SERIE;
//            this.NID_PAIS = NID_PAIS;
//            this.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
//            datos_ALTA_COMODATO_VEHICULO = new dald_ALTA_COMODATO_VEHICULO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_COMODATO, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_COMODATO, this.NID_TIPO_VEHICULO, this.NID_MARCA, this.C_MODELO, this.V_DESCRIPCION, this.E_NUMERO_SERIE, this.NID_PAIS, this.CID_ENTIDAD_FEDERATIVA, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_ALTA_COMODATO_VEHICULO.update();
        }
        public void delete()
        {
            datos_ALTA_COMODATO_VEHICULO.delete();
        }
        public void reload()
        {
            datos_ALTA_COMODATO_VEHICULO.reload();
        }

        #endregion

    }
}
