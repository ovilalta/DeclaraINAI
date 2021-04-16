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
    internal class dal_USUARIO_SESION : _dal_base_Declara
    {

        USUARIO_SESION registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_SESION => registro.NID_SESION; 

        internal String V_IP
        {
          get => registro.V_IP; 
          set => registro.V_IP = value; 
        }

        internal String V_MAQUINA_USUARIO
        {
          get => registro.V_MAQUINA_USUARIO; 
          set => registro.V_MAQUINA_USUARIO = value; 
        }

        internal DateTime F_INICIO
        {
          get => registro.F_INICIO; 
          set => registro.F_INICIO = value; 
        }

        internal DateTime F_FIN
        {
          get => registro.F_FIN; 
          set => registro.F_FIN = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_USUARIO_SESION() => registro = new USUARIO_SESION();

        internal dal_USUARIO_SESION(USUARIO_SESION oUSUARIO_SESION) : this(oUSUARIO_SESION.VID_NOMBRE, oUSUARIO_SESION.VID_FECHA, oUSUARIO_SESION.VID_HOMOCLAVE, oUSUARIO_SESION.NID_SESION) { }

        internal dal_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_SESION) { registro = db.USUARIO_SESION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_USUARIO_SESION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_SESION, String V_IP, String V_MAQUINA_USUARIO, DateTime F_INICIO, DateTime F_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new USUARIO_SESION()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_SESION = NID_SESION,
                 V_IP = V_IP,
                 V_MAQUINA_USUARIO = V_MAQUINA_USUARIO,
                 F_INICIO = F_INICIO,
                 F_FIN = F_FIN,
               };
            try
            {
                USUARIO_SESION registroCheck = db.USUARIO_SESION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_SESION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("USUARIO_SESION",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_SESION.ToString() + ", " );
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
                            db.USUARIO_SESION.Attach(registro);
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
            db.USUARIO_SESION.Add(registro);
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
            db.USUARIO_SESION.Remove(registro);
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
