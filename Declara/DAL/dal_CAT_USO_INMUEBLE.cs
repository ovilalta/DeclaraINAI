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
    internal class dal_CAT_USO_INMUEBLE : _dal_base_Declara
    {

        CAT_USO_INMUEBLE registro;

     #region *** Atributos ***

        internal Int32 NID_USO => registro.NID_USO; 

        internal String V_USO
        {
          get => registro.V_USO; 
          set => registro.V_USO = value; 
        }

        internal Boolean L_ACTIVO
        {
          get => registro.L_ACTIVO; 
          set => registro.L_ACTIVO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_USO_INMUEBLE() => registro = new CAT_USO_INMUEBLE();

        internal dal_CAT_USO_INMUEBLE(CAT_USO_INMUEBLE oCAT_USO_INMUEBLE) : this(oCAT_USO_INMUEBLE.NID_USO) { }

        internal dal_CAT_USO_INMUEBLE(Int32 NID_USO) { registro = db.CAT_USO_INMUEBLE.Find(NID_USO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_USO_INMUEBLE(Int32 NID_USO, String V_USO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_USO_INMUEBLE()
               {
                 NID_USO = NID_USO,
                 V_USO = V_USO,
                 L_ACTIVO = L_ACTIVO,
               };
            try
            {
                CAT_USO_INMUEBLE registroCheck = db.CAT_USO_INMUEBLE.Find(NID_USO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_USO_INMUEBLE",NID_USO.ToString() + ", " );
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
                            db.CAT_USO_INMUEBLE.Attach(registro);
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
            db.CAT_USO_INMUEBLE.Add(registro);
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
            db.CAT_USO_INMUEBLE.Remove(registro);
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
