using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_RELACION_TRANSMISOR : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_RELACION_TRANSMISOR registro { get; set; }
        internal Int32 NID_RELACION_TRANSMISOR => registro.NID_RELACION_TRANSMISOR;
        internal String V_RELACION_TRANSMISOR
        {
            get => registro.V_RELACION_TRANSMISOR;
            set => registro.V_RELACION_TRANSMISOR = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_RELACION_TRANSMISOR() => registro = new CAT_RELACION_TRANSMISOR();
        internal dal_CAT_RELACION_TRANSMISOR(CAT_RELACION_TRANSMISOR oCAT_RELACION_TRANSMISOR) : this(oCAT_RELACION_TRANSMISOR.NID_RELACION_TRANSMISOR) { }
        internal dal_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR) { registro = db.CAT_RELACION_TRANSMISOR.Find(NID_RELACION_TRANSMISOR); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_RELACION_TRANSMISOR(Int32 NID_RELACION_TRANSMISOR, String V_RELACION_TRANSMISOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_RELACION_TRANSMISOR()
            {
                NID_RELACION_TRANSMISOR = NID_RELACION_TRANSMISOR,
                V_RELACION_TRANSMISOR = V_RELACION_TRANSMISOR,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_RELACION_TRANSMISOR registroCheck = db.CAT_RELACION_TRANSMISOR.Find(NID_RELACION_TRANSMISOR);
                if (registroCheck == null)
                {
                    db.CAT_RELACION_TRANSMISOR.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_RELACION_TRANSMISOR));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_RELACION_TRANSMISOR = registro.V_RELACION_TRANSMISOR;
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
            db.CAT_RELACION_TRANSMISOR.Remove(registro);
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
