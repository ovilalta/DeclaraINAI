using Declara_V2.BLL;
using Declara_V2.DALD;
using Declara_V2.Exceptions;
using System;
using System.Linq;

namespace Declara_V2.BLLD
{
    public partial class blld_DECLARACION_DEPENDIENTES_PUBLICO : bll_DECLARACION_DEPENDIENTES_PUBLICO
    {

        #region *** Propiedades ***
        //    new public String VID_NOMBRE => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_NOMBRE;
        //    new public String VID_FECHA => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_FECHA;
        //    new public String VID_HOMOCLAVE => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_HOMOCLAVE;
        //    new public Int32 NID_DECLARACION => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DECLARACION;
        //    new public Int32 NID_DEPENDIENTE => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DEPENDIENTE;
        //    new public Int32 NID_AMBITO_SECTOR
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR = value;
        //        }
        //    new public Int32 NID_NIVEL_GOBIERNO
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO = value;
        //        }
        //    new public Int32 NID_AMBITO_PUBLICO
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO = value;
        //        }
        //    new public String V_NOMBRE_ENTE
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE = value;
        //        }
        //    new public String V_AREA_ADSCRIPCION
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION = value;
        //        }
        //    new public String V_CARGO
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO = value;
        //        }
        //    new public String V_FUNCION_PRINCIPAL
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL = value;
        //        }
        //    new public Decimal M_SALARIO_MENSUAL
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL = value;
        //        }
        //    new public DateTime F_INGRESO
        //        {
        //            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO;
        //            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO = value;
        //        }
        public String V_AMBITO_SECTOR => datos_DECLARACION_DEPENDIENTES_PUBLICO.oCAT_AMBITO_SECTOR.V_AMBITO_SECTOR;
        public String V_NIVEL_GOBIERNO => datos_DECLARACION_DEPENDIENTES_PUBLICO.oCAT_NIVEL_GOBIERNO.V_NIVEL_GOBIERNO;
        public String V_AMBITO_PUBLICO => datos_DECLARACION_DEPENDIENTES_PUBLICO.oCAT_AMBITO_PUBLICO.V_AMBITO_PUBLICO;

        #endregion

        public blld_DECLARACION_DEPENDIENTES_PUBLICO() : base() { }
        #region *** Constructores ***
        public blld_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, String V_FUNCION_PRINCIPAL, Decimal M_SALARIO_MENSUAL, DateTime F_INGRESO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE;
            String _VID_FECHA = VID_FECHA;
            String _VID_HOMOCLAVE = VID_HOMOCLAVE;
            Int32 _NID_DECLARACION = NID_DECLARACION;
            Int32 _NID_DEPENDIENTE = NID_DEPENDIENTE;
            this.NID_AMBITO_SECTOR = NID_AMBITO_SECTOR;
            this.NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO;
            this.NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO;
            this.V_NOMBRE_ENTE = V_NOMBRE_ENTE;
            this.V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION;
            this.V_CARGO = V_CARGO;
            this.V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL;
            this.M_SALARIO_MENSUAL = M_SALARIO_MENSUAL;
            this.F_INGRESO = F_INGRESO;
            datos_DECLARACION_DEPENDIENTES_PUBLICO = new dald_DECLARACION_DEPENDIENTES_PUBLICO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_DEPENDIENTE, this.NID_AMBITO_SECTOR, this.NID_NIVEL_GOBIERNO, this.NID_AMBITO_PUBLICO, this.V_NOMBRE_ENTE, this.V_AREA_ADSCRIPCION, this.V_CARGO, this.V_FUNCION_PRINCIPAL, this.M_SALARIO_MENSUAL, this.F_INGRESO, lOpcionesRegistroExistente);
        }
        public blld_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, String V_FUNCION_PRINCIPAL, Decimal M_SALARIO_MENSUAL, DateTime F_INGRESO)
            : base()
        {
            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
            String _VID_NOMBRE = VID_NOMBRE;
            String _VID_FECHA = VID_FECHA;
            String _VID_HOMOCLAVE = VID_HOMOCLAVE;
            Int32 _NID_DECLARACION = NID_DECLARACION;
            //     Int32 _NID_DEPENDIENTE = dald_DECLARACION_DEPENDIENTES_PUBLICO.nNuevo_NID_DEPENDIENTE(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            this.NID_AMBITO_SECTOR = NID_AMBITO_SECTOR;
            this.NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO;
            this.NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO;
            this.V_NOMBRE_ENTE = V_NOMBRE_ENTE;
            this.V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION;
            this.V_CARGO = V_CARGO;
            this.V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL;
            this.M_SALARIO_MENSUAL = M_SALARIO_MENSUAL;
            this.F_INGRESO = F_INGRESO;
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
            datos_DECLARACION_DEPENDIENTES_PUBLICO = new dald_DECLARACION_DEPENDIENTES_PUBLICO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_DEPENDIENTE, this.NID_AMBITO_SECTOR, this.NID_NIVEL_GOBIERNO, this.NID_AMBITO_PUBLICO, this.V_NOMBRE_ENTE, this.V_AREA_ADSCRIPCION, this.V_CARGO, this.V_FUNCION_PRINCIPAL, this.M_SALARIO_MENSUAL, this.F_INGRESO, lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***

        #endregion

    }
}
