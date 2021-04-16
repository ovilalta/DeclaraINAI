using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Declara_V2.BLLD;
using Declara_V2;
using Declara_V2.MODELextended;
using Declara_V2.Exceptions;
using AlanWebControls;


namespace DeclaraINE.Formas
{


    public partial class Registro : Pagina
    {
        clsSistema _oSistema => (clsSistema)Session["oSistema"];
        private Int32 nContador
        {
            get => (Int32)ViewState["cuenta"];
            set => ViewState["cuenta"] = value;
        }

        private String Homo
        {
            get => ((String)ViewState["Homo"]).ToUpper();
            set => ViewState["Homo"] = value;
        }

        private String Contraseña
        {
            get => (String)Session["Pass"];
            set => SessionAdd("Pass", value);
        }

        private String Confirmacion
        {
            get => (String)Session["Conf"];
            set => SessionAdd("Conf", value);
        }

        private String strCorreo
        {
            get => (String)Session["strCorreo"];
            set => SessionAdd("strCorreo", Clean(value));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                clsSistema oSistema = _oSistema;
                if (oSistema == null)
                    Response.Redirect("Login");
            }
            catch
            {
                Response.Redirect("Login");
            }

            if (!IsPostBack)
            {
                Page.Title = "Registro";
                nContador = 0;
                txtFecha_C.EndDate = DateTime.Today;
                txtFIngreso_C.EndDate = DateTime.Today;
                mdlTutorial.Show();

                blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
                oPuesto.select();
                cmbVID_CLAVEPUESTO.DataSource = oPuesto.lista_CAT_PUESTO;
                cmbVID_CLAVEPUESTO.DataTextField = CAT_PUESTO.Properties.VID_PUESTO.ToString();
                cmbVID_CLAVEPUESTO.DataValueField = CAT_PUESTO.Properties.NID_PUESTO.ToString();
                cmbVID_CLAVEPUESTO.DataBind();

            }
            if (trNivel.Visible)
            {
                alertPuesto.ShowInfo("Si no encuentra su puesto, debe comunicarse a la etx: #### o al correo oic@inai.org.mx");
                try { txtPrevCorreo.Attributes.Remove("placeholder"); } catch { }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ToUpper();
            Contraseña = txtNueva.Text;
            Confirmacion = txtConfirmar.Text;
            qstConfirmaDatos.Ask(String.Concat("¿Confirma bajo protesta de decir verdad que los datos son correctos?", "<br />"
                                               , "La información se enviará al Órgano Interno de Control", "<br />"
                                               , Clean(txtNombre.Text), " ", Clean(txtPrimerApellido.Text), " ", Clean(txtSegundoApellido.Text), "<br />"
                                               , Clean(txtFecha.Text), "<br />"
                                               , Clean(txtVID_NOMBRE.Text), Clean(txtVID_FECHA.Text), Clean(txtVID_HOMOCLAVE.Text), "<br />"
                                               , Clean(txtCorreo.Text)
                ));

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        private void ToUpper()
        {
            txtVID_NOMBRE.Text = txtVID_NOMBRE.Text.ToUpper();
            txtVID_HOMOCLAVE.Text = txtVID_HOMOCLAVE.Text.ToUpper();
        }


        private void btnCalcular()
        {
            try
            {
                ToUpper();

                String RFCCalculado = RFC.CalcularRFC(txtNombre.Text
                        , txtPrimerApellido.Text
                        , txtSegundoApellido.Text
                        , txtFecha.Date(esMX));

                if (!RFCCalculado.Substring(0, 4).Equals(txtVID_NOMBRE.Text))
                {
                    txtVID_NOMBRE.BackColor = System.Drawing.Color.Red;
                    txtVID_NOMBRE.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txtVID_NOMBRE.BackColor = System.Drawing.Color.White;
                    txtVID_NOMBRE.ForeColor = System.Drawing.Color.Black;
                }

                if (!RFCCalculado.Substring(4, 6).Equals(txtVID_FECHA.Text))
                {
                    txtVID_FECHA.BackColor = System.Drawing.Color.Red;
                    txtVID_FECHA.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txtVID_FECHA.BackColor = System.Drawing.Color.White;
                    txtVID_FECHA.ForeColor = System.Drawing.Color.Black;
                }
                Int32 Cuenta = nContador;
                if (!RFCCalculado.Substring(10, 3).Equals(txtVID_HOMOCLAVE.Text))
                {
                    txtVID_HOMOCLAVE.BackColor = System.Drawing.Color.Red;
                    txtVID_HOMOCLAVE.ForeColor = System.Drawing.Color.White;
                    if (String.IsNullOrEmpty(txtVID_HOMOCLAVE.Text))
                        btnCalcularHomo.Visible = true;
                    else if (nContador >= 1)
                    {
                        ////btnCalcularHomo.Visible = true;
                        msgBox.ShowDanger("Los datos capturados no coinciden con la validación automatica del R.F.C. <br /> Si continua teniendo problemas con el R.F.C. favor de comunicarse a las extensiones 3435, 2307 y 2461");
                    }
                    nContador++;
                }
                else
                {
                    txtVID_HOMOCLAVE.BackColor = System.Drawing.Color.White;
                    txtVID_HOMOCLAVE.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception ex)
            {
                msgx.ShowDanger(ex.Message);
            }
        }


        protected void btnCalcularHomo_Click(object sender, ImageClickEventArgs e)
        {
            //try
            //{
            //    ToUpper();
            //    String RFCCalculado = RFC.CalcularRFC(txtNombre.Text
            //            , txtPrimerApellido.Text
            //            , txtSegundoApellido.Text
            //            , txtFecha.Date(esMX));
            //    Homo = RFCCalculado.Substring(10, 3);
            //    qstHomo.Ask(String.Concat("De acuerdo con los datos proporcionados la homoclave es:   <b>", RFCCalculado.Substring(10, 3), "</b><br />¿Desea utilizarla?"));
            //}
            //catch
            //{
            //}

        }

        protected void btnAceptarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrevCorreo.Text.Length <= 3)
                    throw new CustomException("Ingrese una dirección de correo válida");

                //if (pretag.Visible)

                //else
                {
                    if (cmbVID_NIVEL.Visible)
                    {
                        blld_CAT_PUESTO oPuesto = new blld_CAT_PUESTO(cmbVID_NIVEL.SelectedValue());
                    }
                    //correo = txtPrevCorreo.Text.Trim().ToLower();
                    //qstBoxConfirmaCorreo.Ask(String.Concat("¿El correo electrónico ", correo, " es correcto?"));
                    //if (oPuesto.L_ACTIVO)
                    //if (SioNo1.CheckedNullable.HasValue && SioNo2.CheckedNullable.HasValue)
                    //{
                    //    //if (SioNo1.Checked || SioNo2.Checked)
                    //    //{
                    if (pretag.Visible)
                    {
                        strCorreo = String.Concat(txtPrevCorreo.Text.Trim().ToLower().Replace(" ", String.Empty).Replace("@ifai.org.mx", String.Empty).Replace("@inai.org.mx", String.Empty).Replace("@", String.Empty).Trim(), "@inai.org.mx").ToLower();
                        qstBoxConfirmaCorreo.Ask(String.Concat("¿El correo electrónico institucional <b>", Clean(strCorreo), "</b> es correcto?"));
                    }
                    else
                    {
                        strCorreo = txtPrevCorreo.Text.Trim().ToLower();
                        qstBoxConfirmaCorreo.Ask(String.Concat("¿El correo electrónico <b>", Clean(strCorreo), "</b> es correcto?"));
                    }
                    //    //}
                    //    //else if (oPuesto.L_ACTIVO)
                    //    //{
                    //    //    correo = txtPrevCorreo.Text.Trim().ToLower();
                    //    //    qstBoxConfirmaCorreo.Ask(String.Concat("¿El correo electrónico ", correo, " es correcto?"));
                    //    //}
                    //    //else
                    //    //{
                    //    //    msgx.ShowDanger("Usted no es sujeto obligado a presentar declaración patrimonial, si tiene dudas por favor comuniquese a las IP 372421, 373270, 370115 o al correo declara@ine.mx");
                    //    //}
                    //}
                    //else
                    //{
                    //    msgx.ShowDanger("Debe contestar a todas las preguntas de Si o No");
                    //}
                }
            }
            catch (Exception ex)
            {
                msgx.ShowDanger(ex.Message);
            }
        }

