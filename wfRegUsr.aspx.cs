using checadorAsp.APP_statics;
using checadorAsp.DB;
using checadorAsp.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace checadorAsp
{
    public partial class wfRegUsr : System.Web.UI.Page
    {
        private dbop db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!globals.logedIn)
            {
                globals.go(this.Page, "wfLogin.aspx");
            }
            this.db = new dbop();        
            
            if(!IsPostBack)
            {
                this.integraFolio();
            }
        }
        private void registra()
        {
            if((this.txtnombre.Text.Trim() != string.Empty)&&(this.txtapellido.Text.Trim() != string.Empty))
            {
                if (this.db.insertUsr(new usuarios(this.txtnombre.Text.Trim(), this.txtapellido.Text.Trim())))
                {
                    globals.nextfolio = this.db.next_folio();
                    globals.show(this.Page,"Usuario Registrado Satisfactoriamente...");
                    globals.go(this.Page, "wfRegUsr.aspx");
                }
            }
            else
            {
                globals.show(this.Page, "Ingrese Datos Validos...");
            }
        }

        protected void btnGuardaUsr_Click(object sender, EventArgs e)
        {
            this.registra();
        }

        private void integraFolio()
        {
            this.txtfolio.Text = this.db.next_folio();
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            globals.logedIn = false;
            globals.go(this.Page, "wfLogin.aspx");
        }
    }
}