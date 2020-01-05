using checadorAsp.APP_statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace checadorAsp
{
    public partial class wfCentral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!globals.logedIn)
            {
                globals.go(this.Page, "wfLogin.aspx");
            }
        }

        protected void btnA_Click(object sender, EventArgs e)
        {
            globals.go(this.Page,"Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            globals.go(this.Page, "wfConsulta.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            globals.go(this.Page, "wfRegUsr.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            globals.go(this.Page, "wfUpdateUsr.aspx");
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            globals.logedIn = false;
            globals.go(this.Page, "wfLogin.aspx");
        }
    }
}