using Declara_V2.Exceptions;
using MODELDeclara_V2;
using System;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_EXPERIENCIA_LABORAL : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_EXPERIENCIA_LABORAL registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_EXPERIENCIA_LABORAL => registro.NID_EXPERIENCIA_LABORAL;
        internal Int32 NID_AMBITO_SECTOR
        {
            get => registro.NID_AMBITO_SECTOR;
            set => registro.NID_AMBITO_SECTOR = value;
        }
        internal Int32 NID_NIVEL_GOBIERNO
        {
            get => registro.NID_NIVEL_GOBIERNO;
            set => registro.NID_NIVEL_GOBIERNO = value;
        }
        internal Int32 NID_AMBITO_PUBLICO
        {
            get => registro.NID_AMBITO_PUBLICO;
            set => registro.NID_AMBITO_PUBLICO = value;
        }
        internal String V_NOMBRE
        {
            get => registro.V_NOMBRE;
            set => registro.V_NOMBRE = value;
        }
        internal String V_RFC
        {
            get => registro.V_RFC;
            set => registro.V_RFC = value;
        }
        internal String V_AREA_ADSCRIPCION
        {
            get => registro.V_AREA_ADSCRIPCION;
            set => registro.V_AREA_ADSCRIPCION = value;
        }
        internal String V_PUESTO
        {
            get => registro.V_PUESTO;
            set => registro.V_PUESTO = value;
        }
        internal String V_FUNCION_PRINCIPAL
        {
            get => registro.V_FUNCION_PRINCIPAL;
            set => registro.V_FUNCION_PRINCIPAL = value;
        }
        internal Int32 NID_SECTOR
        {
            get => registro.NID_SECTOR;
            set => registro.NID_SECTOR = value;
        }
        internal DateTime F_INGRESO
        {
            get => registro.F_INGRESO;
            set => registro.F_INGRESO = value;
        }
        internal DateTime F_EGRESO
        {
            get => registro.F_EGRESO;
            set => registro.F_EGRESO = value;
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
        internal String V_SECTOR
        {
            get => registro.V_SECTOR;
            set => registro.V_SECTOR = value;
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
        internal dal_DECLARACION_EXPERIENCIA_LABORAL() => registro = new DECLARACION_EXPERIENCIA_LABORAL();
        internal dal_DECLARACION_EXPERIENCIA_LABORAL(DECLARACION_EXPERIENCIA_LABORAL oDECLARACION_EXPERIENCIA_LABORAL) : this(oDECLARACION_EXPERIENCIA_LABORAL.VID_NOMBRE, oDECLARACION_EXPERIENCIA_LABORAL.VID_FECHA, oDECLARACION_EXPERIENCIA_LABORAL.VID_HOMOCLAVE, oDECLARACION_EXPERIENCIA_LABORAL.NID_DECLARACION, oDECLARACION_EXPERIENCIA_LABORAL.NID_EXPERIENCIA_LABORAL) { }
        internal dal_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL) { registro = db.DECLARACION_EXPERIENCIA_LABORAL.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EXPERIENCIA_LABORAL); if (registro == null) throw new RowNotFoundException(); }
        internal dal_DECLARACION_EXPERIENCIA_LABORAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_EXPERIENCIA_LABORAL, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE, String V_RFC, String V_AREA_ADSCRIPCION, String V_PUESTO, String V_FUNCION_PRINCIPAL, Int32 NID_SECTOR, DateTime F_INGRESO, DateTime F_EGRESO, Int32 NID_PAIS, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO,  ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_EXPERIENCIA_LABORAL()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_EXPERIENCIA_LABORAL = NID_EXPERIENCIA_LABORAL,
                NID_AMBITO_SECTOR = NID_AMBITO_SECTOR,
                NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO,
                NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO,
                V_NOMBRE = V_NOMBRE,
                V_RFC = V_RFC,
                V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION,
                V_PUESTO = V_PUESTO,
                V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL,
                NID_SECTOR = NID_SECTOR,
                F_INGRESO = F_INGRESO,
                F_EGRESO = F_EGRESO,
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
                DECLARACION_EXPERIENCIA_LABORAL registroCheck = db.DECLARACION_EXPERIENCIA_LABORAL.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_EXPERIENCIA_LABORAL);
                if (registroCheck == null)
                {
                    db.DECLARACION_EXPERIENCIA_LABORAL.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_", String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION, ", ", NID_EXPERIENCIA_LABORAL));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.NID_AMBITO_SECTOR = registro.NID_AMBITO_SECTOR;
                            registroCheck.NID_NIVEL_GOBIERNO = registro.NID_NIVEL_GOBIERNO;
                            registroCheck.NID_AMBITO_PUBLICO = registro.NID_AMBITO_PUBLICO;
                            registroCheck.V_NOMBRE = registro.V_NOMBRE;
                            registroCheck.V_RFC = registro.V_RFC;
                            registroCheck.V_AREA_ADSCRIPCION = registro.V_AREA_ADSCRIPCION;
                            registroCheck.V_PUESTO = registro.V_PUESTO;
                            registroCheck.V_FUNCION_PRINCIPAL = registro.V_FUNCION_PRINCIPAL;
                            registroCheck.NID_SECTOR = registro.NID_SECTOR;
                            registroCheck.F_INGRESO = registro.F_INGRESO;
                            registroCheck.F_EGRESO = registro.F_EGRESO;
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
            db.DECLARACION_EXPERIENCIA_LABORAL.Remove(registro);
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
