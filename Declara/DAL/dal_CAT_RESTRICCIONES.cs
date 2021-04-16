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
    internal class dal_CAT_RESTRICCIONES : _dal_base_Declara
    {

        CAT_RESTRICCIONES registro;

     #region *** Atributos ***

        internal Int32 NID_RESTRICCION => registro.NID_RESTRICCION; 

        internal String V_RESTRICCION
        {
          get => registro.V_RESTRICCION; 
          set => registro.V_RESTRICCION = value; 
        }

        internal Boolean L_VIGENTE
        {
          get => registro.L_VIGENTE; 
          set => registro.L_VIGENTE = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_RESTRICCIONES() => registro = new CAT_RESTRICCIONES();

        internal dal_CAT_RESTRICCIONES(CAT_RESTRICCIONES oCAT_RESTRICCIONES) : this(oCAT_RESTRICCIONES.NID_RESTRICCION) { }

        internal dal_CAT_RESTRICCIONES(Int32 NID_RESTRICCION) { registro = db.CAT_RESTRICCIONES.Find(NID_RESTRICCION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_RESTRICCIONES(Int32 NID_RESTRICCION, String V_RESTRICCION, Boolean L_VIGENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_RESTRICCIONES()
               {
                 NID_RESTRICCION = NID_RESTRICCION,
                 V_RESTRICCION = V_RESTRICCION,
                 L_VIGENTE = L_VIGENTE,
               };
            try
            {
                CAT_RESTRICCIONES registroCheck = db.CAT_RESTRICCIONES.Find(NID_RESTRICCION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_RESTRICCIONES",NID_RESTRICCION.ToString() + ", " );
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
                            db.CAT_RESTRICCIONES.Attach(registro);
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
            db.CAT_RESTRICCIONES.Add(registro);
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
            db.CAT_RESTRICCIONES.Remove(registro);
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
