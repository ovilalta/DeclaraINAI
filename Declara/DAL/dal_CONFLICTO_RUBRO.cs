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
    internal class dal_CONFLICTO_RUBRO : _dal_base_Declara
    {

        CONFLICTO_RUBRO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_CONFLICTO => registro.NID_CONFLICTO; 

        internal Int32 NID_RUBRO => registro.NID_RUBRO; 

        internal System.Nullable<Boolean> L_RESPUESTA
        {
          get => registro.L_RESPUESTA; 
          set => registro.L_RESPUESTA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CONFLICTO_RUBRO() => registro = new CONFLICTO_RUBRO();

        internal dal_CONFLICTO_RUBRO(CONFLICTO_RUBRO oCONFLICTO_RUBRO) : this(oCONFLICTO_RUBRO.VID_NOMBRE, oCONFLICTO_RUBRO.VID_FECHA, oCONFLICTO_RUBRO.VID_HOMOCLAVE, oCONFLICTO_RUBRO.NID_CONFLICTO, oCONFLICTO_RUBRO.NID_RUBRO) { }

        internal dal_CONFLICTO_RUBRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO) { registro = db.CONFLICTO_RUBRO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CONFLICTO_RUBRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, System.Nullable<Boolean> L_RESPUESTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CONFLICTO_RUBRO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_CONFLICTO = NID_CONFLICTO,
                 NID_RUBRO = NID_RUBRO,
                 L_RESPUESTA = L_RESPUESTA,
               };
            try
            {
                CONFLICTO_RUBRO registroCheck = db.CONFLICTO_RUBRO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CONFLICTO_RUBRO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_CONFLICTO.ToString() + ", " + NID_RUBRO.ToString() + ", " );
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
                            db.CONFLICTO_RUBRO.Attach(registro);
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
            db.CONFLICTO_RUBRO.Add(registro);
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
            db.CONFLICTO_RUBRO.Remove(registro);
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
