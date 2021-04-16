using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_ALTA_COMODATO_VEHICULO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected ALTA_COMODATO_VEHICULO registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_COMODATO => registro.NID_COMODATO;
        internal Int32 NID_TIPO_VEHICULO
        {
            get => registro.NID_TIPO_VEHICULO;
            set => registro.NID_TIPO_VEHICULO = value;
        }
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
        internal String E_NUMERO_SERIE
        {
            get => registro.E_NUMERO_SERIE;
            set => registro.E_NUMERO_SERIE = value;
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

        #endregion


        #region *** Constructores ***
        internal dal_ALTA_COMODATO_VEHICULO() => registro = new ALTA_COMODATO_VEHICULO();
        internal dal_ALTA_COMODATO_VEHICULO(ALTA_COMODATO_VEHICULO oALTA_COMODATO_VEHICULO) : this(oALTA_COMODATO_VEHICULO.VID_NOMBRE, oALTA_COMODATO_VEHICULO.VID_FECHA, oALTA_COMODATO_VEHICULO.VID_HOMOCLAVE, oALTA_COMODATO_VEHICULO.NID_DECLARACION, oALTA_COMODATO_VEHICULO.NID_COMODATO) { }
        internal dal_ALTA_COMODATO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO) { registro = db.ALTA_COMODATO_VEHICULO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_ALTA_COMODATO_VEHICULO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_COMODATO, Int32 NID_TIPO_VEHICULO, Int32 NID_MARCA, String C_MODELO, String V_DESCRIPCION, String E_NUMERO_SERIE, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new ALTA_COMODATO_VEHICULO()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_COMODATO = NID_COMODATO,
                NID_TIPO_VEHICULO = NID_TIPO_VEHICULO,
                NID_MARCA = NID_MARCA,
                C_MODELO = C_MODELO,
                V_DESCRIPCION = V_DESCRIPCION,
                E_NUMERO_SERIE = E_NUMERO_SERIE,
                NID_PAIS = NID_PAIS,
                CID_ENTIDAD_FEDERATIVA = CID_ENTIDAD_FEDERATIVA,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                ALTA_COMODATO_VEHICULO registroCheck = db.ALTA_COMODATO_VEHICULO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_COMODATO);
                if (registroCheck == null)
                {
                    db.ALTA_COMODATO_VEHICULO.Add(registro);
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
                            registroCheck.NID_TIPO_VEHICULO = registro.NID_TIPO_VEHICULO;
                            registroCheck.NID_MARCA = registro.NID_MARCA;
                            registroCheck.C_MODELO = registro.C_MODELO;
                            registroCheck.V_DESCRIPCION = registro.V_DESCRIPCION;
                            registroCheck.E_NUMERO_SERIE = registro.E_NUMERO_SERIE;
                            registroCheck.NID_PAIS = registro.NID_PAIS;
                            registroCheck.CID_ENTIDAD_FEDERATIVA = registro.CID_ENTIDAD_FEDERATIVA;
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
            db.ALTA_COMODATO_VEHICULO.Remove(registro);
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
