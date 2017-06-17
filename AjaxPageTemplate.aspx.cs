using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspdotnet_webform_template
{
    public partial class AjaxPageTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Request.QueryString.Get("AjaxRequest")) && Request.QueryString.Get("AjaxRequest") == "true")
                HandleAjaxRequest();
        }

        protected virtual void HandleAjaxRequest()
        {
            contentAjax.Controls.Add(new LiteralControl("<p>this is ajax requset line 1</p>"));
            contentAjax.Controls.Add(new LiteralControl("<p>this is ajax requset line 2</p>"));
        }
    }
}