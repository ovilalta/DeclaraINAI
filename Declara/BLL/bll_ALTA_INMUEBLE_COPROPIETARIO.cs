using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_ALTA_INMUEBLE_COPROPIETARIO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_ALTA_INMUEBLE_COPROPIETARIO datos_ALTA_INMUEBLE_COPROPIETARIO { get; set; }
        public String VID_NOMBRE => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_NOMBRE;
        public String VID_FECHA => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_FECHA;
        public String VID_HOMOCLAVE => datos_ALTA_INMUEBLE_COPROPIETARIO.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_DECLARACION;
        public Int32 NID_INMUEBLE => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_INMUEBLE;
        public Int32 NID_COPROPIETARIO => datos_ALTA_INMUEBLE_COPROPIETARIO.NID_COPROPIETARIO;
        public String CID_TIPO_PERSONA
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONA;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.CID_TIPO_PERSONA = value;
        }
        public String V_NOMBRE
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.V_NOMBRE;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.V_NOMBRE = value;
        }
        public String V_RFC
        {
            get => datos_ALTA_INMUEBLE_COPROPIETARIO.V_RFC;
            set => datos_ALTA_INMUEBLE_COPROPIETARIO.V_RFC = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_ALTA_INMUEBLE_COPROPIETARIO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_ALTA_INMUEBLE_COPROPIETARIO() => datos_ALTA_INMUEBLE_COPROPIETARIO = new dald_ALTA_INMUEBLE_COPROPIETARIO();
        public bll_ALTA_INMUEBLE_COPROPIETARIO(MODELDeclara_V2.ALTA_INMUEBLE_COPROPIETARIO ALTA_INMUEBLE_COPROPIETARIO) => datos_ALTA_INMUEBLE_COPROPIETARIO = new dald_ALTA_INMUEBLE_COPROPIETARIO(ALTA_INMUEBLE_COPROPIETARIO);
        public bll_ALTA_INMUEBLE_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_COPROPIETARIO) => datos_ALTA_INMUEBLE_COPROPIETARIO = new dald_ALTA_INMUEBLE_COPROPIETARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE, NID_COPROPIETARIO);

//        public bll_ALTA_INMUEBLE_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_COPROPIETARIO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_ALTA_INMUEBLE_COPROPIETARIO = new dald_ALTA_INMUEBLE_COPROPIETARIO();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_INMUEBLE = NID_INMUEBLE; 
//            Int32 _NID_COPROPIETARIO = NID_COPROPIETARIO; 
//            this.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
//            this.V_NOMBRE = V_NOMBRE;
//            this.V_RFC = V_RFC;
//            datos_ALTA_INMUEBLE_COPROPIETARIO = new dald_ALTA_INMUEBLE_COPROPIETARIO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_INMUEBLE, _NID_COPROPIETARIO, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_INMUEBLE, this.NID_COPROPIETARIO, this.CID_TIPO_PERSONA, this.V_NOMBRE, this.V_RFC, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_ALTA_INMUEBLE_COPROPIETARIO.update();
        }
        public void delete()
        {
            datos_ALTA_INMUEBLE_COPROPIETARIO.delete();
        }
        public void reload()
        {
            datos_ALTA_INMUEBLE_COPROPIETARIO.reload();
        }

        #endregion

    }
}
