using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_REGIMEN_MATRIMONIAL : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_REGIMEN_MATRIMONIAL registro { get; set; }
        internal Int32 NID_REGIMEN_MATRIMONIAL => registro.NID_REGIMEN_MATRIMONIAL;
        internal String V_REGIMEN_MATRIMONIAL
        {
            get => registro.V_REGIMEN_MATRIMONIAL;
            set => registro.V_REGIMEN_MATRIMONIAL = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_REGIMEN_MATRIMONIAL() => registro = new CAT_REGIMEN_MATRIMONIAL();
        internal dal_CAT_REGIMEN_MATRIMONIAL(CAT_REGIMEN_MATRIMONIAL oCAT_REGIMEN_MATRIMONIAL) : this(oCAT_REGIMEN_MATRIMONIAL.NID_REGIMEN_MATRIMONIAL) { }
        internal dal_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL) { registro = db.CAT_REGIMEN_MATRIMONIAL.Find(NID_REGIMEN_MATRIMONIAL); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_REGIMEN_MATRIMONIAL(Int32 NID_REGIMEN_MATRIMONIAL, String V_REGIMEN_MATRIMONIAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_REGIMEN_MATRIMONIAL()
            {
                NID_REGIMEN_MATRIMONIAL = NID_REGIMEN_MATRIMONIAL,
                V_REGIMEN_MATRIMONIAL = V_REGIMEN_MATRIMONIAL,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_REGIMEN_MATRIMONIAL registroCheck = db.CAT_REGIMEN_MATRIMONIAL.Find(NID_REGIMEN_MATRIMONIAL);
                if (registroCheck == null)
                {
                    db.CAT_REGIMEN_MATRIMONIAL.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_REGIMEN_MATRIMONIAL));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_REGIMEN_MATRIMONIAL = registro.V_REGIMEN_MATRIMONIAL;
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
            db.CAT_REGIMEN_MATRIMONIAL.Remove(registro);
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
