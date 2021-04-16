using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;


namespace DeclaraINE.Formas.DeclaracionConclusion
{
    public partial class AdeudoModificacion : System.Web.UI.UserControl
    {
        public String Requerido
        {
            get
            {
                if (ViewState["req"] == null)
                    return String.Empty;
                return ViewState["req"].ToString();
            }
            set
            {
                ViewState["req"] = value;
                req();
            }
        }
        private void SessionAdd(String ObjectName, Object Objeto)
        {
            if (Session[ObjectName] == null) Session.Add(ObjectName, Objeto);
            else Session[ObjectName] = Objeto;
        }

        private blld_USUARIO _oUsuario
        {
            get => (blld_USUARIO)Session["oUsuario"];
            set => SessionAdd("oUsuario", value);
        }

        private blld_DECLARACION _oDeclaracion
        {
            get => (blld_DECLARACION)Session["oDeclaracion"];
            set => SessionAdd("oDeclaracion", value);
        }



        //public System.Nullable<Decimal> M_PAGOS
        //{
        //    get => moneytxtM_ORIGINAL.MoneyNullable();
        //    set
        //    {
        //        if (value.HasValue)
        //            moneytxtM_ORIGINAL.Text = value.Value.ToString("C");
        //        else
        //            moneytxtM_ORIGINAL.Text = String.Empty;
        //    }
        //}

        public System.Nullable<Decimal> M_SALDO
        {
            get => moneytxtM_SALDO.MoneyNullable();
            set
            {
                if (value.HasValue)
                    moneytxtM_SALDO.Text = value.Value.ToString("C");
                else
                    moneytxtM_SALDO.Text = String.Empty;
            }
        }


        public List<Int32> NID_TITULARs
        {
            get
            {
                if (cblTitulares.SelectedValuesInteger() == null)
                    return new List<Int32>();
                else
                    return cblTitulares.SelectedValuesInteger();
            }
            set
            {
                cblTitulares.ClearSelection();
                if (value != null)
                    foreach (Int32 ID in value)
                        cblTitulares.Items.FindByValue(ID.ToString()).Selected = true;
            }
        }

        public Int32 IndiceItemSeleccionado
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
            if (!IsPostBack)
            {
                req();
                blld_DECLARACION oDeclaracion = _oDeclaracion;
                cblTitulares.DataBind(oDeclaracion.DECLARACION_DEPENDIENTESs, DECLARACION_DEPENDIENTES.Properties.NID_DEPENDIENTE, DECLARACION_DEPENDIENTES.Properties.V_NOMBRE_COMPLETO_TIPO);
                cblTitulares.Items.Insert(0, new ListItem("Declarante", "0"));
                cblTitulares.Items.Insert(cblTitulares.Items.Count, new ListItem("Copropietario", "-1"));


            }
        }

        private void req()
        {
            if (!String.IsNullOrEmpty(Requerido))
            {
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is TextBox)
                    {
                        ((TextBox)ctr).Attributes.Add("requerido", Requerido);
                    }
                    else if (ctr is DropDownList)
                    {
                        ((DropDownList)ctr).Attributes.Add("requerido", Requerido);
                    }
                }
            }
        }


        public void Clear()
        {
            //moneytxtM_ORIGINAL.Text = String.Empty;
            moneytxtM_SALDO.Text = String.Empty;
            try { cblTitulares.ClearSelection(); } catch { }
        }
    }
}