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
    internal class dal_H_PATRIMONIO_ADEUDO : _dal_base_Declara
    {

        H_PATRIMONIO_ADEUDO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Int32 NID_HISTORICO => registro.NID_HISTORICO; 

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

        internal Int32 NID_INSTITUCION
        {
          get => registro.NID_INSTITUCION; 
          set => registro.NID_INSTITUCION = value; 
        }

        internal Int32 NID_TIPO_ADEUDO
        {
          get => registro.NID_TIPO_ADEUDO; 
          set => registro.NID_TIPO_ADEUDO = value; 
        }

        internal Decimal M_ORIGINAL
        {
          get => registro.M_ORIGINAL; 
          set => registro.M_ORIGINAL = value; 
        }

        internal Decimal M_SALDO
        {
          get => registro.M_SALDO; 
          set => registro.M_SALDO = value; 
        }

        internal String E_CUENTA
        {
          get => registro.E_CUENTA; 
          set => registro.E_CUENTA = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_H_PATRIMONIO_ADEUDO() => registro = new H_PATRIMONIO_ADEUDO();

        internal dal_H_PATRIMONIO_ADEUDO(H_PATRIMONIO_ADEUDO oH_PATRIMONIO_ADEUDO) : this(oH_PATRIMONIO_ADEUDO.VID_NOMBRE, oH_PATRIMONIO_ADEUDO.VID_FECHA, oH_PATRIMONIO_ADEUDO.VID_HOMOCLAVE, oH_PATRIMONIO_ADEUDO.NID_PATRIMONIO, oH_PATRIMONIO_ADEUDO.NID_HISTORICO) { }

        internal dal_H_PATRIMONIO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO) { registro = db.H_PATRIMONIO_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_H_PATRIMONIO_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_HISTORICO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_INSTITUCION, Int32 NID_TIPO_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new H_PATRIMONIO_ADEUDO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 NID_HISTORICO = NID_HISTORICO,
                 NID_PAIS = NID_PAIS,
                 CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                 NID_INSTITUCION = NID_INSTITUCION,
                 NID_TIPO_ADEUDO = NID_TIPO_ADEUDO,
                 M_ORIGINAL = M_ORIGINAL,
                 M_SALDO = M_SALDO,
                 E_CUENTA = E_CUENTA,
               };
            try
            {
                H_PATRIMONIO_ADEUDO registroCheck = db.H_PATRIMONIO_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_HISTORICO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("H_PATRIMONIO_ADEUDO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_PATRIMONIO.ToString() + ", " + NID_HISTORICO.ToString() + ", " );
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
                            db.H_PATRIMONIO_ADEUDO.Attach(registro);
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
            db.H_PATRIMONIO_ADEUDO.Add(registro);
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
            db.H_PATRIMONIO_ADEUDO.Remove(registro);
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
