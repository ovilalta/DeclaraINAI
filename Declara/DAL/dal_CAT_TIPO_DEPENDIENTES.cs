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
    internal class dal_CAT_TIPO_DEPENDIENTES : _dal_base_Declara
    {

        CAT_TIPO_DEPENDIENTES registro;

     #region *** Atributos ***

        internal Int32 NID_TIPO_DEPENDIENTE => registro.NID_TIPO_DEPENDIENTE; 

        internal String V_TIPO_DEPENDIENTE
        {
          get => registro.V_TIPO_DEPENDIENTE; 
          set => registro.V_TIPO_DEPENDIENTE = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPO_DEPENDIENTES() => registro = new CAT_TIPO_DEPENDIENTES();

        internal dal_CAT_TIPO_DEPENDIENTES(CAT_TIPO_DEPENDIENTES oCAT_TIPO_DEPENDIENTES) : this(oCAT_TIPO_DEPENDIENTES.NID_TIPO_DEPENDIENTE) { }

        internal dal_CAT_TIPO_DEPENDIENTES(Int32 NID_TIPO_DEPENDIENTE) { registro = db.CAT_TIPO_DEPENDIENTES.Find(NID_TIPO_DEPENDIENTE); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPO_DEPENDIENTES(Int32 NID_TIPO_DEPENDIENTE, String V_TIPO_DEPENDIENTE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPO_DEPENDIENTES()
               {
                 NID_TIPO_DEPENDIENTE = NID_TIPO_DEPENDIENTE,
                 V_TIPO_DEPENDIENTE = V_TIPO_DEPENDIENTE,
               };
            try
            {
                CAT_TIPO_DEPENDIENTES registroCheck = db.CAT_TIPO_DEPENDIENTES.Find(NID_TIPO_DEPENDIENTE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPO_DEPENDIENTES",NID_TIPO_DEPENDIENTE.ToString() + ", " );
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
                            db.CAT_TIPO_DEPENDIENTES.Attach(registro);
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
            db.CAT_TIPO_DEPENDIENTES.Add(registro);
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
            db.CAT_TIPO_DEPENDIENTES.Remove(registro);
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
