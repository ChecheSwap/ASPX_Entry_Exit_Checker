using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace checadorAsp.logica
{
    public class registros
    {
        public string id    = "";
        public string fecha = "";
        public string hora  = "";
        public string folio = "";

        public registros(string folio)
        {
            if(folio != null)
            {
                this.folio= folio;
            }
        }
    }
}