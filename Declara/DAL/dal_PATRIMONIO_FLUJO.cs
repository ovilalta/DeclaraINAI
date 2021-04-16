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
    internal class dal_PATRIMONIO_FLUJO : _dal_base_Declara
    {

        PATRIMONIO_FLUJO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Decimal M_INGRESOS
        {
          get => registro.M_INGRESOS; 
          set => registro.M_INGRESOS = value; 
        }

        internal Decimal M_EGRESOS
        {
          get => registro.M_EGRESOS; 
          set => registro.M_EGRESOS = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_PATRIMONIO_FLUJO() => registro = new PATRIMONIO_FLUJO();

        internal dal_PATRIMONIO_FLUJO(PATRIMONIO_FLUJO oPATRIMONIO_FLUJO) : this(oPATRIMONIO_FLUJO.VID_NOMBRE, oPATRIMONIO_FLUJO.VID_FECHA, oPATRIMONIO_FLUJO.VID_HOMOCLAVE) { }

        internal dal_PATRIMONIO_FLUJO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE) { registro = db.PATRIMONIO_FLUJO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE); if (registro == null) throw new RowNotFoundException(); }

        internal dal_PATRIMONIO_FLUJO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Decimal M_INGRESOS, Decimal M_EGRESOS, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new PATRIMONIO_FLUJO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 M_INGRESOS = M_INGRESOS,
                 M_EGRESOS = M_EGRESOS,
               };
            try
            {
                PATRIMONIO_FLUJO registroCheck = db.PATRIMONIO_FLUJO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("PATRIMONIO_FLUJO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " );
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
                            db.PATRIMONIO_FLUJO.Attach(registro);
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
            db.PATRIMONIO_FLUJO.Add(registro);
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
            db.PATRIMONIO_FLUJO.Remove(registro);
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
