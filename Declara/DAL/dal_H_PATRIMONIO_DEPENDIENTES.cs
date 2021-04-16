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
    //internal class dal_H_PATRIMONIO_DEPENDIENTES : _dal_base_Declara
    //{

    //    H_PATRIMONIO_DEPENDIENTES registro;

    // #region *** Atributos ***

    //    internal String VID_NOMBRE => registro.VID_NOMBRE; 

    //    internal String VID_FECHA => registro.VID_FECHA; 

    //    internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

    //    internal Int32 NID_DEPENDIENTE => registro.NID_DEPENDIENTE; 

    //    internal Int32 NID_TIPO_DEPENDIENTE
    //    {
    //      get => registro.NID_TIPO_DEPENDIENTE; 
    //      set => registro.NID_TIPO_DEPENDIENTE = value; 
    //    }

    //    internal String E_NOMBRE
    //    {
    //      get => registro.E_NOMBRE; 
    //      set => registro.E_NOMBRE = value; 
    //    }

    //    internal String E_PRIMER_A
    //    {
    //      get => registro.E_PRIMER_A; 
    //      set => registro.E_PRIMER_A = value; 
    //    }

    //    internal String E_SEGUNDO_A
    //    {
    //      get => registro.E_SEGUNDO_A; 
    //      set => registro.E_SEGUNDO_A = value; 
    //    }

    //    internal DateTime F_NACIMIENTO
    //    {
    //      get => registro.F_NACIMIENTO; 
    //      set => registro.F_NACIMIENTO = value; 
    //    }

    //    internal String E_RFC
    //    {
    //      get => registro.E_RFC; 
    //      set => registro.E_RFC = value; 
    //    }

    //    internal Int32 NID_HISTORICO
    //    {
    //      get => registro.NID_HISTORICO; 
    //      set => registro.NID_HISTORICO = value; 
    //    }


    // #endregion


    // #region *** Constructores ***

    //    internal dal_H_PATRIMONIO_DEPENDIENTES() => registro = new H_PATRIMONIO_DEPENDIENTES();

    //    internal dal_H_PATRIMONIO_DEPENDIENTES(H_PATRIMONIO_DEPENDIENTES oH_PATRIMONIO_DEPENDIENTES) : this(oH_PATRIMONIO_DEPENDIENTES.VID_NOMBRE, oH_PATRIMONIO_DEPENDIENTES.VID_FECHA, oH_PATRIMONIO_DEPENDIENTES.VID_HOMOCLAVE, oH_PATRIMONIO_DEPENDIENTES.NID_DEPENDIENTE) { }

    //    internal dal_H_PATRIMONIO_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DEPENDIENTE) { registro = db.H_PATRIMONIO_DEPENDIENTES.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DEPENDIENTE); if (registro == null) throw new RowNotFoundException(); }

    //    internal dal_H_PATRIMONIO_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Int32 NID_HISTORICO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
    //    {
    //           registro = new H_PATRIMONIO_DEPENDIENTES()
    //           {
    //             VID_NOMBRE = VID_NOMBRE,
    //             VID_FECHA = VID_FECHA,
    //             VID_HOMOCLAVE = VID_HOMOCLAVE,
    //             NID_DEPENDIENTE = NID_DEPENDIENTE,
    //             NID_TIPO_DEPENDIENTE = NID_TIPO_DEPENDIENTE,
    //             E_NOMBRE = E_NOMBRE,
    //             E_PRIMER_A = E_PRIMER_A,
    //             E_SEGUNDO_A = E_SEGUNDO_A,
    //             F_NACIMIENTO = F_NACIMIENTO,
    //             E_RFC = E_RFC,
    //             NID_HISTORICO = NID_HISTORICO,
    //           };
    //        try
    //        {
    //            H_PATRIMONIO_DEPENDIENTES registroCheck = db.H_PATRIMONIO_DEPENDIENTES.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DEPENDIENTE);
    //            switch (lOpcionesRegistroExistente)
    //            {
    //                //Arrojar Exepción de llave primaria
    //                case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
    //                    if (registroCheck == null) insert();
    //                    else throw new ExistingPrimaryKeyException("H_PATRIMONIO_DEPENDIENTES",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DEPENDIENTE.ToString() + ", " );
    //                    break;

    //                //Usar registro existente
    //                case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting:
    //                    if (registroCheck == null) insert();
    //                    else registro = registroCheck;
    //                    break;

    //                //Actualizar registro existente
    //                case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting:
    //                    if (registroCheck == null) insert();
    //                    else
    //                    {
    //                        db.H_PATRIMONIO_DEPENDIENTES.Attach(registro);
    //                        ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(registro, EntityState.Modified);
    //                        update();
    //                    }
    //                    break;

    //               //Opcion no Implementada
    //                default:
    //                    throw new NotImplementedException();
    //            }
    //        }
    //          catch (Exception ex)
    //           {
    //               registro = null;
    //                throw ex;
    //           }
    //    }


    // #endregion


    // #region *** Metodos ***

    //    internal void insert()
    //    {
    //        db.H_PATRIMONIO_DEPENDIENTES.Add(registro);
    //        SaveChanges(true);
    //    }

    //    internal void update()
    //    {
    //        if (db.Entry(registro).State == EntityState.Modified)
    //        {
    //            SaveChanges(false);
    //        }
    //    }

    //    internal void delete()
    //    {
    //        db.H_PATRIMONIO_DEPENDIENTES.Remove(registro);
    //        SaveChanges(null);
    //        if (db.Entry(registro).State == EntityState.Detached) registro = null;
    //    }

    //    internal void reload()
    //    {
    //        db.Entry(registro).Reload();
    //        _lEsNuevoRegistro = false;
    //    }

    //    private void SaveChanges(System.Nullable<Boolean> q)
    //    {
    //        db.SaveChanges();
    //       _lEsNuevoRegistro = q;
    //    }


    // #endregion

    //}
}
