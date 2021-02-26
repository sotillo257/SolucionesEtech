using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using AccesoDato;

namespace LogicaNegocio
{
    public class lnViajes
    {
        adViajes _AD = new adViajes();
        public List<Viaje> ObtenerViajes()
        {
            try
            {
                return _AD.ObtenerViajes();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Viaje ObtenerViaje(int pId)
        {
            try
            {
                return _AD.ObtenerViaje(pId);
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
            try
            {
                return _AD.ObtenerViajesExcluyendoViajero(pIdViajero); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       

        public bool InsertarViaje(Viaje pViaje)
        {
            try
            {
                return _AD.InsertarViaje(pViaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool ModificarViaje(Viaje pViaje)
        {
            try
            {
                _AD.ModificarViaje(pViaje);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool EliminarViaje(int pId)
        {
            try
            {
                _AD.EliminarViaje(pId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
