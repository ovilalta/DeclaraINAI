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
    internal class dal_USUARIO_CORREO : _dal_base_Declara
    {

        USUARIO_CORREO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal String V_CORREO => registro.V_CORREO;


        internal Boolean L_PRINCIPAL
        {
          get => registro.L_PRINCIPAL; 
          set => registro.L_PRINCIPAL = value; 
        }

        internal Boolean L_ACTIVO
        {
          get => registro.L_ACTIVO; 
          set => registro.L_ACTIVO = value; 
        }

        internal Boolean L_CONFIRMADO
        {
          get => registro.L_CONFIRMADO; 
          set => registro.L_CONFIRMADO = value; 
        }

        internal int N_CODIGO
        {
            get => registro.N_CODIGO;
            set => registro.N_CODIGO = value;
        }


        #endregion


        #region *** Constructores ***

        internal dal_USUARIO_CORREO() => registro = new USUARIO_CORREO();

        internal dal_USUARIO_CORREO(USUARIO_CORREO oUSUARIO_CORREO) : this(oUSUARIO_CORREO.VID_NOMBRE, oUSUARIO_CORREO.VID_FECHA, oUSUARIO_CORREO.VID_HOMOCLAVE, oUSUARIO_CORREO.V_CORREO) { }

        internal dal_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO) { registro = db.USUARIO_CORREO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_USUARIO_CORREO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_CORREO, Boolean L_PRINCIPAL, Boolean L_ACTIVO, Boolean L_CONFIRMADO,Int32 N_CODIGO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new USUARIO_CORREO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 V_CORREO = V_CORREO,
                 L_PRINCIPAL = L_PRINCIPAL,
                 L_ACTIVO = L_ACTIVO,
                 L_CONFIRMADO = L_CONFIRMADO,
                 N_CODIGO = N_CODIGO,
               };
            try
            {
                USUARIO_CORREO registroCheck = db.USUARIO_CORREO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, V_CORREO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("USUARIO_CORREO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + V_CORREO + ", " );
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
                            db.USUARIO_CORREO.Attach(registro);
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
            db.USUARIO_CORREO.Add(registro);
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
            db.USUARIO_CORREO.Remove(registro);
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
