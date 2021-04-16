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
    internal class dal_CAT_TIPO_BAJA : _dal_base_Declara
    {

        CAT_TIPO_BAJA registro;

     #region *** Atributos ***

        internal Int32 NID_TIPO_BAJA => registro.NID_TIPO_BAJA; 

        internal String V_TIPO_BAJA
        {
          get => registro.V_TIPO_BAJA; 
          set => registro.V_TIPO_BAJA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPO_BAJA() => registro = new CAT_TIPO_BAJA();

        internal dal_CAT_TIPO_BAJA(CAT_TIPO_BAJA oCAT_TIPO_BAJA) : this(oCAT_TIPO_BAJA.NID_TIPO_BAJA) { }

        internal dal_CAT_TIPO_BAJA(Int32 NID_TIPO_BAJA) { registro = db.CAT_TIPO_BAJA.Find(NID_TIPO_BAJA); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPO_BAJA(Int32 NID_TIPO_BAJA, String V_TIPO_BAJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPO_BAJA()
               {
                 NID_TIPO_BAJA = NID_TIPO_BAJA,
                 V_TIPO_BAJA = V_TIPO_BAJA,
               };
            try
            {
                CAT_TIPO_BAJA registroCheck = db.CAT_TIPO_BAJA.Find(NID_TIPO_BAJA);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPO_BAJA",NID_TIPO_BAJA.ToString() + ", " );
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
                            db.CAT_TIPO_BAJA.Attach(registro);
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
            db.CAT_TIPO_BAJA.Add(registro);
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
            db.CAT_TIPO_BAJA.Remove(registro);
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
