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
    internal class dal_CAT_TIPO_INVERSION : _dal_base_Declara
    {

        CAT_TIPO_INVERSION registro;

     #region *** Atributos ***

        internal Int32 NID_TIPO_INVERSION => registro.NID_TIPO_INVERSION; 

        internal String V_TIPO_INVERSION
        {
          get => registro.V_TIPO_INVERSION; 
          set => registro.V_TIPO_INVERSION = value; 
        }

        internal Boolean L_ACTIVO
        {
          get => registro.L_ACTIVO; 
          set => registro.L_ACTIVO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPO_INVERSION() => registro = new CAT_TIPO_INVERSION();

        internal dal_CAT_TIPO_INVERSION(CAT_TIPO_INVERSION oCAT_TIPO_INVERSION) : this(oCAT_TIPO_INVERSION.NID_TIPO_INVERSION) { }

        internal dal_CAT_TIPO_INVERSION(Int32 NID_TIPO_INVERSION) { registro = db.CAT_TIPO_INVERSION.Find(NID_TIPO_INVERSION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPO_INVERSION(Int32 NID_TIPO_INVERSION, String V_TIPO_INVERSION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPO_INVERSION()
               {
                 NID_TIPO_INVERSION = NID_TIPO_INVERSION,
                 V_TIPO_INVERSION = V_TIPO_INVERSION,
                 L_ACTIVO = L_ACTIVO,
               };
            try
            {
                CAT_TIPO_INVERSION registroCheck = db.CAT_TIPO_INVERSION.Find(NID_TIPO_INVERSION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPO_INVERSION",NID_TIPO_INVERSION.ToString() + ", " );
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
                            db.CAT_TIPO_INVERSION.Attach(registro);
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
            db.CAT_TIPO_INVERSION.Add(registro);
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
            db.CAT_TIPO_INVERSION.Remove(registro);
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
