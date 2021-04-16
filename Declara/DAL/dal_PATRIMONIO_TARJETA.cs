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
    internal class dal_PATRIMONIO_TARJETA : _dal_base_Declara
    {

        PATRIMONIO_TARJETA registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        //internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        //internal String E_NUMERO => registro.E_NUMERO; 

        internal Int32 NID_INSTITUCION
        {
          get => registro.NID_INSTITUCION; 
          set => registro.NID_INSTITUCION = value; 
        }

        //internal String V_NUMERO_CORTO
        //{
        //  get => registro.V_NUMERO_CORTO; 
        //  set => registro.V_NUMERO_CORTO = value; 
        //}

        internal Decimal M_SALDO
        {
          get => registro.M_SALDO; 
          set => registro.M_SALDO = value; 
        }

        //internal Boolean L_ACTIVA
        //{
        //  get => registro.L_ACTIVA; 
        //  set => registro.L_ACTIVA = value; 
        //}


     #endregion


     #region *** Constructores ***

        internal dal_PATRIMONIO_TARJETA() => registro = new PATRIMONIO_TARJETA();

        //internal dal_PATRIMONIO_TARJETA(PATRIMONIO_TARJETA oPATRIMONIO_TARJETA) : this(oPATRIMONIO_TARJETA.VID_NOMBRE, oPATRIMONIO_TARJETA.VID_FECHA, oPATRIMONIO_TARJETA.VID_HOMOCLAVE, oPATRIMONIO_TARJETA.NID_DECLARACION, oPATRIMONIO_TARJETA.E_NUMERO) { }

        internal dal_PATRIMONIO_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO) { registro = db.PATRIMONIO_TARJETA.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_PATRIMONIO_TARJETA(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String E_NUMERO, Int32 NID_INSTITUCION, String V_NUMERO_CORTO, Decimal M_SALDO, Boolean L_ACTIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new PATRIMONIO_TARJETA()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 //NID_DECLARACION = NID_DECLARACION,
                 //E_NUMERO = E_NUMERO,
                 //NID_INSTITUCION = NID_INSTITUCION,
                 //V_NUMERO_CORTO = V_NUMERO_CORTO,
                 //M_SALDO = M_SALDO,
                 //L_ACTIVA = L_ACTIVA,
               };
            try
            {
                PATRIMONIO_TARJETA registroCheck = db.PATRIMONIO_TARJETA.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, E_NUMERO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("PATRIMONIO_TARJETA",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + E_NUMERO + ", " );
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
                            db.PATRIMONIO_TARJETA.Attach(registro);
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
            db.PATRIMONIO_TARJETA.Add(registro);
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
            db.PATRIMONIO_TARJETA.Remove(registro);
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
