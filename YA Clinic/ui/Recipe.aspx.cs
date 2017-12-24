﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YA_Clinic.ui.Controller;

namespace YA_Clinic.ui
{
    public partial class Recipe : System.Web.UI.Page
    {
        RecipeController controller = new RecipeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                onRequestData();
            }
        }

        private void onRequestData()
        {
            dgv_Recipe.DataSource = controller.recipeData();
            dgv_Recipe.DataBind();
        }

        protected void dgv_Recipe_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            onRequestData();
            dgv_Recipe.PageIndex = e.NewPageIndex;
            dgv_Recipe.DataBind();
        }
    }
}