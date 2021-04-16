using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_INGRESOS : bll_DECLARACION_INGRESOS
    {

        #region *** Propiedades ***
//    new public String VID_NOMBRE => datos_DECLARACION_INGRESOS.VID_NOMBRE;
//    new public String VID_FECHA => datos_DECLARACION_INGRESOS.VID_FECHA;
//    new public String VID_HOMOCLAVE => datos_DECLARACION_INGRESOS.VID_HOMOCLAVE;
//    new public Int32 NID_DECLARACION => datos_DECLARACION_INGRESOS.NID_DECLARACION;
//    new public Int32 NID_INGRESO => datos_DECLARACION_INGRESOS.NID_INGRESO;
//    new public String V_CONCEPTO
//        {
//            get => datos_DECLARACION_INGRESOS.V_CONCEPTO;
//            set => datos_DECLARACION_INGRESOS.V_CONCEPTO = value;
//        }
//    new public Decimal M_DECLARANTE
//        {
//            get => datos_DECLARACION_INGRESOS.M_DECLARANTE;
//            set => datos_DECLARACION_INGRESOS.M_DECLARANTE = value;
//        }
//    new public Decimal M_DEPENDIENTE
//        {
//            get => datos_DECLARACION_INGRESOS.M_DEPENDIENTE;
//            set => datos_DECLARACION_INGRESOS.M_DEPENDIENTE = value;
//        }
//    new public Decimal M_SUMA
//        {
//            get => datos_DECLARACION_INGRESOS.M_SUMA;
//            set => datos_DECLARACION_INGRESOS.M_SUMA = value;
//        }
//    new public Int32 N_NIVEL
//        {
//            get => datos_DECLARACION_INGRESOS.N_NIVEL;
//            set => datos_DECLARACION_INGRESOS.N_NIVEL = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_DECLARACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_INGRESO = NID_INGRESO; 
            this.V_CONCEPTO = V_CONCEPTO;
            this.M_DECLARANTE = M_DECLARANTE;
            this.M_DEPENDIENTE = M_DEPENDIENTE;
            this.M_SUMA = M_SUMA;
            this.N_NIVEL = N_NIVEL;
            datos_DECLARACION_INGRESOS = new dald_DECLARACION_INGRESOS(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_INGRESO, this.V_CONCEPTO, this.M_DECLARANTE, this.M_DEPENDIENTE, this.M_SUMA, this.N_NIVEL, lOpcionesRegistroExistente);
        }
        public blld_DECLARACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_INGRESO = dald_DECLARACION_INGRESOS.nNuevo_NID_INGRESO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.V_CONCEPTO = V_CONCEPTO;
            this.M_DECLARANTE = M_DECLARANTE;
            this.M_DEPENDIENTE = M_DEPENDIENTE;
            this.M_SUMA = M_SUMA;
            this.N_NIVEL = N_NIVEL;
            datos_DECLARACION_INGRESOS = new dald_DECLARACION_INGRESOS(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_INGRESO, this.V_CONCEPTO, this.M_DECLARANTE, this.M_DEPENDIENTE, this.M_SUMA, this.N_NIVEL, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
