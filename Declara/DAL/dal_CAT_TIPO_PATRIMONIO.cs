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
    internal class dal_CAT_TIPO_PATRIMONIO : _dal_base_Declara
    {

        CAT_TIPO_PATRIMONIO registro;

     #region *** Atributos ***

        internal Int32 NID_TIPO => registro.NID_TIPO; 

        internal String V_TIPO
        {
          get => registro.V_TIPO; 
          set => registro.V_TIPO = value; 
        }

        internal Int32 C_NATURALEZA
        {
          get => registro.C_NATURALEZA; 
          set => registro.C_NATURALEZA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPO_PATRIMONIO() => registro = new CAT_TIPO_PATRIMONIO();

        internal dal_CAT_TIPO_PATRIMONIO(CAT_TIPO_PATRIMONIO oCAT_TIPO_PATRIMONIO) : this(oCAT_TIPO_PATRIMONIO.NID_TIPO) { }

        internal dal_CAT_TIPO_PATRIMONIO(Int32 NID_TIPO) { registro = db.CAT_TIPO_PATRIMONIO.Find(NID_TIPO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPO_PATRIMONIO(Int32 NID_TIPO, String V_TIPO, Int32 C_NATURALEZA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPO_PATRIMONIO()
               {
                 NID_TIPO = NID_TIPO,
                 V_TIPO = V_TIPO,
                 C_NATURALEZA = C_NATURALEZA,
               };
            try
            {
                CAT_TIPO_PATRIMONIO registroCheck = db.CAT_TIPO_PATRIMONIO.Find(NID_TIPO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPO_PATRIMONIO",NID_TIPO.ToString() + ", " );
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
                            db.CAT_TIPO_PATRIMONIO.Attach(registro);
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
            db.CAT_TIPO_PATRIMONIO.Add(registro);
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
            db.CAT_TIPO_PATRIMONIO.Remove(registro);
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
