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
    internal class dal_DECLARACION_DOM_LABORAL : _dal_base_Declara
    {

        DECLARACION_DOM_LABORAL registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal String C_CODIGO_POSTAL
        {
          get => registro.C_CODIGO_POSTAL; 
          set => registro.C_CODIGO_POSTAL = value; 
        }

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

        internal String V_COLONIA
        {
          get => registro.V_COLONIA; 
          set => registro.V_COLONIA = value; 
        }

        internal String V_DOMICILIO
        {
          get => registro.V_DOMICILIO; 
          set => registro.V_DOMICILIO = value; 
        }

        internal String V_CORREO_LABORAL
        {
          get => registro.V_CORREO_LABORAL; 
          set => registro.V_CORREO_LABORAL = value; 
        }

        internal String V_TEL_LABORAL
        {
          get => registro.V_TEL_LABORAL; 
          set => registro.V_TEL_LABORAL = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_DECLARACION_DOM_LABORAL() => registro = new DECLARACION_DOM_LABORAL();

        internal dal_DECLARACION_DOM_LABORAL(DECLARACION_DOM_LABORAL oDECLARACION_DOM_LABORAL) : this(oDECLARACION_DOM_LABORAL.VID_NOMBRE, oDECLARACION_DOM_LABORAL.VID_FECHA, oDECLARACION_DOM_LABORAL.VID_HOMOCLAVE, oDECLARACION_DOM_LABORAL.NID_DECLARACION) { }

        internal dal_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) { registro = db.DECLARACION_DOM_LABORAL.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_DECLARACION_DOM_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_CORREO_LABORAL, String V_TEL_LABORAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new DECLARACION_DOM_LABORAL()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 C_CODIGO_POSTAL = C_CODIGO_POSTAL,
                 NID_PAIS = NID_PAIS,
                 CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                 CID_MUNICIPIO = CID_MUNICIPIO,
                 V_COLONIA = V_COLONIA,
                 V_DOMICILIO = V_DOMICILIO,
                 V_CORREO_LABORAL = V_CORREO_LABORAL,
                 V_TEL_LABORAL = V_TEL_LABORAL,
               };
            try
            {
                DECLARACION_DOM_LABORAL registroCheck = db.DECLARACION_DOM_LABORAL.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("DECLARACION_DOM_LABORAL",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " );
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
                            db.DECLARACION_DOM_LABORAL.Attach(registro);
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
            db.DECLARACION_DOM_LABORAL.Add(registro);
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
            db.DECLARACION_DOM_LABORAL.Remove(registro);
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
