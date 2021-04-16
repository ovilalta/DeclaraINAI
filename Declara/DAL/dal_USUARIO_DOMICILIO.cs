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
    internal class dal_USUARIO_DOMICILIO : _dal_base_Declara
    {

        USUARIO_DOMICILIO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DOMICILIO => registro.NID_DOMICILIO; 

        internal Int32 NID_PAIS
        {
          get => registro.NID_PAIS; 
          set => registro.NID_PAIS = value; 
        }

        internal String CID_ENTIDAD_FEDERATIVA
        {
          get => registro.CID_ENTIDAD_FEDERATIVA; 
          set => registro.CID_ENTIDAD_FEDERATIVA = value; 
        }

        internal String CID_MUNICIPIO
        {
          get => registro.CID_MUNICIPIO; 
          set => registro.CID_MUNICIPIO = value; 
        }

        internal String C_CODIGO_POSTAL
        {
          get => registro.C_CODIGO_POSTAL; 
          set => registro.C_CODIGO_POSTAL = value; 
        }

        internal String E_DIRECCION
        {
          get => registro.E_DIRECCION; 
          set => registro.E_DIRECCION = value; 
        }

        internal Int32 NID_TIPO_DOMICILIO
        {
          get => registro.NID_TIPO_DOMICILIO; 
          set => registro.NID_TIPO_DOMICILIO = value; 
        }

        internal Boolean L_ACTIVO
        {
          get => registro.L_ACTIVO; 
          set => registro.L_ACTIVO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_USUARIO_DOMICILIO() => registro = new USUARIO_DOMICILIO();

        internal dal_USUARIO_DOMICILIO(USUARIO_DOMICILIO oUSUARIO_DOMICILIO) : this(oUSUARIO_DOMICILIO.VID_NOMBRE, oUSUARIO_DOMICILIO.VID_FECHA, oUSUARIO_DOMICILIO.VID_HOMOCLAVE, oUSUARIO_DOMICILIO.NID_DOMICILIO) { }

        internal dal_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DOMICILIO) { registro = db.USUARIO_DOMICILIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_USUARIO_DOMICILIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DOMICILIO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String C_CODIGO_POSTAL, String E_DIRECCION, Int32 NID_TIPO_DOMICILIO, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new USUARIO_DOMICILIO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DOMICILIO = NID_DOMICILIO,
                 NID_PAIS = NID_PAIS,
                 CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                 CID_MUNICIPIO = CID_MUNICIPIO,
                 C_CODIGO_POSTAL = C_CODIGO_POSTAL,
                 E_DIRECCION = E_DIRECCION,
                 NID_TIPO_DOMICILIO = NID_TIPO_DOMICILIO,
                 L_ACTIVO = L_ACTIVO,
               };
            try
            {
                USUARIO_DOMICILIO registroCheck = db.USUARIO_DOMICILIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DOMICILIO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("USUARIO_DOMICILIO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DOMICILIO.ToString() + ", " );
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
                            db.USUARIO_DOMICILIO.Attach(registro);
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
            db.USUARIO_DOMICILIO.Add(registro);
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
            db.USUARIO_DOMICILIO.Remove(registro);
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
