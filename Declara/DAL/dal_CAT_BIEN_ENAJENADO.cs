using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_BIEN_ENAJENADO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_BIEN_ENAJENADO registro { get; set; }
        internal Int32 NID_BIEN_ENAJENADO => registro.NID_BIEN_ENAJENADO;
        internal String V_BIEN_ENAJENADO
        {
            get => registro.V_BIEN_ENAJENADO;
            set => registro.V_BIEN_ENAJENADO = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_BIEN_ENAJENADO() => registro = new CAT_BIEN_ENAJENADO();
        internal dal_CAT_BIEN_ENAJENADO(CAT_BIEN_ENAJENADO oCAT_BIEN_ENAJENADO) : this(oCAT_BIEN_ENAJENADO.NID_BIEN_ENAJENADO) { }
        internal dal_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO) { registro = db.CAT_BIEN_ENAJENADO.Find(NID_BIEN_ENAJENADO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_BIEN_ENAJENADO(Int32 NID_BIEN_ENAJENADO, String V_BIEN_ENAJENADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_BIEN_ENAJENADO()
            {
                NID_BIEN_ENAJENADO = NID_BIEN_ENAJENADO,
                V_BIEN_ENAJENADO = V_BIEN_ENAJENADO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_BIEN_ENAJENADO registroCheck = db.CAT_BIEN_ENAJENADO.Find(NID_BIEN_ENAJENADO);
                if (registroCheck == null)
                {
                    db.CAT_BIEN_ENAJENADO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_BIEN_ENAJENADO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_BIEN_ENAJENADO = registro.V_BIEN_ENAJENADO;
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
            db.CAT_BIEN_ENAJENADO.Remove(registro);
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
