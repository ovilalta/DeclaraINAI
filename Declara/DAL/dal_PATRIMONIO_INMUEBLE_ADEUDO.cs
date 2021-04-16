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
    internal class dal_PATRIMONIO_INMUEBLE_ADEUDO : _dal_base_Declara
    {

        PATRIMONIO_INMUEBLE_ADEUDO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_PATRIMONIO => registro.NID_PATRIMONIO; 

        internal Int32 NID_PATRIMONIO_ADEUDO => registro.NID_PATRIMONIO_ADEUDO; 


     #endregion


     #region *** Constructores ***

        internal dal_PATRIMONIO_INMUEBLE_ADEUDO() => registro = new PATRIMONIO_INMUEBLE_ADEUDO();

        internal dal_PATRIMONIO_INMUEBLE_ADEUDO(PATRIMONIO_INMUEBLE_ADEUDO oPATRIMONIO_INMUEBLE_ADEUDO) : this(oPATRIMONIO_INMUEBLE_ADEUDO.VID_NOMBRE, oPATRIMONIO_INMUEBLE_ADEUDO.VID_FECHA, oPATRIMONIO_INMUEBLE_ADEUDO.VID_HOMOCLAVE, oPATRIMONIO_INMUEBLE_ADEUDO.NID_PATRIMONIO, oPATRIMONIO_INMUEBLE_ADEUDO.NID_PATRIMONIO_ADEUDO) { }

        internal dal_PATRIMONIO_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO) { registro = db.PATRIMONIO_INMUEBLE_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_PATRIMONIO_INMUEBLE_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_PATRIMONIO, Int32 NID_PATRIMONIO_ADEUDO, System.Nullable<Boolean> L_DIF, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new PATRIMONIO_INMUEBLE_ADEUDO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 NID_PATRIMONIO_ADEUDO = NID_PATRIMONIO_ADEUDO,
                 L_DIF = L_DIF,
               };
            try
            {
                PATRIMONIO_INMUEBLE_ADEUDO registroCheck = db.PATRIMONIO_INMUEBLE_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_PATRIMONIO, NID_PATRIMONIO_ADEUDO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("PATRIMONIO_INMUEBLE_ADEUDO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_PATRIMONIO.ToString() + ", " + NID_PATRIMONIO_ADEUDO.ToString() + ", " );
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
                            db.PATRIMONIO_INMUEBLE_ADEUDO.Attach(registro);
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
            db.PATRIMONIO_INMUEBLE_ADEUDO.Add(registro);
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
            db.PATRIMONIO_INMUEBLE_ADEUDO.Remove(registro);
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
