using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_ALTA_COMODATO_INMUEBLE : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected ALTA_COMODATO_INMUEBLE registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_COMODATO => registro.NID_COMODATO;
        internal Int32 NID_TIPO
        {
            get => registro.NID_TIPO;
            set => registro.NID_TIPO = value;
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

        #endregion


        #region *** Constructores ***
        internal dal_ALTA_COMODATO_INMUEBLE() => registro = new ALTA_COMODATO_INMUEBLE();
        internal dal_ALTA_COMODATO_INMUEBLE(ALTA_COMODATO_INMUEBLE oALTA_COMODATO_INMUEBLE) : this(oALTA_COMODATO_INMUEBLE.VID_NOMBRE, oALTA_COMODATO_INMUEBLE.VID_FECHA, oALTA_COMODATO_INMUEBLE.VID_HOMOCLAVE, oALTA_COMODATO_INMUEBLE.NID_DECLARACION, oALTA_COMODATO_INMUEBLE.NID_COMODATO) { }
        internal dal_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) { registro = db.ALTA_COMODATO_INMUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_ALTA_COMODATO_INMUEBLE(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO, String C_CODIGO_POSTAL, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String CID_MUNICIPIO, String V_COLONIA, String V_DOMICILIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new ALTA_COMODATO_INMUEBLE()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_COMODATO = NID_COMODATO,
                NID_TIPO = NID_TIPO,
                C_CODIGO_POSTAL = C_CODIGO_POSTAL,
                NID_PAIS = NID_PAIS,
                CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
                CID_MUNICIPIO = CID_MUNICIPIO,
                V_COLONIA = V_COLONIA,
                V_DOMICILIO = V_DOMICILIO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                ALTA_COMODATO_INMUEBLE registroCheck = db.ALTA_COMODATO_INMUEBLE.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO);
                if (registroCheck == null)
                {
                    db.ALTA_COMODATO_INMUEBLE.Add(registro);
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
                            registroCheck.NID_TIPO = registro.NID_TIPO;
                            registroCheck.C_CODIGO_POSTAL = registro.C_CODIGO_POSTAL;
                            registroCheck.NID_PAIS = registro.NID_PAIS;
                            registroCheck.CID_ENTIDAD_FEDERATIVA = registro.CID_ENTIDAD_FEDERATIVA;
                            registroCheck.CID_MUNICIPIO = registro.CID_MUNICIPIO;
                            registroCheck.V_COLONIA = registro.V_COLONIA;
                            registroCheck.V_DOMICILIO = registro.V_DOMICILIO;
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
            db.ALTA_COMODATO_INMUEBLE.Remove(registro);
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
