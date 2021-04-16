using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_REGIMEN_MATRIMONIAL : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_REGIMEN_MATRIMONIAL registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_REGIMEN => registro.NID_REGIMEN;
        internal Int32 NID_REGIMEN_MATRIMONIAL
        {
            get => registro.NID_REGIMEN_MATRIMONIAL;
            set => registro.NID_REGIMEN_MATRIMONIAL = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_DECLARACION_REGIMEN_MATRIMONIAL() => registro = new DECLARACION_REGIMEN_MATRIMONIAL();
        internal dal_DECLARACION_REGIMEN_MATRIMONIAL(DECLARACION_REGIMEN_MATRIMONIAL oDECLARACION_REGIMEN_MATRIMONIAL) : this(oDECLARACION_REGIMEN_MATRIMONIAL.VID_NOMBRE, oDECLARACION_REGIMEN_MATRIMONIAL.VID_FECHA, oDECLARACION_REGIMEN_MATRIMONIAL.VID_HOMOCLAVE, oDECLARACION_REGIMEN_MATRIMONIAL.NID_DECLARACION, oDECLARACION_REGIMEN_MATRIMONIAL.NID_REGIMEN) { }
        internal dal_DECLARACION_REGIMEN_MATRIMONIAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN) { registro = db.DECLARACION_REGIMEN_MATRIMONIAL.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN); if (registro == null) throw new RowNotFoundException(); }
        internal dal_DECLARACION_REGIMEN_MATRIMONIAL(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_REGIMEN, Int32 NID_REGIMEN_MATRIMONIAL, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_REGIMEN_MATRIMONIAL()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_REGIMEN = NID_REGIMEN,
                NID_REGIMEN_MATRIMONIAL = NID_REGIMEN_MATRIMONIAL,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                DECLARACION_REGIMEN_MATRIMONIAL registroCheck = db.DECLARACION_REGIMEN_MATRIMONIAL.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_REGIMEN);
                if (registroCheck == null)
                {
                    db.DECLARACION_REGIMEN_MATRIMONIAL.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION, ", ", NID_REGIMEN));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.NID_REGIMEN_MATRIMONIAL = registro.NID_REGIMEN_MATRIMONIAL;
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
            db.DECLARACION_REGIMEN_MATRIMONIAL.Remove(registro);
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
