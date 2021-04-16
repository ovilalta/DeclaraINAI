using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_INGRESOS : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_DECLARACION_INGRESOS datos_DECLARACION_INGRESOS { get; set; }
        public String VID_NOMBRE => datos_DECLARACION_INGRESOS.VID_NOMBRE;
        public String VID_FECHA => datos_DECLARACION_INGRESOS.VID_FECHA;
        public String VID_HOMOCLAVE => datos_DECLARACION_INGRESOS.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_DECLARACION_INGRESOS.NID_DECLARACION;
        public Int32 NID_INGRESO => datos_DECLARACION_INGRESOS.NID_INGRESO;
        public String V_CONCEPTO
        {
            get => datos_DECLARACION_INGRESOS.V_CONCEPTO;
            set => datos_DECLARACION_INGRESOS.V_CONCEPTO = value;
        }
        public Decimal M_DECLARANTE
        {
            get => datos_DECLARACION_INGRESOS.M_DECLARANTE;
            set => datos_DECLARACION_INGRESOS.M_DECLARANTE = value;
        }
        public Decimal M_DEPENDIENTE
        {
            get => datos_DECLARACION_INGRESOS.M_DEPENDIENTE;
            set => datos_DECLARACION_INGRESOS.M_DEPENDIENTE = value;
        }
        public Decimal M_SUMA
        {
            get => datos_DECLARACION_INGRESOS.M_SUMA;
            set => datos_DECLARACION_INGRESOS.M_SUMA = value;
        }
        public Int32 N_NIVEL
        {
            get => datos_DECLARACION_INGRESOS.N_NIVEL;
            set => datos_DECLARACION_INGRESOS.N_NIVEL = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_INGRESOS.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_DECLARACION_INGRESOS() => datos_DECLARACION_INGRESOS = new dald_DECLARACION_INGRESOS();
        public bll_DECLARACION_INGRESOS(MODELDeclara_V2.DECLARACION_INGRESOS DECLARACION_INGRESOS) => datos_DECLARACION_INGRESOS = new dald_DECLARACION_INGRESOS(DECLARACION_INGRESOS);
        public bll_DECLARACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO) => datos_DECLARACION_INGRESOS = new dald_DECLARACION_INGRESOS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO);

//        public bll_DECLARACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_DECLARACION_INGRESOS = new dald_DECLARACION_INGRESOS();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_INGRESO = NID_INGRESO; 
//            this.V_CONCEPTO = V_CONCEPTO;
//            this.M_DECLARANTE = M_DECLARANTE;
//            this.M_DEPENDIENTE = M_DEPENDIENTE;
//            this.M_SUMA = M_SUMA;
//            this.N_NIVEL = N_NIVEL;
//            datos_DECLARACION_INGRESOS = new dald_DECLARACION_INGRESOS(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_INGRESO, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_INGRESO, this.V_CONCEPTO, this.M_DECLARANTE, this.M_DEPENDIENTE, this.M_SUMA, this.N_NIVEL, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_DECLARACION_INGRESOS.update();
        }
        public void delete()
        {
            datos_DECLARACION_INGRESOS.delete();
        }
        public void reload()
        {
            datos_DECLARACION_INGRESOS.reload();
        }

        #endregion

    }
}
