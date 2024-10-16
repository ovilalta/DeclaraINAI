using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Declara_V2.Exceptions;

namespace DeclaraINAI.Formas
{
    public partial class SioNo : System.Web.UI.UserControl
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
                        return rbtnYes.Checked;
                }
                else
                    return rbtnYes.Checked;
            }
            set
            {
                if (value.HasValue)
                {
                    rbtAny.Checked = false;
                    rbtAny.Visible = false;
                    rbtnYes.Checked = value.Value;
                    rbtNo.Checked = !value.Value;
                }
                else
                {
                    rbtAny.Checked = true;
                    rbtAny.Visible = true;
                    rbtnYes.Checked = false;
                    rbtNo.Checked = false;
                }
            }
        }

        public Boolean Checked
        {
            get
            {
                if (rbtAny.Visible)
                {
                    if (rbtAny.Checked)
                        throw new CustomException("Debe responder a todas las preguntas de \"Si ó No\"");
                    else
                        return rbtnYes.Checked;
                }
                else
                    return rbtnYes.Checked;
            }
            set
            {
                rbtAny.Checked = false;
                rbtAny.Visible = false;
                rbtnYes.Checked = value;
                rbtNo.Checked = !value;
            }
        }

        public Object CommandArgument
        {
            get => (Object)ViewState["CommandArgument"];
            set => ViewState["CommandArgument"] = value;
        }

        public Boolean AutoPostBack
        {
            get => rbtnYes.AutoPostBack;
            set
            {
                rbtnYes.AutoPostBack = value;
                rbtNo.AutoPostBack = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public delegate void EditarHandler(object sender, EventArgs e);
        public event EditarHandler Change;

        public void Changed(Object Sender, EventArgs e)
        {
            OnCheckedChanged(this, e);
        }

        protected virtual void OnCheckedChanged(Object Sender, EventArgs e)
        {
            Change?.Invoke(Sender, e);
        }

    }
}