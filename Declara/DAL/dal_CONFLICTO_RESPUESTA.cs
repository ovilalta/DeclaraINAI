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
    internal class dal_CONFLICTO_RESPUESTA : _dal_base_Declara
    {

        CONFLICTO_RESPUESTA registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_CONFLICTO => registro.NID_CONFLICTO; 

        internal Int32 NID_RUBRO => registro.NID_RUBRO; 

        internal Int32 NID_ENCABEZADO => registro.NID_ENCABEZADO; 

        internal Int32 NID_PREGUNTA => registro.NID_PREGUNTA; 

        internal String V_RESPUESTA
        {
          get => registro.V_RESPUESTA; 
          set => registro.V_RESPUESTA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CONFLICTO_RESPUESTA() => registro = new CONFLICTO_RESPUESTA();

        internal dal_CONFLICTO_RESPUESTA(CONFLICTO_RESPUESTA oCONFLICTO_RESPUESTA) : this(oCONFLICTO_RESPUESTA.VID_NOMBRE, oCONFLICTO_RESPUESTA.VID_FECHA, oCONFLICTO_RESPUESTA.VID_HOMOCLAVE, oCONFLICTO_RESPUESTA.NID_CONFLICTO, oCONFLICTO_RESPUESTA.NID_RUBRO, oCONFLICTO_RESPUESTA.NID_ENCABEZADO, oCONFLICTO_RESPUESTA.NID_PREGUNTA) { }

        internal dal_CONFLICTO_RESPUESTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, Int32 NID_PREGUNTA) { registro = db.CONFLICTO_RESPUESTA.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CONFLICTO_RESPUESTA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_CONFLICTO, Int32 NID_RUBRO, Int32 NID_ENCABEZADO, Int32 NID_PREGUNTA, String V_RESPUESTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CONFLICTO_RESPUESTA()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_CONFLICTO = NID_CONFLICTO,
                 NID_RUBRO = NID_RUBRO,
                 NID_ENCABEZADO = NID_ENCABEZADO,
                 NID_PREGUNTA = NID_PREGUNTA,
                 V_RESPUESTA = V_RESPUESTA,
               };
            try
            {
                CONFLICTO_RESPUESTA registroCheck = db.CONFLICTO_RESPUESTA.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_CONFLICTO, NID_RUBRO, NID_ENCABEZADO, NID_PREGUNTA);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CONFLICTO_RESPUESTA",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_CONFLICTO.ToString() + ", " + NID_RUBRO.ToString() + ", " + NID_ENCABEZADO.ToString() + ", " + NID_PREGUNTA.ToString() + ", " );
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
                            db.CONFLICTO_RESPUESTA.Attach(registro);
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
            db.CONFLICTO_RESPUESTA.Add(registro);
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
            db.CONFLICTO_RESPUESTA.Remove(registro);
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
