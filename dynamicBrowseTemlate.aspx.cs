using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspdotnet_webform_template
{
    public partial class dynamicBrowseTemlate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++ )
            {

                LiteralControl htmlDivBegin = new LiteralControl("<div>");
                LiteralControl htmlDivEnd = new LiteralControl("</div>");

                Label lblLoginName = new Label();
                lblLoginName.ID = "lblLoginId" + "_" + i;
                lblLoginName.Text = "LoginName" + "_" + i;

                TextBox txtLoginName = new TextBox();
                txtLoginName.ID = "txtloginId" + "_" + i;
                txtLoginName.Text = "Jaden" + "_" + i;


                LinkButton b = new LinkButton();
                b.Click += b_Click;

                //Button b1 = new Button();
                //b1.ID = "testID";
                //b1.Click

                
                plhContainer.Controls.Add(htmlDivBegin);

                plhContainer.Controls.Add(lblLoginName);
                plhContainer.Controls.Add(txtLoginName);

                plhContainer.Controls.Add(htmlDivEnd);
            }

        }

        void b_Click(object sender, EventArgs e)
        {
            
        }
    }
}