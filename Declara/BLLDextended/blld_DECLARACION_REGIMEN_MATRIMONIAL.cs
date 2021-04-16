using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_REGIMEN_MATRIMONIAL : bll_DECLARACION_REGIMEN_MATRIMONIAL
    {

        #region *** Propiedades ***
//    new public String VID_NOMBRE => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_NOMBRE;
//    new public String VID_FECHA => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_FECHA;
//    new public String VID_HOMOCLAVE => datos_DECLARACION_REGIMEN_MATRIMONIAL.VID_HOMOCLAVE;
//    new public Int32 NID_DECLARACION => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_DECLARACION;
//    new public Int32 NID_REGIMEN => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN;
//    new public Int32 NID_REGIMEN_MATRIMONIAL
//        {
//            get => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL;
//            set => datos_DECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL = value;
//        }
        public String V_REGIMEN_MATRIMONIAL => datos_DECLARACION_REGIMEN_MATRIMONIAL.oCAT_REGIMEN_MATRIMONIAL.V_REGIMEN_MATRIMONIAL;

        #endregion


        #region *** Constructores ***
        public blld_DECLARACION_REGIMEN_MATRIMONIAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN, Int32 NID_REGIMEN_MATRIMONIAL)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_REGIMEN = NID_REGIMEN; 
            this.NID_REGIMEN_MATRIMONIAL = NID_REGIMEN_MATRIMONIAL;
            datos_DECLARACION_REGIMEN_MATRIMONIAL = new dald_DECLARACION_REGIMEN_MATRIMONIAL(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_REGIMEN, this.NID_REGIMEN_MATRIMONIAL, lOpcionesRegistroExistente);
        }
        public blld_DECLARACION_REGIMEN_MATRIMONIAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN_MATRIMONIAL)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_REGIMEN = dald_DECLARACION_REGIMEN_MATRIMONIAL.nNuevo_NID_REGIMEN(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.NID_REGIMEN_MATRIMONIAL = NID_REGIMEN_MATRIMONIAL;
            datos_DECLARACION_REGIMEN_MATRIMONIAL = new dald_DECLARACION_REGIMEN_MATRIMONIAL(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_REGIMEN, this.NID_REGIMEN_MATRIMONIAL, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
