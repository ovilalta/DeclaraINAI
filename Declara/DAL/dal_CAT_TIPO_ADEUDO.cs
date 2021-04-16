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
    internal class dal_CAT_TIPO_ADEUDO : _dal_base_Declara
    {

        CAT_TIPO_ADEUDO registro;

     #region *** Atributos ***

        internal Int32 NID_TIPO_ADEUDO => registro.NID_TIPO_ADEUDO; 

        internal String V_TIPO_ADEUDO
        {
          get => registro.V_TIPO_ADEUDO; 
          set => registro.V_TIPO_ADEUDO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_TIPO_ADEUDO() => registro = new CAT_TIPO_ADEUDO();

        internal dal_CAT_TIPO_ADEUDO(CAT_TIPO_ADEUDO oCAT_TIPO_ADEUDO) : this(oCAT_TIPO_ADEUDO.NID_TIPO_ADEUDO) { }

        internal dal_CAT_TIPO_ADEUDO(Int32 NID_TIPO_ADEUDO) { registro = db.CAT_TIPO_ADEUDO.Find(NID_TIPO_ADEUDO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_TIPO_ADEUDO(Int32 NID_TIPO_ADEUDO, String V_TIPO_ADEUDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_TIPO_ADEUDO()
               {
                 NID_TIPO_ADEUDO = NID_TIPO_ADEUDO,
                 V_TIPO_ADEUDO = V_TIPO_ADEUDO,
               };
            try
            {
                CAT_TIPO_ADEUDO registroCheck = db.CAT_TIPO_ADEUDO.Find(NID_TIPO_ADEUDO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_TIPO_ADEUDO",NID_TIPO_ADEUDO.ToString() + ", " );
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
                            db.CAT_TIPO_ADEUDO.Attach(registro);
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
            db.CAT_TIPO_ADEUDO.Add(registro);
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
            db.CAT_TIPO_ADEUDO.Remove(registro);
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
