using Declara_V2.DALD;
using System;

namespace Declara_V2.BLL
{
    public class bll_DECLARACION_DEPENDIENTES_PUBLICO : _bllSistema
    {

        #region *** Propiedades ***
        internal dald_DECLARACION_DEPENDIENTES_PUBLICO datos_DECLARACION_DEPENDIENTES_PUBLICO { get; set; }
        public String VID_NOMBRE => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_NOMBRE;
        public String VID_FECHA => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_FECHA;
        public String VID_HOMOCLAVE => datos_DECLARACION_DEPENDIENTES_PUBLICO.VID_HOMOCLAVE;
        public Int32 NID_DECLARACION => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DECLARACION;
        public Int32 NID_DEPENDIENTE => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_DEPENDIENTE;
        public Int32 NID_AMBITO_SECTOR
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_SECTOR = value;
        }
        public Int32 NID_NIVEL_GOBIERNO
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_NIVEL_GOBIERNO = value;
        }
        public Int32 NID_AMBITO_PUBLICO
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.NID_AMBITO_PUBLICO = value;
        }
        public String V_NOMBRE_ENTE
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES_PUBLICO.V_NOMBRE_ENTE = Encripta(value);
            }
        }
        public String V_AREA_ADSCRIPCION
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES_PUBLICO.V_AREA_ADSCRIPCION = Encripta(value);
            }
        }
        public String V_CARGO
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES_PUBLICO.V_CARGO = Encripta(value);
            }
        }
        public String V_FUNCION_PRINCIPAL
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL))
                        return String.Empty;
                    return DesEncripta(datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL);
                }
                catch (Exception)
                {
                    return datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL = String.Empty;
                else
                    datos_DECLARACION_DEPENDIENTES_PUBLICO.V_FUNCION_PRINCIPAL = Encripta(value);
            }
        }
        public Decimal M_SALARIO_MENSUAL
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.M_SALARIO_MENSUAL = value;
        }
        public DateTime F_INGRESO
        {
            get => datos_DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO;
            set => datos_DECLARACION_DEPENDIENTES_PUBLICO.F_INGRESO = value;
        }

        public System.Nullable<Boolean> lEsNuevoRegistro
        {
            get { return datos_DECLARACION_DEPENDIENTES_PUBLICO.lEsNuevoRegistro; }
        }
        #endregion


        #region *** Constructores ***
        public bll_DECLARACION_DEPENDIENTES_PUBLICO() => datos_DECLARACION_DEPENDIENTES_PUBLICO = new dald_DECLARACION_DEPENDIENTES_PUBLICO();
        public bll_DECLARACION_DEPENDIENTES_PUBLICO(MODELDeclara_V2.DECLARACION_DEPENDIENTES_PUBLICO DECLARACION_DEPENDIENTES_PUBLICO) => datos_DECLARACION_DEPENDIENTES_PUBLICO = new dald_DECLARACION_DEPENDIENTES_PUBLICO(DECLARACION_DEPENDIENTES_PUBLICO);
        public bll_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE) => datos_DECLARACION_DEPENDIENTES_PUBLICO = new dald_DECLARACION_DEPENDIENTES_PUBLICO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_DEPENDIENTE);

        //        public bll_DECLARACION_DEPENDIENTES_PUBLICO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_DEPENDIENTE, Int32 NID_AMBITO_SECTOR, Int32 NID_NIVEL_GOBIERNO, Int32 NID_AMBITO_PUBLICO, String V_NOMBRE_ENTE, String V_AREA_ADSCRIPCION, String V_CARGO, String V_FUNCION_PRINCIPAL, Decimal M_SALARIO_MENSUAL, DateTime F_INGRESO)
        //        {
        //            ExistingPrimaryKeyException.ExistingPrimaryKeyConditions lOpcionesRegistroExistente = ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException;
        //            datos_DECLARACION_DEPENDIENTES_PUBLICO = new dald_DECLARACION_DEPENDIENTES_PUBLICO();
        //            String _VID_NOMBRE = VID_NOMBRE; 
        //            String _VID_FECHA = VID_FECHA; 
        //            String _VID_HOMOCLAVE = VID_HOMOCLAVE; 
        //            Int32 _NID_DECLARACION = NID_DECLARACION; 
        //            Int32 _NID_DEPENDIENTE = NID_DEPENDIENTE; 
        //            this.NID_AMBITO_SECTOR = NID_AMBITO_SECTOR;
        //            this.NID_NIVEL_GOBIERNO = NID_NIVEL_GOBIERNO;
        //            this.NID_AMBITO_PUBLICO = NID_AMBITO_PUBLICO;
        //            this.V_NOMBRE_ENTE = V_NOMBRE_ENTE;
        //            this.V_AREA_ADSCRIPCION = V_AREA_ADSCRIPCION;
        //            this.V_CARGO = V_CARGO;
        //            this.V_FUNCION_PRINCIPAL = V_FUNCION_PRINCIPAL;
        //            this.M_SALARIO_MENSUAL = M_SALARIO_MENSUAL;
        //            this.F_INGRESO = F_INGRESO;
        //            datos_DECLARACION_DEPENDIENTES_PUBLICO = new dald_DECLARACION_DEPENDIENTES_PUBLICO(_VID_NOMBRE, _VID_FECHA, _VID_HOMOCLAVE, _NID_DECLARACION, _NID_DEPENDIENTE, this.VID_NOMBRE, this.VID_FECHA, this.VID_HOMOCLAVE, this.NID_DECLARACION, this.NID_DEPENDIENTE, this.NID_AMBITO_SECTOR, this.NID_NIVEL_GOBIERNO, this.NID_AMBITO_PUBLICO, this.V_NOMBRE_ENTE, this.V_AREA_ADSCRIPCION, this.V_CARGO, this.V_FUNCION_PRINCIPAL, this.M_SALARIO_MENSUAL, this.F_INGRESO, lOpcionesRegistroExistente);
        //        }

        #endregion


        #region *** Metodos ***
        public void update()
        {
            datos_DECLARACION_DEPENDIENTES_PUBLICO.update();
        }
        public void delete()
        {
            datos_DECLARACION_DEPENDIENTES_PUBLICO.delete();
        }
        public void reload()
        {
            datos_DECLARACION_DEPENDIENTES_PUBLICO.reload();
        }

        #endregion

    }
}
