using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_DEPENDIENTES_PRIVADO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_DEPENDIENTES_PRIVADO registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_DEPENDIENTE => registro.NID_DEPENDIENTE;
        internal String V_NOMBRE
        {
            get => registro.V_NOMBRE;
            set => registro.V_NOMBRE = value;
        }
        internal String V_CARGO
        {
            get => registro.V_CARGO;
            set => registro.V_CARGO = value;
        }
        internal String V_RFC
        {
            get => registro.V_RFC;
            set => registro.V_RFC = value;
        }
        internal DateTime F_INGRESO
        {
            get => registro.F_INGRESO;
            set => registro.F_INGRESO = value;
        }
        internal Int32 NID_SECTOR
        {
            get => registro.NID_SECTOR;
            set => registro.NID_SECTOR = value;
        }
        internal Decimal M_SALARIO_MENSUAL
        {
            get => registro.M_SALARIO_MENSUAL;
            set => registro.M_SALARIO_MENSUAL = value;
        }
        internal Boolean L_PROVEEDOR
        {
            get => registro.L_PROVEEDOR;
            set => registro.L_PROVEEDOR = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_DECLARACION_DEPENDIENTES_PRIVADO() => registro = new DECLARACION_DEPENDIENTES_PRIVADO();
        internal dal_DECLARACION_DEPENDIENTES_PRIVADO(DECLARACION_DEPENDIENTES_PRIVADO oDECLARACION_DEPENDIENTES_PRIVADO) : this(oDECLARACION_DEPENDIENTES_PRIVADO.VID_NOMBRE, oDECLARACION_DEPENDIENTES_PRIVADO.VID_FECHA, oDECLARACION_DEPENDIENTES_PRIVADO.VID_HOMOCLAVE, oDECLARACION_DEPENDIENTES_PRIVADO.NID_DECLARACION, oDECLARACION_DEPENDIENTES_PRIVADO.NID_DEPENDIENTE) { }
        internal dal_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE) { registro = db.DECLARACION_DEPENDIENTES_PRIVADO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE); if (registro == null) throw new RowNotFoundException(); }
        internal dal_DECLARACION_DEPENDIENTES_PRIVADO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, String V_NOMBRE, String V_CARGO, String V_RFC, DateTime F_INGRESO, Int32 NID_SECTOR, Decimal M_SALARIO_MENSUAL, Boolean L_PROVEEDOR, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_DEPENDIENTES_PRIVADO()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_DEPENDIENTE = NID_DEPENDIENTE,
                V_NOMBRE = V_NOMBRE,
                V_CARGO = V_CARGO,
                V_RFC = V_RFC,
                F_INGRESO = F_INGRESO,
                NID_SECTOR = NID_SECTOR,
                M_SALARIO_MENSUAL = M_SALARIO_MENSUAL,
                L_PROVEEDOR = L_PROVEEDOR,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                DECLARACION_DEPENDIENTES_PRIVADO registroCheck = db.DECLARACION_DEPENDIENTES_PRIVADO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE);
                if (registroCheck == null)
                {
                    db.DECLARACION_DEPENDIENTES_PRIVADO.Add(registro);
                    SaveChanges(true);
                }
                else
                {
                    switch (lOpcionesRegistroExistente)
                    {
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException://Arrojar Excepción de llave primaria
                            throw new ExistingPrimaryKeyException(this.GetType().Name.Replace("dal_",String.Empty), String.Concat(VID_NOMBRE, ", ", VID_FECHA, ", ", VID_HOMOCLAVE, ", ", NID_DECLARACION, ", ", NID_DEPENDIENTE));
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting://Usar registro existente
                            registro = registroCheck;
                            break;
                        case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting://Actualizar registro existente
                            registroCheck.V_NOMBRE = registro.V_NOMBRE;
                            registroCheck.V_CARGO = registro.V_CARGO;
                            registroCheck.V_RFC = registro.V_RFC;
                            registroCheck.F_INGRESO = registro.F_INGRESO;
                            registroCheck.NID_SECTOR = registro.NID_SECTOR;
                            registroCheck.M_SALARIO_MENSUAL = registro.M_SALARIO_MENSUAL;
                            registroCheck.L_PROVEEDOR = registro.L_PROVEEDOR;
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
            db.DECLARACION_DEPENDIENTES_PRIVADO.Remove(registro);
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
