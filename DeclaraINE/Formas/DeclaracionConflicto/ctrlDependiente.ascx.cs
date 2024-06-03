using AlanWebControls;
using Declara_V2.BLL;
using Declara_V2.BLLD;
using Declara_V2.MODELextended;

using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINAI.Formas.DeclaracionConflicto
{
    public partial class ctrlDependiente : System.Web.UI.UserControl
    {

        public enum Acciones
        {
            Actualiza,
            Inserta,
        }

        public Acciones Accion
        {
            get => (Acciones)ViewState["ctrlDependienteAccion"];
            set
            {
                if (ViewState["ctrlDependienteAccion"] == null)
                    ViewState.Add("ctrlDependienteAccion", value);
                else
                    ViewState["ctrlDependienteAccion"] = value;
            }
        }

        public Int32 Selected_id
        {
            get
            {
                if (ViewState["ctrlDependienteid"] == null)
                    return -1;
                return (Int32)ViewState["ctrlDependienteid"];
            }
            set
            {
                if (ViewState["ctrlDependienteid"] == null)
                    ViewState.Add("ctrlDependienteid", value);
                else
                    ViewState["ctrlDependienteid"] = value;
            }
        }

        public String NID_TIPO_DEPENDIENTE
        {
            get => cmbNID_TIPO_DEPENDIENTE_DEP.SelectedValue;
            set
            {
                cmbNID_TIPO_DEPENDIENTE_DEP.SelectedValue = value;
            }
        }

        public String V_COLONIA
        {
            get => txtV_COLONIA_LABORAL.Text;
            set => txtV_COLONIA_LABORAL.Text = value;
        }
        public String E_NOMBRE
        {
            get => txtE_NOMBRE.Text;
            set => txtE_NOMBRE.Text = value;
        }

        public int NID_AMBITO_PUBLICO
        {
            //get => cmbPU_Ambito.SelectedIndex;
            //set => cmbPU_Ambito.SelectedIndex = value;

            get
            {
                if (cmbPU_Ambito.SelectedValue == "")
                    return NID_AMBITO_PUBLICO = 0;
                else
                    return cmbPU_nivel.SelectedIndex;
            }

            set
            {
                if (value.ToString() == "")
                    NID_AMBITO_PUBLICO = 0;
                else
                    try { cmbPU_Ambito.SelectedIndex = value; } catch { }
            }
        }




        public String V_NOMBRE_ENTE
        {
            get => txtNombre.Text;
            set => txtNombre.Text = value;
        }

        public String V_AREA_ADSCRIPCION
        {
            get => txtArea.Text;
            set => txtArea.Text = value;
        }

        public String V_FUNCION_PRINCIPAL
        {
            get => txtFuncion.Text;
            set => txtFuncion.Text = value;
        }


        public System.Nullable<Decimal> M_SALARIO_MENSUAL
        {
            //get => moneytxtM_Salario.MoneyNullable();

            get
            {
                if (moneytxtM_Salario.Text == "")
                    return 0;
                else
                    return moneytxtM_Salario.MoneyNullable();
            }
            set
            {
                if (value.HasValue)
                    moneytxtM_Salario.Text = value.Value.ToString("C");
                else
                    moneytxtM_Salario.Text = String.Empty;
            }
        }
        public String E_PRIMER_A
        {
            get => txtE_PRIMER_A.Text;
            set => txtE_PRIMER_A.Text = value;
        }

        public String E_SEGUNDO_A
        {
            get => txtE_SEGUNDO_A.Text;
            set => txtE_SEGUNDO_A.Text = value;
        }

        public String C_CODIGO_POSTAL
        {
            get => C_CODIGO_POSTAL_DEP.Text;
            set => C_CODIGO_POSTAL_DEP.Text = value;
        }
        public int NID_PAIS
        {
            get => cmbNID_PAIS_LABORAL_DEP.SelectedIndex;
            set => cmbNID_PAIS_LABORAL_DEP.SelectedIndex = value;
        }

        public String CID_ENTIDAD_FEDERATIVA
        {
            get => cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue;
            set => cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue = value;
        }
        public String CID_MUNICIPIO
        {
            get => cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue;
            set => cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue = value;
        }

        public DateTime F_NACIMIENTO
        {
            get => txtF_NACIMIENTO.Date(Pagina.esMX);
            set => txtF_NACIMIENTO.Text = value.ToString(Pagina.strFormatoFecha);
        }
        public DateTime F_INGRESO
        {
            //get => txtF_FechaIngreso.Date(Pagina.esMX);
            //set => txtF_FechaIngreso.Text = value.ToString(Pagina.strFormatoFecha);
            get
            {
                if (txtF_FechaIngreso.Text == "")
                    return DateTime.Now;
                else
                    return txtF_FechaIngreso.Date(Pagina.esMX);
            }
            set
            {
                if (txtF_FechaIngreso.Text == "")
                    txtF_FechaIngreso.Text = value.ToString(Pagina.strFormatoFecha);
                else
                    txtF_FechaIngreso.Text = String.Empty;

            }
        }

        public String E_RFC
        {
            get => txtE_RFC.Text;
            set => txtE_RFC.Text = value;
        }
        public String E_CURP
        {
            get => txtCurp.Text;
            set => txtCurp.Text = value;
        }

        public String E_OBSERVACIONES
        {
            get => txtObservaciones.Text;
            set => txtObservaciones.Text = value;
        }
        public String E_OBSERVACIONES_MARCADO
        {
            get => txtObservaciones.Text;
            set => txtObservaciones.Text = value;
        }
        public String V_OBSERVACIONES_TESTADO
        {
            get => txtObservaciones.Text;
            set => txtObservaciones.Text = value;
        }

        public Boolean L_DEPENDE_ECO
        {
            get
            {
                return cbxL_DEPENDE_ECO.Checked;
            }
            set
            {
                cbxL_DEPENDE_ECO.Checked = value;
            }
        }




        public Boolean L_PROVEEDOR
        {
            get
            {
                return cbxProveedor.Checked;
            }
            set
            {
                cbxProveedor.Checked = value;
            }
        }



        public Boolean L_MISMO_DOMICILIO_DECLARANTE
        {
            get
            {
                return chk_L_MISMO_DOMICIO_DEP.Checked;
            }
            set
            {
                chk_L_MISMO_DOMICIO_DEP.Checked = value;
            }
        }



        public Boolean L_CIUDADANO_EXTRANJERO
        {
            get
            {
                return cbxEstrangero.Checked;
            }
            set
            {
                cbxEstrangero.Checked = true;
            }
        }


        public int NID_AMBITO_SECTOR//NID_ACTIVIDAD_LABORAL
        {
            get
            {
                int op = 0;

                if (rbtPr.Checked)
                    op = 1; //publico

                if (rbtnPu.Checked)
                    op = 2; //publico

                if (rbtnOtros.Checked)
                    op = 3; //Otro

                if (rbtnNinguno.Checked)
                    op = 4; //Ninguno

                return op;
            }
            set
            {
                int val = value;

                if (val == 1)
                {
                    rbtnPu.Checked = true;
                    rbtPr.Checked = false;
                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;


                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;

                    mostrarPublico();

                }
                if (val == 2)
                {
                    rbtnPu.Checked = false;
                    rbtPr.Checked = true;

                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;

                    mostrarPrivado();
                }
                if (val == 3)
                {
                    rbtnPu.Checked = false;
                    rbtPr.Checked = false;

                    rbtnOtros.Checked = true;
                    rbtnNinguno.Checked = false;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;

                    mostrarOtros();
                }
                if (val == 4)
                {
                    rbtnPu.Checked = false;
                    rbtPr.Checked = false;

                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;

                    mostrarNinguno();
                }
            }
        }


        public int NID_ACTIVIDAD_LABORAL//NID_ACTIVIDAD_LABORAL
        {
            get
            {
                int op = 0;

                if (rbtPr.Checked)
                    op = 1; //privado 

                if (rbtnPu.Checked)
                    op = 2; //publico 

                if (rbtnOtros.Checked)
                    op = 3; //Otros 

                if (rbtnNinguno.Checked)
                    op = 4; //Ningunos 

                return op;
            }
            set
            {
                int val = value;
                if (val == 1)
                {
                    rbtPr.Checked = true;
                    rbtnPu.Checked = false;
                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                    mostrarPrivado();
                }
                if (val == 2)
                {
                    rbtPr.Checked = false;
                    rbtnPu.Checked = true;
                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = false;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                    mostrarPublico();
                }


                if (val == 3)
                {
                    rbtPr.Checked = false;
                    rbtnPu.Checked = false;
                    rbtnOtros.Checked = true;
                    rbtnNinguno.Checked = false;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                    mostrarOtros();
                }

                if (val == 4)
                {
                    rbtPr.Checked = false;
                    rbtnPu.Checked = false;
                    rbtnOtros.Checked = false;
                    rbtnNinguno.Checked = true;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                    mostrarNinguno();
                }
            }
        }

        public Boolean L_PAREJA
        {
            get
            {
                bool op = false;

                if (rbtP.Checked)
                    op = true; //privado 

                if (rbtD.Checked)
                    op = false; //Dependiente 

                return op;
            }
            set
            {
                bool val = value;

                if (val)
                {
                    rbtP.Checked = true;
                    rbtD.Checked = false;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    SelectPareja();
                }
                if (val == false)
                {
                    rbtP.Checked = false;
                    rbtD.Checked = true;

                    rbtnPu.Enabled = false;
                    rbtPr.Enabled = false;
                    SelectDependiente();
                }
            }
        }


        public string V_DOMICILIO
        {
            get => String.Concat(txtV_DOMICILIO_LABORAL.Text, '|', txtNumExteriorDOMICILIO_LABORAL.Text, '|', txtNumInteriorDOMICILIO_LABORAL.Text);
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    txtV_DOMICILIO_LABORAL.Text = String.Empty;
                    txtNumExteriorDOMICILIO_LABORAL.Text = String.Empty;
                    txtNumInteriorDOMICILIO_LABORAL.Text = String.Empty;
                }
                else
                {
                    try { txtV_DOMICILIO_LABORAL.Text = value.Split('|')[0]; } catch { }
                    try { txtNumExteriorDOMICILIO_LABORAL.Text = value.Split('|')[1]; } catch { }
                    try { txtNumInteriorDOMICILIO_LABORAL.Text = value.Split('|')[2]; } catch { }
                }
            }
        }

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
                //////////////req();
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
            set => txtRFC.Text = value;
        }

        public int NID_SECTOR
        {
            //get => cmbPR_Sector.SelectedIndex;
            //set => cmbPR_Sector.SelectedIndex = value;
            get
            {
                if (cmbPR_Sector.SelectedValue == "")
                    return NID_SECTOR = 0;
                else
                    return cmbPR_Sector.SelectedIndex;
            }

            set
            {
                if (value.ToString() == "")
                    NID_SECTOR = value;
                else
                    try { cmbPR_Sector.SelectedIndex = value; } catch { }
            }
        }

        public String V_CARGO
        {
            get
            {
                if (txtPuesto.Text != null)
                {
                    return txtPuesto.Text;
                }
                else
                    return ltrPuPr_Puesto.Text;
            }
            set
            {
                txtPuesto.Text = value;
                ltrPuPr_Puesto.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                req();
                rbtD.Checked = true;
                SelectDependiente();
                tbAltaParejaDependiente.Visible = true;

                txtF_NACIMIENTO_C.StartDate = new DateTime(1900, 1, 1);
                txtF_NACIMIENTO_C.EndDate = DateTime.Today.AddDays(-1);




                blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
                oCAT_PAIS.select();
                cmbNID_PAIS_LABORAL_DEP.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
                cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(sender, e);
                cmbNID_PAIS_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
                cmbNID_PAIS_LABORAL_DEP.SelectedIndex = 0;

                cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedIndex = 0;


                cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
                cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedIndex = 0;

                cmbCID_MUNICIPIO_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
                cmbCID_MUNICIPIO_LABORAL_DEP.SelectedIndex = 0;
            }
        }
        private void req()
        {
            if (!String.IsNullOrEmpty(Requerido))
            {
                foreach (Control ctr in this.Controls)
                {
                    //if (ctr is TextBox)
                    //{
                    //    if (((TextBox)ctr).ID != txtE_SEGUNDO_A.ID)
                    //        //((TextBox)ctr).Attributes.Add("requerido", Requerido);
                    //}
                    //else if (ctr is DropDownList)
                    //{
                    //    //((DropDownList)ctr).Attributes.Add("requerido", Requerido);
                    //}
                }
            }
        }
        protected void txtF_NACIMIENTO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtE_NOMBRE.Text) &&
                    !String.IsNullOrEmpty(txtE_PRIMER_A.Text) &&
                    !String.IsNullOrEmpty(txtF_NACIMIENTO.Text))
                    txtE_RFC.Text = RFC.CalcularRFC(txtE_NOMBRE.Text
                                                   , txtE_PRIMER_A.Text
                                                   , txtE_SEGUNDO_A.Text
                                                   , txtF_NACIMIENTO.Date(Pagina.esMX));
            }
            catch { }
        }

        public void llena(blld_DECLARACION_DEPENDIENTES Dependiente, Int32 Id)
        {
            pnlDependiente.Visible = true;

            tbAltaParejaDependiente.Visible = true;

            try { E_NOMBRE = _bllSistema.DesEncriptaStatic(Dependiente.E_NOMBRE); } catch { E_NOMBRE = Dependiente.E_NOMBRE; }
            try { E_PRIMER_A = _bllSistema.DesEncriptaStatic(Dependiente.E_PRIMER_A); } catch { E_PRIMER_A = Dependiente.E_PRIMER_A; }
            try { E_SEGUNDO_A = _bllSistema.DesEncriptaStatic(Dependiente.E_SEGUNDO_A); } catch { E_SEGUNDO_A = Dependiente.E_SEGUNDO_A; }

            F_NACIMIENTO = Dependiente.F_NACIMIENTO;
            E_RFC = Dependiente.E_RFC;

            chk_L_MISMO_DOMICIO_DEP.Checked = Dependiente.L_MISMO_DOMICILIO_DECLARANTE;


            cbxEstrangero.Checked = Dependiente.L_CIUDADANO_EXTRANJERO;
            cbxL_DEPENDE_ECO.Checked = Dependiente.L_DEPENDE_ECO;


            //if (chk_L_MISMO_DOMICIO.Checked)
            //{
            //    try { txt_V_DOMICILIO.Attributes.Remove("requerido"); } catch { }

            //}
            //else
            //{
            //    try { txt_V_DOMICILIO.Attributes.Add("requerido", Requerido); } catch { }
            //}

            //      V_DOMICILIO = Dependiente.E_DOMICILIO;
            txtCurp.Text = Dependiente.E_CURP;
            txtObservaciones.Text = Dependiente.E_OBSERVACIONES;

            //Direccion


            if (Dependiente.L_PAREJA)
            {
                rbtP.Checked = true;
                rbtD.Checked = false;
                rbtAny.Checked = false;

                rbtP.Enabled = true;
                rbtD.Enabled = true;
                SelectPareja();
            }
            if (Dependiente.L_PAREJA == false)
            {
                rbtP.Checked = false;
                rbtD.Checked = true;
                rbtAny.Checked = false;

                rbtP.Enabled = true;
                rbtD.Enabled = true;
                SelectDependiente();
            }

            try { NID_TIPO_DEPENDIENTE = Dependiente.NID_TIPO_DEPENDIENTE.ToString(); } catch { E_SEGUNDO_A = Dependiente.E_SEGUNDO_A; }

            if (!Dependiente.L_MISMO_DOMICILIO_DECLARANTE)
            {
                try
                {
                    MODELDeclara_V2.cnxDeclara db = new MODELDeclara_V2.cnxDeclara();
                    var oDomicilio = ((from p in db.DECLARACION_DEPENDIENTES_DOMICILIO
                                       where
                                              p.VID_NOMBRE == Dependiente.VID_NOMBRE &&
                                              p.VID_FECHA == Dependiente.VID_FECHA &&
                                              p.VID_HOMOCLAVE == Dependiente.VID_HOMOCLAVE &&
                                              p.NID_DECLARACION == Dependiente.NID_DECLARACION &&
                                              p.NID_DEPENDIENTE == Dependiente.NID_DEPENDIENTE
                                       select p).First());


                    C_CODIGO_POSTAL_DEP.Text = oDomicilio.C_CODIGO_POSTAL;
                    cmbNID_PAIS_LABORAL_DEP.SelectedValue = oDomicilio.NID_PAIS.ToString();
                    cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(cmbNID_PAIS_LABORAL_DEP, null);
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue = oDomicilio.CID_ENTIDAD_FEDERATIVA;
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP, null);
                    cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue = oDomicilio.CID_MUNICIPIO;



                    try { txtV_COLONIA_LABORAL.Text = _bllSistema.DesEncriptaStatic(oDomicilio.V_COLONIA); } catch { txtV_COLONIA_LABORAL.Text = oDomicilio.V_COLONIA; }
                    try { V_DOMICILIO = _bllSistema.DesEncriptaStatic(oDomicilio.V_DOMICILIO); } catch { V_DOMICILIO = oDomicilio.V_DOMICILIO; }


                    try { txtV_DOMICILIO_LABORAL.Text = V_DOMICILIO.Split('|')[0]; } catch { }
                    try { txtNumExteriorDOMICILIO_LABORAL.Text = V_DOMICILIO.Split('|')[1]; } catch { }
                    try { txtNumInteriorDOMICILIO_LABORAL.Text = V_DOMICILIO.Split('|')[2]; } catch { }
                }
                catch (Exception)
                {

                }

            }
            else
            {
                pnlDependiente.Visible = false;
            }

            if (Dependiente.NID_ACTIVIDAD_LABORAL == 3)
            {
                mostrarOtros();
                rbtPr.Enabled = false;
                rbtnPu.Enabled = false;
                rbtnOtros.Enabled = false;
                rbtnNinguno.Enabled = false;
            }

            if (Dependiente.NID_ACTIVIDAD_LABORAL == 4)
            {
                mostrarNinguno();
                rbtPr.Enabled = false;
                rbtnPu.Enabled = false;
                rbtnOtros.Enabled = false;
                rbtnNinguno.Enabled = false;

            }

            if (Dependiente.NID_ACTIVIDAD_LABORAL == 1)
            {
                mostrarPrivado();

                try
                {
                    blld_DECLARACION_DEPENDIENTES_PRIVADO oDepPrivado = new blld_DECLARACION_DEPENDIENTES_PRIVADO(Dependiente.VID_NOMBRE, Dependiente.VID_FECHA, Dependiente.VID_HOMOCLAVE, Dependiente.NID_DECLARACION, Dependiente.NID_DEPENDIENTE);

                    txtNombre.Text = oDepPrivado.V_NOMBRE;
                    txtPuesto.Text = oDepPrivado.V_CARGO;
                    txtRFC.Text = oDepPrivado.V_RFC;

                    txtF_FechaIngreso.Text = oDepPrivado.F_INGRESO.ToString();
                    cmbPR_Sector.SelectedIndex = oDepPrivado.NID_SECTOR;
                    moneytxtM_Salario.Text = oDepPrivado.M_SALARIO_MENSUAL.ToString("C");
                    cbxProveedor.Checked = oDepPrivado.L_PROVEEDOR;
                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                }
                catch (Exception ex)
                {

                }
            }

            if (Dependiente.NID_ACTIVIDAD_LABORAL == 2)
            {
                mostrarPublico();

                try
                {
                    blld_DECLARACION_DEPENDIENTES_PUBLICO oDepPublico = new blld_DECLARACION_DEPENDIENTES_PUBLICO(Dependiente.VID_NOMBRE, Dependiente.VID_FECHA, Dependiente.VID_HOMOCLAVE, Dependiente.NID_DECLARACION, Dependiente.NID_DEPENDIENTE);

                    cmbPU_nivel.SelectedIndex = oDepPublico.NID_NIVEL_GOBIERNO;
                    cmbPU_Ambito.SelectedIndex = oDepPublico.NID_AMBITO_PUBLICO;

                    txtNombre.Text = oDepPublico.V_NOMBRE_ENTE;
                    txtFuncion.Text = oDepPublico.V_FUNCION_PRINCIPAL;
                    moneytxtM_Salario.Text = oDepPublico.M_SALARIO_MENSUAL.ToString("C");
                    txtF_FechaIngreso.Text = oDepPublico.F_INGRESO.ToString();

                    txtPuesto.Text = oDepPublico.V_CARGO;
                    txtArea.Text = oDepPublico.V_AREA_ADSCRIPCION;

                    rbtPr.Enabled = false;
                    rbtnPu.Enabled = false;
                    rbtnOtros.Enabled = false;
                    rbtnNinguno.Enabled = false;
                }
                catch (Exception ex)
                {

                }
            }

            Accion = Acciones.Actualiza;
            this.Selected_id = Id;

        }

        public void limpia()
        {
            NID_TIPO_DEPENDIENTE = "0";
            E_NOMBRE = String.Empty;
            E_PRIMER_A = String.Empty;
            E_SEGUNDO_A = String.Empty;
            txtF_NACIMIENTO.Text = String.Empty;
            E_RFC = String.Empty;
            txtCurp.Text = String.Empty;
            cbxL_DEPENDE_ECO.Checked = false;
            chk_L_MISMO_DOMICIO_DEP.Checked = false;
            cbxEstrangero.Checked = false;
            /*V_DOMICILIO = String.Empty;*/
            Accion = Acciones.Inserta;
            //txt_V_DOMICILIO.Visible = false;
            cmbPU_nivel.ClearSelection();
            cmbPU_Ambito.ClearSelection();
            cmbPR_Sector.ClearSelection();

            txtNombre.Text = String.Empty;
            txtPuesto.Text = String.Empty;
            txtRFC.Text = String.Empty;
            txtF_FechaIngreso.Text = String.Empty;
            txtArea.Text = String.Empty;
            txtFuncion.Text = String.Empty;
            moneytxtM_Salario.Text = String.Empty;
            txtObservaciones.Text = String.Empty;
            cbxProveedor.Checked = false;

            cmbNID_PAIS_LABORAL_DEP.ClearSelection();
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.ClearSelection();
            cmbCID_MUNICIPIO_LABORAL_DEP.ClearSelection();
 
            //Direccion
            C_CODIGO_POSTAL_DEP.Text = String.Empty;
            txtV_COLONIA_LABORAL.Text = String.Empty;
            txtV_DOMICILIO_LABORAL.Text = String.Empty;
            txtNumExteriorDOMICILIO_LABORAL.Text = String.Empty;
            txtNumInteriorDOMICILIO_LABORAL.Text = String.Empty;


            cmbNID_PAIS_LABORAL_DEP.ClearSelection();
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.ClearSelection();
            cmbCID_MUNICIPIO_LABORAL_DEP.ClearSelection();

            //cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Clear();
            //cmbCID_MUNICIPIO_LABORAL_DEP.Items.Clear();

            tr_Mixto1.Visible = false;
            tr_Mixto2.Visible = false;
            tr_Mixto3.Visible = false;
            tr_Mixto4.Visible = false;


            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = false;
            trPr_Area.Visible = false;

            rbtP.Checked = false;
            rbtD.Checked = false;
            rbtAny.Checked = true;

            rbtP.Enabled = true;
            rbtD.Enabled = true;

            trPr_Proveedor.Visible = false;
            trPR_RFC.Visible = false;
            trPR_Sector.Visible = false;

            rbtnPu.Checked = false;
            rbtPr.Checked = false;
            rbtnOtros.Checked = false;
            rbtnNinguno.Checked = false;

            rbtnPu.Enabled = true;
            rbtPr.Enabled = true;
            rbtnOtros.Enabled = true;
            rbtnNinguno.Enabled = true;

            pnlDependiente.Visible = true;

            tbAltaParejaDependiente.Visible = false;


            blld__l_CAT_PAIS oCAT_PAIS = new blld__l_CAT_PAIS();
            oCAT_PAIS.select();
            cmbNID_PAIS_LABORAL_DEP.DataBind(oCAT_PAIS.lista_CAT_PAIS, CAT_PAIS.Properties.NID_PAIS, CAT_PAIS.Properties.V_PAIS, false);
      
            cmbNID_PAIS_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
            cmbNID_PAIS_LABORAL_DEP.SelectedIndex = 0;

            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedIndex = 0;


            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedIndex = 0;

            cmbCID_MUNICIPIO_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
            cmbCID_MUNICIPIO_LABORAL_DEP.SelectedIndex = 0;
        }

        protected void chk_L_MISMO_DOMICIO_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_L_MISMO_DOMICIO_DEP.Checked)
            {
                pnlDependiente.Visible = false;
            }
            else
            {
                pnlDependiente.Visible = true;
            }
        }


        protected void cmbLugarRecide_DEP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void C_CODIGO_POSTAL_DEP_TextChanged(object sender, EventArgs e)
        {
            if (C_CODIGO_POSTAL_DEP.Text.Length == 5)
            {
                try
                {
                    blld_CAT_CODIGO_POSTAL oCodigo = new blld_CAT_CODIGO_POSTAL(C_CODIGO_POSTAL_DEP.Text);
                    cmbNID_PAIS_LABORAL_DEP.SelectedValue = oCodigo.NID_PAIS.ToString();
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue = oCodigo.CID_ENTIDAD_FEDERATIVA;
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(sender, e);
                    cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
                    cmbCID_MUNICIPIO_LABORAL_DEP.SelectedValue = oCodigo.CID_MUNICIPIO;
                    txtV_COLONIA_LABORAL.Text = oCodigo.V_COLONIA;

                }
                catch
                {
                }
            }
        }


        protected void cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_ENTIDAD_FEDERATIVA oEntidadFederativa = new blld__l_CAT_ENTIDAD_FEDERATIVA();
            oEntidadFederativa.NID_PAIS = new Declara_V2.IntegerFilter(cmbNID_PAIS_LABORAL_DEP.SelectedValue());
            oEntidadFederativa.select();
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.DataBind(oEntidadFederativa.lista_CAT_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.CID_ENTIDAD_FEDERATIVA, CAT_ENTIDAD_FEDERATIVA.Properties.V_ENTIDAD_FEDERATIVA);
            cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(sender, e);
            //cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
        }
        protected void cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_MUNICIPIO omun = new blld__l_CAT_MUNICIPIO();
            omun.NID_PAIS = new Declara_V2.IntegerFilter(cmbNID_PAIS_LABORAL_DEP.SelectedValue());
            omun.CID_ENTIDAD_FEDERATIVA = new Declara_V2.StringFilter(cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP.SelectedValue);
            omun.select();
            cmbCID_MUNICIPIO_LABORAL_DEP.DataBind(omun.lista_CAT_MUNICIPIO, CAT_MUNICIPIO.Properties.CID_MUNICIPIO, CAT_MUNICIPIO.Properties.V_MUNICIPIO);
            //cmbCID_MUNICIPIO_LABORAL_DEP.Items.Insert(0, new ListItem(String.Empty));
        }

        private void mostrarPublico()
        {
            tr_Mixto1.Visible = true;
            tr_Mixto2.Visible = true;
            tr_Mixto3.Visible = true;
            tr_Mixto4.Visible = true;

            trPR_RFC.Visible = false;
            trPR_Sector.Visible = false;
            trPr_Proveedor.Visible = false;

            trPU_nivel.Visible = true;
            trPU_Ambito.Visible = true;
            trPr_Funcion.Visible = true;
            trPr_Area.Visible = true;

            ltrPU_nivel.Text = "Nivel / Orden de Gobierno ";
            ltrPuPr_Puesto.Text = "Empleo, Cargo o Comisión";
            ltrPuPr_Area.Text = "Área de adscripción";
            ltrPuPr_Nombre.Text = "Nombre del ente público ";

            rbtnPu.Checked = true;
            rbtPr.Checked = false;

            rbtnOtros.Checked = false;
            rbtnNinguno.Checked = false;

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
        }

        private void mostrarPrivado()
        {
            tr_Mixto1.Visible = true;
            tr_Mixto2.Visible = true;
            tr_Mixto3.Visible = true;
            tr_Mixto4.Visible = true;

            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = false;
            trPr_Area.Visible = false;

            trPr_Proveedor.Visible = true;
            trPR_RFC.Visible = true;
            trPR_Sector.Visible = true;

            ltrPuPr_Puesto.Text = "Empleo o cargo";
            //ltrPuPr_Area.Text = "Área";
            ltrPuPr_Nombre.Text = "Nombre de la empresa, <br/> sociedad o asociacion";

            rbtnPu.Checked = false;
            rbtPr.Checked = true;

            rbtnOtros.Checked = false;
            rbtnNinguno.Checked = false;

            blld__l_CAT_SECTOR catSector = new blld__l_CAT_SECTOR();
            catSector.select();
            cmbPR_Sector.DataBind(catSector.lista_CAT_SECTOR, CAT_SECTOR.Properties.NID_SECTOR, CAT_SECTOR.Properties.V_SECTOR);
            cmbPR_Sector.Items.Insert(0, new ListItem(String.Empty));
            cmbPR_Sector.Items.Remove(cmbPR_Sector.Items.FindByValue("1000"));
            //cmbPR_Sector.Items.Remove(cmbPR_Sector.Items.FindByValue("17"));


        }

        private void mostrarOtros()
        {
            rbtnPu.Checked = false;
            rbtPr.Checked = false;
            rbtnOtros.Checked = true;
            rbtnNinguno.Checked = false;



            tr_Mixto1.Visible = true;
            tr_Mixto2.Visible = true;
            tr_Mixto3.Visible = true;
            tr_Mixto4.Visible = true;

            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = false;
            trPr_Area.Visible = false;

            trPr_Proveedor.Visible = true;
            trPR_RFC.Visible = true;
            trPR_Sector.Visible = true;

            ltrPuPr_Puesto.Text = "Empleo o cargo";
            //ltrPuPr_Area.Text = "Área";
            ltrPuPr_Nombre.Text = "Nombre de la empresa, <br/> sociedad o asociacion";


            blld__l_CAT_SECTOR catSector = new blld__l_CAT_SECTOR();
            catSector.select();
            cmbPR_Sector.DataBind(catSector.lista_CAT_SECTOR, CAT_SECTOR.Properties.NID_SECTOR, CAT_SECTOR.Properties.V_SECTOR);
            cmbPR_Sector.Items.Insert(0, new ListItem(String.Empty));
            cmbPR_Sector.Items.Remove(cmbPR_Sector.Items.FindByValue("1000"));
            cmbPR_Sector.SelectedIndex = 17;
        }


        private void mostrarNinguno()
        {
            rbtnPu.Checked = false;
            rbtPr.Checked = false;
            rbtnOtros.Checked = false;
            rbtnNinguno.Checked = true;

            tr_Mixto1.Visible = false;
            tr_Mixto2.Visible = false;
            tr_Mixto3.Visible = false;
            tr_Mixto4.Visible = false;

            trPU_nivel.Visible = false;
            trPU_Ambito.Visible = false;
            trPr_Funcion.Visible = false;
            trPr_Area.Visible = false;
            trPR_RFC.Visible = false;
            trPR_Sector.Visible = false;
        }










        protected void rbtnPu_CheckedChanged(object sender, EventArgs e)
        {
            mostrarPublico();
        }

        protected void rbtPr_CheckedChanged(object sender, EventArgs e)
        {
            mostrarPrivado();
        }

        protected void rbtnOtros_CheckedChanged(object sender, EventArgs e)
        {
            mostrarOtros();
        }

        protected void rbtnNinguno_CheckedChanged(object sender, EventArgs e)
        {
            mostrarNinguno();
        }








        protected void rbtP_CheckedChanged(object sender, EventArgs e)
        {
            SelectPareja();
            tbAltaParejaDependiente.Visible = true; 
        }

        protected void rbtD_CheckedChanged(object sender, EventArgs e)
        {
            SelectDependiente();
            tbAltaParejaDependiente.Visible = true;
        }




        internal void SelectPareja()
        {
            try
            {
                labTipoRelacion.Text = "Relación con el declarante";
                trPareja.Visible = true;
                lblDomicilio.Text = "¿El domicilio de la pareja <br/> es el mismo que el del declarante?";

                blld__l_CAT_TIPO_DEPENDIENTES oDep = new blld__l_CAT_TIPO_DEPENDIENTES();
                oDep.OrderByCriterios.Add(new Declara_V2.Order(CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE));
                oDep.select();
                var list = oDep.lista_CAT_TIPO_DEPENDIENTES.Where(p => p.L_PAREJA == true).ToList();

                cmbNID_TIPO_DEPENDIENTE_DEP.DataBind(list, CAT_TIPO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE, CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE);
                cmbNID_TIPO_DEPENDIENTE_DEP.Items.Insert(0, new ListItem(String.Empty, "0"));
            }
            catch (Exception ex)
            {


            }
        }

        internal void SelectDependiente()
        {
            try
            {
                trPareja.Visible = false;
                labTipoRelacion.Text = "Parentesco o relación con el declarante";
                lblDomicilio.Text = "¿El domicilio del dependiente <br/> es el mismo que el del declarante?";

                blld__l_CAT_TIPO_DEPENDIENTES oDep = new blld__l_CAT_TIPO_DEPENDIENTES();
                oDep.OrderByCriterios.Add(new Declara_V2.Order(CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE));
                oDep.select();
                var list = oDep.lista_CAT_TIPO_DEPENDIENTES.Where(p => p.L_PAREJA == false).ToList();

                cmbNID_TIPO_DEPENDIENTE_DEP.DataBind(list, CAT_TIPO_DEPENDIENTES.Properties.NID_TIPO_DEPENDIENTE, CAT_TIPO_DEPENDIENTES.Properties.V_TIPO_DEPENDIENTE);
                cmbNID_TIPO_DEPENDIENTE_DEP.Items.Insert(0, new ListItem(String.Empty, "0"));
            }
            catch (Exception ex)
            {


            }
        }





    }
}