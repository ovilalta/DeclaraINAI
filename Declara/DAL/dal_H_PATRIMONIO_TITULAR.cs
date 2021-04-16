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
    internal class dal_H_PATRIMONIO_TITULAR : _dal_base_Declara
    {

        H_PATRIMONIO_TITULAR registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Int32 NID_DEPENDIENTE => registro.NID_DEPENDIENTE; 

        internal Int32 NID_HISTORICO => registro.NID_HISTORICO; 


     #endregion


     #region *** Constructores ***

        internal dal_H_PATRIMONIO_TITULAR() => registro = new H_PATRIMONIO_TITULAR();

        internal dal_H_PATRIMONIO_TITULAR(H_PATRIMONIO_TITULAR oH_PATRIMONIO_TITULAR) : this(oH_PATRIMONIO_TITULAR.VID_NOMBRE, oH_PATRIMONIO_TITULAR.VID_FECHA, oH_PATRIMONIO_TITULAR.VID_HOMOCLAVE, oH_PATRIMONIO_TITULAR.NID_PATRIMONIO, oH_PATRIMONIO_TITULAR.NID_DEPENDIENTE, oH_PATRIMONIO_TITULAR.NID_HISTORICO) { }

        internal dal_H_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Int32 NID_HISTORICO) { registro = db.H_PATRIMONIO_TITULAR.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_H_PATRIMONIO_TITULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Int32 NID_HISTORICO, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new H_PATRIMONIO_TITULAR()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 NID_DEPENDIENTE = NID_DEPENDIENTE,
                 NID_HISTORICO = NID_HISTORICO,
                 L_DIF = L_DIF,
               };
            try
            {
                H_PATRIMONIO_TITULAR registroCheck = db.H_PATRIMONIO_TITULAR.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_DEPENDIENTE, NID_HISTORICO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("H_PATRIMONIO_TITULAR",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_PATRIMONIO.ToString() + ", " + NID_DEPENDIENTE.ToString() + ", " + NID_HISTORICO.ToString() + ", " );
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
                            db.H_PATRIMONIO_TITULAR.Attach(registro);
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
            db.H_PATRIMONIO_TITULAR.Add(registro);
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
            db.H_PATRIMONIO_TITULAR.Remove(registro);
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
