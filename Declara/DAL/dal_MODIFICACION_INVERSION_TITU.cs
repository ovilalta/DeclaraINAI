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
    internal class dal_MODIFICACION_INVERSION_TITU : _dal_base_Declara
    {

        MODIFICACION_INVERSION_TITU registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Int32 NID_DEPENDIENTE => registro.NID_DEPENDIENTE; 


     #endregion


     #region *** Constructores ***

        internal dal_MODIFICACION_INVERSION_TITU() => registro = new MODIFICACION_INVERSION_TITU();

        internal dal_MODIFICACION_INVERSION_TITU(MODIFICACION_INVERSION_TITU oMODIFICACION_INVERSION_TITU) : this(oMODIFICACION_INVERSION_TITU.VID_NOMBRE, oMODIFICACION_INVERSION_TITU.VID_FECHA, oMODIFICACION_INVERSION_TITU.VID_HOMOCLAVE, oMODIFICACION_INVERSION_TITU.NID_DECLARACION, oMODIFICACION_INVERSION_TITU.NID_PATRIMONIO, oMODIFICACION_INVERSION_TITU.NID_DEPENDIENTE) { }

        internal dal_MODIFICACION_INVERSION_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE) { registro = db.MODIFICACION_INVERSION_TITU.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE); if (registro == null) throw new RowNotFoundException(); }

        internal dal_MODIFICACION_INVERSION_TITU(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PATRIMONIO, Int32 NID_DEPENDIENTE, Boolean L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new MODIFICACION_INVERSION_TITU()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 NID_DEPENDIENTE = NID_DEPENDIENTE,
                 L_DIF = L_DIF,
               };
            try
            {
                MODIFICACION_INVERSION_TITU registroCheck = db.MODIFICACION_INVERSION_TITU.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PATRIMONIO, NID_DEPENDIENTE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("MODIFICACION_INVERSION_TITU",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_PATRIMONIO.ToString() + ", " + NID_DEPENDIENTE.ToString() + ", " );
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
                            db.MODIFICACION_INVERSION_TITU.Attach(registro);
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
            db.MODIFICACION_INVERSION_TITU.Add(registro);
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
            db.MODIFICACION_INVERSION_TITU.Remove(registro);
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
