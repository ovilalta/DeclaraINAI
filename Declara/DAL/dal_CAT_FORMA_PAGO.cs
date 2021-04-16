using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_FORMA_PAGO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_FORMA_PAGO registro { get; set; }
        internal Int32 NID_FORMA_PAGO => registro.NID_FORMA_PAGO;
        internal String V_FORMA_PAGO
        {
            get => registro.V_FORMA_PAGO;
            set => registro.V_FORMA_PAGO = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_FORMA_PAGO() => registro = new CAT_FORMA_PAGO();
        internal dal_CAT_FORMA_PAGO(CAT_FORMA_PAGO oCAT_FORMA_PAGO) : this(oCAT_FORMA_PAGO.NID_FORMA_PAGO) { }
        internal dal_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO) { registro = db.CAT_FORMA_PAGO.Find(NID_FORMA_PAGO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_FORMA_PAGO(Int32 NID_FORMA_PAGO, String V_FORMA_PAGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_FORMA_PAGO()
            {
                NID_FORMA_PAGO = NID_FORMA_PAGO,
                V_FORMA_PAGO = V_FORMA_PAGO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_FORMA_PAGO registroCheck = db.CAT_FORMA_PAGO.Find(NID_FORMA_PAGO);
                if (registroCheck == null)
                {
                    db.CAT_FORMA_PAGO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_FORMA_PAGO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_FORMA_PAGO = registro.V_FORMA_PAGO;
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
            db.CAT_FORMA_PAGO.Remove(registro);
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
