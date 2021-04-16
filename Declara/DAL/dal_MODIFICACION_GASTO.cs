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
    internal class dal_MODIFICACION_GASTO : _dal_base_Declara
    {

        MODIFICACION_GASTO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_GASTO => registro.NID_GASTO;

        internal Int32 NID_TIPO_GASTO
        {
            get => registro.NID_TIPO_GASTO;
            set => registro.NID_TIPO_GASTO = value;
        }

        internal String V_GASTO
        {
          get => registro.V_GASTO; 
          set => registro.V_GASTO = value; 
        }

        internal Decimal M_GASTO
        {
          get => registro.M_GASTO; 
          set => registro.M_GASTO = value; 
        }

        internal Boolean L_AUTOGENERADO
        {
          get => registro.L_AUTOGENERADO; 
          set => registro.L_AUTOGENERADO = value; 
        }

        internal System.Nullable<Int32> NID_PATRIMONIO_ASC
        {
          get => registro.NID_PATRIMONIO_ASC; 
          set => registro.NID_PATRIMONIO_ASC = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_MODIFICACION_GASTO() => registro = new MODIFICACION_GASTO();

        internal dal_MODIFICACION_GASTO(MODIFICACION_GASTO oMODIFICACION_GASTO) : this(oMODIFICACION_GASTO.VID_NOMBRE, oMODIFICACION_GASTO.VID_FECHA, oMODIFICACION_GASTO.VID_HOMOCLAVE, oMODIFICACION_GASTO.NID_DECLARACION, oMODIFICACION_GASTO.NID_GASTO) { }

        internal dal_MODIFICACION_GASTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_GASTO) { registro = db.MODIFICACION_GASTO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_GASTO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_MODIFICACION_GASTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_GASTO,Int32 NID_TIPO_GASTO, String V_GASTO, Decimal M_GASTO, Boolean L_AUTOGENERADO, System.Nullable<Int32> NID_PATRIMONIO_ASC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new MODIFICACION_GASTO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_GASTO = NID_GASTO,
                 V_GASTO = V_GASTO,
                 M_GASTO = M_GASTO,
                 L_AUTOGENERADO = L_AUTOGENERADO,
                 NID_PATRIMONIO_ASC = NID_PATRIMONIO_ASC,
                 NID_TIPO_GASTO = NID_TIPO_GASTO,
               };
            try
            {
                MODIFICACION_GASTO registroCheck = db.MODIFICACION_GASTO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_GASTO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("MODIFICACION_GASTO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_GASTO.ToString() + ", " );
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
                            db.MODIFICACION_GASTO.Attach(registro);
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
            db.MODIFICACION_GASTO.Add(registro);
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
            db.MODIFICACION_GASTO.Remove(registro);
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
