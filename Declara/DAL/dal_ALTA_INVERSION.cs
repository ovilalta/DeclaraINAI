using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_ALTA_INVERSION : _dal_base_Declara
    {

        ALTA_INVERSION registro;

        #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE;

        internal String VID_FECHA => registro.VID_FECHA;

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;

        internal Int32 NID_INVERSION => registro.NID_INVERSION;

        internal Int32 NID_TIPO_INVERSION
        {
            get => registro.NID_TIPO_INVERSION;
            set => registro.NID_TIPO_INVERSION = value;
        }

        internal Int32 NID_SUBTIPO_INVERSION
        {
            get => registro.NID_SUBTIPO_INVERSION;
            set => registro.NID_SUBTIPO_INVERSION = value;
        }

        internal Int32 NID_INSTITUCION
        {
            get => registro.NID_INSTITUCION;
            set => registro.NID_INSTITUCION = value;
        }

        internal String E_CUENTA
        {
            get => registro.E_CUENTA;
            set => registro.E_CUENTA = value;
        }

        internal String V_CUENTA_CORTO
        {
            get => registro.V_CUENTA_CORTO;
            set => registro.V_CUENTA_CORTO = value;
        }

        internal String V_OTRO
        {
            get => registro.V_OTRO;
            set => registro.V_OTRO = value;
        }

        internal Decimal M_SALDO
        {
            get => registro.M_SALDO;
            set => registro.M_SALDO = value;
        }

        internal Int32 NID_PAIS
        {
            get => registro.NID_PAIS;
            set => registro.NID_PAIS = value;
        }

        internal String CID_ENTIDAD_FEDERATIVA
        {
            get => registro.CID_ENTIDAD_FEDERATIVA;
            set => registro.CID_ENTIDAD_FEDERATIVA = value;
        }

        internal String V_LUGAR
        {
            get => registro.V_LUGAR;
            set => registro.V_LUGAR = value;
        }

        internal DateTime F_APERTURA
        {
            get => registro.F_APERTURA;
            set => registro.F_APERTURA = value;
        }

        internal Int32 NID_PATRIMONIO
        {
            get => registro.NID_PATRIMONIO;
            set => registro.NID_PATRIMONIO = value;
        }


        internal String V_RFC_INVERSION
        {
            get => registro.V_RFC_INVERSION;
            set => registro.V_RFC_INVERSION = value;
        }


        internal String V_TIPO_MONEDA
        {
            get => registro.V_TIPO_MONEDA;
            set => registro.V_TIPO_MONEDA = value;
        }
        //internal String V_TERCERO_TIPO
        //{
        //    get => registro.V_TERCERO_TIPO;
        //    set => registro.V_TERCERO_TIPO = value;
        //}
        //internal String V_TERCERO_NOMBRE
        //{
        //    get => registro.V_TERCERO_NOMBRE;
        //    set => registro.V_TERCERO_NOMBRE = value;
        //}
        //internal String V_TERCERO_RFC
        //{
        //    get => registro.V_TERCERO_RFC;
        //    set => registro.V_TERCERO_RFC = value;
        //}

        internal String E_OBSERVACIONES
        {
            get => registro.E_OBSERVACIONES;
            set => registro.E_OBSERVACIONES = value;
        }


        #endregion


        #region *** Constructores ***

        internal dal_ALTA_INVERSION() => registro = new ALTA_INVERSION();

        internal dal_ALTA_INVERSION(ALTA_INVERSION oALTA_INVERSION) : this(oALTA_INVERSION.VID_NOMBRE, oALTA_INVERSION.VID_FECHA, oALTA_INVERSION.VID_HOMOCLAVE, oALTA_INVERSION.NID_DECLARACION, oALTA_INVERSION.NID_INVERSION) { }

        internal dal_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION) { registro = db.ALTA_INVERSION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_CUENTA_CORTO, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, DateTime F_APERTURA, Int32 NID_PATRIMONIO, String V_RFC_INVERSION, String V_TIPO_MONEDA, String E_OBSERVACIONES, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new ALTA_INVERSION()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_INVERSION = NID_INVERSION,
                NID_TIPO_INVERSION = NID_TIPO_INVERSION,
                NID_SUBTIPO_INVERSION = NID_SUBTIPO_INVERSION,
                NID_INSTITUCION = NID_INSTITUCION,
                E_CUENTA = E_CUENTA,
                V_CUENTA_CORTO = V_CUENTA_CORTO,
                V_OTRO = V_OTRO,
                M_SALDO = M_SALDO,
                NID_PAIS = NID_PAIS,
                CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                V_LUGAR = V_LUGAR,
                F_APERTURA = F_APERTURA,
                NID_PATRIMONIO = NID_PATRIMONIO,
                V_RFC_INVERSION = V_RFC_INVERSION,
                V_TIPO_MONEDA = V_TIPO_MONEDA,
                E_OBSERVACIONES = E_OBSERVACIONES,
            };
            try
            {
                ALTA_INVERSION registroCheck = db.ALTA_INVERSION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("ALTA_INVERSION", VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_INVERSION.ToString() + ", ");
                        break;

                    //Usar registro existente
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting:
                        if (registroCheck == null) insert();
                        else registro = registroCheck;
                        break;

                    //Actualizar registro existente
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting:
                        if (registroCheck == null) insert();
                        else
                        {
                            db.ALTA_INVERSION.Attach(registro);
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


        #region *** Metodos ***

        internal void insert()
        {
            db.ALTA_INVERSION.Add(registro);
            SaveChanges(true);
        }

        internal void update()
        {
            if (db.Entry(registro).State == EntityState.Modified)
            {
                SaveChanges(false);
            }
        }

        internal void delete()
        {
            db.ALTA_INVERSION.Remove(registro);
            SaveChanges(null);
            if (db.Entry(registro).State == EntityState.Detached) registro = null;
        }

        internal void reload()
        {
            db.Entry(registro).Reload();
            _lEsNuevoRegistro = false;
        }

        private void SaveChanges(System.Nullable<Boolean> q)
        {
            db.SaveChanges();
            _lEsNuevoRegistro = q;
        }


        #endregion

    }
}
