using Declara_V2.Exceptions;
using MODELDeclara_V2;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Declara_V2.DAL
{
    internal class dal_DECLARACION_DEPENDIENTES : _dal_base_Declara
    {

        DECLARACION_DEPENDIENTES registro;

        #region *** Atributos ***

        internal String VID_NOMBRE => registro.VID_NOMBRE;

        internal String VID_FECHA => registro.VID_FECHA;

        internal String VID_HOMOCLAVE => registro.VID_HOMOCLAVE;

        internal Int32 NID_DECLARACION => registro.NID_DECLARACION;

        internal Int32 NID_DEPENDIENTE => registro.NID_DEPENDIENTE;

        internal Int32 NID_TIPO_DEPENDIENTE
        {
            get => registro.NID_TIPO_DEPENDIENTE;
            set => registro.NID_TIPO_DEPENDIENTE = value;
        }

        internal String E_NOMBRE
        {
            get => registro.E_NOMBRE;
            set => registro.E_NOMBRE = value;
        }

        internal String E_PRIMER_A
        {
            get => registro.E_PRIMER_A;
            set => registro.E_PRIMER_A = value;
        }

        internal String E_SEGUNDO_A
        {
            get => registro.E_SEGUNDO_A;
            set => registro.E_SEGUNDO_A = value;
        }

        internal DateTime F_NACIMIENTO
        {
            get => registro.F_NACIMIENTO;
            set => registro.F_NACIMIENTO = value;
        }

        internal String E_RFC
        {
            get => registro.E_RFC;
            set => registro.E_RFC = value;
        }

        internal Boolean L_DEPENDE_ECO
        {
            get => registro.L_DEPENDE_ECO;
            set => registro.L_DEPENDE_ECO = value;
        }

        internal Boolean L_PAREJA
        {
            get => registro.L_PAREJA;
            set => registro.L_PAREJA = value;
        }

        internal String E_DOMICILIO
        {
            get => registro.E_DOMICILIO;
            set => registro.E_DOMICILIO = value;
        }

        internal Boolean L_ACTIVO
        {
            get => registro.L_ACTIVO;
            set => registro.L_ACTIVO = value;
        }




        internal Boolean L_CIUDADANO_EXTRANJERO
        {
            get => registro.L_CIUDADANO_EXTRANJERO;
            set => registro.L_CIUDADANO_EXTRANJERO = value;
        }

        internal String E_CURP
        {
            get => registro.E_CURP;
            set => registro.E_CURP = value;
        }

        internal Int32 NID_ACTIVIDAD_LABORAL
        {
            get => registro.NID_ACTIVIDAD_LABORAL;
            set => registro.NID_ACTIVIDAD_LABORAL = value;
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


        internal Boolean L_MISMO_DOMICILIO_DECLARANTE
        {
            get => registro.L_MISMO_DOMICILIO_DECLARANTE;
            set => registro.L_MISMO_DOMICILIO_DECLARANTE = value;
        }


        #endregion


        #region *** Constructores ***

        internal dal_DECLARACION_DEPENDIENTES() => registro = new DECLARACION_DEPENDIENTES();

        internal dal_DECLARACION_DEPENDIENTES(DECLARACION_DEPENDIENTES oDECLARACION_DEPENDIENTES) : this(oDECLARACION_DEPENDIENTES.VID_NOMBRE, oDECLARACION_DEPENDIENTES.VID_FECHA, oDECLARACION_DEPENDIENTES.VID_HOMOCLAVE, oDECLARACION_DEPENDIENTES.NID_DECLARACION, oDECLARACION_DEPENDIENTES.NID_DEPENDIENTE) { }

        internal dal_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE) { registro = db.DECLARACION_DEPENDIENTES.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE); if (registro == null) throw new RowNotFoundException(); }

        internal dal_DECLARACION_DEPENDIENTES(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_TIPO_DEPENDIENTE, String E_NOMBRE, String E_PRIMER_A, String E_SEGUNDO_A, DateTime F_NACIMIENTO, String E_RFC, Boolean L_DEPENDE_ECO
                                                               , String E_DOMICILIO
                                                               , Boolean L_CIUDADANO_EXTRANJERO
                                                               , String E_CURP
                                                               , Int32 NID_ACTIVIDAD_LABORAL
                                                               , String E_OBSERVACIONES
                                                               , String E_OBSERVACIONES_MARCADO
                                                               , String V_OBSERVACIONES_TESTADO
                                                               , Boolean L_MISMO_DOMICILIO_DECLARANTE, Boolean L_ACTIVO, Boolean L_PAREJA, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente)
        {
            registro = new DECLARACION_DEPENDIENTES()
            {
                VID_NOMBRE = VID_NOMBRE,
                VID_FECHA = VID_FECHA,
                VID_HOMOCLAVE = VID_HOMOCLAVE,
                NID_DECLARACION = NID_DECLARACION,
                NID_DEPENDIENTE = NID_DEPENDIENTE,
                NID_TIPO_DEPENDIENTE = NID_TIPO_DEPENDIENTE,
                E_NOMBRE = E_NOMBRE,
                E_PRIMER_A = E_PRIMER_A,
                E_SEGUNDO_A = E_SEGUNDO_A,
                F_NACIMIENTO = F_NACIMIENTO,
                L_CIUDADANO_EXTRANJERO = L_CIUDADANO_EXTRANJERO,
                E_RFC = E_RFC,
                L_DEPENDE_ECO = L_DEPENDE_ECO,
                E_DOMICILIO = E_DOMICILIO,
                E_CURP = E_CURP,
                NID_ACTIVIDAD_LABORAL = NID_ACTIVIDAD_LABORAL,
                E_OBSERVACIONES = E_OBSERVACIONES,
                E_OBSERVACIONES_MARCADO = E_OBSERVACIONES_MARCADO,
                V_OBSERVACIONES_TESTADO = V_OBSERVACIONES_TESTADO,
                L_MISMO_DOMICILIO_DECLARANTE = L_MISMO_DOMICILIO_DECLARANTE,
                L_ACTIVO = L_ACTIVO,
                L_PAREJA = L_PAREJA,
            };
            try
            {
                DECLARACION_DEPENDIENTES registroCheck = db.DECLARACION_DEPENDIENTES.Find(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE);
                switch (lOpcionesRegistroExistente)
                {
                    //Arrojar Exepción de llave primaria
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException:
                        if (registroCheck == null) insert();
                        else throw new ExistingPrimaryKeyException("DECLARACION_DEPENDIENTES", VID_NOMBRE + ", " + VID_FECHA + ", " + VID_HOMOCLAVE + ", " + NID_DECLARACION.ToString() + ", " + NID_DEPENDIENTE.ToString() + ", ");
                        break;

                    //Usar registro existente
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UseExisiting:
                        if (registroCheck == null) insert();
                        else registro = registroCheck;
                        break;

                    //Actualizar registro existente
                    case ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.UpdateExisiting:
                        if (registroCheck == null) insert();
                        else
                        {
                            db.DECLARACION_DEPENDIENTES.Attach(registro);
                            ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(registro, EntityState.Modified);
                            update();
                        }
                        break;

                    //Opcion no Implementada
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                registro = null;
                throw ex;
            }
        }


        #endregion


        #region *** Metodos ***

        internal void insert()
        {
            db.DECLARACION_DEPENDIENTES.Add(registro);
            SaveChanges(true);
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
            db.DECLARACION_DEPENDIENTES.Remove(registro);
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
