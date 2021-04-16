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
    internal class dal_H_PATRIMONIO_VEHICULO : _dal_base_Declara
    {

        H_PATRIMONIO_VEHICULO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Int32 NID_HISTORICO => registro.NID_HISTORICO; 

        internal Int32 NID_MARCA
        {
          get => registro.NID_MARCA; 
          set => registro.NID_MARCA = value; 
        }

        internal String C_MODELO
        {
          get => registro.C_MODELO; 
          set => registro.C_MODELO = value; 
        }

        internal String V_DESCRIPCION
        {
          get => registro.V_DESCRIPCION; 
          set => registro.V_DESCRIPCION = value; 
        }

        internal DateTime F_ADQUISICION
        {
          get => registro.F_ADQUISICION; 
          set => registro.F_ADQUISICION = value; 
        }

        internal Int32 NID_USO
        {
          get => registro.NID_USO; 
          set => registro.NID_USO = value; 
        }

        internal Decimal M_VALOR_VEHICULO
        {
          get => registro.M_VALOR_VEHICULO; 
          set => registro.M_VALOR_VEHICULO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_H_PATRIMONIO_VEHICULO() => registro = new H_PATRIMONIO_VEHICULO();

        internal dal_H_PATRIMONIO_VEHICULO(H_PATRIMONIO_VEHICULO oH_PATRIMONIO_VEHICULO) : this(oH_PATRIMONIO_VEHICULO.VID_NOMBRE, oH_PATRIMONIO_VEHICULO.VID_FECHA, oH_PATRIMONIO_VEHICULO.VID_HOMOCLAVE, oH_PATRIMONIO_VEHICULO.NID_PATRIMONIO, oH_PATRIMONIO_VEHICULO.NID_HISTORICO) { }

        internal dal_H_PATRIMONIO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO) { registro = db.H_PATRIMONIO_VEHICULO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_H_PATRIMONIO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, DateTime F_ADQUISICION, Int32 NID_USO, Decimal M_VALOR_VEHICULO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new H_PATRIMONIO_VEHICULO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 NID_HISTORICO = NID_HISTORICO,
                 NID_MARCA = NID_MARCA,
                 C_MODELO = C_MODELO,
                 V_DESCRIPCION = V_DESCRIPCION,
                 F_ADQUISICION = F_ADQUISICION,
                 NID_USO = NID_USO,
                 M_VALOR_VEHICULO = M_VALOR_VEHICULO,
               };
            try
            {
                H_PATRIMONIO_VEHICULO registroCheck = db.H_PATRIMONIO_VEHICULO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("H_PATRIMONIO_VEHICULO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_PATRIMONIO.ToString() + ", " + NID_HISTORICO.ToString() + ", " );
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
                            db.H_PATRIMONIO_VEHICULO.Attach(registro);
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
            db.H_PATRIMONIO_VEHICULO.Add(registro);
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
            db.H_PATRIMONIO_VEHICULO.Remove(registro);
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
