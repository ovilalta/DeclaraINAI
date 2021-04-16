using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_INGRESOS : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_INGRESOS registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_INGRESO => registro.NID_INGRESO;
        internal String V_CONCEPTO
        {
            get => registro.V_CONCEPTO;
            set => registro.V_CONCEPTO = value;
        }
        internal Decimal M_DECLARANTE
        {
            get => registro.M_DECLARANTE;
            set => registro.M_DECLARANTE = value;
        }
        internal Decimal M_DEPENDIENTE
        {
            get => registro.M_DEPENDIENTE;
            set => registro.M_DEPENDIENTE = value;
        }
        internal Decimal M_SUMA
        {
            get => registro.M_SUMA;
            set => registro.M_SUMA = value;
        }
        internal Int32 N_NIVEL
        {
            get => registro.N_NIVEL;
            set => registro.N_NIVEL = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_DECLARACION_INGRESOS() => registro = new DECLARACION_INGRESOS();
        internal dal_DECLARACION_INGRESOS(DECLARACION_INGRESOS oDECLARACION_INGRESOS) : this(oDECLARACION_INGRESOS.VID_NOMBRE, oDECLARACION_INGRESOS.VID_FECHA, oDECLARACION_INGRESOS.VID_HOMOCLAVE, oDECLARACION_INGRESOS.NID_DECLARACION, oDECLARACION_INGRESOS.NID_INGRESO) { }
        internal dal_DECLARACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO) { registro = db.DECLARACION_INGRESOS.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_DECLARACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String V_CONCEPTO, Decimal M_DECLARANTE, Decimal M_DEPENDIENTE, Decimal M_SUMA, Int32 N_NIVEL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_INGRESOS()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_INGRESO = NID_INGRESO,
                V_CONCEPTO = V_CONCEPTO,
                M_DECLARANTE = M_DECLARANTE,
                M_DEPENDIENTE = M_DEPENDIENTE,
                M_SUMA = M_SUMA,
                N_NIVEL = N_NIVEL,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                DECLARACION_INGRESOS registroCheck = db.DECLARACION_INGRESOS.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO);
                if (registroCheck == null)
                {
                    db.DECLARACION_INGRESOS.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION, ", ", NID_INGRESO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_CONCEPTO = registro.V_CONCEPTO;
                            registroCheck.M_DECLARANTE = registro.M_DECLARANTE;
                            registroCheck.M_DEPENDIENTE = registro.M_DEPENDIENTE;
                            registroCheck.M_SUMA = registro.M_SUMA;
                            registroCheck.N_NIVEL = registro.N_NIVEL;
                            SaveChanges(false);
                            registro = registroCheck;
                            break;
                        default://Opcion no Implementada
                            throw new NotImplementedException();
                    }
                }
            }
            catch (Exception ex)
            {
                registro = null;
                throw ex;
            }
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
            db.DECLARACION_INGRESOS.Remove(registro);
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
