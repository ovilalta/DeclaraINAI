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
    internal class dal_ALTA_INMUEBLE : _dal_base_Declara
    {

       protected ALTA_INMUEBLE registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_INMUEBLE => registro.NID_INMUEBLE; 

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

        internal Int32 NID_PATRIMONIO
        {
          get => registro.NID_PATRIMONIO; 
          set => registro.NID_PATRIMONIO = value; 
        }

        internal Decimal N_PORCENTAJE_DECLARANTE
        {
            get => registro.N_PORCENTAJE_DECLARANTE;
            set => registro.N_PORCENTAJE_DECLARANTE = value;
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
        #endregion

        internal Int32 NID_RELACION_TRANSMISOR
        {
            get => registro.NID_RELACION_TRANSMISOR;
            set => registro.NID_RELACION_TRANSMISOR = value;
        }

        internal String V_TIPO_MONEDA
        {
            get => registro.V_TIPO_MONEDA;
            set => registro.V_TIPO_MONEDA = value;
        }

        internal String E_REGISTRO_PUBLICO_PROPIEDAD
        {
            get => registro.E_REGISTRO_PUBLICO_PROPIEDAD;
            set => registro.E_REGISTRO_PUBLICO_PROPIEDAD = value;
        }

        internal Int32 NID_VALOR_ADQUISICION
        {
            get => registro.NID_VALOR_ADQUISICION;
            set => registro.NID_VALOR_ADQUISICION = value;
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


        #region *** Constructores ***

        internal dal_ALTA_INMUEBLE() => registro = new ALTA_INMUEBLE();

        internal dal_ALTA_INMUEBLE(ALTA_INMUEBLE oALTA_INMUEBLE) : this(oALTA_INMUEBLE.VID_NOMBRE, oALTA_INMUEBLE.VID_FECHA, oALTA_INMUEBLE.VID_HOMOCLAVE, oALTA_INMUEBLE.NID_DECLARACION, oALTA_INMUEBLE.NID_INMUEBLE) { }

        internal dal_ALTA_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INMUEBLE) { registro = db.ALTA_INMUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE); if (registro == null) throw new RowNotFoundException(); }

        internal dal_ALTA_INMUEBLE(  String VID_NOMBRE
                                    , String VID_FECHA
                                    , String VID_HOMOCLAVE
                                    , Int32 NID_DECLARACION
                                    , Int32 NID_INMUEBLE
                                    , Int32 NID_TIPO
                                    , DateTime F_ADQUISICION
                                    , Int32 NID_USO
                                    , String E_UBICACION
                                    , Decimal N_TERRENO
                                    , Decimal N_CONSTRUCCION
                                    , Decimal M_VALOR_INMUEBLE
                                    , Int32 NID_PATRIMONIO
                                    , Decimal N_PORCENTAJE_DECLARANTE
                                    , String CID_TIPO_PERSONA_TRANSMISOR
                                    , String E_NOMBRE_TRANSMISOR
                                    , String E_RFC_TRANSMISOR
                                    , Int32 NID_RELACION_TRANSMISOR
                                    , String V_TIPO_MONEDA
                                    , String E_REGISTRO_PUBLICO_PROPIEDAD
                                    , Int32 NID_VALOR_ADQUISICION
                                    , Int32 NID_FORMA_ADQUISICION
                                    , Int32 NID_FORMA_PAGO
                                    , String E_OBSERVACIONES
                                    , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
                                    )
        {
               registro = new ALTA_INMUEBLE()
               {
                  VID_NOMBRE = VID_NOMBRE
                 , VID_FECHA = VID_FECHA
                 , VID_HOMOCLAVE = VID_HOMOCLAVE
                 , NID_DECLARACION = NID_DECLARACION
                 , NID_INMUEBLE = NID_INMUEBLE
                 , NID_TIPO = NID_TIPO
                 , F_ADQUISICION = F_ADQUISICION
                 , NID_USO = NID_USO
                 , E_UBICACION = E_UBICACION
                 , N_TERRENO = N_TERRENO
                 , N_CONSTRUCCION = N_CONSTRUCCION
                 , M_VALOR_INMUEBLE = M_VALOR_INMUEBLE
                 , NID_PATRIMONIO = NID_PATRIMONIO
                 , N_PORCENTAJE_DECLARANTE = N_PORCENTAJE_DECLARANTE
                 , CID_TIPO_PERSONA_TRANSMISOR = CID_TIPO_PERSONA_TRANSMISOR
                 , E_NOMBRE_TRANSMISOR = E_NOMBRE_TRANSMISOR
                 , E_RFC_TRANSMISOR = E_RFC_TRANSMISOR
                 , NID_RELACION_TRANSMISOR = NID_RELACION_TRANSMISOR
                 , V_TIPO_MONEDA = V_TIPO_MONEDA
                 , E_REGISTRO_PUBLICO_PROPIEDAD = E_REGISTRO_PUBLICO_PROPIEDAD
                 , NID_VALOR_ADQUISICION = NID_VALOR_ADQUISICION
                 , NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION
                 , NID_FORMA_PAGO = NID_FORMA_PAGO
                 , E_OBSERVACIONES = E_OBSERVACIONES
               };
            try
            {
                ALTA_INMUEBLE registroCheck = db.ALTA_INMUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INMUEBLE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("ALTA_INMUEBLE",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_INMUEBLE.ToString() + ", " );
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
                            db.ALTA_INMUEBLE.Attach(registro);
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
            db.ALTA_INMUEBLE.Add(registro);
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
            db.ALTA_INMUEBLE.Remove(registro);
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
