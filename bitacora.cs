using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace checadorAsp.logica
{
    public class bitacora
    {
        public string folio  = string.Empty;
        public string nombre = string.Empty;
        public string fecha  = string.Empty;        
        public string hora = string.Empty;


        public bitacora(string a, string b, string c, string d)
        {
            this.folio =  (a == null) ? "" : a;
            this.nombre = (b == null) ? "" : b;
            this.fecha  = (c == null) ? "" : c;
            this.hora   = (d == null) ? "" : d;

        }

    }
}