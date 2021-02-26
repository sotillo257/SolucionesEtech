using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AccesoDato
{
    public class adViajerosxViajes : Conexion
    {
        public ViajerosxViajes ObtenerViajeroxViaje(int pId)
        {
            ViajerosxViajes viajeroxViaje = null;
            string sql = @"[sp_OptenerViajeroxViaje] '{0}' ";
            sql = string.Format(sql, pId);

            try
            {
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        viajeroxViaje = new ViajerosxViajes()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Viajero = new Viajero()
                            {
                                Id = int.Parse(item["IdViajero"].ToString()),
                                Nombre = item["NombreViajero"].ToString(),
                                Cedula = item["Cedula"].ToString(),
                                Direccion = item["Direccion"].ToString(),
                                Telefono = item["Telefono"].ToString()
                            },
                            Viaje = new Viaje()
                            {
                                Id = int.Parse(item["IdViaje"].ToString()),
                                Codigo = item["Codigo"].ToString(),
                                NumeroPlazas = int.Parse(item["NumeroPlazas"].ToString()),
                                Precio = decimal.Parse(item["Precio"].ToString()),
                                Destino = new AereoPuerto() { Id = int.Parse(item["IdDestino"].ToString()), Nombre = item["NombreDestino"].ToString() },
                                Origen = new AereoPuerto() { Id = int.Parse(item["IdOrigen"].ToString()), Nombre = item["NombreOrigen"].ToString() }
                            }

                        };
                    }
                }
                return viajeroxViaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<ViajerosxViajes> ObtenerViajerosxViajes()
        {
            List<ViajerosxViajes> viajerosxViajes = new List<ViajerosxViajes>();
            string sql = @"[sp_ObtenerViajerosxViajes]";
            try
            {
                DataSet ds = _MB.RetornaDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        viajerosxViajes.Add(new ViajerosxViajes()
                        {
                            Id = int.Parse(item["Id"].ToString()),
                            Viajero = new Viajero()
                            {
                                Id = int.Parse(item["IdViajero"].ToString()),
                                Nombre = item["NombreViajero"].ToString(),
                                Cedula = item["Cedula"].ToString(),
                                Direccion = item["Direccion"].ToString(),
                                Telefono = item["Telefono"].ToString()
                            },
                            Viaje = new Viaje()
                            {
                                Id = int.Parse(item["IdViaje"].ToString()),
                                Codigo = item["Codigo"].ToString(),
                                NumeroPlazas = int.Parse(item["NumeroPlazas"].ToString()),
                                Precio = decimal.Parse(item["Precio"].ToString()),
                                Destino = new AereoPuerto() { Id = int.Parse(item["IdDestino"].ToString()), Nombre = item["NombreDestino"].ToString() },
                                Origen = new AereoPuerto() { Id = int.Parse(item["IdOrigen"].ToString()), Nombre = item["NombreOrigen"].ToString() }
                            }

                        });
                    }
                }
                return viajerosxViajes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool InsertarViajeroxViaje(ViajerosxViajes pviajerosxViajes)
        {
            string sql = @"[sp_InsertarViajeroxViaje] '{0}', '{1}'";
            sql = string.Format(sql, pviajerosxViajes.Viajero.Id, pviajerosxViajes.Viaje.Id);
            try
            {
                return _MB.EjecutarSQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModificarViajeroxViaje(ViajerosxViajes pviajerosxViajes)
        {
            string sql = @"[sp_ModificarViajeroxViaje] '{0}', '{1}', '{2}'";
            sql = string.Format(sql, pviajerosxViajes.Id, pviajerosxViajes.Viajero.Id, pviajerosxViajes.Viaje.Id);
            try
            {
                return _MB.EjecutarSQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarViajeroxViaje(int pId)
        {
            string sql = @"[sp_EliminarViajeroxViaje] '{0}'";
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
