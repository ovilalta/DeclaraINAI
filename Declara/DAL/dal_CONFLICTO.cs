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
    internal class dal_CONFLICTO : _dal_base_Declara
    {

        CONFLICTO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_CONFLICTO => registro.NID_CONFLICTO; 

        internal System.Nullable<Int32> NID_DEC_ASOS
        {
          get => registro.NID_DEC_ASOS; 
          set => registro.NID_DEC_ASOS = value; 
        }

        internal Int32 NID_ESTADO_CONFLICTO
        {
          get => registro.NID_ESTADO_CONFLICTO; 
          set => registro.NID_ESTADO_CONFLICTO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CONFLICTO() => registro = new CONFLICTO();

        internal dal_CONFLICTO(CONFLICTO oCONFLICTO) : this(oCONFLICTO.VID_NOMBRE, oCONFLICTO.VID_FECHA, oCONFLICTO.VID_HOMOCLAVE, oCONFLICTO.NID_CONFLICTO) { }

        internal dal_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO) { registro = db.CONFLICTO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CONFLICTO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, System.Nullable<Int32> NID_DEC_ASOS, Int32 NID_ESTADO_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CONFLICTO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_CONFLICTO = NID_CONFLICTO,
                 NID_DEC_ASOS = NID_DEC_ASOS,
                 NID_ESTADO_CONFLICTO = NID_ESTADO_CONFLICTO,
               };
            try
            {
                CONFLICTO registroCheck = db.CONFLICTO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CONFLICTO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_CONFLICTO.ToString() + ", " );
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
                            db.CONFLICTO.Attach(registro);
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
            db.CONFLICTO.Add(registro);
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
            db.CONFLICTO.Remove(registro);
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
