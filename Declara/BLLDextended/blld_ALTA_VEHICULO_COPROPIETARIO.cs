using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_VEHICULO_COPROPIETARIO : bll_ALTA_VEHICULO_COPROPIETARIO
    {

        #region *** Propiedades ***
        //    new public String VID_NOMBRE => datos_ALTA_VEHICULO_COPROPIETARIO.VID_NOMBRE;
        //    new public String VID_FECHA => datos_ALTA_VEHICULO_COPROPIETARIO.VID_FECHA;
        //    new public String VID_HOMOCLAVE => datos_ALTA_VEHICULO_COPROPIETARIO.VID_HOMOCLAVE;
        //    new public Int32 NID_DECLARACION => datos_ALTA_VEHICULO_COPROPIETARIO.NID_DECLARACION;
        //    new public Int32 NID_VEHICULO => datos_ALTA_VEHICULO_COPROPIETARIO.NID_VEHICULO;
        //    new public Int32 NID_COPROPIETARIO => datos_ALTA_VEHICULO_COPROPIETARIO.NID_COPROPIETARIO;
        //    new public String CID_TIPO_PERSONA
        //        {
        //            get => datos_ALTA_VEHICULO_COPROPIETARIO.CID_TIPO_PERSONA;
        //            set => datos_ALTA_VEHICULO_COPROPIETARIO.CID_TIPO_PERSONA = value;
        //        }
        //    new public String V_NOMBRE
        //        {
        //            get => datos_ALTA_VEHICULO_COPROPIETARIO.V_NOMBRE;
        //            set => datos_ALTA_VEHICULO_COPROPIETARIO.V_NOMBRE = value;
        //        }
        //    new public String V_RFC
        //        {
        //            get => datos_ALTA_VEHICULO_COPROPIETARIO.V_RFC;
        //            set => datos_ALTA_VEHICULO_COPROPIETARIO.V_RFC = value;
        //        }
        //    new public Int32 NID_PAIS
        //        {
        //            get => datos_ALTA_VEHICULO_COPROPIETARIO.NID_PAIS;
        //            set => datos_ALTA_VEHICULO_COPROPIETARIO.NID_PAIS = value;
        //        }
        //    new public String CID_ENTIDAD_FEDERATIVA
        //        {
        //            get => datos_ALTA_VEHICULO_COPROPIETARIO.CID_ENTIDAD_FEDERATIVA;
        //            set => datos_ALTA_VEHICULO_COPROPIETARIO.CID_ENTIDAD_FEDERATIVA = value;
        //        }

        #endregion


        #region *** Constructores ***

        internal blld_ALTA_VEHICULO_COPROPIETARIO() : base() { }
        public blld_ALTA_VEHICULO_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO, Int32 NID_COPROPIETARIO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
            : base()
        {
            // se cambio de ThrowException a UpdateExisiting
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_VEHICULO = NID_VEHICULO; 
            Int32 _NID_COPROPIETARIO = NID_COPROPIETARIO; 
            this.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
            this.V_NOMBRE = V_NOMBRE;
            this.V_RFC = V_RFC;
            datos_ALTA_VEHICULO_COPROPIETARIO = new dald_ALTA_VEHICULO_COPROPIETARIO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_VEHICULO, _NID_COPROPIETARIO, this.CID_TIPO_PERSONA, this.V_NOMBRE, this.V_RFC,  lOpcionesRegistroExistente);
        }
        public blld_ALTA_VEHICULO_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_VEHICULO = NID_VEHICULO; 
            Int32 _NID_COPROPIETARIO = dald_ALTA_VEHICULO_COPROPIETARIO.nNuevo_NID_COPROPIETARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO);
            this.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
            this.V_NOMBRE = V_NOMBRE;
            this.V_RFC = V_RFC;
            datos_ALTA_VEHICULO_COPROPIETARIO = new dald_ALTA_VEHICULO_COPROPIETARIO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_VEHICULO, _NID_COPROPIETARIO, this.CID_TIPO_PERSONA, this.V_NOMBRE, this.V_RFC, lOpcionesRegistroExistente);
        }
        internal void update(string vID_NOMBRE, string vID_FECHA, string vID_HOMOCLAVE, int nID_DECLARACION, int nID_VEHICULO, int nID_COPROPIETARIO)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region *** Metodos ***
        internal void Update(string vID_NOMBRE, string vID_FECHA, string vID_HOMOCLAVE, int nID_DECLARACION, int nID_VEHICULO, int nID_COPROPIETARIO)
        {
            datos_ALTA_VEHICULO_COPROPIETARIO.update(vID_NOMBRE, vID_FECHA, vID_HOMOCLAVE, nID_DECLARACION, nID_VEHICULO, nID_COPROPIETARIO);
        }
        #endregion

    }
}
