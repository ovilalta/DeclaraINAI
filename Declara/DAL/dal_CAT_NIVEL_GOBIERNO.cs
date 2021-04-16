using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_NIVEL_GOBIERNO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_NIVEL_GOBIERNO registro { get; set; }
        internal Int32 NID_NIVEL_GOBIERNO => registro.NID_NIVEL_GOBIERNO;
        internal String V_NIVEL_GOBIERNO
        {
            get => registro.V_NIVEL_GOBIERNO;
            set => registro.V_NIVEL_GOBIERNO = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_NIVEL_GOBIERNO() => registro = new CAT_NIVEL_GOBIERNO();
        internal dal_CAT_NIVEL_GOBIERNO(CAT_NIVEL_GOBIERNO oCAT_NIVEL_GOBIERNO) : this(oCAT_NIVEL_GOBIERNO.NID_NIVEL_GOBIERNO) { }
        internal dal_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO) { registro = db.CAT_NIVEL_GOBIERNO.Find(NID_NIVEL_GOBIERNO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_NIVEL_GOBIERNO(Int32 NID_NIVEL_GOBIERNO, String V_NIVEL_GOBIERNO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_NIVEL_GOBIERNO()
            {
                NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO,
                V_NIVEL_GOBIERNO = V_NIVEL_GOBIERNO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_NIVEL_GOBIERNO registroCheck = db.CAT_NIVEL_GOBIERNO.Find(NID_NIVEL_GOBIERNO);
                if (registroCheck == null)
                {
                    db.CAT_NIVEL_GOBIERNO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_NIVEL_GOBIERNO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_NIVEL_GOBIERNO = registro.V_NIVEL_GOBIERNO;
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
            db.CAT_NIVEL_GOBIERNO.Remove(registro);
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
