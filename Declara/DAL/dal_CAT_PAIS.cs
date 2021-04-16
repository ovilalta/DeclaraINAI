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
    internal class dal_CAT_PAIS : _dal_base_Declara
    {

        CAT_PAIS registro;

     #region *** Atributos ***

        internal Int32 NID_PAIS => registro.NID_PAIS; 

        internal String V_PAIS
        {
          get => registro.V_PAIS; 
          set => registro.V_PAIS = value; 
        }

        internal String V_NACIONALIDAD_M
        {
          get => registro.V_NACIONALIDAD_M; 
          set => registro.V_NACIONALIDAD_M = value; 
        }

        internal String V_NACIONALIDAD_F
        {
          get => registro.V_NACIONALIDAD_F; 
          set => registro.V_NACIONALIDAD_F = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_PAIS() => registro = new CAT_PAIS();

        internal dal_CAT_PAIS(CAT_PAIS oCAT_PAIS) : this(oCAT_PAIS.NID_PAIS) { }

        internal dal_CAT_PAIS(Int32 NID_PAIS) { registro = db.CAT_PAIS.Find(NID_PAIS); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_PAIS(Int32 NID_PAIS, String V_PAIS, String V_NACIONALIDAD_M, String V_NACIONALIDAD_F, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_PAIS()
               {
                 NID_PAIS = NID_PAIS,
                 V_PAIS = V_PAIS,
                 V_NACIONALIDAD_M = V_NACIONALIDAD_M,
                 V_NACIONALIDAD_F = V_NACIONALIDAD_F,
               };
            try
            {
                CAT_PAIS registroCheck = db.CAT_PAIS.Find(NID_PAIS);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_PAIS",NID_PAIS.ToString() + ", " );
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
                            db.CAT_PAIS.Attach(registro);
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
            db.CAT_PAIS.Add(registro);
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
            db.CAT_PAIS.Remove(registro);
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
