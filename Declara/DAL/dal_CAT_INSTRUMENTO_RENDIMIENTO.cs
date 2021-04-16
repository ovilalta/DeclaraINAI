using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_INSTRUMENTO_RENDIMIENTO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_INSTRUMENTO_RENDIMIENTO registro { get; set; }
        internal Int32 NID_INSTRUMENTO_RENDIMIENTO => registro.NID_INSTRUMENTO_RENDIMIENTO;
        internal String V_INSTRUMENTO_RENDIMIENTO
        {
            get => registro.V_INSTRUMENTO_RENDIMIENTO;
            set => registro.V_INSTRUMENTO_RENDIMIENTO = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_INSTRUMENTO_RENDIMIENTO() => registro = new CAT_INSTRUMENTO_RENDIMIENTO();
        internal dal_CAT_INSTRUMENTO_RENDIMIENTO(CAT_INSTRUMENTO_RENDIMIENTO oCAT_INSTRUMENTO_RENDIMIENTO) : this(oCAT_INSTRUMENTO_RENDIMIENTO.NID_INSTRUMENTO_RENDIMIENTO) { }
        internal dal_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO) { registro = db.CAT_INSTRUMENTO_RENDIMIENTO.Find(NID_INSTRUMENTO_RENDIMIENTO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_INSTRUMENTO_RENDIMIENTO(Int32 NID_INSTRUMENTO_RENDIMIENTO, String V_INSTRUMENTO_RENDIMIENTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_INSTRUMENTO_RENDIMIENTO()
            {
                NID_INSTRUMENTO_RENDIMIENTO = NID_INSTRUMENTO_RENDIMIENTO,
                V_INSTRUMENTO_RENDIMIENTO = V_INSTRUMENTO_RENDIMIENTO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_INSTRUMENTO_RENDIMIENTO registroCheck = db.CAT_INSTRUMENTO_RENDIMIENTO.Find(NID_INSTRUMENTO_RENDIMIENTO);
                if (registroCheck == null)
                {
                    db.CAT_INSTRUMENTO_RENDIMIENTO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_INSTRUMENTO_RENDIMIENTO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_INSTRUMENTO_RENDIMIENTO = registro.V_INSTRUMENTO_RENDIMIENTO;
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
            db.CAT_INSTRUMENTO_RENDIMIENTO.Remove(registro);
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
