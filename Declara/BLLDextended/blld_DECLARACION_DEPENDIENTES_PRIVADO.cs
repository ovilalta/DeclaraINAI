using System;
using System.Collections.Generic;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using Declara_V2.DALD;
using Declara_V2.BLL;
using System.Linq;
namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_DEPENDIENTES_PRIVADO : bll_DECLARACION_DEPENDIENTES_PRIVADO
    {

        #region *** Propiedades ***
//    new public String VID_NOMBRE => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_NOMBRE;
//    new public String VID_FECHA => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_FECHA;
//    new public String VID_HOMOCLAVE => datos_DECLARACION_DEPENDIENTES_PRIVADO.VID_HOMOCLAVE;
//    new public Int32 NID_DECLARACION => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DECLARACION;
//    new public Int32 NID_DEPENDIENTE => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_DEPENDIENTE;
//    new public String V_NOMBRE
//        {
//            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE;
//            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_NOMBRE = value;
//        }
//    new public String V_CARGO
//        {
//            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO;
//            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_CARGO = value;
//        }
//    new public String V_RFC
//        {
//            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC;
//            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.V_RFC = value;
//        }
//    new public DateTime F_INGRESO
//        {
//            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO;
//            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.F_INGRESO = value;
//        }
//    new public Int32 NID_SECTOR
//        {
//            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR;
//            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.NID_SECTOR = value;
//        }
//    new public Decimal M_SALARIO_MENSUAL
//        {
//            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL;
//            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.M_SALARIO_MENSUAL = value;
//        }
//    new public Boolean L_PROVEEDOR
//        {
//            get => datos_DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR;
//            set => datos_DECLARACION_DEPENDIENTES_PRIVADO.L_PROVEEDOR = value;
//        }
        public String V_SECTOR => datos_DECLARACION_DEPENDIENTES_PRIVADO.oCAT_SECTOR.V_SECTOR;

        #endregion


        #region *** Constructores ***
        public blld_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, String V_NOMBRE, String V_CARGO, String V_RFC, DateTime F_INGRESO, Int32 NID_SECTOR, Decimal M_SALARIO_MENSUAL, Boolean L_PROVEEDOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            Int32 _NID_DEPENDIENTE = NID_DEPENDIENTE; 
            this.V_NOMBRE = V_NOMBRE;
            this.V_CARGO = V_CARGO;
            this.V_RFC = V_RFC;
            this.F_INGRESO = F_INGRESO;
            this.NID_SECTOR = NID_SECTOR;
            this.M_SALARIO_MENSUAL = M_SALARIO_MENSUAL;
            this.L_PROVEEDOR = L_PROVEEDOR;
            datos_DECLARACION_DEPENDIENTES_PRIVADO = new dald_DECLARACION_DEPENDIENTES_PRIVADO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_DEPENDIENTE, this.V_NOMBRE, this.V_CARGO, this.V_RFC, this.F_INGRESO, this.NID_SECTOR, this.M_SALARIO_MENSUAL, this.L_PROVEEDOR, lOpcionesRegistroExistente);
        }
        public blld_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String V_NOMBRE, String V_CARGO, String V_RFC, DateTime F_INGRESO, Int32 NID_SECTOR, Decimal M_SALARIO_MENSUAL, Boolean L_PROVEEDOR)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE; 
            String _VID_FECHA = VID_FECHA; 
            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
            Int32 _NID_DECLARACION = NID_DECLARACION; 
            //Int32 _NID_DEPENDIENTE = dald_DECLARACION_DEPENDIENTES_PRIVADO.nNuevo_NID_DEPENDIENTE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.V_NOMBRE = V_NOMBRE;
            this.V_CARGO = V_CARGO;
            this.V_RFC = V_RFC;
            this.F_INGRESO = F_INGRESO;
            this.NID_SECTOR = NID_SECTOR;
            this.M_SALARIO_MENSUAL = M_SALARIO_MENSUAL;
            this.L_PROVEEDOR = L_PROVEEDOR;
            Int32 _NID_DEPENDIENTE = 0;
            try
            {
                MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();

                _NID_DEPENDIENTE = ((from p in dbInt.DECLARACION_DEPENDIENTES
                                     where p.VID_NOMBRE == VID_NOMBRE &&
                                           p.VID_FECHA == VID_FECHA &&
                                           p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                           p.NID_DECLARACION == NID_DECLARACION

                                     select p.NID_DEPENDIENTE).First());
            }
            catch (Exception)
            {

                _NID_DEPENDIENTE = _NID_DEPENDIENTE + 1;
            }
            datos_DECLARACION_DEPENDIENTES_PRIVADO = new dald_DECLARACION_DEPENDIENTES_PRIVADO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_DEPENDIENTE, this.V_NOMBRE, this.V_CARGO, this.V_RFC, this.F_INGRESO, this.NID_SECTOR, this.M_SALARIO_MENSUAL, this.L_PROVEEDOR, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
