using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_ALTA_INVERSION_COPROPIETARIO : bll_ALTA_INVERSION_COPROPIETARIO
    {

        #region *** Propiedades ***
        //    new public String VID_NOMBRE => datos_ALTA_INVERSION_COPROPIETARIO.VID_NOMBRE;
        //    new public String VID_FECHA => datos_ALTA_INVERSION_COPROPIETARIO.VID_FECHA;
        //    new public String VID_HOMOCLAVE => datos_ALTA_INVERSION_COPROPIETARIO.VID_HOMOCLAVE;
        //    new public Int32 NID_DECLARACION => datos_ALTA_INVERSION_COPROPIETARIO.NID_DECLARACION;
        //    new public Int32 NID_INVERSION => datos_ALTA_INVERSION_COPROPIETARIO.NID_INVERSION;
        //    new public Int32 NID_COPROPIETARIO => datos_ALTA_INVERSION_COPROPIETARIO.NID_COPROPIETARIO;
        new public String CID_TIPO_PERSONA
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_INVERSION_COPROPIETARIO.CID_TIPO_PERSONA))
                    return String.Empty;
                return DesEncripta(datos_ALTA_INVERSION_COPROPIETARIO.CID_TIPO_PERSONA);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_INVERSION_COPROPIETARIO.CID_TIPO_PERSONA = String.Empty;
                else
                    datos_ALTA_INVERSION_COPROPIETARIO.CID_TIPO_PERSONA = Encripta(value);
            }
        }
        new public String V_NOMBRE
        {
            get => datos_ALTA_INVERSION_COPROPIETARIO.V_NOMBRE;
            set => datos_ALTA_INVERSION_COPROPIETARIO.V_NOMBRE = value;
        }
        new public String V_RFC
        {
            get => datos_ALTA_INVERSION_COPROPIETARIO.V_RFC;
            set => datos_ALTA_INVERSION_COPROPIETARIO.V_RFC = value;
        }

        #endregion


        #region *** Constructores ***
        public blld_ALTA_INVERSION_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_COPROPIETARIO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_INVERSION = NID_INVERSION; 
            Int32 _NID_COPROPIETARIO = NID_COPROPIETARIO; 
            this.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
            this.V_NOMBRE = V_NOMBRE;
            this.V_RFC = V_RFC;
            datos_ALTA_INVERSION_COPROPIETARIO = new dald_ALTA_INVERSION_COPROPIETARIO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_INVERSION, _NID_COPROPIETARIO, this.CID_TIPO_PERSONA, this.V_NOMBRE, this.V_RFC, lOpcionesRegistroExistente);
        }
        public blld_ALTA_INVERSION_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_INVERSION = NID_INVERSION; 
            Int32 _NID_COPROPIETARIO = dald_ALTA_INVERSION_COPROPIETARIO.nNuevo_NID_COPROPIETARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION);
            this.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
            this.V_NOMBRE = V_NOMBRE;
            this.V_RFC = V_RFC;
            datos_ALTA_INVERSION_COPROPIETARIO = new dald_ALTA_INVERSION_COPROPIETARIO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_INVERSION, _NID_COPROPIETARIO, this.CID_TIPO_PERSONA, this.V_NOMBRE, this.V_RFC, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
