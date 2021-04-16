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
    internal class dal_CAT_CONFLICTO_PREGUNTA : _dal_base_Declara
    {

        CAT_CONFLICTO_PREGUNTA registro;

     #region *** Atributos ***

        internal Int32 NID_RUBRO => registro.NID_RUBRO; 

        internal Int32 NID_PREGUNTA => registro.NID_PREGUNTA; 

        internal String V_RUBRO
        {
          get => registro.V_RUBRO; 
          set => registro.V_RUBRO = value; 
        }

        internal String V_OPCIONES
        {
          get => registro.V_OPCIONES; 
          set => registro.V_OPCIONES = value; 
        }

        internal String C_INICIO
        {
          get => registro.C_INICIO; 
          set => registro.C_INICIO = value; 
        }

        internal String C_FIN
        {
          get => registro.C_FIN; 
          set => registro.C_FIN = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_CONFLICTO_PREGUNTA() => registro = new CAT_CONFLICTO_PREGUNTA();

        internal dal_CAT_CONFLICTO_PREGUNTA(CAT_CONFLICTO_PREGUNTA oCAT_CONFLICTO_PREGUNTA) : this(oCAT_CONFLICTO_PREGUNTA.NID_RUBRO, oCAT_CONFLICTO_PREGUNTA.NID_PREGUNTA) { }

        internal dal_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, Int32 NID_PREGUNTA) { registro = db.CAT_CONFLICTO_PREGUNTA.Find(NID_RUBRO, NID_PREGUNTA); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_CONFLICTO_PREGUNTA(Int32 NID_RUBRO, Int32 NID_PREGUNTA, String V_RUBRO, String V_OPCIONES, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_CONFLICTO_PREGUNTA()
               {
                 NID_RUBRO = NID_RUBRO,
                 NID_PREGUNTA = NID_PREGUNTA,
                 V_RUBRO = V_RUBRO,
                 V_OPCIONES = V_OPCIONES,
                 C_INICIO = C_INICIO,
                 C_FIN = C_FIN,
               };
            try
            {
                CAT_CONFLICTO_PREGUNTA registroCheck = db.CAT_CONFLICTO_PREGUNTA.Find(NID_RUBRO, NID_PREGUNTA);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_CONFLICTO_PREGUNTA",NID_RUBRO.ToString() + ", " + NID_PREGUNTA.ToString() + ", " );
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
                            db.CAT_CONFLICTO_PREGUNTA.Attach(registro);
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
            db.CAT_CONFLICTO_PREGUNTA.Add(registro);
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
            db.CAT_CONFLICTO_PREGUNTA.Remove(registro);
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
