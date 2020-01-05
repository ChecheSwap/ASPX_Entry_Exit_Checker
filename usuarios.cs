using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace checadorAsp.logica
{
    public class usuarios
    {
        public int     id;
        public string folio;
        public string nombre = "";
        public string apellido = "";
        public usuarios()
        {

        }

        public usuarios(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;            
        }
    }
}