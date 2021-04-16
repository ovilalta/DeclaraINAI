using Declara_V2.BLL;
using Declara_V2.DALD;
using Declara_V2.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Declara_V2.BLLD
{
    // Extended
    public partial class blld_ALTA_INVERSION : bll_ALTA_INVERSION
    {

        #region *** Atributos (Extended) ***

        //        public String VID_NOMBRE
        //        {
        //          get { return datos_ALTA_INVERSION.VID_NOMBRE; }
        //        }

        //        public String VID_FECHA
        //        {
        //          get { return datos_ALTA_INVERSION.VID_FECHA; }
        //        }

        //        public String VID_HOMOCLAVE
        //        {
        //          get { return datos_ALTA_INVERSION.VID_HOMOCLAVE; }
        //        }

        //        public Int32 NID_DECLARACION
        //        {
        //          get { return datos_ALTA_INVERSION.NID_DECLARACION; }
        //        }

        //        public Int32 NID_INVERSION
        //        {
        //          get { return datos_ALTA_INVERSION.NID_INVERSION; }
        //        }


        //        public Int32 NID_TIPO_INVERSION
        //        {
        //          get { return datos_ALTA_INVERSION.NID_TIPO_INVERSION; }
        //          set { datos_ALTA_INVERSION.NID_TIPO_INVERSION = value; }
        //        }


        //        public Int32 NID_SUBTIPO_INVERSION
        //        {
        //          get { return datos_ALTA_INVERSION.NID_SUBTIPO_INVERSION; }
        //          set { datos_ALTA_INVERSION.NID_SUBTIPO_INVERSION = value; }
        //        }


        //        public Int32 NID_INSTITUCION
        //        {
        //          get { return datos_ALTA_INVERSION.NID_INSTITUCION; }
        //          set { datos_ALTA_INVERSION.NID_INSTITUCION = value; }
        //        }


        new public String E_CUENTA
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_INVERSION.E_CUENTA))
                    return String.Empty;
                return DesEncripta(datos_ALTA_INVERSION.E_CUENTA);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_INVERSION.E_CUENTA = String.Empty;
                else
                    datos_ALTA_INVERSION.E_CUENTA = Encripta(value);
            }
        }


        //        public String V_CUENTA_CORTO
        //        {
        //          get { return datos_ALTA_INVERSION.V_CUENTA_CORTO; }
        //          set { datos_ALTA_INVERSION.V_CUENTA_CORTO = value; }
        //        }


        //        public String V_OTRO
        //        {
        //          get { return datos_ALTA_INVERSION.V_OTRO; }
        //          set { datos_ALTA_INVERSION.V_OTRO = value; }
        //        }


        //        public Decimal M_SALDO
        //        {
        //          get { return datos_ALTA_INVERSION.M_SALDO; }
        //          set { datos_ALTA_INVERSION.M_SALDO = value; }
        //        }

        new public DateTime F_APERTURA
        {
            get => datos_ALTA_INVERSION.F_APERTURA;
            set
            {
                if (value >= DateTime.Now)
                    throw new CustomException("La fecha de apertura de la inversión no puede ser mayor que la fecha actual");
                datos_ALTA_INVERSION.F_APERTURA = value;
            }
        }

        new public Int32 NID_PAIS
        {
            get => datos_ALTA_INVERSION.NID_PAIS;
            set
            {
                if (!value.Equals(datos_ALTA_INVERSION.NID_PAIS))
                {
                    datos_ALTA_INVERSION._oPais = null;
                    datos_ALTA_INVERSION._oEntidad = null;
                }
                datos_ALTA_INVERSION.NID_PAIS = value;
            }
        }


        new public String CID_ENTIDAD_FEDERATIVA
        {
            get => datos_ALTA_INVERSION.CID_ENTIDAD_FEDERATIVA;
            set
            {
                if (!value.Equals(datos_ALTA_INVERSION.CID_ENTIDAD_FEDERATIVA))
                {
                    datos_ALTA_INVERSION._oEntidad = null;
                }
                datos_ALTA_INVERSION.CID_ENTIDAD_FEDERATIVA = value;
            }
        }

        public String V_PAIS => datos_ALTA_INVERSION.oPais.V_PAIS;
        public String V_ENTIDAD_FEDERATIVA => datos_ALTA_INVERSION.oEntidad.V_ENTIDAD_FEDERATIVA;


        //        public String V_LUGAR
        //        {
        //          get { return datos_ALTA_INVERSION.V_LUGAR; }
        //          set { datos_ALTA_INVERSION.V_LUGAR = value; }
        //        }


        //        public Int32 NID_PATRIMONIO
        //        {
        //          get { return datos_ALTA_INVERSION.NID_PATRIMONIO; }
        //          set { datos_ALTA_INVERSION.NID_PATRIMONIO = value; }
        //        }






        //public Decimal M_SALDO
        //{ 
        //    get
        //    {
        //        return Convert.ToDecimal(DesEncripta(datos_ALTA_INVERSION.M_SALDO.ToString()));
        //    }
        //    set
        //    {

        //            datos_ALTA_INVERSION.M_SALDO = Encripta(value);
        //    }
        //}





        public String V_RFC_INVERSION
        {
            get { return datos_ALTA_INVERSION.V_RFC_INVERSION; }
            set { datos_ALTA_INVERSION.V_RFC_INVERSION = value; }
        }


        public String V_TIPO_MONEDA
        {
            get { return datos_ALTA_INVERSION.V_TIPO_MONEDA; }
            set { datos_ALTA_INVERSION.V_TIPO_MONEDA = value; }
        }


        blld_ALTA_INVERSION_COPROPIETARIO _ALTA_INVERSION_COPROPIETARIO { get; set; }

        public blld_ALTA_INVERSION_COPROPIETARIO ALTA_INVERSION_COPROPIETARIO
        {
            get
            {
                try
                {
                    if (_ALTA_INVERSION_COPROPIETARIO == null)
                        _ALTA_INVERSION_COPROPIETARIO = new blld_ALTA_INVERSION_COPROPIETARIO(this.VID_NOMBRE
                                                                                        , this.VID_FECHA
                                                                                        , this.VID_HOMOCLAVE
                                                                                        , this.NID_DECLARACION
                                                                                        , this.NID_INVERSION
                                                                                        , 1);
                }
                catch (Exception ex)
                {

                }
                return _ALTA_INVERSION_COPROPIETARIO;
            }
            set => _ALTA_INVERSION_COPROPIETARIO = value;
        }


        //public String V_TERCERO_TIPO
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(datos_ALTA_INVERSION.V_TERCERO_TIPO))
        //            return String.Empty;
        //        return DesEncripta(datos_ALTA_INVERSION.V_TERCERO_TIPO);
        //    }
        //    set
        //    {
        //        if (String.IsNullOrEmpty(value))
        //            datos_ALTA_INVERSION.V_TERCERO_TIPO = String.Empty;
        //        else
        //            datos_ALTA_INVERSION.V_TERCERO_TIPO = Encripta(value);
        //    }
        //}
        //public String V_TERCERO_NOMBRE
        //{
        //    get { return datos_ALTA_INVERSION.V_TERCERO_NOMBRE; }
        //    set { datos_ALTA_INVERSION.V_TERCERO_NOMBRE = value; }
        //}
        //public String V_TERCERO_RFC
        //{
        //    get { return datos_ALTA_INVERSION.V_TERCERO_RFC; }
        //    set { datos_ALTA_INVERSION.V_TERCERO_RFC = value; }
        //}

        public String E_OBSERVACIONES
        {
            get
            {
                if (String.IsNullOrEmpty(datos_ALTA_INVERSION.E_OBSERVACIONES))
                    return String.Empty;
                return DesEncripta(datos_ALTA_INVERSION.E_OBSERVACIONES);
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    datos_ALTA_INVERSION.E_OBSERVACIONES = String.Empty;
                else
                    datos_ALTA_INVERSION.E_OBSERVACIONES = Encripta(value);
            }
        }
        #endregion


        #region *** Constructores (Extended) ***

        public blld_ALTA_INVERSION(String VID_NOMBRE, String VID_FECHA, String VID_HOMOCLAVE, Int32 NID_DECLARACION, Int32 NID_TIPO_INVERSION, Int32 NID_SUBTIPO_INVERSION, Int32 NID_INSTITUCION, String E_CUENTA, String V_OTRO, Decimal M_SALDO, Int32 NID_PAIS, String CID_ENTIDAD_FEDERATIVA, String V_LUGAR, DateTime F_APERTURA, String V_RFC_INVERSION, String V_TIPO_MONEDA, String V_TERCERO_TIPO, String V_TERCERO_NOMBRE, String V_TERCERO_RFC, String E_OBSERVACIONES, List<Int32> ListaTitulares)
        : base()
        {

            if (V_TERCERO_TIPO != "")
            {

                if (V_TERCERO_NOMBRE == string.Empty)
                    throw new CustomException("El nombre de la persona es requerido");

                switch (V_TERCERO_TIPO)
                {
                    case "F":
                        if (V_TERCERO_RFC.Length < 13)
                            throw new CustomException("El RFC del tercero no corresponde con el tipo de persona");

                        break;
                    case "M":
                        if (V_TERCERO_RFC.Length > 12)
                            throw new CustomException("El RFC del tercero no corresponde con el tipo de persona");
                        break;
                    default:

                        break;
                }
            }

            Int32 NID_INVERSION = dald_ALTA_INVERSION.nNuevo_NID_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            Int32 NID_PATRIMONIO = dald_PATRIMONIO.nNuevo_NID_PATRIMONIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION);
            if (F_APERTURA >= DateTime.Now)
                throw new CustomException("La fecha de apertura de la inversión no puede ser mayor que la fecha actual");
            if (ListaTitulares.Count == 0)
                throw new CustomException("Debe seleccionar por lo menos un dependiente");

            String V_CUENTA_CORTO = String.Empty;
            if (E_CUENTA.Length > 4)
            {
                V_CUENTA_CORTO = String.Concat("*", E_CUENTA.Substring(E_CUENTA.Length - 4, 4));
            }
            else
            {
                V_CUENTA_CORTO = E_CUENTA.PadLeft(5, '*');
            }
            E_CUENTA = Encripta(E_CUENTA);
            datos_ALTA_INVERSION = new dald_ALTA_INVERSION(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, NID_TIPO_INVERSION, NID_SUBTIPO_INVERSION, NID_INSTITUCION, E_CUENTA, V_CUENTA_CORTO, V_OTRO, M_SALDO, NID_PAIS, CID_ENTIDAD_FEDERATIVA, V_LUGAR, F_APERTURA, NID_PATRIMONIO, V_RFC_INVERSION, V_TIPO_MONEDA, Encripta(E_OBSERVACIONES), ExistingPrimaryKeyException.ExistingPrimaryKeyConditions.ThrowException);
            foreach (Int32 x in ListaTitulares)
            {
                Add_ALTA_INVERSION_TITULARs(x);
            }

            if (V_TERCERO_TIPO != "" && V_TERCERO_NOMBRE != "")
            {
                blld_ALTA_INVERSION_COPROPIETARIO o = new blld_ALTA_INVERSION_COPROPIETARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, 1, Encripta(V_TERCERO_TIPO), V_TERCERO_NOMBRE, V_TERCERO_RFC);
            }
        }


        #endregion


        #region *** Metodos (Extended) ***

        public void Reload_ALTA_INVERSION_TITULARs()
        {
            _Reload_ALTA_INVERSION_TITULARs();
        }

        public void Add_ALTA_INVERSION_TITULARs(Int32 NID_DEPENDIENTE)
        {
            try
            {
                _Add_ALTA_INVERSION_TITULARs(NID_DEPENDIENTE, true);
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
        }

        public void update(List<Int32> ListDependientes, String CID_TIPO_PERSONA, String V_NOMBRE, String V_RFC)
        {
            if (ListDependientes == null) throw new CustomException("Debe haber al menos un titular");
            if (ListDependientes.Count == 0) throw new CustomException("Debe haber al menos un titular");

            List<blld_ALTA_INVERSION_TITULAR> listAux = new List<blld_ALTA_INVERSION_TITULAR>();
            foreach (blld_ALTA_INVERSION_TITULAR o in ALTA_INVERSION_TITULARs)
            {
                listAux.Add(o);
            }

            foreach (blld_ALTA_INVERSION_TITULAR select in listAux)
            {
                if (!ListDependientes.Contains(select.NID_DEPENDIENTE))
                    ALTA_INVERSION_TITULARs.Remove(select);
            }

            foreach (Int32 nid_Dependiente in ListDependientes)
            {
                Add_ALTA_INVERSION_TITULARs(nid_Dependiente);

            }

            datos_ALTA_INVERSION.update();


            try
            {
                blld__l_ALTA_INVERSION_COPROPIETARIO op = new blld__l_ALTA_INVERSION_COPROPIETARIO();
                op.select();

                if (op.lista_ALTA_INVERSION_COPROPIETARIO.Count > 0)
                {

                    if (!String.IsNullOrEmpty(CID_TIPO_PERSONA) && V_NOMBRE != "")
                    {

                        var lis = op.lista_ALTA_INVERSION_COPROPIETARIO.ToList()
                                     .Where(p => p.VID_NOMBRE == VID_NOMBRE)
                                     .Where(p => p.VID_FECHA == VID_FECHA)
                                     .Where(p => p.VID_HOMOCLAVE == VID_HOMOCLAVE)
                                     .Where(p => p.NID_DECLARACION == NID_DECLARACION)
                                     .Where(p => p.NID_INVERSION == NID_INVERSION).ToList();

                        if (lis.Count > 0)
                        {
                            blld_ALTA_INVERSION_COPROPIETARIO oCompro = new blld_ALTA_INVERSION_COPROPIETARIO(
                                                                          datos_ALTA_INVERSION.VID_NOMBRE
                                                                        , datos_ALTA_INVERSION.VID_FECHA
                                                                        , datos_ALTA_INVERSION.VID_HOMOCLAVE
                                                                        , datos_ALTA_INVERSION.NID_DECLARACION
                                                                        , datos_ALTA_INVERSION.NID_INVERSION
                                                                        , 1
                                                                    );

                            oCompro.V_NOMBRE = V_NOMBRE;
                            oCompro.V_RFC = V_RFC;
                            oCompro.CID_TIPO_PERSONA = CID_TIPO_PERSONA;
                            oCompro.update();
                        }
                        else
                        {
                            blld_ALTA_INVERSION_COPROPIETARIO o = new blld_ALTA_INVERSION_COPROPIETARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, 1, Encripta(CID_TIPO_PERSONA), V_NOMBRE, V_RFC);
                        }
                    }
                    else
                    {
                        var lis = op.lista_ALTA_INVERSION_COPROPIETARIO.ToList()
                                   .Where(p => p.VID_NOMBRE == VID_NOMBRE)
                                   .Where(p => p.VID_FECHA == VID_FECHA)
                                   .Where(p => p.VID_HOMOCLAVE == VID_HOMOCLAVE)
                                   .Where(p => p.NID_DECLARACION == NID_DECLARACION)
                                   .Where(p => p.NID_INVERSION == NID_INVERSION).ToList();

                        if (lis.Count > 0)
                        {
                            blld_ALTA_INVERSION_COPROPIETARIO oCompro = new blld_ALTA_INVERSION_COPROPIETARIO(
                                                                          datos_ALTA_INVERSION.VID_NOMBRE
                                                                        , datos_ALTA_INVERSION.VID_FECHA
                                                                        , datos_ALTA_INVERSION.VID_HOMOCLAVE
                                                                        , datos_ALTA_INVERSION.NID_DECLARACION
                                                                        , datos_ALTA_INVERSION.NID_INVERSION
                                                                        , 1
                                                                    );
                            oCompro.delete();
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(CID_TIPO_PERSONA) && V_NOMBRE != "")
                    {
                        blld_ALTA_INVERSION_COPROPIETARIO o = new blld_ALTA_INVERSION_COPROPIETARIO(VID_NOMBRE, VID_FECHA, VID_HOMOCLAVE, NID_DECLARACION, NID_INVERSION, 1, Encripta(CID_TIPO_PERSONA), V_NOMBRE, V_RFC);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        new public void delete()
        {
            blld_ALTA_INVERSION_COPROPIETARIO oCompro = new blld_ALTA_INVERSION_COPROPIETARIO(
                                                              datos_ALTA_INVERSION.VID_NOMBRE
                                                            , datos_ALTA_INVERSION.VID_FECHA
                                                            , datos_ALTA_INVERSION.VID_HOMOCLAVE
                                                            , datos_ALTA_INVERSION.NID_DECLARACION
                                                            , datos_ALTA_INVERSION.NID_INVERSION
                                                            , 1
                                                        );
            oCompro.delete();
            base.delete();
        }

        #endregion

    }
}
