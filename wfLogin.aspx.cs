using checadorAsp.APP_statics;
using checadorAsp.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace checadorAsp
{
    public partial class wfLogin : System.Web.UI.Page
    {
        private dbop db;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new dbop();

            if (globals.logedIn)
            {
                globals.go(this.Page,"wfCentral.aspx");
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            if(this.txtusuario.Text.Trim() != string.Empty && this.txtpassword.Text.Trim() != string.Empty)
            {
                if(this.db.login(this.txtusuario.Text.Trim(), this.txtpassword.Text.Trim()))
                {
                    globals.logedIn = true;
                    globals.go(this.Page,"wfCentral.aspx");
                }
                else
                {
                    globals.show(this.Page, "Credenciales Incorrectas!");
                }
            }
            else
            {
                globals.show(this.Page,"Ingrese Crendenciales!");
            }
        }
    }
}