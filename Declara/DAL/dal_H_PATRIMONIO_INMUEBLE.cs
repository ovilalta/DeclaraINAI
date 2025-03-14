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
    internal class dal_H_PATRIMONIO_INMUEBLE : _dal_base_Declara
    {

        H_PATRIMONIO_INMUEBLE registro;

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

        internal String E_UBICACION
        {
          get => registro.E_UBICACION; 
          set => registro.E_UBICACION = value; 
        }

        internal Decimal N_TERRENO
        {
          get => registro.N_TERRENO; 
          set => registro.N_TERRENO = value; 
        }

        internal Decimal N_CONSTRUCCION
        {
          get => registro.N_CONSTRUCCION; 
          set => registro.N_CONSTRUCCION = value; 
        }

        internal Decimal M_VALOR_INMUEBLE
        {
          get => registro.M_VALOR_INMUEBLE; 
          set => registro.M_VALOR_INMUEBLE = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_H_PATRIMONIO_INMUEBLE() => registro = new H_PATRIMONIO_INMUEBLE();

        internal dal_H_PATRIMONIO_INMUEBLE(H_PATRIMONIO_INMUEBLE oH_PATRIMONIO_INMUEBLE) : this(oH_PATRIMONIO_INMUEBLE.VID_NOMBRE, oH_PATRIMONIO_INMUEBLE.VID_FECHA, oH_PATRIMONIO_INMUEBLE.VID_HOMOCLAVE, oH_PATRIMONIO_INMUEBLE.NID_PATRIMONIO, oH_PATRIMONIO_INMUEBLE.NID_HISTORICO) { }

        internal dal_H_PATRIMONIO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO) { registro = db.H_PATRIMONIO_INMUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_H_PATRIMONIO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_TIPO, DateTime F_ADQUISICION, Int32 NID_USO, String E_UBICACION, Decimal N_TERRENO, Decimal N_CONSTRUCCION, Decimal M_VALOR_INMUEBLE, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new H_PATRIMONIO_INMUEBLE()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 NID_HISTORICO = NID_HISTORICO,
                 NID_TIPO = NID_TIPO,
                 F_ADQUISICION = F_ADQUISICION,
                 NID_USO = NID_USO,
                 E_UBICACION = E_UBICACION,
                 N_TERRENO = N_TERRENO,
                 N_CONSTRUCCION = N_CONSTRUCCION,
                 M_VALOR_INMUEBLE = M_VALOR_INMUEBLE,
               };
            try
            {
                H_PATRIMONIO_INMUEBLE registroCheck = db.H_PATRIMONIO_INMUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("H_PATRIMONIO_INMUEBLE",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_PATRIMONIO.ToString() + ", " + NID_HISTORICO.ToString() + ", " );
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
                            db.H_PATRIMONIO_INMUEBLE.Attach(registro);
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
            db.H_PATRIMONIO_INMUEBLE.Add(registro);
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
            db.H_PATRIMONIO_INMUEBLE.Remove(registro);
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
