using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_ALTA_COMODATO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected ALTA_COMODATO registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_COMODATO => registro.NID_COMODATO;
        internal String CID_TIPO_PERSONA
        {
            get => registro.CID_TIPO_PERSONA;
            set => registro.CID_TIPO_PERSONA = value;
        }
        internal String E_TITULAR
        {
            get => registro.E_TITULAR;
            set => registro.E_TITULAR = value;
        }
        internal String E_RFC
        {
            get => registro.E_RFC;
            set => registro.E_RFC = value;
        }
        internal Int32 NID_TIPO_RELACION
        {
            get => registro.NID_TIPO_RELACION;
            set => registro.NID_TIPO_RELACION = value;
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
        internal dal_ALTA_COMODATO() => registro = new ALTA_COMODATO();
        internal dal_ALTA_COMODATO(ALTA_COMODATO oALTA_COMODATO) : this(oALTA_COMODATO.VID_NOMBRE, oALTA_COMODATO.VID_FECHA, oALTA_COMODATO.VID_HOMOCLAVE, oALTA_COMODATO.NID_DECLARACION, oALTA_COMODATO.NID_COMODATO) { }
        internal dal_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) { registro = db.ALTA_COMODATO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_ALTA_COMODATO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, String CID_TIPO_PERSONA, String E_TITULAR, String E_RFC, Int32 NID_TIPO_RELACION, String E_OBSERVACIONES, String E_OBSERVACIONES_MARCADO, String V_OBSERVACIONES_TESTADO, Int32 NID_ESTADO_TESTADO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new ALTA_COMODATO()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_COMODATO = NID_COMODATO,
                CID_TIPO_PERSONA = CID_TIPO_PERSONA,
                E_TITULAR = E_TITULAR,
                E_RFC = E_RFC,
                NID_TIPO_RELACION = NID_TIPO_RELACION,
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
                ALTA_COMODATO registroCheck = db.ALTA_COMODATO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO);
                if (registroCheck == null)
                {
                    db.ALTA_COMODATO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION, ", ", NID_COMODATO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.CID_TIPO_PERSONA = registro.CID_TIPO_PERSONA;
                            registroCheck.E_TITULAR = registro.E_TITULAR;
                            registroCheck.E_RFC = registro.E_RFC;
                            registroCheck.NID_TIPO_RELACION = registro.NID_TIPO_RELACION;
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
            db.ALTA_COMODATO.Remove(registro);
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
