using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_FORMA_ADQUISICION : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_FORMA_ADQUISICION registro { get; set; }
        internal Int32 NID_FORMA_ADQUISICION => registro.NID_FORMA_ADQUISICION;
        internal String V_FORMA_ADQUISICION
        {
            get => registro.V_FORMA_ADQUISICION;
            set => registro.V_FORMA_ADQUISICION = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_FORMA_ADQUISICION() => registro = new CAT_FORMA_ADQUISICION();
        internal dal_CAT_FORMA_ADQUISICION(CAT_FORMA_ADQUISICION oCAT_FORMA_ADQUISICION) : this(oCAT_FORMA_ADQUISICION.NID_FORMA_ADQUISICION) { }
        internal dal_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION) { registro = db.CAT_FORMA_ADQUISICION.Find(NID_FORMA_ADQUISICION); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_FORMA_ADQUISICION(Int32 NID_FORMA_ADQUISICION, String V_FORMA_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_FORMA_ADQUISICION()
            {
                NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION,
                V_FORMA_ADQUISICION = V_FORMA_ADQUISICION,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_FORMA_ADQUISICION registroCheck = db.CAT_FORMA_ADQUISICION.Find(NID_FORMA_ADQUISICION);
                if (registroCheck == null)
                {
                    db.CAT_FORMA_ADQUISICION.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_FORMA_ADQUISICION));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_FORMA_ADQUISICION = registro.V_FORMA_ADQUISICION;
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
            db.CAT_FORMA_ADQUISICION.Remove(registro);
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
