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
    public partial class wfRegistraUsr : System.Web.UI.Page
    {
        private dbop db;
        protected void Page_Load(object sender, EventArgs e)
        {
            globals.current_asp_page = this;

            if (!globals.logedIn)
            {
                globals.go(this.Page, "wfLogin.aspx");
            }
            this.db = new DB.dbop();
            this.showNextFolio();
        }


        private void showNextFolio()
        {
            this.txtfolio.Text = this.db.next_folio();
        }

        private void registra()
        {/*
            if((this.txtnombre.Text.Trim() != string.Empty)&&(this.txtapellido.Text.Trim() != string.Empty))
            {
                if (this.db.insertUsr(new usuarios(this.txtnombre.Text.Trim(), this.txtapellido.Text.Trim())))
                {
                    globals.show(this.Page,"Usuario Registrado Satisfactoriamente...");
                    globals.go(this.Page, "wfRegistraUsr.aspx");
                }
            }
            else
            {
                globals.show(this.Page, "Ingrese Datos Validos...");
            }*/
        }

        protected void btnGuardaUsr_Click(object sender, EventArgs e)
        {
            globals.show(this.Page, "OK");
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            globals.logedIn = false;
            globals.go(this.Page, "wfLogin.aspx");
        }
    }
}