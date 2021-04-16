using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;
using DeclaraINE.Formas.Patrimonio;
using System.Data;

namespace DeclaraINE.Formas.Patrimonio
{
    public partial class Patrimonio : Pagina
    {

        internal Boolean lEditar
        {
            get => (Boolean)ViewState["lEditar"];
            set => ViewState["lEditar"] = value;
        }

        blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }


        blld__l_PATRIMONIO _oPatrimonio
        {
            get => (blld__l_PATRIMONIO)Session["oPatrimonio"];
            set => SessionAdd("oPatrimonio", value);
        }

        internal Int32 IndiceItemSeleccionado
        {
            get
            {
                if (ViewState["IndiceItemSeleccionado"] == null) return -1;
                return (Int32)ViewState["IndiceItemSeleccionado"];
            }

            set
            {
                if (ViewState["IndiceItemSeleccionado"] == null) ViewState.Add("IndiceItemSeleccionado", value);
                ViewState["IndiceItemSeleccionado"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            blld__l_PATRIMONIO oPatrimonio;

            if (!IsPostBack)
            {
                blld_USUARIO oUsuario = _oUsuario;


                oPatrimonio = new blld__l_PATRIMONIO();
                oPatrimonio.VID_NOMBRE = new Declara_V2.StringFilter(oUsuario.VID_NOMBRE);
                oPatrimonio.VID_FECHA = new Declara_V2.StringFilter(oUsuario.VID_FECHA);
                oPatrimonio.VID_HOMOCLAVE = new Declara_V2.StringFilter(oUsuario.VID_HOMOCLAVE);
                oPatrimonio.L_ACTIVO = true;
                oPatrimonio.select();

                _oPatrimonio = oPatrimonio;

            }
            else
                oPatrimonio = _oPatrimonio;

            foreach (PATRIMONIO oPat in oPatrimonio.lista_PATRIMONIO)
            {
                switch (oPat.NID_TIPO)
                {
                    case 1:
                        conInmuebles(new blld_PATRIMONIO(oPat));
                        break;
                    case 2:
                        conVehiculos(new blld_PATRIMONIO(oPat));
                        break;
                    case 3:
                        conMuebles(new blld_PATRIMONIO(oPat));
                        break;
                    case 4:
                        conInversiones(new blld_PATRIMONIO(oPat));
                        break;
                    case 5:
                        conAdeudos(new blld_PATRIMONIO(oPat));
                        break;

                    default:
                        break;
                }

            }

        }

 

        public void OnEditar(object sender, ItemEventArgs e)
        {
            blld_USUARIO oUsuario = _oUsuario;

            List<Detalle> ListaDetalle = new List<Detalle>();

            blld_PATRIMONIO oPatrimonio = new blld_PATRIMONIO(oUsuario.VID_NOMBRE
                                                                     , oUsuario.VID_FECHA
                                                                     , oUsuario.VID_HOMOCLAVE
                                                                     , e.Id);            

            switch (oPatrimonio.NID_TIPO)
            {
                 case 1:
                    mppDetalles.HeaderText = "Consulta de inmueble";
                    mppDetalles.Show(true);
                    ListaDetalle.Add(new Detalle { Etiqueta = "Tipo de bien", Texto = oPatrimonio.PATRIMONIO_INMUEBLE.V_TIPO });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Ubicación del Inmueble", Texto = oPatrimonio.PATRIMONIO_INMUEBLE.E_UBICACION });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Superficie del terreno m²", Texto = oPatrimonio.PATRIMONIO_INMUEBLE.N_TERRENO.ToString() });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Superficie de construccion m²", Texto = oPatrimonio.PATRIMONIO_INMUEBLE.N_CONSTRUCCION.ToString() });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Fecha de adquisición", Texto = oPatrimonio.PATRIMONIO_INMUEBLE.F_ADQUISICION.ToString(strFormatoFecha) });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Valor de adquisición", Texto =  "$ " + oPatrimonio.PATRIMONIO_INMUEBLE.M_VALOR_INMUEBLE.ToString() });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Tipo de uso", Texto = oPatrimonio.PATRIMONIO_INMUEBLE.V_USO });
                    grdDetalles.DataBind(ListaDetalle);
                    break;
                case 2:
                    mppDetalles.HeaderText = "Consulta de vehículo";
                    mppDetalles.Show(true);
                    ListaDetalle.Add(new Detalle { Etiqueta = "Marca", Texto = oPatrimonio.PATRIMONIO_VEHICULO.V_MARCA });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Descripción del vehículo", Texto = oPatrimonio.PATRIMONIO_VEHICULO.V_DESCRIPCION });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Fecha de adquisición", Texto = oPatrimonio.PATRIMONIO_VEHICULO.F_ADQUISICION.ToString(strFormatoFecha) });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Modelo", Texto = oPatrimonio.PATRIMONIO_VEHICULO.C_MODELO });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Valor de adquisición", Texto = "$ " + Convert.ToString(oPatrimonio.PATRIMONIO_VEHICULO.M_VALOR_VEHICULO) });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Tipo de uso", Texto = oPatrimonio.PATRIMONIO_VEHICULO.V_USO });
                    grdDetalles.DataBind(ListaDetalle);
                    break;
                case 3:
                    mppDetalles.HeaderText = "Consulta de mueble";
                    mppDetalles.Show(true);
                    ListaDetalle.Add(new Detalle { Etiqueta = "Tipo de bien", Texto = oPatrimonio.PATRIMONIO_MUEBLE.V_TIPO });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Especificar tipo de bien", Texto = oPatrimonio.PATRIMONIO_MUEBLE.E_ESPECIFICACION });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Valor de adquisición", Texto = "$ " + Convert.ToString(oPatrimonio.PATRIMONIO_MUEBLE.M_VALOR) });
                    grdDetalles.DataBind(ListaDetalle);
                    break;
                case 4:
                    mppDetalles.HeaderText = "Consulta de Inversion";
                    mppDetalles.Show(true);
                    ListaDetalle.Add(new Detalle { Etiqueta = "Tipo de Inversión", Texto = oPatrimonio.PATRIMONIO_INVERSION.V_SUBTIPO_INVERSION });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Localización de la Inversión", Texto = oPatrimonio.PATRIMONIO_INVERSION.V_LUGAR });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Institución o Razón Social", Texto = oPatrimonio.PATRIMONIO_INVERSION.V_INSTITUCION });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Saldo", Texto = "$ " + Convert.ToString(oPatrimonio.PATRIMONIO_INVERSION.M_SALDO) });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Número de Cuenta o Contrato", Texto = oPatrimonio.PATRIMONIO_INVERSION.E_CUENTA });
                    grdDetalles.DataBind(ListaDetalle);
                    break;
                case 5:
                    mppDetalles.HeaderText = "Consulta de adeudo";
                    mppDetalles.Show(true);
                    ListaDetalle.Add(new Detalle { Etiqueta = "Tipo de Adeudo", Texto = oPatrimonio.PATRIMONIO_ADEUDO.V_TIPO_ADEUDO });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Localización del Adeudo", Texto = oPatrimonio.PATRIMONIO_ADEUDO.V_LUGAR });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Institución o Razón Social", Texto = oPatrimonio.PATRIMONIO_ADEUDO.V_INSTITUCION });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Monto original del Adeudo", Texto = "$ " + Convert.ToString(oPatrimonio.PATRIMONIO_ADEUDO.M_SALDO) });
                    ListaDetalle.Add(new Detalle { Etiqueta = "Número de Cuenta o Contrato", Texto = oPatrimonio.PATRIMONIO_ADEUDO.E_CUENTA });
                    grdDetalles.DataBind(ListaDetalle);
                    break;
            }

        }
 
        private void conInmuebles(blld_PATRIMONIO oPatrimonio)
        {
            try
            {
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oPatrimonio.NID_PATRIMONIO;
                ((Item)item).ID = String.Concat("Inmueble_", oPatrimonio.NID_PATRIMONIO);
                ((Item)item).TextoPrincipal = oPatrimonio.PATRIMONIO_INMUEBLE.V_TIPO;
                ((Item)item).TextoSecundario = oPatrimonio.PATRIMONIO_INMUEBLE.E_UBICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INMUEBLE/", oPatrimonio.PATRIMONIO_INMUEBLE.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                grdInmueble.Controls.AddAt(0, item);
            }
            catch { }
        }


        private void conMuebles(blld_PATRIMONIO oPatrimonio)
        {
            try
            {
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oPatrimonio.NID_PATRIMONIO;
                ((Item)item).ID = String.Concat("Mueble_", oPatrimonio.NID_PATRIMONIO);
                ((Item)item).TextoPrincipal = oPatrimonio.PATRIMONIO_MUEBLE.V_TIPO;
                ((Item)item).TextoSecundario = oPatrimonio.PATRIMONIO_MUEBLE.E_ESPECIFICACION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_MUEBLE/", oPatrimonio.PATRIMONIO_MUEBLE.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                grdMueble.Controls.AddAt(0, item);
            }
            catch { }
        }

        private void conVehiculos(blld_PATRIMONIO oPatrimonio)
        {
            try
            {
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oPatrimonio.NID_PATRIMONIO;
                ((Item)item).ID = String.Concat("Vehiculo_", oPatrimonio.NID_PATRIMONIO);
                ((Item)item).TextoPrincipal = oPatrimonio.PATRIMONIO_VEHICULO.V_MARCA;
                ((Item)item).TextoSecundario = oPatrimonio.PATRIMONIO_VEHICULO.V_DESCRIPCION;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_VEHICULO/", oPatrimonio.NID_TIPO, ".png");
                ((Item)item).Editar += OnEditar;
                grdVehiculos.Controls.AddAt(0, item);
            }
            catch { }
        }

        private void conInversiones(blld_PATRIMONIO oPatrimonio)
        {
            try
            {
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oPatrimonio.NID_PATRIMONIO;
                ((Item)item).ID = String.Concat("Inversion_", oPatrimonio.NID_PATRIMONIO);
                ((Item)item).TextoPrincipal = oPatrimonio.PATRIMONIO_INVERSION.NID_TIPO_INVERSION + "<br>" + oPatrimonio.PATRIMONIO_INVERSION.V_SUBTIPO_INVERSION;
                ((Item)item).TextoSecundario = "<br>No. Cuenta :" + oPatrimonio.PATRIMONIO_INVERSION.E_CUENTA + "<br> Saldo : " + oPatrimonio.PATRIMONIO_INVERSION.M_SALDO.ToString("C"); ;
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_INVERSION/", oPatrimonio.PATRIMONIO_INVERSION.NID_TIPO_INVERSION, ".png");
                ((Item)item).Editar += OnEditar;
                grdInversiones.Controls.AddAt(0, item);
            }
            catch { }
        }

        private void conAdeudos(blld_PATRIMONIO oPatrimonio)
        {
            try
            {
                UserControl item = (UserControl)Page.LoadControl("item.ascx");
                ((Item)item).Id = oPatrimonio.NID_PATRIMONIO;
                ((Item)item).ID = String.Concat("Adeudo_", oPatrimonio.NID_PATRIMONIO);
                ((Item)item).TextoPrincipal = oPatrimonio.PATRIMONIO_ADEUDO.V_TIPO_ADEUDO;
                ((Item)item).TextoSecundario = "No. Cuenta:" + oPatrimonio.PATRIMONIO_ADEUDO.E_CUENTA + "<br> Monto original: " + oPatrimonio.PATRIMONIO_ADEUDO.M_ORIGINAL.ToString("C") + "<br>  Saldo : " + oPatrimonio.PATRIMONIO_ADEUDO.M_SALDO.ToString("C");
                ((Item)item).ImageUrl = String.Concat("../../Images/CAT_TIPO_ADEUDO/", oPatrimonio.PATRIMONIO_ADEUDO.NID_TIPO_ADEUDO, ".png");
                ((Item)item).Editar += OnEditar;
                grdAdeudo.Controls.AddAt(0, item);
            }
            catch { }
        }

        protected void btnCerrarDetalles_Click(object sender, EventArgs e)
        {
            grdDetalles.DataBind(new List<Object>());
            mppDetalles.Hide();
        }

    }

    public class Detalle
    {
        public String Etiqueta { get; set; }
        public String Texto { get; set; }
    }
}