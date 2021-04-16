using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_DOCUMENTO_OBTENIDO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_DOCUMENTO_OBTENIDO registro { get; set; }
        internal Int32 NID_DOCUMENTO_OBTENIDO => registro.NID_DOCUMENTO_OBTENIDO;
        internal String V_DOCUMENTO_OBTENIDO
        {
            get => registro.V_DOCUMENTO_OBTENIDO;
            set => registro.V_DOCUMENTO_OBTENIDO = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_DOCUMENTO_OBTENIDO() => registro = new CAT_DOCUMENTO_OBTENIDO();
        internal dal_CAT_DOCUMENTO_OBTENIDO(CAT_DOCUMENTO_OBTENIDO oCAT_DOCUMENTO_OBTENIDO) : this(oCAT_DOCUMENTO_OBTENIDO.NID_DOCUMENTO_OBTENIDO) { }
        internal dal_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO) { registro = db.CAT_DOCUMENTO_OBTENIDO.Find(NID_DOCUMENTO_OBTENIDO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_DOCUMENTO_OBTENIDO(Int32 NID_DOCUMENTO_OBTENIDO, String V_DOCUMENTO_OBTENIDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_DOCUMENTO_OBTENIDO()
            {
                NID_DOCUMENTO_OBTENIDO = NID_DOCUMENTO_OBTENIDO,
                V_DOCUMENTO_OBTENIDO = V_DOCUMENTO_OBTENIDO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_DOCUMENTO_OBTENIDO registroCheck = db.CAT_DOCUMENTO_OBTENIDO.Find(NID_DOCUMENTO_OBTENIDO);
                if (registroCheck == null)
                {
                    db.CAT_DOCUMENTO_OBTENIDO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_DOCUMENTO_OBTENIDO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_DOCUMENTO_OBTENIDO = registro.V_DOCUMENTO_OBTENIDO;
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
            db.CAT_DOCUMENTO_OBTENIDO.Remove(registro);
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
