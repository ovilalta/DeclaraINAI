using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_ALTA_COMODATO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_ALTA_COMODATO datos_ALTA_COMODATO { get; set; }
        public String VID_NOMBRE => datos_ALTA_COMODATO.VID_NOMBRE;
        public String VID_FECHA => datos_ALTA_COMODATO.VID_FECHA;
        public String VID_HOMOCLAVE => datos_ALTA_COMODATO.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_ALTA_COMODATO.NID_DECLARACION;
        public Int32 NID_COMODATO => datos_ALTA_COMODATO.NID_COMODATO;
        public String CID_TIPO_PERSONA
        {
            get => datos_ALTA_COMODATO.CID_TIPO_PERSONA;
            set => datos_ALTA_COMODATO.CID_TIPO_PERSONA = value;
        }
        public String E_TITULAR
        {
            get => datos_ALTA_COMODATO.E_TITULAR;
            set => datos_ALTA_COMODATO.E_TITULAR = value;
        }
        public String E_RFC
        {
            get => datos_ALTA_COMODATO.E_RFC;
            set => datos_ALTA_COMODATO.E_RFC = value;
        }
        public Int32 NID_TIPO_RELACION
        {
            get => datos_ALTA_COMODATO.NID_TIPO_RELACION;
            set => datos_ALTA_COMODATO.NID_TIPO_RELACION = value;
        }
        public String E_OBSERVACIONES
        {
            get => datos_ALTA_COMODATO.E_OBSERVACIONES;
            set => datos_ALTA_COMODATO.E_OBSERVACIONES = value;
        }
        public String E_OBSERVACIONES_MARCADO
        {
            get => datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO;
            set => datos_ALTA_COMODATO.E_OBSERVACIONES_MARCADO = value;
        }
        public String V_OBSERVACIONES_TESTADO
        {
            get => datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO;
            set => datos_ALTA_COMODATO.V_OBSERVACIONES_TESTADO = value;
        }
        public Int32 NID_ESTADO_TESTADO => datos_ALTA_COMODATO.NID_ESTADO_TESTADO;

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_COMODATO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_ALTA_COMODATO() => datos_ALTA_COMODATO = new dald_ALTA_COMODATO();
        public bll_ALTA_COMODATO(MODELDeclara_V2.ALTA_COMODATO ALTA_COMODATO) => datos_ALTA_COMODATO = new dald_ALTA_COMODATO(ALTA_COMODATO);
        public bll_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) => datos_ALTA_COMODATO = new dald_ALTA_COMODATO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO);

//        public bll_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, String CID_TIPO_PERSONA, String E_TITULAR, String E_RFC, Int32 NID_TIPO_RELACION, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_ALTA_COMODATO = new dald_ALTA_COMODATO();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_COMODATO = NID_COMODATO; 
//            this.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
//            this.E_TITULAR = E_TITULAR;
//            this.E_RFC = E_RFC;
//            this.NID_TIPO_RELACION = NID_TIPO_RELACION;
//            this.E_OBSERVACIONES = E_OBSERVACIONES;
//            this.E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO;
//            this.V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO;
//            this.NID_ESTADO_TESTADO = NID_ESTADO_TESTADO;
//            datos_ALTA_COMODATO = new dald_ALTA_COMODATO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_COMODATO, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_COMODATO, this.CID_TIPO_PERSONA, this.E_TITULAR, this.E_RFC, this.NID_TIPO_RELACION, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_ALTA_COMODATO.update();
        }
        public void delete()
        {
            datos_ALTA_COMODATO.delete();
        }
        public void reload()
        {
            datos_ALTA_COMODATO.reload();
        }

        #endregion

    }
}
