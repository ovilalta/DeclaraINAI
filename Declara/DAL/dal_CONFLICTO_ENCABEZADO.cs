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
    internal class dal_CONFLICTO_ENCABEZADO : _dal_base_Declara
    {

        CONFLICTO_ENCABEZADO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_CONFLICTO => registro.NID_CONFLICTO; 

        internal Int32 NID_RUBRO => registro.NID_RUBRO; 

        internal Int32 NID_ENCABEZADO => registro.NID_ENCABEZADO; 

        internal System.Nullable<Boolean> L_CONFLICTO
        {
          get => registro.L_CONFLICTO; 
          set => registro.L_CONFLICTO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CONFLICTO_ENCABEZADO() => registro = new CONFLICTO_ENCABEZADO();

        internal dal_CONFLICTO_ENCABEZADO(CONFLICTO_ENCABEZADO oCONFLICTO_ENCABEZADO) : this(oCONFLICTO_ENCABEZADO.VID_NOMBRE, oCONFLICTO_ENCABEZADO.VID_FECHA, oCONFLICTO_ENCABEZADO.VID_HOMOCLAVE, oCONFLICTO_ENCABEZADO.NID_CONFLICTO, oCONFLICTO_ENCABEZADO.NID_RUBRO, oCONFLICTO_ENCABEZADO.NID_ENCABEZADO) { }

        internal dal_CONFLICTO_ENCABEZADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO) { registro = db.CONFLICTO_ENCABEZADO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CONFLICTO_ENCABEZADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, System.Nullable<Boolean> L_CONFLICTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CONFLICTO_ENCABEZADO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_CONFLICTO = NID_CONFLICTO,
                 NID_RUBRO = NID_RUBRO,
                 NID_ENCABEZADO = NID_ENCABEZADO,
                 L_CONFLICTO = L_CONFLICTO,
               };
            try
            {
                CONFLICTO_ENCABEZADO registroCheck = db.CONFLICTO_ENCABEZADO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CONFLICTO_ENCABEZADO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_CONFLICTO.ToString() + ", " + NID_RUBRO.ToString() + ", " + NID_ENCABEZADO.ToString() + ", " );
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
                            db.CONFLICTO_ENCABEZADO.Attach(registro);
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
            db.CONFLICTO_ENCABEZADO.Add(registro);
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
            db.CONFLICTO_ENCABEZADO.Remove(registro);
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
