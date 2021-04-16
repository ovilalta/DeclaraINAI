using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_TITULAR : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_TITULAR registro { get; set; }
        internal Int32 NID_TITULAR => registro.NID_TITULAR;
        internal String V_TITULAR
        {
            get => registro.V_TITULAR;
            set => registro.V_TITULAR = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_TITULAR() => registro = new CAT_TITULAR();
        internal dal_CAT_TITULAR(CAT_TITULAR oCAT_TITULAR) : this(oCAT_TITULAR.NID_TITULAR) { }
        internal dal_CAT_TITULAR(Int32 NID_TITULAR) { registro = db.CAT_TITULAR.Find(NID_TITULAR); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_TITULAR(Int32 NID_TITULAR, String V_TITULAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_TITULAR()
            {
                NID_TITULAR = NID_TITULAR,
                V_TITULAR = V_TITULAR,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_TITULAR registroCheck = db.CAT_TITULAR.Find(NID_TITULAR);
                if (registroCheck == null)
                {
                    db.CAT_TITULAR.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_TITULAR));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_TITULAR = registro.V_TITULAR;
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
            db.CAT_TITULAR.Remove(registro);
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
