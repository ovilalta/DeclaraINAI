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
    internal class dal_CAT_ESTADO_CIVIL : _dal_base_Declara
    {

        CAT_ESTADO_CIVIL registro;

     #region *** Atributos ***

        internal Int32 NID_ESTADO_CIVIL => registro.NID_ESTADO_CIVIL; 

        internal String V_ESTADO_CIVIL
        {
          get => registro.V_ESTADO_CIVIL; 
          set => registro.V_ESTADO_CIVIL = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_ESTADO_CIVIL() => registro = new CAT_ESTADO_CIVIL();

        internal dal_CAT_ESTADO_CIVIL(CAT_ESTADO_CIVIL oCAT_ESTADO_CIVIL) : this(oCAT_ESTADO_CIVIL.NID_ESTADO_CIVIL) { }

        internal dal_CAT_ESTADO_CIVIL(Int32 NID_ESTADO_CIVIL) { registro = db.CAT_ESTADO_CIVIL.Find(NID_ESTADO_CIVIL); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_ESTADO_CIVIL(Int32 NID_ESTADO_CIVIL, String V_ESTADO_CIVIL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_ESTADO_CIVIL()
               {
                 NID_ESTADO_CIVIL = NID_ESTADO_CIVIL,
                 V_ESTADO_CIVIL = V_ESTADO_CIVIL,
               };
            try
            {
                CAT_ESTADO_CIVIL registroCheck = db.CAT_ESTADO_CIVIL.Find(NID_ESTADO_CIVIL);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_ESTADO_CIVIL",NID_ESTADO_CIVIL.ToString() + ", " );
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
                            db.CAT_ESTADO_CIVIL.Attach(registro);
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
            db.CAT_ESTADO_CIVIL.Add(registro);
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
            db.CAT_ESTADO_CIVIL.Remove(registro);
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