        private String Clean(String str)
        {
            return str.Replace("</", String.Empty)
                      .Replace("/>", String.Empty)
                      .Replace(">", String.Empty)
                      .Replace("<", String.Empty)
                      .Replace("'", String.Empty)
                      .Replace("--", String.Empty);
        }

        protected void btnSinCorreo_Click(object sender, EventArgs e)
        {
            qstBoxConfirmaSinCorre.AskDanger("¿Confirma que no cuenta con un correo electrónico institucional?");
        }

        protected void qstBoxConfirmaCorreo_Yes(object Sender, EventArgs e)
        {
            txtCorreo.Text = strCorreo;
            Session.Remove("strCorreo");
            txtPrevCorreo.Text = String.Empty;
            //if (pretag.Visible)
            //    txtCorreo.Text = String.Concat(txtPrevCorreo.Text.Trim().Replace("@ine.mx", String.Empty).Replace("@", String.Empty).Trim(), "@ine.mx").ToLower();
            //else
            //    txtCorreo.Text = txtPrevCorreo.Text.Trim().ToLower();
            Correo.Visible = false;
            Forma.Visible = true;
        }

        protected void qstBoxConfirmaCorreo_No(object Sender, EventArgs e)
        {

        }

        protected void qstBoxConfirmaSinCorre_Yes(object Sender, EventArgs e)
        {
            pretag.Visible = false;
            btnCancelarCorreo.Visible = false;
            txtPrevCorreo.TextMode = TextBoxMode.Email;
            txtPrevCorreo.Attributes.Remove("placeholder");
            ltrPreCorreo.Text = "Correo electrónico personal";
            lblCorreoINE.Visible = false;
            trNivel.Visible = true;
            trPuesto.Visible = true;
            trNivel0.Visible = true;
            try { txtPrevCorreo.Attributes.Remove("placeholder"); } catch { }
            alertPuesto.ShowInfo("Si no encuentra su puesto, debe comunicarse a la etx: #### o al correo oic@inai.org.mx");
        }

