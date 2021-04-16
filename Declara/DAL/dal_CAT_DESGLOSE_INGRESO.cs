using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_DESGLOSE_INGRESO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_DESGLOSE_INGRESO registro { get; set; }
        internal Int32 NID_INGRESO_SUPERIOR => registro.NID_INGRESO_SUPERIOR;
        internal Int32 NID_INGRESO => registro.NID_INGRESO;
        internal String V_INGRESO
        {
            get => registro.V_INGRESO;
            set => registro.V_INGRESO = value;
        }
        internal Boolean L_VIGENTE
        {
            get => registro.L_VIGENTE;
            set => registro.L_VIGENTE = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_DESGLOSE_INGRESO() => registro = new CAT_DESGLOSE_INGRESO();
        internal dal_CAT_DESGLOSE_INGRESO(CAT_DESGLOSE_INGRESO oCAT_DESGLOSE_INGRESO) : this(oCAT_DESGLOSE_INGRESO.NID_INGRESO_SUPERIOR, oCAT_DESGLOSE_INGRESO.NID_INGRESO) { }
        internal dal_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO) { registro = db.CAT_DESGLOSE_INGRESO.Find(NID_INGRESO_SUPERIOR, NID_INGRESO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_DESGLOSE_INGRESO(Int32 NID_INGRESO_SUPERIOR, Int32 NID_INGRESO, String V_INGRESO, Boolean L_VIGENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_DESGLOSE_INGRESO()
            {
                NID_INGRESO_SUPERIOR = NID_INGRESO_SUPERIOR,
                NID_INGRESO = NID_INGRESO,
                V_INGRESO = V_INGRESO,
                L_VIGENTE = L_VIGENTE,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_DESGLOSE_INGRESO registroCheck = db.CAT_DESGLOSE_INGRESO.Find(NID_INGRESO_SUPERIOR, NID_INGRESO);
                if (registroCheck == null)
                {
                    db.CAT_DESGLOSE_INGRESO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_INGRESO_SUPERIOR, ", ", NID_INGRESO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_INGRESO = registro.V_INGRESO;
                            registroCheck.L_VIGENTE = registro.L_VIGENTE;
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
            db.CAT_DESGLOSE_INGRESO.Remove(registro);
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
