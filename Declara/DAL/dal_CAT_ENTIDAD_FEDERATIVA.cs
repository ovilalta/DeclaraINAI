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
    internal class dal_CAT_ENTIDAD_FEDERATIVA : _dal_base_Declara
    {

        CAT_ENTIDAD_FEDERATIVA registro;

     #region *** Atributos ***

        internal Int32 NID_PAIS => registro.NID_PAIS; 

        internal String CID_ENTIDAD_FEDERATIVA => registro.CID_ENTIDAD_FEDERATIVA; 

        internal String V_ENTIDAD_FEDERATIVA
        {
          get => registro.V_ENTIDAD_FEDERATIVA; 
          set => registro.V_ENTIDAD_FEDERATIVA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_ENTIDAD_FEDERATIVA() => registro = new CAT_ENTIDAD_FEDERATIVA();

        internal dal_CAT_ENTIDAD_FEDERATIVA(CAT_ENTIDAD_FEDERATIVA oCAT_ENTIDAD_FEDERATIVA) : this(oCAT_ENTIDAD_FEDERATIVA.NID_PAIS, oCAT_ENTIDAD_FEDERATIVA.CID_ENTIDAD_FEDERATIVA) { }

        internal dal_CAT_ENTIDAD_FEDERATIVA(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA) { registro = db.CAT_ENTIDAD_FEDERATIVA.Find(NID_PAIS, CID_ENTIDAD_FEDERATIVA); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_ENTIDAD_FEDERATIVA(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_ENTIDAD_FEDERATIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_ENTIDAD_FEDERATIVA()
               {
                 NID_PAIS = NID_PAIS,
                 CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                 V_ENTIDAD_FEDERATIVA = V_ENTIDAD_FEDERATIVA,
               };
            try
            {
                CAT_ENTIDAD_FEDERATIVA registroCheck = db.CAT_ENTIDAD_FEDERATIVA.Find(NID_PAIS, CID_ENTIDAD_FEDERATIVA);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_ENTIDAD_FEDERATIVA",NID_PAIS.ToString() + ", " + CID_ENTIDAD_FEDERATIVA + ", " );
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
                            db.CAT_ENTIDAD_FEDERATIVA.Attach(registro);
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
            db.CAT_ENTIDAD_FEDERATIVA.Add(registro);
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
            db.CAT_ENTIDAD_FEDERATIVA.Remove(registro);
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
