using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Declara_V2;
using Declara_V2.DAL;
using MODELDeclara_V2;
using Declara_V2.Exceptions;
using System.Data.Entity.Core.Objects;

namespace Declara_V2.DALD
{
    // Extended
    internal partial class dald_DECLARACION : dal_DECLARACION
    {

        #region *** Atributos (Extended) ***

        internal dald_CAT_ESTADO_DECLARACION _oEstadoDeclaracion;

        internal dald_CAT_ESTADO_DECLARACION oEstadoDeclaracion
        {
            get
            {
                if (_oEstadoDeclaracion == null)
                    _oEstadoDeclaracion = new dald_CAT_ESTADO_DECLARACION(NID_ESTADO);
                return _oEstadoDeclaracion;
            }
        }

        internal dald_CAT_TIPO_DECLARACION _oTipoDeclaracion;

        internal dald_CAT_TIPO_DECLARACION oTipoDeclaracion
        {
            get
            {
                if (_oTipoDeclaracion == null)
                    _oTipoDeclaracion = new dald_CAT_TIPO_DECLARACION(NID_TIPO_DECLARACION);
                return _oTipoDeclaracion;
            }
        }
        public List<MODELextended.fn_BalanzaEgresos> BalanzaEgresos
        {
            get
            {
                return db.fn_BalanzaEgresos(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION).Select(p => new MODELextended.fn_BalanzaEgresos { V_CONCEPTO = p.V_CONCEPTO, NID_CONCEPTO = p.NID_CONCEPTO, M_DEPENDIENTE = p.M_DEPENDIENTE, M_DECLARANTE = p.M_DECLARANTE, M_TOTAL = p.M_TOTAL, N_NIVEL = p.N_NIVEL }).ToList();
            }
        }
        public List<MODELextended.fn_BalanzaIngresos> BalanzaIngresos
        {
            get
            {
                return db.fn_BalanzaIngresos(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION).Select( p=>  new MODELextended.fn_BalanzaIngresos { V_CONCEPTO= p.V_CONCEPTO, NID_CONCEPTO = p.NID_CONCEPTO, M_DEPENDIENTE = p.M_DEPENDIENTE, M_DECLARANTE= p.M_DECLARANTE, M_TOTAL = p.M_TOTAL, N_NIVEL = p.N_NIVEL } ).ToList();
        
            }
        }

   internal String V_ESTADO_TESTADO => oCAT_ESTADO_TESTADO.V_ESTADO_TESTADO;

        #endregion


        #region *** Constructores (Extended) ***

        public dald_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String C_EJERCICIO, Int32 NID_TIPO_DECLARACION, Int32 NID_ESTADO, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, Boolean L_AUTORIZA_PUBLICAR, System.Nullable<DateTime> F_ENVIO, System.Nullable<Boolean> L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
         : base()
        {
            ObjectParameter nNID_DECLARACION = new ObjectParameter("NID_DECLARACION", 0);

            /*sme*/


            if (NID_TIPO_DECLARACION > 0 & NID_TIPO_DECLARACION < 4)
                db.paDECLARACION_NUEVA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_TIPO_DECLARACION, C_EJERCICIO, nNID_DECLARACION);
            else
                throw new CustomException("Error en tipo de declaración");


            //switch (NID_TIPO_DECLARACION)
            //{
            //    case 1:

            //        db.paDEC_INICIAL_NUEVA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, nNID_DECLARACION);

            //        break;
            //    case 2:
            //        db.paDEC_MODIFICACION_NUEVA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, nNID_DECLARACION);
            //        break;
            //    case 3:
            //        db.paDEC_CONCLUSION_NUEVA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, nNID_DECLARACION);
            //        break;
            //    default:
            //        break;
            //}


            if ((Int32)nNID_DECLARACION.Value == -1)
                throw new CustomException("No se pudo iniciar la declaración");
            else
            {
                registro = db.DECLARACION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, nNID_DECLARACION.Value);
                if (registro == null) throw new RowNotFoundException();
            }


        }






        #endregion


        #region *** Metodos (Extended) ***

        //internal static int nNuevo_NID_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE)
        //{
        //    MODELDeclara_V2.cnxDeclara dbInt = new MODELDeclara_V2.cnxDeclara();
        //    try
        //    {
        //        var query = ((from p in dbInt.DECLARACION
        //                      where
        //                           p.VID_NOMBRE == VID_NOMBRE &&
        //                           p.VID_FECHA == VID_FECHA &&
        //                           p.VID_HOMOCLAVE == VID_HOMOCLAVE
        //                      select p.NID_DECLARACION).Max());
        //       return query + 1;
        //    }
        //    catch
        //    {
        //        return 1;
        //    }
        //}

        internal void Enviar()
        {
            try
            {
                /*sme*/

                if (NID_TIPO_DECLARACION > 0 & NID_TIPO_DECLARACION < 4)
                    db.paDECLARACION_ENVIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_TIPO_DECLARACION, C_EJERCICIO);
                else
                    throw new CustomException("Error en tipo de declaración");


                //switch (NID_TIPO_DECLARACION)
                //{
                //    case 1:
                //        db.paDEC_INICIAL_ENVIO(VID_NOMBRE
                //                  , VID_FECHA
                //                  , VID_HOMOCLAVE
                //                  , NID_DECLARACION);
                //        break;
                //    case 2:
                //        db.paDEC_MODIFICACION_ENVIO(VID_NOMBRE
                //                  , VID_FECHA
                //                  , VID_HOMOCLAVE
                //                  , NID_DECLARACION);
                //        break;
                //    case 3:
                //        db.paDEC_CONCLUSION_ENVIO(VID_NOMBRE
                //                  , VID_FECHA
                //                  , VID_HOMOCLAVE
                //                  , NID_DECLARACION);
                //        break;
                //    default:
                //        break;
                //}
                registro = db.DECLARACION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("|"))
                    {
                        String Mesaage = ex.InnerException.Message;
                        Mesaage = Mesaage.Substring(Mesaage.IndexOf('|') +1);
                        Mesaage = Mesaage.Substring(0,Mesaage.IndexOf('|'));
                        CustomException exep = new CustomException(Mesaage);
                        throw new CustomException("wrong!", exep);
                    }
                    else
                    {
                        throw new CustomException("wrong!", ex.InnerException);
                    }
                }
                else
                {
                    if (ex.Message.Contains("|"))
                    {
                        String Mesaage = ex.Message;
                        Mesaage = Mesaage.Substring(Mesaage.IndexOf('|'));
                        Mesaage = Mesaage.Substring(0, Mesaage.IndexOf('|'));
                        CustomException exep = new CustomException(Mesaage);
                        throw new CustomException("wrong!", exep);
                    }
                    else
                    {
                        throw new CustomException("wrong!", ex);
                    }
                }
            }

        }

        #endregion

    }
}
