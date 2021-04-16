using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_CARGO_OTRO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_CARGO_OTRO registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
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
        internal String VID_NOMBRE_ENTE
        {
            get => registro.VID_NOMBRE_ENTE;
            set => registro.VID_NOMBRE_ENTE = value;
        }
        internal String V_AREA_ADSCRIPCION
        {
            get => registro.V_AREA_ADSCRIPCION;
            set => registro.V_AREA_ADSCRIPCION = value;
        }
        internal String V_CARGO
        {
            get => registro.V_CARGO;
            set => registro.V_CARGO = value;
        }
        internal Boolean L_HONORARIOS
        {
            get => registro.L_HONORARIOS;
            set => registro.L_HONORARIOS = value;
        }
        internal String V_NIVEL_EMPLEO
        {
            get => registro.V_NIVEL_EMPLEO;
            set => registro.V_NIVEL_EMPLEO = value;
        }
        internal String V_FUNCION_PRINCIPAL
        {
            get => registro.V_FUNCION_PRINCIPAL;
            set => registro.V_FUNCION_PRINCIPAL = value;
        }
        internal DateTime F_POSESION
        {
            get => registro.F_POSESION;
            set => registro.F_POSESION = value;
        }
        internal String V_TEL_LABORAL
        {
            get => registro.V_TEL_LABORAL;
            set => registro.V_TEL_LABORAL = value;
        }
        internal String C_CODIGO_POSTAL
        {
            get => registro.C_CODIGO_POSTAL;
            set => registro.C_CODIGO_POSTAL = value;
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
        internal String CID_MUNICIPIO
        {
            get => registro.CID_MUNICIPIO;
            set => registro.CID_MUNICIPIO = value;
        }
        internal String V_COLONIA
        {
            get => registro.V_COLONIA;
            set => registro.V_COLONIA = value;
        }
        internal String V_DOMICILIO
        {
            get => registro.V_DOMICILIO;
            set => registro.V_DOMICILIO = value;
        }
        internal String V_OBSERVACIONES
        {
            get => registro.V_OBSERVACIONES;
            set => registro.V_OBSERVACIONES = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_DECLARACION_CARGO_OTRO() => registro = new DECLARACION_CARGO_OTRO();
        internal dal_DECLARACION_CARGO_OTRO(DECLARACION_CARGO_OTRO oDECLARACION_CARGO_OTRO) : this(oDECLARACION_CARGO_OTRO.VID_NOMBRE, oDECLARACION_CARGO_OTRO.VID_FECHA, oDECLARACION_CARGO_OTRO.VID_HOMOCLAVE, oDECLARACION_CARGO_OTRO.NID_DECLARACION) { }
        internal dal_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) { registro = db.DECLARACION_CARGO_OTRO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION); if (registro == null) throw new RowNotFoundException(); }
      
        internal dal_DECLARACION_CARGO_OTRO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String VID_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, Boolean L_HONORARIOS, String V_NIVEL_EMPLEO, String V_FUNCION_PRINCIPAL, DateTime F_POSESION, String V_TEL_LABORAL, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_OBSERVACIONES, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_CARGO_OTRO()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO,
                NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO,
                VID_NOMBRE_ENTE = VID_NOMBRE_ENTE,
                V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION,
                V_CARGO = V_CARGO,
                L_HONORARIOS = L_HONORARIOS,
                V_NIVEL_EMPLEO = V_NIVEL_EMPLEO,
                V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL,
                F_POSESION = F_POSESION,
                V_TEL_LABORAL = V_TEL_LABORAL,
                C_CODIGO_POSTAL = C_CODIGO_POSTAL,
                NID_PAIS = NID_PAIS,
                CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                CID_MUNICIPIO = CID_MUNICIPIO,
                V_COLONIA = V_COLONIA,
                V_DOMICILIO = V_DOMICILIO,
                V_OBSERVACIONES = V_OBSERVACIONES,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                DECLARACION_CARGO_OTRO registroCheck = db.DECLARACION_CARGO_OTRO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                if (registroCheck == null)
                {
                    db.DECLARACION_CARGO_OTRO.Add(registro);
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
                            registroCheck.NID_NIVEL_GOBIERNO = registro.NID_NIVEL_GOBIERNO;
                            registroCheck.NID_AMBITO_PUBLICO = registro.NID_AMBITO_PUBLICO;
                            registroCheck.VID_NOMBRE_ENTE = registro.VID_NOMBRE_ENTE;
                            registroCheck.V_AREA_ADSCRIPCION = registro.V_AREA_ADSCRIPCION;
                            registroCheck.V_CARGO = registro.V_CARGO;
                            registroCheck.L_HONORARIOS = registro.L_HONORARIOS;
                            registroCheck.V_NIVEL_EMPLEO = registro.V_NIVEL_EMPLEO;
                            registroCheck.V_FUNCION_PRINCIPAL = registro.V_FUNCION_PRINCIPAL;
                            registroCheck.F_POSESION = registro.F_POSESION;
                            registroCheck.V_TEL_LABORAL = registro.V_TEL_LABORAL;
                            registroCheck.C_CODIGO_POSTAL = registro.C_CODIGO_POSTAL;
                            registroCheck.NID_PAIS = registro.NID_PAIS;
                            registroCheck.CID_ENTIDAD_FEDERATIVA = registro.CID_ENTIDAD_FEDERATIVA;
                            registroCheck.CID_MUNICIPIO = registro.CID_MUNICIPIO;
                            registroCheck.V_COLONIA = registro.V_COLONIA;
                            registroCheck.V_DOMICILIO = registro.V_DOMICILIO;
                            registroCheck.V_OBSERVACIONES = registro.V_OBSERVACIONES;
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
            db.DECLARACION_CARGO_OTRO.Remove(registro);
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
