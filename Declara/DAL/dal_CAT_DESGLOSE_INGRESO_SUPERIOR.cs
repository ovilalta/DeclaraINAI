using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_DESGLOSE_INGRESO_SUPERIOR : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_DESGLOSE_INGRESO_SUPERIOR registro { get; set; }
        internal Int32 NID_INGRESO_SUPERIOR => registro.NID_INGRESO_SUPERIOR;
        internal String V_INGRESO_SUPERIOR
        {
            get => registro.V_INGRESO_SUPERIOR;
            set => registro.V_INGRESO_SUPERIOR = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_DESGLOSE_INGRESO_SUPERIOR() => registro = new CAT_DESGLOSE_INGRESO_SUPERIOR();
        internal dal_CAT_DESGLOSE_INGRESO_SUPERIOR(CAT_DESGLOSE_INGRESO_SUPERIOR oCAT_DESGLOSE_INGRESO_SUPERIOR) : this(oCAT_DESGLOSE_INGRESO_SUPERIOR.NID_INGRESO_SUPERIOR) { }
        internal dal_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR) { registro = db.CAT_DESGLOSE_INGRESO_SUPERIOR.Find(NID_INGRESO_SUPERIOR); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_DESGLOSE_INGRESO_SUPERIOR(Int32 NID_INGRESO_SUPERIOR, String V_INGRESO_SUPERIOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_DESGLOSE_INGRESO_SUPERIOR()
            {
                NID_INGRESO_SUPERIOR = NID_INGRESO_SUPERIOR,
                V_INGRESO_SUPERIOR = V_INGRESO_SUPERIOR,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_DESGLOSE_INGRESO_SUPERIOR registroCheck = db.CAT_DESGLOSE_INGRESO_SUPERIOR.Find(NID_INGRESO_SUPERIOR);
                if (registroCheck == null)
                {
                    db.CAT_DESGLOSE_INGRESO_SUPERIOR.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_INGRESO_SUPERIOR));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_INGRESO_SUPERIOR = registro.V_INGRESO_SUPERIOR;
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
            db.CAT_DESGLOSE_INGRESO_SUPERIOR.Remove(registro);
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
