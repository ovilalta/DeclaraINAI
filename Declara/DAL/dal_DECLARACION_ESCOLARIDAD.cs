using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_ESCOLARIDAD : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_ESCOLARIDAD registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_ESCOLARIDAD => registro.NID_ESCOLARIDAD;
        internal Int32 NID_NIVEL_ESCOLARIDAD
        {
            get => registro.NID_NIVEL_ESCOLARIDAD;
            set => registro.NID_NIVEL_ESCOLARIDAD = value;
        }
        internal String V_INSTITUCION_EDUCATIVA
        {
            get => registro.V_INSTITUCION_EDUCATIVA;
            set => registro.V_INSTITUCION_EDUCATIVA = value;
        }
        internal String V_CARRERA
        {
            get => registro.V_CARRERA;
            set => registro.V_CARRERA = value;
        }
        internal Int32 NID_ESTADO_ESCOLARIDAD
        {
            get => registro.NID_ESTADO_ESCOLARIDAD;
            set => registro.NID_ESTADO_ESCOLARIDAD = value;
        }
        internal Int32 NID_DOCUMENTO_OBTENIDO
        {
            get => registro.NID_DOCUMENTO_OBTENIDO;
            set => registro.NID_DOCUMENTO_OBTENIDO = value;
        }
        internal DateTime F_OBTENCION
        {
            get => registro.F_OBTENCION;
            set => registro.F_OBTENCION = value;
        }
        internal Int32 NID_PAIS
        {
            get => registro.NID_PAIS;
            set => registro.NID_PAIS = value;
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

        #endregion


        #region *** Constructores ***
        internal dal_DECLARACION_ESCOLARIDAD() => registro = new DECLARACION_ESCOLARIDAD();
        internal dal_DECLARACION_ESCOLARIDAD(DECLARACION_ESCOLARIDAD oDECLARACION_ESCOLARIDAD) : this(oDECLARACION_ESCOLARIDAD.VID_NOMBRE, oDECLARACION_ESCOLARIDAD.VID_FECHA, oDECLARACION_ESCOLARIDAD.VID_HOMOCLAVE, oDECLARACION_ESCOLARIDAD.NID_DECLARACION, oDECLARACION_ESCOLARIDAD.NID_ESCOLARIDAD) { }
        internal dal_DECLARACION_ESCOLARIDAD(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ESCOLARIDAD) { registro = db.DECLARACION_ESCOLARIDAD.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ESCOLARIDAD); if (registro == null) throw new RowNotFoundException(); }
        internal dal_DECLARACION_ESCOLARIDAD(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ESCOLARIDAD, Int32 NID_NIVEL_ESCOLARIDAD, String V_INSTITUCION_EDUCATIVA, String V_CARRERA, Int32 NID_ESTADO_ESCOLARIDAD, Int32 NID_DOCUMENTO_OBTENIDO, DateTime F_OBTENCION, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_ESCOLARIDAD()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_ESCOLARIDAD = NID_ESCOLARIDAD,
                NID_NIVEL_ESCOLARIDAD = NID_NIVEL_ESCOLARIDAD,
                V_INSTITUCION_EDUCATIVA = V_INSTITUCION_EDUCATIVA,
                V_CARRERA = V_CARRERA,
                NID_ESTADO_ESCOLARIDAD = NID_ESTADO_ESCOLARIDAD,
                NID_DOCUMENTO_OBTENIDO = NID_DOCUMENTO_OBTENIDO,
                F_OBTENCION = F_OBTENCION,
                NID_PAIS = NID_PAIS,
                E_OBSERVACIONES = E_OBSERVACIONES,
                E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO,
                V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO,
                NID_ESTADO_TESTADO = NID_ESTADO_TESTADO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                DECLARACION_ESCOLARIDAD registroCheck = db.DECLARACION_ESCOLARIDAD.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ESCOLARIDAD);
                if (registroCheck == null)
                {
                    db.DECLARACION_ESCOLARIDAD.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION, ", ", NID_ESCOLARIDAD));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.NID_NIVEL_ESCOLARIDAD = registro.NID_NIVEL_ESCOLARIDAD;
                            registroCheck.V_INSTITUCION_EDUCATIVA = registro.V_INSTITUCION_EDUCATIVA;
                            registroCheck.V_CARRERA = registro.V_CARRERA;
                            registroCheck.NID_ESTADO_ESCOLARIDAD = registro.NID_ESTADO_ESCOLARIDAD;
                            registroCheck.NID_DOCUMENTO_OBTENIDO = registro.NID_DOCUMENTO_OBTENIDO;
                            registroCheck.F_OBTENCION = registro.F_OBTENCION;
                            registroCheck.NID_PAIS = registro.NID_PAIS;
                            registroCheck.E_OBSERVACIONES = registro.E_OBSERVACIONES;
                            registroCheck.E_OBSERVACIONES_MARCADO = registro.E_OBSERVACIONES_MARCADO;
                            registroCheck.V_OBSERVACIONES_TESTADO = registro.V_OBSERVACIONES_TESTADO;
                            registroCheck.NID_ESTADO_TESTADO = registro.NID_ESTADO_TESTADO;
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
            db.DECLARACION_ESCOLARIDAD.Remove(registro);
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
