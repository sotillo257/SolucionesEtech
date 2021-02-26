using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AccesoDato
{
    public class adAereoPuertos :Conexion
    {
        public AereoPuerto ObtenerAereoPuerto(int pId)
        {
            AereoPuerto AereoPuerto = null;
            string sql = @"[sp_OptenerAereoPuerto] '{0}' ";
            sql = string.Format(sql, pId);

            try
            {
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        AereoPuerto = new AereoPuerto()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Nombre = item["Nombre"].ToString()
                        };
                    }
                }
                return AereoPuerto;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<AereoPuerto> ObtenerAereoPuertos()
        {
            List<AereoPuerto> AereoPuertos = new List<AereoPuerto>();
            string sql = @"[sp_ObtenerAereoPuertos]";
            try
            {
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        AereoPuertos.Add(new AereoPuerto()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Nombre = item["Nombre"].ToString()
                        });
                    }
                }
                return AereoPuertos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
