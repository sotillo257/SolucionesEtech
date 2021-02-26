using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDato
{
    public class Conexion
    {
        public MetodosDB _MB = new MetodosDB();

        public SqlConnection connection = new SqlConnection();
    }
}
