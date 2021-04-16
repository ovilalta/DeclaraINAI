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
    internal partial class dald_ALTA_INMUEBLE : dal_ALTA_INMUEBLE
    {


        #region *** Atributos (Extended) ***

        protected ALTA_INMUEBLE_FORMA_ADQUISICION registro_forma_adquisicion;
        protected ALTA_INMUEBLE_PAGO_INICIAL registro_pago_inicial;


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

        internal dald_CAT_VALOR_ADQUISICION _oValorAdquisicion;

        internal dald_CAT_VALOR_ADQUISICION oValorAdquisicion
        {
            get
            {
                if (_oValorAdquisicion == null)
                    _oValorAdquisicion = new dald_CAT_VALOR_ADQUISICION(NID_VALOR_ADQUISICION);
                return _oValorAdquisicion;
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


        internal dald_CAT_PAIS _oPais;

        internal dald_CAT_ENTIDAD_FEDERATIVA _oEntidad;

        internal dald_CAT_MUNICIPIO _oMunicipio;

        internal dald_CAT_PAIS oPais
        {
            get
            {
                if (_oPais == null)
                    _oPais = new dald_CAT_PAIS(1);
                return _oPais;
            }
        }


        internal dald_CAT_ENTIDAD_FEDERATIVA oEntidad
        {
            get
            {
                if (_oEntidad == null)
                    _oEntidad = new dald_CAT_ENTIDAD_FEDERATIVA(1, "09");
                return _oEntidad;
            }
        }

        internal dald_CAT_MUNICIPIO oMunicipio
        {
            get
            {
                if (_oMunicipio == null)
                    _oMunicipio = new dald_CAT_MUNICIPIO(1, "09", "01");
                return _oMunicipio;
            }
        }

        // sme

        public Decimal M_PAGO_INICIAL
        {
            get
            {
                if (registro_pago_inicial == null)
                {
                    registro_pago_inicial = db.ALTA_INMUEBLE_PAGO_INICIAL.Find(VID_NOMBRE,VID_FECHA,VID_HOMOCLAVE,NID_DECLARACION,NID_INMUEBLE);
                    if (registro_pago_inicial == null)
                        return 0;
                }
                return registro_pago_inicial.M_PAGO;
            }
            set
            {
                if (registro_pago_inicial == null)
                    SavePago(value);
                else
                    registro_pago_inicial.M_PAGO = value;
            }
        }

        

        //public System.Nullable<Int32> NID_FORMA_ADQUISICION
        //{
        //    get
        //    {
        //        if (registro_forma_adquisicion == null)
        //        {
        //            registro_forma_adquisicion = db.ALTA_INMUEBLE_FORMA_ADQUISICION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE,NID_DECLARACION, NID_INMUEBLE);
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



        #endregion


        #region *** Constructores (Extended) ***

        internal dald_ALTA_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE, Int32 NID_PATRIMONIO, Decimal M_PAGO, Int32 NID_FORMA_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new ALTA_INMUEBLE()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_INMUEBLE = NID_INMUEBLE,
                NID_TIPO = NID_TIPO,
                F_ADQUISICION = F_ADQUISICION,
                NID_USO = NID_USO,
                E_UBICACION = E_UBICACION,
                N_TERRENO = N_TERRENO,
                N_CONSTRUCCION = N_CONSTRUCCION,
                M_VALOR_INMUEBLE = M_VALOR_INMUEBLE,
                NID_PATRIMONIO = NID_PATRIMONIO,
            };
            try
            {
                ALTA_INMUEBLE registroCheck = db.ALTA_INMUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE);

                registro_pago_inicial = new ALTA_INMUEBLE_PAGO_INICIAL()
                {
                    VID_NOMBRE = VID_NOMBRE,
                    VID_FECHA = VID_FECHA,
                    VID_HOMOCLAVE = VID_HOMOCLAVE,
                    NID_DECLARACION = NID_DECLARACION,
                    NID_INMUEBLE = NID_INMUEBLE,
                    M_PAGO = M_PAGO,
                };

                registro_forma_adquisicion = new ALTA_INMUEBLE_FORMA_ADQUISICION()
                {
                    VID_NOMBRE = VID_NOMBRE,
                    VID_FECHA = VID_FECHA,
                    VID_HOMOCLAVE = VID_HOMOCLAVE,
                    NID_DECLARACION = NID_DECLARACION,
                    NID_INMUEBLE = NID_INMUEBLE,
                    M_DONACION = 0,
                    NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION
                };


                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insertAll();
                        else throw new ExistingPrimaryKeyException("ALTA_INMUEBLE", VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_INMUEBLE.ToString() + ", ");
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
                            db.ALTA_INMUEBLE.Attach(registro);
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

        private void SavePago(decimal M_PAGO)
        {
            registro_pago_inicial = new ALTA_INMUEBLE_PAGO_INICIAL()
            {
                VID_NOMBRE = this.VID_NOMBRE,
                VID_FECHA = this.VID_FECHA,
                VID_HOMOCLAVE = this.VID_HOMOCLAVE,
                NID_DECLARACION = this.NID_DECLARACION,
                NID_INMUEBLE = this.NID_INMUEBLE,
                M_PAGO = M_PAGO,
            };
            try
            {
                db.ALTA_INMUEBLE_PAGO_INICIAL.Add(registro_pago_inicial);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                registro_pago_inicial = null;
                throw ex;
            }
        }

        private void SaveFormaAdquisicion(int NID_FORMA_ADQUISICION)
        {
            registro_forma_adquisicion = new ALTA_INMUEBLE_FORMA_ADQUISICION()
            {
                VID_NOMBRE = this.VID_NOMBRE,
                VID_FECHA = this.VID_FECHA,
                VID_HOMOCLAVE = this.VID_HOMOCLAVE,
                NID_DECLARACION = this.NID_DECLARACION,
                NID_INMUEBLE = this.NID_INMUEBLE,
                M_DONACION = 0,
                NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION
            };
            try
            {
                db.ALTA_INMUEBLE_FORMA_ADQUISICION.Add(registro_forma_adquisicion);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                registro_forma_adquisicion = null;
                throw ex;
            }
        }

        internal static int nNuevo_NID_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION)
        {
            MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
            try
            {
                var query = ((from p in db.ALTA_INMUEBLE
                              where
                                   p.VID_NOMBRE == VID_NOMBRE &&
                                   p.VID_FECHA == VID_FECHA &&
                                   p.VID_HOMOCLAVE == VID_HOMOCLAVE &&
                                   p.NID_DECLARACION == NID_DECLARACION
                              select p.NID_INMUEBLE).Max());
                return query + 1;
            }
            catch
            {
                return 1;
            }
        }

        new public void delete()
        {
            db.paIMUEBLE_ELIMINA(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE);
        }

        internal void insertAll()
        {
            db.ALTA_INMUEBLE.Add(registro);
            db.ALTA_INMUEBLE_PAGO_INICIAL.Add(registro_pago_inicial);
            db.ALTA_INMUEBLE_FORMA_ADQUISICION.Add(registro_forma_adquisicion);
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
