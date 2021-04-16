using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_AMBITO_SECTOR : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_AMBITO_SECTOR registro { get; set; }
        internal Int32 NID_AMBITO_SECTOR => registro.NID_AMBITO_SECTOR;
        internal String V_AMBITO_SECTOR
        {
            get => registro.V_AMBITO_SECTOR;
            set => registro.V_AMBITO_SECTOR = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_AMBITO_SECTOR() => registro = new CAT_AMBITO_SECTOR();
        internal dal_CAT_AMBITO_SECTOR(CAT_AMBITO_SECTOR oCAT_AMBITO_SECTOR) : this(oCAT_AMBITO_SECTOR.NID_AMBITO_SECTOR) { }
        internal dal_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR) { registro = db.CAT_AMBITO_SECTOR.Find(NID_AMBITO_SECTOR); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_AMBITO_SECTOR(Int32 NID_AMBITO_SECTOR, String V_AMBITO_SECTOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_AMBITO_SECTOR()
            {
                NID_AMBITO_SECTOR = NID_AMBITO_SECTOR,
                V_AMBITO_SECTOR = V_AMBITO_SECTOR,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_AMBITO_SECTOR registroCheck = db.CAT_AMBITO_SECTOR.Find(NID_AMBITO_SECTOR);
                if (registroCheck == null)
                {
                    db.CAT_AMBITO_SECTOR.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_AMBITO_SECTOR));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_AMBITO_SECTOR = registro.V_AMBITO_SECTOR;
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
            db.CAT_AMBITO_SECTOR.Remove(registro);
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
