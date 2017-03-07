using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region "PATRON SINGLETON"
        private static Conexion conexion = null;
        private Conexion() { }
        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public SqlConnection ConexionBD()
        {
            SqlConnection conexion = new SqlConnection();
            //conexion.ConnectionString = "Data Source=0.0.0.0; Initial Catalog=test; User ID=ss; Password=qRr8/1qNn__aaaaw|";
            conexion.ConnectionString = GetConnectionString();
            return conexion;
        }

        public String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["local_clinica"].ConnectionString;
        }

    }
}
