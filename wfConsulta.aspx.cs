using checadorAsp.APP_statics;
using checadorAsp.DB;
using checadorAsp.logica;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace checadorAsp
{
    public partial class wfConsulta : System.Web.UI.Page
    {
        private dbop db;

        Microsoft.Office.Interop.Excel.Application excel;
        Microsoft.Office.Interop.Excel.Workbook    excelworkBook;
        Microsoft.Office.Interop.Excel.Worksheet   excelSheet;
        Microsoft.Office.Interop.Excel.Range       excelCellrange;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!globals.logedIn)
            {
                globals.go(this.Page, "wfLogin.aspx");
            }

            this.db = new dbop();

            this.lblcount.Text = "Registros: 0";

            if (globals.rBitacoraQ != null)
            {
                this.consulta();
                globals.rBitacoraQ = null;
            }
        }
        protected void btnreg_Click(object sender, EventArgs e)
        {            
            this.validaconsulta();
        }
        protected void btnHome_Click1(object sender, EventArgs e)
        {
        }
        private void consulta(bool flag = false)
        {
            int contador = 0;
            if (!flag)
            {
                globals.lst_consulta = this.db.getBitacora(globals.rBitacoraQ);

                foreach (var rBitacora in globals.lst_consulta)
                {
                    this.addToTable(rBitacora);
                    ++contador;
                }                
            }
            else
            {
                bitacoraQuery bTmp = new bitacoraQuery(null, null, null, null);

                globals.lst_consulta = this.db.getBitacora(bTmp);

                foreach (var rBitacora in this.db.getBitacora(bTmp))
                {
                    this.addToTable(rBitacora);
                    ++contador;
                }
                
            }
            this.lblcount.Text = "Total de Registros Obtenidos: " + contador.ToString();
        }
        private void validaconsulta()
        {  
            if ((this.txtfolio.Text.Trim() != string.Empty) || (this.txtnombre.Text.Trim() != string.Empty) ||
               (this.txtfecha.Text.Trim() != string.Empty) || (this.txtfechafinal.Text.Trim() != string.Empty))
            {
                globals.rBitacoraQ = new bitacoraQuery(this.txtfolio.Text.Trim(),
                                                       this.txtnombre.Text.Trim(),
                                                       this.txtfecha.Text.Trim(),
                                                       this.txtfechafinal.Text.Trim());
                globals.go(this.Page,"wfConsulta.aspx");
            }
            else
            {
                globals.show(this.Page,"Ingrese Almenos una Rubrica de Consulta");
            }
        }

        private void addToTable(bitacora registro)
        {
            TableRow tr = new TableRow();

            TableCell[] tcx = new TableCell[4];

            for (int x = 0; x < 4; ++x)
            {
                tcx[x] = new TableCell() { BorderStyle = BorderStyle.Solid, HorizontalAlign = HorizontalAlign.Center, BackColor = System.Drawing.Color.Transparent };
            }

            tcx[0].Text = registro.folio;
            tcx[1].Text = registro.nombre;
            tcx[2].Text = registro.fecha;
            tcx[3].Text = registro.hora;

            for (int x = 0; x < 4; ++x)
            {
                tr.Cells.Add(tcx[x]);
            }

            this.tab1.Rows.Add(tr);
        }
        private void convertToPdf()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Clave de Usuario"    , typeof(string));
            dt.Columns.Add("Nombre de Usuario"   , typeof(string));
            dt.Columns.Add("Fecha Inicial"       , typeof(string));
            dt.Columns.Add("Fecha Final"         , typeof(string));

            foreach (var dr in globals.lst_consulta)
            {                
                dt.Rows.Add(dr.folio,
                            dr.nombre,
                            dr.fecha,
                            dr.hora);
            }

            Document document = new Document();                         

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"c://pdf/reporteBitacora.pdf", FileMode.Create));

            document.Open();

            Font font5 = FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow   row = null;

            float[] widths = new float[] { 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;

            int    iCol = 0;
            string colname = "";

            PdfPCell cell = new PdfPCell(new Phrase("C1"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {
                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                }
            }

            document.Add(table);

            document.Close();
        }
        private void convertToExcel()
        {
            try
            {
                this.excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                this.excelworkBook = excel.Workbooks.Add(Type.Missing);

                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = "Consulta Checador";

                int ri = 0;
                foreach (DataRow dr in this.tab1.Rows)
                {
                    ++ri;
                    excelSheet.Cells[ri, 1] = dr[0].ToString();
                    excelSheet.Cells[ri, 2] = dr[1].ToString();
                    excelSheet.Cells[ri, 3] = dr[2].ToString();
                    excelSheet.Cells[ri, 4] = dr[3].ToString();
                }
                globals.show(this.Page, HttpContext.Current.Server.MapPath("~"));
                excelworkBook.SaveAs(HttpContext.Current.Server.MapPath("~") + "Okey");
                excelworkBook.Close();
                excel.Quit();
            }
            catch (Exception ex)
            {
                globals.show(this.Page, ex.Message.ToString());
            }
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            this.txtfolio.Text = null;
            this.txtnombre.Text = null;
            this.txtfecha.Text = null;
            this.txtfechafinal.Text = null;

            this.consulta(true);

            this.txtfolio.Focus();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {

            if (globals.lst_consulta != null && globals.lst_consulta.Count > 0)
            {
                try
                {
                    this.convertToPdf();
                    Process.Start("c://pdf/reporteBitacora.pdf");
                }
                catch(Exception ex)
                {
                    globals.show(this.Page,ex.Message.ToString());
                }
            }
            else
            {
                globals.show(this.Page, "Tabla de resultados Vacia...");
            }
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            globals.logedIn = false;
            globals.go(this.Page, "wfLogin.aspx");
        }
    }
}