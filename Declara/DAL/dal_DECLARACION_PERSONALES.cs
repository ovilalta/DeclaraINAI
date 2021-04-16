using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_PERSONALES : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_PERSONALES registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal String C_GENERO
        {
            get => registro.C_GENERO;
            set => registro.C_GENERO = value;
        }
        internal String C_CURP
        {
            get => registro.C_CURP;
            set => registro.C_CURP = value;
        }
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
        internal Int32 NID_NACIONALIDAD
        {
            get => registro.NID_NACIONALIDAD;
            set => registro.NID_NACIONALIDAD = value;
        }
        internal Int32 NID_ESTADO_CIVIL
        {
            get => registro.NID_ESTADO_CIVIL;
            set => registro.NID_ESTADO_CIVIL = value;
        }
        internal System.Nullable<Boolean> L_SERVIDOR_ANTERIOR
        {
            get => registro.L_SERVIDOR_ANTERIOR;
            set => registro.L_SERVIDOR_ANTERIOR = value;
        }
        internal System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_INICIO
        {
            get => registro.F_SERVIDOR_ANTERIOR_INICIO;
            set => registro.F_SERVIDOR_ANTERIOR_INICIO = value;
        }
        internal System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_FIN
        {
            get => registro.F_SERVIDOR_ANTERIOR_FIN;
            set => registro.F_SERVIDOR_ANTERIOR_FIN = value;
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
        internal dal_DECLARACION_PERSONALES() => registro = new DECLARACION_PERSONALES();
        internal dal_DECLARACION_PERSONALES(DECLARACION_PERSONALES oDECLARACION_PERSONALES) : this(oDECLARACION_PERSONALES.VID_NOMBRE, oDECLARACION_PERSONALES.VID_FECHA, oDECLARACION_PERSONALES.VID_HOMOCLAVE, oDECLARACION_PERSONALES.NID_DECLARACION) { }
        internal dal_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) { registro = db.DECLARACION_PERSONALES.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION); if (registro == null) throw new RowNotFoundException(); }
        internal dal_DECLARACION_PERSONALES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_GENERO, String C_CURP, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, Int32 NID_NACIONALIDAD, Int32 NID_ESTADO_CIVIL, System.Nullable<Boolean> L_SERVIDOR_ANTERIOR, System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_INICIO, System.Nullable<DateTime> F_SERVIDOR_ANTERIOR_FIN, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
 
        {
            registro = new DECLARACION_PERSONALES()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                C_GENERO = C_GENERO,
                C_CURP = C_CURP,
                NID_PAIS = NID_PAIS,
                CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                NID_NACIONALIDAD = NID_NACIONALIDAD,
                NID_ESTADO_CIVIL = NID_ESTADO_CIVIL,
                L_SERVIDOR_ANTERIOR = L_SERVIDOR_ANTERIOR,
                F_SERVIDOR_ANTERIOR_INICIO = F_SERVIDOR_ANTERIOR_INICIO,
                F_SERVIDOR_ANTERIOR_FIN = F_SERVIDOR_ANTERIOR_FIN,
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
                DECLARACION_PERSONALES registroCheck = db.DECLARACION_PERSONALES.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                if (registroCheck == null)
                {
                    db.DECLARACION_PERSONALES.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.C_GENERO = registro.C_GENERO;
                            registroCheck.C_CURP = registro.C_CURP;
                            registroCheck.NID_PAIS = registro.NID_PAIS;
                            registroCheck.CID_ENTIDAD_FEDERATIVA = registro.CID_ENTIDAD_FEDERATIVA;
                            registroCheck.NID_NACIONALIDAD = registro.NID_NACIONALIDAD;
                            registroCheck.NID_ESTADO_CIVIL = registro.NID_ESTADO_CIVIL;
                            registroCheck.L_SERVIDOR_ANTERIOR = registro.L_SERVIDOR_ANTERIOR;
                            registroCheck.F_SERVIDOR_ANTERIOR_INICIO = registro.F_SERVIDOR_ANTERIOR_INICIO;
                            registroCheck.F_SERVIDOR_ANTERIOR_FIN = registro.F_SERVIDOR_ANTERIOR_FIN;
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
            db.DECLARACION_PERSONALES.Remove(registro);
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
