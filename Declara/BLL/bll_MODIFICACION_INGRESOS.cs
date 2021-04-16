using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_MODIFICACION_INGRESOS : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_MODIFICACION_INGRESOS datos_MODIFICACION_INGRESOS { get; set; }
        public String VID_NOMBRE => datos_MODIFICACION_INGRESOS.VID_NOMBRE;
        public String VID_FECHA => datos_MODIFICACION_INGRESOS.VID_FECHA;
        public String VID_HOMOCLAVE => datos_MODIFICACION_INGRESOS.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_MODIFICACION_INGRESOS.NID_DECLARACION;
        public Int32 NID_INGRESO => datos_MODIFICACION_INGRESOS.NID_INGRESO;
        public String E_ESPECIFICAR
        {
            get => datos_MODIFICACION_INGRESOS.E_ESPECIFICAR;
            set => datos_MODIFICACION_INGRESOS.E_ESPECIFICAR = value;
        }
        public String E_ESPECIFICAR_COMPLEMENTO
        {
            get => datos_MODIFICACION_INGRESOS.E_ESPECIFICAR_COMPLEMENTO;
            set => datos_MODIFICACION_INGRESOS.E_ESPECIFICAR_COMPLEMENTO = value;
        }
        public Decimal M_INGRESO
        {
            get => datos_MODIFICACION_INGRESOS.M_INGRESO;
            set => datos_MODIFICACION_INGRESOS.M_INGRESO = value;
        }
        public Char C_TITULAR
        {
            get => datos_MODIFICACION_INGRESOS.C_TITULAR;
            set => datos_MODIFICACION_INGRESOS.C_TITULAR = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_MODIFICACION_INGRESOS.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_MODIFICACION_INGRESOS() => datos_MODIFICACION_INGRESOS = new dald_MODIFICACION_INGRESOS();
        public bll_MODIFICACION_INGRESOS(MODELDeclara_V2.MODIFICACION_INGRESOS MODIFICACION_INGRESOS) => datos_MODIFICACION_INGRESOS = new dald_MODIFICACION_INGRESOS(MODIFICACION_INGRESOS);
        public bll_MODIFICACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO) => datos_MODIFICACION_INGRESOS = new dald_MODIFICACION_INGRESOS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO);

        public bll_MODIFICACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String E_ESPECIFICAR, String E_ESPECIFICAR_COMPLEMENTO, Decimal M_INGRESO, Char C_TITULAR)
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            datos_MODIFICACION_INGRESOS = new dald_MODIFICACION_INGRESOS();
            String _VID_NOMBRE = VID_NOMBRE;
            String _VID_FECHA = VID_FECHA;
            String _VID_HOMOCLAVE = VID_HOMOCLAVE;
            Int32 _NID_DECLARACION = NID_DECLARACION;
            Int32 _NID_INGRESO = NID_INGRESO;
            this.E_ESPECIFICAR = E_ESPECIFICAR;
            this.E_ESPECIFICAR_COMPLEMENTO = E_ESPECIFICAR_COMPLEMENTO;
            this.M_INGRESO = M_INGRESO;
            this.C_TITULAR = C_TITULAR;
            datos_MODIFICACION_INGRESOS = new dald_MODIFICACION_INGRESOS(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_INGRESO,   this.E_ESPECIFICAR, this.E_ESPECIFICAR_COMPLEMENTO, this.M_INGRESO, this.C_TITULAR, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_MODIFICACION_INGRESOS.update();
        }
        public void delete()
        {
            datos_MODIFICACION_INGRESOS.delete();
        }
        public void reload()
        {
            datos_MODIFICACION_INGRESOS.reload();
        }

        #endregion

    }
}
