﻿using AlanWebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeclaraINEAdmin.Formas
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((AlanTabsMenu)Master.FindControl("MenuPrincipal")).Activate("Index.aspx");
            }
        }
    }
}