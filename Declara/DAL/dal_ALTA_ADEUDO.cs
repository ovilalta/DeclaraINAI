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
    internal class dal_ALTA_ADEUDO : _dal_base_Declara
    {

        protected ALTA_ADEUDO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_ADEUDO => registro.NID_ADEUDO; 

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

        internal String V_LUGAR
        {
          get => registro.V_LUGAR; 
          set => registro.V_LUGAR = value; 
        }

        internal Int32 NID_INSTITUCION
        {
          get => registro.NID_INSTITUCION; 
          set => registro.NID_INSTITUCION = value; 
        }

        internal String V_OTRA
        {
          get => registro.V_OTRA; 
          set => registro.V_OTRA = value; 
        }

        internal Int32 NID_TIPO_ADEUDO
        {
          get => registro.NID_TIPO_ADEUDO; 
          set => registro.NID_TIPO_ADEUDO = value; 
        }

        internal DateTime F_ADEUDO
        {
          get => registro.F_ADEUDO; 
          set => registro.F_ADEUDO = value; 
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
        internal String E_RFC
        {
            get => registro.E_RFC;
            set => registro.E_RFC = value;
        }
        internal String E_OBSERVACIONES
        {
            get => registro.E_OBSERVACIONES;
            set => registro.E_OBSERVACIONES = value;
        }
        internal String V_TIPO_MONEDA
        {
            get => registro.V_TIPO_MONEDA;
            set => registro.V_TIPO_MONEDA = value;
        }
        internal String CID_TIPO_PERSONA_OTORGANTE
        {
            get => registro.CID_TIPO_PERSONA_OTORGANTE;
            set => registro.CID_TIPO_PERSONA_OTORGANTE = value;
        }
        internal String NID_TERCERO
        {
            get => registro.NID_TERCERO;
            set => registro.NID_TERCERO = value;
        }
        internal String E_NOMBRE_TERCERO
        {
            get => registro.E_NOMBRE_TERCERO;
            set => registro.E_NOMBRE_TERCERO = value;
        }
        internal String E_RFC_TERCERO
        {
            get => registro.E_RFC_TERCERO;
            set => registro.E_RFC_TERCERO = value;
        }
        internal Boolean L_AUTOGENERADO
        {
          get => registro.L_AUTOGENERADO; 
          set => registro.L_AUTOGENERADO = value; 
        }

        internal Int32 NID_PATRIMONIO
        {
          get => registro.NID_PATRIMONIO; 
          set => registro.NID_PATRIMONIO = value; 
        }


     #endregion


     #region *** Constructores ***

        internal dal_ALTA_ADEUDO() => registro = new ALTA_ADEUDO();

        internal dal_ALTA_ADEUDO(ALTA_ADEUDO oALTA_ADEUDO) : this(oALTA_ADEUDO.VID_NOMBRE, oALTA_ADEUDO.VID_FECHA, oALTA_ADEUDO.VID_HOMOCLAVE, oALTA_ADEUDO.NID_DECLARACION, oALTA_ADEUDO.NID_ADEUDO) { }

        //internal dal_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO) { registro = db.ALTA_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO) { registro = db.ALTA_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO); if (registro == null) ; }
        internal dal_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, String V_TIPO_MONEDA, String E_RFC, String E_OBSERVACIONES, String CID_TIPO_PERSONA_OTORGANTE, Boolean L_AUTOGENERADO, Int32 NID_PATRIMONIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
               registro = new ALTA_ADEUDO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_ADEUDO = NID_ADEUDO,
                 NID_PAIS = NID_PAIS,
                 CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                 V_LUGAR = V_LUGAR,
                 NID_INSTITUCION = NID_INSTITUCION,
                 V_OTRA = V_OTRA,
                 NID_TIPO_ADEUDO = NID_TIPO_ADEUDO,
                 F_ADEUDO = F_ADEUDO,
                 M_ORIGINAL = M_ORIGINAL,
                 M_SALDO = M_SALDO,
                 E_CUENTA = E_CUENTA,
                 V_TIPO_MONEDA = V_TIPO_MONEDA,
                 E_RFC = E_RFC,
                 E_OBSERVACIONES = E_OBSERVACIONES,
                 CID_TIPO_PERSONA_OTORGANTE = CID_TIPO_PERSONA_OTORGANTE,
                 L_AUTOGENERADO = L_AUTOGENERADO,
                 NID_PATRIMONIO = NID_PATRIMONIO,
               };
            try
            {
                ALTA_ADEUDO registroCheck = db.ALTA_ADEUDO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("ALTA_ADEUDO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_ADEUDO.ToString() + ", " );
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
                            db.ALTA_ADEUDO.Attach(registro);
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
            db.ALTA_ADEUDO.Add(registro);
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
            db.ALTA_ADEUDO.Remove(registro);
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
