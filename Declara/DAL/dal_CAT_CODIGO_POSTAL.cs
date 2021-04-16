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
    internal class dal_CAT_CODIGO_POSTAL : _dal_base_Declara
    {

        CAT_CODIGO_POSTAL registro;

     #region *** Atributos ***

        internal Int32 NID_PAIS => registro.NID_PAIS; 

        internal String CID_ENTIDAD_FEDERATIVA => registro.CID_ENTIDAD_FEDERATIVA; 

        internal String CID_MUNICIPIO => registro.CID_MUNICIPIO; 

        internal String CID_CODIGO_POSTAL => registro.CID_CODIGO_POSTAL; 

        internal Int32 NID_COLONIA => registro.NID_COLONIA; 

        internal String V_COLONIA
        {
          get => registro.V_COLONIA; 
          set => registro.V_COLONIA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_CODIGO_POSTAL() => registro = new CAT_CODIGO_POSTAL();

        internal dal_CAT_CODIGO_POSTAL(CAT_CODIGO_POSTAL oCAT_CODIGO_POSTAL) : this(oCAT_CODIGO_POSTAL.NID_PAIS, oCAT_CODIGO_POSTAL.CID_ENTIDAD_FEDERATIVA, oCAT_CODIGO_POSTAL.CID_MUNICIPIO, oCAT_CODIGO_POSTAL.CID_CODIGO_POSTAL, oCAT_CODIGO_POSTAL.NID_COLONIA) { }

        internal dal_CAT_CODIGO_POSTAL(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String CID_CODIGO_POSTAL, Int32 NID_COLONIA) { registro = db.CAT_CODIGO_POSTAL.Find(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, CID_CODIGO_POSTAL, NID_COLONIA); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_CODIGO_POSTAL(Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String CID_CODIGO_POSTAL, Int32 NID_COLONIA, String V_COLONIA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_CODIGO_POSTAL()
               {
                 NID_PAIS = NID_PAIS,
                 CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                 CID_MUNICIPIO = CID_MUNICIPIO,
                 CID_CODIGO_POSTAL = CID_CODIGO_POSTAL,
                 NID_COLONIA = NID_COLONIA,
                 V_COLONIA = V_COLONIA,
               };
            try
            {
                CAT_CODIGO_POSTAL registroCheck = db.CAT_CODIGO_POSTAL.Find(NID_PAIS, CID_ENTIDAD_FEDERATIVA, CID_MUNICIPIO, CID_CODIGO_POSTAL, NID_COLONIA);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_CODIGO_POSTAL",NID_PAIS.ToString() + ", " + CID_ENTIDAD_FEDERATIVA + ", " + CID_MUNICIPIO + ", " + CID_CODIGO_POSTAL + ", " + NID_COLONIA.ToString() + ", " );
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
                            db.CAT_CODIGO_POSTAL.Attach(registro);
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
            db.CAT_CODIGO_POSTAL.Add(registro);
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
            db.CAT_CODIGO_POSTAL.Remove(registro);
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
