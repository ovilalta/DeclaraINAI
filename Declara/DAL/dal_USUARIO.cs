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
    internal class dal_USUARIO : _dal_base_Declara
    {

        USUARIO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal String V_PASSWORD
        {
          get => registro.V_PASSWORD; 
          set => registro.V_PASSWORD = value; 
        }

        internal String V_NOMBRE
        {
          get => registro.V_NOMBRE; 
          set => registro.V_NOMBRE = value; 
        }

        internal String V_PRIMER_A
        {
          get => registro.V_PRIMER_A; 
          set => registro.V_PRIMER_A = value; 
        }

        internal String V_SEGUNDO_A
        {
          get => registro.V_SEGUNDO_A; 
          set => registro.V_SEGUNDO_A = value; 
        }

        internal DateTime F_NACIMIENTO
        {
          get => registro.F_NACIMIENTO; 
          set => registro.F_NACIMIENTO = value; 
        }

        internal String V_ACUSE
        {
          get => registro.V_ACUSE; 
          set => registro.V_ACUSE = value; 
        }

        internal Boolean L_ACTIVO
        {
          get => registro.L_ACTIVO; 
          set => registro.L_ACTIVO = value; 
        }

        internal DateTime F_INGRESO_INSTITUTO
        {
          get => registro.F_INGRESO_INSTITUTO; 
          set => registro.F_INGRESO_INSTITUTO = value; 
        }

        internal DateTime F_REGISTRO => registro.F_REGISTRO;

        internal Boolean NVO_INGRESO
        {
            get => registro.NVO_INGRESO;
            set => registro.NVO_INGRESO = value;
        }

        internal Boolean OBL_DECLARACION
        {
            get => registro.OBL_DECLARACION;
            set => registro.OBL_DECLARACION = value;
        }

        #endregion


        #region *** Constructores ***

        internal dal_USUARIO() => registro = new USUARIO();

        internal dal_USUARIO(USUARIO oUSUARIO) : this(oUSUARIO.VID_NOMBRE, oUSUARIO.VID_FECHA, oUSUARIO.VID_HOMOCLAVE) { }

        internal dal_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE) { registro = db.USUARIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE); if (registro == null) throw new RowNotFoundException(); }

        internal dal_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_PASSWORD, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_ACUSE, Boolean L_ACTIVO, DateTime F_INGRESO_INSTITUTO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new USUARIO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 V_PASSWORD = V_PASSWORD,
                 V_NOMBRE = V_NOMBRE,
                 V_PRIMER_A = V_PRIMER_A,
                 V_SEGUNDO_A = V_SEGUNDO_A,
                 F_NACIMIENTO = F_NACIMIENTO,
                 V_ACUSE = V_ACUSE,
                 L_ACTIVO = L_ACTIVO,
                 F_INGRESO_INSTITUTO = F_INGRESO_INSTITUTO,
                 F_REGISTRO = DateTime.Now,
               };
            try
            {
                USUARIO registroCheck = db.USUARIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("USUARIO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " );
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
                            registro.F_REGISTRO = registroCheck.F_REGISTRO;
                            db.USUARIO.Attach(registro);
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

        internal dal_USUARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, String V_PASSWORD, String V_NOMBRE, String V_PRIMER_A, String V_SEGUNDO_A, DateTime F_NACIMIENTO, String V_ACUSE, Boolean L_ACTIVO, DateTime F_INGRESO_INSTITUTO, Boolean NVO_INGRESO, Boolean OBL_DECLARACION, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new USUARIO()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                V_PASSWORD = V_PASSWORD,
                V_NOMBRE = V_NOMBRE,
                V_PRIMER_A = V_PRIMER_A,
                V_SEGUNDO_A = V_SEGUNDO_A,
                F_NACIMIENTO = F_NACIMIENTO,
                V_ACUSE = V_ACUSE,
                L_ACTIVO = L_ACTIVO,
                F_INGRESO_INSTITUTO = F_INGRESO_INSTITUTO,
                F_REGISTRO = DateTime.Now,
                NVO_INGRESO = NVO_INGRESO,
                OBL_DECLARACION = OBL_DECLARACION,
            };
            try
            {
                USUARIO registroCheck = db.USUARIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("USUARIO", VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", ");
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
                            registro.F_REGISTRO = registroCheck.F_REGISTRO;
                            db.USUARIO.Attach(registro);
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
            db.USUARIO.Add(registro);
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
            db.USUARIO.Remove(registro);
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
