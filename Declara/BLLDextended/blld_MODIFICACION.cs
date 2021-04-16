using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;
using System.Globalization;

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_MODIFICACION : bll_MODIFICACION
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION.NID_DECLARACION; }
        //        }


        //        public System.Nullable<Boolean> L_PRESENTO_DEC
        //        {
        //          get { return datos_MODIFICACION.L_PRESENTO_DEC; }
        //          set { datos_MODIFICACION.L_PRESENTO_DEC = value; }
        //        }


        new public System.Nullable<DateTime> F_INICIO
        {
            get => datos_MODIFICACION.F_INICIO;
            set
            {
                //if (value < new DateTime(DateTime.Today.Year - 1, 1, 1))
                //    throw new CustomException(String.Concat("La fecha de inicio del periodo no puede ser menor que ", (new DateTime(DateTime.Today.Year - 1, 1, 1)).ToString("dd/MMMM/yyy", new CultureInfo("es-MX")).ToUpper()));
                datos_MODIFICACION.F_INICIO = value;
            }
        }

        new public System.Nullable<DateTime> F_FIN
        {
            get => datos_MODIFICACION.F_FIN;
            set
            {
                //if (value < new DateTime(DateTime.Today.Year - 1, 12, 31))
                //    throw new CustomException(String.Concat("La fecha de fin del periodo no puede ser menor que ", (new DateTime(DateTime.Today.Year - 1, 12, 31)).ToString("dd/MMMM/yyy", new CultureInfo("es-MX")).ToUpper()));
                datos_MODIFICACION.F_FIN = value;
            }
        }

        public Decimal M_MONTO_VENTAS
        {
            get
            {
                Decimal retorno = 0;
                foreach (blld_MODIFICACION_BAJA_VENTA o in MODIFICACION_BAJAs.Where(p => p.NID_TIPO_BAJA == 1).Select(p => p.MODIFICACION_BAJA_VENTA))
                    retorno = retorno + o.M_IMPORTE_VENTA;
                return retorno;
            }
        }

        public Decimal M_MONTO_RECUPERACION
        {
            get
            {
                Decimal retorno = 0;
                foreach (blld_MODIFICACION_BAJA_SINIESTRO o in MODIFICACION_BAJAs.Where(p => p.NID_TIPO_BAJA == 3).Select(p => p.MODIFICACION_BAJA_SINIESTRO))
                    retorno = retorno + o.M_RECUPERADO;
                return retorno;
            }
        }

        public Decimal M_MONTO_RETIROS
        {
            get
            {
                Decimal retorno = 0;
                foreach (blld_MODIFICACION_INVERSION o in MODIFICACION_INVERSIONs)
                {
                    if (o.PATRIMONIO.PATRIMONIO_INVERSION.NID_TIPO_INVERSION == 1)
                        retorno = retorno + o.M_DIFERENCIA;
                }
                if (retorno > 0)
                    return retorno;
                return 0;
            }
        }

        public Decimal M_MONTO_AHORRO
        {
            get
            {
                Decimal retorno = 0;
                foreach (blld_MODIFICACION_INVERSION o in MODIFICACION_INVERSIONs)
                {
                    if (o.PATRIMONIO.PATRIMONIO_INVERSION.NID_TIPO_INVERSION == 1)
                        retorno = retorno + o.M_DIFERENCIA;
                }
                if (retorno < 0)
                    return retorno * -1;
                return 0;
            }
        }

        public Decimal M_PAGOS_ADEUDOS
        {
            get
            {
                Decimal retorno = 0;
                foreach (blld_MODIFICACION_ADEUDO O in MODIFICACION_ADEUDOs)
                    retorno = retorno + O.M_PAGOS;
                return retorno;
            }
        }
        public Decimal M_PAGOS_TARJETAS
        {
            get
            {
                Decimal retorno = 0;
                foreach (blld_MODIFICACION_TARJETA O in MODIFICACION_TARJETAs)
                    retorno = retorno + O.M_PAGOS;
                return retorno;
            }
        }
        public Decimal M_IMPUESTOS
        {
            get
            {
                Decimal retorno = 0;
                foreach (blld_MODIFICACION_GASTO O in MODIFICACION_GASTOs.Where(p=> p.NID_TIPO_GASTO == 1))
                    retorno = retorno + O.M_GASTO;
                return retorno;
            }
        }

        #endregion



        #region *** Constructores (Extended) ***


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_MODIFICACION_INVERSIONs()
        {
            _Reload_MODIFICACION_INVERSIONs();
        }

        //public void Add_MODIFICACION_INVERSIONs(Int32 NID_PATRIMONIO, Decimal M_DEPOSITOS, Decimal M_RETIROS, Boolean L_CANCELADA)
        //{
        //    try
        //    {
        //        //_Add_MODIFICACION_INVERSIONs(NID_PATRIMONIO, M_DEPOSITOS, M_RETIROS, L_CANCELADA);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}

        public void Reload_MODIFICACION_TARJETAs()
        {
            _Reload_MODIFICACION_TARJETAs();
        }

        public void Add_MODIFICACION_TARJETAs(String E_NUMERO, Int32 NID_INSTITUCION, String V_NUMERO_CORTO, Decimal M_PAGOS, Decimal M_GASTOS, Boolean L_ACTIVA, List<Int32> ListDependientes)
        {
            try
            {
                _Add_MODIFICACION_TARJETAs(E_NUMERO, NID_INSTITUCION, V_NUMERO_CORTO, M_PAGOS, M_GASTOS, L_ACTIVA, ListDependientes);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Reload_MODIFICACION_ADEUDOs()
        {
            _Reload_MODIFICACION_ADEUDOs();
        }

        //public void Add_MODIFICACION_ADEUDOs(Int32 NID_PATRIMONIO, Decimal M_DEPOSITOS, Boolean L_CANCELADO)
        //{
        //    try
        //    {
        //        _Add_MODIFICACION_ADEUDOs(NID_PATRIMONIO, M_DEPOSITOS, L_CANCELADO);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}

        public void Reload_MODIFICACION_VEHICULOs()
        {
            _Reload_MODIFICACION_VEHICULOs();
        }

        //public void Add_MODIFICACION_VEHICULOs(Int32 NID_VEHICULO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_TIPO_COMPRA, Int32 NID_USO, Decimal M_VALOR_VEHICULO, Boolean L_MODIFICADO)
        //{
        //    try
        //    {
        //        _Add_MODIFICACION_VEHICULOs( NID_MARCA, C_MODELO, V_DESCRIPCION, F_ADQUISICION, NID_TIPO_COMPRA, NID_USO, M_VALOR_VEHICULO, L_MODIFICADO);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}

        public void Reload_MODIFICACION_INMUEBLEs()
        {
            _Reload_MODIFICACION_INMUEBLEs();
        }

        //public void Add_MODIFICACION_INMUEBLEs(Int32 NID_INMUEBLE, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE, Int32 NID_PATRIMONIO)
        //{
        //    try
        //    {
        //        _Add_MODIFICACION_INMUEBLEs(NID_INMUEBLE, NID_TIPO, F_ADQUISICION, NID_USO, E_UBICACION, N_TERRENO, N_CONSTRUCCION, M_VALOR_INMUEBLE, NID_PATRIMONIO);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}

        public void Reload_MODIFICACION_MUEBLEs()
        {
            _Reload_MODIFICACION_MUEBLEs();
        }

        //public void Add_MODIFICACION_MUEBLEs(Int32 NID_MUEBLE, Int32 NID_TIPO, String E_ESPECIFICACION, Int64 M_VALOR, Int32 NID_PATRIMONIO)
        //{
        //    try
        //    {
        //        _Add_MODIFICACION_MUEBLEs(NID_MUEBLE, NID_TIPO, E_ESPECIFICACION, M_VALOR, NID_PATRIMONIO);
        //    }
        //    catch (Exception e)
        //    {
        //        //if (e is ExistingPrimaryKeyException)
        //        //{
        //        //    ///Codigo Para Controlar la Excepcion de clave primaria existente
        //        //}
        //        //else
        //        //{
        //        //    throw e;
        //        //}
        //        throw e;
        //    }
        //}

        public void Reload_MODIFICACION_GASTOs()
        {
            _Reload_MODIFICACION_GASTOs();
        }

        public void Add_MODIFICACION_GASTOs(Int32 NID_TIPO_GASTO, String V_GASTO, Decimal M_GASTO, Boolean L_AUTOGENERADO, System.Nullable<Int32> NID_PATRIMONIO_ASC)
        {
            try
            {
                _Add_MODIFICACION_GASTOs(NID_TIPO_GASTO, V_GASTO, M_GASTO, L_AUTOGENERADO, NID_PATRIMONIO_ASC);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Reload_MODIFICACION_BAJAs()
        {
            _Reload_MODIFICACION_BAJAs();
        }

        public void Add_MODIFICACION_BAJAs(Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA)
        {
            try
            {
                _Add_MODIFICACION_BAJAs(NID_PATRIMONIO, NID_TIPO_BAJA, F_BAJA);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void Add_MODIFICACION_BAJAs(Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA,Boolean L_POLIZA, Decimal M_VALOR,Int32 NID_TIPO_VENTA,String E_BENEFICIARIO)
        {
            try
            {
                _Add_MODIFICACION_BAJAs(NID_PATRIMONIO, NID_TIPO_BAJA, F_BAJA,L_POLIZA,M_VALOR,NID_TIPO_VENTA,E_BENEFICIARIO);
                Reload_MODIFICACION_BAJAs();
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        private void _Add_MODIFICACION_BAJAs(Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA, Boolean L_POLIZA, Decimal M_VALOR, Int32 NID_TIPO_VENTA, String E_BENEFICIARIO)
        {
            blld_MODIFICACION_BAJA oMODIFICACION_BAJA = new blld_MODIFICACION_BAJA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_BAJA, F_BAJA,  L_POLIZA,  M_VALOR,  NID_TIPO_VENTA, Encripta (E_BENEFICIARIO));
            //if (oMODIFICACION_BAJA.lEsNuevoRegistro.Value) MODIFICACION_BAJAs.Add(oMODIFICACION_BAJA);
            //_MODIFICACION_BAJAs[FindIndex_MODIFICACION_BAJAs(NID_PATRIMONIO)] = oMODIFICACION_BAJA;
        }

        public void Reload_MODIFICACION_INGRESOSs()
        {
            _Reload_MODIFICACION_INGRESOSs();
        }

        public void Add_MODIFICACION_INGRESOSs(String E_ESPECIFICAR, String E_ESPECIFICAR_COMPLEMENTO, Decimal M_INGRESO, Char C_TITULAR)
        {
            try
            {
                _Add_MODIFICACION_INGRESOSs(E_ESPECIFICAR, E_ESPECIFICAR_COMPLEMENTO, M_INGRESO, C_TITULAR);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        private void _Add_MODIFICACION_INGRESOSs(String E_ESPECIFICAR, String E_ESPECIFICAR_COMPLEMENTO, Decimal M_INGRESO, Char C_TITULAR)
        {
            blld_MODIFICACION_INGRESOS oMODIFICACION_INGRESOS = new blld_MODIFICACION_INGRESOS(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_ESPECIFICAR, E_ESPECIFICAR_COMPLEMENTO, M_INGRESO, C_TITULAR);
            MODIFICACION_INGRESOSs.Add(oMODIFICACION_INGRESOS);
        }
        #endregion

    }
}
