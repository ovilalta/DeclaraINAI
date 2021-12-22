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
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Declara_V2.DALD
{
// Extended
    internal partial class dald_ALTA_MUEBLE : dal_ALTA_MUEBLE
    {

        #region *** Atributos (Extended) ***

        protected ALTA_MUEBLE_FORMA_ADQUISICION registro_forma_adquisicion;

        //public System.Nullable<Int32> NID_FORMA_ADQUISICION
        //{
        //    get
        //    {
        //        if (registro_forma_adquisicion == null)
        //        {
        //            registro_forma_adquisicion = db.ALTA_MUEBLE_FORMA_ADQUISICION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE);
        //            if (registro_forma_adquisicion == null)
        //                return -1;
        //        }
        //        return registro_forma_adquisicion.NID_FORMA_ADQUISICION;
        //    }
        //    set
        //    {
        //        if (value.HasValue)
        //        {
        //            if (registro_forma_adquisicion == null)
        //                SaveFormaAdquisicion(value.Value);
        //            else
        //                registro_forma_adquisicion.NID_FORMA_ADQUISICION = value.Value;
        //        }
        //        else
        //        {
        //            if (registro_forma_adquisicion == null)
        //                SaveFormaAdquisicion(-1);
        //            else
        //                registro_forma_adquisicion.NID_FORMA_ADQUISICION = -1;
        //        }
        //    }
        //}

        // sme

        internal dald_CAT_FORMA_PAGO _oFormaPago;

        internal dald_CAT_FORMA_PAGO oFormaPago
        {
            get
            {
                if (_oFormaPago == null)
                    _oFormaPago = new dald_CAT_FORMA_PAGO(NID_FORMA_PAGO);
                return _oFormaPago;
            }
        }

        internal dald_CAT_FORMA_ADQUISICION _oFormaAdquisicion;

        internal dald_CAT_FORMA_ADQUISICION oFormaAdquisicion
        {
            get
            {
                if (_oFormaAdquisicion == null)
                    _oFormaAdquisicion = new dald_CAT_FORMA_ADQUISICION(NID_FORMA_ADQUISICION);
                return _oFormaAdquisicion;
            }
        }


        internal dald_CAT_RELACION_TRANSMISOR _oRelacionTransmisor;

        internal dald_CAT_RELACION_TRANSMISOR oRelacionTransmisor
        {
            get
            {
                if (_oRelacionTransmisor == null)
                    _oRelacionTransmisor = new dald_CAT_RELACION_TRANSMISOR(NID_RELACION_TRANSMISOR);
                return _oRelacionTransmisor;
            }
        }


        // sme
        #endregion


        #region *** Constructores (Extended) ***


        internal dald_ALTA_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE, Int32 NID_TIPO, String E_ESPECIFICACION, Decimal M_VALOR, Int32 NID_PATRIMONIO, Boolean L_CREDITO, DateTime F_ADQUISICION, Int32 NID_FORMA_ADQUISICION, String D_ESPECIFICACION,ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new ALTA_MUEBLE()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_MUEBLE = NID_MUEBLE,
                NID_TIPO = NID_TIPO,
                E_ESPECIFICACION = E_ESPECIFICACION,
                M_VALOR = M_VALOR,
                NID_PATRIMONIO = NID_PATRIMONIO,
                L_CREDITO = L_CREDITO,
                F_ADQUISICION = F_ADQUISICION,
                D_ESPECIFICACION = D_ESPECIFICACION,
            };
            try
            {
                ALTA_MUEBLE registroCheck = db.ALTA_MUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE);

                registro_forma_adquisicion = new ALTA_MUEBLE_FORMA_ADQUISICION()
                {
                    VID_NOMBRE = VID_NOMBRE,
                    VID_FECHA = VID_FECHA,
                    VID_HOMOCLAVE = VID_HOMOCLAVE,
                    NID_DECLARACION = NID_DECLARACION,
                    NID_MUEBLE = NID_MUEBLE,
                    M_DONACION = 0,
                    NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION
                };

                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insertAll();
                        else throw new ExistingPrimaryKeyException("ALTA_MUEBLE", VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_MUEBLE.ToString() + ", ");
                        break;

                    //Usar registro existente
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting:
                        if (registroCheck == null) insertAll();
                        else registro = registroCheck;
                        break;

                    //Actualizar registro existente
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting:
                        if (registroCheck == null) insertAll();
                        else
                        {
                            db.ALTA_MUEBLE.Attach(registro);
                            ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(registro, EntityState.Modified);
                            update();
                        }
                        break;

                    //Opcion no Implementada
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                registro = null;
                throw ex;
            }
        }

        #endregion


        #region *** Metodos (Extended) ***

        internal static int nNuevo_NID_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.ALTA_MUEBLE
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p.NID_MUEBLE).Max());
               return query + 1;
            }
            catch
            {
                return 1;
            }
        }

        new public void delete()
        {
            db.paMUEBLE_ELIMINA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE);
        }

        private void SaveFormaAdquisicion(int NID_FORMA_ADQUISICION)
        {
            registro_forma_adquisicion = new ALTA_MUEBLE_FORMA_ADQUISICION()
            {
                VID_NOMBRE = this.VID_NOMBRE,
                VID_FECHA = this.VID_FECHA,
                VID_HOMOCLAVE = this.VID_HOMOCLAVE,
                NID_DECLARACION = this.NID_DECLARACION,
                NID_MUEBLE = this.NID_MUEBLE,
                M_DONACION = 0,
                NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION
            };
            try
            {
                db.ALTA_MUEBLE_FORMA_ADQUISICION.Add(registro_forma_adquisicion);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                registro_forma_adquisicion = null;
                throw ex;
            }
        }

        internal void insertAll()
        {
            db.ALTA_MUEBLE.Add(registro);
            db.ALTA_MUEBLE_FORMA_ADQUISICION.Add(registro_forma_adquisicion);
            db.SaveChanges();
            _lEsNuevoRegistro = true;
        }

        new internal void update()
        {
            db.SaveChanges();
        }

        #endregion

    }
}
