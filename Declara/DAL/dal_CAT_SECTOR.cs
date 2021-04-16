using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_SECTOR : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_SECTOR registro { get; set; }
        internal Int32 NID_SECTOR => registro.NID_SECTOR;
        internal String V_SECTOR
        {
            get => registro.V_SECTOR;
            set => registro.V_SECTOR = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_SECTOR() => registro = new CAT_SECTOR();
        internal dal_CAT_SECTOR(CAT_SECTOR oCAT_SECTOR) : this(oCAT_SECTOR.NID_SECTOR) { }
        internal dal_CAT_SECTOR(Int32 NID_SECTOR) { registro = db.CAT_SECTOR.Find(NID_SECTOR); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_SECTOR(Int32 NID_SECTOR, String V_SECTOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_SECTOR()
            {
                NID_SECTOR = NID_SECTOR,
                V_SECTOR = V_SECTOR,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_SECTOR registroCheck = db.CAT_SECTOR.Find(NID_SECTOR);
                if (registroCheck == null)
                {
                    db.CAT_SECTOR.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_SECTOR));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_SECTOR = registro.V_SECTOR;
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
            db.CAT_SECTOR.Remove(registro);
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
