using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_MODIFICACION_INGRESOS : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected MODIFICACION_INGRESOS registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_INGRESO => registro.NID_INGRESO;
        internal String E_ESPECIFICAR
        {
            get => registro.E_ESPECIFICAR;
            set => registro.E_ESPECIFICAR = value;
        }
        internal String E_ESPECIFICAR_COMPLEMENTO
        {
            get => registro.E_ESPECIFICAR_COMPLEMENTO;
            set => registro.E_ESPECIFICAR_COMPLEMENTO = value;
        }
        internal Decimal M_INGRESO
        {
            get => registro.M_INGRESO;
            set => registro.M_INGRESO = value;
        }
        internal Char C_TITULAR
        {
            get => Convert.ToChar(registro.C_TITULAR);
            set => registro.C_TITULAR = value.ToString();
        }

        #endregion


        #region *** Constructores ***
        internal dal_MODIFICACION_INGRESOS() => registro = new MODIFICACION_INGRESOS();
        internal dal_MODIFICACION_INGRESOS(MODIFICACION_INGRESOS oMODIFICACION_INGRESOS) : this(oMODIFICACION_INGRESOS.VID_NOMBRE, oMODIFICACION_INGRESOS.VID_FECHA, oMODIFICACION_INGRESOS.VID_HOMOCLAVE, oMODIFICACION_INGRESOS.NID_DECLARACION, oMODIFICACION_INGRESOS.NID_INGRESO) { }
        internal dal_MODIFICACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO) { registro = db.MODIFICACION_INGRESOS.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO); if (registro == null) throw new RowNotFoundException(); }
        internal dal_MODIFICACION_INGRESOS(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_INGRESO, String E_ESPECIFICAR, String E_ESPECIFICAR_COMPLEMENTO, Decimal M_INGRESO, Char C_TITULAR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new MODIFICACION_INGRESOS()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_INGRESO = NID_INGRESO,
                E_ESPECIFICAR = E_ESPECIFICAR,
                E_ESPECIFICAR_COMPLEMENTO = E_ESPECIFICAR_COMPLEMENTO,
                M_INGRESO = M_INGRESO,
                C_TITULAR = C_TITULAR.ToString()
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                MODIFICACION_INGRESOS registroCheck = db.MODIFICACION_INGRESOS.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INGRESO);
                if (registroCheck == null)
                {
                    db.MODIFICACION_INGRESOS.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION, ", ", NID_INGRESO));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.E_ESPECIFICAR = registro.E_ESPECIFICAR;
                            registroCheck.E_ESPECIFICAR_COMPLEMENTO = registro.E_ESPECIFICAR_COMPLEMENTO;
                            registroCheck.M_INGRESO = registro.M_INGRESO;
                            registroCheck.C_TITULAR = registro.C_TITULAR;
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
            db.MODIFICACION_INGRESOS.Remove(registro);
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
