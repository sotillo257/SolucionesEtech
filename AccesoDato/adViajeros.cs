using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AccesoDato
{
    public class adViajeros : Conexion
    {
        public Viajero ObtenerViajero(int pId)
        {
            Viajero viajero = null;
            string sql = @"[sp_OptenerViajero] '{0}' ";
            sql = string.Format(sql, pId);

            try
            {
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        viajero = new Viajero()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Nombre = item["Nombre"].ToString(),
                            Cedula = item["Cedula"].ToString(),
                            Direccion = item["Direccion"].ToString(),
                            Telefono = item["Telefono"].ToString()

                        };
                    }
                }
                return viajero;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Viajero> ObtenerViajeros()
        {
            List<Viajero> viajeros = new List<Viajero>();
            string sql = @"[sp_ObtenerViajeros]";
            try
            { 
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        viajeros.Add(new Viajero()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Nombre = item["Nombre"].ToString(),
                            Cedula = item["Cedula"].ToString(),
                            Direccion = item["Direccion"].ToString(),
                            Telefono = item["Telefono"].ToString()

                        });
                    }
                }
                return viajeros;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool InsertarViajero(Viajero pViajeros)
        {
            string sql = @"[sp_InsertarViajero] '{0}', '{1}', '{2}', '{3}'";
            sql = string.Format(sql, pViajeros.Nombre, pViajeros.Cedula, pViajeros.Direccion, pViajeros.Telefono);
            try
            {
                return _MB.EjecutarSQL( sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModificarViajero(Viajero pViajeros)
        {
            string sql = @"[sp_ModificarViajero] '{0}', '{1}', '{2}', '{3}', '{4}'";
            sql = string.Format(sql, pViajeros.Id, pViajeros.Nombre, pViajeros.Cedula, pViajeros.Direccion, pViajeros.Telefono);
            try
            {
                return _MB.EjecutarSQL( sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public bool EliminarViajero(int pId)
        {
            string sql = @"[sp_EliminarViajero] '{0}'";
            sql = string.Format(sql, pId);
            try
            {
               return _MB.EjecutarSQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
