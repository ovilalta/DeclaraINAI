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
    internal class dal_CAT_APARTADO : _dal_base_Declara
    {

        CAT_APARTADO registro;

     #region *** Atributos ***

        internal Int32 NID_APARTADO => registro.NID_APARTADO; 

        internal String V_APARTADO
        {
          get => registro.V_APARTADO; 
          set => registro.V_APARTADO = value; 
        }

        internal System.Nullable<Int32> NID_APARTADO_SUPERIOR
        {
          get => registro.NID_APARTADO_SUPERIOR; 
          set => registro.NID_APARTADO_SUPERIOR = value; 
        }

        internal System.Nullable<Int32> N_APARTADO
        {
          get => registro.N_APARTADO; 
          set => registro.N_APARTADO = value; 
        }

        internal Int32 NID_TIPO_DECLARACION
        {
          get => registro.NID_TIPO_DECLARACION; 
          set => registro.NID_TIPO_DECLARACION = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_APARTADO() => registro = new CAT_APARTADO();

        internal dal_CAT_APARTADO(CAT_APARTADO oCAT_APARTADO) : this(oCAT_APARTADO.NID_APARTADO) { }

        internal dal_CAT_APARTADO(Int32 NID_APARTADO) { registro = db.CAT_APARTADO.Find(NID_APARTADO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_APARTADO(Int32 NID_APARTADO, String V_APARTADO, System.Nullable<Int32> NID_APARTADO_SUPERIOR, System.Nullable<Int32> N_APARTADO, Int32 NID_TIPO_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_APARTADO()
               {
                 NID_APARTADO = NID_APARTADO,
                 V_APARTADO = V_APARTADO,
                 NID_APARTADO_SUPERIOR = NID_APARTADO_SUPERIOR,
                 N_APARTADO = N_APARTADO,
                 NID_TIPO_DECLARACION = NID_TIPO_DECLARACION,
               };
            try
            {
                CAT_APARTADO registroCheck = db.CAT_APARTADO.Find(NID_APARTADO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_APARTADO",NID_APARTADO.ToString() + ", " );
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
                            db.CAT_APARTADO.Attach(registro);
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
            db.CAT_APARTADO.Add(registro);
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
            db.CAT_APARTADO.Remove(registro);
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
