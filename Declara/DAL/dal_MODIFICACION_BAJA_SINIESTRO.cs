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
    internal class dal_MODIFICACION_BAJA_SINIESTRO : _dal_base_Declara
    {

        MODIFICACION_BAJA_SINIESTRO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Boolean L_POLIZA
        {
          get => registro.L_POLIZA; 
          set => registro.L_POLIZA = value; 
        }

        internal Decimal M_RECUPERADO
        {
          get => registro.M_RECUPERADO; 
          set => registro.M_RECUPERADO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_MODIFICACION_BAJA_SINIESTRO() => registro = new MODIFICACION_BAJA_SINIESTRO();

        internal dal_MODIFICACION_BAJA_SINIESTRO(MODIFICACION_BAJA_SINIESTRO oMODIFICACION_BAJA_SINIESTRO) : this(oMODIFICACION_BAJA_SINIESTRO.VID_NOMBRE, oMODIFICACION_BAJA_SINIESTRO.VID_FECHA, oMODIFICACION_BAJA_SINIESTRO.VID_HOMOCLAVE, oMODIFICACION_BAJA_SINIESTRO.NID_DECLARACION, oMODIFICACION_BAJA_SINIESTRO.NID_PATRIMONIO) { }

        internal dal_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) { registro = db.MODIFICACION_BAJA_SINIESTRO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_MODIFICACION_BAJA_SINIESTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Boolean L_POLIZA, Decimal M_RECUPERADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new MODIFICACION_BAJA_SINIESTRO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 L_POLIZA = L_POLIZA,
                 M_RECUPERADO = M_RECUPERADO,
               };
            try
            {
                MODIFICACION_BAJA_SINIESTRO registroCheck = db.MODIFICACION_BAJA_SINIESTRO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("MODIFICACION_BAJA_SINIESTRO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_PATRIMONIO.ToString() + ", " );
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
                            registroCheck.L_POLIZA = registro.L_POLIZA;
                            registroCheck.M_RECUPERADO = registro.M_RECUPERADO;
                            ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(registroCheck, EntityState.Modified);
                            update();
                            registro = registroCheck;
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
            db.MODIFICACION_BAJA_SINIESTRO.Add(registro);
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
            db.MODIFICACION_BAJA_SINIESTRO.Remove(registro);
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
