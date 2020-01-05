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
    public partial class wfUpdateUsr : System.Web.UI.Page
    {
        private dbop db;
        private usuarios usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            globals.current_asp_page = this.Page;
            this.db = new dbop();
            if (!globals.logedIn)
            {
                globals.go(this.Page, "wfLogin.aspx");
            }

            if (globals.usuario != null)
            {
                this.llena(globals.usuario);
                globals.usuario = null;
                this.btnEliminar.Enabled = true;
                this.btnGuardaUsr.Enabled = true;
            }
            else
            {
                this.btnEliminar.Enabled = false;
                this.btnGuardaUsr.Enabled = false;
            }
        }

        protected void btnbusqueda_Click(object sender, EventArgs e)
        {
            if(this.txtcabecero.Text.Trim() != String.Empty)
            {
                if (this.db.existFolio(this.txtcabecero.Text.Trim()))
                {
                    globals.usuario = this.db.getUsr(this.txtcabecero.Text.Trim());
                    globals.go(this.Page,"wfUpdateUsr.aspx");
                }
                else
                {
                    globals.show(this.Page, "Folio de Usuario Invalido...");
                    this.txtfolio.Text = string.Empty;
                    this.txtfolio.Focus();
                }
            }
            else
            {
                globals.show(this.Page, "Ingrese Folio de Usuario...");
            }
        }

        protected void btnGuardaUsr_Click(object sender, EventArgs e)
        {
            usuarios usuario = new usuarios();

            usuario.folio = this.txtfolio.Text;
            usuario.nombre = this.txtnombre.Text;
            usuario.apellido = this.txtapellido.Text;

            if (usuario.nombre == string.Empty || usuario.apellido == string.Empty)
            {
                globals.show(this.Page,"Complete Valores a Actualizar...");                
            }
            else
            {
                if (this.db.updateUsr(usuario)){
                    globals.show(this.Page, "Usuario Actualizado...");
                    globals.go(this.Page,"wfUpdateUsr.aspx");
                }
            }
                       
        }

        private void llena(usuarios usuario)
        {
            this.txtfolio.Text    = usuario.folio;
            this.txtnombre.Text   = usuario.nombre;
            this.txtapellido.Text = usuario.apellido;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.db.deleteUsr(this.txtfolio.Text.Trim()))
            {
                globals.show(this.Page,"Usuario Eliminado!");
                globals.go(this.Page, "wfUpdateUsr.aspx");
            }
            else
            {
                globals.show(this.Page, "Problema al Eliminar Usuario, Contacte a Soporte...");
            }            
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            globals.logedIn = false;
            globals.go(this.Page, "wfLogin.aspx");
        }
    }
}