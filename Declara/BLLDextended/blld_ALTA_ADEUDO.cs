using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Declara_V2.DALD;
using Declara_V2.BLL;
using Declara_V2.Exceptions;

namespace Declara_V2.BLLD
{
// Extended
    public partial class blld_ALTA_ADEUDO : bll_ALTA_ADEUDO
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_ALTA_ADEUDO.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_ALTA_ADEUDO.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_ALTA_ADEUDO.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_ALTA_ADEUDO.NID_DECLARACION; }
        //        }

        //        public Int32 NID_ADEUDO
        //        {
        //          get { return datos_ALTA_ADEUDO.NID_ADEUDO; }
        //        }

        new public Int32 NID_PAIS
        {
            get => datos_ALTA_ADEUDO.NID_PAIS;
            set
            {
                if (!value.Equals(datos_ALTA_ADEUDO.NID_PAIS))
                {
                    datos_ALTA_ADEUDO.oPais = null;
                    datos_ALTA_ADEUDO.oEntidad = null;
                }
                datos_ALTA_ADEUDO.NID_PAIS = value;
            }
        }


        new public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_ADEUDO.CID_ENTIDAD_FEDERATIVA;
            set
            {
                if (!value.Equals(datos_ALTA_ADEUDO.CID_ENTIDAD_FEDERATIVA))
                {
                    datos_ALTA_ADEUDO.oEntidad = null;
                }
                datos_ALTA_ADEUDO.CID_ENTIDAD_FEDERATIVA = value;
            }
        }



        //        public Int32 NID_INSTITUCION
        //        {
        //          get { return datos_ALTA_ADEUDO.NID_INSTITUCION; }
        //          set { datos_ALTA_ADEUDO.NID_INSTITUCION = value; }
        //        }


        //        public Int32 NID_TIPO_ADEUDO
        //        {
        //          get { return datos_ALTA_ADEUDO.NID_TIPO_ADEUDO; }
        //          set { datos_ALTA_ADEUDO.NID_TIPO_ADEUDO = value; }
        //        }


        //        public Decimal M_ORIGINAL
        //        {
        //          get { return datos_ALTA_ADEUDO.M_ORIGINAL; }
        //          set { datos_ALTA_ADEUDO.M_ORIGINAL = value; }
        //        }


        //        public Decimal M_SALDO
        //        {
        //          get { return datos_ALTA_ADEUDO.M_SALDO; }
        //          set { datos_ALTA_ADEUDO.M_SALDO = value; }
        //        }


        new public String E_CUENTA
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_ADEUDO.E_CUENTA))
                    return String.Empty;
                return  DesEncripta(datos_ALTA_ADEUDO.E_CUENTA);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_ADEUDO.E_CUENTA = String.Empty;
                else
                   datos_ALTA_ADEUDO.E_CUENTA = Encripta(value);
            }
        }
        public String E_RFC
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_ADEUDO.E_RFC))
                    return String.Empty;
                return DesEncripta(datos_ALTA_ADEUDO.E_RFC);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_ADEUDO.E_RFC = String.Empty;
                else
                    datos_ALTA_ADEUDO.E_RFC = Encripta(value);
            }
        }

        public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_ADEUDO.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_ALTA_ADEUDO.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_ADEUDO.E_OBSERVACIONES = String.Empty;
                else
                    datos_ALTA_ADEUDO.E_OBSERVACIONES = Encripta(value);
            }
        }
        public String V_TIPO_MONEDA
        {
            get { return datos_ALTA_ADEUDO.V_TIPO_MONEDA; }
            set { datos_ALTA_ADEUDO.V_TIPO_MONEDA = value; }
        }

        public String CID_TIPO_PERSONA_OTORGANTE
        {
            get { return datos_ALTA_ADEUDO.CID_TIPO_PERSONA_OTORGANTE; }
            set { datos_ALTA_ADEUDO.CID_TIPO_PERSONA_OTORGANTE = value; }
        }
        public String NID_TERCERO
        {
            get { return datos_ALTA_ADEUDO.NID_TERCERO; }
            set { datos_ALTA_ADEUDO.NID_TERCERO = value; }
        }

      

        public String E_NOMBRE_TERCERO
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_ADEUDO.E_NOMBRE_TERCERO))
                    return String.Empty;
                return DesEncripta(datos_ALTA_ADEUDO.E_NOMBRE_TERCERO);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_ADEUDO.E_NOMBRE_TERCERO = String.Empty;
                else
                    datos_ALTA_ADEUDO.E_NOMBRE_TERCERO = Encripta(value);
            }
        }



        public String E_RFC_TERCERO
        {
            //get { return datos_ALTA_ADEUDO.E_RFC_TERCERO; }
            //set { datos_ALTA_ADEUDO.E_RFC_TERCERO = value; }

            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_ADEUDO.E_RFC_TERCERO))
                    return String.Empty;
                return DesEncripta(datos_ALTA_ADEUDO.E_RFC_TERCERO);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_ADEUDO.E_RFC_TERCERO = String.Empty;
                else
                    datos_ALTA_ADEUDO.E_RFC_TERCERO = Encripta(value);
            }
        }
        //        public Boolean L_AUTOGENERADO
        //        {
        //          get { return datos_ALTA_ADEUDO.L_AUTOGENERADO; }
        //          set { datos_ALTA_ADEUDO.L_AUTOGENERADO = value; }
        //        }


        //        public System.Nullable<Int32> NID_PATRIMONI_ASO
        //        {
        //          get { return datos_ALTA_ADEUDO.NID_PATRIMONI_ASO; }
        //          set { datos_ALTA_ADEUDO.NID_PATRIMONI_ASO = value; }
        //        }


        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_ALTA_ADEUDO.NID_PATRIMONIO; }
        //          set { datos_ALTA_ADEUDO.NID_PATRIMONIO = value; }
        //        }

        new public DateTime F_ADEUDO
        {
            get => datos_ALTA_ADEUDO.F_ADEUDO; 
            set
            {
                if (value >= DateTime.Now)
                    throw new CustomException("La fecha del adeudo no puede ser mayor que la fecha actual");
                datos_ALTA_ADEUDO.F_ADEUDO = value;
            }
        }

        public String V_PAIS => datos_ALTA_ADEUDO.V_PAIS;
        public String V_ENTIDAD_FEDERATIVA => datos_ALTA_ADEUDO.V_ENTIDAD_FEDERATIVA;

        public Decimal M_PAGOS {
            get => datos_ALTA_ADEUDO.M_PAGOS;
            set => datos_ALTA_ADEUDO.M_PAGOS = value;
        }


        #endregion


        #region *** Constructores (Extended) ***

        public blld_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION,  Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA,String V_LUGAR, Int32 NID_INSTITUCION,String V_OTRA, Int32 NID_TIPO_ADEUDO,DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, String V_TIPO_MONEDA, String E_RFC, String E_OBSERVACIONES, String CID_TIPO_PERSONA_OTORGANTE, List<Int32> ListaTitulares)
        : base()
        {
            if (ListaTitulares == null)
                throw new CustomException("Debe haber al menos un titular");
            if (ListaTitulares.Count == 0)
                throw new CustomException("Debe haber al menos un titular");
            if (F_ADEUDO >= DateTime.Now)
                throw new CustomException("La fecha del adeudo no puede ser mayor que la fecha actual");
            Int32 NID_ADEUDO = dald_ALTA_ADEUDO.nNuevo_NID_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            E_CUENTA = Encripta(E_CUENTA);
            E_OBSERVACIONES = Encripta(E_OBSERVACIONES);
            E_RFC = Encripta(E_RFC);
            Boolean L_AUTOGENERADO = false;
            datos_ALTA_ADEUDO = new dald_ALTA_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION,V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, V_TIPO_MONEDA, E_RFC, E_OBSERVACIONES, CID_TIPO_PERSONA_OTORGANTE, L_AUTOGENERADO, NID_PATRIMONIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
            foreach (Int32 x in ListaTitulares)
            {
                Add_ALTA_ADEUDO_TITULARs(x);
            }
        }

        public blld_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA,Decimal M_PAGOS, List<Int32> ListaTitulares)
         : base()
        {
            if (ListaTitulares == null)
                throw new CustomException("Debe haber al menos un titular");
            if (ListaTitulares.Count == 0)
                throw new CustomException("Debe haber al menos un titular");
            if (F_ADEUDO >= DateTime.Now)
                throw new CustomException("La fecha del adeudo no puede ser mayor que la fecha actual");
            Int32 NID_ADEUDO = dald_ALTA_ADEUDO.nNuevo_NID_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            E_CUENTA = Encripta(E_CUENTA);
            Boolean L_AUTOGENERADO = false;
            datos_ALTA_ADEUDO = new dald_ALTA_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_ADEUDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA, V_TIPO_MONEDA, E_RFC, E_OBSERVACIONES, CID_TIPO_PERSONA_OTORGANTE, M_PAGOS, L_AUTOGENERADO, NID_PATRIMONIO, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
            foreach (Int32 x in ListaTitulares)
            {
                Add_ALTA_ADEUDO_TITULARs(x);
            }
        }

        public blld_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO,DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA, List<Int32> ListaTitulares, Int32 NID,Int16 NID_TIPO_BIEN)
       : base()
        {
            E_CUENTA = Encripta(E_CUENTA);

           String Moneda = V_LUGAR.Split('|')[1];
            String Otorgante = V_LUGAR.Split('|')[2];
           String E_rfc = Encripta(V_LUGAR.Split('|')[3]);
            String Observaciones = Encripta(V_LUGAR.Split('|')[4]);
            String Nid_T = V_LUGAR.Split('|')[5];
            String Nombre_T = Encripta(V_LUGAR.Split('|')[6]);
            String E_rfc_t = Encripta(V_LUGAR.Split('|')[7]);
            V_LUGAR = V_LUGAR.Split('|')[0] + ";" + Moneda + ";" + Otorgante + ";" + E_rfc + ";" + Observaciones + ";" + Nid_T + ";" + Nombre_T + ";" + E_rfc_t;
            datos_ALTA_ADEUDO = new dald_ALTA_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO,F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA,ListaTitulares, NID, NID_TIPO_BIEN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }

        public blld_ALTA_ADEUDO(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, Int32 NID_INSTITUCION, String V_OTRA, Int32 NID_TIPO_ADEUDO, DateTime F_ADEUDO, Decimal M_ORIGINAL, Decimal M_SALDO, String E_CUENTA,Decimal M_PAGOS, List<Int32> ListaTitulares, Int32 NID, Int16 NID_TIPO_BIEN)
     : base()
        {
            E_CUENTA = Encripta(E_CUENTA);
            datos_ALTA_ADEUDO = new dald_ALTA_ADEUDO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, NID_INSTITUCION, V_OTRA, NID_TIPO_ADEUDO, F_ADEUDO, M_ORIGINAL, M_SALDO, E_CUENTA,M_PAGOS, ListaTitulares, NID, NID_TIPO_BIEN, ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_ALTA_ADEUDO_TITULARs()
        {
                _Reload_ALTA_ADEUDO_TITULARs();
        }

        public void Add_ALTA_ADEUDO_TITULARs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_ALTA_ADEUDO_TITULARs(NID_DEPENDIENTE,true);
            }
            catch (Exception e)
            {
                //if (e is ExistingPrimaryKeyException)
                //{
                //    ///Codigo Para Controlar la Excepcion de clave primaria existente
                //}
                //else
                //{
                //    throw e;
                //}
                throw e;
            }
        }

        public void update(List<Int32> ListDependientes)
        {
            if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");

            blld__l_ALTA_INMUEBLE_ADEUDO oCompruebaInmueble = new blld__l_ALTA_INMUEBLE_ADEUDO();
            oCompruebaInmueble.VID_NOMBRE = new StringFilter(VID_NOMBRE);
            oCompruebaInmueble.VID_FECHA = new StringFilter(VID_FECHA);
            oCompruebaInmueble.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
            oCompruebaInmueble.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
            oCompruebaInmueble.NID_ADEUDO = new IntegerFilter(NID_ADEUDO);
            oCompruebaInmueble.select();
            if (oCompruebaInmueble.lista_ALTA_INMUEBLE_ADEUDO.Any())
            {
                blld_ALTA_INMUEBLE oInmueble = new blld_ALTA_INMUEBLE(oCompruebaInmueble.lista_ALTA_INMUEBLE_ADEUDO.First().VID_NOMBRE
                                                                      , oCompruebaInmueble.lista_ALTA_INMUEBLE_ADEUDO.First().VID_FECHA
                                                                      , oCompruebaInmueble.lista_ALTA_INMUEBLE_ADEUDO.First().VID_HOMOCLAVE
                                                                      , oCompruebaInmueble.lista_ALTA_INMUEBLE_ADEUDO.First().NID_DECLARACION
                                                                      , oCompruebaInmueble.lista_ALTA_INMUEBLE_ADEUDO.First().NID_INMUEBLE);
                if (this.M_ORIGINAL > oInmueble.M_VALOR_INMUEBLE)
                    throw new CustomException("El monto original del adeudo no puede ser mayor que el valor del inmueble asociado");
                if (this.F_ADEUDO > oInmueble.F_ADQUISICION)
                    throw new CustomException("La fecha del adeudo no puede ser mayor que la fecha de adquisición del inmueble asociado");
            }
            else
            {
                blld__l_ALTA_VEHICULO_ADEUDO oCompruebaVehiculo = new blld__l_ALTA_VEHICULO_ADEUDO();
                oCompruebaVehiculo.VID_NOMBRE = new StringFilter(VID_NOMBRE);
                oCompruebaVehiculo.VID_FECHA = new StringFilter(VID_FECHA);
                oCompruebaVehiculo.VID_HOMOCLAVE = new StringFilter(VID_HOMOCLAVE);
                oCompruebaVehiculo.NID_DECLARACION = new IntegerFilter(NID_DECLARACION);
                oCompruebaVehiculo.NID_ADEUDO = new IntegerFilter(NID_ADEUDO);
                oCompruebaVehiculo.select();
                if (oCompruebaVehiculo.lista_ALTA_VEHICULO_ADEUDO.Any())
                {
                    blld_ALTA_VEHICULO oVehiculo = new blld_ALTA_VEHICULO(oCompruebaVehiculo.lista_ALTA_VEHICULO_ADEUDO.First().VID_NOMBRE
                                                                    , oCompruebaVehiculo.lista_ALTA_VEHICULO_ADEUDO.First().VID_FECHA
                                                                    , oCompruebaVehiculo.lista_ALTA_VEHICULO_ADEUDO.First().VID_HOMOCLAVE
                                                                    , oCompruebaVehiculo.lista_ALTA_VEHICULO_ADEUDO.First().NID_DECLARACION
                                                                    , oCompruebaVehiculo.lista_ALTA_VEHICULO_ADEUDO.First().NID_VEHICULO);

                    if (this.M_ORIGINAL > oVehiculo.M_VALOR_VEHICULO)
                        throw new CustomException("El monto original del adeudo no puede ser mayor que el valor del vehículo asociado");
                    if (this.F_ADEUDO > oVehiculo.F_ADQUISICION)
                        throw new CustomException("La fecha del adeudo no puede ser mayor que la fecha de adquisición del vehículo asociado");

                }
            }

            List<blld_ALTA_ADEUDO_TITULAR> listAux = new List<blld_ALTA_ADEUDO_TITULAR>();
            foreach(blld_ALTA_ADEUDO_TITULAR o in ALTA_ADEUDO_TITULARs)
            {
                listAux.Add(o);
            }
            foreach(blld_ALTA_ADEUDO_TITULAR select in listAux)
            {
                if (!ListDependientes.Contains(select.NID_DEPENDIENTE))
                    ALTA_ADEUDO_TITULARs.Remove(select);
            }
            foreach(Int32 nid_Dependiente in ListDependientes)
            {
                Add_ALTA_ADEUDO_TITULARs(nid_Dependiente);
            }
            datos_ALTA_ADEUDO.update();
        }

        new public void delete()
        {
            if (this.L_AUTOGENERADO)
                throw new CustomException("El adeudo se creo a partir de un bien patrimonial debe eliminarse desde dicho bien");
            //int val = ALTA_ADEUDO_TITULARs.Count - 1;
            //for (int i = val; i >= 0; i--)
            //{
            //    try { ALTA_ADEUDO_TITULARs.RemoveAt(i); } catch { };
            //}

            base.delete();
        }

        public void deleteConInmueble(Int32 NID_INMUEBLE)
        {
            //Reload_ALTA_ADEUDO_TITULARs();
            //int val = ALTA_ADEUDO_TITULARs.Count - 1;
            //for (int i = val; i >= 0; i--)
            //{
            //    try { ALTA_ADEUDO_TITULARs.RemoveAt(i); } catch { };
            //}

            //String NOMBRE = this.VID_NOMBRE;
            //String FECHA = this.VID_FECHA;
            //String HOMOCLAVE = this.VID_HOMOCLAVE;
            //Int32 DECLARACION = this.NID_DECLARACION;
            //    Int32 ADEUDO = this.NID_ADEUDO;
            base.delete();
            //try
            //{
            //    blld_ALTA_INMUEBLE_ADEUDO o = new blld_ALTA_INMUEBLE_ADEUDO(NOMBRE, FECHA, HOMOCLAVE, DECLARACION, NID_INMUEBLE, ADEUDO);
            //    o.delete();
            //}
            //catch { }
        }

        public void deleteConVehiculo(Int32 NID_VEHICULO)
        {
            //Reload_ALTA_ADEUDO_TITULARs();
            //int val = ALTA_ADEUDO_TITULARs.Count - 1;
            //for (int i = val; i >= 0; i--)
            //{
            //    try { ALTA_ADEUDO_TITULARs.RemoveAt(i); } catch { };
            //}

            //String NOMBRE = this.VID_NOMBRE;
            //String FECHA = this.VID_FECHA;
            //String HOMOCLAVE = this.VID_HOMOCLAVE;
            //Int32 DECLARACION = this.NID_DECLARACION;
            //Int32 ADEUDO = this.NID_ADEUDO;
            base.delete();
            //try
            //{
            //    blld_ALTA_VEHICULO_ADEUDO o = new blld_ALTA_VEHICULO_ADEUDO(NOMBRE, FECHA, HOMOCLAVE, DECLARACION, NID_VEHICULO);
            //    o.delete();
            //}
            //catch { }
        }



        #endregion

    }
}
