using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_ESTADO_ESCOLARIDAD : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_ESTADO_ESCOLARIDAD registro { get; set; }
        internal Int32 NID_ESTADO_ESCOLARIDAD => registro.NID_ESTADO_ESCOLARIDAD;
        internal String V_ESTADO_ESCOLARIDAD
        {
            get => registro.V_ESTADO_ESCOLARIDAD;
            set => registro.V_ESTADO_ESCOLARIDAD = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_ESTADO_ESCOLARIDAD() => registro = new CAT_ESTADO_ESCOLARIDAD();
        internal dal_CAT_ESTADO_ESCOLARIDAD(CAT_ESTADO_ESCOLARIDAD oCAT_ESTADO_ESCOLARIDAD) : this(oCAT_ESTADO_ESCOLARIDAD.NID_ESTADO_ESCOLARIDAD) { }
        internal dal_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD) { registro = db.CAT_ESTADO_ESCOLARIDAD.Find(NID_ESTADO_ESCOLARIDAD); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_ESTADO_ESCOLARIDAD(Int32 NID_ESTADO_ESCOLARIDAD, String V_ESTADO_ESCOLARIDAD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_ESTADO_ESCOLARIDAD()
            {
                NID_ESTADO_ESCOLARIDAD = NID_ESTADO_ESCOLARIDAD,
                V_ESTADO_ESCOLARIDAD = V_ESTADO_ESCOLARIDAD,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_ESTADO_ESCOLARIDAD registroCheck = db.CAT_ESTADO_ESCOLARIDAD.Find(NID_ESTADO_ESCOLARIDAD);
                if (registroCheck == null)
                {
                    db.CAT_ESTADO_ESCOLARIDAD.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_ESTADO_ESCOLARIDAD));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_ESTADO_ESCOLARIDAD = registro.V_ESTADO_ESCOLARIDAD;
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
            db.CAT_ESTADO_ESCOLARIDAD.Remove(registro);
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
