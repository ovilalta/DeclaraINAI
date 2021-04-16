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
    internal class dal_CAT_TIPS : _dal_base_Declara
    {

        CAT_TIPS registro;

     #region *** Atributos ***

        internal Int32 NID_TIP => registro.NID_TIP; 

        internal String V_TIP
        {
          get => registro.V_TIP; 
          set => registro.V_TIP = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPS() => registro = new CAT_TIPS();

        internal dal_CAT_TIPS(CAT_TIPS oCAT_TIPS) : this(oCAT_TIPS.NID_TIP) { }

        internal dal_CAT_TIPS(Int32 NID_TIP) { registro = db.CAT_TIPS.Find(NID_TIP); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPS(Int32 NID_TIP, String V_TIP, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPS()
               {
                 NID_TIP = NID_TIP,
                 V_TIP = V_TIP,
               };
            try
            {
                CAT_TIPS registroCheck = db.CAT_TIPS.Find(NID_TIP);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPS",NID_TIP.ToString() + ", " );
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
                            db.CAT_TIPS.Attach(registro);
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
            db.CAT_TIPS.Add(registro);
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
            db.CAT_TIPS.Remove(registro);
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
