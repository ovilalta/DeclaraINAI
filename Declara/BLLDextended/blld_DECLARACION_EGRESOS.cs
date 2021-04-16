using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_EGRESOS : bll_DECLARACION_EGRESOS
    {

        #region *** Propiedades ***
//    new public String VID_NOMBRE => datos_DECLARACION_EGRESOS.VID_NOMBRE;
//    new public String VID_FECHA => datos_DECLARACION_EGRESOS.VID_FECHA;
//    new public String VID_HOMOCLAVE => datos_DECLARACION_EGRESOS.VID_HOMOCLAVE;
//    new public Int32 NID_DECLARACION => datos_DECLARACION_EGRESOS.NID_DECLARACION;
//    new public Int32 NID_EGRESO => datos_DECLARACION_EGRESOS.NID_EGRESO;
//    new public String V_CONCEPTO
//        {
//            get => datos_DECLARACION_EGRESOS.V_CONCEPTO;
//            set => datos_DECLARACION_EGRESOS.V_CONCEPTO = value;
//        }
//    new public Decimal M_DECLARANTE
//        {
//            get => datos_DECLARACION_EGRESOS.M_DECLARANTE;
//            set => datos_DECLARACION_EGRESOS.M_DECLARANTE = value;
//        }
//    new public Decimal M_DEPENDIENTE
//        {
//            get => datos_DECLARACION_EGRESOS.M_DEPENDIENTE;
//            set => datos_DECLARACION_EGRESOS.M_DEPENDIENTE = value;
//        }
//    new public Decimal M_SUMA
//        {
//            get => datos_DECLARACION_EGRESOS.M_SUMA;
//            set => datos_DECLARACION_EGRESOS.M_SUMA = value;
//        }
//    new public Int32 N_NIVEL
//        {
//            get => datos_DECLARACION_EGRESOS.N_NIVEL;
//            set => datos_DECLARACION_EGRESOS.N_NIVEL = value;
//        }

        #endregion


        #region *** Constructores ***
        public blld_DECLARACION_EGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_EGRESO = NID_EGRESO; 
            this.V_CONCEPTO = V_CONCEPTO;
            this.M_DECLARANTE = M_DECLARANTE;
            this.M_DEPENDIENTE = M_DEPENDIENTE;
            this.M_SUMA = M_SUMA;
            this.N_NIVEL = N_NIVEL;
            datos_DECLARACION_EGRESOS = new dald_DECLARACION_EGRESOS(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_EGRESO, this.V_CONCEPTO, this.M_DECLARANTE, this.M_DEPENDIENTE, this.M_SUMA, this.N_NIVEL, lOpcionesRegistroExistente);
        }
        public blld_DECLARACION_EGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_EGRESO = dald_DECLARACION_EGRESOS.nNuevo_NID_EGRESO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.V_CONCEPTO = V_CONCEPTO;
            this.M_DECLARANTE = M_DECLARANTE;
            this.M_DEPENDIENTE = M_DEPENDIENTE;
            this.M_SUMA = M_SUMA;
            this.N_NIVEL = N_NIVEL;
            datos_DECLARACION_EGRESOS = new dald_DECLARACION_EGRESOS(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_EGRESO, this.V_CONCEPTO, this.M_DECLARANTE, this.M_DEPENDIENTE, this.M_SUMA, this.N_NIVEL, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
