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
    internal class dal_CAT_ESTADO_DECLARACION : _dal_base_Declara
    {

        CAT_ESTADO_DECLARACION registro;

     #region *** Atributos ***

        internal Int32 NID_ESTADO => registro.NID_ESTADO; 

        internal String V_ESTADO
        {
          get => registro.V_ESTADO; 
          set => registro.V_ESTADO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_ESTADO_DECLARACION() => registro = new CAT_ESTADO_DECLARACION();

        internal dal_CAT_ESTADO_DECLARACION(CAT_ESTADO_DECLARACION oCAT_ESTADO_DECLARACION) : this(oCAT_ESTADO_DECLARACION.NID_ESTADO) { }

        internal dal_CAT_ESTADO_DECLARACION(Int32 NID_ESTADO) { registro = db.CAT_ESTADO_DECLARACION.Find(NID_ESTADO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_ESTADO_DECLARACION(Int32 NID_ESTADO, String V_ESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_ESTADO_DECLARACION()
               {
                 NID_ESTADO = NID_ESTADO,
                 V_ESTADO = V_ESTADO,
               };
            try
            {
                CAT_ESTADO_DECLARACION registroCheck = db.CAT_ESTADO_DECLARACION.Find(NID_ESTADO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_ESTADO_DECLARACION",NID_ESTADO.ToString() + ", " );
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
                            db.CAT_ESTADO_DECLARACION.Attach(registro);
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
            db.CAT_ESTADO_DECLARACION.Add(registro);
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
            db.CAT_ESTADO_DECLARACION.Remove(registro);
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
