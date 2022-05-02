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
    internal class dal_CAT_PUESTO : _dal_base_Declara
    {

        CAT_PUESTO registro;

     #region *** Atributos ***

        internal Int32 NID_PUESTO => registro.NID_PUESTO; 

        internal String VID_PUESTO
        {
          get => registro.VID_PUESTO; 
          set => registro.VID_PUESTO = value; 
        }

        internal String VID_NIVEL
        {
          get => registro.VID_NIVEL; 
          set => registro.VID_NIVEL = value; 
        }

        internal String V_PUESTO
        {
          get => registro.V_PUESTO; 
          set => registro.V_PUESTO = value; 
        }

        internal Boolean L_ACTIVO
        {
          get => registro.L_ACTIVO; 
          set => registro.L_ACTIVO = value; 
        }

        public string NOMBRE_UA {
            get => registro.NOMBRE_UA;
            set => registro.NOMBRE_UA = value;

        }
        #endregion


        #region *** Constructores ***

        internal dal_CAT_PUESTO() => registro = new CAT_PUESTO();

        internal dal_CAT_PUESTO(CAT_PUESTO oCAT_PUESTO) : this(oCAT_PUESTO.NID_PUESTO) { }

        internal dal_CAT_PUESTO(Int32 NID_PUESTO) { registro = db.CAT_PUESTO.Find(NID_PUESTO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_PUESTO(Int32 NID_PUESTO, String VID_PUESTO, String VID_NIVEL, String V_PUESTO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_PUESTO()
               {
                 NID_PUESTO = NID_PUESTO,
                 VID_PUESTO = VID_PUESTO,
                 VID_NIVEL = VID_NIVEL,
                 V_PUESTO = V_PUESTO,
                 L_ACTIVO = L_ACTIVO,
               };
            try
            {
                CAT_PUESTO registroCheck = db.CAT_PUESTO.Find(NID_PUESTO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_PUESTO",NID_PUESTO.ToString() + ", " );
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
                            db.CAT_PUESTO.Attach(registro);
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

        internal dal_CAT_PUESTO(Int32 NID_PUESTO, String VID_PUESTO, String VID_NIVEL, String V_PUESTO, Boolean L_ACTIVO, String NOMBRE_UA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new CAT_PUESTO()
            {
                NID_PUESTO = NID_PUESTO,
                VID_PUESTO = VID_PUESTO,
                VID_NIVEL = VID_NIVEL,
                V_PUESTO = V_PUESTO,
                L_ACTIVO = L_ACTIVO,
                NOMBRE_UA = NOMBRE_UA,
            };
            try
            {
                CAT_PUESTO registroCheck = db.CAT_PUESTO.Find(NID_PUESTO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_PUESTO", NID_PUESTO.ToString() + ", ");
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
                            db.CAT_PUESTO.Attach(registro);
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
            db.CAT_PUESTO.Add(registro);
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
            db.CAT_PUESTO.Remove(registro);
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
