using AlanWebControls;
using Declara_V2.BLLD;
using Declara_V2.Exceptions;
using Declara_V2.MODELextended;
using System;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas.DeclaracionConclusion
{
    public partial class ctrlExperienciaLaboral : System.Web.UI.UserControl
    {

        public System.Nullable<Boolean> CheckedNullable
        {
            get
            {
                if (rbtAny.Visible)
                {
                    if (rbtAny.Checked)
                        return null;
                    else
                        return rbtnPu.Checked;
                }
                else
                    return rbtPr.Checked;
            }
            set
            {
                if (value.HasValue)
                {
                    rbtAny.Checked = true;
                    rbtAny.Visible = true;
                    rbtnPu.Checked = value.Value;
                    rbtPr.Checked = value.Value;

                    rbtnPu.Enabled = true;
                    rbtPr.Enabled = true;
                    tbExperiencia.Visible = false;
                }
                else
                {
                    rbtAny.Checked = true;
                    rbtAny.Visible = true;
                    rbtnPu.Checked = false;
                    rbtPr.Checked = false;
                }
            }
        }


        public System.Nullable<Boolean> V_SECTOR_BOOL
        {
            set
            {
                if (value.Value)
                {

                 
                    rbtnOtro.Checked = true;

                    rbtnPu.Checked = false;
                    rbtPr.Checked = false;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtPr.Enabled = false;

                    rbtAny.Checked = false;
                    cmbPR_Sector.SelectedIndex = 17;
                } 
         
            }
        }

        public void ValidaPregunta()
        {
            if (rbtAny.Visible)
            {
                if (rbtAny.Checked)
                    throw new CustomException("Selecciona el sector en el que laboraste");
            }
        }

        public Object CommandArgument
        {
            get => (Object)ViewState["CommandArgument"];
            set => ViewState["CommandArgument"] = value;
        }

        public Boolean AutoPostBack
        {
            get => rbtnPu.AutoPostBack;
            set
            {
                rbtnPu.AutoPostBack = value;
                rbtPr.AutoPostBack = value;
            }
        }

        public delegate void EditarHandler(object sender, EventArgs e);
        public event EditarHandler Change;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbtnPu.Checked = false;
                rbtPr.Checked = false;
                rbtAny.Checked = true;
                rbtnPu.Enabled = true;
                rbtPr.Enabled = true;
                tbExperiencia.Visible = false; 
            }
        }

        public void Changed(Object Sender, EventArgs e)
        {
            OnCheckedChanged(this, e);
        }

        protected virtual void OnCheckedChanged(Object Sender, EventArgs e)
        {
            Change?.Invoke(Sender, e);
        }

        public int NID_AMBITO_SECTOR
        {
            get
            {
                int op = 0;

                if (rbtnPu.Checked)
                    op = 1; //publico
                else
                    op = 2; //privado
                return op;
            }
            set
            {
                int val = value;

                if (val == 1)
                {
                    rbtnPu.Checked = true;
                    rbtPr.Checked = false;
                    rbtAny.Checked = true;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    tbExperiencia.Visible = false;
                    mostrarPublico();

                }
                if (val == 2)
                {
                    rbtnPu.Checked = false;
                    rbtPr.Checked = true;
                    rbtAny.Checked = true;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    tbExperiencia.Visible = false;
                    mostrarPrivado();
                }
            }
        }
        public String V_AMBITO_SECTOR
        {
            get
            {
                if (rbtnPu.Checked)
                    return "Publico";
                else
                    return "Privado";
            }

        }

        public Int32 NID_AMBITO_PUBLICO
        {
            get
            {
                if (cmbPU_Ambito.SelectedValue() == 0)
                    return NID_AMBITO_PUBLICO = 1000;
                else
                    return cmbPU_Ambito.SelectedValue();
            }
            set
            {
                if (value.ToString() == "")
                    NID_AMBITO_PUBLICO = 1000;
                else
                    try { cmbPU_Ambito.SelectedValue = value.ToString(); } catch { }

            }
        }

        public Int32 NID_NIVEL_GOBIERNO
        {
            get
            {
                if (cmbPU_nivel.SelectedValue() == 0)
                    return NID_NIVEL_GOBIERNO = 1000;
                else
                    return cmbPU_nivel.SelectedValue();
            }

            set
            {
                if (value.ToString() == "")
                    NID_NIVEL_GOBIERNO = 1000;
                else
                    try { cmbPU_nivel.SelectedValue = value.ToString(); } catch { }
            }
        }



        public String V_NOMBRE
        {
            get => txtNombre.Text;
            set => txtNombre.Text = value;
        }

        public String V_RFC
        {
            get => txtRFC.Text;
            ////////set
            ////////{
            ////////    if (value == " ")
            ////////        txtRFC.Text = " ";
            ////////    else
            ////////        txtRFC.Text = value;
            ////////}
            set => txtRFC.Text = value;
        }

        public String V_AREA_ADSCRIPCION
        {
            get => txtArea.Text;
            set => txtArea.Text = value;
        }

        public String V_PUESTO
        {
            get => txtPuesto.Text;
            set => txtPuesto.Text = value;
        }

        public String V_FUNCION_PRINCIPAL
        {
            get => txtFuncion.Text;
            set => txtFuncion.Text = value;
        }

        public Int32 NID_SECTOR
        {
            get
            {
                if (cmbPR_Sector.SelectedValue() == 0)
                    return NID_SECTOR = 1000;
                else
                    return cmbPR_Sector.SelectedValue();
            }

            set
            {
                if (value.ToString() == "")
                    NID_SECTOR = 1000;
                else
                    try { cmbPR_Sector.SelectedValue = value.ToString(); } catch { }
            }
        }

  
        public DateTime F_INGRESO
        {
            get => txtF_FechaIngreso.Date(Pagina.esMX);
            set => txtF_FechaIngreso.Text = value.ToString(Pagina.strFormatoFecha);
        }

        public DateTime F_EGRESO
        {
            get
            {
                if (F_INGRESO >= txtF_Egreso.Date(Pagina.esMX))
                    throw new CustomException("La Fecha de Ingreso, debe ser menor a la Fecha de Egreso");
                else
                    return txtF_Egreso.Date(Pagina.esMX);
            }
            set => txtF_Egreso.Text = value.ToString(Pagina.strFormatoFecha);
        }

        public Int32 NID_PAIS
        {
            get => cmbPuPr_Lugar.SelectedValue();
            set => cmbPuPr_Lugar.SelectedValue = value.ToString();
        }

        public Int32 NID_EXPERIENCIA_LABORAL
        {
            get
            {
                if (NID_EXPERIENCIA.Value == "")
                    return 0;
                else
                    return Convert.ToInt32(NID_EXPERIENCIA.Value);
            }
            set => NID_EXPERIENCIA.Value = value.ToString();
        }

        public String E_OBSERVACIONES
        {
            get => txtObservaciones.Text;
            set => txtObservaciones.Text = value;
        }

        protected void rbtnPu_CheckedChanged(object sender, EventArgs e)
        {
            mostrarPublico();
        }

        protected void rbtPr_CheckedChanged(object sender, EventArgs e)
        {
            mostrarPrivado();
 
        }

        protected void rbtPrOtro_CheckedChanged(object sender, EventArgs e)
        {
            mostrarPrivado();
 
            rbtnOtro.Checked = true;

            rbtnPu.Checked = false;
            rbtPr.Checked = false;

            rbtAny.Checked = false;
            cmbPR_Sector.SelectedIndex = 17;
        }

        private void mostrarPublico()
        {
            tbExperiencia.Visible = true;

            //trPR_RFC.Visible = false;
            trPR_RFC.Visible = true;
            trPR_Sector.Visible = false;

            trPU_nivel.Visible = true;
            trPU_Ambito.Visible = true;
            trPr_Funcion.Visible = true;

            ltrPU_nivel.Text = "Nivel / Orden de Gobierno ";
            ltrPuPr_Puesto.Text = "Empleo, Cargo o Comisión";
            ltrPuPr_Area.Text = "Área de adscripción";
            ltrPuPr_Nombre.Text = "Nombre del ente público ";

            rbtnPu.Checked = true;
            rbtPr.Checked = false;
            rbtAny.Checked = false;

            blld__l_CAT_AMBITO_PUBLICO catAmbitoPublico = new blld__l_CAT_AMBITO_PUBLICO();
            catAmbitoPublico.select();
            cmbPU_Ambito.DataBind(catAmbitoPublico.lista_CAT_AMBITO_PUBLICO, CAT_AMBITO_PUBLICO.Properties.NID_AMBITO_PUBLICO, CAT_AMBITO_PUBLICO.Properties.V_AMBITO_PUBLICO, false);
            cmbPU_Ambito.Items.Insert(0, new ListItem(string.Empty));
            cmbPU_Ambito.Items.Remove(cmbPU_Ambito.Items.FindByValue("1000"));

            blld__l_CAT_NIVEL_GOBIERNO catNivelGob = new blld__l_CAT_NIVEL_GOBIERNO();
            catNivelGob.select();
            cmbPU_nivel.DataBind(catNivelGob.lista_CAT_NIVEL_GOBIERNO, CAT_NIVEL_GOBIERNO.Properties.NID_NIVEL_GOBIERNO, CAT_NIVEL_GOBIERNO.Properties.V_NIVEL_GOBIERNO);
            cmbPU_nivel.Items.Insert(0, new ListItem(string.Empty));
            cmbPU_nivel.Items.Remove(cmbPU_nivel.Items.FindByValue("1000"));

            blld__l_CAT_PAIS catPais = new blld__l_CAT_PAIS();
            catPais.select();
            cmbPuPr_Lugar.DataBind(catPais.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS);
            cmbPuPr_Lugar.Items.Insert(0, new ListItem(string.Empty));
        }

        private void mostrarPrivado()
        {
            tbExperiencia.Visible = true;

            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = true;

            trPR_RFC.Visible = true;
            trPR_Sector.Visible = true;

            ltrPuPr_Puesto.Text = "Puesto";
            ltrPuPr_Area.Text = "Área";
            ltrPuPr_Nombre.Text = "Nombre de la empresa, sociedad o asociacion";

            rbtnPu.Checked = false;
            rbtPr.Checked = true;
            rbtAny.Checked = false;

            blld__l_CAT_SECTOR catSector = new blld__l_CAT_SECTOR();
            catSector.select();
            cmbPR_Sector.DataBind(catSector.lista_CAT_SECTOR, CAT_SECTOR.Properties.NID_SECTOR, CAT_SECTOR.Properties.V_SECTOR);
            cmbPR_Sector.Items.Insert(0, new ListItem(String.Empty));
            cmbPR_Sector.Items.Remove(cmbPR_Sector.Items.FindByValue("1000"));
            cmbPR_Sector.SelectedIndex = 0;

            blld__l_CAT_PAIS catPais = new blld__l_CAT_PAIS();
            catPais.select();
            cmbPuPr_Lugar.DataBind(catPais.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS);
            cmbPuPr_Lugar.Items.Insert(0, new ListItem(string.Empty));
        }

        public void limpiarFormulario()
        {
            try { cmbPU_nivel.SelectedIndex = 0; } catch { }
            try { cmbPU_Ambito.SelectedIndex = 0; } catch { }
            try { cmbPR_Sector.SelectedIndex = 0; } catch { }
            try { cmbPuPr_Lugar.SelectedIndex = 0; } catch { }

            txtNombre.Text = String.Empty;
            txtRFC.Text = String.Empty;
            txtArea.Text = String.Empty;
            txtPuesto.Text = String.Empty;
            txtFuncion.Text = String.Empty;
            txtPuesto.Text = String.Empty;
            txtF_FechaIngreso.Text = String.Empty;
            txtF_Egreso.Text = String.Empty;
            txtObservaciones.Text = String.Empty;
 
        }
 


    }
}