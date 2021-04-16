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
    internal class dal_CAT_TIPO_VEHICULO : _dal_base_Declara
    {

        CAT_TIPO_VEHICULO registro;

     #region *** Atributos ***

        internal Int32 NID_TIPO_VEHICULO => registro.NID_TIPO_VEHICULO; 

        internal String V_TIPO_VEHICULO
        {
          get => registro.V_TIPO_VEHICULO; 
          set => registro.V_TIPO_VEHICULO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPO_VEHICULO() => registro = new CAT_TIPO_VEHICULO();

        internal dal_CAT_TIPO_VEHICULO(CAT_TIPO_VEHICULO oCAT_TIPO_VEHICULO) : this(oCAT_TIPO_VEHICULO.NID_TIPO_VEHICULO) { }

        internal dal_CAT_TIPO_VEHICULO(Int32 NID_TIPO_VEHICULO) { registro = db.CAT_TIPO_VEHICULO.Find(NID_TIPO_VEHICULO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPO_VEHICULO(Int32 NID_TIPO_VEHICULO, String V_TIPO_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPO_VEHICULO()
               {
                 NID_TIPO_VEHICULO = NID_TIPO_VEHICULO,
                 V_TIPO_VEHICULO = V_TIPO_VEHICULO,
               };
            try
            {
                CAT_TIPO_VEHICULO registroCheck = db.CAT_TIPO_VEHICULO.Find(NID_TIPO_VEHICULO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPO_VEHICULO",NID_TIPO_VEHICULO.ToString() + ", " );
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
                            db.CAT_TIPO_VEHICULO.Attach(registro);
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
            db.CAT_TIPO_VEHICULO.Add(registro);
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
            db.CAT_TIPO_VEHICULO.Remove(registro);
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
