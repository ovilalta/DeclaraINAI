using Declara_V2.Exceptions;
using MODELDeclara_V2;
using System;
using System.Data.Entity;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_DOM_PARTICULAR : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_DOM_PARTICULAR registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
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
        internal String V_ENTIDAD_FEDERATIVA
        {
            get => registro.V_ENTIDAD_FEDERATIVA;
            set => registro.V_ENTIDAD_FEDERATIVA = value;
        }
        internal String V_MUNICIPIO
        {
            get => registro.V_MUNICIPIO;
            set => registro.V_MUNICIPIO = value;
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
        internal String V_CORREO
        {
            get => registro.V_CORREO;
            set => registro.V_CORREO = value;
        }
        internal String V_TEL_PARTICULAR
        {
            get => registro.V_TEL_PARTICULAR;
            set => registro.V_TEL_PARTICULAR = value;
        }
        internal String V_TEL_CELULAR
        {
            get => registro.V_TEL_CELULAR;
            set => registro.V_TEL_CELULAR = value;
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
        internal dal_DECLARACION_DOM_PARTICULAR() => registro = new DECLARACION_DOM_PARTICULAR();
        internal dal_DECLARACION_DOM_PARTICULAR(DECLARACION_DOM_PARTICULAR oDECLARACION_DOM_PARTICULAR) : this(oDECLARACION_DOM_PARTICULAR.VID_NOMBRE, oDECLARACION_DOM_PARTICULAR.VID_FECHA, oDECLARACION_DOM_PARTICULAR.VID_HOMOCLAVE, oDECLARACION_DOM_PARTICULAR.NID_DECLARACION) { }
        internal dal_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION) { registro = db.DECLARACION_DOM_PARTICULAR.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION); if (registro == null) throw new RowNotFoundException(); }
        internal dal_DECLARACION_DOM_PARTICULAR(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, String V_CORREO, String V_TEL_PARTICULAR, String V_TEL_CELULAR, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, String V_ENTIDAD_FEDERATIVA, String V_MUNICIPIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_DOM_PARTICULAR()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                C_CODIGO_POSTAL = C_CODIGO_POSTAL,
                NID_PAIS = NID_PAIS,
                CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                CID_MUNICIPIO = CID_MUNICIPIO,
                V_COLONIA = V_COLONIA,
                V_DOMICILIO = V_DOMICILIO,
                V_CORREO = V_CORREO,
                V_TEL_PARTICULAR = V_TEL_PARTICULAR,
                V_TEL_CELULAR = V_TEL_CELULAR,
                E_OBSERVACIONES = E_OBSERVACIONES,
                E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO,
                V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO,
                NID_ESTADO_TESTADO = NID_ESTADO_TESTADO,
                V_ENTIDAD_FEDERATIVA = V_ENTIDAD_FEDERATIVA,
                V_MUNICIPIO = V_MUNICIPIO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                DECLARACION_DOM_PARTICULAR registroCheck = db.DECLARACION_DOM_PARTICULAR.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
                if (registroCheck == null)
                {
                    db.DECLARACION_DOM_PARTICULAR.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_", String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.C_CODIGO_POSTAL = registro.C_CODIGO_POSTAL;
                            registroCheck.NID_PAIS = registro.NID_PAIS;
                            registroCheck.CID_ENTIDAD_FEDERATIVA = registro.CID_ENTIDAD_FEDERATIVA;
                            registroCheck.CID_MUNICIPIO = registro.CID_MUNICIPIO;
                            registroCheck.V_COLONIA = registro.V_COLONIA;
                            registroCheck.V_DOMICILIO = registro.V_DOMICILIO;
                            registroCheck.V_CORREO = registro.V_CORREO;
                            registroCheck.V_TEL_PARTICULAR = registro.V_TEL_PARTICULAR;
                            registroCheck.V_TEL_CELULAR = registro.V_TEL_CELULAR;
                            registroCheck.E_OBSERVACIONES = registro.E_OBSERVACIONES;
                            registroCheck.E_OBSERVACIONES_MARCADO = registro.E_OBSERVACIONES_MARCADO;
                            registroCheck.V_OBSERVACIONES_TESTADO = registro.V_OBSERVACIONES_TESTADO;
                            registroCheck.NID_ESTADO_TESTADO = registro.NID_ESTADO_TESTADO;
                            registroCheck.V_ENTIDAD_FEDERATIVA = registro.V_ENTIDAD_FEDERATIVA;
                            registroCheck.V_MUNICIPIO = registro.V_MUNICIPIO;
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
                SaveChanges(true);
            }
        }

        internal void delete()
        {
            db.DECLARACION_DOM_PARTICULAR.Remove(registro);
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
