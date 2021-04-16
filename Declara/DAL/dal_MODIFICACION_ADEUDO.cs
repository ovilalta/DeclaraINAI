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
    internal class dal_MODIFICACION_ADEUDO : _dal_base_Declara
    {

        MODIFICACION_ADEUDO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Decimal M_PAGOS
        {
          get => registro.M_PAGOS; 
          set => registro.M_PAGOS = value; 
        }

        internal Decimal M_SALDOS
        {
          get => registro.M_SALDOS; 
          set => registro.M_SALDOS = value; 
        }

        internal Boolean L_CANCELADO
        {
          get => registro.L_CANCELADO; 
          set => registro.L_CANCELADO = value; 
        }

        internal Boolean L_MODIFICADO
        {
          get => registro.L_MODIFICADO; 
          set => registro.L_MODIFICADO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_MODIFICACION_ADEUDO() => registro = new MODIFICACION_ADEUDO();

        internal dal_MODIFICACION_ADEUDO(MODIFICACION_ADEUDO oMODIFICACION_ADEUDO) : this(oMODIFICACION_ADEUDO.VID_NOMBRE, oMODIFICACION_ADEUDO.VID_FECHA, oMODIFICACION_ADEUDO.VID_HOMOCLAVE, oMODIFICACION_ADEUDO.NID_DECLARACION, oMODIFICACION_ADEUDO.NID_PATRIMONIO) { }

        internal dal_MODIFICACION_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) { registro = db.MODIFICACION_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_MODIFICACION_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Decimal M_PAGOS, Decimal M_SALDOS, Boolean L_CANCELADO, Boolean L_MODIFICADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new MODIFICACION_ADEUDO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 M_PAGOS = M_PAGOS,
                 M_SALDOS = M_SALDOS,
                 L_CANCELADO = L_CANCELADO,
                 L_MODIFICADO = L_MODIFICADO,
               };
            try
            {
                MODIFICACION_ADEUDO registroCheck = db.MODIFICACION_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("MODIFICACION_ADEUDO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_PATRIMONIO.ToString() + ", " );
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
                            db.MODIFICACION_ADEUDO.Attach(registro);
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
            db.MODIFICACION_ADEUDO.Add(registro);
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
            db.MODIFICACION_ADEUDO.Remove(registro);
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
