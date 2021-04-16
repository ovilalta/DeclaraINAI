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

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_MODIFICACION_BAJA : bll_MODIFICACION_BAJA
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_MODIFICACION_BAJA.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_MODIFICACION_BAJA.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_MODIFICACION_BAJA.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_MODIFICACION_BAJA.NID_DECLARACION; }
        //        }

        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_MODIFICACION_BAJA.NID_PATRIMONIO; }
        //        }


        //        public Int32 NID_TIPO_BAJA
        //        {
        //          get { return datos_MODIFICACION_BAJA.NID_TIPO_BAJA; }
        //          set { datos_MODIFICACION_BAJA.NID_TIPO_BAJA = value; }
        //        }


        //        public DateTime F_BAJA
        //        {
        //          get { return datos_MODIFICACION_BAJA.F_BAJA; }
        //          set { datos_MODIFICACION_BAJA.F_BAJA = value; }
        //        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_MODIFICACION_BAJA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA)
        : base()
        {
            if (F_BAJA > DateTime.Now)
                throw new CustomException("La fecha de venta no puede ser mayor la fecha actual");
            datos_MODIFICACION_BAJA = new dald_MODIFICACION_BAJA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_BAJA, F_BAJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting);
        }

       

        public blld_MODIFICACION_BAJA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_TIPO_BAJA, DateTime F_BAJA, Boolean L_POLIZA, Decimal M_VALOR, Int32 NID_TIPO_VENTA, String E_BENEFICIARIO)
         : base()
        {
            if (F_BAJA > DateTime.Now)
                throw new CustomException("La fecha de venta no puede ser mayor la fecha actual");
            datos_MODIFICACION_BAJA = new dald_MODIFICACION_BAJA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_TIPO_BAJA, F_BAJA, L_POLIZA, M_VALOR, NID_TIPO_VENTA, E_BENEFICIARIO);
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Add_MODIFICACION_DONACION(String V_ESPECIFICA, String E_BENIFICIARIO)
        {
            try
            {
                _Add_MODIFICACION_DONACION(V_ESPECIFICA, E_BENIFICIARIO);
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
        public void Add_MODIFICACION_BAJA_SINIESTRO(Boolean L_POLIZA, Decimal M_RECUPERADO)
        {
            try
            {
                _Add_MODIFICACION_BAJA_SINIESTRO(L_POLIZA, M_RECUPERADO);
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
        public void Add_MODIFICACION_BAJA_VENTA(Int32 NID_TIPO_VENTA, Decimal M_IMPORTE_VENTA, String E_BENIFICIARIO)
        {
            try
            {
                _Add_MODIFICACION_BAJA_VENTA(NID_TIPO_VENTA, M_IMPORTE_VENTA, E_BENIFICIARIO);
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



        #endregion

    }
}
