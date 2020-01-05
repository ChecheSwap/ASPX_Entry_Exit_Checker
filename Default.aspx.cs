using checadorAsp.APP_statics;
using checadorAsp.DB;
using checadorAsp.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace checadorAsp
{
    public partial class _Default : Page
    {
        private dbop db;        
        protected void Page_Load(object sender, EventArgs e)
        {
            globals.current_asp_page = this;                       
            this.db = new dbop();
            this.getAllRegisters();
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }
        protected void btnreg_Click(object sender, EventArgs e)
        {
            this.clickAdd();            
        }   

        private void clickAdd()
        {
            if (txtfolio.Text != string.Empty)
            {
                if (this.db.existFolio(txtfolio.Text.Trim()))
                {
                    registros rtmp = new registros(txtfolio.Text.Trim());

                    if (this.db.insertReg(rtmp))
                    {
                        globals.show(this.Page, "Registro Guardado Satisfactoriamente...");
                        this.txtfolio.Text = string.Empty;
                        globals.go(this.Page,"Default.aspx");       
                    }
                    else
                    {
                        globals.show(this.Page, "Problema al Guardar Registro, contacte al Adminsitrador del Sistema...");
                    }
                }
                else
                {
                    globals.show(this.Page, "Folio Inexistente, Corrija...");
                }

                this.txtfolio.Focus();
            }
            else
            {
                globals.show(this.Page, "Ingrese Folio de Usuario.");
                this.txtfolio.Focus();
            }
        }

        private void getAllRegisters()
        {
            this.clearTableClient();

            foreach (bitacora b in db.getRegistros(new bitacora(null, null, null, null)))
            {
                addToTable(b);
            }
                        
        }
        private void addToTable(bitacora registro)
        {
            TableRow tr = new TableRow();
            TableCell[] tcx = new TableCell[3];

            for (int x = 0; x < 3; ++x)
            {
                tcx[x] = new TableCell() { BorderStyle = BorderStyle.Solid, HorizontalAlign = HorizontalAlign.Center, BackColor = System.Drawing.Color.Transparent };
            }

            tcx[0].Text = registro.folio;
            tcx[1].Text = registro.fecha;
            tcx[2].Text = registro.hora;

            for (int x = 0; x < 3; ++x)
            {
                tr.Cells.Add(tcx[x]);
            }

            this.tab1.Rows.Add(tr);             
        }


        private void clearTableClient()
        {
            for(int x = 1; x < this.tab1.Rows.Count; ++x)
            {
                this.tab1.Rows.RemoveAt(x);
            }
        }

        protected void btnHome_Click1(object sender, EventArgs e)
        {
            globals.go(this.Page, "Default.aspx");
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            globals.logedIn = false;
            globals.go(this.Page, "wfLogin.aspx");
        }
    }
}