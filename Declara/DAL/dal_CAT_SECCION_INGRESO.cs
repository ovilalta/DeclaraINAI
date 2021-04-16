using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_SECCION_INGRESO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected CAT_SECCION_INGRESO registro { get; set; }
        internal Int32 NID_SECCION => registro.NID_SECCION;
        internal Int32 NID_RUBRO => registro.NID_RUBRO;
        internal String V_RUBRO
        {
            get => registro.V_RUBRO;
            set => registro.V_RUBRO = value;
        }
        internal Boolean L_VIGENTE
        {
            get => registro.L_VIGENTE;
            set => registro.L_VIGENTE = value;
        }
        internal String CID_TIPO
        {
            get => registro.CID_TIPO;
            set => registro.CID_TIPO = value;
        }
        internal Int32 NID_RUBRO_SUMA
        {
            get => registro.NID_RUBRO_SUMA;
            set => registro.NID_RUBRO_SUMA = value;
        }
        internal String C_TITULAR
        {
            get => registro.C_TITULAR;
            set => registro.C_TITULAR = value;
        }
        internal String V_CATALOGO
        {
            get => registro.V_CATALOGO;
            set => registro.V_CATALOGO = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_CAT_SECCION_INGRESO() => registro = new CAT_SECCION_INGRESO();
        internal dal_CAT_SECCION_INGRESO(CAT_SECCION_INGRESO oCAT_SECCION_INGRESO) : this(oCAT_SECCION_INGRESO.NID_SECCION, oCAT_SECCION_INGRESO.NID_RUBRO) { }
        internal dal_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO) { registro = db.CAT_SECCION_INGRESO.Find(NID_SECCION, NID_RUBRO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_CAT_SECCION_INGRESO(Int32 NID_SECCION, Int32 NID_RUBRO, String V_RUBRO, Boolean L_VIGENTE, String CID_TIPO, Int32 NID_RUBRO_SUMA, String C_TITULAR, String V_CATALOGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_SECCION_INGRESO()
            {
                NID_SECCION = NID_SECCION,
                NID_RUBRO = NID_RUBRO,
                V_RUBRO = V_RUBRO,
                L_VIGENTE = L_VIGENTE,
                CID_TIPO = CID_TIPO,
                NID_RUBRO_SUMA = NID_RUBRO_SUMA,
                C_TITULAR = C_TITULAR,
                V_CATALOGO = V_CATALOGO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                CAT_SECCION_INGRESO registroCheck = db.CAT_SECCION_INGRESO.Find(NID_SECCION, NID_RUBRO);
                if (registroCheck == null)
                {
                    db.CAT_SECCION_INGRESO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(NID_SECCION, ", ", NID_RUBRO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_RUBRO = registro.V_RUBRO;
                            registroCheck.L_VIGENTE = registro.L_VIGENTE;
                            registroCheck.CID_TIPO = registro.CID_TIPO;
                            registroCheck.NID_RUBRO_SUMA = registro.NID_RUBRO_SUMA;
                            registroCheck.C_TITULAR = registro.C_TITULAR;
                            registroCheck.V_CATALOGO = registro.V_CATALOGO;
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
            db.CAT_SECCION_INGRESO.Remove(registro);
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
