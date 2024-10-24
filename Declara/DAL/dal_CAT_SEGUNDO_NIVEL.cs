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
    internal class dal_CAT_SEGUNDO_NIVEL : _dal_base_Declara
    {

        CAT_SEGUNDO_NIVEL registro;

     #region *** Atributos ***

        internal String VID_PRIMER_NIVEL => registro.VID_PRIMER_NIVEL; 

        internal String VID_SEGUNDO_NIVEL => registro.VID_SEGUNDO_NIVEL; 

        internal String V_SEGUNDO_NIVEL
        {
          get => registro.V_SEGUNDO_NIVEL; 
          set => registro.V_SEGUNDO_NIVEL = value; 
        }

        internal String C_INICIO
        {
          get => registro.C_INICIO; 
          set => registro.C_INICIO = value; 
        }

        internal String C_FIN
        {
          get => registro.C_FIN; 
          set => registro.C_FIN = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_CAT_SEGUNDO_NIVEL() => registro = new CAT_SEGUNDO_NIVEL();

        internal dal_CAT_SEGUNDO_NIVEL(CAT_SEGUNDO_NIVEL oCAT_SEGUNDO_NIVEL) : this(oCAT_SEGUNDO_NIVEL.VID_PRIMER_NIVEL, oCAT_SEGUNDO_NIVEL.VID_SEGUNDO_NIVEL) { }

        internal dal_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL) { registro = db.CAT_SEGUNDO_NIVEL.Find(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL); if (registro == null) throw new RowNotFoundException(); }

        internal dal_CAT_SEGUNDO_NIVEL(String VID_PRIMER_NIVEL, String VID_SEGUNDO_NIVEL, String V_SEGUNDO_NIVEL, String C_INICIO, String C_FIN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new CAT_SEGUNDO_NIVEL()
               {
                 VID_PRIMER_NIVEL = VID_PRIMER_NIVEL,
                 VID_SEGUNDO_NIVEL = VID_SEGUNDO_NIVEL,
                 V_SEGUNDO_NIVEL = V_SEGUNDO_NIVEL,
                 C_INICIO = C_INICIO,
                 C_FIN = C_FIN,
               };
            try
            {
                CAT_SEGUNDO_NIVEL registroCheck = db.CAT_SEGUNDO_NIVEL.Find(VID_PRIMER_NIVEL, VID_SEGUNDO_NIVEL);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("CAT_SEGUNDO_NIVEL",VID_PRIMER_NIVEL + ", " + VID_SEGUNDO_NIVEL + ", " );
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
                            db.CAT_SEGUNDO_NIVEL.Attach(registro);
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
            db.CAT_SEGUNDO_NIVEL.Add(registro);
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
            db.CAT_SEGUNDO_NIVEL.Remove(registro);
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
