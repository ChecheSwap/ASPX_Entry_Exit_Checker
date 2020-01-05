using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace checadorAsp.DB
{
    public static class SQLQ
    {
        public static string connectionString = "Data Source=VESTIGIUM_SENEX; Initial Catalog=checador; User ID=.|.; Password=.|.";

        public static string GetBitacora      = "dbo.bdConsulta";

        public static string InsertReg        = "dbo.bdInsertReg";

        public static string InsertUsr        = "dbo.bdInsertUsr";

        public static string existUsr         = "dbo.bdExistUsr";

        public static string nextFolio        = "dbo.bdNextFolio";

        public static string getUsr           = "dbo.bdGetUsr";

        public static string updateUsr        = "dbo.bdUpdateUsr";

        public static string deleteUsr        = "dbo.bdDeleteUsr";

        public static string login            = "dbo.bdLogin";
    }
}
