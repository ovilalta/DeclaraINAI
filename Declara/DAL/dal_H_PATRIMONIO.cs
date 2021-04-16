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
    internal class dal_H_PATRIMONIO : _dal_base_Declara
    {

        H_PATRIMONIO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Int32 NID_HISTORICO => registro.NID_HISTORICO; 

        internal Int32 NID_TIPO
        {
          get => registro.NID_TIPO; 
          set => registro.NID_TIPO = value; 
        }

        internal Decimal M_VALOR
        {
          get => registro.M_VALOR; 
          set => registro.M_VALOR = value; 
        }

        internal Int32 NID_DEC_INCOR
        {
          get => registro.NID_DEC_INCOR; 
          set => registro.NID_DEC_INCOR = value; 
        }

        internal DateTime F_INCORPORACION
        {
          get => registro.F_INCORPORACION; 
          set => registro.F_INCORPORACION = value; 
        }

        internal Int32 NID_DEC_ULT_MOD
        {
          get => registro.NID_DEC_ULT_MOD; 
          set => registro.NID_DEC_ULT_MOD = value; 
        }

        internal DateTime F_MODIFICACION
        {
          get => registro.F_MODIFICACION; 
          set => registro.F_MODIFICACION = value; 
        }

        internal Boolean L_ACTIVO
        {
          get => registro.L_ACTIVO; 
          set => registro.L_ACTIVO = value; 
        }

        internal DateTime F_REGISTRO => registro.F_REGISTRO; 


     #endregion


     #region *** Constructores ***

        internal dal_H_PATRIMONIO() => registro = new H_PATRIMONIO();

        internal dal_H_PATRIMONIO(H_PATRIMONIO oH_PATRIMONIO) : this(oH_PATRIMONIO.VID_NOMBRE, oH_PATRIMONIO.VID_FECHA, oH_PATRIMONIO.VID_HOMOCLAVE, oH_PATRIMONIO.NID_PATRIMONIO, oH_PATRIMONIO.NID_HISTORICO) { }

        internal dal_H_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO) { registro = db.H_PATRIMONIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_H_PATRIMONIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_TIPO, Decimal M_VALOR, Int32 NID_DEC_INCOR, DateTime F_INCORPORACION, Int32 NID_DEC_ULT_MOD, DateTime F_MODIFICACION, Boolean L_ACTIVO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new H_PATRIMONIO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 NID_HISTORICO = NID_HISTORICO,
                 NID_TIPO = NID_TIPO,
                 M_VALOR = M_VALOR,
                 NID_DEC_INCOR = NID_DEC_INCOR,
                 F_INCORPORACION = F_INCORPORACION,
                 NID_DEC_ULT_MOD = NID_DEC_ULT_MOD,
                 F_MODIFICACION = F_MODIFICACION,
                 L_ACTIVO = L_ACTIVO,
                 F_REGISTRO = DateTime.Now,
               };
            try
            {
                H_PATRIMONIO registroCheck = db.H_PATRIMONIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("H_PATRIMONIO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_PATRIMONIO.ToString() + ", " + NID_HISTORICO.ToString() + ", " );
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
                            db.H_PATRIMONIO.Attach(registro);
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
            db.H_PATRIMONIO.Add(registro);
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
            db.H_PATRIMONIO.Remove(registro);
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
