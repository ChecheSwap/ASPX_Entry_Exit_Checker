using checadorAsp.APP_statics;
using checadorAsp.logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace checadorAsp.DB
{
    public class dbop
    {
        private List<bitacora> lstBitacora = default(List<bitacora>);
        private SqlConnection xconn        = default(SqlConnection);
        private string mssqlPath           = SQLQ.connectionString;
        public bool login(string usr, string pass)
        {
            bool flag = false;

            if (this.connect())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.login, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@usr",usr);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                flag = !flag;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    globals.show(globals.current_asp_page, ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }

            return flag;
        }
        public bool deleteUsr(string folio)
        {
            bool flag = false;
            if (this.connect())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.deleteUsr, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@folio", folio);

                        cmd.ExecuteNonQuery();

                        flag = !flag;
                    }
                }
                catch(Exception ex)
                {
                    globals.show(globals.current_asp_page,ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }
            return flag;
        }
        public bool updateUsr(usuarios usuario)
        {
            bool flag = false;

            if (this.connect())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.updateUsr, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@folio", usuario.folio);
                        cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                        cmd.Parameters.AddWithValue("@apellido", usuario.apellido);

                        cmd.ExecuteNonQuery();

                        flag = true;
                    }
                }
                catch(Exception ex)
                {
                    globals.show(globals.current_asp_page,ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }

            return flag;
        }
        public usuarios getUsr(string folio)
        {
            usuarios usuario = null;
            if (this.connect())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.getUsr, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@folio",folio);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                usuario = new usuarios();
                                reader.Read();

                                usuario.folio = reader[1].ToString();
                                usuario.nombre = reader[2].ToString();
                                usuario.apellido = reader[3].ToString();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    globals.show(globals.current_asp_page, ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }
            return usuario;
        }
        public string next_folio()
        {
            string nextfolio = string.Empty;
            if (this.connect())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.nextFolio, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                nextfolio = reader[0].ToString();
                            }
                            reader.Close();
                        }
                        cmd.Dispose();
                    }
                }
                catch(Exception ex)
                {
                    globals.show(globals.current_asp_page, ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }
            return nextfolio;
        }
        public bool insertUsr(usuarios usuario)
        {
            bool flag = false;

            if (this.connect())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.InsertUsr, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                        cmd.Parameters.AddWithValue("@apellido", usuario.apellido);

                        cmd.ExecuteNonQuery();
                        flag = !flag;
                    }
                }
                catch(Exception ex)
                {
                    globals.show(globals.current_asp_page,ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }
            return flag;
        }
        public bool existFolio(string folio)
        {
            bool flag = false;

            if (this.connect())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.existUsr, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@folio",folio);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                flag = !flag;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    globals.show(globals.current_asp_page, ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }
            return flag;

        }
        public bool insertReg(registros registro)
        {
            bool flag = false;
            if (this.connect())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.InsertReg, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@folio",registro.folio).Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        flag = !flag;
                    }
                }
                catch(Exception ex)
                {
                    globals.show(globals.current_asp_page,ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }
            return flag;
        }

        public List<bitacora> getRegistros2(bitacora rbitacora)
        {
            bitacora tmp = default(bitacora);
            this.lstBitacora = new List<bitacora>();

            if (this.connect())
            {

                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.GetBitacora, this.xconn))
                    {
                        cmd.CommandText = "SELECT * FROM vwBitacora";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    tmp = new bitacora(reader[0].ToString(), reader[1].ToString(),
                                                        reader[2].ToString(), reader[3].ToString());
                                    this.lstBitacora.Add(tmp);
                                }
                            }
                            reader.Close();
                        }
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    globals.show(globals.current_asp_page, ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }

            return this.lstBitacora;
        }

        public List<bitacora> getRegistros(bitacora rbitacora)
        {
            bitacora tmp = default(bitacora);
            this.lstBitacora = new List<bitacora>();

            if (this.connect())
            {

                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.GetBitacora, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@folio" ,  rbitacora.folio).Direction= ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("@nombre",  rbitacora.nombre).Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("@fecha" ,  rbitacora.fecha ).Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("@fecha2"  , rbitacora.hora  ).Direction = ParameterDirection.Input;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {                                                 
                            if (reader.HasRows)
                            {                                
                                while (reader.Read())
                                {                                    
                                    tmp = new bitacora(reader[0].ToString(), reader[1].ToString(),
                                                        reader[2].ToString(), reader[3].ToString());                                    
                                    this.lstBitacora.Add(tmp);
                                }
                            }
                            reader.Close();
                        }
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    globals.show(globals.current_asp_page,ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }

            return this.lstBitacora;
        }

        public List<bitacora> getBitacora(bitacoraQuery rbitacora)
        {
            bitacora tmp = default(bitacora);
            this.lstBitacora = new List<bitacora>();

            if (this.connect())
            {

                try
                {
                    using (SqlCommand cmd = new SqlCommand(SQLQ.GetBitacora, this.xconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@folio", rbitacora.folio).Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("@nombre", rbitacora.nombre).Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("@fecha", rbitacora.fecha).Direction = ParameterDirection.Input;
                        cmd.Parameters.AddWithValue("@fecha2", rbitacora.fecha2).Direction = ParameterDirection.Input;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    tmp = new bitacora(reader[0].ToString(), reader[1].ToString(),
                                                        reader[2].ToString(), reader[3].ToString());
                                    this.lstBitacora.Add(tmp);
                                }
                            }
                            reader.Close();
                        }
                        cmd.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    globals.show(globals.current_asp_page, ex.Message.ToString());
                }
                finally
                {
                    this.disconn();
                }
            }

            return this.lstBitacora;
        }

        public bool connect()
        {
            bool flag = true;
            try
            {
                this.xconn = new SqlConnection(this.mssqlPath);
                this.xconn.Open();                
            }
            catch(Exception ex)
            {                
                flag = !flag;
                ex.Message.ToString();
            }

            return flag;
        }

        public bool disconn()
        {
            bool flag = true;
            try
            {
                if (this.xconn.State == System.Data.ConnectionState.Open)
                {
                    this.xconn.Close();
                    this.xconn.Dispose();
                }
            }
            catch (Exception ex)
            {
                flag = !flag;
            }

            return flag;
        }
    }
}