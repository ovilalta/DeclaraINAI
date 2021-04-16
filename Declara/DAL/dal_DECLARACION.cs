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
    internal class dal_DECLARACION : _dal_base_Declara
    {

        protected DECLARACION registro;

        #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE;

        internal String VID_FECHA => registro.VID_FECHA;

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;

        internal String C_EJERCICIO
        {
            get => registro.C_EJERCICIO;
            set => registro.C_EJERCICIO = value;
        }

        internal Int32 NID_TIPO_DECLARACION
        {
            get => registro.NID_TIPO_DECLARACION;
            set => registro.NID_TIPO_DECLARACION = value;
        }

        internal Int32 NID_ESTADO
        {
            get => registro.NID_ESTADO;
            set => registro.NID_ESTADO = value;
        }

        internal String E_OBSERVACIONES
        {
            get => registro.E_OBSERVACIONES;
            set => registro.E_OBSERVACIONES = value;
        }

        internal String E_OBSERVACIONES_MARCADO
        {
            get => registro.E_OBSERVACIONES_MARCADO;
            set => registro.E_OBSERVACIONES_MARCADO = value;
        }

        internal String V_OBSERVACIONES_TESTADO
        {
            get => registro.V_OBSERVACIONES_TESTADO;
            set => registro.V_OBSERVACIONES_TESTADO = value;
        }

        internal Int32 NID_ESTADO_TESTADO
        {
            get => registro.NID_ESTADO_TESTADO;
            set => registro.NID_ESTADO_TESTADO = value;
        }

        internal Boolean L_AUTORIZA_PUBLICAR
        {
            get => registro.L_AUTORIZA_PUBLICAR;
            set => registro.L_AUTORIZA_PUBLICAR = value;
        }

        internal DateTime F_REGISTRO => registro.F_REGISTRO;

        internal System.Nullable<DateTime> F_ENVIO
        {
            get => registro.F_ENVIO;
            set => registro.F_ENVIO = value;
        }

        internal System.Nullable<Boolean> L_CONFLICTO
        {
            get => registro.L_CONFLICTO;
            set => registro.L_CONFLICTO = value;
        }

        internal String V_HASH
        {
            get => registro.V_HASH;
            set => registro.V_HASH = value;
        }


        #endregion


        #region *** Constructores ***

        internal dal_DECLARACION() => registro = new DECLARACION();

        internal dal_DECLARACION(DECLARACION oDECLARACION) : this(oDECLARACION.VID_NOMBRE, oDECLARACION.VID_FECHA, oDECLARACION.VID_HOMOCLAVE, oDECLARACION.NID_DECLARACION) { }

        internal dal_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) { registro = db.DECLARACION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION); if (registro == null) throw new RowNotFoundException(); }

        internal dal_DECLARACION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_EJERCICIO, Int32 NID_TIPO_DECLARACION, Int32 NID_ESTADO, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, Boolean L_AUTORIZA_PUBLICAR, System.Nullable<DateTime> F_ENVIO, System.Nullable<Boolean> L_CONFLICTO, String V_HASH, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                C_EJERCICIO = C_EJERCICIO,
                NID_TIPO_DECLARACION = NID_TIPO_DECLARACION,
                NID_ESTADO = NID_ESTADO,
                E_OBSERVACIONES = E_OBSERVACIONES,
                E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO,
                V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO,
                NID_ESTADO_TESTADO = NID_ESTADO_TESTADO,
                L_AUTORIZA_PUBLICAR = L_AUTORIZA_PUBLICAR,
                F_REGISTRO = DateTime.Now,
                F_ENVIO = F_ENVIO,
                L_CONFLICTO = L_CONFLICTO,
                V_HASH = V_HASH,
            };
            insert(lOpcionesRegistroExistente);
        }


        #endregion


        #region *** Metodos ***

        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                DECLARACION registroCheck = db.DECLARACION.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                if (registroCheck == null)
                {
                    db.DECLARACION.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA , ", " , VID_HOMOCLAVE , ", " , NID_DECLARACION));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.F_REGISTRO = registro.F_REGISTRO;
                            SaveChanges(false);
                            registro = registroCheck;
                            break;
                        default://Opcion no Implementada
                            throw new NotImplementedException();
                    }
                }
            }
            catch (Exception ex)
            {
                registro = null;
                throw ex;
            }

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
            db.DECLARACION.Remove(registro);
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
