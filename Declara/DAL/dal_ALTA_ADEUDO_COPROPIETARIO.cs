using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_ALTA_ADEUDO_COPROPIETARIO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected ALTA_ADEUDO_COPROPIETARIO registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_ADEUDO => registro.NID_ADEUDO;
        internal Int32 NID_COPROPIETARIO => registro.NID_COPROPIETARIO;
        internal String CID_TIPO_PERSONA
        {
            get => registro.CID_TIPO_PERSONA;
            set => registro.CID_TIPO_PERSONA = value;
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

        #endregion


        #region *** Constructores ***
        internal dal_ALTA_ADEUDO_COPROPIETARIO() => registro = new ALTA_ADEUDO_COPROPIETARIO();
        internal dal_ALTA_ADEUDO_COPROPIETARIO(ALTA_ADEUDO_COPROPIETARIO oALTA_ADEUDO_COPROPIETARIO) : this(oALTA_ADEUDO_COPROPIETARIO.VID_NOMBRE, oALTA_ADEUDO_COPROPIETARIO.VID_FECHA, oALTA_ADEUDO_COPROPIETARIO.VID_HOMOCLAVE, oALTA_ADEUDO_COPROPIETARIO.NID_DECLARACION, oALTA_ADEUDO_COPROPIETARIO.NID_ADEUDO, oALTA_ADEUDO_COPROPIETARIO.NID_COPROPIETARIO) { }
        internal dal_ALTA_ADEUDO_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_COPROPIETARIO) { registro = db.ALTA_ADEUDO_COPROPIETARIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_COPROPIETARIO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_ALTA_ADEUDO_COPROPIETARIO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_ADEUDO, Int32 NID_COPROPIETARIO, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new ALTA_ADEUDO_COPROPIETARIO()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_ADEUDO = NID_ADEUDO,
                NID_COPROPIETARIO = NID_COPROPIETARIO,
                CID_TIPO_PERSONA = CID_TIPO_PERSONA,
                V_NOMBRE = V_NOMBRE,
                V_RFC = V_RFC,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                ALTA_ADEUDO_COPROPIETARIO registroCheck = db.ALTA_ADEUDO_COPROPIETARIO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_COPROPIETARIO);
                if (registroCheck == null)
                {
                    db.ALTA_ADEUDO_COPROPIETARIO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION, ", ", NID_ADEUDO, ", ", NID_COPROPIETARIO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.CID_TIPO_PERSONA = registro.CID_TIPO_PERSONA;
                            registroCheck.V_NOMBRE = registro.V_NOMBRE;
                            registroCheck.V_RFC = registro.V_RFC;
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
            db.ALTA_ADEUDO_COPROPIETARIO.Remove(registro);
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
