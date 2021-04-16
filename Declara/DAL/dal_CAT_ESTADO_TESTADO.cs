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
    internal class dal_CAT_ESTADO_TESTADO : _dal_base_Declara
    {

        CAT_ESTADO_TESTADO registro;

     #region *** Atributos ***

        internal Int32 NID_ESTADO_TESTADO => registro.NID_ESTADO_TESTADO; 

        internal String V_ESTADO_TESTADO
        {
          get => registro.V_ESTADO_TESTADO; 
          set => registro.V_ESTADO_TESTADO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_ESTADO_TESTADO() => registro = new CAT_ESTADO_TESTADO();

        internal dal_CAT_ESTADO_TESTADO(CAT_ESTADO_TESTADO oCAT_ESTADO_TESTADO) : this(oCAT_ESTADO_TESTADO.NID_ESTADO_TESTADO) { }

        internal dal_CAT_ESTADO_TESTADO(Int32 NID_ESTADO_TESTADO) { registro = db.CAT_ESTADO_TESTADO.Find(NID_ESTADO_TESTADO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_ESTADO_TESTADO(Int32 NID_ESTADO_TESTADO, String V_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_ESTADO_TESTADO()
               {
                 NID_ESTADO_TESTADO = NID_ESTADO_TESTADO,
                 V_ESTADO_TESTADO = V_ESTADO_TESTADO,
               };
            try
            {
                CAT_ESTADO_TESTADO registroCheck = db.CAT_ESTADO_TESTADO.Find(NID_ESTADO_TESTADO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_ESTADO_TESTADO",NID_ESTADO_TESTADO.ToString() + ", " );
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
                            db.CAT_ESTADO_TESTADO.Attach(registro);
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
            db.CAT_ESTADO_TESTADO.Add(registro);
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
            db.CAT_ESTADO_TESTADO.Remove(registro);
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
