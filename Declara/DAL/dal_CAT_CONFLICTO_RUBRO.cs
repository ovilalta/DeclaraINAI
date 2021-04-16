using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_CAT_CONFLICTO_RUBRO : _dal_base_Declara
    {

        CAT_CONFLICTO_RUBRO registro;

     #region *** Atributos ***

        internal Int32 NID_RUBRO => registro.NID_RUBRO; 

        internal String V_RUBRO
        {
          get => registro.V_RUBRO; 
          set => registro.V_RUBRO = value; 
        }

        internal String C_INICIO
        {
          get => registro.C_INICIO; 
          set => registro.C_INICIO = value; 
        }

        internal String C_FIN
        {
          get => registro.C_FIN; 
          set => registro.C_FIN = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_CONFLICTO_RUBRO() => registro = new CAT_CONFLICTO_RUBRO();

        internal dal_CAT_CONFLICTO_RUBRO(CAT_CONFLICTO_RUBRO oCAT_CONFLICTO_RUBRO) : this(oCAT_CONFLICTO_RUBRO.NID_RUBRO) { }

        internal dal_CAT_CONFLICTO_RUBRO(Int32 NID_RUBRO) { registro = db.CAT_CONFLICTO_RUBRO.Find(NID_RUBRO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_CONFLICTO_RUBRO(Int32 NID_RUBRO, String V_RUBRO, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_CONFLICTO_RUBRO()
               {
                 NID_RUBRO = NID_RUBRO,
                 V_RUBRO = V_RUBRO,
                 C_INICIO = C_INICIO,
                 C_FIN = C_FIN,
               };
            try
            {
                CAT_CONFLICTO_RUBRO registroCheck = db.CAT_CONFLICTO_RUBRO.Find(NID_RUBRO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_CONFLICTO_RUBRO",NID_RUBRO.ToString() + ", " );
                        break;

                    //Usar registro existente
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting:
                        if (registroCheck == null) insert();
                        else registro = registroCheck;
                        break;

                    //Actualizar registro existente
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting:
                        if (registroCheck == null) insert();
                        else
                        {
                            db.CAT_CONFLICTO_RUBRO.Attach(registro);
                            ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(registro, EntityState.Modified);
                            update();
                        }
                        break;

                   //Opcion no Implementada
                    default:
                        throw new NotImplementedException();
                }
            }
              catch (Exception ex)
               {
                   registro = null;
                    throw ex;
               }
        }


     #endregion


     #region *** Metodos ***

        internal void insert()
        {
            db.CAT_CONFLICTO_RUBRO.Add(registro);
            SaveChanges(true);
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
            db.CAT_CONFLICTO_RUBRO.Remove(registro);
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
