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
    internal class dal_CAT_DENOMINACION : _dal_base_Declara
    {

        CAT_DENOMINACION registro;

     #region *** Atributos ***

        internal Int32 NID_DENOMINACION => registro.NID_DENOMINACION; 

        internal String V_DENOMINACION
        {
          get => registro.V_DENOMINACION; 
          set => registro.V_DENOMINACION = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_DENOMINACION() => registro = new CAT_DENOMINACION();

        internal dal_CAT_DENOMINACION(CAT_DENOMINACION oCAT_DENOMINACION) : this(oCAT_DENOMINACION.NID_DENOMINACION) { }

        internal dal_CAT_DENOMINACION(Int32 NID_DENOMINACION) { registro = db.CAT_DENOMINACION.Find(NID_DENOMINACION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_DENOMINACION(Int32 NID_DENOMINACION, String V_DENOMINACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_DENOMINACION()
               {
                 NID_DENOMINACION = NID_DENOMINACION,
                 V_DENOMINACION = V_DENOMINACION,
               };
            try
            {
                CAT_DENOMINACION registroCheck = db.CAT_DENOMINACION.Find(NID_DENOMINACION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_DENOMINACION",NID_DENOMINACION.ToString() + ", " );
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
                            db.CAT_DENOMINACION.Attach(registro);
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
            db.CAT_DENOMINACION.Add(registro);
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
            db.CAT_DENOMINACION.Remove(registro);
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
