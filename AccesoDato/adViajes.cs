using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AccesoDato
{
    public class adViajes : Conexion
    {
        public Viaje ObtenerViaje(int pId)
        {
            Viaje Viaje = null;
            string sql = @"[sp_ObtenerViaje] '{0}' ";
            sql = string.Format(sql, pId);

            try
            {
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Viaje = new Viaje()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Codigo = item["Codigo"].ToString(),
                            NumeroPlazas = int.Parse(item["NumeroPlazas"].ToString()),
                            Precio = decimal.Parse(item["Precio"].ToString()),
                            Destino = new AereoPuerto() { Id = int.Parse(item["IdDestino"].ToString()), Nombre = item["NombreDestino"].ToString() },
                            Origen = new AereoPuerto() { Id = int.Parse(item["IdOrigen"].ToString()), Nombre = item["NombreOrigen"].ToString() }
                        };
                    }
                }
                
                
                return Viaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Viaje> ObtenerViajes()
        {
            List<Viaje> Viajes = new List<Viaje>();
            string sql = @"[sp_ObtenerViajes]";
            try
            {
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Viajes.Add(new Viaje()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Codigo = item["Codigo"].ToString(),
                            NumeroPlazas = int.Parse(item["NumeroPlazas"].ToString()),
                            Precio = decimal.Parse(item["Precio"].ToString()),
                            Destino = new AereoPuerto() { Id = int.Parse(item["IdDestino"].ToString()), Nombre = item["NombreDestino"].ToString() },
                            Origen = new AereoPuerto() { Id = int.Parse(item["IdOrigen"].ToString()), Nombre = item["NombreOrigen"].ToString() }

                        });
                    }
                }
                return Viajes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Metodo que retorna una lista de viajes excluyendo los viajes realizados por el viajero
        /// </summary>
        /// <param name="pIdViajero"></param>
        /// <returns>List<Viaje></returns>
        public List<Viaje> ObtenerViajesExcluyendoViajero(int pIdViajero)
        {
            List<Viaje> Viajes = new List<Viaje>();
            string sql = @"[sp_ObtenerViajesxViajero] '{0}' ";
            sql = string.Format(sql, pIdViajero);
            try
            {
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        Viajes.Add(new Viaje()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Codigo = item["Codigo"].ToString(),
                            NumeroPlazas = int.Parse(item["NumeroPlazas"].ToString()),
                            Precio = decimal.Parse(item["Precio"].ToString()),
                            Destino = new AereoPuerto() { Id = int.Parse(item["IdDestino"].ToString()), Nombre = item["NombreDestino"].ToString() },
                            Origen = new AereoPuerto() { Id = int.Parse(item["IdOrigen"].ToString()), Nombre = item["NombreOrigen"].ToString() }

                        });
                    }
                }
                return Viajes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool InsertarViaje(Viaje pViaje)
        {
            string sql = @"[sp_InsertarViaje] '{0}', '{1}', '{2}', '{3}', '{4}'";
            sql = string.Format(sql, pViaje.Codigo, pViaje.NumeroPlazas, pViaje.Origen.Id, pViaje.Destino.Id, pViaje.Precio);
            try
            {
                return _MB.EjecutarSQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModificarViaje(Viaje pViaje)
        {
            string sql = @"[sp_ModificarViaje] '{0}', '{1}', '{2}', '{3}', '{4}', '{5}'";
            sql = string.Format(sql, pViaje.Id, pViaje.Codigo, pViaje.NumeroPlazas, pViaje.Origen.Id, pViaje.Destino.Id, pViaje.Precio);
            try
            {
                return _MB.EjecutarSQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarViaje(int pId)
        {
            string sql = @"[sp_EliminarViaje] '{0}'";
            sql = string.Format(sql, pId);
            try
            {
                _MB.EjecutarSQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
