﻿using System;

namespace EYE
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("View/Login.aspx");
        }
    }
}