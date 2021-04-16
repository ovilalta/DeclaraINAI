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
    internal class dal_ALTA_VEHICULO : _dal_base_Declara
    {

        protected ALTA_VEHICULO registro;

     #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE; 

        internal String VID_FECHA => registro.VID_FECHA; 

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE; 

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION; 

        internal Int32 NID_VEHICULO => registro.NID_VEHICULO; 

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

        internal Int32 NID_TIPO_VEHICULO
        {
          get => registro.NID_TIPO_VEHICULO; 
          set => registro.NID_TIPO_VEHICULO = value; 
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

        internal Int32 NID_PATRIMONIO
        {
          get => registro.NID_PATRIMONIO; 
          set => registro.NID_PATRIMONIO = value; 
        }

        internal System.Nullable<Int32> NID_PAIS
        //internal Int32 NID_PAIS
        {
            get => registro.NID_PAIS;
            set => registro.NID_PAIS = value;
        }

        public String CID_ENTIDAD_FEDERATIVA
        {
            get => registro.CID_ENTIDAD_FEDERATIVA;
            set => registro.CID_ENTIDAD_FEDERATIVA = value;
        }
        internal String V_TIPO_MONEDA
        {
            get => registro.V_TIPO_MONEDA;
            set => registro.V_TIPO_MONEDA = value;
        }

        internal String E_NUMERO_SERIE
        {
            get => registro.E_NUMERO_SERIE;
            set => registro.E_NUMERO_SERIE = value;
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

        internal dal_ALTA_VEHICULO() => registro = new ALTA_VEHICULO();

        internal dal_ALTA_VEHICULO(ALTA_VEHICULO oALTA_VEHICULO) : this(oALTA_VEHICULO.VID_NOMBRE, oALTA_VEHICULO.VID_FECHA, oALTA_VEHICULO.VID_HOMOCLAVE, oALTA_VEHICULO.NID_DECLARACION, oALTA_VEHICULO.NID_VEHICULO) { }

        internal dal_ALTA_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_VEHICULO) { registro = db.ALTA_VEHICULO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO); if (registro == null) throw new RowNotFoundException(); }

        internal dal_ALTA_VEHICULO(String VID_NOMBRE
                                    , String VID_FECHA
                                    , String VID_HOMOCLAVE
                                    , Int32 NID_DECLARACION
                                    , Int32 NID_VEHICULO
                                    , Int32 NID_MARCA
                                    , String C_MODELO
                                    , String V_DESCRIPCION
                                    , DateTime F_ADQUISICION
                                    , Int32 NID_TIPO_VEHICULO
                                    , Int32 NID_USO
                                    , Decimal M_VALOR_VEHICULO
                                    , Int32 NID_PATRIMONIO
                                    , Int32 NID_PAIS
                                    , String CID_ENTIDAD_FEDERATIVA
                                    , String CID_TIPO_PERSONA_TRANSMISOR
                                    , String E_NOMBRE_TRANSMISOR
                                    , String E_RFC_TRANSMISOR
                                    , Int32 NID_RELACION_TRANSMISOR
                                    , String V_TIPO_MONEDA
                                    , String E_NUMERO_SERIE
                                    , Int32 NID_FORMA_ADQUISICION
                                    , Int32 NID_FORMA_PAGO
                                    , String E_OBSERVACIONES
                                    , ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente
                                    )
        {
               registro = new ALTA_VEHICULO()
               {
                 VID_NOMBRE = VID_NOMBRE,
                 VID_FECHA = VID_FECHA,
                 VID_HOMOCLAVE = VID_HOMOCLAVE,
                 NID_DECLARACION = NID_DECLARACION,
                 NID_VEHICULO = NID_VEHICULO,
                 NID_MARCA = NID_MARCA,
                 C_MODELO = C_MODELO,
                 V_DESCRIPCION = V_DESCRIPCION,
                 F_ADQUISICION = F_ADQUISICION,
                 NID_TIPO_VEHICULO = NID_TIPO_VEHICULO,
                 NID_USO = NID_USO,
                 M_VALOR_VEHICULO = M_VALOR_VEHICULO,
                 NID_PATRIMONIO = NID_PATRIMONIO,
                 NID_PAIS = NID_PAIS,
                 CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                 CID_TIPO_PERSONA_TRANSMISOR = CID_TIPO_PERSONA_TRANSMISOR,
                 E_NOMBRE_TRANSMISOR = E_NOMBRE_TRANSMISOR,
                 E_RFC_TRANSMISOR = E_RFC_TRANSMISOR,
                 NID_RELACION_TRANSMISOR = NID_RELACION_TRANSMISOR,
                 V_TIPO_MONEDA = V_TIPO_MONEDA,
                 E_NUMERO_SERIE = E_NUMERO_SERIE,
                 NID_FORMA_ADQUISICION = NID_FORMA_ADQUISICION,
                 NID_FORMA_PAGO = NID_FORMA_PAGO,
                 E_OBSERVACIONES = E_OBSERVACIONES
               };
            try
            {
                ALTA_VEHICULO registroCheck = db.ALTA_VEHICULO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_VEHICULO);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("ALTA_VEHICULO",VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_VEHICULO.ToString() + ", " );
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
                            db.ALTA_VEHICULO.Attach(registro);
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
            db.ALTA_VEHICULO.Add(registro);
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
            db.ALTA_VEHICULO.Remove(registro);
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
