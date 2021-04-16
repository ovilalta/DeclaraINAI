using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_VALOR_ADQUISICION : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_VALOR_ADQUISICION registro { get; set; }
        internal Int32 NID_VALOR_ADQUISICION => registro.NID_VALOR_ADQUISICION;
        internal String V_VALOR_ADQUISICION
        {
            get => registro.V_VALOR_ADQUISICION;
            set => registro.V_VALOR_ADQUISICION = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_VALOR_ADQUISICION() => registro = new CAT_VALOR_ADQUISICION();
        internal dal_CAT_VALOR_ADQUISICION(CAT_VALOR_ADQUISICION oCAT_VALOR_ADQUISICION) : this(oCAT_VALOR_ADQUISICION.NID_VALOR_ADQUISICION) { }
        internal dal_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION) { registro = db.CAT_VALOR_ADQUISICION.Find(NID_VALOR_ADQUISICION); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_VALOR_ADQUISICION(Int32 NID_VALOR_ADQUISICION, String V_VALOR_ADQUISICION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_VALOR_ADQUISICION()
            {
                NID_VALOR_ADQUISICION = NID_VALOR_ADQUISICION,
                V_VALOR_ADQUISICION = V_VALOR_ADQUISICION,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_VALOR_ADQUISICION registroCheck = db.CAT_VALOR_ADQUISICION.Find(NID_VALOR_ADQUISICION);
                if (registroCheck == null)
                {
                    db.CAT_VALOR_ADQUISICION.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_VALOR_ADQUISICION));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_VALOR_ADQUISICION = registro.V_VALOR_ADQUISICION;
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
            db.CAT_VALOR_ADQUISICION.Remove(registro);
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
