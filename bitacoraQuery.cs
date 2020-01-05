using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace checadorAsp.logica
{
    public class bitacoraQuery
    {
        public string folio = string.Empty;
        public string nombre = string.Empty;
        public string fecha = string.Empty;
        public string fecha2 = string.Empty;

        public bitacoraQuery(string a, string b, string c, string d)
        {
            this.folio = (a == null) ? "" : a;
            this.nombre = (b == null) ? "" : b;
            this.fecha = (c == null) ? "" : c;
            this.fecha2 = (d == null) ? "" : d;

        }
    }
}