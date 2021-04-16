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
    internal class dal_DECLARACION_RESTRICCIONES : _dal_base_Declara
    {

        DECLARACION_RESTRICCIONES registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_RESTRICCION => registro.NID_RESTRICCION; 

        internal System.Nullable<Boolean> L_RESPUESTA
        {
          get => registro.L_RESPUESTA; 
          set => registro.L_RESPUESTA = value; 
        }

        internal Boolean L_AUTO
        {
          get => registro.L_AUTO; 
          set => registro.L_AUTO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_DECLARACION_RESTRICCIONES() => registro = new DECLARACION_RESTRICCIONES();

        internal dal_DECLARACION_RESTRICCIONES(DECLARACION_RESTRICCIONES oDECLARACION_RESTRICCIONES) : this(oDECLARACION_RESTRICCIONES.VID_NOMBRE, oDECLARACION_RESTRICCIONES.VID_FECHA, oDECLARACION_RESTRICCIONES.VID_HOMOCLAVE, oDECLARACION_RESTRICCIONES.NID_DECLARACION, oDECLARACION_RESTRICCIONES.NID_RESTRICCION) { }

        internal dal_DECLARACION_RESTRICCIONES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION) { registro = db.DECLARACION_RESTRICCIONES.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_DECLARACION_RESTRICCIONES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_RESTRICCION, System.Nullable<Boolean> L_RESPUESTA, Boolean L_AUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new DECLARACION_RESTRICCIONES()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_RESTRICCION = NID_RESTRICCION,
                 L_RESPUESTA = L_RESPUESTA,
                 L_AUTO = L_AUTO,
               };
            try
            {
                DECLARACION_RESTRICCIONES registroCheck = db.DECLARACION_RESTRICCIONES.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_RESTRICCION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("DECLARACION_RESTRICCIONES",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_RESTRICCION.ToString() + ", " );
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
                            db.DECLARACION_RESTRICCIONES.Attach(registro);
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
            db.DECLARACION_RESTRICCIONES.Add(registro);
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
            db.DECLARACION_RESTRICCIONES.Remove(registro);
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
