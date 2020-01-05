using checadorAsp.logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace checadorAsp.APP_statics
{
    public static class globals
    {
        public static List<TableRow> lst_registers = new List<TableRow>() { };

        public static List<bitacora> lst_consulta;

        public static bitacoraQuery rBitacoraQ = null;

        public static Page current_asp_page;

        public static string nextfolio;

        public static usuarios usuario = null;

        public static bool logedIn = false;
        private static string msg(string msg){
           return $"alert('{msg}')";            
        }  
        
        public static void go(Page page,string url)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "redirect", "window.location='" + page.Request.ApplicationPath + url+"';", true);
        }
        public static void show(Page page, string txt)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", globals.msg(txt), true);
        }      
    }
}