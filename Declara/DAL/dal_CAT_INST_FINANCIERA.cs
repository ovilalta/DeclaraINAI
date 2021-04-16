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
    internal class dal_CAT_INST_FINANCIERA : _dal_base_Declara
    {

        CAT_INST_FINANCIERA registro;

     #region *** Atributos ***

        internal Int32 NID_INSTITUCION => registro.NID_INSTITUCION; 

        internal String V_INSTITUCION
        {
          get => registro.V_INSTITUCION; 
          set => registro.V_INSTITUCION = value; 
        }

        internal Boolean L_ACTIVO
        {
          get => registro.L_ACTIVO; 
          set => registro.L_ACTIVO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_INST_FINANCIERA() => registro = new CAT_INST_FINANCIERA();

        internal dal_CAT_INST_FINANCIERA(CAT_INST_FINANCIERA oCAT_INST_FINANCIERA) : this(oCAT_INST_FINANCIERA.NID_INSTITUCION) { }

        internal dal_CAT_INST_FINANCIERA(Int32 NID_INSTITUCION) { registro = db.CAT_INST_FINANCIERA.Find(NID_INSTITUCION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_INST_FINANCIERA(Int32 NID_INSTITUCION, String V_INSTITUCION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_INST_FINANCIERA()
               {
                 NID_INSTITUCION = NID_INSTITUCION,
                 V_INSTITUCION = V_INSTITUCION,
                 L_ACTIVO = L_ACTIVO,
               };
            try
            {
                CAT_INST_FINANCIERA registroCheck = db.CAT_INST_FINANCIERA.Find(NID_INSTITUCION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_INST_FINANCIERA",NID_INSTITUCION.ToString() + ", " );
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
                            db.CAT_INST_FINANCIERA.Attach(registro);
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
            db.CAT_INST_FINANCIERA.Add(registro);
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
            db.CAT_INST_FINANCIERA.Remove(registro);
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
