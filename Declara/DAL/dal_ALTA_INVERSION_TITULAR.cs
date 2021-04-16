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
    internal class dal_ALTA_INVERSION_TITULAR : _dal_base_Declara
    {

        ALTA_INVERSION_TITULAR registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_INVERSION => registro.NID_INVERSION; 

        internal Int32 NID_DEPENDIENTE => registro.NID_DEPENDIENTE; 


     #endregion


     #region *** Constructores ***

        internal dal_ALTA_INVERSION_TITULAR() => registro = new ALTA_INVERSION_TITULAR();

        internal dal_ALTA_INVERSION_TITULAR(ALTA_INVERSION_TITULAR oALTA_INVERSION_TITULAR) : this(oALTA_INVERSION_TITULAR.VID_NOMBRE, oALTA_INVERSION_TITULAR.VID_FECHA, oALTA_INVERSION_TITULAR.VID_HOMOCLAVE, oALTA_INVERSION_TITULAR.NID_DECLARACION, oALTA_INVERSION_TITULAR.NID_INVERSION, oALTA_INVERSION_TITULAR.NID_DEPENDIENTE) { }

        internal dal_ALTA_INVERSION_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_DEPENDIENTE) { registro = db.ALTA_INVERSION_TITULAR.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_DEPENDIENTE); if (registro == null) throw new RowNotFoundException(); }

        internal dal_ALTA_INVERSION_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INVERSION, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new ALTA_INVERSION_TITULAR()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_INVERSION = NID_INVERSION,
                 NID_DEPENDIENTE = NID_DEPENDIENTE,
                 L_DIF = L_DIF,
               };
            try
            {
                ALTA_INVERSION_TITULAR registroCheck = db.ALTA_INVERSION_TITULAR.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_DEPENDIENTE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("ALTA_INVERSION_TITULAR",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_INVERSION.ToString() + ", " + NID_DEPENDIENTE.ToString() + ", " );
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
                            db.ALTA_INVERSION_TITULAR.Attach(registro);
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
            db.ALTA_INVERSION_TITULAR.Add(registro);
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
            db.ALTA_INVERSION_TITULAR.Remove(registro);
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
