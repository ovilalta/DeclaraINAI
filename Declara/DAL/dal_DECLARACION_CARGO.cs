using Declara_V2.Exceptions;
using MODELDeclara_V2;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_CARGO : _dal_base_Declara
    {

        DECLARACION_CARGO registro;

        #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE;

        internal String VID_FECHA => registro.VID_FECHA;

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;

        internal Int32 NID_PUESTO
        {
            get => registro.NID_PUESTO;
            set => registro.NID_PUESTO = value;
        }

        internal String V_DENOMINACION
        {
            get => registro.V_DENOMINACION;
            set => registro.V_DENOMINACION = value;
        }

        internal DateTime F_POSESION
        {
            get => registro.F_POSESION;
            set => registro.F_POSESION = value;
        }

        internal DateTime F_INICIO
        {
            get => registro.F_INICIO;
            set => registro.F_INICIO = value;
        }

        internal String VID_PRIMER_NIVEL
        {
            get => registro.VID_PRIMER_NIVEL;
            set => registro.VID_PRIMER_NIVEL = value;
        }

        internal String VID_SEGUNDO_NIVEL
        {
            get => registro.VID_SEGUNDO_NIVEL;
            set => registro.VID_SEGUNDO_NIVEL = value;
        }

        internal String E_OBSERVACIONES
        {
            get => registro.E_OBSERVACIONES;
            set => registro.E_OBSERVACIONES = value;
        }
        internal String E_OBSERVACIONES_MARCADO
        {
            get => registro.E_OBSERVACIONES_MARCADO;
            set => registro.E_OBSERVACIONES_MARCADO = value;
        }
        internal String V_OBSERVACIONES_TESTADO
        {
            get => registro.V_OBSERVACIONES_TESTADO;
            set => registro.V_OBSERVACIONES_TESTADO = value;
        }
        internal String V_FUNCION_PRINCIPAL
        {
            get => registro.V_FUNCION_PRINCIPAL;
            set => registro.V_FUNCION_PRINCIPAL = value;
        }
        internal Int32 NID_ESTADO_TESTADO
        {
            get => registro.NID_ESTADO_TESTADO;
            set => registro.NID_ESTADO_TESTADO = value;
        }
        #endregion


        #region *** Constructores ***

        internal dal_DECLARACION_CARGO() => registro = new DECLARACION_CARGO();

        internal dal_DECLARACION_CARGO(DECLARACION_CARGO oDECLARACION_CARGO) : this(oDECLARACION_CARGO.VID_NOMBRE, oDECLARACION_CARGO.VID_FECHA, oDECLARACION_CARGO.VID_HOMOCLAVE, oDECLARACION_CARGO.NID_DECLARACION) { }

        internal dal_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) { registro = db.DECLARACION_CARGO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_DECLARACION_CARGO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PUESTO, String V_DENOMINACION, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, DateTime F_INICIO, String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_CARGO()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_PUESTO = NID_PUESTO,
                V_DENOMINACION = V_DENOMINACION,
                V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL,
                F_POSESION = F_POSESION,
                F_INICIO = F_INICIO,
                VID_PRIMER_NIVEL = VID_PRIMER_NIVEL,
                VID_SEGUNDO_NIVEL = VID_SEGUNDO_NIVEL,
                E_OBSERVACIONES = E_OBSERVACIONES,
                E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO,
                V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO,
                NID_ESTADO_TESTADO = NID_ESTADO_TESTADO
            };
            try
            {
                DECLARACION_CARGO registroCheck = db.DECLARACION_CARGO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("DECLARACION_CARGO", VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", ");
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
                            db.DECLARACION_CARGO.Attach(registro);
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
            db.DECLARACION_CARGO.Add(registro);
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
            db.DECLARACION_CARGO.Remove(registro);
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
