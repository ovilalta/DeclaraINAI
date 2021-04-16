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
    internal class dal_CAT_TIPO_DECLARACION : _dal_base_Declara
    {

        CAT_TIPO_DECLARACION registro;

     #region *** Atributos ***

        internal Int32 NID_TIPO_DECLARACION => registro.NID_TIPO_DECLARACION; 

        internal String V_TIPO_DECLARACION
        {
          get => registro.V_TIPO_DECLARACION; 
          set => registro.V_TIPO_DECLARACION = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPO_DECLARACION() => registro = new CAT_TIPO_DECLARACION();

        internal dal_CAT_TIPO_DECLARACION(CAT_TIPO_DECLARACION oCAT_TIPO_DECLARACION) : this(oCAT_TIPO_DECLARACION.NID_TIPO_DECLARACION) { }

        internal dal_CAT_TIPO_DECLARACION(Int32 NID_TIPO_DECLARACION) { registro = db.CAT_TIPO_DECLARACION.Find(NID_TIPO_DECLARACION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPO_DECLARACION(Int32 NID_TIPO_DECLARACION, String V_TIPO_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPO_DECLARACION()
               {
                 NID_TIPO_DECLARACION = NID_TIPO_DECLARACION,
                 V_TIPO_DECLARACION = V_TIPO_DECLARACION,
               };
            try
            {
                CAT_TIPO_DECLARACION registroCheck = db.CAT_TIPO_DECLARACION.Find(NID_TIPO_DECLARACION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPO_DECLARACION",NID_TIPO_DECLARACION.ToString() + ", " );
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
                            db.CAT_TIPO_DECLARACION.Attach(registro);
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
            db.CAT_TIPO_DECLARACION.Add(registro);
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
            db.CAT_TIPO_DECLARACION.Remove(registro);
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
