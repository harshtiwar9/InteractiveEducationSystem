﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveEducationSystem.FrontEnd
{
    public partial class StudentMaster : System.Web.UI.MasterPage
    {
        string pagename;
        protected void Page_Load(object sender, EventArgs e)
        {
            pagename = (string)Session["PageName"];
            if (pagename != null)
            {
                UserPageName.Text = pagename;
            }
            else
            {
                LoginDetails.Visible = false;
            }
        }
    }
}