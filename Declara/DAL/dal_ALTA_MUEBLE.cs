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
    internal class dal_ALTA_MUEBLE : _dal_base_Declara
    {

       protected ALTA_MUEBLE registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_MUEBLE => registro.NID_MUEBLE; 

        internal Int32 NID_TIPO
        {
          get => registro.NID_TIPO; 
          set => registro.NID_TIPO = value; 
        }

        internal String E_ESPECIFICACION
        {
          get => registro.E_ESPECIFICACION; 
          set => registro.E_ESPECIFICACION = value; 
        }

        internal Decimal M_VALOR
        {
          get => registro.M_VALOR; 
          set => registro.M_VALOR = value; 
        }

        internal Int32 NID_PATRIMONIO
        {
          get => registro.NID_PATRIMONIO; 
          set => registro.NID_PATRIMONIO = value; 
        }

        internal Boolean L_CREDITO
        {
          get => registro.L_CREDITO; 
          set => registro.L_CREDITO = value; 
        }

        internal DateTime F_ADQUISICION
        {
          get => registro.F_ADQUISICION; 
          set => registro.F_ADQUISICION = value; 
        }

        internal String V_TIPO_MONEDA
        {
            get => registro.V_TIPO_MONEDA;
            set => registro.V_TIPO_MONEDA = value;
        }

        internal String CID_TIPO_PERSONA_TRANSMISOR
        {
            get => registro.CID_TIPO_PERSONA_TRANSMISOR;
            set => registro.CID_TIPO_PERSONA_TRANSMISOR = value;
        }

        internal String E_NOMBRE_TRANSMISOR
        {
            get => registro.E_NOMBRE_TRANSMISOR;
            set => registro.E_NOMBRE_TRANSMISOR = value;
        }

        internal String E_RFC_TRANSMISOR
        {
            get => registro.E_RFC_TRANSMISOR;
            set => registro.E_RFC_TRANSMISOR = value;
        }


        internal Int32 NID_RELACION_TRANSMISOR
        {
            get => registro.NID_RELACION_TRANSMISOR;
            set => registro.NID_RELACION_TRANSMISOR = value;
        }
        internal System.Nullable<Int32> NID_FORMA_ADQUISICION
        {
            get => registro.NID_FORMA_ADQUISICION;
            set => registro.NID_FORMA_ADQUISICION = value;
        }
        internal System.Nullable<Int32> NID_FORMA_PAGO
        {
            get => registro.NID_FORMA_PAGO;
            set => registro.NID_FORMA_PAGO = value;
        }
        internal String E_OBSERVACIONES
        {
            get => registro.E_OBSERVACIONES;
            set => registro.E_OBSERVACIONES = value;
        }

#endregion


        #region *** Constructores ***

        internal dal_ALTA_MUEBLE() => registro = new ALTA_MUEBLE();

        internal dal_ALTA_MUEBLE(ALTA_MUEBLE oALTA_MUEBLE) : this(oALTA_MUEBLE.VID_NOMBRE, oALTA_MUEBLE.VID_FECHA, oALTA_MUEBLE.VID_HOMOCLAVE, oALTA_MUEBLE.NID_DECLARACION, oALTA_MUEBLE.NID_MUEBLE) { }

        internal dal_ALTA_MUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_MUEBLE) { registro = db.ALTA_MUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE); if (registro == null) throw new RowNotFoundException(); }

        internal dal_ALTA_MUEBLE(String VID_NOMBRE
                                , String VID_FECHA
                                , String VID_HOMOCLAVE
                                , Int32 NID_DECLARACION
                                , Int32 NID_MUEBLE
                                , Int32 NID_TIPO
                                , String E_ESPECIFICACION
                                , Decimal M_VALOR
                                , Int32 NID_PATRIMONIO
                                , Boolean L_CREDITO
                                , DateTime F_ADQUISICION
                                , String CID_TIPO_PERSONA_TRANSMISOR
                                , String E_NOMBRE_TRANSMISOR
                                , String E_RFC_TRANSMISOR
                                , Int32 NID_RELACION_TRANSMISOR
                                , String V_TIPO_MONEDA
                                , Int32 NID_FORMA_ADQUISICION
                                , Int32 NID_FORMA_PAGO
                                , String E_OBSERVACIONES
                                , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
                                )
        {
               registro = new ALTA_MUEBLE()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_MUEBLE = NID_MUEBLE,
                 NID_TIPO = NID_TIPO,
                 E_ESPECIFICACION = E_ESPECIFICACION,
                 M_VALOR = M_VALOR,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 L_CREDITO = L_CREDITO,
                 F_ADQUISICION = F_ADQUISICION,
                 CID_TIPO_PERSONA_TRANSMISOR = CID_TIPO_PERSONA_TRANSMISOR,
                 E_NOMBRE_TRANSMISOR = E_NOMBRE_TRANSMISOR,
                 E_RFC_TRANSMISOR = E_RFC_TRANSMISOR,
                 NID_RELACION_TRANSMISOR = NID_RELACION_TRANSMISOR,
                 V_TIPO_MONEDA = V_TIPO_MONEDA,
                 NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION,
                 NID_FORMA_PAGO = NID_FORMA_PAGO,
                 E_OBSERVACIONES = E_OBSERVACIONES
               };
            try
            {

                ALTA_MUEBLE registroCheck = db.ALTA_MUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_MUEBLE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("ALTA_MUEBLE",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_MUEBLE.ToString() + ", " );
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
                            db.ALTA_MUEBLE.Attach(registro);
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
            db.ALTA_MUEBLE.Add(registro);
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
            db.ALTA_MUEBLE.Remove(registro);
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
