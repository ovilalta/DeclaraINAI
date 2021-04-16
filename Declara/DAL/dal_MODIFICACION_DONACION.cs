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
    internal class dal_MODIFICACION_DONACION : _dal_base_Declara
    {

        MODIFICACION_DONACION registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal String E_ESPECIFICA
        {
          get => registro.E_ESPECIFICA; 
          set => registro.E_ESPECIFICA = value; 
        }

        internal String E_BENIFICIARIO
        {
            get => registro.E_BENIFICIARIO;
            set => registro.E_BENIFICIARIO = value;
        }

        #endregion


        #region *** Constructores ***

        internal dal_MODIFICACION_DONACION() => registro = new MODIFICACION_DONACION();

        internal dal_MODIFICACION_DONACION(MODIFICACION_DONACION oMODIFICACION_DONACION) : this(oMODIFICACION_DONACION.VID_NOMBRE, oMODIFICACION_DONACION.VID_FECHA, oMODIFICACION_DONACION.VID_HOMOCLAVE, oMODIFICACION_DONACION.NID_DECLARACION, oMODIFICACION_DONACION.NID_PATRIMONIO) { }

        internal dal_MODIFICACION_DONACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO) { registro = db.MODIFICACION_DONACION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_MODIFICACION_DONACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, String V_ESPECIFICA, String E_BENIFICIARIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new MODIFICACION_DONACION()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 E_ESPECIFICA = V_ESPECIFICA,
                 E_BENIFICIARIO = E_BENIFICIARIO
               };
            try
            {
                MODIFICACION_DONACION registroCheck = db.MODIFICACION_DONACION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("MODIFICACION_DONACION",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_PATRIMONIO.ToString() + ", " );
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
                            registroCheck.E_ESPECIFICA = registro.E_ESPECIFICA;
                            registroCheck.E_BENIFICIARIO = registro.E_BENIFICIARIO;
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
            db.MODIFICACION_DONACION.Add(registro);
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
            db.MODIFICACION_DONACION.Remove(registro);
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
