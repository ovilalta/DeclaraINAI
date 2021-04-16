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
    internal class dal_CAT_MUNICIPIO : _dal_base_Declara
    {

        CAT_MUNICIPIO registro;

     #region *** Atributos ***

        internal Int32 NID_PAIS => registro.NID_PAIS; 

        internal String CID_ENTIDAD_FEDERATIVA => registro.CID_ENTIDAD_FEDERATIVA; 

        internal String CID_MUNICIPIO => registro.CID_MUNICIPIO; 

        internal String V_MUNICIPIO
        {
          get => registro.V_MUNICIPIO; 
          set => registro.V_MUNICIPIO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_MUNICIPIO() => registro = new CAT_MUNICIPIO();

        internal dal_CAT_MUNICIPIO(CAT_MUNICIPIO oCAT_MUNICIPIO) : this(oCAT_MUNICIPIO.NID_PAIS, oCAT_MUNICIPIO.CID_ENTIDAD_FEDERATIVA, oCAT_MUNICIPIO.CID_MUNICIPIO) { }

        internal dal_CAT_MUNICIPIO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO) { registro = db.CAT_MUNICIPIO.Find(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_MUNICIPIO(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_MUNICIPIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_MUNICIPIO()
               {
                 NID_PAIS = NID_PAIS,
                 CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                 CID_MUNICIPIO = CID_MUNICIPIO,
                 V_MUNICIPIO = V_MUNICIPIO,
               };
            try
            {
                CAT_MUNICIPIO registroCheck = db.CAT_MUNICIPIO.Find(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_MUNICIPIO",NID_PAIS.ToString() + ", " + CID_ENTIDAD_FEDERATIVA + ", " + CID_MUNICIPIO + ", " );
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
                            db.CAT_MUNICIPIO.Attach(registro);
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
            db.CAT_MUNICIPIO.Add(registro);
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
            db.CAT_MUNICIPIO.Remove(registro);
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