        protected void qstBoxConfirmaSinCorre_No(object Sender, EventArgs e)
        {

        }

        protected void qstHomo_Yes(object Sender, EventArgs e)
        {
            txtVID_HOMOCLAVE.Text = Homo;
            txtVID_HOMOCLAVE.BackColor = System.Drawing.Color.White;
            txtVID_HOMOCLAVE.ForeColor = System.Drawing.Color.Black;
        }

        protected void qstHomo_No(object Sender, EventArgs e)
        {
            txtVID_HOMOCLAVE.Text = String.Empty;
        }

        protected void qstConfirmaDatos_Yes(object Sender, EventArgs e)
        {
            try
            {
                ToUpper();
                String strEmail = txtCorreo.Text.Trim();
                //String strPass = txtPassword.Text;
                //String strConfirmaPass = txtPasswordConfirma.Text;
                if (!Contraseña.Equals(Confirmacion))
                    throw new CustomException("La contraseña y la confirmación no coinciden");

                if (
                     !String.IsNullOrEmpty(txtNombre.Text.Trim()) &&
                     !String.IsNullOrEmpty(txtPrimerApellido.Text.Trim()) &&
                     !String.IsNullOrEmpty(txtFecha.Text.Trim())
                    )
                {
                    btnCalcular();
                    blld_USUARIO oUsuario = new blld_USUARIO(
                                                               txtVID_NOMBRE.Text
                                                             , txtVID_FECHA.Text
                                                             , txtVID_HOMOCLAVE.Text
                                                             , Contraseña
                                                             , txtNombre.Text.Trim()
                                                             , txtPrimerApellido.Text.Trim()
                                                             , txtSegundoApellido.Text.Trim()
                                                             , txtFecha.Date(esMX)
                                                             , txtCorreo.Text
                                                             , txtFIngreso.Date(esMX)
                                                             , Convert.ToBoolean(listNvoIng.SelectedValue)
                                                             , Convert.ToBoolean(listOblDec.SelectedValue));



                    bool Respuesta = oUsuario.USUARIO_CORREOs.Where(P => P.V_CORREO == txtCorreo.Text).First().EnviarCorreoConfirmacionCuenta();

                    if (Respuesta)
                        qstRegistroExitoso.AskSuccess("Se enviaron correctamente los datos <br/> Recibirá un correo electrónico en la dirección que capturó, deberá seguir las instrucciones para completar su registro <br/> búsquelo en su <b>bandeja de entrada</b> o la carpeta de <b>correo no deseado</b>");
                    else
                        qstRegistroExitoso.AskSuccess("Ocurrió un error durante su registro, por favor contáctenos vía telefónica o correo electrónico para revisar su caso.");


                    //Response.Redirect(url);
                    Contraseña = null;
                    Confirmacion = null;
                }
                else
                {
                    msgx.ShowDanger("Se deben llenar todos los campos requeridos");
                }
            }
            catch (Exception ex)
            {
                msgx.ShowDanger(ex.Message);
            }
        }

        protected void qstConfirmaDatos_No(object Sender, EventArgs e)
        {
            txtNueva.Text = Contraseña;
            txtConfirmar.Text = Confirmacion;
        }

        protected void cmbVID_CLAVEPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            blld__l_CAT_PUESTO oPuesto = new blld__l_CAT_PUESTO();
            oPuesto.VID_PUESTO = new Declara_V2.StringFilter(cmbVID_CLAVEPUESTO.SelectedItem.Text);
            oPuesto.select();
            cmbVID_NIVEL.DataBind(oPuesto.lista_CAT_PUESTO, CAT_PUESTO.Properties.NID_PUESTO, CAT_PUESTO.Properties.V_PUESTO_NIVEL);
            cmbVID_NIVEL.Items.Insert(0, new ListItem(String.Empty));
            txtV_DENOMINACION_PUESTO.Text = String.Empty;
            cmbVID_NIVEL.SelectedValue = String.Empty;


        }

        protected void cmbVID_NIVEL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                blld_CAT_PUESTO oPuesto = new blld_CAT_PUESTO(cmbVID_CLAVEPUESTO.SelectedItem.Text, cmbVID_NIVEL.SelectedValue());
                txtV_DENOMINACION_PUESTO.Text = oPuesto.V_PUESTO_COMPUESTO;
            }
            catch
            {
                txtV_DENOMINACION_PUESTO.Text = String.Empty;
            }
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            mdlTutorial.Hide();
        }


        protected void btnVerTutorial_Click(object sender, EventArgs e)
        {
            mdlTutorial.Show(true);
        }

        protected void qstRegistroExitoso_Yes(object Sender, EventArgs e)
        {
            Response.Redirect("Login");
        }
    }
}