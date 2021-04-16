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
    internal class dal_CAT_TIPO_DOMICILIO : _dal_base_Declara
    {

        CAT_TIPO_DOMICILIO registro;

     #region *** Atributos ***

        internal Int32 NID_TIPO_DOMICILIO => registro.NID_TIPO_DOMICILIO; 

        internal String V_TIPO_DOMICILIO
        {
          get => registro.V_TIPO_DOMICILIO; 
          set => registro.V_TIPO_DOMICILIO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPO_DOMICILIO() => registro = new CAT_TIPO_DOMICILIO();

        internal dal_CAT_TIPO_DOMICILIO(CAT_TIPO_DOMICILIO oCAT_TIPO_DOMICILIO) : this(oCAT_TIPO_DOMICILIO.NID_TIPO_DOMICILIO) { }

        internal dal_CAT_TIPO_DOMICILIO(Int32 NID_TIPO_DOMICILIO) { registro = db.CAT_TIPO_DOMICILIO.Find(NID_TIPO_DOMICILIO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPO_DOMICILIO(Int32 NID_TIPO_DOMICILIO, String V_TIPO_DOMICILIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPO_DOMICILIO()
               {
                 NID_TIPO_DOMICILIO = NID_TIPO_DOMICILIO,
                 V_TIPO_DOMICILIO = V_TIPO_DOMICILIO,
               };
            try
            {
                CAT_TIPO_DOMICILIO registroCheck = db.CAT_TIPO_DOMICILIO.Find(NID_TIPO_DOMICILIO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPO_DOMICILIO",NID_TIPO_DOMICILIO.ToString() + ", " );
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
                            db.CAT_TIPO_DOMICILIO.Attach(registro);
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
            db.CAT_TIPO_DOMICILIO.Add(registro);
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
            db.CAT_TIPO_DOMICILIO.Remove(registro);
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
