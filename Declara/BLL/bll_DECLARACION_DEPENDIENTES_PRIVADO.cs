using System;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_DEPENDIENTES_PRIVADO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_DECLARACION_DEPENDIENTES_PRIVADO datos_DECLARACION_DEPENDIENTES_PRIVADO { get; set; }
        public String VID_NOMBRE => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_NOMBRE;
        public String VID_FECHA => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_FECHA;
        public String VID_HOMOCLAVE => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DECLARACION;
        public Int32 NID_DEPENDIENTE => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DEPENDIENTE;
        public String V_NOMBRE
        {
            //get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE;
            //set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = value;

            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = Encripta(value);
            }
        }
        public String V_CARGO
        {
 
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = Encripta(value);
            }
        }
        public String V_RFC
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = Encripta(value);
            }
        }
        public DateTime F_INGRESO
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO = value;
        }
        public Int32 NID_SECTOR
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR = value;
        }
        public Decimal M_SALARIO_MENSUAL
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = value;
        }
        public Boolean L_PROVEEDOR
        {
            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR;
            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_DEPENDIENTES_PRIVADO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_DECLARACION_DEPENDIENTES_PRIVADO() => datos_DECLARACION_DEPENDIENTES_PRIVADO = new dald_DECLARACION_DEPENDIENTES_PRIVADO();
        public bll_DECLARACION_DEPENDIENTES_PRIVADO(MODELDeclara_V2.DECLARACION_DEPENDIENTES_PRIVADO DECLARACION_DEPENDIENTES_PRIVADO) => datos_DECLARACION_DEPENDIENTES_PRIVADO = new dald_DECLARACION_DEPENDIENTES_PRIVADO(DECLARACION_DEPENDIENTES_PRIVADO);
        public bll_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE) => datos_DECLARACION_DEPENDIENTES_PRIVADO = new dald_DECLARACION_DEPENDIENTES_PRIVADO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE);

//        public bll_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, String V_NOMBRE, String V_CARGO, String V_RFC, DateTime F_INGRESO, Int32 NID_SECTOR, Decimal M_SALARIO_MENSUAL, Boolean L_PROVEEDOR)
//        {
//            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
//            datos_DECLARACION_DEPENDIENTES_PRIVADO = new dald_DECLARACION_DEPENDIENTES_PRIVADO();
//            String _VID_NOMBRE = VID_NOMBRE; 
//            String _VID_FECHA = VID_FECHA; 
//            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
//            Int32 _NID_DECLARACION = NID_DECLARACION; 
//            Int32 _NID_DEPENDIENTE = NID_DEPENDIENTE; 
//            this.V_NOMBRE = V_NOMBRE;
//            this.V_CARGO = V_CARGO;
//            this.V_RFC = V_RFC;
//            this.F_INGRESO = F_INGRESO;
//            this.NID_SECTOR = NID_SECTOR;
//            this.M_SALARIO_MENSUAL = M_SALARIO_MENSUAL;
//            this.L_PROVEEDOR = L_PROVEEDOR;
//            datos_DECLARACION_DEPENDIENTES_PRIVADO = new dald_DECLARACION_DEPENDIENTES_PRIVADO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_DEPENDIENTE, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_DEPENDIENTE, this.V_NOMBRE, this.V_CARGO, this.V_RFC, this.F_INGRESO, this.NID_SECTOR, this.M_SALARIO_MENSUAL, this.L_PROVEEDOR, lOpcionesRegistroExistente);
//        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_DECLARACION_DEPENDIENTES_PRIVADO.update();
        }
        public void delete()
        {
            datos_DECLARACION_DEPENDIENTES_PRIVADO.delete();
        }
        public void reload()
        {
            datos_DECLARACION_DEPENDIENTES_PRIVADO.reload();
        }

        #endregion

    }
}
