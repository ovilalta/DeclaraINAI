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
    internal class dal_USUARIO_REC_PASS : _dal_base_Declara
    {

        protected USUARIO_REC_PASS registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal String V_CORREO => registro.V_CORREO; 

        internal Int32 N_USOS
        {
          get => registro.N_USOS; 
          set => registro.N_USOS = value; 
        }

        internal DateTime F_SOLICITUD
        {
          get => registro.F_SOLICITUD; 
          set => registro.F_SOLICITUD = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_USUARIO_REC_PASS() => registro = new USUARIO_REC_PASS();

        internal dal_USUARIO_REC_PASS(USUARIO_REC_PASS oUSUARIO_REC_PASS) : this(oUSUARIO_REC_PASS.VID_NOMBRE, oUSUARIO_REC_PASS.VID_FECHA, oUSUARIO_REC_PASS.VID_HOMOCLAVE, oUSUARIO_REC_PASS.V_CORREO) { }

        internal dal_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO) { registro = db.USUARIO_REC_PASS.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_USUARIO_REC_PASS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Int32 N_USOS, DateTime F_SOLICITUD, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new USUARIO_REC_PASS()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 V_CORREO = V_CORREO,
                 N_USOS = N_USOS,
                 F_SOLICITUD = F_SOLICITUD,
               };
            try
            {
                USUARIO_REC_PASS registroCheck = db.USUARIO_REC_PASS.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("USUARIO_REC_PASS",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + V_CORREO + ", " );
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
                            db.USUARIO_REC_PASS.Attach(registro);
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
            db.USUARIO_REC_PASS.Add(registro);
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
            db.USUARIO_REC_PASS.Remove(registro);
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
