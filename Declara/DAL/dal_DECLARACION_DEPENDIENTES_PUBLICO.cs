using System;
using System.Data.Entity;
using MODELDeclara_V2;
using Declara_V2.Exceptions;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_DEPENDIENTES_PUBLICO : _dal_base_Declara
    {

        #region *** Propiedades ***
        protected DECLARACION_DEPENDIENTES_PUBLICO registro { get; set; }
        internal String VID_NOMBRE => registro.VID_NOMBRE;
        internal String VID_FECHA => registro.VID_FECHA;
        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;
        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;
        internal Int32 NID_DEPENDIENTE => registro.NID_DEPENDIENTE;
        internal Int32 NID_AMBITO_SECTOR
        {
            get => registro.NID_AMBITO_SECTOR;
            set => registro.NID_AMBITO_SECTOR = value;
        }
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
        internal String V_NOMBRE_ENTE
        {
            get => registro.V_NOMBRE_ENTE;
            set => registro.V_NOMBRE_ENTE = value;
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
        internal String V_FUNCION_PRINCIPAL
        {
            get => registro.V_FUNCION_PRINCIPAL;
            set => registro.V_FUNCION_PRINCIPAL = value;
        }
        internal Decimal M_SALARIO_MENSUAL
        {
            get => registro.M_SALARIO_MENSUAL;
            set => registro.M_SALARIO_MENSUAL = value;
        }
        internal DateTime F_INGRESO
        {
            get => registro.F_INGRESO;
            set => registro.F_INGRESO = value;
        }

        #endregion


        #region *** Constructores ***
        internal dal_DECLARACION_DEPENDIENTES_PUBLICO() => registro = new DECLARACION_DEPENDIENTES_PUBLICO();
        internal dal_DECLARACION_DEPENDIENTES_PUBLICO(DECLARACION_DEPENDIENTES_PUBLICO oDECLARACION_DEPENDIENTES_PUBLICO) : this(oDECLARACION_DEPENDIENTES_PUBLICO.VID_NOMBRE, oDECLARACION_DEPENDIENTES_PUBLICO.VID_FECHA, oDECLARACION_DEPENDIENTES_PUBLICO.VID_HOMOCLAVE, oDECLARACION_DEPENDIENTES_PUBLICO.NID_DECLARACION, oDECLARACION_DEPENDIENTES_PUBLICO.NID_DEPENDIENTE) { }
        internal dal_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE) { registro = db.DECLARACION_DEPENDIENTES_PUBLICO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE); if (registro == null) throw new RowNotFoundException(); }
        internal dal_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, String V_FUNCION_PRINCIPAL, Decimal M_SALARIO_MENSUAL, DateTime F_INGRESO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_DEPENDIENTES_PUBLICO()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_DEPENDIENTE = NID_DEPENDIENTE,
                NID_AMBITO_SECTOR = NID_AMBITO_SECTOR,
                NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO,
                NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO,
                V_NOMBRE_ENTE = V_NOMBRE_ENTE,
                V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION,
                V_CARGO = V_CARGO,
                V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL,
                M_SALARIO_MENSUAL = M_SALARIO_MENSUAL,
                F_INGRESO = F_INGRESO,
            };
            insert(lOpcionesRegistroExistente);
        }

        #endregion


        #region *** Metodos ***
        internal void insert(ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            try
            {
                DECLARACION_DEPENDIENTES_PUBLICO registroCheck = db.DECLARACION_DEPENDIENTES_PUBLICO.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE);
                if (registroCheck == null)
                {
                    db.DECLARACION_DEPENDIENTES_PUBLICO.Add(registro);
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
                            registroCheck.NID_AMBITO_SECTOR = registro.NID_AMBITO_SECTOR;
                            registroCheck.NID_NIVEL_GOBIERNO = registro.NID_NIVEL_GOBIERNO;
                            registroCheck.NID_AMBITO_PUBLICO = registro.NID_AMBITO_PUBLICO;
                            registroCheck.V_NOMBRE_ENTE = registro.V_NOMBRE_ENTE;
                            registroCheck.V_AREA_ADSCRIPCION = registro.V_AREA_ADSCRIPCION;
                            registroCheck.V_CARGO = registro.V_CARGO;
                            registroCheck.V_FUNCION_PRINCIPAL = registro.V_FUNCION_PRINCIPAL;
                            registroCheck.M_SALARIO_MENSUAL = registro.M_SALARIO_MENSUAL;
                            registroCheck.F_INGRESO = registro.F_INGRESO;
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
            db.DECLARACION_DEPENDIENTES_PUBLICO.Remove(registro);
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
