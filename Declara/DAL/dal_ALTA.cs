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
    internal class dal_ALTA : _dal_base_Declara
    {

        protected ALTA registro;

        #region *** Propiedades ***

        internal String VID_NOMBRE => registro.VID_NOMBRE;

        internal String VID_FECHA => registro.VID_FECHA;

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;


        #endregion


        #region *** Constructores ***

        internal dal_ALTA() => registro = new ALTA();

        internal dal_ALTA(ALTA oALTA) : this(oALTA.VID_NOMBRE, oALTA.VID_FECHA, oALTA.VID_HOMOCLAVE, oALTA.NID_DECLARACION) { }

        internal dal_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) { registro = db.ALTA.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_ALTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new ALTA()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
            };
            try
            {
                ALTA registroCheck = db.ALTA.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("ALTA", VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", ");
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
                            db.ALTA.Attach(registro);
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
            db.ALTA.Add(registro);
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
            db.ALTA.Remove(registro);
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
