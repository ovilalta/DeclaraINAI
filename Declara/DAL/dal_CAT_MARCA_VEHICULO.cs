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
    internal class dal_CAT_MARCA_VEHICULO : _dal_base_Declara
    {

        CAT_MARCA_VEHICULO registro;

     #region *** Atributos ***

        internal Int32 NID_MARCA => registro.NID_MARCA; 

        internal String V_MARCA
        {
          get => registro.V_MARCA; 
          set => registro.V_MARCA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_MARCA_VEHICULO() => registro = new CAT_MARCA_VEHICULO();

        internal dal_CAT_MARCA_VEHICULO(CAT_MARCA_VEHICULO oCAT_MARCA_VEHICULO) : this(oCAT_MARCA_VEHICULO.NID_MARCA) { }

        internal dal_CAT_MARCA_VEHICULO(Int32 NID_MARCA) { registro = db.CAT_MARCA_VEHICULO.Find(NID_MARCA); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_MARCA_VEHICULO(Int32 NID_MARCA, String V_MARCA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_MARCA_VEHICULO()
               {
                 NID_MARCA = NID_MARCA,
                 V_MARCA = V_MARCA,
               };
            try
            {
                CAT_MARCA_VEHICULO registroCheck = db.CAT_MARCA_VEHICULO.Find(NID_MARCA);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_MARCA_VEHICULO",NID_MARCA.ToString() + ", " );
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
                            db.CAT_MARCA_VEHICULO.Attach(registro);
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
            db.CAT_MARCA_VEHICULO.Add(registro);
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
            db.CAT_MARCA_VEHICULO.Remove(registro);
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
