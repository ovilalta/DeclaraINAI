using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_AMBITO_PUBLICO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_AMBITO_PUBLICO registro { get; set; }
        internal Int32 NID_AMBITO_PUBLICO => registro.NID_AMBITO_PUBLICO;
        internal String V_AMBITO_PUBLICO
        {
            get => registro.V_AMBITO_PUBLICO;
            set => registro.V_AMBITO_PUBLICO = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_AMBITO_PUBLICO() => registro = new CAT_AMBITO_PUBLICO();
        internal dal_CAT_AMBITO_PUBLICO(CAT_AMBITO_PUBLICO oCAT_AMBITO_PUBLICO) : this(oCAT_AMBITO_PUBLICO.NID_AMBITO_PUBLICO) { }
        internal dal_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO) { registro = db.CAT_AMBITO_PUBLICO.Find(NID_AMBITO_PUBLICO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_AMBITO_PUBLICO(Int32 NID_AMBITO_PUBLICO, String V_AMBITO_PUBLICO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_AMBITO_PUBLICO()
            {
                NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO,
                V_AMBITO_PUBLICO = V_AMBITO_PUBLICO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_AMBITO_PUBLICO registroCheck = db.CAT_AMBITO_PUBLICO.Find(NID_AMBITO_PUBLICO);
                if (registroCheck == null)
                {
                    db.CAT_AMBITO_PUBLICO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_AMBITO_PUBLICO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_AMBITO_PUBLICO = registro.V_AMBITO_PUBLICO;
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
            db.CAT_AMBITO_PUBLICO.Remove(registro);
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
