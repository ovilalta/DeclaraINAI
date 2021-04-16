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
    internal class dal_MODIFICACION_INVERSION : _dal_base_Declara
    {

        MODIFICACION_INVERSION registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Decimal M_SALDO_ANTERIOR
        {
          get => registro.M_SALDO_ANTERIOR; 
          set => registro.M_SALDO_ANTERIOR = value; 
        }

        internal Decimal M_SALDO_ACTUAL
        {
          get => registro.M_SALDO_ACTUAL; 
          set => registro.M_SALDO_ACTUAL = value; 
        }

        internal Boolean L_CANCELADA
        {
          get => registro.L_CANCELADA; 
          set => registro.L_CANCELADA = value; 
        }

        internal Boolean L_MODIFICADA
        {
          get => registro.L_MODIFICADA; 
          set => registro.L_MODIFICADA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_MODIFICACION_INVERSION() => registro = new MODIFICACION_INVERSION();

        internal dal_MODIFICACION_INVERSION(MODIFICACION_INVERSION oMODIFICACION_INVERSION) : this(oMODIFICACION_INVERSION.VID_NOMBRE, oMODIFICACION_INVERSION.VID_FECHA, oMODIFICACION_INVERSION.VID_HOMOCLAVE, oMODIFICACION_INVERSION.NID_DECLARACION, oMODIFICACION_INVERSION.NID_PATRIMONIO) { }

        internal dal_MODIFICACION_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) { registro = db.MODIFICACION_INVERSION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_MODIFICACION_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Decimal M_SALDO_ANTERIOR, Decimal M_SALDO_ACTUAL, Boolean L_CANCELADA, Boolean L_MODIFICADA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new MODIFICACION_INVERSION()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 M_SALDO_ANTERIOR = M_SALDO_ANTERIOR,
                 M_SALDO_ACTUAL = M_SALDO_ACTUAL,
                 L_CANCELADA = L_CANCELADA,
                 L_MODIFICADA = L_MODIFICADA,
               };
            try
            {
                MODIFICACION_INVERSION registroCheck = db.MODIFICACION_INVERSION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("MODIFICACION_INVERSION",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_PATRIMONIO.ToString() + ", " );
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
                            db.MODIFICACION_INVERSION.Attach(registro);
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
            db.MODIFICACION_INVERSION.Add(registro);
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
            db.MODIFICACION_INVERSION.Remove(registro);
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
