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
    internal class dal_ALTA_VEHICULO_ADEUDO : _dal_base_Declara
    {

        ALTA_VEHICULO_ADEUDO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_VEHICULO => registro.NID_VEHICULO; 

        internal Int32 NID_ADEUDO
        {
          get => registro.NID_ADEUDO; 
          set => registro.NID_ADEUDO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_ALTA_VEHICULO_ADEUDO() => registro = new ALTA_VEHICULO_ADEUDO();

        internal dal_ALTA_VEHICULO_ADEUDO(ALTA_VEHICULO_ADEUDO oALTA_VEHICULO_ADEUDO) : this(oALTA_VEHICULO_ADEUDO.VID_NOMBRE, oALTA_VEHICULO_ADEUDO.VID_FECHA, oALTA_VEHICULO_ADEUDO.VID_HOMOCLAVE, oALTA_VEHICULO_ADEUDO.NID_DECLARACION, oALTA_VEHICULO_ADEUDO.NID_VEHICULO) { }

        internal dal_ALTA_VEHICULO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO) { registro = db.ALTA_VEHICULO_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_ALTA_VEHICULO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO, Int32 NID_ADEUDO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new ALTA_VEHICULO_ADEUDO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_VEHICULO = NID_VEHICULO,
                 NID_ADEUDO = NID_ADEUDO,
               };
            try
            {
                ALTA_VEHICULO_ADEUDO registroCheck = db.ALTA_VEHICULO_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("ALTA_VEHICULO_ADEUDO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_VEHICULO.ToString() + ", " );
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
                            db.ALTA_VEHICULO_ADEUDO.Attach(registro);
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
            db.ALTA_VEHICULO_ADEUDO.Add(registro);
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
            db.ALTA_VEHICULO_ADEUDO.Remove(registro);
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
