using Declara_V2.DALD;
using System;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_DOM_PARTICULAR : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_DECLARACION_DOM_PARTICULAR datos_DECLARACION_DOM_PARTICULAR { get; set; }
        public String VID_NOMBRE => datos_DECLARACION_DOM_PARTICULAR.VID_NOMBRE;
        public String VID_FECHA => datos_DECLARACION_DOM_PARTICULAR.VID_FECHA;
        public String VID_HOMOCLAVE => datos_DECLARACION_DOM_PARTICULAR.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_DECLARACION_DOM_PARTICULAR.NID_DECLARACION;
        public String C_CODIGO_POSTAL
        {
            get => datos_DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL;
            set => datos_DECLARACION_DOM_PARTICULAR.C_CODIGO_POSTAL = value;
        }
        public Int32 NID_PAIS
        {
            get => datos_DECLARACION_DOM_PARTICULAR.NID_PAIS;
            set => datos_DECLARACION_DOM_PARTICULAR.NID_PAIS = value;
        }
        public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA;
            set => datos_DECLARACION_DOM_PARTICULAR.CID_ENTIDAD_FEDERATIVA = value;
        }
        public String CID_MUNICIPIO
        {
            get => datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO;
            set => datos_DECLARACION_DOM_PARTICULAR.CID_MUNICIPIO = value;
        }
        public String V_ENTIDAD_FEDERATIVA
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_ENTIDAD_FEDERATIVA;
            set => datos_DECLARACION_DOM_PARTICULAR.V_ENTIDAD_FEDERATIVA = value;
        }
        public String V_MUNICIPIO
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_MUNICIPIO;
            set => datos_DECLARACION_DOM_PARTICULAR.V_MUNICIPIO = value;
        }
        public String V_COLONIA
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_COLONIA;
            set => datos_DECLARACION_DOM_PARTICULAR.V_COLONIA = value;
        }
        public String V_DOMICILIO
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO;
            set => datos_DECLARACION_DOM_PARTICULAR.V_DOMICILIO = value;
        }
        public String V_CORREO
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_CORREO;
            set => datos_DECLARACION_DOM_PARTICULAR.V_CORREO = value;
        }
        public String V_TEL_PARTICULAR
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR;
            set => datos_DECLARACION_DOM_PARTICULAR.V_TEL_PARTICULAR = value;
        }
        public String V_TEL_CELULAR
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR;
            set => datos_DECLARACION_DOM_PARTICULAR.V_TEL_CELULAR = value;
        }
        public String E_OBSERVACIONES
        {
            get => datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES;
            set => datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES = value;
        }
        public String E_OBSERVACIONES_MARCADO
        {
            get => datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES_MARCADO;
            set => datos_DECLARACION_DOM_PARTICULAR.E_OBSERVACIONES_MARCADO = value;
        }
        public String V_OBSERVACIONES_TESTADO
        {
            get => datos_DECLARACION_DOM_PARTICULAR.V_OBSERVACIONES_TESTADO;
            set => datos_DECLARACION_DOM_PARTICULAR.V_OBSERVACIONES_TESTADO = value;
        }
        public Int32 NID_ESTADO_TESTADO => datos_DECLARACION_DOM_PARTICULAR.NID_ESTADO_TESTADO;

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_DOM_PARTICULAR.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_DECLARACION_DOM_PARTICULAR() => datos_DECLARACION_DOM_PARTICULAR = new dald_DECLARACION_DOM_PARTICULAR();
        public bll_DECLARACION_DOM_PARTICULAR(MODELDeclara_V2.DECLARACION_DOM_PARTICULAR DECLARACION_DOM_PARTICULAR) => datos_DECLARACION_DOM_PARTICULAR = new dald_DECLARACION_DOM_PARTICULAR(DECLARACION_DOM_PARTICULAR);
        public bll_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) => datos_DECLARACION_DOM_PARTICULAR = new dald_DECLARACION_DOM_PARTICULAR(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);

        //        public bll_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_CORREO, String V_TEL_PARTICULAR, String V_TEL_CELULAR, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO)
        //        {
        //            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
        //            datos_DECLARACION_DOM_PARTICULAR = new dald_DECLARACION_DOM_PARTICULAR();
        //            String _VID_NOMBRE = VID_NOMBRE; 
        //            String _VID_FECHA = VID_FECHA; 
        //            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
        //            Int32 _NID_DECLARACION = NID_DECLARACION; 
        //            this.C_CODIGO_POSTAL = C_CODIGO_POSTAL;
        //            this.NID_PAIS = NID_PAIS;
        //            this.CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA;
        //            this.CID_MUNICIPIO = CID_MUNICIPIO;
        //            this.V_COLONIA = V_COLONIA;
        //            this.V_DOMICILIO = V_DOMICILIO;
        //            this.V_CORREO = V_CORREO;
        //            this.V_TEL_PARTICULAR = V_TEL_PARTICULAR;
        //            this.V_TEL_CELULAR = V_TEL_CELULAR;
        //            this.E_OBSERVACIONES = E_OBSERVACIONES;
        //            this.E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO;
        //            this.V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO;
        //            this.NID_ESTADO_TESTADO = NID_ESTADO_TESTADO;
        //            datos_DECLARACION_DOM_PARTICULAR = new dald_DECLARACION_DOM_PARTICULAR(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.C_CODIGO_POSTAL, this.NID_PAIS, this.CID_ENTIDAD_FEDERATIVA, this.CID_MUNICIPIO, this.V_COLONIA, this.V_DOMICILIO, this.V_CORREO, this.V_TEL_PARTICULAR, this.V_TEL_CELULAR, this.E_OBSERVACIONES, this.E_OBSERVACIONES_MARCADO, this.V_OBSERVACIONES_TESTADO, this.NID_ESTADO_TESTADO, lOpcionesRegistroExistente);
        //        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_DECLARACION_DOM_PARTICULAR.update();
        }
        public void delete()
        {
            datos_DECLARACION_DOM_PARTICULAR.delete();
        }
        public void reload()
        {
            datos_DECLARACION_DOM_PARTICULAR.reload();
        }

        #endregion

    }
}
